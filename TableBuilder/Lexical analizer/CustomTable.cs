using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableBuilder
{
    class CustomTable
    {
        private string[,] table;
        public int Length
        {
            get;
            set;
        }

        public CustomTable(List<string> labels)
        {
            int n = labels.Count;
            table = new string[n + 1, n + 1];
            Length = n + 1;
            for (int i = 0; i < Length; i++)
            {
                for (int j = 0; j < Length; j++)
                {
                    table[i, j] = "";
                }
            }
            for (int i = 1; i < n + 1; i++)
            {
                table[0, i] = labels[i - 1];
                table[i, 0] = labels[i - 1];
            }
        }

        public string this[string i, string j]
        {
            get
            {
                int n = 0, m = 0;
                for (int q = 0; q < Length; q++)
                {
                    if (table[0, q].Equals(i))
                        n = q;
                    if (table[q, 0].Equals(j))
                        m = q;
                }
                return table[n, m];
            }
            set
            {
                int n = 0, m = 0;
                for (int q = 1; q < Length; q++)
                {
                    if (table[0, q].Equals(i))
                        n = q;
                    if (table[q, 0].Equals(j))
                        m = q;
                }
                table[n, m] = value;
            }
        }

        public string[,] GetTable()
        {
            return table;
        }

    }
}
