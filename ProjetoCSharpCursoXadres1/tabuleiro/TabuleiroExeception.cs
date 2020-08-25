using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoCSharpCursoXadres1.tabuleiro
{
    class TabuleiroExeception : Exception
    {

        public TabuleiroExeception(string msg) : base(msg)
        {

        }
    }
}
