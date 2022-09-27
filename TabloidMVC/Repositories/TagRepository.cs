using System.Collections.Generic;
<<<<<<< HEAD
using Microsoft.CodeAnalysis.CSharp.Syntax;
=======
using Microsoft.Data.SqlClient;
>>>>>>> main
using Microsoft.Extensions.Configuration;
using TabloidMVC.Models;
using Microsoft.Data.SqlClient;
using System;

namespace TabloidMVC.Repositories
{
    public class TagRepository : BaseRepository, ITagRepository
    {
        public TagRepository(IConfiguration config) : base(config) { }

        public List<Tag> GetAll()
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT id, name FROM Tag ORDER BY name";
                    var reader = cmd.ExecuteReader();

                    var tags = new List<Tag>();

                    while (reader.Read())
                    {
                        tags.Add(new Tag()
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Name = reader.GetString(reader.GetOrdinal("Name")),
                        });
                    }

                    reader.Close();

                    return tags;
                }
            }
        }

        public void AddTag(Tag tag)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        INSERT INTO Tag (Name)
                        OUTPUT INSERTED.ID
                        VALUES (@name);
                        ";

<<<<<<< HEAD
        public Tag GetTagById(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                    SELECT Id, Name 
                    FROM Tag
                    WHERE Id = @id";
                    cmd.Parameters.AddWithValue("@id", id);
                    //var reader = cmd.ExecuteReader();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            Tag tag = new Tag
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Name = reader.GetString(reader.GetOrdinal("Name")),
                            };
                            return tag;
                        }
                        return null;
                    }
=======
                    cmd.Parameters.AddWithValue("@name", tag.Name);

                    int id = (int)cmd.ExecuteScalar();

                    tag.Id = id;
>>>>>>> main
                }
            }
        }

        public void UpdateTag(Tag tag)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT Id, Name FROM Tag";

                    cmd.Parameters.AddWithValue("@id", tag.Id);
                    cmd.Parameters.AddWithValue("@email", tag.Name);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
