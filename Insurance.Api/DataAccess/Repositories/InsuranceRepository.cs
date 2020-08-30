using DataAccess.Contracts;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class InsuranceRepository : Repository<InsurancePolicy>, IInsuranceRepository
    {
        private readonly DataContext _dataContext;

        public InsuranceRepository(DataContext dataContext): base (dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IEnumerable<InsurancePolicy>> GetAllInsurancesAsync()
        {
            return await _dataContext.InsurancePolicies
                   .Include(x => x.RiskType)
                   .Include(x => x.Location).ThenInclude(x => x.Country)
                   .Include(x => x.CoverType)
                   .ToListAsync();
        }

        public async Task<InsurancePolicy> GetAllInsurancesByIdAsync(int id)
        {
            return await _dataContext.InsurancePolicies
                   .Include(x => x.RiskType)
                   .Include(x => x.Location).ThenInclude(x => x.Country)
                   .Include(x => x.CoverType)
                   .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
