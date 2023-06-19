using BusinessObject.Models;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class MilestonesByMonthRepository : IMilestonesByMonthRepository
    {
        public void CreateNewMilestonesByMonth(MilestonesByMonth cate) => MilestonesByMonthDAO.Instance.CreateNewMilestonesByMonth(cate);

        public void DeleteMilestonesByMonth(MilestonesByMonth cate) => MilestonesByMonthDAO.Instance.DeleteMilestonesByMonth(cate);

        public MilestonesByMonth GetMilestonesByMonthById(int id) => MilestonesByMonthDAO.Instance.GetMilestonesByMonthById(id);

        public List<MilestonesByMonth> GetMilestonesByMonth() => MilestonesByMonthDAO.Instance.GetMilestonesByMonth();

        public void UpdateMilestonesByMonth(MilestonesByMonth cate) => MilestonesByMonthDAO.Instance.UpdateMilestonesByMontht(cate);
    }
}
