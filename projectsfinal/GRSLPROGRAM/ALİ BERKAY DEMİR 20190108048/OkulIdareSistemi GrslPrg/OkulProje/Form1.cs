using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OkulProje
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OgrenciPanel ogrpanel = new OgrenciPanel();
            ogrpanel.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OkulYonetim oklyonetim = new OkulYonetim();
            oklyonetim.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DersPaneli derspanel = new DersPaneli();
            derspanel.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OgrenciDersPanel derspanel = new OgrenciDersPanel();
            derspanel.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
