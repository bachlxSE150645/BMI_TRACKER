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
    public class paymentRepository :IPaymentRepository
    {
        private readonly paymentDAO dao;

        public paymentRepository(MyDbContext dbContext)
        {
            dao = new paymentDAO(dbContext);
        }

        public Task<payment> AddNewPayment(payment MenuInfo) =>dao.AddNewPayment(MenuInfo);

        public bool deletePayments(payment menu)=>dao.deletePayments(menu);

        public List<payment> getAllpayments() =>dao.getAllpayments();

        public payment getPaymentById(Guid id) =>dao.getPaymentById(id);

        public payment UpdatePayments(payment menu) =>dao.UpdatePayments(menu);
    }
}
