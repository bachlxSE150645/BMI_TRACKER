﻿using BussinessObject;
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
    public class menuRepository : IMenuRepository
    {
        private readonly MenuDAO dao;

        public menuRepository (MyDbContext dbContext)
        {
            dao = new MenuDAO(dbContext);
        }

        public Task<Menu> AddNewMenu(Menu MenuInfo)=>dao.AddNewFood(MenuInfo);

        public void deleteMenu(Menu menu) =>dao.deleteFood(menu);

        public List<Menu> getAllMenu() =>dao.getAllMenu();

        public Menu getMenuById(Guid id) =>dao.getMenuById(id);
        public List<food> getFoodByMenuName(string menuName) => dao.getFoodByMenuName(menuName);

        public Menu UpdateMenu(Guid id, menuUpdateInfo menu)
        {
            var r = dao.getMenuById(id);  
            if (!String.IsNullOrEmpty(menu.menuName))
                {
                    r.menuName = menu.menuName;
                }
            if (!String.IsNullOrEmpty(menu.menuType))
            {
                r.menuType = menu.menuType;
            }
            if (!String.IsNullOrEmpty(menu.menuPhoto))
            {
                r.menuPhoto = menu.menuPhoto;
            }
           
            if (!String.IsNullOrEmpty(menu.menuDescription))
            {
                r.menuDescription = menu.menuDescription;
            }
            
            return dao.UpdateMenu(id, r);
            
        }

        public List<food> getFoodByMenuId(Guid menuId) => dao.getFoodByMenuId(menuId);
    }
}
