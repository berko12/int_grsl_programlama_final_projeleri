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
    public partial class DersPaneli : Form
    {
        public DersPaneli()
        {
            InitializeComponent();
        }

        okulIdareSisEntities1 db = new okulIdareSisEntities1();

        void listele()
        {
            dataGridView1.DataSource = (from x in db.ois_ders
                                        select new
                                        {
                                            x.ders_id,
                                            x.ders_ad,
                                            x.ders_kredi,
                                            x.ois_okulyonetim.yonetim_adsoyad
                                          
                                        }).ToList();
            
         
           
            //dataGridView1.Columns[4].Visible = false;

            var derslist = db.ois_ders.ToList();


        }
        private void DersPaneli_Load(object sender, EventArgs e)
        {
            listele();
            var ogretmenler = (from x in db.ois_okulyonetim
                               where x.yonetim_tip == "12"
                               select new
                               {
                                   x.yonetim_id,
                                   x.yonetim_adsoyad

                               }).ToList();

            comboBox1.ValueMember = "yonetim_id";
            comboBox1.DisplayMember = "yonetim_adsoyad";
            comboBox1.DataSource = ogretmenler;
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {

            ois_ders ekle = new ois_ders();
            ekle.ders_ad = txtdersad.Text;
            ekle.ders_kredi = txtkredi.Text;
            ekle.ders_okulyonetimid = Convert.ToInt16(comboBox1.SelectedValue);
            db.ois_ders.Add(ekle);
            db.SaveChanges();
            MessageBox.Show("Ders Kaydedildi.", "Sistem Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();

        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                var ogretmenler = (from x in db.ois_okulyonetim
                                   where x.yonetim_tip == "12"
                                   select new
                                   {
                                       x.yonetim_id,
                                       x.yonetim_adsoyad

                                   }).ToList();
                foreach (var item in ogretmenler)
                {
                    e.Value = item.yonetim_adsoyad;
                }

               
             
            
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtid.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtdersad.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtkredi.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DialogResult sor = new DialogResult();
            sor = MessageBox.Show("Seçilen Kayıt Silinecektir. Onaylıyor musunuz?", "Sistem Mesajı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (sor == DialogResult.Yes)
            {
                int secilen = dataGridView1.SelectedCells[0].RowIndex;
                int DersID = Convert.ToInt32(dataGridView1.Rows[secilen].Cells[0].Value);


                var dersbul = db.ois_ders.Find(DersID);
                db.ois_ders.Remove(dersbul);
                db.SaveChanges();
                MessageBox.Show("Ders Kayıdı Silindi", "Sistem Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listele();
            }
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            int DersID = Convert.ToInt32(txtid.Text);

            var guncelle = db.ois_ders.Find(DersID);
            guncelle.ders_ad = txtdersad.Text;
            guncelle.ders_kredi = txtkredi.Text;
            guncelle.ders_okulyonetimid = Convert.ToInt16(comboBox1.SelectedValue);
            db.SaveChanges();
            MessageBox.Show("Ders Kayıdı Güncellendi", "Sistem Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
