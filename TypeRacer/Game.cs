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
        private String pathToTextFileFolder = "Texts";
        private String[] allWords;
        private String currentWord;
        private int currentWordIndex = 0;
        private String typedText = "";       
        private Stopwatch sw = new Stopwatch();


        public Game() {

            allWords = GetTextFromRandomTextFile().Split(' ');
            sw.Start();

            while (currentWordIndex != allWords.Length)
            {

                currentWord = allWords[currentWordIndex];
                if (currentWordIndex != allWords.Length - 1) currentWord += " ";

                while (!typedText.Equals(currentWord))
                {
                    RefreshConsole();

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
                currentWordIndex++;
                typedText = "";
            }

            sw.Stop();
            RefreshConsole();
            
        }

        private void RefreshConsole()
        {
            Console.Clear();
            WriteText();
            Console.WriteLine("\n");
            Console.WriteLine(currentWord);

            if (!CheckIfTypedTextIsCorrect()) MarkWordAsMistyped();     
            else Console.WriteLine(typedText);

            Console.WriteLine((float)currentWordIndex / sw.ElapsedMilliseconds * 1000 * 60 + " w/m");
        }

        private bool CheckIfTypedTextIsCorrect()
        {
            if (typedText.Length > currentWord.Length) return false;
            else return currentWord.Substring(0, typedText.Length).Equals(typedText);
        }

        private void WriteText()
        {
            // Written words are green
            Console.ForegroundColor = ConsoleColor.Green;
            for (int i = 0; i < currentWordIndex; i++)
            {
                Console.Write(allWords[i] + " ");
            }

            Console.ForegroundColor = ConsoleColor.Gray;
            for (int i = currentWordIndex; i < allWords.Length; i++)
            {
                Console.Write(allWords[i] + " ");
            }

        }

        private void MarkWordAsMistyped() {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(typedText);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        private String GetTextFromRandomTextFile()
        {
            DirectoryInfo textFileDirectory = new DirectoryInfo(pathToTextFileFolder);
            FileInfo[] textFiles = textFileDirectory.GetFiles("*.txt");

            Random random = new Random();
            int randomNumber = random.Next(0, textFiles.Length);
            String text = File.ReadAllText(pathToTextFileFolder + "//" + textFiles[randomNumber].Name);

            return text;
        }
    }
}
