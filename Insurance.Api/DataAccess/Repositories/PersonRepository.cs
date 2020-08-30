using DataAccess.Contracts;
using DataAccess.Models;

namespace DataAccess.Repositories
{
    public class PersonRepository : Repository<Person>, IPersonRepository
    {
        public PersonRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
