using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class VoucherDAO
    {
        private static VoucherDAO instance = null;
        private static readonly object instanceLock = new object();
        BabyMilkV2Context _dbContext = new BabyMilkV2Context();
        public VoucherDAO()
        {

        }
        public static VoucherDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new VoucherDAO();
                    }
                    return instance;
                }
            }
        }
        public List<Voucher> Get()
        {
            try
            {
                var candate = _dbContext.Vouchers.ToList();
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


        public void Delete(Voucher cate)
        {
            try
            {
                _dbContext.Vouchers.Remove(cate);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public Voucher GetById(int id)
        {
            try
            {
                var ca = _dbContext.Vouchers.FirstOrDefault(x => x.VoucherId == id);
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


        public void Update(Voucher cate)
        {
            try
            {
                _dbContext.ChangeTracker.Clear();
                _dbContext.Entry<Voucher>(cate).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public void Create(Voucher cate)
        {
            try
            {
                _dbContext.Vouchers.Add(cate);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
