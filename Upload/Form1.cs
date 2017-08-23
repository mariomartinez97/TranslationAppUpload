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

namespace Upload
{
    public partial class Form1 : Form
    {
        private Dictionary<string, Word> diccionario;

        public Form1()
        {
            InitializeComponent();
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFile();
            if (diccionario != null)
            {
                foreach (var kvp in diccionario)
                {
                    listBox1.Items.Add(diccionario[kvp.Key].palabra);
                }
            }
        }
        private void OpenFile()
        {
            diccionario = new Dictionary<string, Word>();

            OpenFileDialog fileDialog = new OpenFileDialog();
            if (DialogResult.OK == fileDialog.ShowDialog())
            {
                StreamReader reader = new StreamReader(fileDialog.FileName);
                while (!reader.EndOfStream)
                {
                    Word mWord = new Word();
                    string wordInfo = reader.ReadLine();
                    string[] split = wordInfo.Split('|');
                    for (int i = 0; i < split.Length; i++)
                    {
                        split[i] = split[i].Remove(0, 1);
                        split[i] = split[i].Remove(split[i].Length - 1, 1);
                    }

                    mWord.palabra = split[0];
                    mWord.traduccion = split[1];

                    diccionario.Add(mWord.palabra, mWord);
                }
            }
           
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string word = (string)listBox1.SelectedItem;
            textBox1.Text = diccionario[word].palabra;
            textBox2.Text = diccionario[word].traduccion;
        }
    }
}
