//receber nome da pessoa
//receber a data de nascimento (calculo de idade)
//receber a altura e peso (calculo do imc)
//receber salário bruto (calculo do desconto clt)
//receber o saldo da conta (calcular valor em dólar)

using System;

//projeto
namespace Pessoa
{
    //classe
    internal class Program 
    {
        //método = ação
        static void Main(string[] args) 
        {
            Console.WriteLine("Digite o seu nome: ");  //captura da ação
            var nomePessoa = Console.ReadLine();  //variável + nome da variável  //=valor  //lê a linha e guarda o valor na variável

            Console.WriteLine("Digite sua data de nascimento: ");
            var dataNascimentoPessoa = Console.ReadLine();
            var dataNascimento = Convert.ToDateTime(dataNascimentoPessoa);   //conversão de dados

            var anoAtual = DateTime.Now.Year;   //ano atual
            var idade = anoAtual - dataNascimento.Year;   //calculo

            Console.WriteLine("Digite sua altura: ");  //com .
            var altura = Convert.ToDecimal(Console.ReadLine());   //conversão de dados
            Console.WriteLine("Digite seu peso: ");
            var peso = Convert.ToDecimal(Console.ReadLine());

            //+ - * /
            var imc = Math.Round((peso / (altura * altura)), 1);   //calculo imc + conversão para valor real
            var classificacao = "";

            //operadores
            //e = &&
            //ou = ||
            if (imc < (decimal)18.5)   //if = condição se //conversão de dados
            {
                classificacao = "Abaixo do peso ideal";
            }
            else if (imc >= (decimal)18.5 && imc <= (decimal)24.99)  //else = consição senão
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
                classificacao = "Obedidade grau III";
            }

            Console.WriteLine("Digite seu sálario bruto: ");
            var salario = Convert.ToDouble(Console.ReadLine());

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

            var inss = (salario * aliquota) / 100;
            var salarioLiquido = salario - inss;

            Console.WriteLine("Digite o saldo da conta: ");
            var saldo = Convert.ToDecimal(Console.ReadLine());

            var dolar = (decimal)5.15;

            var saldoDolar = Math.Round(saldo / dolar, 2);  //casas decimais

            Console.WriteLine("Seu nome é " + nomePessoa);
            Console.WriteLine("Você tem " + idade + " anos");
            Console.WriteLine("Seu IMC é " + imc + ", classificação: " + classificacao);
            Console.WriteLine("O desconto do INSS é " + inss + ", aliquota: " + aliquota);
            Console.WriteLine("O sálario líquido é: " + salarioLiquido);
            Console.WriteLine("O saldo em dólar é: " + saldoDolar);
        }
    }
}
