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

        public async Task AddPersonInsuranceAsync(int personId, int insuranceId)
        {
            var personInsurance = new PersonInsurance
            {
                PersonId = personId,
                InsuranceId = insuranceId
            };

            await _dataContext.PersonInsurances.AddAsync(personInsurance);
        }

        public async Task DeletePersonInsuranceAsync(int personId, int insuranceId)
        {
            var personInsurance = await (from pi in _dataContext.PersonInsurances
                                         where pi.PersonId == personId && pi.InsuranceId == insuranceId
                                         select pi).FirstOrDefaultAsync();

            _dataContext.PersonInsurances.Remove(personInsurance);
        }

        public async Task<ICollection<InsurancePolicy>> GetInsurnacesByPersonIdAsync(int personId)
        {
            return await (from pi in _dataContext.PersonInsurances
                          join i in _dataContext.InsurancePolicies on pi.InsuranceId equals i.Id
                          where pi.PersonId == personId
                          select i).ToListAsync();
        }

        public async Task<bool> HasPersonInsuranceAsync(int personId, int insuranceId)
        {
            return await (from pi in _dataContext.PersonInsurances
                          where pi.PersonId == personId && pi.InsuranceId == insuranceId
                          select pi).AnyAsync();
        }
    }
}
