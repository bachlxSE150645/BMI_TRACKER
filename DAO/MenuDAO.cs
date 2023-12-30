 using BussinessObject;
using Microsoft.EntityFrameworkCore;
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
                return _context.menus.Include(f => f.meals).Include(f=>f.schedules).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Menu getMenuByName(string nemuName)
        {
            try
            {
                return _context.menus.FirstOrDefault(i => i.menuName.Equals(nemuName));
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
                return _context.menus.Include(f => f.meals).Include(f => f.schedules).FirstOrDefault(i => i.MenuId.Equals(id));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Menu UpdateMenu(Guid id,Menu menu)
        {
            try
            {
                var foo = _context.menus
                    .Include(f => f.meals)
                    .Where(x => x.MenuId.Equals(id)).SingleOrDefault();
                foo.status =menu.status;
                foo.menuName = menu.menuName;
                foo.menuType = menu.menuType;
                foo.menuDescription = menu.menuDescription;
                this._context.menus.Update(foo);
                this._context.SaveChanges();
                return foo;
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
                    menuType = MenuInfo.menuType,
                    status = "available-menu",
                    categoryId = MenuInfo.categoryId,
                    categorys = _context.categories.FirstOrDefault(r => r.CategoryId == MenuInfo.categoryId)

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

