using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SepetToplamiHesapla
{
    public partial class Form1 : Form
    {
        string[] urunArray = new string[4];
        decimal[] fiyatArray = new decimal[4];
        decimal secilenFiyat;
        string secilenUrun;
        int quantity;
        decimal price;
        List<decimal> toplamSepetFiyat = new List<decimal>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            urunArray[0] = "Çamaşır";
            fiyatArray[0] = 10;
            urunArray[1] = "Elbise";
            fiyatArray[1] = 25;
            urunArray[2] = "Ayakkabı";
            fiyatArray[2] = 50;
            urunArray[3] = "Bilgisayar";
            fiyatArray[3] = 1500;

            cmbUrun.Items.AddRange(urunArray);
        }

        private void cmbUrun_SelectedIndexChanged(object sender, EventArgs e)
        {
            var urunIndex = Array.IndexOf(urunArray, cmbUrun.SelectedItem);

            if (urunIndex != -1)
            {
                secilenFiyat = fiyatArray[urunIndex];
                secilenUrun = urunArray[urunIndex];

                lblBirimFiyat.Text =  secilenFiyat + "₺";
            }
        }

        private void txtAdet_KeyUp(object sender, KeyEventArgs e)
        {
            //enter tuşuna basıldığı zaman işlem yapmasını istiyorum. e.keyvalue bize tuşların kodunu vermektedir. 
            if (e.KeyValue == 13) 
            {
                bool isNumber = int.TryParse(txtAdet.Text, out int qty);

                if (isNumber)
                {
                    quantity = qty;
                    price = secilenFiyat * quantity;
                    lblToplamFiyat.Text = string.Format("{0}₺", price);

                    var urun = string.Format("{0} * ({1}) = {2}", secilenUrun, quantity, price);
                    lstSepet.Items.Add(urun);
                    toplamSepetFiyat.Add(secilenFiyat * quantity);

                    lblSepetFiyat.Text = toplamSepetFiyat.Sum() + "₺";
                }
                else
                {
                    MessageBox.Show("Lütfen Doğru Bir Değer Giriniz.");
                }
              
            }
        }
    }
}
