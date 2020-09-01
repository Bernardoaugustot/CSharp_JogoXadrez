using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tabuleiro;
namespace ProjetoCSharpCursoXadres1.xadrez
{
    class Torre : Peca
    {

        public Torre(Tabuleiro tab, Cor cor) : base(tab, cor)
        {

        }


        private bool podeMover(Posicao posicao)
        {
            Peca p = tab.peca(posicao);
            return p == null || p.cor != this.cor;
        }

        public override bool[,] movimentosPossiveis()
        {
            bool[,] mat = new bool[tab.linhas, tab.colunas];

            Posicao pos = new Posicao(0, 0);

            
            //Acima
            pos.definirValores(posicao.linha - 1, posicao.coluna);
            while (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if (tab.peca(pos) !=null && tab.peca(pos).cor != cor) //detectar coluzão
                {
                    break;
                }
                pos.linha =pos.linha -1; //COntador
            }
            //abaixo
            pos.definirValores(posicao.linha + 1, posicao.coluna);
            while (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if (tab.peca(pos) != null && tab.peca(pos).cor != cor) //detectar coluzão
                {
                    break;
                }
                pos.linha = pos.linha + 1; //COntador
            }
            //Direita
            pos.definirValores(posicao.linha , posicao.coluna -1);
            while (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if (tab.peca(pos) != null && tab.peca(pos).cor != cor) //detectar coluzão
                {
                    break;
                }
                pos.coluna = pos.coluna- 1; //COntador
            }
            //Direita
            pos.definirValores(posicao.linha, posicao.coluna + 1);
            while (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if (tab.peca(pos) != null && tab.peca(pos).cor != cor) //detectar coluzão
                {
                    break;
                }
                pos.coluna = pos.coluna + 1; //COntador
            }

            return mat;
        }
        public override string ToString()
        {
            return "T";
        }

    }
}
