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
    public class menuRepository : IMenuRepository
    {
        private readonly MenuDAO dao;

        public menuRepository (MyDbContext dbContext)
        {
            dao = new MenuDAO(dbContext);
        }

        public Task<Menu> AddNewFood(Menu MenuInfo) =>dao.AddNewFood(MenuInfo);


        public void deleteFood(Menu menu) =>dao.deleteFood(menu);


        public List<Menu> getAllMenu() => dao.getAllMenu();

        public Menu getMenuById(Guid id)=>dao.getMenuById(id);

        public Menu UpdateFood(Menu menu)=>dao.UpdateFood(menu);
    }
}
