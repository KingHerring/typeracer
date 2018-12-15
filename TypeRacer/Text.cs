using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TypeRacer
{
    class Text
    {
        private static String pathToTextFileFolder = "Texts";
        private Word[] allWordsObj;
        private int currentWordIndex;

        public Text() {
            String[] allWords = GetTextFromRandomTextFile().Split(' ');
            AddSpacingToWords(allWords);
            ConvertStringsToWordObjects(allWords);
            currentWordIndex = 0;
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

        private void AddSpacingToWords(String[] allWords) {
            for (int i = 0; i < allWords.Length - 1; i++)
                allWords[i] += " ";
        }

        private void ConvertStringsToWordObjects(String[] allWords) {
            allWordsObj = new Word[allWords.Length];
            for (int i = 0; i < allWords.Length; i++) {
                allWordsObj[i] = new NotYetWrittenWord(allWords[i]);
            }
        }

        public int getLength() {
            return allWordsObj.Length;
        }

        public int getCurrentWordIndex() {
            return currentWordIndex;
        }

        public Word getCurrentWord() {
            if (currentWordIndex >= allWordsObj.Length) return null;

            return allWordsObj[currentWordIndex];
        }

        public void moveToNextWord()
        {
            WrittenWord ww = new WrittenWord(allWordsObj[currentWordIndex].ToString());
            allWordsObj[currentWordIndex] = ww;
            if(currentWordIndex < allWordsObj.Length)
            currentWordIndex++;
        }

        public Word[] getAllWords() {
            return allWordsObj;
        }
    }
}
