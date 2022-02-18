namespace Pets.Platform.Permissions.Core.Domain.ProjectAggregate
{
    public class ProjectUser : Entity<long>
    {
        public long UserId { get; private set; }

        public long RoleId { get; private set; }

        /// <summary>
        /// Can only be added through Project Aggregate
        /// </summary>
        public long ProjectId { get; private set; }

        protected ProjectUser() { }

        public ProjectUser(long userId, long roleId)
        {
            UserId = userId;
            RoleId = roleId;
        }
    }
}