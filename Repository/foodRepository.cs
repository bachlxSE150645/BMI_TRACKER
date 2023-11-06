
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
        public List<food> GetFoodList() =>dao.GetFoodList();
        public food UpdateFood(food food) =>dao.UpdateFood(food);
    }
}
