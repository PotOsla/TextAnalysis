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
            var counter = new Dictionary<string, int>();
            foreach (var sentence in text)
            {
                foreach (var word in sentence)
                {
                    var index = sentence.IndexOf(word);
                    if (index + 1 < sentence.Count)
                    {
                        var doubleWord = word + "," + sentence[index + 1];
                        if (counter.ContainsKey(doubleWord))
                        {
                            counter[doubleWord]++;
                        }
                        else
                        {
                            counter[doubleWord] = 1;
                        }
                        if (index + 2 < sentence.Count)
                        {
                            var tripleWord = doubleWord + "," + sentence[index + 2];
                            if (!counter.ContainsKey(tripleWord)) counter[tripleWord] = 0;
                            counter[tripleWord]++;
                        }
                    }
                }
            }
            return result;
        }
   }
}