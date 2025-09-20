using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.DAL
{
    public class clsMemberData {

        // 🔹 Get member info by ID
        public static bool GetMemberInfoByID(int memberID, ref int personID, ref DateTime dateJoined)  {
            try {
                using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.connectionString))
                using (SqlCommand cmd = new SqlCommand("sp_GetMemberByID", conn)) {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MemberID", memberID);
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader()) {
                        if (reader.Read()) {
                            personID = (int)reader["PersonID"];
                            dateJoined = reader["DateJoined"] == DBNull.Value ? DateTime.MinValue : (DateTime)reader["DateJoined"];                           

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

        public static bool GetMemberInfoByPersonID(ref int memberID, int personID, ref DateTime dateJoined)  {
            try {
                using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.connectionString))
                using (SqlCommand cmd = new SqlCommand("sp_GetMemberByPersonID", conn)) {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PersonID", personID);
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader()) {
                        if (reader.Read()) {
                            memberID = (int)reader["MemberID"];
                            personID = (int)reader["PersonID"];
                            dateJoined = reader["DateJoined"] == DBNull.Value ? DateTime.MinValue : (DateTime)reader["DateJoined"];                           

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

        // 🔹 Get all members
        public static DataTable GetAllMembers() {
            using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_GetAllMembers", conn)) {
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
        }

        // 🔹 Add new member
        public static int AddNewMember(int personID) {
            try {
                using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.connectionString))
                using (SqlCommand cmd = new SqlCommand("sp_AddNewMember", conn)) {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@PersonID", personID);

                    conn.Open();
                    var result = cmd.ExecuteScalar();
                    return result != null && int.TryParse(result.ToString(), out int id) ? id : -1;
                }
            }catch {
                // Log the error
                return -1;
            }
        }

        // 🔹 Update member
        //public static bool UpdateMember(int memberID, int personID)  {
        //    try {
        //        using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.connectionString))
        //        using (SqlCommand cmd = new SqlCommand("sp_UpdateMember", conn)) {
        //            cmd.CommandType = CommandType.StoredProcedure;

        //            cmd.Parameters.AddWithValue("@MemberID", memberID);
        //            cmd.Parameters.AddWithValue("@PersonID", personID);

        //            conn.Open();
        //            int rows = cmd.ExecuteNonQuery();

        //            return rows > 0;
        //        }
        //    }catch {
        //        // Optionally log the error
        //        return false;
        //    }
        //}

        // 🔹 Delete member
        public static bool DeleteMember(int memberID) {
            try {
                using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.connectionString))
                using (SqlCommand cmd = new SqlCommand("sp_DeleteMember", conn)) {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MemberID", memberID);

                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();

                    return rows > 0;
                }
            }catch {
                // Optionally log the error
                return false;
            }
        }

        // 🔹 Check if member exists
        public static bool IsMemberExist(int memberID) {
            using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_IsMemberExist", conn)) {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@MemberID", memberID);
                var returnParameter = cmd.Parameters.Add("@RETURN_VALUE", SqlDbType.Int);
                returnParameter.Direction = ParameterDirection.ReturnValue;

                conn.Open();
                cmd.ExecuteNonQuery();

                return (int)returnParameter.Value == 1;
            }
        }


    }
}
