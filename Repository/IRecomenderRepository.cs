using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IRecomenderRepository
    {
        List<Product> Get(int page, int pageSize, int month);
        Task<Product> GetById(int id);
    }
}
