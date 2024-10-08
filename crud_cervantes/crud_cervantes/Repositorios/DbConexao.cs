﻿using Npgsql;
using System;
using System.Data;

namespace crud_cervantes.Repositorios
{
    public class DbConexao : IDisposable
    {
        private readonly IDbConnection connection;

        public DbConexao()
        {
            connection = new NpgsqlConnection("Server=127.0.0.1;Port=5432;Database=cadastro_funcionarios_cervantes;User Id=postgres;Password=123;");
        }

        public IDbConnection GetConnection()
        {
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            return connection;
        }

        public void Dispose()
        {
            connection?.Dispose();
        }
    }
}