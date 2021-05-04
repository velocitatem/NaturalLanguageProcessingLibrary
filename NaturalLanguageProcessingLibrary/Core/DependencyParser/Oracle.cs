using NaturalLanguageProcessingLibrary.Core.FeatureExtraction.PartOfSpeechTagging;
using NaturalLanguageProcessingLibrary.Schemas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaturalLanguageProcessingLibrary.Core.DependecyParser
{
    public class Oracle
    {
        
        public Oracle(Sentence sentece)
        {
            this.sentence = sentence;            
        }

        private Sentence sentence { get; set; }
        public Tag[] tags { get; set; }

        public enum operation
        {
            leftArc,
            rightArc,
            shift
        }

        public operation evaluate(Stack stack, int remaining)
        {

            try
            {
                Word[] top = stack.topPair();

                foreach (Word w in top)
                {
                    Console.Write(w.tag + "|");
                }
                Console.WriteLine();
            }
            catch (Exception e)
            {

            }
            if (stack.data.Count == 1)
            {
                return operation.shift;
            }
            else if(remaining == 0)
            {
                operation[] operations = new operation[] { operation.leftArc, operation.rightArc };
                int pos = new Random().Next(0, operations.Length);
                return operations[pos];
            }
            else
            {
                operation[] operations = new operation[] { operation.leftArc, operation.rightArc, operation.shift };
                int pos = new Random().Next(0, operations.Length);
                return operations[pos];
            }
            
        }
    }
}
