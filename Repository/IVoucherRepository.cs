using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IVoucherRepository
    {
        List<Voucher> Get();
        void Delete(Voucher cate);
        Voucher GetById(int id);
        void Update(Voucher cate);
        void Create(Voucher cate);
    }
}
