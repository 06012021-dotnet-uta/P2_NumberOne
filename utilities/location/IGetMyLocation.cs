using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using data_models;

namespace utilities
{
    public interface IGetMyLocation
    {
        string GetMyCoordinate(string ip);
    }
}
