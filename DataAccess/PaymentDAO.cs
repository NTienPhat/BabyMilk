using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class PaymentDAO
    {
        private static PaymentDAO instance = null;
        private static readonly object instanceLock = new object();
        BabyMilkV2Context _dbContext = new BabyMilkV2Context();
        public PaymentDAO()
        {

        }
        public static PaymentDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new PaymentDAO();
                    }
                    return instance;
                }
            }
        }
        public List<Payment> Get()
        {
            try
            {
                var candate = _dbContext.Payments.ToList();
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


        public void Delete(Payment cate)
        {
            try
            {
                _dbContext.Payments.Remove(cate);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public Payment GetById(int id)
        {
            try
            {
                var ca = _dbContext.Payments.FirstOrDefault(x => x.PaymentId == id);
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

        public List<Payment> GetByUser(int id)
        {
            try
            {
                var ca = _dbContext.Payments.Where(x => x.AccountId == id).ToList();
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


        public void Update(Payment cate)
        {
            try
            {
                _dbContext.ChangeTracker.Clear();
                _dbContext.Entry<Payment>(cate).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public void Create(Payment cate)
        {
            try
            {
                _dbContext.Payments.Add(cate);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}

