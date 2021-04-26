using NaturalLanguageProcessingLibrary.Dependencies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NaturalLanguageProcessingLibrary.Core.Oracle;

namespace NaturalLanguageProcessingLibrary.Schemas
{
    public class Stack 
    {

        private HIF hif;

        public Stack()
        {
            hif = new HIF("Stack");
            this.data = new List<String>();
            this.data.Add("root");
        }


        public Relation executeOperations(operation operation)
        {
            int s = this.data.Count;
            Relation relation = null;                        
            if(s-2>0)
            {
                hif.Out(String.Format("last pair [{0}, {1}] ", this.data[s - 2], this.data[s - 1]));
                switch (operation)
                {
                    case operation.leftArc:
                        relation = new Relation(this.data[s-1], this.data[s - 2], Relation.relation.head);
                        this.data.Remove(this.data[s - 2]);
                        break;
                    case operation.rightArc:
                        relation = new Relation(this.data[s - 2], this.data[s-1], Relation.relation.head);
                        this.data.Remove(this.data[s - 1]);
                        break;
                    default:
                        break;
                }
            }
            return relation;
        }


        public void pop(int index)
        {
            this.data.Remove(this.data[index]);
        }

        public string[] topPair()
        {
            return new string[] { data[data.Count-1], data[data.Count-2] };
        }

        public string get(int index)
        {
            return data[index];
        }

        public void add(string data)
        {
            this.data.Add(data);
        }
        
        
        public bool isFinal()
        {
            return data.Count.Equals(1);
        }

        public void addAll(string[] data)
        {
            foreach(string dat in data)
            {
                this.data.Add(dat);
            }
        }

        public override string ToString()
        {
            return String.Join(", ", data);
        }

        public List<String> data { get; set; }
    }
}
