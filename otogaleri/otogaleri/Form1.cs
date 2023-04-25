using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
namespace otogaleri
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        OleDbConnection baglantim = new OleDbConnection("Provider=Microsoft.ACE.OleDb.12.0; Data Source="+Application.StartupPath+"\\otogaleri.accdb");

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            kayitlarilistele();
        }
        private void kayitlarilistele()
        {
            try
            {
                baglantim.Open();
                OleDbDataAdapter listele = new OleDbDataAdapter("select * from araclar",baglantim);
                DataSet dshafiza = new DataSet();
                listele.Fill(dshafiza);
                dataGridView1.DataSource = dshafiza.Tables[0];
                baglantim.Close();
            }
            catch (Exception hatamsj)
            {
                MessageBox.Show(hatamsj.Message);
                baglantim.Close();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            string marka=comboBox1.SelectedItem.ToString();
            if (marka=="Toyota")
            {
                string[] model = { "Auris", "Yaris", "Corolla" };
                comboBox2.Items.AddRange(model);
            }
            if (marka=="Honda")
            {
                string[] model = { "Civic", "Accord" };
                comboBox2.Items.AddRange(model);
            }
            if(marka=="Opel")
            {
                string[] model = { "Astra", "Vectra", "Corsa" };
                comboBox2.Items.AddRange(model);
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                baglantim.Open();
                OleDbDataAdapter eklekomutu = new OleDbDataAdapter("insert into araclar (ruhsatno,marka,model,yakıt_tipi,kasa_tipi,kilometre,fiyat) values('" + textBox1.Text + "','" + comboBox1.SelectedItem.ToString() + "','" +
                   comboBox2.SelectedItem.ToString() + "','" + comboBox3.SelectedItem.ToString() +"','" + comboBox4.SelectedItem.ToString() + "','" + textBox2.Text + "','" + textBox3.Text + "')", baglantim);
                DataSet dshafiza = new DataSet();
                eklekomutu.Fill(dshafiza);
                baglantim.Close();
                MessageBox.Show("Araç veri tabanına eklendi.");
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                kayitlarilistele();

            }
            catch (Exception hatamsj)
            {
                MessageBox.Show(hatamsj.Message);
                baglantim.Close();
                
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                baglantim.Open();
                OleDbDataAdapter silkomutu = new OleDbDataAdapter("delete from araclar where ruhsatno='"+ textBox1.Text+"'",baglantim);
                DataSet dshafiza = new DataSet();
                silkomutu.Fill(dshafiza);
                baglantim.Close();
                MessageBox.Show("Araç veri tabanından silindi.");
                kayitlarilistele();
            }
            catch (Exception hatamsj)
            {
                MessageBox.Show(hatamsj.Message);
                baglantim.Close();
            }
        }

        private void btnFiyat_Click(object sender, EventArgs e)
        {
            try
            {
                baglantim.Open();
                OleDbDataAdapter guncellesorgusu= new OleDbDataAdapter("update araclar set fiyat='" + textBox3.Text + "' where ruhsatno='" + textBox1.Text + "'",baglantim);
                DataSet dshafiza = new DataSet();
                guncellesorgusu.Fill(dshafiza);
                baglantim.Close();
                MessageBox.Show("Araç fıyatı güncellendi");
                kayitlarilistele();
            }
            catch (Exception hatamsj)
            {
                MessageBox.Show(hatamsj.Message);
                baglantim.Close();
            }
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            try
            {
                baglantim.Open();
                OleDbDataAdapter aramasorgusu = new OleDbDataAdapter("select * from araclar where ruhsatno='" + textBox1.Text + "'", baglantim);
                DataSet dshafiza = new DataSet();
                aramasorgusu.Fill(dshafiza);
                dataGridView1.DataSource=dshafiza.Tables[0];
                baglantim.Close();
            }
            catch (Exception hatamsj)
            {
                MessageBox.Show(hatamsj.Message);
                baglantim.Close();
            }

        }
    }
}
