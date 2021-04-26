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
            String data = File.ReadAllText("../../../Dependencies/stopwords.json");
            StopWords stopWords = JsonSerializer.Deserialize<StopWords>(data);
            return data;
        }
    }
}
