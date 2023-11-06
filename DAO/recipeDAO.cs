using BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class recipeDAO
    {
        private readonly MyDbContext _context;
        public recipeDAO(MyDbContext context)
        {
            _context = context;
        }
        public List<recipe> getFoodsById(Guid foodId)
        {
            try
            {
                var result = (from r in _context.recipes
                              where (r.foodId == foodId)
                              select r).ToList();
                return result;
            }
            catch(Exception ex) 
            {
                throw new Exception(ex.Message);
            }
        }
        public List<recipe> getIngredientsbyId(Guid ingredientId)
        {
            try
            {
                var result = (from r in _context.recipes
                              where (r.ingredientId == ingredientId)
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
