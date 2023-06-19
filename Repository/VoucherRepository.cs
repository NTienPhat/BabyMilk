using BusinessObject.Models;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class VoucherRepository : IVoucherRepository
    {
        public void Create(Voucher cate) => VoucherDAO.Instance.Create(cate);

        public void Delete(Voucher cate) => VoucherDAO.Instance.Delete(cate);

        public Voucher GetById(int id) => VoucherDAO.Instance.GetById(id);

        public List<Voucher> Get() => VoucherDAO.Instance.Get();
        public void Update(Voucher cate) => VoucherDAO.Instance.Update(cate);
    }
}
