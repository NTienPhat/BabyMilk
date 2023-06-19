using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IBabyDevelopmentRepository
    {
        List<BabyDevelopment> Get();
        void Delete(BabyDevelopment cate);
        BabyDevelopment GetById(int id);
        void Update(BabyDevelopment cate);
        void Create(BabyDevelopment cate);
    }
}
