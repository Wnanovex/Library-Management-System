using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.DAL
{
    public class clsCategoryData {

        // 🔹 Get category info by ID
        public static bool GetCategoryInfoByID(int categoryID, ref string name, ref string description)  {
            try {
                using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.connectionString))
                using (SqlCommand cmd = new SqlCommand("sp_GetCategoryByID", conn)) {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CategoryID", categoryID);
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader()) {
                        if (reader.Read()) {
                            name = reader["Name"].ToString();
                            description = reader["Description"].ToString();

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

        public static bool GetCategoryInfoByName(ref int categoryID, string name, ref string description) {
            try {
                using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.connectionString))
                using (SqlCommand cmd = new SqlCommand("sp_GetCategoryByName", conn)) {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Name", name);
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader()) {
                        if (reader.Read()) {
                            categoryID = (int)reader["CategoryID"];
                            name = reader["Name"].ToString();
                            description = reader["Description"].ToString();

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

        // 🔹 Get all Categories
        public static DataTable GetAllCategories() {
            using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_GetAllCategories", conn)) {
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
        }

        // 🔹 Add new Category
        public static int AddNewCategory(string name, string description) {
            try {
                using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.connectionString))
                using (SqlCommand cmd = new SqlCommand("sp_AddNewCategory", conn)) {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Description", description);

                    conn.Open();
                    var result = cmd.ExecuteScalar();
                    return result != null && int.TryParse(result.ToString(), out int id) ? id : -1;
                }
            }catch {
                // Log the error
                return -1;
            }
        }

        // 🔹 Update Author
        public static bool UpdateCategory(int categoryID, string name, string description)  {
            try {
                using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.connectionString))
                using (SqlCommand cmd = new SqlCommand("sp_UpdateCategory", conn)) {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@CategoryID", categoryID);
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Description", description);

                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();

                    return rows > 0;
                }
            }catch {
                // Optionally log the error
                return false;
            }
        }

        // 🔹 Delete Category
        public static bool DeleteCategory(int categoryID) {
            try {
                using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.connectionString))
                using (SqlCommand cmd = new SqlCommand("sp_DeleteCategory", conn)) {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CategoryID", categoryID);

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
