using BusinessObject.Models;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class DevelopmentRepository : IDevelopmentRepository
    {
        public void Create(Development cate) => DevelopmentDAO.Instance.Create(cate);

        public void Delete(Development cate) => DevelopmentDAO.Instance.Delete(cate);

        public Development GetById(int id) => DevelopmentDAO.Instance.GetById(id);

        public List<Development> Get() => DevelopmentDAO.Instance.Get();
        public void Update(Development cate) => DevelopmentDAO.Instance.Update(cate);
    }
}
