using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OkulProje
{
    public partial class OgrenciPanel : Form
    {
        public OgrenciPanel()
        {
            InitializeComponent();
        }
        okulIdareSisEntities1 db = new okulIdareSisEntities1();

        void listele()
        {
            
            dataGridView1.DataSource = db.ois_ogrenci.ToList();
           
            dataGridView1.Columns[6].Visible = false;
        }
        private void OgrenciPanel_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            ois_ogrenci ekle = new ois_ogrenci();
            ekle.ogrenci_fullname = txtadsoyad.Text;
            ekle.ogrenci_no = txtogrencino.Text;
            ekle.ogrenci_birthdate = dateTimePicker1.Value;
            ekle.ogrenci_bolum = txtbolum.Text;
            ekle.ogrenci_recorddate = DateTime.Now;
            db.ois_ogrenci.Add(ekle);
            db.SaveChanges();
            MessageBox.Show("Öğrenci Kaydı Oluşturuldu.", "Sistem Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
            
        }

       

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            DialogResult sor = new DialogResult();
            sor = MessageBox.Show("Seçilen Kayıt Silinecektir. Onaylıyor musunuz?", "Sistem Mesajı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (sor == DialogResult.Yes)
            {
                int secilen = dataGridView1.SelectedCells[0].RowIndex;
                int OgrenciId = Convert.ToInt32(dataGridView1.Rows[secilen].Cells[0].Value);


                var ogrencibul = db.ois_ogrenci.Find(OgrenciId);
                db.ois_ogrenci.Remove(ogrencibul);
                db.SaveChanges();
                MessageBox.Show("Öğrenci Kayıdı Silindi", "Sistem Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listele();
            }
         

        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            int OgrenciId = Convert.ToInt32(txtid.Text);

            var guncelle = db.ois_ogrenci.Find(OgrenciId);
            guncelle.ogrenci_fullname = txtadsoyad.Text;
            guncelle.ogrenci_no = txtogrencino.Text;
            guncelle.ogrenci_birthdate = dateTimePicker1.Value;
            guncelle.ogrenci_bolum = txtbolum.Text;
            guncelle.ogrenci_recorddate = DateTime.Now;
            db.SaveChanges();
            MessageBox.Show("Öğrenci Kayıdı Güncellendi", "Sistem Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            int OgrenciId = Convert.ToInt32(txtid.Text);

            var ogrencibul = db.ois_ogrenci.Find(OgrenciId);
            db.ois_ogrenci.Remove(ogrencibul);
            db.SaveChanges();
            MessageBox.Show("Öğrenci Kayıdı Silindi", "Sistem Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtid.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtadsoyad.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtogrencino.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            dateTimePicker1.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            txtbolum.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem== "Adı Soyadı = ")
            {
                var sonuc = from rec in db.ois_ogrenci where rec.ogrenci_fullname.Contains(textBox1.Text) select rec;
                dataGridView1.DataSource = sonuc.ToList();
            }
            else if (comboBox1.SelectedItem == "Öğrenci Numarası = ")
            {
                var sonuc = from rec in db.ois_ogrenci where rec.ogrenci_no.Contains(textBox1.Text) select rec;
                dataGridView1.DataSource = sonuc.ToList();
            }
            else if (comboBox1.SelectedItem == "Öğrencinin Bölümü = ")
            {
                var sonuc = from rec in db.ois_ogrenci where rec.ogrenci_bolum.Contains(textBox1.Text) select rec;
                dataGridView1.DataSource = sonuc.ToList();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label6_Click_1(object sender, EventArgs e)
        {

        }
    }
}
