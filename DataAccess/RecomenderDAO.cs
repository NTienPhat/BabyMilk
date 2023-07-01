using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class RecomenderDAO
    {
        private static RecomenderDAO instance = null;
        private static readonly object instanceLock = new object();
        BabyMilkContext _dbContext = new BabyMilkContext();
        public RecomenderDAO()
        {

        }
        public static RecomenderDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new RecomenderDAO();
                    }
                    return instance;
                }
            }
        }
        public List<Product> Get(int page, int pageSize, int month)
        {
            try
            {
                using (var _dbContext = new BabyMilkContext())
                {
                    if (page <= 1)
                        page = 0;
                    else
                        page = page - 1;
                    int totalNumber = page * pageSize;
                    var query = from p in _dbContext.Products
                                join pd in _dbContext.ProductBabyDevelopments on p.ProductId equals pd.ProductId
                                join m in _dbContext.MilestonesByMonths on pd.MilestonesByMonthId equals m.MilestonesByMonthId
                                where month >= m.MinMonth && month <= m.MaxMonth
                                select p;
                    if (query != null)
                    {
                        List<Product> products = query.Skip(totalNumber).Take(pageSize).ToList();
                        return products;
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<Product> GetById(int id)
        {
            try
            {
                using (var _dbContext = new BabyMilkContext())
                {
                    Product ca = await _dbContext.Products.FirstOrDefaultAsync(x => x.ProductId == id);
                    if (ca != null)
                    {
                        return ca;
                    }
                    return null;
                }


            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
