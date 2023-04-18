using Microsoft.EntityFrameworkCore;
using MyCommune.Custom;
using MyCommune.DataModels.Users;
using System.Linq;
using System.Linq.Expressions;

namespace MyCommune.Repository.Users
{

    public interface IUserRepository : IGenericRepository<User>
    {
        IEnumerable<User> GetAllUsers();

    }
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users.AsNoTracking().Include(a => a.UserDetails).ToList();
        }

        public new IEnumerable<User> Find(Expression<Func<User, bool>> expression)
        {
            return _context.Users.AsNoTracking().Include(a => a.UserDetails).Where(expression);
        }
    }
}
