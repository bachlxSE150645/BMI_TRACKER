using BussinessObject;
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
        Menu getMenuByName(string name);
        Menu UpdateMenu(Guid id, MenuInfo menu);
        Task<Menu> AddNewMenu(Menu MenuInfo);
        void deleteMenu(Menu menu);

    }
}
