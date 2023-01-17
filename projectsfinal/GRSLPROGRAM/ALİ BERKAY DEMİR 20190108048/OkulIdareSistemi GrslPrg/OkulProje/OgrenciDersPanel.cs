using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace OkulProje
{
    public partial class OgrenciDersPanel : Form
    {
        public OgrenciDersPanel()
        {
            InitializeComponent();
        }

        okulIdareSisEntities1 db = new okulIdareSisEntities1();

        void listele()
        {
            dataGridView1.DataSource = (from x in db.ois_ogrenciders
                                        select new
                                        {
                                            x.ogrenciders_id,
                                            x.ois_ders.ders_ad,
                                            x.ois_ogrenci.ogrenci_fullname
                                           
                                           

                                        }).ToList();
           
          


    

            var derslist = db.ois_ders.ToList();


        }

        private void OgrenciDersPanel_Load(object sender, EventArgs e)
        {
            listele();
            var ogrenciler = (from x in db.ois_ogrenci
                               select new
                               {
                                   x.ogrenci_id,
                                   x.ogrenci_fullname

                               }).ToList();

            cmbogrenci.ValueMember = "ogrenci_id";
            cmbogrenci.DisplayMember = "ogrenci_fullname";
            cmbogrenci.DataSource = ogrenciler; listele();


            var dersler = (from x in db.ois_ders
                              select new
                              {
                                  x.ders_id,
                                  x.ders_ad

                              }).ToList();

            cmbders.ValueMember = "ders_id";
            cmbders.DisplayMember = "ders_ad";
            cmbders.DataSource = dersler; listele();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtid.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            cmbders.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            cmbogrenci.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
          
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DialogResult sor = new DialogResult();
            sor = MessageBox.Show("Seçilen Kayıt Silinecektir. Onaylıyor musunuz?", "Sistem Mesajı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (sor == DialogResult.Yes)
            {
                int secilen = dataGridView1.SelectedCells[0].RowIndex;
                int ogrencidersID = Convert.ToInt32(dataGridView1.Rows[secilen].Cells[0].Value);


                var ogrencidersbul = db.ois_ogrenciders.Find(ogrencidersID);
                db.ois_ogrenciders.Remove(ogrencidersbul);
                db.SaveChanges();
                MessageBox.Show("Ders Ve Öğrenci İlişkisi Silinecektir. Onaylıyor musunuz?", "Sistem Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listele();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ois_ogrenciders ekle = new ois_ogrenciders();
            ekle.ogrenciders_dersid = Convert.ToInt16(cmbders.SelectedValue);
            ekle.ogrenciders_ogrenciid = Convert.ToInt16(cmbogrenci.SelectedValue);
            db.ois_ogrenciders.Add(ekle);
            db.SaveChanges();
            MessageBox.Show("Öğrenciye Ders Ataması Yapıldı.", "Sistem Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }

       

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem=="Ogrenci")
            {
                {
                    var arama = textBox1.Text;
                    var sonuc = (from x in db.ois_ogrenciders
                                 where x.ois_ogrenci.ogrenci_fullname.Contains(arama)
                                 select new
                                 {
                                     x.ogrenciders_id,
                                     x.ois_ders.ders_ad,
                                     x.ois_ogrenci.ogrenci_fullname

                                 }).ToList();
                    dataGridView1.DataSource = sonuc.ToList();


                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
                listele();
            
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
