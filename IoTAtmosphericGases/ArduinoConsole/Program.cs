using DataAccessLayer;
using DataService;
using EntityLayer;
using EntityLayer.Model;
using System;
using System.Collections.Generic;

namespace ArduinoConsole
{
    class Program
    {
        public static DataUpload dataUpload = new DataUpload();
        public static IUnitOfWork<MDataPublish> unitOfWorkMDataPublish;
        public static AtmosphericGasesDBContext dBContext = new AtmosphericGasesDBContext();
        public static bool IsDeviceReady()
        {
            if (dataUpload.UploadDataToDatabase() != null)
            {
                return true;
            }
            else
            {
                return IsDeviceReady();
            }
        }

        public static List<MDataPublish> GetData()
        {
            if (IsDeviceReady())
            {
                var data = dataUpload.UploadDataToDatabase();
                if (data.Count != 0)
                {
                    foreach (var item in data)
                    {
                        Console.Write(item.SensorName + " - " + item.DataValue + " /" + item.DataName + " ");
                    }
                    Console.WriteLine();
                    dBContext.MDataPublishes.AddRange(data);
                    dBContext.SaveChanges();
                }
                GetData();
                return dataUpload.UploadDataToDatabase();
            }
            else
            {
                return GetData();
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Verilerin gelmesi biraz zaman alabilir...");
            var listOfData = GetData();
        }
    }
}
