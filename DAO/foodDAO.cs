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
                return _context.foods.Include(f=>f.recipes).ToList();
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
        public List<food> getFoodByTAG(string tag)
        {
            try
            {
                var foodTag = from u in _context.foods
                                where u.foodTag.Contains(tag)
                                select u;
                return foodTag.ToList();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public food UpdateFood(Guid id, food food)
        {
            try
            {
                var foo = _context.foods
                    .Include(f=>f.recipes)
                    .Where(x=>x.foodId.Equals(id)).SingleOrDefault();
                foo.foodName = food.foodName;
                foo.foodNutrition = food.foodNutrition;
                foo.foodNotes = food.foodNotes;
                foo.foodTag = food.foodTag;
                foo.foodProcessingVideo = food.foodProcessingVideo;
                foo.foodtimeProcess = food.foodtimeProcess;
                foo.status = food.status;
                foo.foodCalorios = food.foodCalorios;
                foo.foodPhoto = food.foodPhoto;
                foo.foodDesciption = food.foodDesciption;
                this._context.foods.Update(foo);
                this._context.SaveChanges();
                return foo;
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
                    foodDesciption = foodInfo.foodDesciption,
                    status = "available-food",
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
