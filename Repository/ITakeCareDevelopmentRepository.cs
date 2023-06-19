using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface ITakeCareDevelopmentRepository
    {
        List<TakeCareDevelopment> Get();
        void Delete(TakeCareDevelopment cate);
        TakeCareDevelopment GetById(int id);
        void Update(TakeCareDevelopment cate);
        void Create(TakeCareDevelopment cate);
    }
}
