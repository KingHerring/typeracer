using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace TypeRacer
{
    class Display
    {
        private Text text;
        private PlayerInput playerInput;
        private Stopwatch stopwatch;
        private GameRules gameRules;
        private const int MinutesToSecondsMultiplier = 60000;

        public Display(Text text, PlayerInput playerInput, GameRules gameRules, Stopwatch stopwatch) {
            this.text = text;
            this.playerInput = playerInput;
            this.stopwatch = stopwatch;
            this.gameRules = gameRules;
        }

        public void RefreshConsole()
        {
            Console.Clear();
            WriteText();
            Console.WriteLine("\n");

            if (text.getCurrentWord() != null)
            {
                Console.WriteLine(text.getCurrentWord().ToString());
                if (!gameRules.CheckIfTypedTextIsCorrect()) MarkWordAsMistyped();
                else Console.WriteLine(playerInput.getTypedText());
            }

            Console.WriteLine((float)text.getCurrentWordIndex() / stopwatch.ElapsedMilliseconds * MinutesToSecondsMultiplier + " w/m");
        }

        private void WriteText()
        {
            Word[] allWords = text.getAllWords();
            foreach (Word word in allWords) {
                word.PrintWord();
            }
        }

        private void MarkWordAsMistyped()
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(playerInput.getTypedText());
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
        }

    }
}
