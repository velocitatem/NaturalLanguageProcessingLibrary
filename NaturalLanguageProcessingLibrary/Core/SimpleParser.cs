using NaturalLanguageProcessingLibrary.Core.FeatureExtraction.PartOfSpeechTagging;
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

            
            // POS TAGGING
            POS pos = new POS();
            Tag[] tags = pos.GenerateTagArray(wordsCre);



            List<Word> words = new List<Word>();
            int p = 0;
            foreach(String w in wordsCre)
            {
                words.Add(new Word(w, tags[p]));
                p += 1;
            }
            //words.AddRange(wordsCre);
            Sentence sentence = new Sentence(words, input);
            return sentence;
        }
    }
}
