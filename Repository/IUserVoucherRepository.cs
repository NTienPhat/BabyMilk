using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IUserVoucherRepository
    {
        List<UserVoucher> Get();
        void Delete(UserVoucher cate);
        UserVoucher GetById(int id);
        void Update(UserVoucher cate);
        void Create(UserVoucher cate);
    }
}
