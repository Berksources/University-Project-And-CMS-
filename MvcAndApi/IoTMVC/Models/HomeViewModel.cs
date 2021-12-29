using EntityLayer.Model;
using System.Collections.Generic;

namespace IoTMVC.Models
{
    public class HomeViewModel
    {
        public IEnumerable<MDataPublish> MDataPublishes { get; set; }
        public List<MDataPublish> AirQuality { get; set; }
        public List<MDataPublish> Tempature { get; set; }
        public List<MDataPublish> Humidity { get; set; }
        public List<MDataPublish> CO2 { get; set; }
        public List<MDataPublish> BurningGas { get; set; }
        public List<Result> LastTempatureResults { get; set; }
        public List<Result> LastAirQualityResults { get; set; }
        public List<Result> LastHumidityResults { get; set; }
        public List<Result> LastCO2Results { get; set; }
        public List<Result> LastBurningGasResults { get; set; }
        public int MDataPublishedCount { get; set; }
    }
}
