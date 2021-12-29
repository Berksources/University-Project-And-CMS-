using EntityLayer;
using EntityLayer.Model;
using static DataAccessLayer.IRepository;

namespace DataAccessLayer
{
    public interface IRepositoryResult<T>:IRepository<Result>
    {
    }
    public class RepositoryResult<T> : Repository<Result>,IRepositoryResult<T>
    {
        public RepositoryResult(AtmosphericGasesDBContext context) : base(context) { }
    }
}
