using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IBabyRepository
    {
        List<Baby> GetBaby();
        List<Baby> GetBabyByMom(int id);
        void DeleteBaby(Baby cate);
        Baby GetBabyById(int id);
        void UpdateBaby(Baby cate);
        void CreateNewBaby(Baby cate);
        List<Baby> SearchByKeyword(string keyword);
    }
}
