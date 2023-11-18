using BussinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class messageDAO
    {
        private readonly MyDbContext _context;
        public messageDAO(MyDbContext context)
        {
            _context = context;
        }
        public List<message> GetMessages()
        {
            try
            {
                return _context.messages.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Get role by RoleID
        public message GetmessagesById(Guid id)
        {
            try
            {
                return _context.messages.SingleOrDefault(x => x.messageId == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Post new Role
        public async Task<message> Addmessages(message category)
        {
            try
            {
                var newMess = new message
                {
                    messageId = Guid.NewGuid(),
                    Content = category.Content,
                    file = category.file,
                    status = "available"

                };
                _context.messages.Add(newMess);
                await _context.SaveChangesAsync();
                return newMess;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void UpdateMessage(message category)
        {
            try
            {
                var cateCheck = _context.messages.SingleOrDefault(x => x.messageId == category.messageId);
                if (cateCheck != null)
                {
                    _context.Entry(cateCheck).CurrentValues.SetValues(category);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Delete existing role
        public void DeleteMess(message cate)
        {
            try
            {
                var cateCheck = _context.messages.SingleOrDefault(x => x.messageId == cate.messageId);
                if (cateCheck != null)
                {
                    _context.messages.Remove(cateCheck);
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
