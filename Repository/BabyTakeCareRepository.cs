using BusinessObject.Models;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class BabyTakeCareRepository : IBabyTakeCareRepository
    {
        public void Create(BabyTakeCare cate) => BabyTakeCareDAO.Instance.Create(cate);

        public void Delete(BabyTakeCare cate) => BabyTakeCareDAO.Instance.Delete(cate);

        public BabyTakeCare GetById(int id) => BabyTakeCareDAO.Instance.GetById(id);

        public List<BabyTakeCare> Get() => BabyTakeCareDAO.Instance.Get();

        public void Update(BabyTakeCare cate) => BabyTakeCareDAO.Instance.Update(cate);

    }
}
