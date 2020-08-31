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
        private RolesRepository _rolesRepository;
        private PersonRepository _personRepository;
        private UserRoleRepository _userRoleRepository;
        private LocationRepository _locationRepository;
        private CoverTypeRepository _coverTypeRepository;
        private RiskTypeRepository _riskTypeRepository;

        public UnitOfWork(DataContext context)
        {
            _context = context;
        }

        public IInsuranceRepository InsuranceRepository
        {
            get
            {
                return _insuranceRepository ??= new InsuranceRepository(_context);
            }
        }

        public IUserRepository UserRepository
        {
            get
            {
                return _userRepository ??= new UserRepository(_context);
            }
        }

        public IRolesRepository RolesRepository
        {
            get
            {
                return _rolesRepository ??= new RolesRepository(_context);
            }
        }

        public IPersonRepository PersonRepository
        {
            get
            {
                return _personRepository ??= new PersonRepository(_context);
            }
        }

        public IUserRoleRepository UserRoleRepository
        {
            get
            {
                return _userRoleRepository ??= new UserRoleRepository(_context);
            }
        }

        public ILocationRepository LocationRepository
        {
            get
            {
                return _locationRepository ??= new LocationRepository(_context);
            }
        }

        public ICoverTypeRepository CoverTypeRepository
        {
            get
            {
                return _coverTypeRepository ??= new CoverTypeRepository(_context);
            }
        }

        public IRiskTypeRepository RiskTypeRepository
        {
            get
            {
                return _riskTypeRepository ??= new RiskTypeRepository(_context);
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
