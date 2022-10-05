using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace raktar
{
    public partial class Form5 : Form
    {
        class adatok
        {            
            public string name;
            public DateTime date;
            public int num;
        }
        public Form5()
        {
            InitializeComponent();
            StreamReader sr = new StreamReader("eladasok.txt");
            List<adatok> list = new List<adatok>();
            while (!sr.EndOfStream)
            {
                string sor = sr.ReadLine();
                string[] darab = sor.Split(';');
                adatok a = new adatok();
                a.name = darab[0];
                a.date=Convert.ToDateTime(darab[1]);
                a.num = Convert.ToInt32(darab[2]);
                list.Add(a);
            }
            sr.Close();

            foreach (var item in list)
            {
                richTextBox1.Text +=  item.name +" "+ item.num.ToString() +"\n";

            }
        }
    }
}
