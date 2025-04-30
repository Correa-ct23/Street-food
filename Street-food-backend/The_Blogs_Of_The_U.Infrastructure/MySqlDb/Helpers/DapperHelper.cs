using Dapper;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;
using System.Data;
using The_Blogs_Of_The_U.Infrastructure.MySqlDb.Settings;
namespace The_Blogs_Of_The_U.Infrastructure.MySqlDb.Helpers
{
    public class DapperHelper
    {
        public string ConnectionString { get; set; }
        public DapperHelper(IOptions<MySqlSettings> data)
        {
            ConnectionString = $"Server=" + data.Value.host + ";Port=" + data.Value.port + ";Database=" + data.Value.db + ";Uid=" + data.Value.dbUser + ";Pwd=" + data.Value.dbPassword + ";default command timeout=120;SslMode=none";
        }
        public IDbConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        public async Task<IReadOnlyList<T>> QueryAsync<T>(string query, int commandTimeout = 6000)
        {

            using IDbConnection connection = GetConnection();
            connection.Open();

            var resultado = await connection.QueryAsync<T>(query, null, commandType: null, commandTimeout: commandTimeout);
            connection.Close();
            return resultado.ToList();
        }

        public async Task<IReadOnlyList<T>> QueryAsync<T>(IDbConnection connection, string query, int commandTimeout = 6000)
        {
            var resultado = await connection.QueryAsync<T>(query, null, commandType: null, commandTimeout: commandTimeout);
            return resultado.ToList();
        }

        public IDbConnection OpenConectionsTest()
        {
            IDbConnection connection = GetConnection();
            connection.Open();
            return connection;
        }

        public void CloseConnectionTest(IDbConnection connection)
        {
            connection.Close();
        }

        public async Task<int> InsertAsync(string query, object parameters = null, int commandTimeout = 6000)
        {
            using IDbConnection connection = GetConnection();
            connection.Open();

            int rowsAffected = await connection.ExecuteAsync(query, parameters, commandTimeout: commandTimeout);

            connection.Close();
            return rowsAffected;
        }

        public async Task<int> DeleteAsync(string query, object parameters = null, int commandTimeout = 6000)
        {
            using IDbConnection connection = GetConnection();
            connection.Open();

            int rowsAffected = await connection.ExecuteAsync(query, parameters, commandTimeout: commandTimeout);

            connection.Close();
            return rowsAffected;
        }

        public async Task<int> UpdateAsync(string query, int commandTimeout = 6000)
        {
            using IDbConnection connection = GetConnection();
            connection.Open();
            using var transaction = connection.BeginTransaction();

            int rowsAffected = await connection.ExecuteAsync(query, transaction: transaction, commandTimeout: commandTimeout);

            transaction.Commit();

            connection.Close();
            return rowsAffected;
        }

        public async Task<int> DeleteByEmailAsync(string query, int commandTimeout = 6000)
        {
            using IDbConnection connection = GetConnection();
            connection.Open();


            int rowsAffected = await connection.ExecuteAsync(query, commandTimeout: commandTimeout);

            connection.Close();
            return rowsAffected;
        }

        public async Task<int> ExecuteAsync(string query, object parameters = null, int commandTimeout = 6000)
        {
            using IDbConnection connection = GetConnection();
            try
            {
                connection.Open();

                int rowsAffected = await connection.ExecuteAsync(query, parameters, commandType: null, commandTimeout: commandTimeout);
                connection.Close();
                return rowsAffected;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error ejecutando consulta: {ex.Message}");
                throw;
            }
        } 


    }
}
