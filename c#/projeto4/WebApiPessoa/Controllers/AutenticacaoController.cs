using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using WebApiPessoa.Application.Autenticacao;
using WebApiPessoa.Repository;

namespace WebApiPessoa.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AutenticacaoController : ControllerBase
    {
        private readonly PessoaContext _context; //banco de dados
        public AutenticacaoController(PessoaContext context)
        {
            _context = context;
        }  //

        [HttpPost]
        public IActionResult Login([FromBody] AutenticacaoRequest request)
        {
            var autenticacaoService = new AutenticacaoService(_context); //
            var tokenString = autenticacaoService.Autenticar(request);

            if (string.IsNullOrWhiteSpace(tokenString))
            {
                return Unauthorized();
            }
            else
            {
                return Ok(new { token = tokenString });
            }
        }
    }
}