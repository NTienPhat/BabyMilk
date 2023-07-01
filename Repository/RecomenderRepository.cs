using BusinessObject.Models;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RecomenderRepository : IRecomenderRepository
    {
        public async Task<Product> GetById(int id) => await RecomenderDAO.Instance.GetById(id);

        public List<Product> Get(int page, int pageSize, int month) => RecomenderDAO.Instance.Get(page, pageSize, month);
    }
}
