using EntityLayer;
using EntityLayer.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface IRepository
    {
        public interface IRepository<T> where T : class
        {
            IEnumerable<T> GetAll();
            IEnumerable<T> GetAllAsNoTracing();
            T GetByID(int ID);
            T GetByEmail(string email);
            void Update(T model);
            void Create(T model);
            void DeleteID(int ID);
            List<T> GetAllAsList();
            Task<T> GetByIDAsync(int ID);
            Task CreateAsync(T model);
            Task UpdateAsync(T entity);
            List<MDataPublish> GetPublishedData();
        }
        public class Repository<T> : IRepository<T> where T : class
        {
            protected AtmosphericGasesDBContext _context;
            private readonly DbSet<T> _dbSet;
            public Repository(AtmosphericGasesDBContext context)
            {
                this._context = context ?? throw new ArgumentNullException("dbContext can not be null.");
                _dbSet = _context.Set<T>();
            }
            public IEnumerable<T> GetAll()
            {
                var allData = _dbSet.ToList();
                if (allData == null)
                {
                    throw new ArgumentNullException("Veritabanındaki ilgili tabloda veri bulunmamaktadır.");
                }
                else
                {
                    return allData;
                }
            }
            public void Create(T model)
            {
                _dbSet.Add(model);
            }
            public void Update(T model)
            {
                if (model == null)
                {
                    throw new ArgumentNullException("veride boşluk var");
                }
                else
                {
                    _dbSet.Update(model);
                }
            }
            public T GetByID(int ID)
            {
                return _dbSet.Find(ID);
            }
            public T GetByEmail(string email)
            {
                return _dbSet.Find(email);
            }
            public void DeleteID(int ID)
            {
                _dbSet.Remove(GetByID(ID));
            }
            public List<T> GetAllAsList()
            {
                return _dbSet.ToList();
            }
            public IEnumerable<T> GetAllAsNoTracing()
            {
                return _dbSet.AsNoTracking().ToList();
            }
            public async Task CreateAsync(T model)
            {
                await _dbSet.AddAsync(model);
            }
            public async Task<T> GetByIDAsync(int ID)
            {
                return await _dbSet.FindAsync(ID);
            }

            public Task UpdateAsync(T entity)
            {
                _dbSet.Update(entity).State = EntityState.Modified;
                return Task.CompletedTask;
            }

            public List<MDataPublish> GetPublishedData()
            {
                return _context.MDataPublishes.ToList();
            }


            public AtmosphericGasesDBContext AtmosphericGasesDBContext { get { return _context as AtmosphericGasesDBContext; } }
        }
    }
}
