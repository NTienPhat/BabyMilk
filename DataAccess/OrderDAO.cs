using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class OrderDAO
    {
        private static OrderDAO instance = null;
        private static readonly object instanceLock = new object();
        BabyMilkV2Context _dbContext = new BabyMilkV2Context();
        public OrderDAO()
        {

        }
        public static OrderDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new OrderDAO();
                    }
                    return instance;
                }
            }
        }
        public List<Order> GetOrder()
        {
            try
            {
                var candate = _dbContext.Orders
                    .Include(y => y.OrderDetails)
                    .Include(y => y.Payments)
                    .ToList();
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
        public void DeleteOrder(Order cate)
        {
            try
            {
                
                List<OrderDetail> orderDetails = _dbContext.OrderDetails.Where(x => x.OrderId == cate.OrderId).ToList();
                if(orderDetails.Count > 0)
                {
                    foreach(var item in orderDetails)
                    {
                        _dbContext.OrderDetails.Remove(item);
                    }
                    _dbContext.SaveChanges();
                }
                //Payment pay = _dbContext.Payments.FirstOrDefault(x => x.OrderId == cate.OrderId);
                //if (pay != null)
                //{
                //    _dbContext.ChangeTracker.Clear();
                //    _dbContext.Payments.Remove(pay);
                //    _dbContext.ChangeTracker.Clear();
                //}
                _dbContext.ChangeTracker.Clear();
                _dbContext.Payments.RemoveRange(cate.Payments);
                _dbContext.SaveChanges();
                _dbContext.Orders.Remove(cate);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public Order GetOrderById(int id)
        {
            try
            {
                var ca = _dbContext.Orders.Include(x => x.OrderDetails)
                    .Include(x => x.Payments).FirstOrDefault(x => x.OrderId == id);
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

        public List<Order> GetOrderByAccountId(int id)
        {
            try
            {
                using (var _dbContext = new BabyMilkV2Context())
                {
                    var ca = _dbContext.Orders.Where(x => x.AccountId == id).Include(x => x.OrderDetails).ToList();
                    if (ca != null)
                    {
                        return ca;
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void UpdateOder(Order cate)
        {
            try
            {
                _dbContext.ChangeTracker.Clear();
                _dbContext.Entry<Order>(cate).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public void CreateNewOrder(Order pro)
        {
            try
            {
                _dbContext.ChangeTracker.Clear();
                pro.OrderDate = DateTime.Now;
                pro.OrderStatus = "Pending";
                _dbContext.Orders.Add(pro);
                _dbContext.SaveChanges();
                _dbContext.Entry(pro).State = EntityState.Detached;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
