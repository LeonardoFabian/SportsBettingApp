using Dapper;
using Microsoft.Data.SqlClient;
using SportsBettingApp.Models;

namespace SportsBettingApp.Services
{
    public interface ICategoriesRepository
    {
        void Create(Categories categories);
    }

    public class CategoriesRepository : ICategoriesRepository   
    {
        private readonly string connectionString;

        public CategoriesRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public void Create(Categories categories)
        {
            using var connection = new SqlConnection(connectionString);
            var id = connection.QuerySingle<int>($@"INSERT INTO Categories (Name)
                                                    VALUES(@Name);
                                                    SELECT SCOPE_IDENTITY();", categories);

            categories.Id = id;
        }
    }
}
