using ProjetoCSharpCursoXadres1.tabuleiro;
using System;
using System.CodeDom;
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

        public Peca peca(Posicao posicao)
        {
            return pecas[posicao.linha, posicao.coluna];
        }

        public bool existePeca(Posicao posicao)
        {
            validarPosicao(posicao);
            return peca(posicao) != null;
        }

        public void colocarPeca(Peca p, Posicao posicao)
        {
            if (existePeca(posicao))
            {
                throw new TabuleiroExeception(p + ", " + posicao + ". Ja existe uma peça na posição alvo");
            }
            pecas[posicao.linha, posicao.coluna] = p;
            p.posicao = posicao;

        }

        public Peca retirarPeca(Posicao posicao)
        {
            if (peca(posicao) == null)
            {
                return null;
            }
            Peca aux = peca(posicao);
            aux.posicao = null;
            pecas[posicao.linha, posicao.coluna] = null;
            return aux;
        }

        public bool posicaoValida(Posicao posicao)
        {
            if (posicao.linha < 0 || posicao.coluna < 0
                || posicao.linha >= linhas || posicao.coluna >= colunas)
            {
                return false;
            }
            return true;
        }
        public void validarPosicao(Posicao posicao)
        {
            if (!posicaoValida(posicao))
            {
                throw new TabuleiroExeception(posicao + ". Posição fora do tabuleiro");
            }
        }
    }
}
