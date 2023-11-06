using BussinessObject;
using BussinessObject.MapData;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class foodDAO
    {
        private readonly MyDbContext _context;
        public foodDAO(MyDbContext context) { _context = context; }
        public List<food> GetFoodList()
        {
            try
            {
                return _context.foods.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public food getFoodById(Guid id)
        {
            try
            {
                return _context.foods.FirstOrDefault(i => i.foodId.Equals(id));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public food UpdateFood(food food)
        {
            try
            {
                var foo = _context.foods.FirstOrDefault(f => f.foodId == food.foodId);
                if (foo != null)
                {
                    _context.Entry<food>(foo).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    _context.SaveChanges();
                    return foo;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<food> AddNewFood(food foodInfo)
        {
            try
            {
                var newFood = new food
                {
                    foodId = Guid.NewGuid(),
                    foodName = foodInfo.foodName,
                    foodTag = foodInfo.foodTag,
                    foodNutrition = foodInfo.foodNutrition,
                    foodNotes = foodInfo.foodNotes,
                    foodPhoto = foodInfo.foodPhoto,
                    foodtimeProcess = foodInfo.foodtimeProcess,
                    foodCalorios = foodInfo.foodCalorios,
                    foodProcessingVideo = foodInfo.foodProcessingVideo,
                    status = "available",
                    categorys = _context.categories.Where(u => u.CategoryName == "food").FirstOrDefault()
                };
                _context.foods.Add(newFood);
                await _context.SaveChangesAsync();
                return newFood;
            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        public bool deleteFood (food food)
        {
            try
            {
                var foo = _context.foods.FirstOrDefault(f => f.foodId == food.foodId);
                if (foo != null)
                {
                    _context.foods.Remove(foo);
                    _context.SaveChanges();
                    return true;
                }
                return false;

            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
