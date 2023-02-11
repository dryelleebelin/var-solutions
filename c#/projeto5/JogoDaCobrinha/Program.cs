using JogoDaCobrinha;

const int larguraTela = 69;  //largura da tela que vamos usar, esse valor não vai mudar
const int alturaTela = 29;   //altura da tela que vamos usar, esse valor não vai mudar
const string caractereCobra = "■";  //caractere que representa a serpente na tela

string[,] tela = new string[larguraTela, alturaTela];   //variável de tela
bool jogoRodando = true;  //indica se o jogo ta rodando
List<Coordenada> coordenadasCobra = new();  //onde a serpente está na tela
Direcao direcao = Direcao.Direita;  //direção que a serpente começa
int placar = 0;   //variável, placar que cresce a medida que a serpente se alimenta, se inicia em 0
Random random = new();   //variável, sorteio das posições da comida

IniciarJogo(); //método

void IniciarJogo()
{
    CriarCobra();
    CriarComida();
    LerTeclas();

    while(jogoRodando)   //estrutura de repetição
    {
        Thread.Sleep(50);  //tempo fixo
        TransladarCobra();  //fazer a serpente andar
        Renderizar();
    }
    
    FimDeJogo();
}

void FimDeJogo()
{
    Console.Clear();  //limpar a tela
    Console.WriteLine("Fim de jogo, pontuação: " + placar);
}

void Renderizar()  //tela
{
    Console.Clear();
    var telaASerRenderizada = "";

    for(int a = 0; a < alturaTela; a++)
    {
        for(int l = 0; l < larguraTela; l++)
        {
            if (tela[l,a] is not null or " ")
            {
                telaASerRenderizada += tela[l,a];
            }
            else
            {
                telaASerRenderizada += " ";
            }
        }

        telaASerRenderizada += "\n";
    }

    Console.Write(telaASerRenderizada);
}

void TransladarCobra()
{
    var cabeça = coordenadasCobra[0];  //coordenadas da cabeça da cobra
    var coordenadaRaboX = coordenadasCobra[^1].X;  //o último item edve acompanhar o penúltimo item
    var coordenadaRaboY = coordenadasCobra[^1].Y;

    for(int i = coordenadasCobra.Count - 1; i > 0; i--)
    {
        coordenadasCobra[i].X = coordenadasCobra[i - 1].X;
        coordenadasCobra[i].Y = coordenadasCobra[i - 1].Y;
    }

    if(direcao is Direcao.Direita)
    {
        cabeça.X++;

        if(cabeça.X > larguraTela -1)
        {
            cabeça.X = 0;
        }
    }
    if (direcao is Direcao.Esquerda)
    {
        cabeça.X--;

        if (cabeça.X < 0)
        {
            cabeça.X = larguraTela - 1;
        }
    }
    if (direcao is Direcao.Cima)
    {
        cabeça.Y--;

        if (cabeça.Y < 0)
        {
            cabeça.Y = alturaTela - 1;
        }
    }
    if (direcao is Direcao.Baixo)
    {
        cabeça.Y++;

        if (cabeça.Y > alturaTela -1)
        {
            cabeça.Y = 0;
        }
    }

    if(tela[cabeça.X, cabeça.Y] == "*")
    {
        placar += random.Next(1, 10);
        coordenadasCobra.Add(new Coordenada(coordenadaRaboX, coordenadaRaboY));
        CriarComida();
    }
    if (tela[cabeça.X, cabeça.Y] == caractereCobra)
    {
        jogoRodando = false;
        return;
    }

    AtualizarPosicaoCobra();
}

void LerTeclas()
{ 
    Thread task = new(LerAcaoDaTecla);
    task.Start();
}
void LerAcaoDaTecla()
{
    while(jogoRodando)
    {
        var tecla = Console.ReadKey();
        //regras da tecla
        if(tecla.Key is ConsoleKey.UpArrow && direcao is not Direcao.Baixo)
        {
            direcao = Direcao.Cima;
        }
        if (tecla.Key is ConsoleKey.DownArrow && direcao is not Direcao.Cima)
        {
            direcao = Direcao.Baixo;
        }
        if (tecla.Key is ConsoleKey.LeftArrow && direcao is not Direcao.Direita)
        {
            direcao = Direcao.Esquerda;
        }
        if (tecla.Key is ConsoleKey.RightArrow && direcao is not Direcao.Esquerda)
        {
            direcao = Direcao.Direita;
        }
    }
}

void CriarComida()  //a comida inicia em um lugar aletório e quando a serpente toca ela cria em outro lugar aleatório
{
    int aleatorioX, aleatorioY;

    do  //estrutura de repetição
    {
        aleatorioX = random.Next(0, larguraTela);
        aleatorioY = random.Next(0, alturaTela);
    } while (tela[aleatorioX, aleatorioY] is not null or " ");

    tela[aleatorioX, aleatorioY] = "*";
}

void CriarCobra()
{
    coordenadasCobra.Add(new Coordenada(9, 14));  //coordenada inicial da serpente
    coordenadasCobra.Add(new Coordenada(8, 14));  
    coordenadasCobra.Add(new Coordenada(7, 14));

    AtualizarPosicaoCobra();   //método que atualiza a posição da serpente na tela
}

void AtualizarPosicaoCobra()  //o método limpa os itens e coloca da posição correta
{
    for(int l = 0; l < larguraTela; l ++)  //estrutura de repetição
    {
        for(int a = 0; a < alturaTela; a ++)
        {
            var posicaoDeveConterCobra = coordenadasCobra.Any(coordenada => coordenada.X == l && coordenada.Y == a);

            if (posicaoDeveConterCobra)
            {
                tela[l, a] = caractereCobra;
                continue;
            }
            if (tela[l,a] == caractereCobra)
            {
                tela[l, a] = " ";
            }
                
        }
    }
}