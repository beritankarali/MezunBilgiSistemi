using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YZM_2116_PROJE
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();

        }
        LinkedList ll = new LinkedList();
        Tree tr = new Tree();
        HashTable h = new HashTable();
        private void btnMezunEkle_Click(object sender, EventArgs e)
        {
            if (txtMezunAdi.Text == "" || txtMezunAdresi.Text == "" || txtMezunDepartman.Text == "" || txtMezunEPosta.Text == "" || txtMezunGorev.Text == "" || txtMezunNotOrt.Text == "" || txtMezunOgrenciNo.Text == "" || txtMezunSirketAdi.Text == "" || txtMezunSoyadi.Text == "" || txtMezunTelefon.Text == "" || cmbMezunBasariBelgesi.Text == "" || cmbMezunBolumAdi.Text == "" || cmbMezunIlgiAlanlari.Text == "" || cmbMezunUyruk.Text == "" || (radioMezunAdv.Checked == false && radioMezunInter.Checked == false && radioMezunPre.Checked == false && radioMezunUpper.Checked == false))
                MessageBox.Show("Lütfen Bütün Alanları Eksiksiz Doldurun");
            else if (Convert.ToDouble(txtMezunNotOrt.Text) <= 0 || Convert.ToDouble(txtMezunNotOrt.Text) >= 100)
                MessageBox.Show("Lütfen Geçerli Mezun Ortalaması Giriniz");
            else
            {

                Mezun m = new Mezun();
                Mezun2 m2 = new Mezun2();
                Mezun3 m3 = new Mezun3();
                m.ad = txtMezunAdi.Text;
                m.adres = txtMezunAdresi.Text;
                m.calistigiDepartman = txtMezunDepartman.Text;
                m.calistigiGorev = txtMezunGorev.Text;
                m.calistigiSirket = txtMezunSirketAdi.Text;
                m.dogumTarihi = dateTimeMezunDugumTarihi.Value;
                m.ePosta = txtMezunEPosta.Text;
                m.ilgiAlanlari = cmbMezunIlgiAlanlari.Text;
                m.ogrenciNo = Convert.ToInt32(txtMezunOgrenciNo.Text);
                m.soyad = txtMezunSoyadi.Text;
                m.stajBaslangic = dateTimeMezunStajBaslangic.Value;
                m.stajBitis = dateTimeMezunStajBitis.Value;
                m.telefon = txtMezunTelefon.Text;
                m.uyruk = cmbMezunUyruk.Text;
                if (radioMezunAdv.Checked == true)
                {
                    m.yabanciDilSeviyesi = "Advanced";
                }
                else if (radioMezunInter.Checked == true)
                {
                    m.yabanciDilSeviyesi = "Intermediate";
                }
                else if (radioMezunPre.Checked == true)
                {
                    m.yabanciDilSeviyesi = "Preintermediate";
                }
                else if (radioMezunUpper.Checked == true)
                {
                    m.yabanciDilSeviyesi = "Upper Intermediate";
                }
                if (cmbMezunBasariBelgesi.Text == "Var")
                {
                    m2.basariBelgesi = true;
                }
                else if (cmbMezunBasariBelgesi.Text == "Var")
                {
                    m2.basariBelgesi = false;
                }
                m2.llOgrenciNo = Convert.ToInt32(txtMezunOgrenciNo.Text);
                m2.notOrtalamasi = Convert.ToDouble(txtMezunNotOrt.Text);
                m2.okuduguBolumAdi = cmbMezunBolumAdi.Text;
                m2.okulBaslangic = dateTimeMezunOkulBaslangic.Value;
                m2.okulBitis = dateTimeMezunOkulBitis.Value;
                m3.ad = txtMezunAdi.Text;
                if (cmbMezunBasariBelgesi.Text == "Var")
                {
                    m3.basariBelgesi = true;
                }
                else if (cmbMezunBasariBelgesi.Text == "Var")
                {
                    m3.basariBelgesi = false;
                }
                m3.hashOgrenciNo = Convert.ToInt32(txtMezunOgrenciNo.Text);
                m3.notOrtalamasi = Convert.ToDouble(txtMezunNotOrt.Text);
                m3.okuduguBolumAdi = cmbMezunBolumAdi.Text;
                m3.soyad = txtMezunSoyadi.Text;
                int deneme = 0;
                for (int j = 0; j < ll.Size; j++)
                {
                    if (ll.GetElement(j + 1).llVeri.llOgrenciNo == m3.hashOgrenciNo)
                    {
                        deneme = 1;
                    }
                }
                if (deneme == 1)
                {
                    MessageBox.Show("Öğrenci Numarası Aynı Daha Önceki Öğrencilerle Aynı Olamaz");
                }
                else
                {
                    ll.Insert(m2);
                    tr.Ekle(m);
                    if (cmbMezunBolumAdi.Text == "Yazılım Mühendisliği")
                        h.Ekle(1, m3);
                    else if (cmbMezunBolumAdi.Text == "Mekatronik Mühendisliği")
                        h.Ekle(2, m3);
                    else if (cmbMezunBolumAdi.Text == "Makine ve İmalat Mühendisliği")
                        h.Ekle(3, m3);
                    else if (cmbMezunBolumAdi.Text == "Enerji Sistemleri Mühendisliği")
                        h.Ekle(4, m3);
                    else if (cmbMezunBolumAdi.Text == "Endüstri Mühendisliği")
                        h.Ekle(5, m3);
                    else if (cmbMezunBolumAdi.Text == "Makine Mühendisliği")
                        h.Ekle(6, m3);
                    else if (cmbMezunBolumAdi.Text == "İnşaat Mühendisliği")
                        h.Ekle(7, m3);
                    else if (cmbMezunBolumAdi.Text == "Tekstil Mühendisliği")
                        h.Ekle(8, m3);
                    cmbMezunListesi.Items.Clear();
                    cmbOgrNo.Items.Clear();
                    for (int i = 0; i < ll.Size; i++)
                    {
                        cmbMezunListesi.Items.Add(ll.GetElement(i + 1).llVeri.llOgrenciNo);
                        cmbOgrNo.Items.Add(ll.GetElement(i + 1).llVeri.llOgrenciNo);
                    }
                    MessageBox.Show("Mezun Başarılı Bir Şekilde Eklendi!");
                }
            }
        }

        private void txtMezunTelefon_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtMezunAdi_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void txtMezunSoyadi_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void txtMezunAdresi_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtMezunOgrenciNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtMezunSirketAdi_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void txtMezunDepartman_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void txtMezunGorev_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void txtMezunNotOrt_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnMezunGetir_Click(object sender, EventArgs e)
        {
            if (cmbMezunListesi.Text == "")
            {
                MessageBox.Show("Lütfen Mezun Seçiniz");
            }
            else
            {
                int x = Convert.ToInt32(cmbMezunListesi.Text);
                int i = 1;
                for (; ; )
                {
                    if (ll.GetElement(i).llVeri.llOgrenciNo == x)
                        break;
                    else
                        i++;
                }
                txtMezunAdi.Text = tr.Ara(x).Veri.ad;
                txtMezunAdresi.Text = tr.Ara(x).Veri.adres;
                txtMezunDepartman.Text = tr.Ara(x).Veri.calistigiDepartman;
                txtMezunGorev.Text = tr.Ara(x).Veri.calistigiGorev;
                txtMezunSirketAdi.Text = tr.Ara(x).Veri.calistigiSirket;
                dateTimeMezunDugumTarihi.Value = tr.Ara(x).Veri.dogumTarihi;
                txtMezunEPosta.Text = tr.Ara(x).Veri.ePosta;
                cmbMezunIlgiAlanlari.Text = tr.Ara(x).Veri.ilgiAlanlari;
                txtMezunOgrenciNo.Text = Convert.ToString(tr.Ara(x).Veri.ogrenciNo);
                txtMezunSoyadi.Text = tr.Ara(x).Veri.soyad;
                dateTimeMezunStajBaslangic.Value = tr.Ara(x).Veri.stajBaslangic;
                dateTimeMezunStajBitis.Value = tr.Ara(x).Veri.stajBitis;
                txtMezunTelefon.Text = tr.Ara(x).Veri.telefon;
                cmbMezunUyruk.Text = tr.Ara(x).Veri.uyruk;
                if (tr.Ara(x).Veri.yabanciDilSeviyesi == "Advanced")
                {
                    radioMezunAdv.Checked = true;
                }
                else if (tr.Ara(x).Veri.yabanciDilSeviyesi == "Intermediate")
                {
                    radioMezunInter.Checked = true;
                }
                else if (tr.Ara(x).Veri.yabanciDilSeviyesi == "Preintermediate")
                {
                    radioMezunPre.Checked = true;
                }
                else if (tr.Ara(x).Veri.yabanciDilSeviyesi == "Upper Intermediate")
                {
                    radioMezunUpper.Checked = true;
                }
                if (ll.GetElement(i).llVeri.basariBelgesi == true)
                {
                    cmbMezunBasariBelgesi.Text = "Var";
                }
                else if (ll.GetElement(i).llVeri.basariBelgesi == false)
                {
                    cmbMezunBasariBelgesi.Text = "Yok";
                }
                txtMezunOgrenciNo.Text = Convert.ToString(ll.GetElement(i).llVeri.llOgrenciNo);
                txtMezunNotOrt.Text = Convert.ToString(ll.GetElement(i).llVeri.notOrtalamasi);
                cmbMezunBolumAdi.Text = ll.GetElement(i).llVeri.okuduguBolumAdi;
                dateTimeMezunOkulBaslangic.Value = ll.GetElement(i).llVeri.okulBaslangic;
                dateTimeMezunOkulBitis.Value = ll.GetElement(i).llVeri.okulBitis;
                MessageBox.Show("Mezun Getirildi!");
                btnGuncelle.Enabled = true;
                btnSil.Enabled = true;
                txtMezunGuncellenecek.Text = Convert.ToString(ll.GetElement(i).llVeri.llOgrenciNo);
                txtSilinecek.Text = Convert.ToString(ll.GetElement(i).llVeri.llOgrenciNo);
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {


                int i = 1;
                int guncelle = Convert.ToInt32(txtMezunGuncellenecek.Text);
                tr.Sil(guncelle);
                for (; ; )
                {
                    if (ll.GetElement(i).llVeri.llOgrenciNo == guncelle)
                        break;
                    else
                        i++;
                }
                ll.Delete(i);
                Mezun m = new Mezun();
                Mezun2 m2 = new Mezun2();
                m.ad = txtMezunAdi.Text;
                m.adres = txtMezunAdresi.Text;
                m.calistigiDepartman = txtMezunDepartman.Text;
                m.calistigiGorev = txtMezunGorev.Text;
                m.calistigiSirket = txtMezunSirketAdi.Text;
                m.dogumTarihi = dateTimeMezunDugumTarihi.Value;
                m.ePosta = txtMezunEPosta.Text;
                m.ilgiAlanlari = cmbMezunIlgiAlanlari.Text;
                m.ogrenciNo = Convert.ToInt32(txtMezunOgrenciNo.Text);
                m.soyad = txtMezunSoyadi.Text;
                m.stajBaslangic = dateTimeMezunStajBaslangic.Value;
                m.stajBitis = dateTimeMezunStajBitis.Value;
                m.telefon = txtMezunTelefon.Text;
                m.uyruk = cmbMezunUyruk.Text;
                if (radioMezunAdv.Checked == true)
                {
                    m.yabanciDilSeviyesi = "Advanced";
                }
                else if (radioMezunInter.Checked == true)
                {
                    m.yabanciDilSeviyesi = "Intermediate";
                }
                else if (radioMezunPre.Checked == true)
                {
                    m.yabanciDilSeviyesi = "Preintermediate";
                }
                else if (radioMezunUpper.Checked == true)
                {
                    m.yabanciDilSeviyesi = "Upper Intermediate";
                }
                if (cmbMezunBasariBelgesi.Text == "Var")
                {
                    m2.basariBelgesi = true;
                }
                else if (cmbMezunBasariBelgesi.Text == "Var")
                {
                    m2.basariBelgesi = false;
                }
                m2.llOgrenciNo = Convert.ToInt32(txtMezunOgrenciNo.Text);
                m2.notOrtalamasi = Convert.ToDouble(txtMezunNotOrt.Text);
                m2.okuduguBolumAdi = cmbMezunBolumAdi.Text;
                m2.okulBaslangic = dateTimeMezunOkulBaslangic.Value;
                m2.okulBitis = dateTimeMezunOkulBitis.Value;

                ll.Insert(m2);
                tr.Ekle(m);
                cmbMezunListesi.Items.Clear();
                cmbOgrNo.Items.Clear();
                for (int j = 0; j < ll.Size; j++)
                {
                    cmbMezunListesi.Items.Add(ll.GetElement(j + 1).llVeri.llOgrenciNo);
                    cmbOgrNo.Items.Add(ll.GetElement(j + 1).llVeri.llOgrenciNo);
                }
                MessageBox.Show("Mezun Başarılı Bir Şekilde Güncellendi!");
            }

            catch (Exception)
            {

                MessageBox.Show("Hatalı Giriş Yaptınız!");
            }
        }
        private void btnBasariyiSirala_Click(object sender, EventArgs e)
        {
            object[] dizi = new object[ll.Size];
            double[] dizi2 = new double[ll.Size];
            for (int i = 0; i < ll.Size; i++)
            {
                if (ll.GetElement(i + 1).llVeri.basariBelgesi == true)
                {
                    dizi[i] = "Öğrenci Numarası" + ll.GetElement(i + 1).llVeri.llOgrenciNo + ",Başarı Notu:" + (ll.GetElement(i + 1).llVeri.notOrtalamasi + 10);
                    dizi2[i] = ll.GetElement(i + 1).llVeri.notOrtalamasi + 10;
                }
                else
                {
                    dizi[i] = "Öğrenci Numarası" + ll.GetElement(i + 1).llVeri.llOgrenciNo + ",Başarı Notu:" + ll.GetElement(i + 1).llVeri.notOrtalamasi;
                    dizi2[i] = ll.GetElement(i + 1).llVeri.notOrtalamasi;
                }
            }

            int n = dizi.Length;
            int minIndis = 0;
            for (int j = 0; j < n; j++)
            {
                minIndis = j;
                for (int k = j + 1; k < n; k++)
                {
                    if (dizi2[k] > dizi2[minIndis])
                        minIndis = k;
                }
                if (minIndis != j)
                {
                    double temp = dizi2[j];
                    object temp2 = dizi[j];
                    dizi2[j] = dizi2[minIndis];
                    dizi[j] = dizi[minIndis];
                    dizi2[minIndis] = temp;
                    dizi[minIndis] = temp2;
                }
            }
            lstBasariOraniniSirala.Items.Clear();
            for (int a = 0; a < dizi.Length; a++)
                lstBasariOraniniSirala.Items.Add(dizi[a]);
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                int i = 1;
                int silinen = Convert.ToInt32(txtSilinecek.Text);
                tr.Sil(silinen);
                for (; ; )
                {
                    if (ll.GetElement(i).llVeri.llOgrenciNo == silinen)
                        break;
                    else
                        i++;
                }
                ll.Delete(i);
                cmbMezunListesi.Items.Clear();
                cmbOgrNo.Items.Clear();
                for (int j = 0; j < ll.Size; j++)
                {
                    cmbMezunListesi.Items.Add(ll.GetElement(j + 1).llVeri.llOgrenciNo);
                    cmbOgrNo.Items.Add(ll.GetElement(j + 1).llVeri.llOgrenciNo);
                }
                MessageBox.Show("Silme İşlemi Başarılı!");
            }
            catch (Exception)
            {
                MessageBox.Show("Hatalı Giriş Yaptınız!");
            }
        }

        private void btnŞirketEkle_Click(object sender, EventArgs e)
        {
            if (txtIsyeriAd.Text == "" || txtIsyeriEposta.Text == "" || txtIsyeriTel.Text == "")
            {
                MessageBox.Show("İşyeri Bilgilerini Eksiksiz Doldurun!");
            }
            else
            {
                MessageBox.Show("Ekleme Başarılı!");
            }
        }

        private void btnTeklifYap1_Click(object sender, EventArgs e)
        {
            if (lstBasariOraniniSirala.Items.Count == 0)
            {
                MessageBox.Show("Lütfen Önce Sıralama Yapınız");
            }
            else
            {
                MessageBox.Show("En Başarılı Mezuna Teklif Yapıldı!");
            }
        }

        private void btnDileGoreSirala_Click(object sender, EventArgs e)
        {
            lstInter.Items.Clear();
            lstAdv.Items.Clear();
            lstPre.Items.Clear();
            lstUpper.Items.Clear();
            Mezun m = new Mezun();
            for (int i = 0; i < ll.Size; i++)
            {
                m = tr.Ara(ll.GetElement(i + 1).llVeri.llOgrenciNo).Veri;
                if (tr.Ara(ll.GetElement(i + 1).llVeri.llOgrenciNo).Veri.yabanciDilSeviyesi == "Intermediate")
                {
                    lstInter.Items.Add(tr.Ara(ll.GetElement(i + 1).llVeri.llOgrenciNo).Veri.ad + " " + tr.Ara(ll.GetElement(i + 1).llVeri.llOgrenciNo).Veri.soyad + " " + tr.Ara(ll.GetElement(i + 1).llVeri.llOgrenciNo).Veri.yabanciDilSeviyesi);
                }
                else if (tr.Ara(ll.GetElement(i + 1).llVeri.llOgrenciNo).Veri.yabanciDilSeviyesi == "Advanced")
                {
                    lstAdv.Items.Add(tr.Ara(ll.GetElement(i + 1).llVeri.llOgrenciNo).Veri.ad + " " + tr.Ara(ll.GetElement(i + 1).llVeri.llOgrenciNo).Veri.soyad + " " + tr.Ara(ll.GetElement(i + 1).llVeri.llOgrenciNo).Veri.yabanciDilSeviyesi);
                }
                else if (tr.Ara(ll.GetElement(i + 1).llVeri.llOgrenciNo).Veri.yabanciDilSeviyesi == "Preintermediate")
                {
                    lstPre.Items.Add(tr.Ara(ll.GetElement(i + 1).llVeri.llOgrenciNo).Veri.ad + " " + tr.Ara(ll.GetElement(i + 1).llVeri.llOgrenciNo).Veri.soyad + " " + tr.Ara(ll.GetElement(i + 1).llVeri.llOgrenciNo).Veri.yabanciDilSeviyesi);
                }
                else if (tr.Ara(ll.GetElement(i + 1).llVeri.llOgrenciNo).Veri.yabanciDilSeviyesi == "Upper Intermediate")
                {
                    lstUpper.Items.Add(tr.Ara(ll.GetElement(i + 1).llVeri.llOgrenciNo).Veri.ad + " " + tr.Ara(ll.GetElement(i + 1).llVeri.llOgrenciNo).Veri.soyad + " " + tr.Ara(ll.GetElement(i + 1).llVeri.llOgrenciNo).Veri.yabanciDilSeviyesi);
                }
            }
        }

        private void btnTeklifYap2_Click(object sender, EventArgs e)
        {

        }

        private void btnOgrNumGoreListele_Click(object sender, EventArgs e)
        {
            if (cmbOgrNo.Text == "")
            {
                MessageBox.Show("Lütfen Geçerli Seçim Yapınız!");
            }
            else
            {
                Mezun m = new Mezun();
                Mezun2 m2 = new Mezun2();
                for (int i = 0; i < ll.Size; i++)
                {
                    if (tr.Ara(ll.GetElement(i + 1).llVeri.llOgrenciNo).Veri.ogrenciNo == Convert.ToInt32(cmbOgrNo.Text))
                        m = tr.Ara(ll.GetElement(i + 1).llVeri.llOgrenciNo).Veri;
                    if (ll.GetElement(i + 1).llVeri.llOgrenciNo == Convert.ToInt32(cmbOgrNo.Text))
                        m2 = ll.GetElement(i + 1).llVeri;
                }
                lstOgrNoSirala.Items.Clear();
                lstOgrNoSirala.Items.Add("No:" + m.ogrenciNo + "İsim ve Soyisim:" + m.ad + " " + m.soyad + "Okuduğu Bölüm:" + m2.okuduguBolumAdi + "Okul Başlangıç ve Bitiş" + m2.okulBaslangic + " " + m2.okulBitis + "Başarı Belgesiz Not Ortalamasi" + m2.notOrtalamasi + "Uyruk:" + m.uyruk + "Doğum Tarihi:" + m.dogumTarihi + "ePosta:" + m.ePosta + "Adres:" + m.adres + "İlgi Alanları" + m.ilgiAlanlari + "Telefon" + m.telefon + "Yabancı Dil Bilgisi" + m.yabanciDilSeviyesi + "Çalıştığı Şirket, Departman ve Görev" + m.calistigiSirket + " " + m.calistigiDepartman + " " + m.calistigiGorev + "Çalışmaya Başlama ve Bitiş Tarihi" + m.stajBaslangic + m.stajBitis);
            }
        }

        private void btnDoksanUzeriListele_Click(object sender, EventArgs e)
        {
            lst90Sirala.Items.Clear();
            for (int i = 0; i < ll.Size; i++)
            {
                double ortalama;
                if (ll.GetElement(i + 1).llVeri.basariBelgesi == true)
                {
                    ortalama = ll.GetElement(i + 1).llVeri.notOrtalamasi + 10;
                }
                else
                {
                    ortalama = ll.GetElement(i + 1).llVeri.notOrtalamasi;
                }
                if (ortalama >= 90)
                {

                    lst90Sirala.Items.Add("Öğrenci No:" + tr.Ara(ll.GetElement(i + 1).llVeri.llOgrenciNo).Veri.ogrenciNo + "Öğrenci Adı ve Soyadı:" + tr.Ara(ll.GetElement(i + 1).llVeri.llOgrenciNo).Veri.ad + " " + tr.Ara(ll.GetElement(i + 1).llVeri.llOgrenciNo).Veri.soyad + "Ortalama" + ortalama);
                }
            }
        }

        private void btn3CesitSiralama_Click(object sender, EventArgs e)
        {
            lst3CesitSirala.Items.Clear();
            if (cmb3CesitSiralama.Text == "")
            {
                MessageBox.Show("Geçerli Seçenek Seçiniz!");
            }
            else if (cmb3CesitSiralama.Text == "Inorder")
            {
                lst3CesitSirala.Items.Add(tr.InOrder());
            }
            else if (cmb3CesitSiralama.Text == "Preorder")
            {
                lst3CesitSirala.Items.Add(tr.PreOrder());
            }
            else if (cmb3CesitSiralama.Text == "Postorder")
            {
                lst3CesitSirala.Items.Add(tr.PostOrder());
            }
        }

        private void btnIngilizceyeGoreSirala_Click(object sender, EventArgs e)
        {
            lstDileGoreSirala.Items.Clear();
            for (int i = 0; i < ll.Size; i++)
            {
                if (tr.Ara(ll.GetElement(i + 1).llVeri.llOgrenciNo).Veri.yabanciDilSeviyesi == "Advanced")
                {
                    lstDileGoreSirala.Items.Add("Adı ve Soyadı:" + tr.Ara(ll.GetElement(i + 1).llVeri.llOgrenciNo).Veri.ad + " " + tr.Ara(ll.GetElement(i + 1).llVeri.llOgrenciNo).Veri.soyad + "Yabancı Dil Seviyesi" + tr.Ara(ll.GetElement(i + 1).llVeri.llOgrenciNo).Veri.yabanciDilSeviyesi);
                }
            }
        }

        private void btnAgacDerinligi_Click(object sender, EventArgs e)
        {
            txtDerinlik.Text = Convert.ToString(tr.DerinlikBul());
        }

        private void btnElemanSayisi_Click(object sender, EventArgs e)
        {
            txtElemanSayisi.Text = Convert.ToString(tr.DugumSayisi());
        }
    }
}
