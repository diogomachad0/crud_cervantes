using crud_cervantes.Repositorios;
using Npgsql;
using System.Windows.Forms;

namespace crud_cervantes
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void LimparCampos()
        {
            Nome.Text = string.Empty;
            Telefone.Text = string.Empty;
        }

        private void BuscarTodosFuncionarios(FuncionarioRepositorio funcionarioRepositorio)
        {
            var funcionarios = funcionarioRepositorio.GetAllFuncionarios();
            dgFuncionario.DataSource = funcionarios.ToList();

        }

        private void buttonEditar_Click(object sender, EventArgs e)
        {
            if (dgFuncionario.CurrentRow != null)
            {
                int id = Convert.ToInt32(dgFuncionario.CurrentRow.Cells["Id"].Value);

                if (string.IsNullOrWhiteSpace(Nome.Text))
                {
                    MessageBox.Show("O nome não pode estar vazio.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(Telefone.Text))
                {
                    MessageBox.Show("O telefone não pode estar vazio.");
                    return;
                }

                long telefone;
                if (!long.TryParse(Telefone.Text, out telefone))
                {
                    MessageBox.Show("O telefone deve ser um número válido.");
                    return;
                }

                var funcionario = new Funcionario(id, Nome.Text, telefone);
                var funcionarioRepositorio = new FuncionarioRepositorio();
                funcionarioRepositorio.Update(funcionario);
                LimparCampos();
                BuscarTodosFuncionarios(funcionarioRepositorio);
            }
        }

        private void buttonRemover_Click(object sender, EventArgs e)
        {
            if (dgFuncionario.CurrentRow != null)
            {
                int id = Convert.ToInt32(dgFuncionario.CurrentRow.Cells["Id"].Value);
                var funcionarioRepositorio = new FuncionarioRepositorio();
                funcionarioRepositorio.Delete(id);
                LimparCampos();
                BuscarTodosFuncionarios(funcionarioRepositorio);
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Nome.Text) && string.IsNullOrWhiteSpace(Telefone.Text))
            {
                MessageBox.Show("Erro: Nome e Telefone não podem ser nulos.", "Erro de Validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (string.IsNullOrEmpty(Nome.Text.Trim()))
            {
                MessageBox.Show("Erro: Nome não pode ser nulo.", "Erro de Validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (string.IsNullOrEmpty(Telefone.Text.Trim()))
            {
                MessageBox.Show("Erro: Telefone não pode ser nulo.", "Erro de Validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            long telefone;
            if (!long.TryParse(Telefone.Text, out telefone))
            {
                MessageBox.Show("O telefone deve ser um número válido.");
                return;
            }

            var funcionario = new Funcionario(0, Nome.Text, telefone);
            var funcionarioRepositorio = new FuncionarioRepositorio();
            funcionarioRepositorio.Insert(funcionario);
            LimparCampos();
            BuscarTodosFuncionarios(funcionarioRepositorio);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                var funcionarioRepositorio = new FuncionarioRepositorio();
                BuscarTodosFuncionarios(funcionarioRepositorio);
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
                    this.Close();
                }
                else
                {
                    Form1_Load(sender, e);
                }
            }
        }

        private void dgFuncionario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            if (dgv == null)
            {
                return;
            }
            Nome.Text = dgv.CurrentRow.Cells["Nome"].Value.ToString();
            Telefone.Text = dgv.CurrentRow.Cells["Telefone"].Value.ToString();
        }

        private void Id_TextChanged(object sender, EventArgs e)
        {
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void Nome_TextChanged(object sender, EventArgs e)
        {

        }
    }
}