using NaturalLanguageProcessingLibrary.Core.TextCleanup.Shemas;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace NaturalLanguageProcessingLibrary.Core.TextCleanup
{
    public class StopWordCleaner : Cleaner
    {
        

        string Cleaner.cleanText(string text)
        {
            string[] words = text.Split(" ");
            List<String> wordList = new List<string>();
            List < String > output = new List<string>();
            wordList.AddRange(words);
            output.AddRange(words);
            String data = File.ReadAllText("../../../Dependencies/stopwords.json");
            StopWords stopWords = JsonSerializer.Deserialize<StopWords>(data);
            int index = 0, removed = 0;
            foreach(string word in wordList)
            {
                string safeWord = word.Trim().ToLowerInvariant();
                if(stopWords.stopwords.Contains(safeWord))
                {
                    output.RemoveAt(index-removed);
                    removed += 1;
                }
                index += 1;
            }
            return String.Join(" ", output);
        }
    }
}
