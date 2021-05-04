using NaturalLanguageProcessingLibrary.Core.TextCleanup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaturalLanguageProcessingLibrary.Schemas
{
    public class Text
    {
        private string data { get; set; }
        private string[] dotSplitData { get; set; }
        public Text(string data)
        {
            this.data = data;
            this.dotSplitData = data.Split(". ");
        }
        public TextProcessor.process[] config { get; set; } = new TextProcessor.process[0];

        public List<Sentence> GetRawSentences()
        {
            List<Sentence> sentences = new List<Sentence>();
            foreach (string sentence in this.dotSplitData)
            {
                List<Word> wordsList = new List<Word>();
                foreach(String word in sentence.Split(" ")){
                    wordsList.Add(new Word(word));
                }
                sentences.Add(new Sentence(wordsList, sentence));
            }
            return sentences;
        }

        public List<Sentence> GetCleanedSentences()
        {
            List<Sentence> sentences = new List<Sentence>();
            TextProcessor textProcessor = new TextProcessor();
            foreach (string sentence in this.dotSplitData)
            {
                List<Word> wordsList = new List<Word>();
                String cleanSentence = textProcessor.CleanText(sentence, config);
                foreach (String word in cleanSentence.Split(" "))
                {
                    wordsList.Add(new Word(word));
                }
                sentences.Add(new Sentence(wordsList, cleanSentence));
            }
            return sentences;
        }
    }
}
