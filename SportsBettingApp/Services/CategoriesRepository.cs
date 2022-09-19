using Dapper;
using Microsoft.Data.SqlClient;
using SportsBettingApp.Models;

namespace SportsBettingApp.Services
{
    public interface ICategoriesRepository
    {
        Task Create(Categories categories);
    }

    public class CategoriesRepository : ICategoriesRepository   
    {
        private readonly string connectionString;

        public CategoriesRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task Create(Categories categories)
        {
            using var connection = new SqlConnection(connectionString);
            var id = await connection.QuerySingleAsync<int>($@"INSERT INTO Categories (Name)
                                                    VALUES(@Name);
                                                    SELECT SCOPE_IDENTITY();", categories);

            categories.Id = id;
        }
    }
}
