using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class BrandDAO
    {
        private static BrandDAO instance = null;
        private static readonly object instanceLock = new object();
        BabyMilkContext _dbContext = new BabyMilkContext();
        public BrandDAO()
        {

        }
        public static BrandDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new BrandDAO();
                    }
                    return instance;
                }
            }
        }
        public List<Brand> Get()
        {
            try
            {
                var candate = _dbContext.Brands.ToList();
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


        public void Delete(Brand cate)
        {
            try
            {
                _dbContext.Brands.Remove(cate);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public Brand GetById(int id)
        {
            try
            {
                var ca = _dbContext.Brands.FirstOrDefault(x => x.BrandId == id);
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


        public void Update(Brand cate)
        {
            try
            {
                _dbContext.ChangeTracker.Clear();
                _dbContext.Entry<Brand>(cate).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public void Create(Brand cate)
        {
            try
            {
                _dbContext.Brands.Add(cate);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        //public List<BabyDevelopment> SearchByKeyword(string keyword)
        //{
        //    try
        //    {
        //        var x = _dbContext.Babies.Where(x => x.Name.Contains(keyword)).ToList();
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
