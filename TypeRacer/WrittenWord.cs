using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeRacer
{
    class WrittenWord: Word
    {
        public WrittenWord(String word) : base(word) {

        }

        public override void PrintWord() {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(word);
            
        }

        
    }
}
