using Npgsql;
using System;
using System.Data;
using System.Windows.Forms;

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
            while (true)
            {
                try
                {
                    if (connection.State != ConnectionState.Open)
                    {
                        connection.Open();
                    }
                    return connection;
                }
                catch (NpgsqlException ex)
                {
                    DialogResult result = MessageBox.Show(
                        "Erro ao conectar ao banco de dados. Verifique a configuração da rede e tente novamente.\n\n" + ex.Message,
                        "Erro de Conexão",
                        MessageBoxButtons.RetryCancel,
                        MessageBoxIcon.Error
                    );

                    if (result == DialogResult.Cancel)
                    {
                        throw new Exception("Falha ao conectar ao banco de dados.", ex);
                    }
                }
            }
        }

        public void Dispose()
        {
            connection?.Dispose();
        }
    }
}
