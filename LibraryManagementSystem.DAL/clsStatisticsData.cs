using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.DAL
{
    public class clsStatisticsData {

        public static (int TotalBooks, int TotalBookCopies, int TotalMembers, int TotalIssuedBooks) GetDashboardCounts() {
            int books = 0, copies = 0, members = 0, issued = 0;

            using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_GetDashboardCounts", conn)) {
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader()) {
                    if (reader.Read()) {
                        books = (int)reader["TotalBooks"];
                        copies = (int)reader["TotalBookCopies"];
                        members = (int)reader["TotalMembers"];
                        issued = (int)reader["TotalIssuedBooks"];
                    }
                }
            }
            return (books, copies, members, issued);
        }

        public static (int TotalBooksToday, int TotalMembersToday, int TotalIssuedToday) GetDailyDashboardCounts() {
            int books = 0, members = 0, issued = 0;

            using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_GetDailyDashboardCounts", conn)) {
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        books = (int)reader["TotalBooksToday"];
                        members = (int)reader["TotalMembersToday"];
                        issued = (int)reader["TotalIssuedToday"];
                    }
                }
            }

            return (books, members, issued);
        }

    }
}
