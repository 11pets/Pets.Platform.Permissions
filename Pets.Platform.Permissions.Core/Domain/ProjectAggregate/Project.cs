using Pets.Platform.Permissions.Core.Domain.ProjectAggregate.Events;
using Pets.Platform.Permissions.Core.Exceptions;

namespace Pets.Platform.Permissions.Core.Domain.ProjectAggregate
{
    public class Project : Entity<long>, IAggregateRoot
    {
        public DateTime CreatedAt { get; private set; }

        private long? _ownerId { get; set; }

        private readonly List<ProjectUser> _participants;
        public IReadOnlyCollection<ProjectUser> Participants => _participants;

        private readonly List<ProjectSLA> _sLAs;
        public IReadOnlyCollection<ProjectSLA> SLAs => _sLAs;

        private readonly List<ProjectResourceQuota> _projectResourceQuotas;
        public IReadOnlyCollection<ProjectResourceQuota> ProjectResourceQuotas => _projectResourceQuotas;

        private readonly List<ProjectProductFamily> _productFamilyAssignments;
        public IReadOnlyCollection<ProjectProductFamily> ProductFamilyAssignments => _productFamilyAssignments;

        public ProjectSettings ProjectSettings { get; private set; }

        protected Project()
        {
            CreatedAt = DateTime.UtcNow;

            _participants = new List<ProjectUser>();
            _sLAs = new List<ProjectSLA>();
            _projectResourceQuotas = new List<ProjectResourceQuota>();
            _productFamilyAssignments = new List<ProjectProductFamily>();
        }

        public Project(long id)
            : this()
        {
            Id = id;
            ProjectSettings = new ProjectSettings();
        }

        public void AddParticipant(long userId, long roleId)
        {
            //// verify that the role is permitted
            //var permittedRoles = _productFamilyAssignments.SelectMany(a => a.ProductFamily.AllowedRoles.ToList());
            //var isRolePermitted = permittedRoles.Any(r => r.RoleId == roleId);

            //if(!isRolePermitted)
            //{
            //    throw new ProjectDomainException($"Role {roleId} is not permitted in project {Id}");
            //}

            var exists = ExistsParticipant(userId, roleId);

            if (exists)
            {
                return;
            }
            else
            {
                if (_participants.Count == 0)
                {
                    _ownerId = userId;
                }

                _participants.Add(new ProjectUser(userId, roleId));
            }
        }

        public bool RemoveParticipant(long userId, long roleId)
        {
            if (userId <= 0)
            {
                throw new ProjectDomainException("Cannot remove participant. See inner exception for details.",
                    new ArgumentOutOfRangeException(nameof(userId), "Invalid value"));
            }

            if (roleId <= 0)
            {
                throw new ProjectDomainException("Cannot remove participant. See inner exception for details.",
                    new ArgumentOutOfRangeException(nameof(roleId), "Invalid value"));
            }

            var participant = GetParticipant(userId, roleId);

            if (participant == null)
            {
                return true;
            }

            return _participants.Remove(participant);
        }

        public bool RemoveParticipant(ProjectUser user)
        {
            if (user == null)
                throw new ProjectDomainException("Cannot remove participant. See inner exception for details.",
                    new ArgumentNullException(nameof(user)));

            return _participants.Remove(user);
        }

        public void ChangeOwner(long userId)
        {
            _ownerId = userId;
        }

        public long? GetOwner()
        {
            return _ownerId;
        }

        public void AddSLA(string slaId)
        {
            if (string.IsNullOrWhiteSpace(slaId))
            {
                throw new ProjectDomainException("Cannot add SLA. See inner exception for details.",
                    new ArgumentOutOfRangeException(nameof(slaId), "Invalid value"));
            }

            if (ExistsSLA(slaId))
            {
                return;
            }

            _sLAs.Add(new ProjectSLA(slaId));
            AddProjectSLAAssignedDomainEvent(slaId);
        }

        public bool RemoveSLA(string slaId)
        {
            var sla = GetSLA(slaId);
            if (sla == null)
            {
                return true;
            }

            AddProjectSLARemovedDomainEvent(slaId);

            return _sLAs.Remove(sla);
        }

        public void AddProductFamily(string productFamilyId)
        {
            if (HasProductFamily(productFamilyId))
            {
                return;
            }

            _productFamilyAssignments.Add(new ProjectProductFamily(productFamilyId));
            AddProductFamilyAddedDomainEvent(productFamilyId);
        }

