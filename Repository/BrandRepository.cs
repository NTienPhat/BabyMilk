using BusinessObject.Models;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class BrandRepository : IBrandRepository
    {
        public void Create(Brand cate) => BrandDAO.Instance.Create(cate);

        public void Delete(Brand cate) => BrandDAO.Instance.Delete(cate);

        public Brand GetById(int id) => BrandDAO.Instance.GetById(id);

        public List<Brand> Get() => BrandDAO.Instance.Get();
        public void Update(Brand cate) => BrandDAO.Instance.Update(cate);
    }
}
