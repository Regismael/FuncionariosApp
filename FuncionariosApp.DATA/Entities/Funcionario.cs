using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuncionariosApp.DATA.Entities
{
    public class Funcionario
    {
        private Guid? _id;
        private string? _nome;
        private string? _matricula;
        private string? _cpf;
        private DateTime? _dataHoraCadastro;
        private int? _ativo;

        public Guid? Id { get => _id; set => _id = value; }
        public string? Nome { get => _nome; set => _nome = value; }
        public string? Matricula { get => _matricula; set => _matricula = value; }
        public string? Cpf { get => _cpf; set => _cpf = value; }
        public int? Ativo { get => _ativo; set => _ativo = value; }
        public DateTime? DataHoraCadastro { get => _dataHoraCadastro; set => _dataHoraCadastro = value; }
    }
}
