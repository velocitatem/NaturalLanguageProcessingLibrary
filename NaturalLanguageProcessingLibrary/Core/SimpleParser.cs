using NaturalLanguageProcessingLibrary.Schemas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaturalLanguageProcessingLibrary.Core
{
    public class SimpleParser
    {
        public Sentence generateSentence(string input)
        {
            string[] data = input.Split(",");
            input = String.Join("", data);
            string[] wordsCre = input.Split(" ");
            List<String> words = new List<string>();
            words.AddRange(wordsCre);
            Sentence sentence = new Sentence(words, input);
            return sentence;
        }
    }
}
