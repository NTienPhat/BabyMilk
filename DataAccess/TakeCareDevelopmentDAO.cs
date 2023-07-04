using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class TakeCareDevelopmentDAO
    {
        private static TakeCareDevelopmentDAO instance = null;
        private static readonly object instanceLock = new object();
        BabyMilkV2Context _dbContext = new BabyMilkV2Context();
        public TakeCareDevelopmentDAO()
        {

        }
        public static TakeCareDevelopmentDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new TakeCareDevelopmentDAO();
                    }
                    return instance;
                }
            }
        }
        public List<TakeCareDevelopment> Get()
        {
            try
            {
                var candate = _dbContext.TakeCareDevelopments.ToList();
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


        public void Delete(TakeCareDevelopment cate)
        {
            try
            {
                _dbContext.TakeCareDevelopments.Remove(cate);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public TakeCareDevelopment GetById(int id)
        {
            try
            {
                var ca = _dbContext.TakeCareDevelopments.FirstOrDefault(x => x.TakeCareDevelopmentId == id);
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


        public void Update(TakeCareDevelopment cate)
        {
            try
            {
                _dbContext.ChangeTracker.Clear();
                _dbContext.Entry<TakeCareDevelopment>(cate).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public void Create(TakeCareDevelopment cate)
        {
            try
            {
                _dbContext.TakeCareDevelopments.Add(cate);
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
