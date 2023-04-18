using MyCommune.Custom;
using MyCommune.Repository.Account;
using MyCommune.Repository.Users;

namespace MyCommune.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IAccountRepository AccountRepository { get; }
        IUserRepository UserRepository { get; }
        int Complete();
    }

    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            AccountRepository = new AccountRepository(_context);
            UserRepository = new UserRepository(_context);
        }
        public IAccountRepository AccountRepository { get; private set; }
        public IUserRepository UserRepository { get; private set; }
        public int Complete()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
