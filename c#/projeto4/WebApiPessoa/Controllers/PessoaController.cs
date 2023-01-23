using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiPessoa.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PessoaController : ControllerBase
    {
        public PessoaController(ILogger<PessoaController> logger)
        {

        }

        //método
        [HttpPost]

        public PessoaResponse ProcessarInformacoesPessoa([FromBody] PessoaRequest request) //PessoaResponse = o que a api vai responder //ProcessarInformacoesPessoa() = nome do método //[FromBody] = vem do body //PessoaRequest = classe = o que vem do body //request = nome da váriavel, nome do parâmetro
        {
            var anoAtual = DateTime.Now.Year;
            var idade = anoAtual - request.DataNascimento.Year;

            var imc = Math.Round(request.Peso / (request.Altura * request.Altura), 2);

            var classificacao = "";
            if (imc < (decimal)18.5)
            {
                classificacao = "Abaixo do peso ideal";
            }
            else if (imc >= (decimal)18.5 && imc <= (decimal)24.99)
            {
                classificacao = "Peso normal";
            }
            else if (imc >= (decimal)25 && imc <= (decimal)29.99)
            {
                classificacao = "Pré-obesidade";
            }
            else if (imc >= (decimal)30 && imc <= (decimal)34.99)
            {
                classificacao = "Obesidade grau I";
            }
            else if (imc >= (decimal)35 && imc <= (decimal)39.99)
            {
                classificacao = "Obesidade grau II";
            }
            else
            {
                classificacao = "Obesidade grau III";
            }

            var aliquota = 7.5;
            if (request.Salario <= 1212)
            {
                aliquota = 7.5;
            }
            else if (request.Salario >= 1212.01 && request.Salario <= 2427.35)
            {
                aliquota = 9;
            }
            else if (request.Salario >= 2427.36 && request.Salario <= 3641.03)
            {
                aliquota = 12;
            }
            else
            {
                aliquota = 14;
            }

            var inss = (request.Salario * aliquota) / 100;
            var salarioLiquido = request.Salario - inss;

            var dolar = (decimal)5.15;
            var saldoDolar = Math.Round(request.Saldo / dolar, 2);

            //instânciar objeto
            var resposta = new PessoaResponse();  
            resposta.SaldoDolar = saldoDolar;
            resposta.Aliquota = aliquota;
            resposta.SalarioLiquido = salarioLiquido;
            resposta.Classificacao = classificacao;
            resposta.Idade = idade;
            resposta.Imc = imc;
            resposta.Inss = inss;
            resposta.Nome = request.Nome;
            return resposta;
        }
    }
}
