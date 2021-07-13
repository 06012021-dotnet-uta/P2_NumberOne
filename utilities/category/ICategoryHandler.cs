using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System.Drawing;
using data_models;
using data_models.custom;

namespace utilities
{
    public interface ICategoryHandler
    {
        Category CreateCategory(RegisterCategoryRequest category , out string error);
        List<Category> CategoryList();
        

        
    }
}