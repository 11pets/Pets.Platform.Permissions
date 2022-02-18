using Pets.Platform.Permissions.Core.Domain.ProjectAggregate;

namespace Pets.Platform.Permissions.Core.Domain.UserAggregate
{
    public class User : Entity<long>, IAggregateRoot
    {

        public Guid IdentityGuid { get; private set; }

        private List<Project> _ownedProjects;
        private List<ProjectUser> _participatingProjects;

        public IEnumerable<Project> OwnedProjects => _ownedProjects.AsReadOnly();
        public IEnumerable<ProjectUser> ParticipatingProjects => _participatingProjects.AsReadOnly();

        public UserSettings UserSettings { get; private set; }


        protected User()
        {
            _ownedProjects = new List<Project>();
            _participatingProjects = new List<ProjectUser>();
        }

        public User(long id, string identity)
            : this()
        {
            Id = id > 0 ? id : throw new ArgumentOutOfRangeException(nameof(id), "Expected an id > 0");
            IdentityGuid = !string.IsNullOrWhiteSpace(identity) ? Guid.Parse(identity) : throw new ArgumentNullException(nameof(identity));
            UserSettings = new UserSettings(new UserSettingValues());
        }

        public User(long id, string identity, long defaultProjectId)
            : this()
        {
            Id = id > 0 ? id : throw new ArgumentOutOfRangeException(nameof(id), "Expected an id > 0");
            IdentityGuid = !string.IsNullOrWhiteSpace(identity) ? Guid.Parse(identity) : throw new ArgumentNullException(nameof(identity));
            UserSettings = new UserSettings(new UserSettingValues()
            {
                DefaultProject = defaultProjectId
            });
        }


        void InitializeSettings()
        {
            var defaultProjectId = OwnedProjects?.FirstOrDefault()?.Id;
            UserSettings = new UserSettings(new UserSettingValues()
            {
                DefaultLanguage = "en",
                DefaultProject = defaultProjectId
            });
        }

        public void ChangeSettings(UserSettingValues values)
        {
            if (UserSettings == null)
            {
                InitializeSettings();
            }
            UserSettings.Values = values;
        }

        public void ChangeDashboardLanguage(string language)
        {
            if (UserSettings == null)
            {
                InitializeSettings();
            }
            UserSettings.Values.DefaultLanguage = language;
        }

        public void SetDefaultProject(long projectId)
        {
            if (UserSettings == null)
            {
                InitializeSettings();
            }
            if (ParticipatingProjects.Any(x => x.ProjectId == projectId))
            {
                UserSettings.Values.DefaultProject = projectId;
            }
        }
    }
}
