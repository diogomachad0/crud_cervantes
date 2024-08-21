using Dapper;
using Npgsql;

namespace crud_cervantes.Repositorios
{
    public class FuncionarioRepositorio
    {

        public IEnumerable<Funcionario> GetAllFuncionarios()
        {
            using NpgsqlConnection conexao = (NpgsqlConnection)new DbConexao().GetConnection();
            return conexao.Query<Funcionario>(@"SELECT * FROM FUNCIONARIO");

        }

        public void Insert(Funcionario funcionario)
        {
            bool sucesso = false;

            while (!sucesso)
            {
                try
                {
                    using NpgsqlConnection conexao = (NpgsqlConnection)new DbConexao().GetConnection();
                    conexao.Execute("INSERT INTO FUNCIONARIO (NOME, TELEFONE) VALUES(@nome, @telefone);",
                        new
                        {
                            nome = funcionario.Nome,
                            telefone = funcionario.Telefone
                        });

                    int funcionarioId = conexao.QuerySingle<int>("SELECT LASTVAL();");
                    RegistrarLog("Insert", funcionarioId);
                    sucesso = true; // se chegou aqui, a operação foi sucedida
                }
                catch (Npgsql.NpgsqlException ex)
                {
                    DialogResult result = MessageBox.Show("Erro ao conectar com o banco de dados. Deseja tentar novamente?",
                        "Erro de Conexão", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);

                    if (result == DialogResult.Cancel)
                    {
                        // caso o usuario escolher cancelar, sai do loop e retorna a aplicacao
                        break;
                    }
                    // ca/so o usuario escolher tentar nov, o loop continuara e tentara novamente
                }
                catch (Exception ex)
                {
                    // tratamento para outras exceções gerais
                    MessageBox.Show($"Ocorreu um erro: {ex.Message}",
                        "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break; // sai do loop se for uma exceção diferente de npgsqlexception
                }
            }
        }

        public void Update(Funcionario funcionario)
        {
            bool sucesso = false;

            while (!sucesso)
            {
                try
                {
                    using NpgsqlConnection conexao = (NpgsqlConnection)new DbConexao().GetConnection();
                    conexao.Execute("UPDATE FUNCIONARIO SET NOME = @nome, TELEFONE = @telefone WHERE ID = @id;",
                        new
                        {
                            nome = funcionario.Nome,
                            telefone = funcionario.Telefone,
                            id = funcionario.Id
                        });

                    RegistrarLog("Update", funcionario.Id);
                    sucesso = true;
                }
                catch (Npgsql.NpgsqlException ex)
                {
                    DialogResult result = MessageBox.Show("Erro ao conectar com o banco de dados. Deseja tentar novamente?",
                        "Erro de Conexão", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);

                    if (result == DialogResult.Cancel)
                    {
                        break;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ocorreu um erro: {ex.Message}",
                        "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }
            }
        }

        public void Delete(int id)
        {
            using var conexao = (NpgsqlConnection)new DbConexao().GetConnection();
            using var transaction = conexao.BeginTransaction();

            try
            {
                conexao.Execute("INSERT INTO OPERACAO_LOG (TIPO_OPERACAO) VALUES(@tipoOperacao);",
                    new { tipoOperacao = "Delete" },
                    transaction);

                conexao.Execute("DELETE FROM FUNCIONARIO WHERE ID = @id;",
                    new { id },
                    transaction);

                transaction.Commit();
            }
            catch (Npgsql.NpgsqlException ex)
            {
                transaction.Rollback();
                MessageBox.Show("Erro ao conectar com o banco de dados. Verifique sua conexão e tente novamente.",
                    "Erro de Conexão", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                MessageBox.Show($"Erro ao remover o funcionário: {ex.Message}",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RegistrarLog(string tipoOperacao, int funcionarioId)
        {
            using NpgsqlConnection conexao = (NpgsqlConnection)new DbConexao().GetConnection();
            conexao.Execute("INSERT INTO OPERACAO_LOG (TIPO_OPERACAO) VALUES(@tipoOperacao);",
                new
                {
                    tipoOperacao,
                });
        }

    }
}
