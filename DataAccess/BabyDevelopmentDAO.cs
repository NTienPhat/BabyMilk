using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class BabyDevelopmentDAO
    {
        private static BabyDevelopmentDAO instance = null;
        private static readonly object instanceLock = new object();
        BabyMilkV2Context _dbContext = new BabyMilkV2Context();
        public BabyDevelopmentDAO()
        {

        }
        public static BabyDevelopmentDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new BabyDevelopmentDAO();
                    }
                    return instance;
                }
            }
        }
        public List<BabyDevelopment> Get()
        {
            try
            {
                var candate = _dbContext.BabyDevelopments.ToList();
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


        public void Delete(BabyDevelopment cate)
        {
            try
            {
                _dbContext.BabyDevelopments.Remove(cate);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public BabyDevelopment GetById(int id)
        {
            try
            {
                var ca = _dbContext.BabyDevelopments.FirstOrDefault(x => x.BabyDevelopmentId == id);
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


        public void Update(BabyDevelopment cate)
        {
            try
            {
                _dbContext.ChangeTracker.Clear();
                _dbContext.Entry<BabyDevelopment>(cate).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public void Create(BabyDevelopment cate)
        {
            try
            {
                _dbContext.BabyDevelopments.Add(cate);
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