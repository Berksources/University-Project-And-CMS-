using EntityLayer;
using EntityLayer.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using static DataAccessLayer.IRepository;

namespace DataAccessLayer
{
    public interface IRepositoryResult<T>:IRepository<Result>
    {
        List<Result> GetTempature();
        List<Result> GetTempatureResultLast10();
        List<Result> GetHumidity();
        List<Result> GetHumidityResultLast10();
        List<Result> GetCO2();
        List<Result> GetCO2ResultLast10();
        List<Result> GetBurningGas();
        List<Result> GetBurningGasResultLast10();
        List<Result> GetAirQuality();
        List<Result> GetAirQualityResultLast10();
    }
    public class RepositoryResult<T> : Repository<Result>,IRepositoryResult<T>
    {
        public RepositoryResult(AtmosphericGasesDBContext context) : base(context) { }
        public List<Result> GetAirQuality()
        {
            return AtmosphericGasesDBContext.Results.Where(x => x.SensorName == "HavaKalitesi")
                .AsNoTracking().ToList();
        }

        public List<Result> GetAirQualityResultLast10()
        {
            return AtmosphericGasesDBContext.Results.Where(x => x.SensorName == "HavaKalitesi")
                .OrderByDescending(x => x.ResultID).Take(10)
                .AsNoTracking().ToList();
        }

        public List<Result> GetBurningGas()
        {
            return AtmosphericGasesDBContext.Results.Where(x => x.SensorName == "YanıcıGaz")
                .AsNoTracking().ToList();
        }

        public List<Result> GetBurningGasResultLast10()
        {
            return AtmosphericGasesDBContext.Results.Where(x => x.SensorName == "YanıcıGaz")
                .OrderByDescending(x => x.ResultID).Take(10)
                .AsNoTracking().ToList();
        }

        public List<Result> GetCO2()
        {
            return AtmosphericGasesDBContext.Results.Where(x => x.SensorName == "KarbonDioksit")
                .AsNoTracking().ToList();
        }

        public List<Result> GetCO2ResultLast10()
        {
            return AtmosphericGasesDBContext.Results.Where(x => x.SensorName == "KarbonDioksit")
                .OrderByDescending(x => x.ResultID).Take(10)
                .AsNoTracking().ToList();
        }

        public List<Result> GetHumidity()
        {
            return AtmosphericGasesDBContext.Results.Where(x => x.SensorName == "Nem")
                .AsNoTracking().ToList();
        }

        public List<Result> GetHumidityResultLast10()
        {
            return AtmosphericGasesDBContext.Results.Where(x => x.SensorName == "Nem")
                .OrderByDescending(x => x.ResultID).Take(10)
                .AsNoTracking().ToList();
        }

        public List<Result> GetTempature()
        {
            return AtmosphericGasesDBContext.Results.Where(x => x.SensorName == "Sıcaklık")
                .AsNoTracking().ToList();
        }

        public List<Result> GetTempatureResultLast10()
        {
            return AtmosphericGasesDBContext.Results.Where(x => x.SensorName == "Sıcaklık")
                .OrderByDescending(x=>x.ResultID).Take(10)
                .AsNoTracking().ToList();
        }
    }
}
