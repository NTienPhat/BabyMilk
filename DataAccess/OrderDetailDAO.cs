using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class OrderDetailDAO
    {
        private static OrderDetailDAO instance = null;
        private static readonly object instanceLock = new object();
        BabyMilkV2Context _dbContext = new BabyMilkV2Context();
        public OrderDetailDAO()
        {

        }
        public static OrderDetailDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new OrderDetailDAO();
                    }
                    return instance;
                }
            }
        }
        public List<OrderDetail> Get()
        {
            try
            {
                using (var _dbContext = new BabyMilkV2Context())
                {
                    var candate = _dbContext.OrderDetails.Include(x => x.Product).ToList();
                    if (candate != null)
                    {
                        return candate;
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public List<OrderDetail> GetByOrderId(int id)
        {
            try
            {
                using (var _dbContext = new BabyMilkV2Context())
                {
                    List<OrderDetail> candate = _dbContext.OrderDetails.Where(x => x.OrderId == id).Include(x => x.Product).ToList();
                    if (candate != null)
                    {
                        return candate;
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }


        public void Delete(OrderDetail cate)
        {
            try
            {
                _dbContext.OrderDetails.Remove(cate);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public OrderDetail GetById(int id)
        {
            try
            {
                using (var _dbContext = new BabyMilkV2Context())
                {
                    var ca = _dbContext.OrderDetails.FirstOrDefault(x => x.OrderDetailsId == id);
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


        public void Update(OrderDetail cate)
        {
            try
            {
                _dbContext.ChangeTracker.Clear();
                _dbContext.Entry<OrderDetail>(cate).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public void Create(OrderDetail cate)
        {
            try
            {
                using (var _dbContext = new BabyMilkV2Context())
                {
                    var pro = _dbContext.Products.FirstOrDefault(x => x.ProductId == cate.ProductId);
                    if (pro != null)
                    {
                        if (pro.Quantity > cate.Quantity)
                        {
                            _dbContext.OrderDetails.Add(cate);
                            _dbContext.SaveChanges();
                            pro.Quantity = pro.Quantity - cate.Quantity;
                            _dbContext.Products.Update(pro);
                            _dbContext.SaveChanges();
                        }
                        else
                        {
                            throw new Exception("Product quantity is not enough");
                        }
                    }
                    else
                    {
                        throw new Exception("Product is null");
                    }

                }



            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}

