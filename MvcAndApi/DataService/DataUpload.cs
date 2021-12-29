using DataAccessLayer;
using EntityLayer;
using EntityLayer.Model;
using System;
using System.Collections.Generic;
using System.IO.Ports;

namespace DataService
{
    public class DataUpload : IDataUpload
    {
        private SerialPort serialPort;

        public DataUpload()
        {
            serialPort = new SerialPort("COM4");
            serialPort.BaudRate = 9600;
            serialPort.DataBits = 8;
            serialPort.Handshake = Handshake.None;
            serialPort.Parity = Parity.None;
            serialPort.StopBits = StopBits.One;
            serialPort.ReadTimeout = -1;
            serialPort.WriteTimeout = -1;
            serialPort.Open();
        }

        public string[] data2;
        public List<MDataPublish> UploadDataToDatabase()
        {
            string data = serialPort.ReadLine().Replace("\r", "");
            var dataToReturn = new List<MDataPublish>();
            if (data != "Calibrating MQ7" || data != "Calibration done!")
            {
                data2 = data.Split('*');
                int x = 0;
                foreach (var item in data2)
                {
                    var newData = new MDataPublish();
                    newData.PublishDateTime = DateTime.Now;
                    newData.DataValue = item;
                    if (x == 0)
                    {
                        newData.SensorName = "Nem";
                        newData.DataName = "RH";
                    }
                    else if (x == 1)
                    {
                        newData.SensorName = "Sıcaklık";
                        newData.DataName = "C";
                    }
                    else if (x == 2)
                    {
                        newData.SensorName = "KarbonDioksit";
                        newData.DataName = "PPM";
                    }
                    else if (x == 3)
                    {
                        newData.SensorName = "YanıcıGaz";
                        newData.DataName = "PPM";
                    }
                    else if (x == 4)
                    {
                        newData.SensorName = "HavaKalitesi";
                        newData.DataName = "PPM";
                    }
                    x++;
                    //_context.MDataPublishes.Add(newData);
                    //_context.SaveChanges();
                    dataToReturn.Add(newData);
                }
            }
            return dataToReturn;
        }
    }
}
 