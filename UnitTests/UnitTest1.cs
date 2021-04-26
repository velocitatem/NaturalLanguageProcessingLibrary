using Microsoft.VisualStudio.TestTools.UnitTesting;
using NaturalLanguageProcessingLibrary.Schemas;
using NaturalLanguageProcessingLibrary.Core;
using System.IO;
using System;
namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {

            string ogText = "A ti84 calculator is the best";

            Sentence sentence1 = new SimpleParser().generateSentence(ogText);

            DependencyParser dependencyParser = new DependencyParser();
            dependencyParser.Parse(sentence1);


        }
    }
}
