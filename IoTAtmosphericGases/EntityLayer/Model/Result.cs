using System;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Model
{
    public class Result
    {
        [Key]
        public int ResultID { get; set; }
        public string SensorName { get; set; }
        public string PredictedDataValue { get; set; }
        public string RealDataValue { get; set; }
        public DateTime PublishDateTime { get; set; }
    }
}
