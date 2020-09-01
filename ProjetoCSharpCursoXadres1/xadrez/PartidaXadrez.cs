using ProjetoCSharpCursoXadres1.tabuleiro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tabuleiro;
using xadrez;


namespace ProjetoCSharpCursoXadres1.xadrez
{
    class PartidaXadrez
    {
        public Tabuleiro tab { get; private set; }
        public int turno;
        public Cor jogadorAtual { get; private set; }
        public bool Terminada { get; private set; }
        private HashSet<Peca> pecas;
        private HashSet<Peca> capturadas;

        public PartidaXadrez()
        {
            tab = new Tabuleiro(8, 8);
            turno = 1;
            jogadorAtual = Cor.branca;
            Terminada = false;
            pecas = new HashSet<Peca>();
            capturadas = new HashSet<Peca>();
            colocarPecas();
        }

        public void executarMovimento(Posicao origem, Posicao destino)
        {
            Peca p = tab.retirarPeca(origem);
            p.incrementarMovimento();
            Peca pecaCapturada = tab.retirarPeca(destino);
            tab.colocarPeca(p, destino);
            if (pecaCapturada != null)
            {
                capturadas.Add(pecaCapturada);
            }
        }
        public HashSet<Peca> pecasCapturadas(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach(Peca x in capturadas)
            {
                if( x.cor == cor)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }

        public HashSet<Peca>PecasEmJogo(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in pecas)
            {
                if (x.cor == cor)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(pecasCapturadas(cor));
            return aux;
        }


        public void realizaJogada(Posicao origem, Posicao destino)
        {
            executarMovimento(origem, destino);
            turno++;
            mudarJogador();
        }

        public void validarPosicaoDeOrigem(Posicao posicao) //Throws para definir as regra de jogabilidade do Programa.
        {
            if (tab.peca(posicao) == null)
            {
                throw new TabuleiroExeception("Não existe peça na posição de origem escolidada");
            }
            if (jogadorAtual != tab.peca(posicao).cor)
            {
                throw new TabuleiroExeception("Peça escolida é diferente do jogador atual.");
            }
            if (!tab.peca(posicao).existeMovimentoPossiveis())
            {
                throw new TabuleiroExeception("Não há movimentos possiveis para a pesa atual.");
            }
        }

        public void validarPosicaoDeDestino(Posicao origem, Posicao destino)
        {
            if (!tab.peca(origem).podeMoverPara(destino))
            {
                throw new TabuleiroExeception("Posição de destino invalida!!!");
            }
        }
        private void mudarJogador()
        {
            if (jogadorAtual == Cor.branca)
            {
                jogadorAtual = Cor.preta;
            }
            else
            {
                jogadorAtual = Cor.branca;
            }
        }
        public void realizJogada(Posicao origem, Posicao destino)
        {

        }

        public void colocaNovaPeca(char coluna, int linha, Peca peca)
        {
            tab.colocarPeca(peca, new PosicaoXadrez(coluna, linha).ToPosicao());
            pecas.Add(peca);
        }
        private void colocarPecas()
        {



            //tab.colocarPeca(new Torre(tab, Cor.preta), new PosicaoXadrez('a', 8).ToPosicao());
            colocaNovaPeca('c', 8, new Rei(tab, Cor.preta));
            colocaNovaPeca('c', 1, new Rei(tab, Cor.branca));

            colocaNovaPeca('a', 8, new Torre(tab, Cor.preta));
            colocaNovaPeca('h', 8, new Torre(tab, Cor.preta));
            colocaNovaPeca('a', 1, new Torre(tab, Cor.branca));
            colocaNovaPeca('h', 1, new Torre(tab, Cor.branca));




            //peãos negros
            colocaNovaPeca('b', 6, new Peao(tab, Cor.preta));
            colocaNovaPeca('b', 7, new Peao(tab, Cor.preta));
            colocaNovaPeca('c', 7, new Peao(tab, Cor.preta));
            colocaNovaPeca('d', 7, new Peao(tab, Cor.preta));
            colocaNovaPeca('e', 7, new Peao(tab, Cor.preta));
            colocaNovaPeca('f', 7, new Peao(tab, Cor.preta));
            colocaNovaPeca('g', 7, new Peao(tab, Cor.preta));
            colocaNovaPeca('h', 7, new Peao(tab, Cor.preta));
            //peao brnacos
            colocaNovaPeca('a', 2, new Peao(tab, Cor.branca));
            colocaNovaPeca('b', 2, new Peao(tab, Cor.branca));
            colocaNovaPeca('c', 2, new Peao(tab, Cor.branca));
            colocaNovaPeca('d', 2, new Peao(tab, Cor.branca));
            colocaNovaPeca('e', 2, new Peao(tab, Cor.branca));
            colocaNovaPeca('f', 2, new Peao(tab, Cor.branca));
            colocaNovaPeca('g', 2, new Peao(tab, Cor.branca));
            colocaNovaPeca('h', 2, new Peao(tab, Cor.branca));
        }
    }
}
