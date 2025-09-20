using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace LibraryManagementSystem.DAL {
    public class clsPersonData {

        // 🔹 Get person by ID
        public static bool GetPersonInfoByID(int personID,
            ref string firstName, ref string lastName, ref DateTime DateOfBirth,
            ref string gender, ref string email, ref string phone,
            ref string address, ref string city, ref DateTime createdAt, ref DateTime updatedAt) 
        {
            try {
                using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.connectionString))
                using (SqlCommand cmd = new SqlCommand("sp_GetPersonByID", conn)) {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PersonID", personID);
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader()) {
                        if (reader.Read()) {
                            firstName = reader["FirstName"].ToString();
                            lastName = reader["LastName"].ToString();
                            DateOfBirth = reader["DateOfBirth"] == DBNull.Value ? DateTime.MinValue : (DateTime)reader["DateOfBirth"];
                            gender = reader["Gender"] == DBNull.Value ? null : reader["Gender"].ToString();
                            email = reader["Email"] == DBNull.Value ? null : reader["Email"].ToString();
                            phone = reader["Phone"] == DBNull.Value ? null : reader["Phone"].ToString();
                            address = reader["Address"] == DBNull.Value ? null : reader["Address"].ToString();
                            city = reader["City"] == DBNull.Value ? null : reader["City"].ToString();
                            createdAt = reader["CreatedAt"] == DBNull.Value ? DateTime.MinValue : (DateTime)reader["CreatedAt"];
                            updatedAt = reader["UpdatedAt"] == DBNull.Value ? DateTime.MinValue : (DateTime)reader["UpdatedAt"];

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


        // 🔹 Get all people
        public static DataTable GetAllPeople() {
            using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_GetAllPeople", conn)) {
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
        }

        // 🔹 Add new person
        public static int AddNewPerson(string firstName, string lastName, DateTime? dateOfBirth,
               string gender, string email, string phone, string address, string city)
        {
            try {
                using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.connectionString))
                using (SqlCommand cmd = new SqlCommand("sp_AddNewPerson", conn)) {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@FirstName", firstName);
                    cmd.Parameters.AddWithValue("@LastName", lastName);
                    cmd.Parameters.AddWithValue("@DateOfBirth", (object)dateOfBirth ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Gender", (object)gender ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Email", (object)email ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Phone", (object)phone ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Address", (object)address ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@City", (object)city ?? DBNull.Value);

                    conn.Open();
                    var result = cmd.ExecuteScalar();
                    return result != null && int.TryParse(result.ToString(), out int id) ? id : -1;
                }
            }catch {
                // Log the error
                return -1;
            }
        }

        // 🔹 Update person
        public static bool UpdatePerson(int personID, string firstName, string lastName, DateTime? dateOfBirth,
               string gender, string email, string phone, string address, string city)
        {
            try {
                using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.connectionString))
                using (SqlCommand cmd = new SqlCommand("sp_UpdatePerson", conn)) {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@PersonID", personID);
                    cmd.Parameters.AddWithValue("@FirstName", firstName);
                    cmd.Parameters.AddWithValue("@LastName", lastName);
                    cmd.Parameters.AddWithValue("@DateOfBirth", (object)dateOfBirth ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Gender", (object)gender ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Email", (object)email ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Phone", (object)phone ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Address", (object)address ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@City", (object)city ?? DBNull.Value);

                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();

                    return rows > 0;
                }
            }catch {
                // Optionally log the error
                return false;
            }
        }

        // 🔹 Delete person
        public static bool DeletePerson(int personID) {
            try {
                using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.connectionString))
                using (SqlCommand cmd = new SqlCommand("sp_DeletePerson", conn)) {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PersonID", personID);

                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();

                    return rows > 0;
                }
            }catch {
                // Optionally log the error
                return false;
            }
        }

        // 🔹 Check if person exists
        public static bool IsPersonExist(int personID) {
            using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_IsPersonExist", conn)) {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@PersonID", personID);
                var returnParameter = cmd.Parameters.Add("@RETURN_VALUE", SqlDbType.Int);
                returnParameter.Direction = ParameterDirection.ReturnValue;

                conn.Open();
                cmd.ExecuteNonQuery();

                return (int)returnParameter.Value == 1;
            }
        }

    }
}
