using DataAccessLayer;
using EntityLayer.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace IoTAtmosphericGasesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        #region /*IoC and Ctor*/
        private readonly IUnitOfWork<MDataPublish> _unitOfWorkMDataPublish;
        public DataController(IUnitOfWork<MDataPublish> unitOfWorkMDataPublish)
        {
            _unitOfWorkMDataPublish = unitOfWorkMDataPublish;
        }
        #endregion

        #region /*Tempature*/
        [HttpGet]
        [Route("TempatureData")]
        public List<MDataPublish> TempatureData()
        {
            return _unitOfWorkMDataPublish.RepositoryMDataPublish.GetTempature();
        }
        #endregion

        #region /*Humidity*/
        [HttpGet]
        [Route("HumidityData")]
        public List<MDataPublish> HumidityData()
        {
            return _unitOfWorkMDataPublish.RepositoryMDataPublish.GetHumidity();
        }
        #endregion

        #region /*CO2*/
        [HttpGet]
        [Route("CO2Data")]
        public List<MDataPublish> CO2Data()
        {
            return _unitOfWorkMDataPublish.RepositoryMDataPublish.GetC02();
        }
        #endregion

        #region /*AirQuality*/
        [HttpGet]
        [Route("AirQualityData")]
        public List<MDataPublish> AirQualityData()
        {
            return _unitOfWorkMDataPublish.RepositoryMDataPublish.GetAirQuality();
        }
        #endregion

        #region /*BurningGas*/
        [HttpGet]
        [Route("BurningGasData")]
        public List<MDataPublish> BurningGasData()
        {
            return _unitOfWorkMDataPublish.RepositoryMDataPublish.GetBurningGas();
        }
        #endregion
    }
}
