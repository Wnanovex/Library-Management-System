using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace LibraryManagementSystem.DAL
{
    public class clsUserData {

         // 🔹 Get user info by ID
        public static bool GetUserInfoByID(int userID, ref int personID, ref string username,
            ref string password, ref byte role, ref DateTime lastLogin, ref bool isActive) 
        {
            try {
                using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.connectionString))
                using (SqlCommand cmd = new SqlCommand("sp_GetUserByID", conn)) {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserID", userID);
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader()) {
                        if (reader.Read()) {
                            personID = (int)reader["PersonID"];
                            username = reader["Username"].ToString();
                            password = reader["Password"].ToString();
                            role = Convert.ToByte(reader["Role"]);
                            lastLogin = reader["LastLogin"] == DBNull.Value ? DateTime.MinValue : (DateTime)reader["LastLogin"];                           
                            isActive = Convert.ToBoolean(reader["IsActive"]);

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

        public static bool GetUserInfoByPersonID(ref int userID, int personID, ref string username,
            ref string password, ref byte role, ref DateTime lastLogin, ref bool isActive) 
        {
            try {
                using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.connectionString))
                using (SqlCommand cmd = new SqlCommand("sp_GetUserByPersonID", conn)) {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PersonID", personID);
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader()) {
                        if (reader.Read()) {
                            userID = (int)reader["UserID"];
                            username = reader["Username"].ToString();
                            password = reader["Password"].ToString();
                            role = Convert.ToByte(reader["Role"]);
                            lastLogin = reader["LastLogin"] == DBNull.Value ? DateTime.MinValue : (DateTime)reader["LastLogin"];                           
                            isActive = Convert.ToBoolean(reader["IsActive"]);

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

        public static bool GetUserInfoByUsernameAndPassword(ref int userID, ref int personID, string username,
            string password, ref byte role, ref DateTime lastLogin, ref bool isActive) 
        {
            try {
                using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.connectionString))
                using (SqlCommand cmd = new SqlCommand("sp_GetUserByUsernameAndPassword", conn)) {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader()) {
                        if (reader.Read()) {
                            userID = (int)reader["UserID"];
                            personID = (int)reader["PersonID"];
                            username = reader["Username"].ToString();
                            password = reader["Password"].ToString();
                            role = Convert.ToByte(reader["Role"]);
                            lastLogin = reader["LastLogin"] == DBNull.Value ? DateTime.MinValue : (DateTime)reader["LastLogin"];                           
                            isActive = Convert.ToBoolean(reader["IsActive"]);

                            return true;
                        }
                    }
                }
            }catch (Exception ex) {
                // Consider logging the exception
                //LogError(ex);
                Console.WriteLine("Error GetUserInfoByUsernameAndPassword: " + ex.Message);
                return false;
            }
            return false;
        }


        // 🔹 Get all Users
        public static DataTable GetAllUsers() {
            using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_GetAllUsers", conn)) {
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
        }

        // 🔹 Add new User
        public static int AddNewUser(int personID, string username, string password, byte role,bool isActive) {
            try {
                using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.connectionString))
                using (SqlCommand cmd = new SqlCommand("sp_AddNewUser", conn)) {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@PersonID", personID);
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);
                    cmd.Parameters.AddWithValue("@Role", role);
                    cmd.Parameters.AddWithValue("@IsActive", isActive);

                    conn.Open();
                    var result = cmd.ExecuteScalar();
                    return result != null && int.TryParse(result.ToString(), out int id) ? id : -1;
                }
            }catch {
                // Log the error
                return -1;
            }
        }

        // 🔹 Update User
        public static bool UpdateUser(int userID, string username, string password, byte role,bool isActive)  {
            try {
                using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.connectionString))
                using (SqlCommand cmd = new SqlCommand("sp_UpdateUser", conn)) {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UserID", userID);
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);
                    cmd.Parameters.AddWithValue("@Role", role);
                    cmd.Parameters.AddWithValue("@IsActive", isActive);

                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();

                    return rows > 0;
                }
            }catch {
                // Optionally log the error
                return false;
            }
        }

        public static bool ChangePassword(int userID, string password)  {
            try {
                using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.connectionString))
                using (SqlCommand cmd = new SqlCommand("sp_ChangePassword", conn)) {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UserID", userID);
                    cmd.Parameters.AddWithValue("@Password", password);

                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();

                    return rows > 0;
                }
            }catch {
                // Optionally log the error
                return false;
            }
        }

        // 🔹 Delete User
        public static bool DeleteUser(int userID) {
            try {
                using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.connectionString))
                using (SqlCommand cmd = new SqlCommand("sp_DeleteUser", conn)) {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserID", userID);

                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();

                    return rows > 0;
                }
            }catch {
                // Optionally log the error
                return false;
            }
        }

        // 🔹 Check if User exists
        public static bool IsUserExist(int userID) {
            using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_IsUserExist", conn)) {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@UserID", userID);
                var returnParameter = cmd.Parameters.Add("@RETURN_VALUE", SqlDbType.Int);
                returnParameter.Direction = ParameterDirection.ReturnValue;

                conn.Open();
                cmd.ExecuteNonQuery();

                return (int)returnParameter.Value == 1;
            }
        }

    }
}
