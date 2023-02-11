using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiPessoa.Application.Autenticacao
{
    public class AutenticacaoRequest
    {
        public string UserName { get; set; }

        public string Password { get; set; }
    }
}