using BussinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class FavoriteFoodDAO
    {
        private readonly MyDbContext _context;
        public FavoriteFoodDAO(MyDbContext context) { _context = context; }

        public List<favoriteFood> GetFavoriteFood()
        {
            try
            {
                return _context.favoriteFoods.Include(u=>u.users).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

       
        public favoriteFood GetFavoriteFoodById(Guid userId)
        {
            try
            {
                return _context.favoriteFoods.SingleOrDefault(x =>x.userId ==userId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public favoriteFood GetFavoriteFoodByFoodId(Guid FoodId)
        {
            try
            {
                return _context.favoriteFoods.SingleOrDefault(x => x.foodId == FoodId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public favoriteFood GetFavoriteFoodByBoth(Guid FoodId, Guid userId)
        {
            try
            {
                return _context.favoriteFoods.SingleOrDefault(x => x.foodId == FoodId && x.userId == userId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Post new Role
        public favoriteFood AddFavoriteFood(favoriteFood fa)
        {
            try
            {
                var newFa = new favoriteFood
                {
                    userId = fa.userId,
                    foodId = fa.foodId,
                    users = _context.users.SingleOrDefault(u=>u.userId == fa.userId),
                    foods = _context.foods.SingleOrDefault(u => u.foodId == fa.foodId),

                };

                _context.favoriteFoods.Add(newFa);
                _context.SaveChanges();
                return newFa;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
       
        public void DeleteFavoriteFood(Guid  foodId, Guid userId)
        {
            try
            {
                var cateCheck = _context.favoriteFoods.SingleOrDefault(x => x.foodId == foodId && x.userId  == userId);
                if (cateCheck != null)
                {
                    _context.favoriteFoods.Remove(cateCheck);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
