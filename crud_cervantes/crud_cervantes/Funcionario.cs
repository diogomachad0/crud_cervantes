using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crud_cervantes
{
    public class Funcionario
    {
        public Funcionario() { }

        public Funcionario(int id, string nome, long telefone)
        {
            Id = id;
            Nome = nome;
            Telefone = telefone;
        }

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public long Telefone { get; private set; }
    }

}
