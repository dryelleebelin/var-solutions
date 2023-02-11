using System;
using System.Collections.Generic;
using System.Text;

// representação da tabela
namespace WebApiPessoa.Repository.Models
{
    //representação dos atributos da tabela
    public class TUsuario 
    {
        public int id { get; set; }
        public string nome { get;set; }
        public string usuario { get; set; }
        public string senha { get; set; }
    }
}
