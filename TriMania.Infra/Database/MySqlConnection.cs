using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;

namespace TriMania.Infra.Database
{
    public class SqlConnection : IMySqlConnection, IDisposable
    {
        private readonly string _connectionString;
        private IDbConnection _connection;

        public SqlConnection(string connectionString)
        {
            this._connectionString = connectionString;
        }

        public MySqlConnection CreateNewConnection()
        {
            var connection = new MySqlConnection(_connectionString);
            connection.Open();

            return connection;
        }

        public void Dispose()
        {
            if (this._connection != null && this._connection.State == ConnectionState.Open)
            {
                this._connection.Dispose();
            }
        }
    }
}
