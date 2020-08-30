using DataAccess.Contracts;
using System;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly DataContext _context;

        private InsuranceRepository _insuranceRepository;
        private UserRepository _userRepository;

        public UnitOfWork(DataContext context)
        {
            _context = context;
        }

        public IInsuranceRepository InsuranceRepository
        {
            get
            {
                return _insuranceRepository ?? (_insuranceRepository = new InsuranceRepository(_context));
            }
        }

        public IUserRepository UserRepository
        {
            get
            {
                return _userRepository ?? (_userRepository = new UserRepository(_context));
            }
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        #region Dispose
        private bool disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }

            disposed = true;
        }
        #endregion
    }
}
