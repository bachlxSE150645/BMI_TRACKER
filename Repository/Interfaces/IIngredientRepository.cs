using BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
     public interface IIngredientRepository
    {
        List<ingredient> getAll();
        ingredient getIngredientById(Guid id);
        ingredient updateIngredinet(ingredient ingredient);
        Task<ingredient> AddIngredient(ingredient ingredient);
        void DeleteIngredient(ingredient ingredient);
    }
}
