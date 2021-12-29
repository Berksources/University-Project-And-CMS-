using System;
using System.Threading.Tasks;
using static DataAccessLayer.IRepository;

namespace DataAccessLayer
{
    public interface IUnitOfWork<T> : IDisposable where T : class
    {
        IRepository<T> Repository { get; }
        public IRepositoryMDataPublish<T> RepositoryMDataPublish { get; }
        public IRepositoryResult<T> RepositoryResult { get; }
        int Complete();
        Task<int> CompleteAsync();
    }
}
