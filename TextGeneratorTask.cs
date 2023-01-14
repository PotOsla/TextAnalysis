using System.Collections.Generic;

namespace TextAnalysis
{
    static class TextGeneratorTask
    {
        public static string ContinuePhrase(
            Dictionary<string, string> nextWords,
            string phraseBeginning,
            int wordsCount)
        {
            string[] phrasewords;
            for (int i = 0; i < wordsCount; i++)
            {
                phrasewords = phraseBeginning.Split(new char[] { ' ' });
                string twoLastWords = "";
                string oneLastWords = phrasewords[phrasewords.Length - 1];
                if (phrasewords.Length >= 2)
                {
                    twoLastWords = $"{phrasewords[phrasewords.Length - 2]} {phrasewords[phrasewords.Length - 1]}";
                }
                string temp = "";
                if (nextWords.ContainsKey(twoLastWords))
                {
                    temp = twoLastWords;
                }
                else if (nextWords.ContainsKey(oneLastWords))
                {
                    temp = oneLastWords;
                }
                else break;
                temp = nextWords[temp];
                phraseBeginning = phraseBeginning + " " + temp;
            }
            return phraseBeginning;
        }
    }
}