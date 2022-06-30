using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization.Formatters.Binary;
using System.Data;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Xml;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ListsWinForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0; comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.SelectedIndex = 0; comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox3.SelectedIndex = 0; comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox4.SelectedIndex = 0; comboBox4.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox5.SelectedIndex = 0; comboBox5.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        List<rabot> rab = new List<rabot>();
        int r = 0, g = 0, b = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dial = new OpenFileDialog();
            if (dial.ShowDialog() == DialogResult.OK)
            {
                using (StreamReader str = new StreamReader(dial.FileName, Encoding.Default))
                {
                    List<string> ls = new List<string>();
                    string st1 = "";
                    progressBar1.Value = 0;
                    progressBar1.Maximum = str.ReadToEnd().Length;
                    str.BaseStream.Seek(0, SeekOrigin.Begin);
                    while ((st1 = str.ReadLine()) != null)
                    {
                        progressBar1.Value += st1.Length + 1;
                        ls.Add(st1);

                    }
                    listBox1.Items.AddRange(ls.ToArray());
                }
            }
        }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            double d = trackBar1.Value;
            Opacity = d / 100;
        }
        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            r = trackBar2.Value;
            BackColor = Color.FromArgb(r, g, b);
        }

        public void sort()
        {

        }

        public void print()
        {
            listBox2.Items.Clear();
            sort();
            if (comboBox1.SelectedIndex == 0) { listBox2.Items.AddRange(rab.OrderBy(i => i.Name).ToArray()); }
            else if (comboBox1.SelectedIndex == 1) { listBox2.Items.AddRange(rab.OrderByDescending(i => i.Name).ToArray()); }
            else if (comboBox1.SelectedIndex == 2) { listBox2.Items.AddRange(rab.OrderBy(i => i.Doli).ToArray()); }
            else if (comboBox1.SelectedIndex == 3) { listBox2.Items.AddRange(rab.OrderByDescending(i => i.Doli).ToArray()); }
            else if (comboBox1.SelectedIndex == 4) { listBox2.Items.AddRange(rab.OrderBy(i => i.Zarp).ToArray()); }
            else if (comboBox1.SelectedIndex == 5) { listBox2.Items.AddRange(rab.OrderByDescending(i => i.Zarp).ToArray()); }
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
            comboBox4.SelectedIndex = 0;
            comboBox5.SelectedIndex = 0;
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                rab.Add(new rabot(textBox1.Text, comboBox5.SelectedIndex, comboBox5.Text, int.Parse(textBox2.Text), comboBox3.Text, comboBox2.Text, comboBox4.Text));
                print();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BinaryFormatter bin = new BinaryFormatter();
            using (Stream fs = File.Create(@"..\testb.bin"))
            {
                bin.Serialize(fs, rab);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            rab = new List<rabot>();
            List<rabot> com = new List<rabot>();
            BinaryFormatter bin = new BinaryFormatter();
            using (Stream fs = File.OpenRead(@"..\testb.bin"))
            {
                com = bin.Deserialize(fs) as List<rabot>;
            }
            rab = com;
            print();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            print();
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            g = trackBar3.Value;
            BackColor = Color.FromArgb(r, g, b);
        }
        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            b = trackBar4.Value;
            BackColor = Color.FromArgb(r, g, b);
        }

    }
}
