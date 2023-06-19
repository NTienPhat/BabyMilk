using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IMilestonesByMonthRepository
    {
        List<MilestonesByMonth> GetMilestonesByMonth();
        void DeleteMilestonesByMonth(MilestonesByMonth cate);
        MilestonesByMonth GetMilestonesByMonthById(int id);
        void UpdateMilestonesByMonth(MilestonesByMonth cate);
        void CreateNewMilestonesByMonth(MilestonesByMonth cate);
    }
}
