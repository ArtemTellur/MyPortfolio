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
    public class DBDALLike : IMyPortfolioDALLike
    {
        private string connectionString;

        public DBDALLike()
        {
            connectionString = ConfigurationManager.ConnectionStrings["MyPortfolioDB"].ConnectionString;
        }

        public int Add(Like like)
        {
            int id = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string com = "INSERT INTO [MyPortfolioDB].[dbo].[Like] (PhotoId, userId) VALUES (@PhotoId, @userId); Select [likeId] FROM [MyPortfolioDB].[dbo].[Like] WHERE [likeId]=SCOPE_IDENTITY()";
                SqlCommand command = new SqlCommand(com, connection);
                command.Parameters.AddWithValue("@PhotoId", like.PhotoId);
                command.Parameters.AddWithValue("@userId", like.UserId);
                connection.Open();
                var reader = command.ExecuteReader();
                reader.Read();
                id = (int)reader["likeId"];
                connection.Close();
            }
            return id;
        }

        public void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string com = "DELETE FROM [MyPortfolioDB].[dbo].[Like] WHERE [likeId]=@likeId";
                SqlCommand command = new SqlCommand(com, connection);
                command.Parameters.AddWithValue("@likeId", id);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public IEnumerable<Like> GetLikesOfPhoto(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand com = new SqlCommand($"SELECT [likeId], [PhotoId], [userId] FROM [MyPortfolioDB].[dbo].[Like] WHERE [MyPortfolioDB].[dbo].[like].[PhotoId] = '{id}'", conn);
                conn.Open();
                var reader = com.ExecuteReader();
                while (reader.Read())
                {
                    yield return (new Like((int)reader["likeId"], (int)reader["PhotoId"], (int)reader["userId"]));
                }
                conn.Close();
            }
        }
    }
}
