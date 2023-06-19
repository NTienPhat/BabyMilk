using BusinessObject.Models;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class UserVoucherRepository : IUserVoucherRepository
    {
        public void Create(UserVoucher cate) => UserVoucherDAO.Instance.Create(cate);

        public void Delete(UserVoucher cate) => UserVoucherDAO.Instance.Delete(cate);

        public UserVoucher GetById(int id) => UserVoucherDAO.Instance.GetById(id);

        public List<UserVoucher> Get() => UserVoucherDAO.Instance.Get();
        public void Update(UserVoucher cate) => UserVoucherDAO.Instance.Update(cate);
    }
}
