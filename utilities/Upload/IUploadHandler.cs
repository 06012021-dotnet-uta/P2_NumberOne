using data_models.custom;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace utilities.Upload
{
    public interface IUploadHandler
    {
        bool UploadFile(FileUploadRequest fileUploadRequest, out string error);
    }
}
