using BusinessObject.Models;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class BabyRepository : IBabyRepository
    {
        public void CreateNewBaby(Baby cate) => BabyDAO.Instance.CreateNewBaby(cate);

        public void DeleteBaby(Baby cate) => BabyDAO.Instance.DeleteBaby(cate);

        public Baby GetBabyById(int id) => BabyDAO.Instance.GetBabyById(id);

        public List<Baby> GetBaby() => BabyDAO.Instance.GetBaby();
        public List<Baby> GetBabyByMom(int id) => BabyDAO.Instance.GetBabyByMom(id);

        public List<Baby> SearchByKeyword(string keyword) => BabyDAO.Instance.SearchByKeyword(keyword);

        public void UpdateBaby(Baby cate) => BabyDAO.Instance.UpdateBaby(cate);

    }
}
