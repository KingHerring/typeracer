using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace TypeRacer
{
    class Game
    {
        public Game() {

            Stopwatch sw = new Stopwatch();
            Text text = new Text();
            PlayerInput input = new PlayerInput();
            GameRules gameRules = new GameRules(text, input);
            Display display = new Display(text, input, gameRules, sw);
            sw.Start();

            while (!gameRules.Finished())
            {
                while (!gameRules.WordIsWritten())
                {
                    display.RefreshConsole();
                    input.HandlePressedKey();
                }
                gameRules.NextWord();
            }

           sw.Stop();
           display.RefreshConsole();
            
        }
    }
}
