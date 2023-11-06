using BussinessObject;
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
        Menu UpdateFood(Menu menu);
        Task<Menu> AddNewFood(Menu MenuInfo);
        void deleteFood(Menu menu);

    }
}
