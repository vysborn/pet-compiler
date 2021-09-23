using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableBuilder
{
    class TableMaker
    {
        private Grammar grammar;
        private CustomTable table;
        public TableMaker(Grammar grammar)
        {
            this.grammar = grammar;
            table = new CustomTable(grammar.GetAllItems());
        }

        public string[,] GetTable()
        {
            return table.GetTable();
        }

        public int GetLength()
        {
            return table.Length;
        }

        public void MakeTable()
        {
            MakeEq();
            MakeLess();
            MakeGreater();
        }

        public void MakeEq()
        {
            foreach (var key in grammar.GetKeys())
            {
                bool isFirst = true;
                List<List<string>> list = grammar.GetSuquence(key);
                foreach (var lst in list)
                {
                    string prevItem = "";
                    foreach (var item in lst)
                    {
                        if (isFirst)
                        {
                            isFirst = false;
                        }
                        else
                        {
                            if (table[item, prevItem].Equals("") || table[item, prevItem].Equals("="))
                                table[prevItem, item] = "=";
                            else
                                Console.WriteLine("EQ ", item, " ", prevItem, "\n");
                        }
                        prevItem = item;
                    }
                }
              
            }
        }

        public void MakeLess()
        {
            foreach (var V in grammar.GetAllItems())
            {
                List<string> list = new List<string>();
                grammar.First(V, list);
                foreach (var S in list)
                {
                    foreach (var R in grammar.GetAllItems())
                    {
                        if (!S.Equals("|") && !R.Equals("|") && !V.Equals("|")
                            && table[R, V].Equals("=")
                            && !grammar.GetExceptions().Contains(V))
                        {
                            if (table[R, S].Equals("") || table[R,S].Equals("<"))
                                table[R, S] = "<";
                            else
                                Console.WriteLine("Less " + R + " " + S);
                        }
                    }
                    
                }
            }
        }

        public void MakeGreater()
        {
            foreach (var V in grammar.GetAllItems())
            {
                foreach (var W in grammar.GetAllItems())
                {
                    //Console.WriteLine(table[V, W]);
                    if (table[V,W].Equals("="))
                    {
                        List<string> last = new List<string>();
                        List<string> first = new List<string>();
                        grammar.Last(V, last);
                        //last.Add(V);
                        grammar.First(W, first);
                        if (!grammar.GetExceptions().Contains(W))
                            first.Add(W);
                        foreach (var S in first)
                        {
                            foreach (var R in last)
                            {
                                //if (!grammar.GetExceptions().Contains(W))
                                //{
                                    if (table[R, S].Equals("") || table[R,S].Equals(">"))
                                        table[R, S] = ">";
                                    else
                                        Console.WriteLine("Greater " + R + " " + S);
                                //}
                            }
                        }
                    }
                }
            }
        }
    }
}
