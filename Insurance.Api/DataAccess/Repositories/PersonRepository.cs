using DataAccess.Contracts;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace DataAccess.Repositories
{
    public class PersonRepository : Repository<Person>, IPersonRepository
    {
        private readonly DataContext _dataContext;

        public PersonRepository(DataContext dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<ICollection<InsurancePolicy>> GetInsurnacesByPersonIdAsync(int personId)
        {
            return await (from pi in _dataContext.PersonInsurances
                          join i in _dataContext.InsurancePolicies on pi.InsuranceId equals i.Id
                          where pi.PersonId == personId
                          select i).ToListAsync();
        }
    }
}
