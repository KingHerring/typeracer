using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeRacer
{
    class GameRules
    {
        private Text text;
        private PlayerInput playerInput;

        public GameRules(Text text, PlayerInput playerInput)
        {
            this.text = text;
            this.playerInput = playerInput;
        }

        public bool Finished() {
            return text.getCurrentWordIndex() == text.getLength();
        }

        public bool WordIsWritten() {
            return playerInput.getTypedText().Equals(text.getCurrentWord().ToString());
        }

        public void NextWord()
        {
            text.moveToNextWord();
            playerInput.ClearPlayerText();
        }

        public bool CheckIfTypedTextIsCorrect()
        {
            if (playerInput.getTypedText().Length > text.getCurrentWord().ToString().Length) return false;
            else return text.getCurrentWord().ToString().Substring(0, playerInput.getTypedText().Length).Equals(playerInput.getTypedText());
        }
    }
}
