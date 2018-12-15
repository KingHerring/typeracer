using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeRacer
{
    abstract class Word
    {
        protected String word;

        public Word(String word) {
            this.word = word;
        }

        public abstract void PrintWord();

        override public String ToString() {
            return word;
        }


    }
}
