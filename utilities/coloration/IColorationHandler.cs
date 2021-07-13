using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System.Drawing;
using data_models;
using data_models.custom;

namespace utilities
{
    public interface IColorationHandler
    {
        Coloration CreateColoration(RegisterColorationRequest coloration, out string error);
        List<Coloration> ColorationList();
        

        
    }
}