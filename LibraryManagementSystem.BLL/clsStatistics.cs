using LibraryManagementSystem.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.BLL
{
    public class clsStatistics {

        public static (int TotalBooks, int TotalBookCopies, int TotalMembers, int TotalIssuedBooks) GetDashboardCounts() {
            return clsStatisticsData.GetDashboardCounts();
        }

        public static (int TotalBooksToday, int TotalMembersToday, int TotalIssuedToday) GetDailyCounts() {
            return clsStatisticsData.GetDailyDashboardCounts();
        }

    }
}
