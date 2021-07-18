using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System.Drawing;
using data_models;
using data_models.custom;

namespace utilities
{
    public interface IPetHandler
    {
        Pet CreatePet(RegisterPetRequest pet, out string error);
        List<Pet> PetList();
        Pet PetDetails(int id);
        Pet SearchPetByOwnerId(int Ownerid, out string error);
        List<Gender> GenderList();
        List<AggressionCode> AggressionCodeList();
    }
}