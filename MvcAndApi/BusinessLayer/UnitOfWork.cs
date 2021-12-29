using DataAccessLayer;
using EntityLayer;
using System;
using System.Threading.Tasks;
using static DataAccessLayer.IRepository;

namespace BusinessLayer
{
    public class UnitOfWork<T> : IUnitOfWork<T> where T : class
    {
        private readonly AtmosphericGasesDBContext _context;
        public UnitOfWork(AtmosphericGasesDBContext context)
        {
            _context = context;
            Repository = new Repository<T>(_context);
            RepositoryMDataPublish = new RepositoryMDataPublish<T>(_context);
            RepositoryResult = new RepositoryResult<T>(_context);
        }
        public IRepository<T> Repository { get; }
        public IRepositoryMDataPublish<T> RepositoryMDataPublish { get; private set; }
        public IRepositoryResult<T> RepositoryResult { get; private set; }
        public int Complete()
        {
            try
            {
                return _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
        public async Task<int> CompleteAsync()
        {
            try
            {
                return await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
