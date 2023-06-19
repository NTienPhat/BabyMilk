using BusinessObject.Models;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class OrderVoucherRepository : IOrderVoucherRepository
    {
        public void Create(OrderVoucher cate) => OrderVoucherDAO.Instance.Create(cate);

        public void Delete(OrderVoucher cate) => OrderVoucherDAO.Instance.Delete(cate);

        public OrderVoucher GetById(int id) => OrderVoucherDAO.Instance.GetById(id);

        public List<OrderVoucher> Get() => OrderVoucherDAO.Instance.Get();
        public void Update(OrderVoucher cate) => OrderVoucherDAO.Instance.Update(cate);
    }
}
