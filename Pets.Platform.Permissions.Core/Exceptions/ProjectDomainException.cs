namespace Pets.Platform.Permissions.Core.Exceptions
{
    /// <summary>
    /// Exception type from domain exceptions
    /// </summary>
    public class ProjectDomainException : Exception
    {
        public ProjectDomainException() 
        { }

        public ProjectDomainException(string message) 
            : base(message)
        { }

        public ProjectDomainException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
