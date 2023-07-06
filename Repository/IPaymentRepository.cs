using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IPaymentRepository
    {
        List<Payment> Get();
        List<Payment> GetByUser(int id);
        void Delete(Payment cate);
        Payment GetById(int id);
        void Update(Payment cate);
        void Create(Payment cate);
    }
}
