using data_models.custom;
using System;
using System.IO;

namespace utilities.Upload
{
    public class UploadHandler : IUploadHandler
    {
        public bool UploadFile(FileUploadRequest fileUploadRequest, out string error)
        {
            error = null;
            

            if (error == null) return true;
            else return false;
        }
    }
}
