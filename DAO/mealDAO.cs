using BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class mealDAO
    {
        private readonly MyDbContext _context;
        public mealDAO(MyDbContext context)
        {
            _context = context;
        }
        public List<Meal> getFoodsById(Guid foodId)
        {
            try
            {
                var result = (from r in _context.meals
                              where (r.foodId == foodId)
                              select r).ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<Meal> getMenusbyId(Guid menuId)
        {
            try
            {
                var result = (from r in _context.meals
                              where (r.menuId == menuId)
                              select r).ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
