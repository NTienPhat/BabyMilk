using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IDevelopmentRepository
    {
        List<Development> Get();
        void Delete(Development cate);
        Development GetById(int id);
        void Update(Development cate);
        void Create(Development cate);
    }
}
