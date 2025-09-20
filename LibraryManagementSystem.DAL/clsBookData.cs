using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.DAL
{
    public class clsBookData {

        // 🔹 Get Book info by ID
        public static bool GetBookInfoByID(int bookID, ref string title, ref string ISBN,
            ref int categoryID, ref int authorID, ref string edition, ref int publishedYear,
            ref string language, ref string description, ref int totalCopies, ref string shelfLocation,
            ref float dailyRate ,ref string imageName, ref DateTime dateAdded) 
        {
            try {
                using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.connectionString))
                using (SqlCommand cmd = new SqlCommand("sp_GetBookByID", conn)) {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@BookID", bookID);
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader()) {
                        if (reader.Read()) {
                            title = reader["Title"].ToString();
                            ISBN = reader["ISBN"].ToString();
                            categoryID = (int)reader["CategoryID"];
                            authorID = (int)reader["AuthorID"];
                            edition = reader["Edition"].ToString();
                            publishedYear = (int)reader["PublishedYear"];
                            language = reader["Language"].ToString();
                            description = reader["Description"].ToString();
                            totalCopies = reader["TotalCopies"] == DBNull.Value ? -1 : (int)reader["TotalCopies"];
                            shelfLocation = reader["ShelfLocation"].ToString();
                            dailyRate = Convert.ToSingle(reader["DailyRate"]);
                            imageName = reader["ImageName"] == DBNull.Value ? "" : reader["ImageName"].ToString();
                            dateAdded = reader["DateAdded"] == DBNull.Value ? DateTime.MinValue : (DateTime)reader["DateAdded"];                           

                            return true;
                        }
                    }
                }
            }catch (Exception ex) {
                Console.WriteLine("Error GetBookInfoByID: " + ex.Message);
                // LogError(ex);
                return false;
            }
            return false;
        }

        // 🔹 Get all Books
        public static DataTable GetAllBooks() {
            using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_GetAllBooks", conn)) {
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
        }

        public static DataTable GetAllBooksByCategoryID() {
            using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_GetBooksByCategoryID", conn)) {
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
        }

        // 🔹 Add new Book
        public static int AddNewBook(string title, string ISBN, int categoryID, int authorID, 
            string edition, int publishedYear, string language, string description, int totalCopies, 
            string shelfLocation, float dailyRate, string imageName) 
        {
            try {
                using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.connectionString))
                using (SqlCommand cmd = new SqlCommand("sp_AddNewBook", conn)) {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Title", title);
                    cmd.Parameters.AddWithValue("@ISBN", ISBN);
                    cmd.Parameters.AddWithValue("@CategoryID", categoryID);
                    cmd.Parameters.AddWithValue("@AuthorID", authorID);
                    cmd.Parameters.AddWithValue("@Edition", edition);
                    cmd.Parameters.AddWithValue("@PublishedYear", publishedYear);
                    cmd.Parameters.AddWithValue("@Language", language);
                    cmd.Parameters.AddWithValue("@Description", description);
                    cmd.Parameters.AddWithValue("@ShelfLocation", shelfLocation);
                    cmd.Parameters.AddWithValue("@DailyRate", dailyRate);
                    if (imageName != "" && imageName != null)
                        cmd.Parameters.AddWithValue("@ImageName", imageName);
                    else
                        cmd.Parameters.AddWithValue("@ImageName", System.DBNull.Value);

                    conn.Open();
                    var result = cmd.ExecuteScalar();
                    return result != null && int.TryParse(result.ToString(), out int id) ? id : -1;
                }
            }catch (Exception ex) {
                // Log the error
                Console.WriteLine("Error AddNewBook: " + ex.Message);
                return -1;
            }
        }

        // 🔹 Update Book
        public static bool UpdateBook(int bookID, string title, string ISBN, int categoryID, int authorID, 
            string edition, int publishedYear, string language, string description, int totalCopies, 
            string shelfLocation, float dailyRate, string imageName)  
        {
            try {
                using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.connectionString))
                using (SqlCommand cmd = new SqlCommand("sp_UpdateBook", conn)) {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@BookID", bookID);
                    cmd.Parameters.AddWithValue("@Title", title);
                    cmd.Parameters.AddWithValue("@ISBN", ISBN);
                    cmd.Parameters.AddWithValue("@CategoryID", categoryID);
                    cmd.Parameters.AddWithValue("@AuthorID", authorID);
                    cmd.Parameters.AddWithValue("@Edition", edition);
                    cmd.Parameters.AddWithValue("@PublishedYear", publishedYear);
                    cmd.Parameters.AddWithValue("@Language", language);
                    cmd.Parameters.AddWithValue("@Description", description);
                    cmd.Parameters.AddWithValue("@ShelfLocation", shelfLocation);
                    cmd.Parameters.AddWithValue("@DailyRate", dailyRate);
                    if (imageName != "" && imageName != null)
                        cmd.Parameters.AddWithValue("@ImageName", imageName);
                    else
                        cmd.Parameters.AddWithValue("@ImageName", System.DBNull.Value);

                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();

                    return rows > 0;
                }
            }catch {
                // Optionally log the error
                return false;
            }
        }

        // 🔹 Delete Book
        public static bool DeleteBook(int bookID) {
            try {
                using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.connectionString))
                using (SqlCommand cmd = new SqlCommand("sp_DeleteBook", conn)) {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@BookID", bookID);

                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();

                    return rows > 0;
                }
            }catch {
                // Optionally log the error
                return false;
            }
        }

        // 🔹 Check if Book exists
        public static bool IsBookExist(int bookID) {
            using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_IsBookExist", conn)) {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@BookID", bookID);
                var returnParameter = cmd.Parameters.Add("@RETURN_VALUE", SqlDbType.Int);
                returnParameter.Direction = ParameterDirection.ReturnValue;

                conn.Open();
                cmd.ExecuteNonQuery();

                return (int)returnParameter.Value == 1;
            }
        }


    }
}
