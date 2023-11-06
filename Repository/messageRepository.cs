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
    public class messageRepository :IMessageRepository
    {

        private readonly messageDAO dao;

        public messageRepository(MyDbContext dbContext)
        {
            dao = new messageDAO(dbContext);
        }

        public Task<message> Addmessages(message category) =>dao.Addmessages(category);

        public void DeleteMess(message cate) =>dao.DeleteMess(cate);

        public List<message> GetMessages() =>dao.GetMessages();

        public message GetmessagesById(Guid id) =>dao.GetmessagesById(id);

        public void UpdateMessage(message category)=>dao.UpdateMessage(category);
    }
}
