using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class MilestonesByMonthDAO
    {
        private static MilestonesByMonthDAO instance = null;
        private static readonly object instanceLock = new object();
        BabyMilkV2Context _dbContext = new BabyMilkV2Context();
        public MilestonesByMonthDAO()
        {

        }
        public static MilestonesByMonthDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new MilestonesByMonthDAO();
                    }
                    return instance;
                }
            }
        }
        public List<MilestonesByMonth> GetMilestonesByMonth()
        {
            try
            {
                var candate = _dbContext.MilestonesByMonths.ToList();
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
        public void DeleteMilestonesByMonth(MilestonesByMonth cate)
        {
            try
            {
                _dbContext.ChangeTracker.Clear();
                _dbContext.MilestonesByMonths.Remove(cate);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public MilestonesByMonth GetMilestonesByMonthById(int id)
        {
            try
            {
                var ca = _dbContext.MilestonesByMonths.FirstOrDefault(x => x.MilestonesByMonthId == id);
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
        public void UpdateMilestonesByMontht(MilestonesByMonth cate)
        {
            try
            {
                _dbContext.ChangeTracker.Clear();
                _dbContext.Entry<MilestonesByMonth>(cate).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public void CreateNewMilestonesByMonth(MilestonesByMonth pro)
        {
            try
            {
                _dbContext.ChangeTracker.Clear();
                _dbContext.MilestonesByMonths.Add(pro);
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
