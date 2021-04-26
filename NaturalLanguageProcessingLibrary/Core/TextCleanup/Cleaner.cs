using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaturalLanguageProcessingLibrary.Core.TextCleanup
{
    public interface Cleaner
    {
        string cleanText(String text);
    }
}
