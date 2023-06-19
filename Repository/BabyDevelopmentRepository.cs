using BusinessObject.Models;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class BabyDevelopmentRepository : IBabyDevelopmentRepository
    {
        public void Create(BabyDevelopment cate) => BabyDevelopmentDAO.Instance.Create(cate);

        public void Delete(BabyDevelopment cate) => BabyDevelopmentDAO.Instance.Delete(cate);

        public BabyDevelopment GetById(int id) => BabyDevelopmentDAO.Instance.GetById(id);

        public List<BabyDevelopment> Get() => BabyDevelopmentDAO.Instance.Get();
        public void Update(BabyDevelopment cate) => BabyDevelopmentDAO.Instance.Update(cate);
    }
}
