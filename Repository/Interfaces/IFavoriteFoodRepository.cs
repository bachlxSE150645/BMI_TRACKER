using BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IFavoriteFoodRepository
    {
        List<favoriteFood> GetFavoriteFood();
        favoriteFood GetFavoriteFoodById(Guid userId);
        favoriteFood GetFavoriteFoodByFoodId(Guid FoodId);
        favoriteFood GetFavoriteFoodByBoth(Guid FoodId,Guid userId);
        favoriteFood AddFavoriteFood(favoriteFood fa);
        void DeleteFavoriteFood(Guid foodId, Guid userId);
        
    }
}
