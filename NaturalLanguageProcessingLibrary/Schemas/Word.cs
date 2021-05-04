using NaturalLanguageProcessingLibrary.Core.FeatureExtraction.PartOfSpeechTagging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaturalLanguageProcessingLibrary.Schemas
{
    public class Word
    {
        public string word { get; set; }
        public Tag tag { get; set; }    
        public Word(string w)
        {
            this.word = w;
        }

        public override string ToString()
        {
            return this.word + "\\" + this.tag.ToString();
        }

        public Word(string w, Tag t)
        {
            this.word = w;
            this.tag = t;
        }
    }
}
