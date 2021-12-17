using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using VisitorApplication.Shared;

namespace VisitorApplication.Server.Controllers
{
    public interface ICategory
    {
        Task<List<Category>> CategoryList();
    }

    public class CategoryService : ICategory
    {
        private readonly IConfiguration _configuration;

        public CategoryService(IConfiguration configuration)
        {
            _configuration = configuration;

        }

        public string GetConnection()
        {
            var connection = _configuration.GetSection("ConnectionStrings").GetSection("default").Value;
            return connection;
        }

        public async Task<List<Category>> CategoryList()
        {
            var connectionString = this.GetConnection();
            List<Category> categoryList = new List<Category>();
            using (var con = new MySqlConnection(connectionString))
            {
                try
                {
                    await con.OpenAsync();
                    var com = new MySqlCommand("Select `CategoryId`, `Title`, `IsPublished`, `Icon`, `InformationBoardId` FROM Category", con)
                    {
                        CommandType = CommandType.Text
                    };
                    var rdr = (MySqlDataReader)await com.ExecuteReaderAsync();

                    while (rdr.Read())
                    {
                        try
                        {
                            var category = new Category
                            {
                                //rdr reads the element inside [] from the database and saves it in the variable
                                CategoryId = (int)rdr["CategoryId"],
                                Title = rdr["Title"].ToString(),
                                IsPublished = (bool)rdr["IsPublished"],
                                Icon = rdr["Icon"].ToString(),
                                InformationBoardId = (int)rdr["InformationBoardId"]
                            };

                            if (!category.ContentIsValid)
                            {
                                throw new Exception("Tried to load invalid category: " + category.Title);
                            }

                            categoryList.Add(category);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
                    return categoryList.ToList();
                }
                finally { con.Close(); }
            }
        }
    }
}