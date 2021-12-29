using EntityLayer;
using EntityLayer.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DataAccessLayer.IRepository;

namespace DataAccessLayer
{
    public interface IRepositoryMDataPublish<T> : IRepository<MDataPublish>
    {
        List<MDataPublish> GetAverageOfTempature();
        List<MDataPublish> GetAverageOfHumidity();
        List<MDataPublish> GetAverageOfC02();
        List<MDataPublish> GetAverageOfBurningGas();
        List<MDataPublish> GetAverageOfAirQuality();
    }
    public class RepositoryMDataPublish<T> : Repository<MDataPublish>, IRepositoryMDataPublish<T>
    {
        public RepositoryMDataPublish(AtmosphericGasesDBContext context) : base(context) { }

        public List<MDataPublish> GetAverageOfAirQuality()
        {
            return AtmosphericGasesDBContext.MDataPublishes.Where(x => x.SensorName == "HavaKalitesi")
                .AsNoTracking().ToList();
        }

        public List<MDataPublish> GetAverageOfBurningGas()
        {
            return AtmosphericGasesDBContext.MDataPublishes.Where(x => x.SensorName == "YanıcıGaz")
                .AsNoTracking().ToList();
        }

        public List<MDataPublish> GetAverageOfC02()
        {
            return AtmosphericGasesDBContext.MDataPublishes.Where(x => x.SensorName == "KarbonDioksit")
                .AsNoTracking().ToList();
        }

        public List<MDataPublish> GetAverageOfHumidity()
        {
            return AtmosphericGasesDBContext.MDataPublishes.Where(x => x.SensorName == "Nem")
                .AsNoTracking().ToList();
        }

        public List<MDataPublish> GetAverageOfTempature()
        {
            return AtmosphericGasesDBContext.MDataPublishes.Where(x => x.SensorName == "Sıcaklık")
                .AsNoTracking().Take(1000).ToList();
        }
    }
}
