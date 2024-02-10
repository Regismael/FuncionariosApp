using Dapper;
using FuncionariosApp.DATA.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuncionariosApp.DATA.Repositories
{
    public class FuncionarioRepository
    {
        private string _connectionString => "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BDFuncionariosApp;Integrated Security=True;";

        public void Inserir(Funcionario funcionario)
        {
            using(var connection = new SqlConnection(_connectionString))
            {
                connection.Execute(@"
                INSERT INTO FUNCIONARIO(ID, NOME, MATRICULA, CPF, DATAHORACADASTRO)
                VALUES(@ID, @NOME, @MATRICULA, @CPF, @DATAHORACADASTRO)

                ", new
                {
                 @ID = funcionario.Id,
                 @NOME = funcionario.Nome,
                 @MATRICULA = funcionario.Matricula,
                 @CPF = funcionario.Cpf,
                 @DATAHORACADASTRO = funcionario.DataHoraCadastro

                });
            }
        }

        public void Atualizar(Funcionario funcionario)
        {
            using(var connection = new SqlConnection(_connectionString))
            {
                connection.Execute(@"
                UPDATE FUNCIONARIO 
                SET NOME = @NOME, MATRICULA =  @MATRICULA, CPF =  @CPF
                WHERE ID = @ID

                ", new
                {
                 @ID = funcionario?.Id,
                 @NOME = funcionario?.Nome,
                 @MATRICULA = funcionario?.Matricula,
                 @CPF = funcionario?.Cpf

                });
            }
        }

        public void Delete(Funcionario funcionario)
        {
            using(var connection = new SqlConnection(_connectionString))
            {
                connection.Execute(@"
                UPDATE FUNCIONARIO
                SET ATIVO = 0
                WHERE ID = @ID

                ", new
                {
                 @ID = funcionario.Id,

                });
            }
        }

        public List<Funcionario> GetAll()
        {
            using(var conncetion = new SqlConnection(_connectionString))
            {
                return conncetion.Query<Funcionario>(@"
                SELECT * FROM FUNCIONARIO
                WHERE ATIVO = 1
                ORDER BY NOME
 
                ").ToList();
            }
        }

        public Funcionario? GetById(Guid id)
        {
            using(var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<Funcionario>(@"
                SELECT * FROM FUNCIONARIO
                WHERE ID = @ID AND ATIVO = 1

                 ",new
                {
                  @ID = id

                }).FirstOrDefault();
            }
        }
    }
}