        public bool RemoveProductFamily(string productFamilyId)
        {
            if (string.IsNullOrWhiteSpace(productFamilyId))
            {
                throw new ProjectDomainException("Cannot remove product family. See inner exception for details.",
                    new ArgumentNullException(nameof(productFamilyId)));
            }

            var assignment = GetProductFamilyAssignment(productFamilyId);

            if (assignment == null)
            {
                return true;
            }

            return _productFamilyAssignments.Remove(assignment);
        }

        /// <summary>
        /// Update the list of assigned quotas. Any entry that is not the quotas list will be removed.
        /// </summary>
        /// <param name="quotas"></param>
        public void UpdateQuotas(Dictionary<string, decimal> quotas)
        {
            var existingQuotas = _projectResourceQuotas.Where(e => quotas.Keys.Any(q => q == e.ResourceId)).ToList();

            var missingQuotas = quotas.Keys.Where(q => !_projectResourceQuotas.Any(p => p.ResourceId == q)).ToList();

            var quotasToRemove = _projectResourceQuotas.Where(e => !quotas.Keys.Any(q => q == e.ResourceId)).ToList();

            foreach (var q in existingQuotas)
            {
                q.Value = quotas[q.ResourceId];
            }

            foreach (var q in missingQuotas)
            {
                _projectResourceQuotas.Add(new ProjectResourceQuota(q, quotas[q]));
            }

            foreach (var q in quotasToRemove)
            {
                _projectResourceQuotas.Remove(q);
            }
        }

        public void InitializeProjectSettings()
        {
            if (ProjectSettings == null)
            {
                ProjectSettings = new ProjectSettings();
            }
        }

        /// <summary>
        /// Changes the default language of the project
        /// </summary>
        /// <param name="language"></param>
        public void ChangeProjectLanguage(string language)
        {
            if (ProjectSettings == null)
            {
                InitializeProjectSettings();
            }

            ProjectSettings.Values.DefaultLanguage = language;
        }

        public void ReplaceProjectSetupSteps(IEnumerable<ProjectSetupStep> setupSteps)
        {
            if (ProjectSettings == null)
            {
                InitializeProjectSettings();
            }

            ProjectSettings.Values.SetupSteps = setupSteps.ToList();
        }

        public void UpdateSetupStepState(string name, ProjectSetupStep.StateEnum state)
        {
            if (ProjectSettings == null)
            {
                InitializeProjectSettings();
            }

            var step = ProjectSettings.Values.SetupSteps.FirstOrDefault(x => x.Name == name);
            if(step != default)
            {
                step.State = state;
            }
        }

        private bool ExistsParticipant(long userId, long roleId)
        {
            return _participants.Any(e => e.UserId == userId && e.RoleId == roleId);
        }

        private ProjectUser GetParticipant(long userId, long roleId)
        {
            var participant = _participants.SingleOrDefault(e => e.UserId == userId && e.RoleId == roleId);
            return participant;
        }

        private bool ExistsSLA(string slaId)
        {
            return _sLAs.Any(e => e.SLAId == slaId);
        }

        private ProjectSLA GetSLA(string slaId)
        {
            return _sLAs.SingleOrDefault(e => e.SLAId == slaId);
        }

        private bool HasProductFamily(string productFamilyId)
        {
            return _productFamilyAssignments.Any(e => e.ProductFamilyId == productFamilyId);
        }

        private ProjectProductFamily GetProductFamilyAssignment(string productFamilyId)
        {
            return _productFamilyAssignments.SingleOrDefault(e => e.ProductFamilyId == productFamilyId);
        }


        private void AddProjectSLAAssignedDomainEvent(string slaId)
        {
            var projectSLAAssignedDomainEvent = new ProjectSLAAssignedDomainEvent(this, slaId);
            this.AddDomainEvent(projectSLAAssignedDomainEvent);
        }

        private void AddProjectSLARemovedDomainEvent(string slaId)
        {
            var projectSLARemovedDomainEvent = new ProjectSLARemovedDomainEvent(this, slaId);
            this.AddDomainEvent(projectSLARemovedDomainEvent);
        }

        private void AddProductFamilyAddedDomainEvent(string productFamilyId)
        {
            var domainEvent = new ProjectProductFamilyAddedDomainEvent(this, productFamilyId);
            this.AddDomainEvent(domainEvent);
        }
    }
}