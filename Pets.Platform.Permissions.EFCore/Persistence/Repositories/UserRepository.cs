using Microsoft.EntityFrameworkCore;
using Pets.Platform.Permissions.Core;
using Pets.Platform.Permissions.Core.Domain.UserAggregate;

namespace Pets.Platform.Permissions.EFCore.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly PermissionsDbContext _context;

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _context;
            }
        }

        public UserRepository(PermissionsDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public User Add(User user)
        {
            return _context.Users.Add(user).Entity;
        }

        public void Update(User user)
        {
            _context.Users.Update(user);
            _context.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public async Task<User> FindAsync(long id)
        {
            var user = await _context.Users.Include(x => x.ParticipatingProjects)
                        .Where(e => e.Id == id)
                        .SingleOrDefaultAsync();

            if(user == null)
            {
                user = _context.Users.Local.FirstOrDefault(p => p.Id == id);
            }

            if(user != null)
            {
                await _context.Entry(user).Reference(x => x.UserSettings).LoadAsync();
            }

            return user;
        }

    }
}
