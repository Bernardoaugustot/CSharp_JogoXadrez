using ProjetoCSharpCursoXadres1.tabuleiro;
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
            try
            {
                PartidaXadrez partida = new PartidaXadrez();

                while (!partida.Terminada)
                {
                    try
                    {
                        Console.Clear();
                        tela.imprimirPartida(partida);

                        Console.WriteLine();
                        Console.Write("Digite a posição de Origem:(a1)");
                        
                            Posicao origem = tela.lerposicaoXadrez().ToPosicao();
                        
                        partida.validarPosicaoDeOrigem(origem);
                        Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("Turno " + partida.turno +" - peça selecionada.");
                        Console.WriteLine("Aguardando Jogada:" + partida.jogadorAtual);

                        bool[,] posicoesPossiveisX = partida.tab.peca(origem).movimentosPossiveis();
                        tela.imprimirTabuleiro(partida.tab, posicoesPossiveisX); // tabuleiro marcado

                        Console.Write("Digite a Destino:");
                        Posicao destino = tela.lerposicaoXadrez().ToPosicao();
                        partida.validarPosicaoDeDestino(origem, destino);
                        partida.realizaJogada(origem, destino);

                        Console.WriteLine(partida.turno + "Jogada N realizada");
                    }
                    
                    catch (TabuleiroExeception e)
                    {
                        Console.WriteLine(e.Message + "Press Start To next");
                        Console.ReadLine();
                    }
                }
                
            }
            catch (TabuleiroExeception e)
            {
                Console.WriteLine("ERRO FORA DO WHILE");
                Console.WriteLine(e.Message);
                Console.WriteLine();
            }


            Console.WriteLine("Teste bem sucedido");
            Console.ReadLine();
        }
    }
}
