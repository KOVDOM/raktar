using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace raktar
{
    public partial class Form2 : Form
    {
        class adatok
        {
            public int num;
            public string name;
        }
        public Form2()
        {
            InitializeComponent();
            StreamReader sr = new StreamReader("termekek.txt");
            List<adatok> list = new List<adatok>();
            while (!sr.EndOfStream)
            {
                string sor = sr.ReadLine();
                string[] darab=sor.Split(';');
                adatok a = new adatok();
                a.num = Convert.ToInt32(darab[0]);
                a.name= darab[1];
                list.Add(a);
            }
            sr.Close();
            foreach (var item in list)
            {
                richTextBox1.Text += item.num.ToString()+" "+item.name+"\n";

            }
            //richTextBox1.Text = File.ReadAllText("termekek.txt");
        }

        private void button1_Click(object sender, EventArgs e)
        {           
            StreamWriter sw = new StreamWriter("termekek.txt", true);

            sw.WriteLine(textBox1.Text + ";" + textBox2.Text);
            textBox1.Text = "";
            sw.Close();
            richTextBox1.Text = File.ReadAllText("termekek.txt");            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter("termekek.txt", true);

            List<string> quotelist = File.ReadAllLines("termekek.txt").ToList();
            string firstItem = quotelist[0];
            quotelist.RemoveAt(0);
            File.WriteAllLines("termekek.txt", quotelist.ToArray());
        }
    }
}
