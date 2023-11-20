using BussinessObject;
using DataAccess;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class FavoritFoodRepository : IFavoriteFoodRepository
    {
        private readonly FavoriteFoodDAO dao;

        public FavoritFoodRepository(MyDbContext dbContext)
        {
            dao = new FavoriteFoodDAO(dbContext);
        }

        public favoriteFood AddFavoriteFood(favoriteFood fa) =>dao.AddFavoriteFood(fa);

        public void DeleteFavoriteFood(Guid foodId,  Guid userId)=>dao.DeleteFavoriteFood( foodId,userId);

        public List<favoriteFood> GetFavoriteFood()=>dao.GetFavoriteFood();

        public favoriteFood GetFavoriteFoodByBoth(Guid FoodId, Guid userId) => dao.GetFavoriteFoodByBoth(FoodId, userId);

        public favoriteFood GetFavoriteFoodByFoodId(Guid FoodId)=>dao.GetFavoriteFoodByFoodId(FoodId);

        public favoriteFood GetFavoriteFoodById(Guid userId)=>dao.GetFavoriteFoodById(userId);
    }
}
