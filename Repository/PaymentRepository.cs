using BusinessObject.Models;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class PaymentRepository : IPaymentRepository
    {
        public void Create(Payment cate) => PaymentDAO.Instance.Create(cate);

        public void Delete(Payment cate) => PaymentDAO.Instance.Delete(cate);

        public Payment GetById(int id) => PaymentDAO.Instance.GetById(id);

        public List<Payment> Get() => PaymentDAO.Instance.Get();
        public List<Payment> GetByUser(int id) => PaymentDAO.Instance.GetByUser(id);
        public void Update(Payment cate) => PaymentDAO.Instance.Update(cate);
    }
}
