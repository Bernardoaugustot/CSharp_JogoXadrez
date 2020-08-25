using ProjetoCSharpCursoXadres1.xadrez;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tabuleiro;
using xadrez;

namespace ProjetoCSharpCursoXadres1
{
    class Program
    {
        static void Main(string[] args)
        {

            PosicaoXadrez pos = new PosicaoXadrez('a', 1);
            Console.WriteLine(pos);
            Console.WriteLine(pos.ToPosicao());
            /*
            Tabuleiro tab = new Tabuleiro(8, 8
            tab.colocarPeca(new Torre(tab, Cor.preta), new Posicao(0, 0));
            tab.colocarPeca(new Rei(tab, Cor.preta), new Posicao(2, 4));
            tab.colocarPeca(new Peao(tab, Cor.preta), new Posicao(2, 2));
            tela.imprimirTabuleiro(tab);
            */
            Console.WriteLine("Teste bem sucedido");
            Console.ReadLine();
        }
    }
}
