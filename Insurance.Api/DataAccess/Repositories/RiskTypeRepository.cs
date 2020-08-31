using DataAccess.Contracts;
using DataAccess.Models;

namespace DataAccess.Repositories
{
    public class RiskTypeRepository: Repository<RiskType>, IRiskTypeRepository
    {
        public RiskTypeRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
