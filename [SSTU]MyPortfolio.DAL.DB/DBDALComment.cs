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
    public class DBDALComment : IMyPortfolioDALComment
    {
        private string connectionString;

        public DBDALComment()
        {
            connectionString = ConfigurationManager.ConnectionStrings["MyPortfolioDB"].ConnectionString;
        }

        public int Add(Comment comment)
        {
            int id = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string com = "INSERT INTO [MyPortfolioDB].[dbo].[Comment] (text, PhotoId, userId) VALUES (@text, @PhotoId, @userId);  Select [commentId] FROM [MyPortfolioDB].[dbo].[Comment] WHERE [commentId]=SCOPE_IDENTITY()";
                SqlCommand command = new SqlCommand(com, connection);
                command.Parameters.AddWithValue("@commentId", comment.CommentId);
                command.Parameters.AddWithValue("@text", comment.Text);
                command.Parameters.AddWithValue("@PhotoId", comment.PhotoId);
                command.Parameters.AddWithValue("@userId", comment.UserId);
                connection.Open();
                var reader = command.ExecuteReader();
                reader.Read();
                id = (int)reader["commentId"];
                connection.Close();
            }
            return id;
        }

        public Comment GetById(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string com = $"SELECT commentId, text, PhotoId, userId FROM [MyPortfolioDB].[dbo].[Comment] WHERE commentId = {id}";
                SqlCommand command = new SqlCommand(com, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    return new Comment(int.Parse(reader["commentId"].ToString()), reader["text"].ToString(), int.Parse(reader["PhotoId"].ToString()), (int)reader["userId"]);
                }
                return null;
            }
        }

        public IEnumerable<Comment> GetCommentsOfPhoto(int photoId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand com = new SqlCommand($"SELECT [commentId],[text],[PhotoId],[userId] FROM [MyPortfolioDB].[dbo].[Comment] WHERE[MyPortfolioDB].[dbo].[Comment].[PhotoId] = '{photoId}'", conn);
                conn.Open();
                var reader = com.ExecuteReader();
                while (reader.Read())
                {
                    yield return (new Comment(int.Parse(reader["commentId"].ToString()), reader["text"].ToString(), int.Parse(reader["PhotoId"].ToString()), (int)reader["userId"]));
                }
                conn.Close();
            }
        }

        public void DeleteCommentsOfUser(int userId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand com = new SqlCommand($"DELETE FROM [MyPortfolioDB].[dbo].[Comment] WHERE[MyPortfolioDB].[dbo].[Comment].[userId] = '{userId}'", conn);
                conn.Open();
                com.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
}
