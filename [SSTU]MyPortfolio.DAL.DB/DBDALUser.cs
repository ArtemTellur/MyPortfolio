using _SSTU_MyPortfolio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _SSTU_MyPortfolio.Entities;
using System.Configuration;
using System.Data.SqlClient;

namespace _SSTU_MyPortfolio.DAL.DB
{
    public class DBDALUser : IMyPortfolioDALUser
    {
        private string connectionString;

        public DBDALUser()
        {
            connectionString = ConfigurationManager.ConnectionStrings["MyPortfolioDB"].ConnectionString;
        }

        public void Add(User user)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string com = "INSERT INTO [MyPortfolioDB].[dbo].[User] (userName, birthdate, about, email, password, isAdmin, PhotoId) VALUES (@userName, @birthdate, @about, @email, @password, @isAdmin, @PhotoId)";
                SqlCommand command = new SqlCommand(com, connection);
                command.Parameters.AddWithValue("@userName", user.UserName);
                command.Parameters.AddWithValue("@birthdate", user.Birthdate);
                command.Parameters.AddWithValue("@about", user.About ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@email", user.Email);
                command.Parameters.AddWithValue("@password", user.Password);
                command.Parameters.AddWithValue("@isAdmin", user.IsAdmin);
                command.Parameters.AddWithValue("@PhotoId", user.PictureId);
                connection.Open();
                var query = command.ExecuteNonQuery();
                connection.Close();
            }
        }
        public void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string com = "DELETE FROM [MyPortfolioDB].[dbo].[User] WHERE userId=@userId";
                SqlCommand command = new SqlCommand(com, connection);
                command.Parameters.AddWithValue("@userId", id);
                connection.Open();
                var query = command.ExecuteNonQuery() == 1;
                connection.Close();
            }
        }
        public IEnumerable<User> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string com = "SELECT userId, userName, birthdate, about, email, password, isAdmin, PhotoId FROM [MyPortfolioDB].[dbo].[User]";
                SqlCommand command = new SqlCommand(com, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    yield return new User(int.Parse(reader["userId"].ToString()), reader["userName"].ToString(), DateTime.Parse(reader["birthdate"].ToString()), reader["about"].ToString(), reader["email"].ToString(), reader["password"].ToString(), int.Parse(reader["isAdmin"].ToString()), (int)reader["PhotoId"]);
                }
            }
        }

        public User GetById(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string com = $"SELECT userId, userName, birthdate, about, email, password, isAdmin, PhotoId FROM [MyPortfolioDB].[dbo].[User] WHERE userId={id}";
                SqlCommand command = new SqlCommand(com, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    return new User ((int)reader["userId"], reader["userName"].ToString(), DateTime.Parse(reader["birthdate"].ToString()), reader["about"].ToString(), reader["email"].ToString(), reader["password"].ToString(), int.Parse(reader["isAdmin"].ToString()), (int)reader["PhotoId"]);
                }
                return null;
            }
        }

        public User GetByEmail(string email)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string com = $"SELECT userId, userName, birthdate, about, email, password, isAdmin, PhotoId FROM [MyPortfolioDB].[dbo].[User] WHERE email='{email}'";
                SqlCommand command = new SqlCommand(com, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    return new User(int.Parse(reader["userId"].ToString()), reader["userName"].ToString(), DateTime.Parse(reader["birthdate"].ToString()), reader["about"].ToString(), reader["email"].ToString(), reader["password"].ToString(), int.Parse(reader["isAdmin"].ToString()), (int)reader["PhotoId"]);
                }
                return null;
            }
        }

        public bool Update(User user)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand com = new SqlCommand($"UPDATE [dbo].[User] SET [userName]='{user.UserName}', [birthdate]='{user.Birthdate}', [about]='{user.About}', [email]='{user.Email}', [password]='{user.Password}', [isAdmin]='{user.IsAdmin}', [PhotoId]='{user.PictureId}' where [userId]='{user.UserId}'", con);
                con.Open();
                return com.ExecuteNonQuery() == 1;
            }
        }

        public bool Login(User user)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string com = $"SELECT email, password FROM [MyPortfolioDB].[dbo].[User] WHERE email = '{user.Email}' AND password='{user.Password}'";
                SqlCommand command = new SqlCommand(com, connection);
                connection.Open();
                return command.ExecuteReader().Read();
            }
        }

        public IEnumerable<string> GetRoleForUser(string email)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string com = $"SELECT isAdmin FROM [MyPortfolioDB].[dbo].[User] WHERE email ='{email}'";
                SqlCommand command = new SqlCommand(com, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                   yield return reader["isAdmin"].ToString();
                }
            }
        }

        public IEnumerable<string> GetAllRoles()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string com = "SELECT isAdmin FROM [MyPortfolioDB].[dbo].[User]";
                SqlCommand command = new SqlCommand(com, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    yield  return reader["isAdmin"].ToString();
                }
            }
        }
    }
}
