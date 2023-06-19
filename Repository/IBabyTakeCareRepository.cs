using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IBabyTakeCareRepository
    {
        List<BabyTakeCare> Get();
        void Delete(BabyTakeCare cate);
        BabyTakeCare GetById(int id);
        void Update(BabyTakeCare cate);
        void Create(BabyTakeCare cate);
    }
}
