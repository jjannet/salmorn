using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GenModelString
{
    public partial class Form1 : Form
    {
        private List<string> numbetStrs = new List<string>() { "int", "float", "long", "decimal" };
        
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGen_Click(object sender, EventArgs e)
        {
            string input = tbInput.Text;
            StringBuilder output = new StringBuilder();


            foreach(var l in input.Split('\n'))
            {
                
                string str = l.Replace("public ", "").Replace(" { get; set; }", "").Trim();
                string type = str.Split(' ')[0];
                string name = str.Split(' ')[1];

                if (isNumber(type.ToLower())) output.Append(name + ": number;\n");
                else if (type.ToLower().Contains("string")) output.Append(name + ": string;\n");
                else if(type.ToLower().Contains("date")) output.Append(name + ": Date;\n");
                else if (type.ToLower().Contains("bool")) output.Append(name + ": Boolean;\n");
            }

            tbOutput.Text = output.ToString();
        }

        private bool isNumber(string type)
        {
            foreach (var n in numbetStrs)
            {
                if (type.Contains(n)) return true;
            }
            return false;
        }
    }
}
