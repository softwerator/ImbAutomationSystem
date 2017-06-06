using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMB
{
    public class HastaneRaporlari
    {
        public int Id { get; set; }
        public int Erkek { get; set; }
        public int Kadin { get; set; }
        public int Cocuk { get; set; }
        public int Stajer { get; set; }
        public int Ozurlu { get; set; }
        public int Hukumlu { get; set; }
        public int Toplam { get; set; }
        public int EskiHukumlu { get; set; }
        public int TerorMagduru { get; set; }
        public string Hastalik { get; set; }
        public string HastalikCozumu { get; set; }
        public string DinlenmeSuresi { get; set; }
        public DateTime IzninBasladigiTarih { get; set; }
    }
}
