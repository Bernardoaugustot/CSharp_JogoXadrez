using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tabuleiro;
namespace ProjetoCSharpCursoXadres1.xadrez
{
    class Peao : Peca
    {

        public Peao(Tabuleiro tab, Cor cor) : base(tab, cor)
        {

        }

        public override bool[,] movimentosPossiveis()
        {
            bool[,] mat = new bool[tab.linhas, tab.colunas];

            Posicao pos = new Posicao(0, 0);

            if(this.cor == Cor.preta){
                pos.definirValores(posicao.linha + 1, posicao.coluna);
                if (tab.posicaoValida(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }
            }
            if (this.cor == Cor.branca)
            {
                pos.definirValores(posicao.linha - 1, posicao.coluna);
                if (tab.posicaoValida(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }
            }
            return mat;
        }

        public override string ToString()
        {
            return "P";
        }

    }
}
