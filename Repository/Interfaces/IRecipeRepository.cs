using BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IRecipeRepository
    {
        List<recipe> getFoodsById(Guid foodId);
        List<recipe> getIngredientsById(Guid ingId);
         recipe createnewRecipe(recipe re);
        void UpdateRecipe(recipe recipeDetail);
        void DeleteRecipeDetail(recipe recipeDetail);
    }
}
