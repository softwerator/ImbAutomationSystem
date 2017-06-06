using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IMB
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        IMBveritabani db = new IMBveritabani();
        Yetkililer y = new Yetkililer();
        string YetkiliKisiAdi = "";
        string YetkiliKisiSoyadi = "";
        int meslekhastaligiID = 0;

        private void Form1_Load(object sender, EventArgs e)
        {
            Yetkililer y1 = new Yetkililer(); Yetkililer y2 = new Yetkililer(); Yetkililer y3 = new Yetkililer(); Yetkililer y4 = new Yetkililer(); Yetkililer y5 = new Yetkililer(); Yetkililer y6 = new Yetkililer();
            y1.Ad = "Burakcan"; y1.Soyad = "Timuçin"; y1.KullaniciAdi = "btimucin"; y1.Sifre = "626991"; y1.TCKimlikNo = "28656167786"; y1.Telefon = "05302549998"; y1.Fax = "05302549996"; y1.ePosta = "btimucin@imb.com";
            y2.Ad = "Intizar"; y2.Soyad = "Najimaddinova"; y2.KullaniciAdi = "inajimaddinova"; y2.Sifre = "845285"; y2.TCKimlikNo = "47754232554"; y2.Telefon = "05312240197"; y2.Fax = "05312240199"; y2.ePosta = "inajimaddinova@imb.com";
            y3.Ad = "Fatih"; y3.Soyad = "Kuşlu"; y3.KullaniciAdi = "fkuslu"; y3.Sifre = "536208"; y3.TCKimlikNo = "21008690826"; y3.Telefon = "05321867256"; y3.Fax = "05321867258"; y3.ePosta = "fkuslu@imb.com";
            y4.Ad = "Yiğit"; y4.Soyad = "Karakoyun"; y4.KullaniciAdi = "ykarakoyun"; y4.Sifre = "293527"; y4.TCKimlikNo = "24967150240"; y4.Telefon = "05335795892"; y4.Fax = "05335795894"; y4.ePosta = "ykarakoyun@imb.com";
            y5.Ad = "Damla"; y5.Soyad = "Demir"; y5.KullaniciAdi = "ddemir"; y5.Sifre = "608063"; y5.TCKimlikNo = "34646763098"; y5.Telefon = "05356328980"; y5.Fax = "05356328982"; y5.ePosta = "ddemir@imb.com";
            y6.Ad = "Tahir"; y6.Soyad = "Baboci"; y6.KullaniciAdi = "tbaboci"; y6.Sifre = "350877"; y6.TCKimlikNo = "69898119720"; y6.Telefon = "05372022304"; y6.Fax = "05372022306"; y6.ePosta = "tbaboci@imb.com";
            y.YetkiliEkle(y1); y.YetkiliEkle(y2); y.YetkiliEkle(y3); y.YetkiliEkle(y4); y.YetkiliEkle(y5); y.YetkiliEkle(y6);

            tabControl1.TabPages.Remove(tabIsyeriBilgileri);
            tabControl1.TabPages.Remove(tabIsKazalari);
            tabControl1.TabPages.Remove(tabMeslekHastaliklari);
            tabControl1.TabPages.Remove(tabHastaneRaporları);

            lvIsKazalariListesi.Clear();
            lvIsKazalariListesi.View = View.Details;
            lvIsKazalariListesi.FullRowSelect = true;
            ListViewIsKazalari(lvIsKazalariListesi);

            lvMeslekHastaligiListesi.Clear();
            lvMeslekHastaligiListesi.View = View.Details;
            lvMeslekHastaligiListesi.FullRowSelect = true;
            ListViewMeslekHastaliklari(lvMeslekHastaligiListesi);

            cbIsKazasiGerceklestigiBolum.ResetText();
            cbIsKazasiGerceklestigiBolum.Items.Clear();
        }

        private void ListViewIsKazalari(ListView Liste)
        {
            Liste.Columns.Add("ID", 0);
            Liste.Columns.Add("ID", 40);
            Liste.Columns.Add("Kaza Sebebi", 275);
            Liste.Columns.Add("Kaç Kişi", 60);
            Liste.Columns.Add("Tarih", 150);
        }

        private void ListViewMeslekHastaliklari(ListView Liste)
        {
            Liste.Columns.Add("ID", 0);
            Liste.Columns.Add("ID", 40);
            Liste.Columns.Add("Hastalık Adı", 275);
            Liste.Columns.Add("Kaç Kişi", 60);
            Liste.Columns.Add("Tarih", 150);
        }

        private void btnGirisYap_Click(object sender, EventArgs e)
        {
            foreach (var item in y.YetkililerListe)
            {
                if ((item.KullaniciAdi == txtKullaniciKodu.Text) && (item.Sifre == txtIsyeriSifresi.Text))
                {
                    tabControl1.TabPages.Insert(1, tabIsyeriBilgileri);
                    tabControl1.TabPages.Insert(2, tabIsKazalari);
                    tabControl1.TabPages.Insert(3, tabMeslekHastaliklari);
                    tabControl1.TabPages.Insert(4, tabHastaneRaporları);
                    btnGirisYap.Enabled = false;
                    btnCikisYap.Enabled = true;
                    txtKullaniciKodu.Text = "";
                    txtKullaniciKodu.Enabled = false;
                    txtIsyeriSifresi.Text = "";
                    txtIsyeriSifresi.Enabled = false;
                    YetkiliKisiAdi = item.Ad;
                    YetkiliKisiSoyadi = item.Soyad;
                    break;
                }
            }

            BagliOlduguIl_lbl.Text = "Manisa";
            IsyeriAdresi_lbl.Text = "Tevfikiye Mh. 8 Eylül Cd. No: 135 45120 Yunusemre/Manisa";
            IsyeriFax_lbl.Text = "02362425768";
            IsyeriSicilNo_lbl.Text = "968808478";
            IsyeriTel_lbl.Text = "02362425766";
            IsyeriUnvani_lbl.Text = "Türkiye Cumhuriyeti Sosyal Güvenlik Kurumu";
            VergiDairesiAdi_lbl.Text = "Manisa Sosyal Güvenlik İl Müdürlüğü";
            VergiDairesiNumarasi_lbl.Text = "617793973";
            BaslangicSaat_lbl.Text = "09";
            BaslangicDakika_lbl.Text = "00";
            BitisSaat_lbl.Text = "17";
            BitisDakika_lbl.Text = "00";
            IsciSayisi_Erkek_lbl.Text = "108";
            IsciSayisi_Kadin_lbl.Text = "44";
            IsciSayisi_Cocuk_lbl.Text = "0";
            IsciSayisi_EskiHukumlu_lbl.Text = "0";
            IsciSayisi_Hukumlu_lbl.Text = "0";
            IsciSayisi_Ozurlu_lbl.Text = "12";
            IsciSayisi_StajerCirak_lbl.Text = "10";
            IsciSayisi_TerorMagduru_lbl.Text = "17";
            IsciSayisi_GenelToplam_lbl.Text = "191";


            foreach (var item in y.YetkililerListe)
            {
                if ((item.Ad == YetkiliKisiAdi) && (item.Soyad == YetkiliKisiSoyadi))
                {
                    BildirimHazirlayan_TCKimlikNo_lbl.Text = item.TCKimlikNo;
                    BildirimHazirlayan_AdSoyad_lbl.Text = item.Ad + " " + item.Soyad;
                    BildirimHazirlayan_Tel_lbl.Text = item.Telefon;
                    BildirimHazirlayan_Faks_lbl.Text = item.Fax;
                    BildirimHazirlayan_ePosta_lbl.Text = item.ePosta;
                    break;
                }
            }
        }

        private void btnCikisYap_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cbIsKazasininGerceklestigiYer_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbIsKazasiGerceklestigiBolum.ResetText();
            cbIsKazasiGerceklestigiBolum.Items.Clear();
            if (cbIsKazasininGerceklestigiYer.SelectedIndex == 0)
            {
                cbIsKazasiGerceklestigiBolum.Items.Add("Ara Dinlenmesinde");
                cbIsKazasiGerceklestigiBolum.Items.Add("Çalışırken");
            }
            else if (cbIsKazasininGerceklestigiYer.SelectedIndex == 1)
            {
                cbIsKazasiGerceklestigiBolum.Items.Add("İşten Eve Kendi Arabasıyla Gelirken");
                cbIsKazasiGerceklestigiBolum.Items.Add("Evden İşe Kendi Arabasyıla Giderken");
                cbIsKazasiGerceklestigiBolum.Items.Add("İşten Eve Servisle Giderken");
                cbIsKazasiGerceklestigiBolum.Items.Add("Evden İşe Servisle Gelirken");
            }
        }

        private void btnKazaKayitEkle_Click(object sender, EventArgs e)
        {
            IsKazalari ik1 = new IsKazalari();
            ik1.KazayaSebepOlanOlay = txtKazayaSebepOlanOlay.Text;
            ik1.KazayaSebepOlanAracGerec = txtKazayaSebepOlanAracGerec.Text;
            ik1.IsKazasininGerceklestigiYer = cbIsKazasininGerceklestigiYer.Text;
            ik1.IsKazasininGerceklestigiBolum = cbIsKazasiGerceklestigiBolum.Text;
            ik1.KazaSonucuIsGoremezligi = cbIsGoremezlik.Text;
            ik1.KazaSonucuIsGoremezlikSonucu = cbIsGoremezlikSonucu.Text;
            ik1.KazaIhmali = Convert.ToInt32(cbKazaIhmali.Text);
            ik1.KazaSiddeti = Convert.ToInt32(cbKazaSiddeti.Text);
            ik1.KazaninOlusSekliVeSebebi = txtKazaninOlusSekli.Text;
            ik1.KazaSonucuOlusanHastalik = txtIK_KazaSonucuOlusanHastalik.Text;
            ik1.HastalikCozumu = txtIK_HastaliginCozumu.Text;
            ik1.Erkek = Convert.ToInt32(txtIK_Erkek.Text);
            ik1.Kadin = Convert.ToInt32(txtIK_Kadin.Text);
            ik1.Cocuk = Convert.ToInt32(txtIK_Cocuk.Text);
            ik1.Stajer = Convert.ToInt32(txtIK_Stajer.Text);
            ik1.Ozurlu = Convert.ToInt32(txtIK_Ozurlu.Text);
            ik1.Hukumlu = Convert.ToInt32(txtIK_Hukumlu.Text);
            ik1.EskiHukumlu = Convert.ToInt32(txtIK_EskiHukumlu.Text);
            ik1.TerorMagduru = Convert.ToInt32(txtIK_TerorMagduru.Text);
            ik1.KazayaUgrayanKisiSayisi = ik1.Erkek + ik1.Kadin + ik1.Cocuk + ik1.Stajer + ik1.Ozurlu + ik1.Hukumlu + ik1.EskiHukumlu + ik1.TerorMagduru;
            ik1.TibbiMudahaleYapildiMi = cbTibbiMudahaleYapildiMi.Text;
            ik1.TibbiMudahalecininAdiSoyadi = txtMudahaleciAdiSoyadi.Text;
            ik1.TibbiMudahaleninYapildigiIl = txtTibbiMudahaleIl.Text;
            ik1.TibbiMudahaleninYapildigiIlce = txtTibbiMudahaleIlce.Text;
            ik1.TibbiMudahaleninYapildigiTarih = Convert.ToDateTime(dtTibbiMudahale.Text);
            ik1.TibbiMudahaleninYapildigiAdres = txtTibbiMudahaleAdres.Text;
            ik1.TibbiMudahaleninYapildigiSaat = Convert.ToInt32(cbTibbiMudahaleSaat.Text);
            ik1.TibbiMudahaleninYapildigiDakika = Convert.ToInt32(cbTibbiMudahaleDakika.Text);
            if (checkIKekle.Checked == true)
            {
                ik1.OnaylandiMi = "Evet";
                db.IsKazalari.Add(ik1);
                db.SaveChanges();
                label26.Text = Convert.ToString(ik1.Erkek);
                label19.Text = Convert.ToString(ik1.Cocuk);
                label33.Text = Convert.ToString(ik1.Kadin);
                label21.Text = Convert.ToString(ik1.Stajer);
                label29.Text = Convert.ToString(ik1.Ozurlu);
                label31.Text = Convert.ToString(ik1.Hukumlu);
                label18.Text = Convert.ToString(ik1.EskiHukumlu);
                label20.Text = Convert.ToString(ik1.TerorMagduru);
                label34.Text = Convert.ToString(ik1.KazayaUgrayanKisiSayisi);

                label8.Text = "Manisa";
                label6.Text = "Manisa Sosyal Güvenlik İl Müdürlüğü";
                label10.Text = "Türkiye Cumhuriyeti Sosyal Güvenlik Kurumu";
                label11.Text = "Tevfikiye Mh. 8 Eylül Cd. No: 135 45120 Yunusemre/Manisa";
                label7.Text = "968808478";
                label5.Text = "617793973";

                HastalikAdi_lbl.Text = ik1.KazaSonucuOlusanHastalik;
                HastalikCozumu_lbl.Text = ik1.HastalikCozumu;
                label132.Text = Convert.ToString(ik1.KazaIhmali * ik1.KazaSiddeti);
                IzninBasladigiTarih_lbl.Text = Convert.ToString(ik1.TibbiMudahaleninYapildigiTarih);

                if      (label132.Text == "1")  { DinlenmeSuresi_lbl.Text = "İş yerinden en az 1 günlük izin."; }
                else if (label132.Text == "2")  { DinlenmeSuresi_lbl.Text = "İş yerinden en az 2 günlük izin."; }
                else if (label132.Text == "3")  { DinlenmeSuresi_lbl.Text = "İş yerinden en az 3 günlük izin."; }
                else if (label132.Text == "4")  { DinlenmeSuresi_lbl.Text = "İş yerinden en az 5 günlük izin."; }
                else if (label132.Text == "5")  { DinlenmeSuresi_lbl.Text = "İş yerinden en az 7 günlük izin."; }
                else if (label132.Text == "6")  { DinlenmeSuresi_lbl.Text = "İş yerinden en az 10 günlük izin."; }
                else if (label132.Text == "8")  { DinlenmeSuresi_lbl.Text = "İş yerinden en az 12 günlük izin."; }
                else if (label132.Text == "9")  { DinlenmeSuresi_lbl.Text = "İş yerinden en az 15 günlük izin."; }
                else if (label132.Text == "10") { DinlenmeSuresi_lbl.Text = "İş yerinden en az 20 günlük izin."; }
                else if (label132.Text == "12") { DinlenmeSuresi_lbl.Text = "İş yerinden en az 25 günlük izin."; }
                else if (label132.Text == "15") { DinlenmeSuresi_lbl.Text = "İş yerinden en az 30 günlük izin."; }
                else if (label132.Text == "16") { DinlenmeSuresi_lbl.Text = "İş yerinden en az 45 günlük izin."; }
                else if (label132.Text == "20") { DinlenmeSuresi_lbl.Text = "İş yerinden en az 60 günlük izin."; }
                else if (label132.Text == "25") { DinlenmeSuresi_lbl.Text = "İş yerinden en az 120 günlük izin."; }

                MessageBox.Show("İş kazası eklenmiştir.\nRapor dökümanını 'Hastane Raporları' sayfasından hastaneye gönderebilirsiniz.");
            }
            else
            {
                MessageBox.Show("Bildirim onay kutucuğuna tıklayınız.");
            }
            tabControl3.SelectedTab = tabHastalikGuncelle;
        }

        private void btnKazaKayitGoruntule_Click(object sender, EventArgs e)
        {
            KazaKayitGoruntule();
        }

        private void KazaKayitGoruntule()
        {
            int sayac = 0;
            lvIsKazalariListesi.Clear();
            lvIsKazalariListesi.View = View.Details;
            lvIsKazalariListesi.FullRowSelect = true;
            ListViewIsKazalari(lvIsKazalariListesi);
            foreach (var item in db.IsKazalari)
            {
                sayac++;
                string[] row = { item.Id.ToString(), sayac.ToString(), item.KazayaSebepOlanOlay.ToString(), item.KazayaUgrayanKisiSayisi.ToString(), item.TibbiMudahaleninYapildigiTarih.ToString() };
                ListViewItem veriler = new ListViewItem(row);
                lvIsKazalariListesi.Items.Add(veriler);
            }
        }

        private void btnKazaKayitSil_Click(object sender, EventArgs e)
        {
            int kazaID = Convert.ToInt32(lvIsKazalariListesi.SelectedItems[0].SubItems[0].Text);
            IsKazalari ik1 = db.IsKazalari.Where(x => x.Id == kazaID).FirstOrDefault();
            db.IsKazalari.Remove(ik1);
            db.SaveChanges();
            KazaKayitGoruntule();
        }

        private void btnMHekle_Click(object sender, EventArgs e)
        {
            MeslekHastaliklari mh1 = new MeslekHastaliklari();
            mh1.MeslekHastaligiTanisiTarihi = Convert.ToDateTime(dtMH_TaniTarihi.Text);
            mh1.SaptanmaSekli = txtSaptanmaSekli.Text;
            mh1.MeslekHastaligiTanisi = txtMeslekHastaligiTanisi.Text;
            mh1.MeslekHastaligiTanisiAltGrup = txtMeslekHastaligiTanisiAltGrup.Text;
            mh1.HastaligaMaruzKalmaSuresi = txtHastaligaMaruzKalmaSuresi.Text;
            mh1.HastaligaNedenOlanEtken = txtHastaligaNedenOlanEtken.Text;
            mh1.HastaligaNedenOlanAltEtken = txtHastaligaNedenOlanAltEtken.Text;
            mh1.IsGoremezlikDurumu = txtIsGoremezlikDurumu.Text;
            mh1.HastaliginCozumu = txtMH_HastaliginCozumu.Text;
            mh1.Erkek = Convert.ToInt32(txtMH_Erkek.Text);
            mh1.Kadin = Convert.ToInt32(txtMH_Kadin.Text);
            mh1.Cocuk = Convert.ToInt32(txtMH_Cocuk.Text);
            mh1.Stajer = Convert.ToInt32(txtMH_Stajer.Text);
            mh1.Ozurlu = Convert.ToInt32(txtMH_Ozurlu.Text);
            mh1.Hukumlu = Convert.ToInt32(txtMH_Hukumlu.Text);
            mh1.EskiHukumlu = Convert.ToInt32(txtMH_EskiHukumlu.Text);
            mh1.TerorMagduru = Convert.ToInt32(txtMH_TerorMagduru.Text);
            mh1.Toplam = mh1.Erkek + mh1.Kadin + mh1.Cocuk + mh1.Stajer + mh1.Ozurlu + mh1.Hukumlu + mh1.EskiHukumlu + mh1.TerorMagduru;
            mh1.IsGuvenligiEgitimiAlmisMi = cbIsGuvenligiEgitimiAlmisMi.Text;
            mh1.MeslekiEgitimAlmisMi = cbMeslekiEgitimAlmisMi.Text;
            mh1.PrimOdemeDurumu = cbPrimOdemeHali.Text;
            if (checkMHonayla.Checked == true)
            {
                mh1.OnaylandiMi = "Evet";
                db.MeslekHastaliklari.Add(mh1);
                db.SaveChanges();

                Erkek_lbl_MH.Text = Convert.ToString(mh1.Erkek);
                Kadin_lbl_MH.Text = Convert.ToString(mh1.Kadin);
                Cocuk_lbl_MH.Text = Convert.ToString(mh1.Cocuk);
                Ozurlu_lbl_MH.Text = Convert.ToString(mh1.Ozurlu);
                Stajer_lbl_MH.Text = Convert.ToString(mh1.Stajer);
                Hukumlu_lbl_MH.Text = Convert.ToString(mh1.Hukumlu);
                EskiHukumlu_lbl_MH.Text = Convert.ToString(mh1.EskiHukumlu);
                TerorMagduru_lbl_MH.Text = Convert.ToString(mh1.TerorMagduru);
                label75.Text = Convert.ToString(mh1.Toplam);

                BagliOlduguIl_lbl_MH.Text = "Manisa";
                VergiDairesiAdi_lbl_MH.Text = "Manisa Sosyal Güvenlik İl Müdürlüğü";
                IsyeriUnvani_lbl_MH.Text = "Türkiye Cumhuriyeti Sosyal Güvenlik Kurumu";
                IsyeriAdresi_lbl_MH.Text = "Tevfikiye Mh. 8 Eylül Cd. No: 135 45120 Yunusemre/Manisa";
                IsyeriSicilNo_lbl_MH.Text = "968808478";
                VergiDairesiNumarasi_lbl_MH.Text = "617793973";

                HastalikAdi_lbl_MH.Text = mh1.HastaligaNedenOlanEtken;
                HastalikCozumu_lbl_MH.Text = mh1.HastaliginCozumu;
                IzninBasladigiTarih_lbl.Text = Convert.ToString(mh1.MeslekHastaligiTanisiTarihi);

                MessageBox.Show("Meslek hastalığı eklenmiştir.\nRapor dökümanını 'Hastane Raporları' sayfasından hastaneye gönderebilirsiniz.");
            }
            else
            {
                MessageBox.Show("Bildirim onay kutucuğuna tıklayınız.");
            }
        }

        /*private void btnMeslekHastaligiGuncelle_Click(object sender, EventArgs e)
        {
        }*/

        private void btnMH_KayitlariGoruntule_Click(object sender, EventArgs e)
        {
            MeslekHastaliklariKayitGoruntule();
        }

        private void MeslekHastaliklariKayitGoruntule()
        {
            int sayac = 0;
            lvMeslekHastaligiListesi.Clear();
            lvMeslekHastaligiListesi.View = View.Details;
            lvMeslekHastaligiListesi.FullRowSelect = true;
            ListViewMeslekHastaliklari(lvMeslekHastaligiListesi);
            foreach (var item in db.MeslekHastaliklari)
            {
                sayac++;
                string[] row = { item.Id.ToString(), sayac.ToString(), item.MeslekHastaligiTanisi.ToString(), item.Toplam.ToString(), item.MeslekHastaligiTanisiTarihi.ToString() };
                ListViewItem veriler = new ListViewItem(row);
                lvMeslekHastaligiListesi.Items.Add(veriler);
            }
        }

        private void btnMH_KayitGuncelle_Click(object sender, EventArgs e)
        {
            int mhID = Convert.ToInt32(lvMeslekHastaligiListesi.SelectedItems[0].SubItems[0].Text);
            meslekhastaligiID = Convert.ToInt32(lvMeslekHastaligiListesi.SelectedItems[0].SubItems[0].Text);
            foreach (var mh1 in db.MeslekHastaliklari)
            {
                if (mhID == mh1.Id)
                {
                    dtMH_TaniTarihi.Text = Convert.ToString(mh1.MeslekHastaligiTanisiTarihi);
                    txtMHG_SaptanmaSekli.Text = mh1.SaptanmaSekli;
                    txtMHG_MeslekHastaligiTanisi.Text = mh1.MeslekHastaligiTanisi;
                    txtMHG_MeslekHastaligiAltGrup.Text = mh1.MeslekHastaligiTanisiAltGrup;
                    txtMHG_HastaligaMaruzKalmaSuresi.Text = mh1.HastaligaMaruzKalmaSuresi;
                    txtMHG_HastaligaNedenOlanEtken.Text = mh1.HastaligaNedenOlanEtken;
                    txtMHG_HastaligaNedenOlanAltEtken.Text = mh1.HastaligaNedenOlanAltEtken;
                    txtMHG_IsGoremezlikDurumu.Text = mh1.IsGoremezlikDurumu;
                    txtMHG_HastaliginCozumu.Text = mh1.HastaliginCozumu;
                    txtMHG_Erkek.Text = Convert.ToString(mh1.Erkek);
                    txtMHG_Kadin.Text = Convert.ToString(mh1.Kadin);
                    txtMHG_Cocuk.Text = Convert.ToString(mh1.Cocuk);
                    txtMHG_Stajer.Text = Convert.ToString(mh1.Stajer);
                    txtMHG_Ozurlu.Text = Convert.ToString(mh1.Ozurlu);
                    txtMHG_Hukumlu.Text = Convert.ToString(mh1.Hukumlu);
                    txtMHG_EskiHukumlu.Text = Convert.ToString(mh1.EskiHukumlu);
                    txtMHG_TerorMagduru.Text = Convert.ToString(mh1.TerorMagduru);

                    Erkek_lbl_MH.Text = Convert.ToString(mh1.Erkek);
                    Kadin_lbl_MH.Text = Convert.ToString(mh1.Kadin);
                    Cocuk_lbl_MH.Text = Convert.ToString(mh1.Cocuk);
                    Ozurlu_lbl_MH.Text = Convert.ToString(mh1.Ozurlu);
                    Stajer_lbl_MH.Text = Convert.ToString(mh1.Stajer);
                    Hukumlu_lbl_MH.Text = Convert.ToString(mh1.Hukumlu);
                    EskiHukumlu_lbl_MH.Text = Convert.ToString(mh1.EskiHukumlu);
                    TerorMagduru_lbl_MH.Text = Convert.ToString(mh1.TerorMagduru);
                    label75.Text = Convert.ToString(mh1.Toplam);

                    BagliOlduguIl_lbl_MH.Text = "Manisa";
                    VergiDairesiAdi_lbl_MH.Text = "Manisa Sosyal Güvenlik İl Müdürlüğü";
                    IsyeriUnvani_lbl_MH.Text = "Türkiye Cumhuriyeti Sosyal Güvenlik Kurumu";
                    IsyeriAdresi_lbl_MH.Text = "Tevfikiye Mh. 8 Eylül Cd. No: 135 45120 Yunusemre/Manisa";
                    IsyeriSicilNo_lbl_MH.Text = "968808478";
                    VergiDairesiNumarasi_lbl_MH.Text = "617793973";

                    HastalikAdi_lbl_MH.Text = mh1.HastaligaNedenOlanEtken;
                    HastalikCozumu_lbl_MH.Text = mh1.HastaliginCozumu;
                    IzninBasladigiTarih_lbl_MH.Text = Convert.ToString(mh1.MeslekHastaligiTanisiTarihi);
                }
            }
            tabControl3.SelectedTab = tabHastalikGuncelle;
        }

        private void btnMH_KayitSil_Click(object sender, EventArgs e)
        {
            int mhID = Convert.ToInt32(lvMeslekHastaligiListesi.SelectedItems[0].SubItems[0].Text);
            MeslekHastaliklari mh1 = db.MeslekHastaliklari.Where(x => x.Id == mhID).FirstOrDefault();
            db.MeslekHastaliklari.Remove(mh1);
            db.SaveChanges();
            MeslekHastaliklariKayitGoruntule();
        }

        private void btnMHG_Click(object sender, EventArgs e)
        {
            foreach (var item in db.MeslekHastaliklari)
            {
                if (item.Id == meslekhastaligiID)
                {
                    item.MeslekHastaligiTanisiTarihi = Convert.ToDateTime(dtMHG.Text);
                    item.SaptanmaSekli = txtMHG_SaptanmaSekli.Text;
                    item.MeslekHastaligiTanisi = txtMHG_MeslekHastaligiTanisi.Text;
                    item.MeslekHastaligiTanisiAltGrup = txtMHG_MeslekHastaligiAltGrup.Text;
                    item.HastaligaMaruzKalmaSuresi = txtMHG_HastaligaMaruzKalmaSuresi.Text;
                    item.HastaligaNedenOlanEtken = txtMHG_HastaligaNedenOlanEtken.Text;
                    item.HastaligaNedenOlanAltEtken = txtMHG_HastaligaNedenOlanAltEtken.Text;
                    item.IsGoremezlikDurumu = txtMHG_IsGoremezlikDurumu.Text;
                    item.HastaliginCozumu = txtMHG_HastaliginCozumu.Text;
                    item.Erkek = Convert.ToInt32(txtMHG_Erkek.Text);
                    item.Kadin = Convert.ToInt32(txtMHG_Kadin.Text);
                    item.Cocuk = Convert.ToInt32(txtMHG_Cocuk.Text);
                    item.Stajer = Convert.ToInt32(txtMHG_Stajer.Text);
                    item.Ozurlu = Convert.ToInt32(txtMHG_Ozurlu.Text);
                    item.Hukumlu = Convert.ToInt32(txtMHG_Hukumlu.Text);
                    item.EskiHukumlu = Convert.ToInt32(txtMHG_EskiHukumlu.Text);
                    item.TerorMagduru = Convert.ToInt32(txtMHG_TerorMagduru.Text);
                    item.Toplam = item.Erkek + item.Kadin + item.Cocuk + item.Stajer + item.Ozurlu + item.Hukumlu + item.EskiHukumlu + item.TerorMagduru;
                    item.IsGuvenligiEgitimiAlmisMi = cbMHG_IsGuvenligiEgitimiAlmisMi.Text;
                    item.MeslekiEgitimAlmisMi = cbMHG_MeslekiEgitimAlmisMi.Text;
                    item.PrimOdemeDurumu = cbMHG_PrimOdemeHali.Text;
                    if (checkMHG_Onayla.Checked == true)
                    {
                        item.OnaylandiMi = "Evet";
                    }
                    else
                    {
                        MessageBox.Show("Bildirim onay kutucuğuna tıklayınız.");
                    }
                }
                MeslekHastaliklariKayitGoruntule();
                tabControl3.SelectedTab = tabHastalikListele;
            }
        }

        private void btnIK_HastaneyeRaporGonder_Click(object sender, EventArgs e)
        {
            DialogResult sonuc = MessageBox.Show("Rapordaki İş Kazası bildirim kaydı hastaneye gönderilecektir. Onaylıyor musunuz?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (sonuc == DialogResult.Yes)
            {
                HastaneRaporlari hr1 = new HastaneRaporlari();
                hr1.Erkek = Convert.ToInt32(label26.Text);
                hr1.Kadin = Convert.ToInt32(label33.Text);
                hr1.Cocuk = Convert.ToInt32(label19.Text);
                hr1.Stajer = Convert.ToInt32(label21.Text);
                hr1.Ozurlu = Convert.ToInt32(label29.Text);
                hr1.Hukumlu = Convert.ToInt32(label31.Text);
                hr1.EskiHukumlu = Convert.ToInt32(label18.Text);
                hr1.TerorMagduru = Convert.ToInt32(label20.Text);
                hr1.Toplam = Convert.ToInt32(label34.Text);
                hr1.Hastalik = Convert.ToString(HastalikAdi_lbl.Text);
                hr1.HastalikCozumu = Convert.ToString(HastalikCozumu_lbl.Text);
                hr1.IzninBasladigiTarih = Convert.ToDateTime(IzninBasladigiTarih_lbl.Text);
                hr1.DinlenmeSuresi = Convert.ToString(DinlenmeSuresi_lbl.Text);
                db.HastaneRaporlari.Add(hr1);
                db.SaveChanges();
                MessageBox.Show("Rapor, anlaşmalı hastaneye gönderilmiştir. Teşekkürler!", "Sonuç");

                label26.Text = ""; label19.Text = ""; label33.Text = ""; label21.Text = ""; label29.Text = ""; label31.Text = "";
                label18.Text = ""; label20.Text = ""; label34.Text = ""; label8.Text = ""; label6.Text = ""; label10.Text = "";
                label11.Text = ""; label7.Text = ""; label5.Text = ""; HastalikAdi_lbl.Text = ""; HastalikCozumu_lbl.Text = "";
                label132.Text = ""; IzninBasladigiTarih_lbl.Text = ""; DinlenmeSuresi_lbl.Text = "";
            }
            else
            {
                MessageBox.Show("Raporun gönderimi onaylanmamıştır.", "Sonuç");
            }
        }

        private void btnMH_HastaneyeRaporGonder_Click(object sender, EventArgs e)
        {
            DialogResult sonuc = MessageBox.Show("Rapordaki Meslek Hastalığı bildirim kaydı hastaneye gönderilecektir. Onaylıyor musunuz?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (sonuc == DialogResult.Yes)
            {
                HastaneRaporlari hr1 = new HastaneRaporlari();
                hr1.Erkek = Convert.ToInt32(Erkek_lbl_MH.Text);
                hr1.Kadin = Convert.ToInt32(Kadin_lbl_MH.Text);
                hr1.Cocuk = Convert.ToInt32(Cocuk_lbl_MH.Text);
                hr1.Stajer = Convert.ToInt32(Stajer_lbl_MH.Text);
                hr1.Ozurlu = Convert.ToInt32(Ozurlu_lbl_MH.Text);
                hr1.Hukumlu = Convert.ToInt32(Hukumlu_lbl_MH.Text);
                hr1.EskiHukumlu = Convert.ToInt32(EskiHukumlu_lbl_MH.Text);
                hr1.TerorMagduru = Convert.ToInt32(TerorMagduru_lbl_MH.Text);
                hr1.Toplam = Convert.ToInt32(label75.Text);
                hr1.Hastalik = Convert.ToString(HastalikAdi_lbl_MH.Text);
                hr1.HastalikCozumu = Convert.ToString(HastalikCozumu_lbl_MH.Text);
                hr1.IzninBasladigiTarih = Convert.ToDateTime(IzninBasladigiTarih_lbl_MH.Text);
                db.HastaneRaporlari.Add(hr1);
                db.SaveChanges();
                MessageBox.Show("Rapor, anlaşmalı hastaneye gönderilmiştir. Teşekkürler!", "Sonuç");
                Erkek_lbl_MH.Text = ""; Kadin_lbl_MH.Text = ""; Cocuk_lbl_MH.Text = ""; Stajer_lbl_MH.Text = ""; Ozurlu_lbl_MH.Text = "";
                Hukumlu_lbl_MH.Text = ""; EskiHukumlu_lbl_MH.Text = ""; TerorMagduru_lbl_MH.Text = ""; label75.Text = ""; HastalikAdi_lbl_MH.Text = "";
                HastalikCozumu_lbl_MH.Text = ""; IzninBasladigiTarih_lbl_MH.Text = "";
            }
            else
            {
                MessageBox.Show("Raporun gönderimi onaylanmamıştır.", "Sonuç");
            }
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
    }
}
