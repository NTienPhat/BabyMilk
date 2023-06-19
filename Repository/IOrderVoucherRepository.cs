using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IOrderVoucherRepository
    {
        List<OrderVoucher> Get();
        void Delete(OrderVoucher cate);
        OrderVoucher GetById(int id);
        void Update(OrderVoucher cate);
        void Create(OrderVoucher cate);
    }
}
