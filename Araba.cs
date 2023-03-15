using System;
using System.Collections.Generic;
using System.Text;

namespace OtoGaleriUygulamasi
{
    class Araba
    {
        public string Plaka { get; set; }
        public string Marka { get; set; }
        public float KiralamaBedeli { get; set; }
        public ARAC_TIPI AracTipi { get; set; }
        public DURUM Durum { get; set; }

        public List<int> KiralamaSureleri = new List<int>();



        public int KiralanmaAdedi
        {
            get
            {
                return this.KiralamaSureleri.Count;
            }
        }
        
        
        public int ToplamKiralanmaSuresi
        {
            get
            {
                int toplam = 0;
                foreach (int item in this.KiralamaSureleri)
                {
                    toplam += item;
                }
                return toplam;
            }
        }

        public float Ciro
        {
            get
            {
                float ciro = 0;
                foreach (int a in this.KiralamaSureleri)
                {
                    ciro += a * this.KiralamaBedeli;
                }
                return ciro;
            }
        }



        public Araba(string plaka, string marka, float kiralamaBedeli, ARAC_TIPI aracTipi)
        {
            this.Plaka = plaka;
            this.Marka = marka;
            this.KiralamaBedeli = kiralamaBedeli;
            this.AracTipi = aracTipi;
            this.Durum = DURUM.Galeride;
        }


    }

    public enum DURUM
    {
        Empty,
        Kirada,
        Galeride
    }

    public enum ARAC_TIPI
    {
        Empty,
        Sedan,
        SUV,
        Hatcback
    }


    //public enum MARKA
    //{
    //    Empty,
    //    FIAT,
    //    OPEL,
    //    FORD
    //}


}
