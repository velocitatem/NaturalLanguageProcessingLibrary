using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaturalLanguageProcessingLibrary.Core.TextCleanup
{
    public class TextProcessor
    {

        private Cleaner[] cleaners = new Cleaner[] { new StopWordCleaner() };
        public enum process
        {
            stopWordClean = 0
        }


        public string CleanText(String input, process[] selected)
        {

            List<Cleaner> cleanersToApply = new List<Cleaner>();
            foreach(process proc in selected) 
            {
                cleanersToApply.Add(cleaners[(int)proc]);
            }

            String output = input;
            foreach(Cleaner cleaner in cleanersToApply)
            {
                output = cleaner.cleanText(output);
            }
            return output;
        }

    }
}
