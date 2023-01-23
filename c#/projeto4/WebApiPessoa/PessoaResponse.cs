using Microsoft.VisualBasic;

namespace WebApiPessoa
{
    public class PessoaResponse  //o que nossa api vai responder
    {
        public string Nome { get; set; }

        public int Idade { get; set; }

        public decimal Imc { get; set; }

        public string Classificacao { get; set; }

        public double Inss { get; set; }

        public double Aliquota { get; set; }

        public double SalarioLiquido { get; set; }

        public decimal SaldoDolar { get; set; }
    }
}
