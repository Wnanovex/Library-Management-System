using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.DAL
{
    public class clsFineData {

        // 🔹 Get Fine info by ID
        public static bool GetFineInfoByID(int fineID, ref int issueID, ref float amount, ref bool paid, ref DateTime datePaid)  {
            try {
                using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.connectionString))
                using (SqlCommand cmd = new SqlCommand("sp_GetFineByID", conn)) {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FineID", fineID);
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader()) {
                        if (reader.Read()) {
                            issueID = (int)reader["IssueID"];
                            amount = Convert.ToSingle(reader["Amount"]);
                            paid = Convert.ToBoolean(reader["Paid"]);
                            datePaid = reader["DatePaid"] == DBNull.Value ? DateTime.MinValue : (DateTime)reader["DatePaid"];                           

                            return true;
                        }
                    }
                }
            }catch (Exception ex) {
                // Consider logging the exception
                // LogError(ex);
                return false;
            }
            return false;
        }

        public static bool GetFineByIssueID(ref int fineID, int issueID, ref float amount, ref bool paid, ref DateTime datePaid)  {
            try {
                using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.connectionString))
                using (SqlCommand cmd = new SqlCommand("sp_GetFineByIssueID", conn)) {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IssueID", issueID);
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader()) {
                        if (reader.Read()) {
                            fineID = (int)reader["FineID"];
                            amount = Convert.ToSingle(reader["Amount"]);
                            paid = Convert.ToBoolean(reader["Paid"]);
                            datePaid = reader["DatePaid"] == DBNull.Value ? DateTime.MinValue : (DateTime)reader["DatePaid"];                           

                            return true;
                        }
                    }
                }
            }catch (Exception ex) {
                // Consider logging the exception
                // LogError(ex);
                return false;
            }
            return false;
        }

        // 🔹 Get all Fines
        public static DataTable GetAllFines() {
            using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_GetAllFines", conn)) {
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
        }

        // 🔹 Add new Fine
        public static int AddNewFine(int issueID) {
            try {
                using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.connectionString))
                using (SqlCommand cmd = new SqlCommand("sp_AddNewFine", conn)) {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IssueID", issueID);

                    conn.Open();
                    var result = cmd.ExecuteScalar();
                    return result != null && int.TryParse(result.ToString(), out int id) ? id : -1;
                }
            }catch {
                // Log the error
                return -1;
            }
        }

        // 🔹 Update Fine
        //public static bool UpdateFine(int fineID, float amount, bool paid, DateTime datePaid) {
        //    try {
        //        using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.connectionString))
        //        using (SqlCommand cmd = new SqlCommand("sp_UpdateFine", conn)) {
        //            cmd.CommandType = CommandType.StoredProcedure;

        //            cmd.Parameters.AddWithValue("@FineID", fineID);
        //            cmd.Parameters.AddWithValue("@Amount", amount);
        //            cmd.Parameters.AddWithValue("@Paid", paid);
        //            cmd.Parameters.AddWithValue("@DatePaid", datePaid);

        //            conn.Open();
        //            int rows = cmd.ExecuteNonQuery();

        //            return rows > 0;
        //        }
        //    }catch {
        //        // Optionally log the error
        //        return false;
        //    }
        //}

        public static bool PayFine(int fineID) {
            try {
                using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.connectionString))
                using (SqlCommand cmd = new SqlCommand("sp_PayFine", conn)) {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@FineID", fineID);

                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();

                    return rows > 0;
                }
            }catch {
                // Optionally log the error
                return false;
            }
        }

        // 🔹 Delete Fine
        public static bool DeleteFine(int fineID) {
            try {
                using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.connectionString))
                using (SqlCommand cmd = new SqlCommand("sp_DeleteFine", conn)) {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FineID", fineID);

                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();

                    return rows > 0;
                }
            }catch {
                // Optionally log the error
                return false;
            }
        }



    }
}
