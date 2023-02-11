using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;  //biblioteca, pacote de códigos
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

        public decimal Altura { get; private set; }

        //swagger

        /// <summary>
        /// Rota responsável por realizar o processamento de dados de uma pessoa
        /// </summary>
        /// <returns>Retorna os dados processados da pessoa</returns>
        /// <response code="200">Retorna os dados processados com sucesso</response>
        /// <response code="400">Erro de validação</response>

        [HttpPost]
        [Authorize]  //só continua se mandar o token

        public PessoaResponse ProcessarInformacoesPessoa([FromBody] PessoaRequest request) //PessoaResponse = o que a api vai responder //ProcessarInformacoesPessoa() = nome do método //[FromBody] = vem do body //PessoaRequest = classe = o que vem do body //request = nome da váriavel, nome do parâmetro
        {
            var idade = CalcularIdade(request.DataNascimento);
            var imc = CalcularImc(request.Peso, request.Altura);
            var classificacao = CalcularClassificacao(imc);
            var aliquota = CalcularAliquota(request.Salario);
            var inss = CalcularInss(request.Salario, aliquota);
            var salarioLiquido = CalcularSalarioLiquido(request.Salario, inss);
            var saldoDolar = CalcularDolar(request.Saldo);

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

        //métodos para refatoração
        private int CalcularIdade(DateTime dataNascimento)
        {
            var anoAtual = DateTime.Now.Year;
            var idade = anoAtual - dataNascimento.Year;
            var mesAtual = DateTime.Now.Month;
            if (mesAtual < dataNascimento.Month)
            {
                idade = idade - 1;
            }

            return idade;
        }

        private decimal CalcularImc(decimal peso, decimal altura)
        {
            return Math.Round(peso / (altura * altura), 2);
        }

        private string CalcularClassificacao(decimal imc)
        {
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

            return classificacao;
        }

        private double CalcularAliquota(double salario)
        {
            var aliquota = 7.5;
            if (salario <= 1212)
            {
                aliquota = 7.5;
            }
            else if (salario >= 1212.01 && salario <= 2427.35)
            {
                aliquota = 9;
            }
            else if (salario >= 2427.36 && salario <= 3641.03)
            {
                aliquota = 12;
            }
            else
            {
                aliquota = 14;
            }

            return aliquota;
        }

        private double CalcularInss(double salario, double aliquota) 
        {
            var inss = (salario * aliquota) / 100;

            return inss;
        }

        private double CalcularSalarioLiquido(double salario, double inss)
        {
            return salario - inss;
        }

        private decimal CalcularDolar(decimal saldo)
        {
            var dolar = (decimal)5.15;
            var saldoDolar = Math.Round(saldo / dolar, 2);

            return saldoDolar;
        }
    }
}
