using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.DAL
{
    public class clsIssuedBookData {

        // 🔹 Get IssuedIssuedBook info by ID
        public static bool GetIssuedBookInfoByID(int issueID, ref int copyID, ref int memberID,
            ref int issuedBy, ref DateTime issueDate, ref DateTime dueDate, ref DateTime returnDate,
            ref bool isReturned) 
        {
            try {
                using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.connectionString))
                using (SqlCommand cmd = new SqlCommand("sp_GetIssuedBookByID", conn)) {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IssueID", issueID);
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader()) {
                        if (reader.Read()) {
                            copyID = (int)reader["CopyID"];
                            memberID = (int)reader["MemberID"];
                            issuedBy = (int)reader["IssuedBy"];
                            issueDate = reader["IssueDate"] == DBNull.Value ? DateTime.MinValue : (DateTime)reader["IssueDate"];
                            dueDate = reader["DueDate"] == DBNull.Value ? DateTime.MinValue : (DateTime)reader["DueDate"];
                            returnDate = reader["ReturnDate"] == DBNull.Value ? DateTime.MinValue : (DateTime)reader["ReturnDate"];
                            isReturned = Convert.ToBoolean(reader["IsReturned"]);

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

        // 🔹 Get all IssuedBooks
        public static DataTable GetAllIssuedBooks() {
            using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_GetAllIssuedBooks", conn)) {
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
        }

        // 🔹 Add new IssuedBook
        public static int AddNewIssuedBook(int copyID, int memberID, int issuedBy, DateTime dueDate)  {
            try {
                using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.connectionString))
                using (SqlCommand cmd = new SqlCommand("sp_AddNewIssuedBook", conn)) {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@CopyID", copyID);
                    cmd.Parameters.AddWithValue("@MemberID", memberID);
                    cmd.Parameters.AddWithValue("@IssuedBy", issuedBy);
                    cmd.Parameters.AddWithValue("@DueDate", dueDate);

                    conn.Open();
                    var result = cmd.ExecuteScalar();
                    return result != null && int.TryParse(result.ToString(), out int id) ? id : -1;
                }
            }catch (Exception ex) {
                // Log the error
                Console.WriteLine("Error AddNewIssuedBook: " + ex.Message);
                return -1;
            }
        }

        // 🔹 Update IssuedBook
        public static bool UpdateIssuedBook(int issueID, int copyID, int memberID, DateTime dueDate, DateTime returnDate, bool isReturned) {
            try {
                using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.connectionString))
                using (SqlCommand cmd = new SqlCommand("sp_UpdateIssuedBook", conn)) {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IssueID", issueID);
                    cmd.Parameters.AddWithValue("@CopyID", copyID);
                    cmd.Parameters.AddWithValue("@MemberID", memberID);
                    cmd.Parameters.AddWithValue("@DueDate", dueDate);
                    
                    if (returnDate != DateTime.MinValue)
                        cmd.Parameters.AddWithValue("@ReturnDate", returnDate);
                    else
                        cmd.Parameters.AddWithValue("@ReturnDate", System.DBNull.Value);

                    cmd.Parameters.AddWithValue("@IsReturned", isReturned);

                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();

                    return rows > 0;
                } 
            }catch (Exception ex) {
                // Log the error
                Console.WriteLine("Error UpdateIssuedBook: " + ex.Message);
                return false;
            }
        }

        // 🔹 Delete IssuedBook
        public static bool DeleteIssuedBook(int issueID) {
            try {
                using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.connectionString))
                using (SqlCommand cmd = new SqlCommand("sp_DeleteIssuedBook", conn)) {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IssueID", issueID);

                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();

                    return rows > 0;
                }
            }catch {
                // Optionally log the error
                return false;
            }
        }


        public static bool MarkBookAsReturned(int issueID, DateTime? returnDate = null) {
            try {
                using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.connectionString))
                using (SqlCommand cmd = new SqlCommand("sp_MarkBookAsReturned", conn)) {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IssueID", issueID);

                    if (returnDate.HasValue)
                        cmd.Parameters.AddWithValue("@ReturnDate", returnDate.Value);
                    else
                        cmd.Parameters.AddWithValue("@ReturnDate", DBNull.Value);

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }catch (Exception ex) {
                // Log the error if needed
                Console.WriteLine("Error in MarkBookAsReturned: " + ex.Message);
                return false;
            }
        }

        public static bool IsBookReturned(int issueID) {
            using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_IsBookReturned", conn)) {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@IssueID", issueID);
                var returnParameter = cmd.Parameters.Add("@RETURN_VALUE", SqlDbType.Int);
                returnParameter.Direction = ParameterDirection.ReturnValue;

                conn.Open();
                cmd.ExecuteNonQuery();

                return (int)returnParameter.Value == 1;
            }
        }

    }
}
