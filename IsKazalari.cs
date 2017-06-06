using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMB
{
    public class IsKazalari
    {
        public int Id { get; set; }
        public string KazayaSebepOlanOlay { get; set; }
        public string KazayaSebepOlanAracGerec { get; set; }
        public string IsKazasininGerceklestigiYer { get; set; }
        public string IsKazasininGerceklestigiBolum { get; set; }
        public string KazaSonucuIsGoremezligi { get; set; }
        public string KazaSonucuIsGoremezlikSonucu { get; set; }
        public string KazaSonucuOlusanHastalik { get; set; }
        public string HastalikCozumu { get; set; }
        public int KazaIhmali { get; set; }
        public int KazaSiddeti { get; set; }
        public int Erkek { get; set; }
        public int Kadin { get; set; }
        public int Cocuk { get; set; }
        public int Stajer { get; set; }
        public int Ozurlu { get; set; }
        public int Hukumlu { get; set; }
        public int EskiHukumlu { get; set; }
        public int TerorMagduru { get; set; }
        public string KazaninOlusSekliVeSebebi { get; set; }
        public int KazayaUgrayanKisiSayisi { get; set; }
        public string TibbiMudahaleYapildiMi { get; set; }
        public string TibbiMudahalecininAdiSoyadi { get; set; }
        public string TibbiMudahaleninYapildigiIl { get; set; }
        public string TibbiMudahaleninYapildigiIlce { get; set; }
        public DateTime TibbiMudahaleninYapildigiTarih { get; set; }
        public string TibbiMudahaleninYapildigiAdres { get; set; }
        public int TibbiMudahaleninYapildigiSaat { get; set; }
        public int TibbiMudahaleninYapildigiDakika { get; set; }
        public string OnaylandiMi { get; set; }
    }
}
