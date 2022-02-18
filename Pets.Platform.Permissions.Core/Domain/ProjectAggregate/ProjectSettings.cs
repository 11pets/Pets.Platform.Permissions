namespace Pets.Platform.Permissions.Core.Domain.ProjectAggregate
{
    public class ProjectSettings : ValueObject
    {
        public ProjectSettingValues Values { get; set; }

        protected ProjectSettings()
        {
            
        }

        public ProjectSettings(ProjectSettingValues values = null)
        {
            Values = values ?? new ProjectSettingValues();
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Values;
        }
    }

    public class ProjectSettingValues : ValueObject
    {
        public string DefaultLanguage { get; set; }
        public List<ProjectSetupStep> SetupSteps { get; set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return DefaultLanguage;
            yield return SetupSteps;
        }
    }

    public class ProjectSetupStep : ValueObject
    {
        protected ProjectSetupStep()
        {

        }

        public ProjectSetupStep(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            State = StateEnum.None;
        }

        public ProjectSetupStep(string name, StateEnum state) : this(name)
        {
            State = state;
        }

        public string Name { get; set; }
        public StateEnum State { get; set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Name;
        }

        public enum StateEnum
        {
            None,
            Done,
            Skipped
        }
    }
}
