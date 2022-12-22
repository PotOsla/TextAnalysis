using System.Collections.Generic;

namespace TextAnalysis
{
    static class SentencesParserTask
    {
        private static List<string> GetWords(string sentence)
        {
            var temp = new List<string>();
            string tempword = string.Empty;
            foreach (var bukva in sentence)
            {
                if (char.IsLetter(bukva) || bukva == '\'')
                {
                    tempword += char.ToLower(bukva);
                }
                else if (!string.IsNullOrEmpty(tempword))
                {
                    temp.Add(tempword);
                    tempword = string.Empty;
                }
            }
            if (!string.IsNullOrWhiteSpace(tempword))
            {
                temp.Add(tempword);
            }
            return temp;
        }

        public static List<List<string>> ParseSentences(string text)
        {
            var sentencesList = new List<List<string>>();
            var stringList = text.Split(new char[] { '.', '!', '?', ':', ';', '(', ')' });
            foreach (var sentence in stringList)
            {
                if (string.IsNullOrWhiteSpace(sentence))
                {
                    continue;
                }
                var temp = SentencesParserTask.GetWords(sentence);
                if (temp.Count > 0)
                {
                    sentencesList.Add(temp);
                }
            }
            return sentencesList;
        }
    }
}