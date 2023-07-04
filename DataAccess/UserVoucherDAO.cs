using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class UserVoucherDAO
    {
        private static UserVoucherDAO instance = null;
        private static readonly object instanceLock = new object();
        BabyMilkV2Context _dbContext = new BabyMilkV2Context();
        public UserVoucherDAO()
        {

        }
        public static UserVoucherDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new UserVoucherDAO();
                    }
                    return instance;
                }
            }
        }
        public List<UserVoucher> Get()
        {
            try
            {
                var candate = _dbContext.UserVouchers.ToList();
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


        public void Delete(UserVoucher cate)
        {
            try
            {
                _dbContext.UserVouchers.Remove(cate);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public UserVoucher GetById(int id)
        {
            try
            {
                var ca = _dbContext.UserVouchers.FirstOrDefault(x => x.UserVoucherId == id);
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


        public void Update(UserVoucher cate)
        {
            try
            {
                _dbContext.ChangeTracker.Clear();
                _dbContext.Entry<UserVoucher>(cate).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public void Create(UserVoucher cate)
        {
            try
            {
                _dbContext.UserVouchers.Add(cate);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
