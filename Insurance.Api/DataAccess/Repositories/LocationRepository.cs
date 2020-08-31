using DataAccess.Contracts;
using DataAccess.Models;

namespace DataAccess.Repositories
{
    public class LocationRepository: Repository<Location>, ILocationRepository
    {
        public LocationRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
