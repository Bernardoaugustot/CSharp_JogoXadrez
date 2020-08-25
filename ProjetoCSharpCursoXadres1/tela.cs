using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tabuleiro;
namespace ProjetoCSharpCursoXadres1
{
    class tela
    {
        public static void imprimirTabuleiro(Tabuleiro tab)
        {
            for(int l=0; l < tab.linhas; l++)
            {
                Console.Write(8-l + " ");
                for(int c=0; c<tab.colunas; c++)
                {

                    if(tab.peca(l, c) == null)
                    {
                        Console.Write("- ");
                    }
                    Console.Write(tab.peca(l, c) + " ");
                }
            }

            Console.Write("  A B C D E F G H");
        }
    }
}
