using BusinessObject.Models;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class TakeCareDevelopmentRepository : ITakeCareDevelopmentRepository
    {
        public void Create(TakeCareDevelopment cate) => TakeCareDevelopmentDAO.Instance.Create(cate);

        public void Delete(TakeCareDevelopment cate) => TakeCareDevelopmentDAO.Instance.Delete(cate);

        public TakeCareDevelopment GetById(int id) => TakeCareDevelopmentDAO.Instance.GetById(id);

        public List<TakeCareDevelopment> Get() => TakeCareDevelopmentDAO.Instance.Get();

        public void Update(TakeCareDevelopment cate) => TakeCareDevelopmentDAO.Instance.Update(cate);
    }
}
