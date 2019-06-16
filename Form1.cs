using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
namespace Wiskundeteller
{

    public partial class Form1 : Form
    {
        string textbestand = null;
        string contents = null;
        public Form1()
        {
            InitializeComponent();

        }

        public void Form1_Load(object sender, EventArgs e)
        {
            button2.Enabled = false;
            Resultatentextveld.Text = "MARCELS WISKUNDE PO PROGRAMMA - 2019 ©";
            Resultatentextveld.Text = Resultatentextveld.Text + "\n______________________________________________________";
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Wiskunde PO Tool - Marcel Groeneveld";

            if (theDialog.ShowDialog() == DialogResult.OK)
            {
                button2.Enabled = true;
                textbestand = theDialog.FileName;
                 contents = File.ReadAllText(textbestand);
                this.richTextBox1.Text = theDialog.FileName + "\nSUCCESSVOL INGELADEN";
                this.richTextBox1.Text = this.richTextBox1.Text + "\n__________________\nKLAAR OM TE STARTEN\n__________________";



            }
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void RichTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            // Dit wordt uitgevoerd wanneer op button2 wordt geklikt; er is al gevraagt welk tekst bestand te lezen; dat is variabele textbestan
            // zet de inhoud van textbestand in het geheugen
            string[] lines = File.ReadAllLines(textbestand);
         
            // mylines zijn alle resultaten. Deze tellen we op en koppelen we aan de naam
            var mylines = lines.GroupBy(g => g).Select(s => new { Name = s, Count = s.Count() });

            //foreach betekent  Voor elke xyz.... dus voor elk getelde regel zet in het textfeld hoe vaak line.name (dus de naam) is geteld (line.count)
            foreach (var line in mylines)
            {
                // We moeten rekening houden met dat een artiest minimaal 16 keer voor komt
                // we hebben al geteld hoe vaak een artiest voorkomt hierboven dus we kunnen simpel stelen: ALS Line.Count (aantal dus) MEER of gelijk is aan 16; dan pas doen wij iets
                // >= betekent gelijk of groter dan en tussen haakjes is dan wat er wordt uitgevoerd
                if (line.Count >= 16)
                {
                    Resultatentextveld.Text = Resultatentextveld.Text + "\n" + line.Name.Key + " | " + line.Count;
                }
                else
                { } // Else is wanneer de line.count dus niet gelijk is of minder is dan 16 maar we hoeven met die waardes niets te doen dus laten we dit leeg                 
                                           
            }
            Resultatentextveld.Text = Resultatentextveld.Text + "\n -----------------------------------------";
            Resultatentextveld.Text = Resultatentextveld.Text + "\n KLAAR MET TELLEN.";

        }
        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
