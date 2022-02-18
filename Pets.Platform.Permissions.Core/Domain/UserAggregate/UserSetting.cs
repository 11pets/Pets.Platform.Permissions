namespace Pets.Platform.Permissions.Core.Domain.UserAggregate
{
    public class UserSettings
    {
        public UserSettingValues Values { get; set; }

        public UserSettings() { }
        public UserSettings(UserSettingValues values)
        {
            Values = values ?? new UserSettingValues();
        }
    }

    public class UserSettingValues : ValueObject
    {
        public UserSettingValues()
        {
            DefaultLanguage = "en";
        }

        public string DefaultLanguage { get; set; }
        public long? DefaultProject { get; set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return DefaultLanguage;
            yield return DefaultProject;
        }
    }
}
