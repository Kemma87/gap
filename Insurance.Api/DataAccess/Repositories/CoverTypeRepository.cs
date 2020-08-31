using DataAccess.Contracts;
using DataAccess.Models;

namespace DataAccess.Repositories
{
    public class CoverTypeRepository: Repository<CoverType>, ICoverTypeRepository
    {
        public CoverTypeRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
