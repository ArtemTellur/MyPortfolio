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
    public class DBDALPhoto : IMyPortfolioDALPhoto
    {

        private string connectionString;

        public DBDALPhoto()
        {
            connectionString = ConfigurationManager.ConnectionStrings["MyPortfolioDB"].ConnectionString;
        } 



        public int Add(Photo photo)
        {
            int id = 0;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand com = new SqlCommand("INSERT INTO [MyPortfolioDB].[dbo].[Photo] ([MIME],[Picture],[albumId]) VALUES (@mime,@picture,@albumId); Select [photoId] FROM [MyPortfolioDB].[dbo].[Photo] WHERE [photoId]=SCOPE_IDENTITY()", con);
                com.Parameters.AddWithValue("@mime", photo.Mime);
                com.Parameters.AddWithValue("@picture", photo.Image);
                com.Parameters.AddWithValue("@albumId", photo.AlbumId.HasValue ? photo.AlbumId.Value : (object)DBNull.Value);
                con.Open();
                var reader = com.ExecuteReader();
                reader.Read();
                id = (int)reader["photoId"];
                con.Close();
            }
            return id;
        }



        public void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string com = "DELETE FROM [MyPortfolioDB].[dbo].[Photo] WHERE [photoId]=@photoId";
                SqlCommand command = new SqlCommand(com, connection);
                command.Parameters.AddWithValue("@photoId", id);
                connection.Open();
                var query = command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public Photo GetById(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand com = new SqlCommand($"SELECT [photoId],[MIME],[Picture],[albumId] FROM [dbo].[Photo] WHERE [photoId]='{id}'", conn);
                conn.Open();
                var reader = com.ExecuteReader();
                while (reader.Read())
                {
                    return new Photo((int)reader["photoId"], (string)reader["MIME"], (byte[])reader["Picture"], reader["albumId"]==DBNull.Value? null : (int?)reader["albumId"]);
                }
                conn.Close();
            }
            return null;
        }

        public void Update(Photo photo)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand com = new SqlCommand($"UPDATE [dbo].[Photo] SET [MIME]=@mime, [Picture]=@picture where [photoId]=@id", con);
                com.Parameters.AddWithValue("@mime", photo.Mime);
                com.Parameters.AddWithValue("@picture", photo.Image);
                com.Parameters.AddWithValue("@id", photo.Id);
                con.Open();
                var query = com.ExecuteNonQuery();
                con.Close();
            }
        }

        public IEnumerable<int> GetPhotosOfAlbum(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand com = new SqlCommand($"SELECT [photoId] FROM [MyPortfolioDB].[dbo].[Photo] INNER JOIN[MyPortfolioDB].[dbo].[Album] on [MyPortfolioDB].[dbo].[Photo].[albumId] = [MyPortfolioDB].[dbo].[Album].[AlbumId] WHERE[MyPortfolioDB].[dbo].[Album].[AlbumId] = '{id}'", conn);
                conn.Open();
                var reader = com.ExecuteReader();
                while (reader.Read())
                {
                    yield return (int)reader["photoId"];
                }
                conn.Close();
            }
        }
    }
}
