using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaturalLanguageProcessingLibrary.Schemas
{
    public class Sentence
    {

        /// <summary>
        /// Create a new Sentence Object, which can then be passed to NLP modules
        /// </summary>
        /// <param name="words"></param>
        /// <param name="original"></param>
        public Sentence(List<String> words, string original)
        {
            this.words = words;
            this.original = original;
        }

        public string next()
        {
            string val = words[0].Trim();
            words.Remove(words[0]);
            return val;
        }
        public List<String> words { get; set; }
        public string original { get; set; }
    }
}
