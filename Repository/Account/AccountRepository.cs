using Microsoft.EntityFrameworkCore;
using MyCommune.Custom;
using MyCommune.DataModels.Users;

namespace MyCommune.Repository.Account
{
    public interface IAccountRepository : IGenericRepository<User>
    {
        void RegisterUser(User registration);
        Task<bool> IsRegistered(string username, string password);
        Task<bool> IsRegistered(string email);
    }
    public class AccountRepository : GenericRepository<User>, IAccountRepository
    {
        public AccountRepository(ApplicationDbContext context) : base(context)
        {

        }

        public Task<bool> IsRegistered(string username, string password)
        {
            Task<bool> exist = _context.Users.AnyAsync(usr => usr.Email.ToLower().Equals(username.ToLower()) && usr.Password.Equals(password));
            return exist;

        }

        public async Task<bool> IsRegistered(string email)
        {
            Task<bool> any = _context.Users.AnyAsync(usr => usr.Email.ToLower() == email.ToLower());
            return await any;
        }

        public void RegisterUser(User registration)
        {
            _context.Add(registration);
            _context.SaveChanges();
        }
    }
}
