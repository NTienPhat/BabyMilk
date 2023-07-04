using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DevelopmentDAO
    {
        private static DevelopmentDAO instance = null;
        private static readonly object instanceLock = new object();
        BabyMilkV2Context _dbContext = new BabyMilkV2Context();
        public DevelopmentDAO()
        {

        }
        public static DevelopmentDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new DevelopmentDAO();
                    }
                    return instance;
                }
            }
        }
        public List<Development> Get()
        {
            try
            {
                var candate = _dbContext.Developments.ToList();
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


        public void Delete(Development cate)
        {
            try
            {
                _dbContext.Developments.Remove(cate);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public Development GetById(int id)
        {
            try
            {
                var ca = _dbContext.Developments.FirstOrDefault(x => x.DevelopmentId == id);
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


        public void Update(Development cate)
        {
            try
            {
                _dbContext.ChangeTracker.Clear();
                _dbContext.Entry<Development>(cate).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public void Create(Development cate)
        {
            try
            {
                _dbContext.Developments.Add(cate);
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
