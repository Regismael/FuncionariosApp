using FuncionariosApp.API.Models;
using FuncionariosApp.DATA.Entities;
using FuncionariosApp.DATA.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FuncionariosApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post(FuncionariosPostModel model)
        {
            try
            {
                var funcionario = new Funcionario
                {
                    Id = Guid.NewGuid(),
                    DataHoraCadastro = DateTime.Now,
                    Nome = model.Nome,
                    Matricula = model.Matricula,
                    Cpf = model.Cpf,
                    Ativo = 1


                };

                var funcionarioRepository = new FuncionarioRepository();
                funcionarioRepository.Inserir(funcionario);

                return StatusCode(201, new
                {
                    Message = "Funcionário cadastrado com sucesso!",
                    funcionario
                });
            }
            catch (Exception e)
            {
                return StatusCode(500, new
                {
                    e.Message
                });
            }

        }

        [HttpPut]
        public IActionResult Put(FuncionariosPutModel model)
        {
            try
            {
                var funcionarioRepository = new FuncionarioRepository();
                var funcionario = funcionarioRepository.GetById(model.Id);

                if (funcionario != null)
                {
                    funcionario.Nome = model.Nome;
                    funcionario.Cpf = model.Matricula;
                    funcionario.Matricula = model.Matricula;

                    funcionarioRepository.Atualizar(funcionario);

                    return StatusCode(201, new
                    {
                        Message = "Funcionário atualizado com sucesso."
                    });
                }
                else
                {
                    return StatusCode(400, new
                    {
                        Message = "Funcionário não encontrado, verifique o Id."
                    });
                }
            }
            catch(Exception e)
            {
                return StatusCode(500, new
                {
                    e.Message
                });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var funcionarioRepository = new FuncionarioRepository();
                var funcionario = funcionarioRepository.GetById(id);

                if (funcionario != null)
                {
                    funcionarioRepository.Delete(funcionario);

                    return StatusCode(200, new
                    {
                        Message = "Funcionário excluído com sucesso",
                        funcionario
                    });
                }
                else
                {
                    return StatusCode(400, new
                    {
                        Message = "Funcionário não encontrado, verifique o Id!"
                    });
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, new
                {
                    e.Message
                });
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var funcionarioRepository = new FuncionarioRepository();
                var funcionario = funcionarioRepository.GetAll();

                return StatusCode(201, funcionario);
            }
            catch (Exception e)
            {
                return StatusCode(500, new
                {
                    e.Message
                });
            }
        }


        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var funcionarioRepository = new FuncionarioRepository();
                var funcionario = funcionarioRepository.GetById(id);

                if(funcionario != null)
                {
                    return StatusCode(200, funcionario);
                }
                else
                {
                    return StatusCode(400, new
                    {
                        Message = "Funcionário não encontrado, verifique o Id!"
                    });
                }

            }
            catch(Exception e)
            {
                return StatusCode(500, new
                {
                    e.Message
                });
            }
        }
    }
}
