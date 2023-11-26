
using BussinessObject;
using BussinessObject.MapData;
using DataAccess;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class foodRepository :IFoodRepository
    {
        private readonly foodDAO dao;

        public foodRepository(MyDbContext dbContext)
        {
            dao = new foodDAO(dbContext);
        }

        public Task<food> AddNewFood(food food) =>dao.AddNewFood(food);
        public void DeleteFood(food food) =>dao.deleteFood(food);
        public food getFoodById(Guid id) =>dao.getFoodById(id);

        public List<food> GetFoodByTag(string tag) =>dao.getFoodByTAG(tag);

        public List<food> GetFoodList() =>dao.GetFoodList();

        public food UpdateFood(Guid id, foodInfo food)
        {
            var r = dao.getFoodById(id);
            if (!String.IsNullOrEmpty(food.foodName))
            {
                r.foodName = food.foodName;
            }
            if (!String.IsNullOrEmpty(food.foodNutrition))
            {
                r.foodNutrition = food.foodNutrition;
            }
            if (!String.IsNullOrEmpty(food.foodTag))
            {
                r.foodTag = food.foodTag;
            }
            if (!String.IsNullOrEmpty(food.foodPhoto))
            {
                r.foodPhoto = food.foodPhoto;
            }
            if (food.foodtimeProcess != null)
            {
                r.foodtimeProcess = food.foodtimeProcess;
            }
            if (!String.IsNullOrEmpty(food.foodNutrition))
            {
                r.foodNutrition = food.foodNutrition;
            }
            if (!String.IsNullOrEmpty(food.foodProcessingVideo))
            {
                r.foodProcessingVideo = food.foodProcessingVideo;
            }
            if (!String.IsNullOrEmpty(food.foodNotes))
            {
                r.foodNotes = food.foodNotes;
            }
            if (!String.IsNullOrEmpty(food.foodDesciption))
            {
                r.foodDesciption = food.foodDesciption;
            }
            if(food.foodCalorios != null)
            {
                r.foodCalorios = food.foodCalorios;
            }
            return dao.UpdateFood(id, r);
        }
    }
}
