using BusinessObject.Models;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        public void Create(OrderDetail cate) => OrderDetailDAO.Instance.Create(cate);

        public void Delete(OrderDetail cate) => OrderDetailDAO.Instance.Delete(cate);

        public OrderDetail GetById(int id) => OrderDetailDAO.Instance.GetById(id);

        public List<OrderDetail> Get() => OrderDetailDAO.Instance.Get();
        public List<OrderDetail> GetByOrderId(int id) => OrderDetailDAO.Instance.GetByOrderId(id);
        public void Update(OrderDetail cate) => OrderDetailDAO.Instance.Update(cate);
    }
}
