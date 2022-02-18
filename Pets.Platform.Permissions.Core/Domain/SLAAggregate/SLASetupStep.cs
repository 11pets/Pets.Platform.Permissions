namespace Pets.Platform.Permissions.Core.Domain.SLAAggregate
{
    public class SLASetupStep
    {
        public long Id { get; set; }
        public string SetupStepName { get; set; }

        protected SLASetupStep()
        {

        }

        public SLASetupStep(string setupStepName)
        {
            SetupStepName = setupStepName;
        }
    }
}
