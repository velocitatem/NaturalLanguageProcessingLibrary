using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaturalLanguageProcessingLibrary.Dependencies
{
    public class HIF
    {

        private static int maxLength = 0;
        public string consumer = "";
        private string padding = "";

        public HIF(String nm)
        {
            this.consumer = nm;
            if(nm.Length > maxLength)
            {
                maxLength = nm.Length;

            }

            int rem = maxLength- nm.Length;
            int halfPadding = (int)Math.Round((double)(rem / 2), 2);
            for(int i = 0; i < halfPadding; i+=1)
            {
                padding += " ";
            }

        }

        public void gap(int size)
        {
            for(int i = 0; i < size; i += 1)
            {
                Console.WriteLine();
            }
        }
        public void Out(String data) {
            Console.WriteLine("\n[{0}{1}{2}]\t{3}\n", padding, consumer, padding, data);
        }
    }
}
