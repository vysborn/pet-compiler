using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TableBuilder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
          //  this.Width = Constants.SMALL_WIDTH;
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void FillTable(TableMaker table)
        {
            for (int i = 0; i < table.GetLength(); i++)
            {
                dataGridView1.Columns.Add("", "");
                dataGridView1.Columns[dataGridView1.Columns.Count - 1].Width = 70;
                dataGridView1.Rows.Add();
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Height = 30;
            }
            
            for(int i = 0; i < dataGridView1.Columns.Count-1; i++)
            {
                dataGridView1.Columns[i].HeaderCell.Value = table.GetTable()[0, i+1];
                dataGridView1.Rows[i].HeaderCell.Value = table.GetTable()[i+1, 0];
            }
            dataGridView1.RowHeadersWidth = 100;
            dataGridView1.ColumnHeadersHeight = 50;
            for (int i = 0; i < dataGridView1.Columns.Count-1; i++)
            {
                for (int j = 0; j < dataGridView1.Columns.Count-1; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Value = table.GetTable()[i+1, j+1];
                }
            }
            for(int i=0;i<dataGridView1.Columns.Count-1; i++)
            {
                dataGridView1.Rows[dataGridView1.Columns.Count - 1].Cells[i].Value = "<";
                dataGridView1.Rows[i].Cells[dataGridView1.Columns.Count - 1].Value = ">";
            }
            dataGridView1.Rows[dataGridView1.Columns.Count - 1].HeaderCell.Value = "#";
            dataGridView1.Columns[dataGridView1.Columns.Count - 1].HeaderCell.Value = "#";

        }

        private void InitGrammar(Grammar grammar)
        {

            grammar.AddRule("prog", new List<List<string>> { new List<string> { "program", "id", ":", "declarationList1", "{", "operList1", "}" } });
            grammar.AddRule("declarationList1", new List<List<string>> { new List<string> { "declarationList" } });
            grammar.AddRule("declarationList", new List<List<string>> { new List<string> { "declarationList", "declaration", ";" }, new List<string> { "declaration", ";" } });
            grammar.AddRule("declaration", new List<List<string>> { new List<string> { "int", "іdList1" } });
            grammar.AddRule("іdList1", new List<List<string>> { new List<string> { "іdList" } });
            grammar.AddRule("іdList", new List<List<string>> { new List<string> { ",", "id"  }, new List<string> { "іdList", ",", "id" } });
            grammar.AddRule("operList1", new List<List<string>> { new List<string> { "operList" } });
            grammar.AddRule("operList", new List<List<string>> { new List<string> { "operList", "oper", ";" }, new List<string> { "oper", ";" } });
            grammar.AddRule("oper", new List<List<string>> { new List<string> { "assigment" }, new List<string> { "inputOper" }, new List<string> { "outputOper" }, new List<string> { "cycle" }, new List<string> { "condition" } });
            grammar.AddRule("assigment", new List<List<string>> { new List<string> { "id", "=", "expretion1" } });
            grammar.AddRule("inputOper", new List<List<string>> { new List<string> { "input", "(", "іdList1", ")" } });
            grammar.AddRule("outputOper", new List<List<string>> { new List<string> { "output", "(", "іdList1", ")" } });
            grammar.AddRule("cycle", new List<List<string>> { new List<string> { "do", "while", "(", "LE1", ")", "{", "operList1", "}" } });
            grammar.AddRule("condition", new List<List<string>> { new List<string> { "if", "(", "LE1", ")", "{", "operList1", "}", "else", "{", "operList1", "}" } });
            grammar.AddRule("LE1", new List<List<string>> { new List<string> { "LE" } });
            grammar.AddRule("LE", new List<List<string>> { new List<string> { "LT1" }, new List<string> { "LE", "||", "LT1" } });
            grammar.AddRule("LT1", new List<List<string>> { new List<string> { "LT" } });
            grammar.AddRule("LT", new List<List<string>> { new List<string> { "LM" }, new List<string> { "LT", "&&", "LM" } });
            grammar.AddRule("LM", new List<List<string>> { new List<string> { "relation" }, new List<string> { "[", "LT1", "]" }, new List<string> { "!", "LM" } });
            grammar.AddRule("relation", new List<List<string>> { new List<string> { "expretion", "signRelation", "expretion1" } });
            grammar.AddRule("signRelation", new List<List<string>> { new List<string> { "<" }, new List<string> { "<=" }, new List<string> { ">" }, new List<string> { ">=" }, new List<string> { "!=" }, new List<string> { "==" } } );
            grammar.AddRule("expretion1", new List<List<string>> { new List<string> { "expretion" } });
            grammar.AddRule("expretion", new List<List<string>> { new List<string> { "term1" }, new List<string> { "expretion", "+", "term1" }, new List<string> { "expretion", "-", "term1" } });
            grammar.AddRule("term1", new List<List<string>> { new List<string> { "term" } });
            grammar.AddRule("term", new List<List<string>> { new List<string> { "multiplier" }, new List<string> { "term", "*", "multiplier" }, new List<string> { "term", "/", "multiplier" } });
            grammar.AddRule("multiplier", new List<List<string>> { new List<string> { "id" }, new List<string> { "con" }, new List<string> { "expretion1" } });


            /*grammar.AddRule("E", new List<List<string>> { new List<string> { "E" ,"+","T1" }, new List<string> { "T1"} });
            grammar.AddRule("E1", new List<List<string>> { new List<string> { "E" } });
            grammar.AddRule("T1", new List<List<string>> {  new List<string> { "T"} });
            grammar.AddRule("F", new List<List<string>> { new List<string> { "(","E1",")" }, new List<string> {"i" } });
            grammar.AddRule("T", new List<List<string>> { new List<string> { "T","*","F" }, new List<string> {"F" } });*/

            grammar.UpdateKeys();
            grammar.UpdateAllItems();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Grammar grammar = new Grammar();
            InitGrammar(grammar);
           // this.Width = Constants.BIG_WIDTH;
            TableMaker maker = new TableMaker(grammar);
            maker.MakeTable();
            FillTable(maker);
           
        }
    }
}
