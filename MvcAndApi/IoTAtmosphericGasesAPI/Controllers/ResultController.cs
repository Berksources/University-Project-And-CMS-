using DataAccessLayer;
using EntityLayer.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace IoTAtmosphericGasesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResultController : ControllerBase
    {
        #region /*IoC and Ctor*/
        private readonly IUnitOfWork<Result> _unitOfWorkResult;
        public ResultController(IUnitOfWork<Result> unitOfWorkResult)
        {
            _unitOfWorkResult = unitOfWorkResult;
        }
        #endregion

        #region /*Tempature*/
        [HttpPost]
        [Route("TempatureResult")]
        public void TempatureResult([FromBody] object newDatas)
        {
            Result result = new Result();
            result.PredictedDataValue = newDatas.ToString().Trim().Substring(12, 10);
            result.SensorName = "Sıcaklık";
            result.PublishDateTime = System.DateTime.Now;
            _unitOfWorkResult.RepositoryResult.Create(result);
            _unitOfWorkResult.Complete();
        }

        [HttpGet]
        [Route("Tempature")]
        public List<Result> Tempature()
        {
            return _unitOfWorkResult.RepositoryResult.GetTempature();
        }
        #endregion

        #region /*Humidity*/
        [HttpPost]
        [Route("HumidityResult")]
        public void HumidityResult([FromBody] object newDatas)
        {
            Result result = new Result();
            result.PredictedDataValue = newDatas.ToString().Trim().Substring(12, 10);
            result.SensorName = "Nem";
            result.PublishDateTime = System.DateTime.Now;
            _unitOfWorkResult.RepositoryResult.Create(result);
            _unitOfWorkResult.Complete();
        }

        [HttpGet]
        [Route("Humidity")]
        public List<Result> Humidity()
        {
            return _unitOfWorkResult.RepositoryResult.GetHumidity();
        }
        #endregion

        #region /*CO2*/
        [HttpPost]
        [Route("CO2Result")]
        public void CO2Result([FromBody] object newDatas)
        {
            Result result = new Result();
            result.PredictedDataValue = newDatas.ToString().Trim().Substring(12, 10);
            result.SensorName = "KarbonDioksit";
            result.PublishDateTime = System.DateTime.Now;
            _unitOfWorkResult.RepositoryResult.Create(result);
            _unitOfWorkResult.Complete();
        }

        [HttpGet]
        [Route("CO2")]
        public List<Result> CO2()
        {
            return _unitOfWorkResult.RepositoryResult.GetCO2();
        }
        #endregion

        #region /*BurningGas*/
        [HttpPost]
        [Route("BurningGasResult")]
        public void BurningGasResult([FromBody] object newDatas)
        {
            Result result = new Result();
            result.PredictedDataValue = newDatas.ToString().Trim().Substring(12, 10);
            result.SensorName = "YanıcıGaz";
            result.PublishDateTime = System.DateTime.Now;
            _unitOfWorkResult.RepositoryResult.Create(result);
            _unitOfWorkResult.Complete();
        }

        [HttpGet]
        [Route("BurningGas")]
        public List<Result> BurningGas()
        {
            return _unitOfWorkResult.RepositoryResult.GetBurningGas();
        }
        #endregion

        #region /*AirQuality*/
        [HttpPost]
        [Route("AirQualityResult")]
        public void AirQualityResult([FromBody] object newDatas)
        {
            Result result = new Result();
            result.PredictedDataValue = newDatas.ToString().Trim().Substring(12, 10);
            result.SensorName = "HavaKalitesi";
            result.PublishDateTime = System.DateTime.Now;
            _unitOfWorkResult.RepositoryResult.Create(result);
            _unitOfWorkResult.Complete();
        }

        [HttpGet]
        [Route("AirQuality")]
        public List<Result> AirQuality()
        {
            return _unitOfWorkResult.RepositoryResult.GetAirQuality();
        }
        #endregion
    }
}
