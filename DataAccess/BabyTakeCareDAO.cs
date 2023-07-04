using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class BabyTakeCareDAO
    {

        private static BabyTakeCareDAO instance = null;
        private static readonly object instanceLock = new object();
        BabyMilkV2Context _dbContext = new BabyMilkV2Context();
        public BabyTakeCareDAO()
        {

        }
        public static BabyTakeCareDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new BabyTakeCareDAO();
                    }
                    return instance;
                }
            }
        }
        public List<BabyTakeCare> Get()
        {
            try
            {
                var candate = _dbContext.BabyTakeCares.ToList();
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


        public void Delete(BabyTakeCare cate)
        {
            try
            {
                _dbContext.BabyTakeCares.Remove(cate);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public BabyTakeCare GetById(int id)
        {
            try
            {
                var ca = _dbContext.BabyTakeCares.FirstOrDefault(x => x.BabyTakeCareId == id);
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


        public void Update(BabyTakeCare cate)
        {
            try
            {
                _dbContext.ChangeTracker.Clear();
                _dbContext.Entry<BabyTakeCare>(cate).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public void Create(BabyTakeCare cate)
        {
            try
            {
                _dbContext.BabyTakeCares.Add(cate);
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
