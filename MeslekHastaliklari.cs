using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMB
{
    public class MeslekHastaliklari
    {
        public int Id { get; set; }
        public DateTime MeslekHastaligiTanisiTarihi { get; set; }
        public string SaptanmaSekli { get; set; }
        public string MeslekHastaligiTanisi { get; set; }
        public string MeslekHastaligiTanisiAltGrup { get; set; }
        public string HastaligaMaruzKalmaSuresi { get; set; }
        public string HastaligaNedenOlanEtken { get; set; }
        public string HastaligaNedenOlanAltEtken { get; set; }
        public string IsGoremezlikDurumu { get; set; }
        public string HastaliginCozumu { get; set; }
        public int Erkek { get; set; }
        public int Kadin { get; set; }
        public int Cocuk { get; set; }
        public int Stajer { get; set; }
        public int Ozurlu { get; set; }
        public int Hukumlu { get; set; }
        public int EskiHukumlu { get; set; }
        public int TerorMagduru { get; set; }
        public int Toplam { get; set; }
        public string IsGuvenligiEgitimiAlmisMi { get; set; }
        public string MeslekiEgitimAlmisMi { get; set; }
        public string PrimOdemeDurumu { get; set; }
        public string OnaylandiMi { get; set; }
    }
}
