 using BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class MenuDAO
    {
        private readonly MyDbContext _context;
        public MenuDAO(MyDbContext context) { _context = context; }

        public List<Menu> getAllMenu()
        {
            try
            {
                return _context.menus.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Menu getMenuById(Guid id)
        {
            try
            {
                return _context.menus.FirstOrDefault(i => i.MenuId.Equals(id));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Menu UpdateFood(Menu menu)
        {
            try
            {
                var men = _context.menus.FirstOrDefault(m =>m.MenuId == menu.MenuId);
                if (men != null)
                {
                    _context.Entry<Menu>(menu).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    _context.SaveChanges();
                    return men;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<Menu> AddNewFood(Menu MenuInfo)
        {
            try
            {
                var newMenu = new Menu
                {
                    MenuId = Guid.NewGuid(),
                    menuName = MenuInfo.menuName,
                    menuDescription = MenuInfo.menuDescription,
                    menuPhoto = MenuInfo.menuPhoto,
                    menuPrice = MenuInfo.menuPrice,
                    menuType = MenuInfo.menuType,
                    status = "available",
                    categorys = _context.categories.FirstOrDefault(r => r.CategoryName == "menu")

                };
                _context.menus.Add(newMenu);
                await _context.SaveChangesAsync();
                return newMenu;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool deleteFood(Menu menu)
        {
            try
            {
                var foo = _context.menus.FirstOrDefault(f => f.MenuId == menu.MenuId);
                if (foo != null)
                {
                    _context.menus.Remove(foo);
                    _context.SaveChanges();
                    return true;
                }
                return false;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

