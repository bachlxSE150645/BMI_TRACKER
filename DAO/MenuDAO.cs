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
        public List<food> getFoodByMenuName(string mennuName)
        {
            try
            {
                var menus = from menu in _context.menus
                            where menu.menuName == mennuName
                            join meal in _context.meals on menu.MenuId equals meal.menuId
                            join food in _context.foods on meal.foodId equals food.foodId
                            select food;
                return menus.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<food> getFoodByMenuId(Guid menuId)
        {
            try
            {
                var menus = from menu in _context.menus
                            where menu.MenuId == menuId
                            join meal in _context.meals on menu.MenuId equals meal.menuId
                            join food in _context.foods on meal.foodId equals food.foodId
                            select food;
                return menus.ToList();
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
                    .Include(f => f.meals).Include(u=>u.users)
                    .Where(x => x.MenuId.Equals(id)).SingleOrDefault();
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
                    userId = MenuInfo.userId,
                    users = _context.users.FirstOrDefault(u=>u.userId == MenuInfo.userId),
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

