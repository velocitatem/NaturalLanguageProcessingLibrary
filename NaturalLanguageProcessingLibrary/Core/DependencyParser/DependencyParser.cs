using NaturalLanguageProcessingLibrary.Dependencies;
using NaturalLanguageProcessingLibrary.Schemas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaturalLanguageProcessingLibrary.Core.DependecyParser
{
    public class DependencyParser
    {
        private HIF hif = new HIF("DependencyParser");
        DependencyTree tree = new DependencyTree();
        public DependencyTree Parse(Sentence sentence)
        {
            List<Relation> relations = new List<Relation>();

            Oracle oracle = new Oracle();
            Stack stack = new Stack();

//            hif.Out("Starting loop");
            while ( sentence.words.Count > 0) 
            {                
                Oracle.operation operation = oracle.evaluate(stack);
//                hif.Out(operation.ToString());
                if (operation.Equals(Oracle.operation.shift))
                {
                    stack.add(sentence.next());
                    new HIF("STEP").Out("added to stack");
                }
                else
                {
                    Relation r = stack.executeOperations(operation);
                    if (r != null)
                    {
                        new HIF("STEP").Out("executed " + operation);
                        relations.Add(r);
                    }
                }
            }
//            hif.Out("loop ended");


            foreach(Relation r in relations)
            {
                hif.Out(r.ToString());
            }


            return this.tree;
        }
    }
}
