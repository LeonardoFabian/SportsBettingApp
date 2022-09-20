using Dapper;
using Microsoft.Data.SqlClient;
using SportsBettingApp.Models;

namespace SportsBettingApp.Services
{
    public interface ICategoriesRepository
    {
        Task Create(Categories categories);
        Task<bool> Exists(string name);
        Task<IEnumerable<Categories>> Get();
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
            var id = await connection.QuerySingleAsync<int>(
                @"INSERT INTO Categories (Name)
                VALUES(@Name);
                SELECT SCOPE_IDENTITY();", 
                categories);

            categories.Id = id;
        }

        public async Task<bool> Exists(string name)
        {
            using var connection = new SqlConnection(connectionString);
            var exists = await connection.QueryFirstOrDefaultAsync<int>(
                @"SELECT 1
                FROM Categories
                WHERE Name = @Name;",
                new {name} );

            return exists == 1;
        }

        public async Task<IEnumerable<Categories>> Get()
        {
            using var connection = new SqlConnection(connectionString);
            return await connection.QueryAsync<Categories>(
                @"SELECT Id, Name
                FROM Categories;");
        }
    }
}
