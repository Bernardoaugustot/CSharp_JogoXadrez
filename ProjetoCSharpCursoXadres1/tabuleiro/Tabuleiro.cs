using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tabuleiro
{
    class Tabuleiro
    {
        public int linhas { get; set; }
        public int colunas { get; set; }
        public Peca[,] pecas;

        public Tabuleiro(int linhas, int colunas)
        {
            this.linhas = linhas;
            this.colunas = colunas;
            pecas = new Peca[linhas, colunas];
        }

        public Peca peca(int l, int c)
        {
            return pecas[l, c];
        }

        public void colocarPeca(Peca p, Posicao posicao)
        {
            pecas[posicao.linha, posicao.coluna] = p;
            p.posicao = posicao;

        }

    }
}
