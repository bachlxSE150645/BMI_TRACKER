using BussinessObject;
using DAO;
using DataAccess;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ingredientRepository :IIngredientRepository
    {
        private readonly ingredientDAO dao;

        public ingredientRepository(MyDbContext dbContext)
        {
            dao = new ingredientDAO(dbContext);
        }

        public Task<ingredient> AddIngredient(ingredient ingredient) =>dao.AddIngredient(ingredient);

        public void DeleteIngredient(ingredient ingredient) => dao.DeleteIngredient(ingredient);

        public List<ingredient> getAll() =>dao.GetAll();

        public ingredient getIngredientById(Guid id) => dao.getIngredientById(id);

        public ingredient updateIngredinet(ingredient ingredient) => dao.updateIngredinet(ingredient);
    }
}
