using System;
using Microsoft.VisualBasic;

namespace WebApiPessoa
{
    public class PessoaRequest  //dados que vamos receber do usuário  //atributos
    {
       public string Nome { get; set; }

       public DateTime DataNascimento { get; set; }

       public decimal Altura { get; set; }

       public decimal Peso { get; set; }

       public double Salario { get; set; }

       public decimal Saldo { get; set; }
    }
}
