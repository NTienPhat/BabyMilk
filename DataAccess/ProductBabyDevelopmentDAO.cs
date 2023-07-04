using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ProductBabyDevelopmentDAO
    {
        private static ProductBabyDevelopmentDAO instance = null;
        private static readonly object instanceLock = new object();
        BabyMilkV2Context _dbContext = new BabyMilkV2Context();
        public ProductBabyDevelopmentDAO()
        {

        }
        public static ProductBabyDevelopmentDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new ProductBabyDevelopmentDAO();
                    }
                    return instance;
                }
            }
        }
        public List<ProductBabyDevelopment> GetProductBabyDevelopment()
        {
            try
            {
                var candate = _dbContext.ProductBabyDevelopments.ToList();
                if (candate != null)
                {
                    return candate;
                }
                return null;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public void DeleteProductBabyDevelopment(ProductBabyDevelopment cate)
        {
            try
            {
                _dbContext.ChangeTracker.Clear();
                _dbContext.ProductBabyDevelopments.Remove(cate);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public ProductBabyDevelopment GetProductBabyDevelopmentsId(int id)
        {
            try
            {
                var ca = _dbContext.ProductBabyDevelopments.FirstOrDefault(x => x.ProductBabyDevelopmentId == id);
                if (ca != null)
                {
                    return ca;
                }
                return null;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public void UpdateProductBabyDevelopment(ProductBabyDevelopment cate)
        {
            try
            {
                _dbContext.ChangeTracker.Clear();
                _dbContext.Entry<ProductBabyDevelopment>(cate).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public void CreateNewProductBabyDevelopment(ProductBabyDevelopment pro)
        {
            try
            {
                _dbContext.ChangeTracker.Clear();
                _dbContext.ProductBabyDevelopments.Add(pro);
                _dbContext.SaveChanges();
                _dbContext.Entry(pro).State = EntityState.Detached;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        //public List<Product> SearchByKeyword(string keyword)
        //{
        //    try
        //    {
        //        var x = _dbContext.ProductBabyDevelopments.Where(x => x.Name.Contains(keyword)).ToList();
        //        if (x != null)
        //        {
        //            return x;
        //        }
        //        return null;
        //    }
        //    catch (Exception ex)
        //    {

        //        throw new Exception(ex.Message);
        //    }
        //}
    }
}
