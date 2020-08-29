using DataAccess.Contracts;
using DataAccess.Models;
using System;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private bool disposed = false;
        private readonly DataContext _context;
        private Repository<InsurancePolicy> _insurancePolicies;
        private Repository<User> _users;
        private Repository<Role> _roles;

        public UnitOfWork(DataContext context)
        {
            _context = context;
        }

        public IRepository<InsurancePolicy> InsurancePolicies
        {
            get
            {
                return _insurancePolicies ?? (_insurancePolicies = new Repository<InsurancePolicy>(_context));
            }
        }

        public IRepository<User> Users
        {
            get
            {
                return _users ?? (_users = new Repository<User>(_context));
            }
        }

        public IRepository<Role> Roles
        {
            get
            {
                return _roles ?? (_roles = new Repository<Role>(_context));
            }
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

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
    }
}
