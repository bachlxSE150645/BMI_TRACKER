using BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IPaymentRepository
    {
        List<payment> getAllpayments();
        payment getPaymentById(Guid id);
        payment UpdatePayments(payment menu);
        Task<payment> AddNewPayment(payment MenuInfo);
       bool deletePayments(payment menu);
    }
}
