using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaturalLanguageProcessingLibrary.Core.TextCleanup
{
    class NonVerbalCleaner : Cleaner
    {
        string Cleaner.cleanText(string text)
        {
            text = String.Join("", text.Split(","));
            return text;
        }
    }
}
