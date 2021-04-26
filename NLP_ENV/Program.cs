using NaturalLanguageProcessingLibrary.Core;
using NaturalLanguageProcessingLibrary.Dependencies;
using NaturalLanguageProcessingLibrary.Schemas;
using System;

namespace NLP_ENV
{
    class Program
    {
        static void Main(string[] args)
        {
            


            int its = 10;
            for (int it = 0; it < its; it += 1)
            {
                new HIF("").gap(3);
                new DependencyParser().Parse(new SimpleParser().generateSentence("Boil the eggs and apples for 10 minutes"));
                new HIF("").gap(3);

            }

        }
    }
}
