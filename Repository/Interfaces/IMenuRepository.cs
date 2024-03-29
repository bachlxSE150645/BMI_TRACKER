﻿using BussinessObject;
using BussinessObject.MapData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IMenuRepository
    {
        List<Menu> getAllMenu();
        Menu getMenuById(Guid id);
        List<food> getFoodByMenuName(string menuName);
        List<food> getFoodByMenuId(Guid menuId);
        Menu UpdateMenu(Guid id, menuUpdateInfo menu);
        Task<Menu> AddNewMenu(Menu MenuInfo);
        void deleteMenu(Menu menu);

    }
}
