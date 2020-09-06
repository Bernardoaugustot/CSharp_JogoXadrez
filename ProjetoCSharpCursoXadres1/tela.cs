using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tabuleiro;
using xadrez;
using ProjetoCSharpCursoXadres1.xadrez;

namespace ProjetoCSharpCursoXadres1
{
    class tela
    {
        public static void imprimirPartida(PartidaXadrez partida)
        {
            Console.WriteLine("Turno " + partida.turno);
            Console.WriteLine("Aguardando Jogada:" + partida.jogadorAtual);
            imprimirPecasCapturadas(partida);
            tela.imprimirTabuleiro(partida.tab);
            if (partida.xeque)
            {
                Console.WriteLine("XEQUE!!");
            }
        }

        public static void imprimirPecasCapturadas(PartidaXadrez partida)
        {
            Console.WriteLine("Peças capturadas: ");
            Console.Write("Brancas:");
            imprimirConjunto(partida.pecasCapturadas(Cor.Branca));
            Console.Write("Pretas: ");
            imprimirConjunto(partida.pecasCapturadas(Cor.Preta));
            
        }
        public static void imprimirConjunto(HashSet<Peca> conjunto)
        {
            Console.Write(" [");
            foreach (Peca x in conjunto)
            {
                Console.Write(x + " ");

            }
            Console.WriteLine(" ]");
            
        }

        public static void imprimirTabuleiro(Tabuleiro tab)
        {
            ConsoleColor fundo = Console.BackgroundColor;
            ConsoleColor fundoAlterado = ConsoleColor.DarkGray;



            for(int l=0; l < tab.linhas; l++)  // Imprimindo na Tela o Tabuleiro.
            {
                Console.Write(8-l + " ");
                for(int c=0; c<tab.colunas; c++)
                {
                   
                    imprimirPeca(tab.peca(l, c));
                    Console.BackgroundColor = fundo;
                }
                Console.WriteLine();
            }
            Console.Write("  A B C D E F G H   ## ");
        }

        public static void imprimirTabuleiro(Tabuleiro tab, bool[,] posicoesPossiveis)
        {
            ConsoleColor fundo = Console.BackgroundColor;
            ConsoleColor fundoAlterado = ConsoleColor.DarkGray;



            for (int l = 0; l < tab.linhas; l++)  // Imprimindo na Tela o Tabuleiro.
            {
                Console.Write(8 - l + " ");
                for (int c = 0; c < tab.colunas; c++)
                {
                    if (posicoesPossiveis[l, c] == true) 
                    {
                        Console.BackgroundColor = fundoAlterado;
                    }
                    imprimirPeca(tab.peca(l, c));
                    Console.BackgroundColor = fundo;
                }
                Console.WriteLine();
            }
            Console.Write("  A B C D E F G H   ## ");
        }
        public static PosicaoXadrez lerposicaoXadrez()
        {
            try
            {
                string s = Console.ReadLine();
                char coluna = s[0];
                int linha = int.Parse(s[1] + "");

                return new PosicaoXadrez(coluna, linha);
            }
            catch(Exception e)
            {
                Console.WriteLine("Ordem de caracteres errada");
                return null;
            }
        }




        public static void imprimirPeca(Peca peca)
        {
            if (peca == null)
            {
                Console.Write("- ");
            }
            else
            {
                try
                {
                    if (peca.cor == Cor.Branca)
                    {
                        Console.Write(peca + " ");
                    }
                    else
                    {
                        ConsoleColor aux = Console.ForegroundColor;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(peca + " ");
                        Console.ForegroundColor = aux;
                    }
                }
                catch (NullReferenceException e)
                {
                    Console.WriteLine("? ");
                }
            }
        }
    }
}
