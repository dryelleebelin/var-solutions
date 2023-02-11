using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace OlaMundo.Controllers
{
    //controller - porta de entrada da api
    [ApiController]
    [Route("[controller]")]
    public class OlaMundoController : ControllerBase
    {
        public OlaMundoController(ILogger<OlaMundoController> logger)
        {
           
        }

        //método get
        [HttpGet]
        //padrão de declaração de método: visibilidade ou nivel de acesso e retorno
        public OlaMundo ObterMensagem()
        {
           var retorno = new OlaMundo();  //instanciar a classe
           retorno.Mensagem = "Olá mundo - Essa é a minha primeira Web API!" +
                " Integração do front com o back";
           return retorno;
        }
    }
}
