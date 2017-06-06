using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMB
{
    public class Yetkililer
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string TCKimlikNo { get; set; }
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }
        public string Telefon { get; set; }
        public string Fax { get; set; }
        public string ePosta { get; set; }
        public List<Yetkililer> YetkililerListe { get; set; }

        public Yetkililer()
        {
            this.YetkililerListe = new List<Yetkililer>();
        }

        public void YetkiliEkle(Yetkililer y)
        {
            YetkililerListe.Add(y);
        }
    }
}
