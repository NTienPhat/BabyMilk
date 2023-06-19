using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IBrandRepository
    {
        List<Brand> Get();
        void Delete(Brand cate);
        Brand GetById(int id);
        void Update(Brand cate);
        void Create(Brand cate);
    }
}
