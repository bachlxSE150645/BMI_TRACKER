using BussinessObject;
using BussinessObject.MapData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IFoodRepository
    {
        List<food> GetFoodList();
        List<food> GetFoodByTag(string tag);
        food getFoodById(Guid id);
        food UpdateFood(food food);
        Task<food> AddNewFood(food food);
        void DeleteFood(food food);
    }
}
