namespace Pets.Platform.Permissions.Core.Domain.UserAggregate
{
    public interface IUserRepository : IRepository<User>
    {
        User Add(User user);
        void Update(User user);

        Task<User> FindAsync(long id);
    }
}
