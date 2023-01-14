using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;

namespace TextAnalysis
{
    static class FrequencyAnalysisTask
    {
        public static Dictionary<string, string> GetMostFrequentNextWords(List<List<string>> text)
        {
            var result = new Dictionary<string, string>();
            var counter = new Dictionary<string, Dictionary<string, int>>();
            foreach (var sentence in text)
            {
                for (var index = 0; index < sentence.Count - 1; index++)
                {
                    var second = sentence[index + 1];
                    var word = sentence[index];
                    AddGramm(counter, word, second);
                    if (index < sentence.Count - 2)
                    {
                        var doubleWord = $"{word} {second}";
                        var third = sentence[index + 2];
                        AddGramm(counter, doubleWord, third);
                    }
                }

            }
            foreach (var i in counter)
            {
                var alpha = i.Key;
                var omega = i.Value;
                int maxtemp = 0;
                foreach (var n in omega)
                {
                    if (n.Value > maxtemp)
                    {
                        maxtemp = n.Value;
                    }
                }
                var tempword = "";
                foreach (var word in omega)
                {
                    if (word.Value == maxtemp)
                    {
                        if (!string.IsNullOrEmpty(tempword))
                        {
                            int compare = string.CompareOrdinal(tempword, word.Key);
                            if (compare > 0)
                            {
                                tempword = word.Key;
                            }
                        }
                        else tempword = word.Key;
                    }
                }
                result.Add(alpha, tempword);
            }
            return result;
        }

        private static void AddGramm(Dictionary<string, Dictionary<string, int>> counter, string word, string second)
        {
            if (!counter.ContainsKey(word))
            {
                counter.Add(word, new Dictionary<string, int>());
            }
            if (!counter[word].ContainsKey(second))
            {
                counter[word].Add(second, 0);
            }
            counter[word][second]++;
        }
    }
}