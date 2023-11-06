using BussinessObject;
using BussinessObject.MapData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class paymentDAO
    {
        private readonly MyDbContext _context;
        public paymentDAO(MyDbContext context) { _context = context; }

        public List<payment> getAllpayments()
        {
            try
            {
                return _context.Payments.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public payment getPaymentById(Guid id)
        {
            try
            {
                return _context.Payments.FirstOrDefault(i => i.paymentId.Equals(id));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public payment UpdatePayments(payment menu)
        {
            try
            {
                var men = _context.Payments.FirstOrDefault(m => m.paymentId == menu.paymentId);
                if (men != null)
                {
                    _context.Entry<payment>(menu).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
        public async Task<payment> AddNewPayment(payment MenuInfo)
        {
            try
            {
                var newPayment = new payment
                {
                    paymentId = MenuInfo.paymentId,
                    paymentName = MenuInfo.paymentName,
                    status = "avaiable"
                };
                _context.Payments.Add(newPayment);
                await _context.SaveChangesAsync();
                return newPayment;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool deletePayments(payment menu)
        {
            try
            {
                var foo = _context.Payments.FirstOrDefault(f => f.paymentId == menu.paymentId);
                if (foo != null)
                {
                    _context.Payments.Remove(foo);
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
