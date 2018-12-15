using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeRacer
{

    class PlayerInput
    {
        private String typedText = "";

        public PlayerInput() {

        }

        public void ClearPlayerText() {
            typedText = "";
        }

        public void HandlePressedKey() {
            ConsoleKeyInfo pressedKey = Console.ReadKey();
            if (!pressedKey.Key.Equals(ConsoleKey.Enter))
            {
                if (pressedKey.Key.Equals(ConsoleKey.Backspace))
                {
                    if (typedText.Length > 0)
                    {
                        typedText = typedText.Remove(typedText.Length - 1);
                    }
                }
                else typedText += pressedKey.KeyChar.ToString();
            }
        }

        public string getTypedText() {
            return typedText;
        }

    }
}
