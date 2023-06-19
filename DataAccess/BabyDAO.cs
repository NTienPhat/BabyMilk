using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class BabyDAO
    {
        private static BabyDAO instance = null;
        private static readonly object instanceLock = new object();
        BabyMilkContext _dbContext = new BabyMilkContext();
        public BabyDAO()
        {

        }
        public static BabyDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new BabyDAO();
                    }
                    return instance;
                }
            }
        }
        public List<Baby> GetBaby()
        {
            try
            {
                var candate = _dbContext.Babies.ToList();
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


        public void DeleteBaby(Baby cate)
        {
            try
            {
                _dbContext.Babies.Remove(cate);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public Baby GetBabyById(int id)
        {
            try
            {
                var ca = _dbContext.Babies.FirstOrDefault(x => x.BabyId == id);
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

        public List<Baby> GetBabyByMom(int id)
        {
            try
            {
                var candate = _dbContext.Babies.Where(x => x.AccountId == id).ToList();
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

        public void UpdateBaby(Baby cate)
        {
            try
            {
                _dbContext.ChangeTracker.Clear();
                _dbContext.Entry<Baby>(cate).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public void CreateNewBaby(Baby cate)
        {
            try
            {
                _dbContext.Babies.Add(cate);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public List<Baby> SearchByKeyword(string keyword)
        {
            try
            {
                var x = _dbContext.Babies.Where(x => x.Name.Contains(keyword)).ToList();
                if (x != null)
                {
                    return x;
                }
                return null;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
