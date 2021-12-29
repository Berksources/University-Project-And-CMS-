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
        List<MDataPublish> GetTempature();
        List<MDataPublish> GetTempature10();
        List<MDataPublish> GetHumidity();
        List<MDataPublish> GetHumidity10();
        List<MDataPublish> GetC02();
        List<MDataPublish> GetC0210();
        List<MDataPublish> GetBurningGas();
        List<MDataPublish> GetBurningGas10();
        List<MDataPublish> GetAirQuality();
        List<MDataPublish> GetAirQuality10();
        int GetAllDataCount();
    }
    public class RepositoryMDataPublish<T> : Repository<MDataPublish>, IRepositoryMDataPublish<T>
    {
        public RepositoryMDataPublish(AtmosphericGasesDBContext context) : base(context) { }

        public List<MDataPublish> GetAirQuality()
        {
            return AtmosphericGasesDBContext.MDataPublishes.Where(x => x.SensorName == "HavaKalitesi")
                .OrderByDescending(x => x.DataPublishID).AsNoTracking().Take(1000).ToList();
        }

        public List<MDataPublish> GetAirQuality10()
        {
            return AtmosphericGasesDBContext.MDataPublishes.Where(x => x.SensorName == "HavaKalitesi")
                .OrderByDescending(x => x.DataPublishID).AsNoTracking().Take(10).ToList();
        }

        public int GetAllDataCount()
        {
            return AtmosphericGasesDBContext.MDataPublishes.Count();
        }

        public List<MDataPublish> GetBurningGas()
        {
            return AtmosphericGasesDBContext.MDataPublishes.Where(x => x.SensorName == "YanıcıGaz")
                .OrderByDescending(x => x.DataPublishID).AsNoTracking().Take(1000).ToList();
        }

        public List<MDataPublish> GetBurningGas10()
        {
            return AtmosphericGasesDBContext.MDataPublishes.Where(x => x.SensorName == "YanıcıGaz")
               .OrderByDescending(x => x.DataPublishID)
               .AsNoTracking().Take(10).ToList();
        }

        public List<MDataPublish> GetC02()
        {
            return AtmosphericGasesDBContext.MDataPublishes.Where(x => x.SensorName == "KarbonDioksit")
                .OrderByDescending(x => x.DataPublishID).AsNoTracking().Take(1000).ToList();
        }

        public List<MDataPublish> GetC0210()
        {
            return AtmosphericGasesDBContext.MDataPublishes.Where(x => x.SensorName == "KarbonDioksit")
               .OrderByDescending(x => x.DataPublishID)
               .AsNoTracking().Take(10).ToList();
        }

        public List<MDataPublish> GetHumidity()
        {
            return AtmosphericGasesDBContext.MDataPublishes.Where(x => x.SensorName == "Nem")
                .OrderByDescending(x => x.DataPublishID).AsNoTracking().Take(1000).ToList();
        }

        public List<MDataPublish> GetHumidity10()
        {
            return AtmosphericGasesDBContext.MDataPublishes.Where(x => x.SensorName == "Nem")
               .OrderByDescending(x => x.DataPublishID)
               .AsNoTracking().Take(10).ToList();
        }

        public List<MDataPublish> GetTempature()
        {
            return AtmosphericGasesDBContext.MDataPublishes.Where(x => x.SensorName == "Sıcaklık")
                .OrderByDescending(x => x.DataPublishID).AsNoTracking().Take(1000).ToList();
        }

        public List<MDataPublish> GetTempature10()
        {
            return AtmosphericGasesDBContext.MDataPublishes.Where(x => x.SensorName == "Sıcaklık")
                .OrderByDescending(x => x.DataPublishID)
                .AsNoTracking().Take(10).ToList();
        }
    }
}
