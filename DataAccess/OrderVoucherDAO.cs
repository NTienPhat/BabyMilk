using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class OrderVoucherDAO
    {
        private static OrderVoucherDAO instance = null;
        private static readonly object instanceLock = new object();
        BabyMilkContext _dbContext = new BabyMilkContext();
        public OrderVoucherDAO()
        {

        }
        public static OrderVoucherDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new OrderVoucherDAO();
                    }
                    return instance;
                }
            }
        }
        public List<OrderVoucher> Get()
        {
            try
            {
                var candate = _dbContext.OrderVouchers.ToList();
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


        public void Delete(OrderVoucher cate)
        {
            try
            {
                _dbContext.OrderVouchers.Remove(cate);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public OrderVoucher GetById(int id)
        {
            try
            {
                var ca = _dbContext.OrderVouchers.FirstOrDefault(x => x.ProductVoucherId == id);
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


        public void Update(OrderVoucher cate)
        {
            try
            {
                _dbContext.ChangeTracker.Clear();
                _dbContext.Entry<OrderVoucher>(cate).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public void Create(OrderVoucher cate)
        {
            try
            {
                _dbContext.OrderVouchers.Add(cate);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
