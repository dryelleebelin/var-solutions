using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using WebApiPessoa.Repository;

namespace WebApiPessoa.Application.Autenticacao
{
    public class AutenticacaoService
    {
        private readonly PessoaContext _context; //
        public AutenticacaoService(PessoaContext context)
        {
            _context = context;
        }   //
        public string Autenticar(AutenticacaoRequest request)
        {
            var usuario = _context.Usuarios.FirstOrDefault(x => x.usuario == request.UserName && x.senha == request.Password);  //
            if (usuario != null)
            {
                var tokenString = GerarTokenJwt();
                return tokenString;
            }
            else
            {
                return null;
            }
        }
        private string GerarTokenJwt()
        {
            var issuer = "var";  //quem está emitindo o token
            var audience = "var";  //destinatário da api
            var key = "1c93a5c9-1b8d-4f3c-ba71-65954542cc4e";  //chave secreta

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(issuer: issuer, audience, expires: DateTime.Now.AddMinutes(60), signingCredentials: credentials);
            var tokenHandler = new JwtSecurityTokenHandler();
            var stringToken = tokenHandler.WriteToken(token);
            return stringToken;
        }
    }
}
