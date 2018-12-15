using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeRacer
{
    class NotYetWrittenWord: Word
    {

        public NotYetWrittenWord(String word) : base(word)
        {

        }

        public override void PrintWord()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(word);
        }

    }
}
