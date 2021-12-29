using EntityLayer.Model;
using System.Collections.Generic;

namespace DataService
{
    public interface IDataUpload
    {
        public List<MDataPublish> UploadDataToDatabase();
    }
}
