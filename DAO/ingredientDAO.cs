using BussinessObject;
using DAO;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ingredientDAO
    {
        private readonly MyDbContext _context;
        public ingredientDAO(MyDbContext context)
        {
            _context = context;
        }

        public List<ingredient> GetAll()
        {
            try
            {
                return _context.ingredients.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public ingredient getIngredientById(Guid id)
        {
            try
            {
                return _context.ingredients.FirstOrDefault(i=>i.ingredientId.Equals(id));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
       public ingredient updateIngredinet (ingredient ingredient)
        {
            try
            {
                var ing = _context.ingredients.FirstOrDefault(u => u.ingredientId == ingredient.ingredientId);
                if(ing != null)
                {
                    _context.Entry<ingredient>(ing).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    _context.SaveChanges();
                }
                return ing;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        
        public async Task<ingredient> AddIngredient(ingredient ingredient)
        {
            try
            {
                var newIngredient = new ingredient
                {
                    ingredientId = Guid.NewGuid(),
                    ingredientName = ingredient.ingredientName,
                    ingredientPhoto = ingredient.ingredientPhoto,
                    status = "available-ingre",
                    categorys = _context.categories.FirstOrDefault(r => r.CategoryName == "ingredient")

                };
                _context.ingredients.Add(newIngredient);
                await _context.SaveChangesAsync();
                return newIngredient;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void DeleteIngredient(ingredient ingredient)
        {
            try
            {
                var existingIngredient = _context.ingredients.SingleOrDefault(x => x.ingredientId.Equals(ingredient.ingredientId));
                if (existingIngredient != null)
                {
                    _context.ingredients.Remove(existingIngredient);
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
