namespace Pets.Platform.Permissions.Core.Domain.SLAAggregate
{
    public class SLA : Entity<string>, IAggregateRoot
    {
        public string Description { get; set; }


        private readonly List<SLAToActionCategory> _actionCategories;
        public IReadOnlyCollection<SLAToActionCategory> ActionCategories => _actionCategories;


        private readonly List<SLAResourceQuota> _resourceQuotas;
        public IReadOnlyCollection<SLAResourceQuota> ResourceQuotas => _resourceQuotas;

        private readonly List<SLASetupStep> _setupSteps;
        public IReadOnlyCollection<SLASetupStep> SetupSteps => _setupSteps;

        protected SLA()
        {
            _actionCategories = new List<SLAToActionCategory>();
            _resourceQuotas = new List<SLAResourceQuota>();
            _setupSteps = new List<SLASetupStep>();
        }

        public SLA(string id) : this()
        {
            Id = id;
        }

        public void AddActionCategory(long actionCategoryId)
        {
            var existing = GetActionCategory(actionCategoryId);

            if(existing == null)
            {
                _actionCategories.Add(new SLAToActionCategory(actionCategoryId));
            }
        }

        public void RemoveActionCategory(long actionCategoryId)
        {
            var existing = GetActionCategory(actionCategoryId);

            if(existing == null)
            {
                return;
            }

            _actionCategories.Remove(existing);
        }

        public void UpdateResourceQuota(string resourceId, decimal value)
        {
            var existing = GetResourceQuota(resourceId);

            if(existing == null)
            {
                _resourceQuotas.Add(new SLAResourceQuota(resourceId, value));
            }
            else
            {
                existing.Value = value;
            }
        }

        public void RemoveResourceQuota(string resourceId, decimal value)
        {
            var existing = GetResourceQuota(resourceId);

            if(existing == null)
            {
                return;
            }

            _resourceQuotas.Remove(existing);
        }

        public void AddSetupStep(string stepName)
        {
            var existing = GetSLASetupStep(stepName);
            if(existing == null)
            {
                _setupSteps.Add(new SLASetupStep(stepName));
            }
        }

        public void RemoveSetupStep(string stepName)
        {
            var existing = GetSLASetupStep(stepName);
            if (existing == null)
            {
                return;
            }

            _setupSteps.Remove(existing);
        }

        private SLAToActionCategory GetActionCategory(long id)
        {
            return _actionCategories.SingleOrDefault(x => x.ActionCategoryId == id);
        }

        private SLAResourceQuota GetResourceQuota(string resourceId)
        {
            return _resourceQuotas.SingleOrDefault(x => x.ResourceId == resourceId);
        }

        private SLASetupStep GetSLASetupStep(string name)
        {
            return _setupSteps.SingleOrDefault(x => x.SetupStepName == name);
        }
    }
}
