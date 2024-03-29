﻿using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using VisitorApplication.Shared;

namespace VisitorApplication.Server.Controllers
{
    public interface IPost
    {
        Task<List<Post>> PostList();
    }

    public class PostService : IPost
    {
        private readonly IConfiguration _configuration;

        public PostService(IConfiguration configuration)
        {
            _configuration = configuration;

        }

        public string GetConnection()
        {
            var connection = _configuration.GetSection("ConnectionStrings").GetSection("default").Value;
            return connection;
        }

        public async Task<List<Post>> PostList()
        {
            var connectionString = this.GetConnection();
            List<Post> lst = new List<Post>();
            using (var con = new MySqlConnection(connectionString))
            {
                try
                {
                    await con.OpenAsync();
                    var com = new MySqlCommand("Select `PostId`,`Title`,`Author`,`Text`,`IsPublished`,`ExpirationDate`,`Image`,`Audio`,`CategoryId`, `Link` FROM Post", con)
                    {
                        CommandType = CommandType.Text
                    };
                    var rdr = (MySqlDataReader)await com.ExecuteReaderAsync();

                    while (rdr.Read())
                    {
                        try
                        {
                            var post = new Post
                            {
                                PostID = (int)rdr["PostId"],
                                Title = rdr["Title"].ToString(),
                                Author = rdr["Author"].ToString(),
                                Text = rdr["Text"].ToString(),
                                IsPublished = (bool)rdr["IsPublished"],
                                Link = rdr["Link"].ToString(),
                                ExpirationDate = (DateTime)rdr["ExpirationDate"],
                                Image = rdr["Image"].ToString(),
                                Audio = rdr["Audio"].ToString(),
                                CategoryID = (int)rdr["CategoryID"]
                            };

                            if (!post.ContentIsValid)
                            {
                                throw new Exception("Tried to load invalid post: " + post.Title);
                            }

                            lst.Add(post);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
                    return lst.ToList();
                }
                finally { con.Close(); }

                
            }

        }

    }
}
