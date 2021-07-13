using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System.Drawing;
using data_models;
using data_models.custom;

namespace utilities
{
    public interface IBreedHandler
    {
        Breed CreateBreed(RegisterBreedRequest breed ,  out string error);
        List<Breed> BreedList();



    }
}