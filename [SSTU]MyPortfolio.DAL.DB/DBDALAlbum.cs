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
    public class DBDALAlbum : IMyPortfolioDALAlbum
    {
        private string connectionString;

        public DBDALAlbum()
        {
            connectionString = ConfigurationManager.ConnectionStrings["MyPortfolioDB"].ConnectionString;
        }

        public bool Add(Album album)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string com = $"INSERT INTO [MyPortfolioDB].[dbo].[Album] (albumName, description, UserId) VALUES ('{album.AlbumName}', '{album.Description ?? (object)DBNull.Value}', '{album.UserId}')";
                SqlCommand command = new SqlCommand(com, connection);
                connection.Open();
                return command.ExecuteNonQuery() == 1;
            }
        }

        public bool Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string com = "DELETE FROM [MyPortfolioDB].[dbo].[Album] WHERE [AlbumId]=@albumId";
                SqlCommand command = new SqlCommand(com, connection);
                command.Parameters.AddWithValue("@albumId", id);
                connection.Open();
                return command.ExecuteNonQuery() == 1;
            }
        }

        public IEnumerable<Album> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string com = "SELECT AlbumId, albumName, description, UserId FROM [MyPortfolioDB].[dbo].[Album]";
                SqlCommand command = new SqlCommand(com, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    yield return new Album(int.Parse(reader["AlbumId"].ToString()), reader["albumName"].ToString(), reader["description"].ToString(), int.Parse(reader["UserId"].ToString()));
                }
            }
        }

        public Album GetById(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string com = $"SELECT AlbumId, albumName, description, UserId FROM [MyPortfolioDB].[dbo].[Album] WHERE AlbumId={id}";
                SqlCommand command = new SqlCommand(com, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    return new Album((int)reader["AlbumId"], reader["albumName"].ToString(), reader["description"].ToString(), (int)reader["UserId"]);
                }
                return null;
            }
        }

        public bool Update(Album album)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("UPDATE [MyPortfolioDB].[dbo].[Album] SET [albumName]=@AlbumName, [description]=@Description, [UserId]=@UserId where [AlbumId]=@id", connection);
                command.Parameters.AddWithValue("@AlbumName", album.AlbumName);
                command.Parameters.AddWithValue("@Description", album.Description ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@UserId", album.UserId);
                command.Parameters.AddWithValue("@id", album.AlbumId);
                connection.Open();
                return command.ExecuteNonQuery() == 1;
                connection.Close();
            }
        }

        public IEnumerable<Album> GetAlbumsOfUser(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand com = new SqlCommand($"SELECT [AlbumId],[albumName],[description] FROM [MyPortfolioDB].[dbo].[Album] INNER JOIN[MyPortfolioDB].[dbo].[User] on Album.UserId = [MyPortfolioDB].[dbo].[User].[userId] WHERE[MyPortfolioDB].[dbo].[User].[userId] = '{id}'", conn);
                conn.Open();
                var reader = com.ExecuteReader();
                while (reader.Read())
                {
                    yield return (new Album((int)reader["AlbumId"], (string)reader["albumName"], reader["description"] == DBNull.Value ? null : (string)reader["description"], id));
                }
                conn.Close();
            }
        }
        public void DeleteAlbumsOfUser(int userId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string com = "DELETE FROM [MyPortfolioDB].[dbo].[Album] WHERE [UserId]=@userId";
                SqlCommand command = new SqlCommand(com, connection);
                command.Parameters.AddWithValue("@userId", userId);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}
