using NaturalLanguageProcessingLibrary.Schemas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaturalLanguageProcessingLibrary.Core
{
    public class Oracle
    {

        public enum operation
        {
            leftArc,
            rightArc,
            shift
        }

        public operation evaluate(Stack stack)
        {
            operation[] operations = new operation[] { operation.leftArc, operation.rightArc, operation.shift };
            int pos = (int)(new Random().Next(0, operations.Length));
            return operations[pos];
        }
    }
}
