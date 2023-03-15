using System;
using System.Collections.Generic;
using System.Text;

namespace OtoGaleriUygulamasi
{
    class Galeri
    {
        public List<Araba> Arabalar = new List<Araba>();
        public int ToplamAracSayisi
        {
            get
            {
                return this.Arabalar.Count;
            }
        }
        public int KiradakiAracSayisi
        {
            get
            {
                int adet = 0;
                foreach (Araba item in this.Arabalar)
                {
                    if (item.Durum == DURUM.Kirada)
                    {
                        adet++;
                    }
                }
                return adet;
            }
        }
        public int GaleridekiAracSayisi
        {
            get
            {
                int adet = 0;
                foreach (Araba item in this.Arabalar)
                {
                    if (item.Durum == DURUM.Galeride)
                    {
                        adet++;
                    }
                }
                return adet;
            }
        }


        public int ToplamAracKiralanmaSuresi { get; set; }

        public int ToplamAracKiralanmaAdedi { get; set; }

        


        public void ArabaKirala(string plaka, int sure)
        {
            Araba a = null;

            foreach (Araba item in this.Arabalar)
            {
                if (item.Plaka == plaka.ToUpper())
                {
                    a = item;
                    break;
                }
            }

            if (a != null)
            {
                if (a.Durum == DURUM.Kirada)
                {
                    Console.WriteLine("Araç müsait değil başka bir araç seçin");
                    return;
                }

                Console.Write("Kiralama süresi:");
                sure += int.Parse(Console.ReadLine());
                a.Durum = DURUM.Kirada;
                a.KiralamaSureleri.Add(sure);

                Console.WriteLine(a.Plaka + " " + "plakalı araç" + " " + sure + " " + "saatliğine kiralandı.");
            }
            else
            {
                Console.WriteLine("Galeride bu plakada bir araç yoktur.");
            }
        }

        public void ArabaTeslimAl(string plaka)
        {
            Araba a = null;

            foreach (Araba item in this.Arabalar)
            {
                if (item.Plaka == plaka.ToUpper())
                {
                    a = item;
                    break;
                }
            }
            if (a != null)
            {
                if (a.Durum == DURUM.Galeride)
                {
                    Console.WriteLine("Hatalı giriş yapıldı. Araç zaten galeride.");
                    return;
                }
                else
                {
                    a.Durum = DURUM.Galeride;
                    Console.WriteLine("Araç galeride beklemeye alındı.");
                }
            }
            else
            {
                Console.WriteLine("Galeriye ait bu plakada bir araç yok.");
            }
        }

        public void ArabaSil(string plaka)
        {
            Araba a = null;

            foreach (Araba item in this.Arabalar)
            {
                if (item.Plaka == plaka.ToUpper())
                {
                    a = item;
                    break;
                }
            }
            if (a != null)
            {
                if (a.Durum == DURUM.Kirada)
                {
                    Console.WriteLine("Kirada olan bir aracı silemezsiniz.");
                    return;
                }
                else
                {
                    Arabalar.Remove(a);
                    Console.WriteLine("Araç silindi.");
                }
            }
            else
            {
                Console.WriteLine("Galeriye ait bu plakada bir araç yok.");
            }


            
        }


















    }
}
