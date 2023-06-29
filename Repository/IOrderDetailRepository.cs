using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IOrderDetailRepository
    {
        List<OrderDetail> Get();
        List<OrderDetail> GetByOrderId(int id);
        void Delete(OrderDetail cate);
        OrderDetail GetById(int id);
        void Update(OrderDetail cate);
        void Create(OrderDetail cate);
    }
}
