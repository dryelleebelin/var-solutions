using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//coordenadas da serpente
namespace JogoDaCobrinha
{
    internal class Coordenada  //eixo x e y
    {
        public  int X { get; set; }

        public int Y { get; set; }

        public Coordenada(int x, int y) //construtor
        {
            X = x;
            Y = y;
        }
    }
}
