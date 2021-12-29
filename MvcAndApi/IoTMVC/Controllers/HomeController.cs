using DataAccessLayer;
using EntityLayer.Model;
using IoTMVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace IoTMVC.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IUnitOfWork<MDataPublish> _unitOfWorkMDataPublish;
        private readonly IUnitOfWork<Result> _unitOfWorkResult;
        public HomeController(
            IUnitOfWork<MDataPublish> unitOfWorkMDataPublish,
            IUnitOfWork<Result> unitOfWorkResult):base(unitOfWorkMDataPublish, unitOfWorkResult)
        {
            _unitOfWorkMDataPublish = unitOfWorkMDataPublish;
            _unitOfWorkResult = unitOfWorkResult;
        }

        public async Task<IActionResult> Index()
        {
            var getTempatureLast10 = _unitOfWorkMDataPublish.RepositoryMDataPublish.GetTempature10();
            var predictedTempatureDataLast10 = _unitOfWorkResult.RepositoryResult.GetTempatureResultLast10();

            var getAirQualityLast10 = _unitOfWorkMDataPublish.RepositoryMDataPublish.GetAirQuality10();
            var predictedAirQualityDataLast10 = _unitOfWorkResult.RepositoryResult.GetAirQualityResultLast10();

            var getCO2Last10 = _unitOfWorkMDataPublish.RepositoryMDataPublish.GetC0210();
            var predictedCO2DataLast10 = _unitOfWorkResult.RepositoryResult.GetCO2ResultLast10();

            var getHumidtyLast10 = _unitOfWorkMDataPublish.RepositoryMDataPublish.GetHumidity10();
            var predictedHumidtyDataLast10 = _unitOfWorkResult.RepositoryResult.GetHumidityResultLast10();

            var getBurningGasLast10 = _unitOfWorkMDataPublish.RepositoryMDataPublish.GetBurningGas10();
            var predictedBurningGasDataLast10 = _unitOfWorkResult.RepositoryResult.GetBurningGasResultLast10();

            int dataCount = _unitOfWorkMDataPublish.RepositoryMDataPublish.GetAllDataCount();
            var homeViewModel = new HomeViewModel
            {
                Tempature = getTempatureLast10,
                LastTempatureResults = predictedTempatureDataLast10,
                AirQuality=getAirQualityLast10,
                LastAirQualityResults=predictedAirQualityDataLast10,
                CO2=getCO2Last10,
                LastCO2Results=predictedCO2DataLast10,
                Humidity=getHumidtyLast10,
                LastHumidityResults=predictedHumidtyDataLast10,
                BurningGas=getBurningGasLast10,
                LastBurningGasResults=predictedBurningGasDataLast10,
                MDataPublishedCount= dataCount
            };
            return View(homeViewModel);
        }
    }
}
