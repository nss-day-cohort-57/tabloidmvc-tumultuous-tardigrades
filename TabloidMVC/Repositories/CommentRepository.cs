using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using TabloidMVC.Models;

namespace TabloidMVC.Repositories
{
    public class CommentRepository : BaseRepository, ICommentRepository
    {
        public CommentRepository(IConfiguration config) : base(config) { }

        public List<Comment> GetCommentsByPostId(int postId)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT Subject, Content, c.CreateDateTime, u.DisplayName
                                        FROM Comment c
                                        JOIN UserProfile u on u.Id = c.UserProfileId
                                        WHERE c.PostId = @postId
                                        ORDER BY c.CreateDateTime DESC";
                    cmd.Parameters.AddWithValue("@postId", postId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<Comment> comments = new List<Comment>();

                        while (reader.Read())
                        {
                            Comment comment = new Comment()
                            {
                                Subject = reader.GetString(reader.GetOrdinal("Subject")),
                                Content = reader.GetString(reader.GetOrdinal("Content")),
                                CreateDateTime = reader.GetDateTime(reader.GetOrdinal("CreateDateTime")),
                                UserProfile = new UserProfile()
                                {
                                    DisplayName = reader.GetString(reader.GetOrdinal("DisplayName"))
                                }
                            };

                            comments.Add(comment);
                        }

                        return comments;
                    }
                }
            }
        }

        public void AddComment(Comment comment)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO Comment
                                        (PostId, UserProfileId, Subject, Content, CreateDateTime)
                                        VALUES
                                        (@postId, @userProfileId, @subject, @content, @createDateTime)";

                    cmd.Parameters.AddWithValue("@postId", comment.PostId);
                    cmd.Parameters.AddWithValue("@userProfileId", comment.UserProfile.Id);
                    cmd.Parameters.AddWithValue("@subject", comment.Subject);
                    cmd.Parameters.AddWithValue("@content", comment.Content);
                    cmd.Parameters.AddWithValue("@createDateTime", comment.CreateDateTime);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
