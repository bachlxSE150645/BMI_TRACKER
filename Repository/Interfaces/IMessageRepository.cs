using BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IMessageRepository
    {
        List<message> GetMessages();
        message GetmessagesById(Guid id);
        Task<message> Addmessages(message category);
        void UpdateMessage(message category);
        void DeleteMess(message cate);
    }
}
