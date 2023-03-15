using System;
using System.Collections.Generic;
using System.Text;

namespace OtoGaleriUygulamasi
{
    class Uygulama
    {
        Galeri OtoGaleri = new Galeri();

        public void Calistir()
        {
            OtoGaleriUygulamasi();
        }

        public void OtoGaleriUygulamasi()
        {
            SahteVeriGir();
            Menu();
            while (true)
            {
                string secim = SecimAl();

                switch (secim)
                {
                    case "1":
                    case "K":
                        ArabaKiralamaIslemleri();
                        break;
                    case "2":
                    case "T":
                        ArabaTeslimAlmaIslemleri();
                        break;
                    case "3":
                    case "R":
                        KiradakiArabalariListele();
                        break;
                    case "4":
                    case "M":
                        MüsaitArabalariListele();
                        break;
                    case "5":
                    case "A":
                        TümArabalariListele();
                        break;
                    case "6":
                    case "Y":
                        YeniArabaEklemeIslemleri();
                        break;
                    case "7":
                    case "S":
                        ArabaSil();
                        break;
                    case "8":
                    case "G":
                        BilgileriGöster();
                        break;
                    case "9":
                    case "C":
                        return;
                    default:
                        Console.WriteLine("Hatalı tuşlama yaptnız.Tekrar deneyin.");
                        continue;
                }
            }
        }

        public string SecimAl()
        {
            Console.WriteLine();
            Console.Write("Seçim: ");
            return Console.ReadLine().ToUpper();
        }


        public void Menu()
        {
            Console.WriteLine("-------Galeri Otomasyon-------");
            Console.WriteLine("1 - Araba Kirala(K)");
            Console.WriteLine("2 - Araba Teslim Al(T)");
            Console.WriteLine("3 - Kiradaki Arabaları Listele(R)");
            Console.WriteLine("4 - Müsait Arabaları Listele(M)");
            Console.WriteLine("5 - Tüm Arabaları Listele(A)");
            Console.WriteLine("6 - Yeni Araba Ekle(Y)");
            Console.WriteLine("7 - Araba Sil(S)");
            Console.WriteLine("8 - Bilgileri Göster(G)");
            Console.WriteLine("9 - Çıkış(C)");
        }


        public void ArabaKiralamaIslemleri()
        {
            Console.WriteLine("- Araç Kiralama Islemleri -");
            Console.Write("Kiralanacak aracın plakası: ");
            string plaka = Console.ReadLine();
            int sure = 0;
            OtoGaleri.ArabaKirala(plaka, sure);
        }

        public void ArabaTeslimAlmaIslemleri()
        {
            Console.WriteLine("-Araba Teslim Alma Islemleri-");
            Console.Write("Teslim edilecek aracın plakası: ");
            string plaka = Console.ReadLine();
            OtoGaleri.ArabaTeslimAl(plaka);
        }
        public void KiradakiArabalariListele()
        {
            Console.WriteLine("-Kiradaki Arabalari Listeleme-");

            Console.WriteLine();

            if (OtoGaleri.KiradakiAracSayisi == 0)
            {
                Console.WriteLine("Kirada araç bulunmamaktadır.");
                return;
            }
            else
            {
                Console.WriteLine("Plaka          Marka         K.Bedeli        Araç Tipi       K.Sayısı       Durum      ");
                Console.WriteLine("---------------------------------------------------------------------------------------");
                foreach (Araba a in OtoGaleri.Arabalar)
                {
                    if (a.Durum == DURUM.Kirada)
                    {
                        Console.WriteLine(a.Plaka.PadRight(15) + a.Marka.PadRight(14) + a.KiralamaBedeli.ToString().PadRight(16) + a.AracTipi.ToString().PadRight(16) + a.KiralanmaAdedi.ToString().PadRight(15) + a.Durum.ToString().PadRight(11));
                    }
                }
            }
        }
        public void MüsaitArabalariListele()
        {
            Console.WriteLine("-Müsait Arabalari Listeleme-");
            Console.WriteLine();

            if (OtoGaleri.GaleridekiAracSayisi == 0)
            {
                Console.WriteLine("Müsait araç bulunmamaktadır.");
                return;
            }
            else
            {
                Console.WriteLine("Plaka          Marka         K.Bedeli        Araç Tipi       K.Sayısı       Durum      ");
                Console.WriteLine("---------------------------------------------------------------------------------------");
                foreach (Araba a in OtoGaleri.Arabalar)
                {
                    if (a.Durum == DURUM.Galeride)
                    {
                        Console.WriteLine(a.Plaka.PadRight(15) + a.Marka.PadRight(14) + a.KiralamaBedeli.ToString().PadRight(16) + a.AracTipi.ToString().PadRight(16) + a.KiralanmaAdedi.ToString().PadRight(15) + a.Durum.ToString().PadRight(11));
                    }
                }
            }
        }
        public void TümArabalariListele()
        {
            Console.WriteLine("-Tüm Arabalari Listele-");
            Console.WriteLine();

            if (OtoGaleri.Arabalar.Count == 0)
            {
                Console.WriteLine("Listede gösterilecek araba yok");
                return;
            }
            else
            {
                Console.WriteLine("Plaka          Marka         K.Bedeli        Araç Tipi       K.Sayısı       Durum      ");
                Console.WriteLine("---------------------------------------------------------------------------------------");
                foreach (Araba a in OtoGaleri.Arabalar)
                {
                    Console.WriteLine(a.Plaka.PadRight(15) + a.Marka.PadRight(14) + a.KiralamaBedeli.ToString().PadRight(16) + a.AracTipi.ToString().PadRight(16) + a.KiralanmaAdedi.ToString().PadRight(15) + a.Durum.ToString().PadRight(11));
                }
            }
        }
        public void YeniArabaEklemeIslemleri()
        {
            Araba a = null;

            Console.WriteLine("-Yeni Araç Ekle-");
            Console.Write("Plaka : ");
            string plaka = Console.ReadLine();

            string ilKodu = plaka.Substring(0, 1);
            string harfler = plaka.Substring(2, 2);
            string sonRakamlar = plaka.Substring(4);
            int s1;
            bool durum1 = int.TryParse(ilKodu, out s1);
            bool durum2 = int.TryParse(harfler, out s1);
            bool durum3 = int.TryParse(sonRakamlar, out s1);

            if (durum1 == false || durum2 == true || durum3 == false)
            {
                Console.WriteLine("Hatalı plaka girdiniz. Tekrar deneyin.");
                return;
            }
            a.Plaka = plaka;

            Console.Write("Marka : ");
            string marka = Console.ReadLine();
            a.Marka = marka;

            Console.Write("Kiralama Bedeli : ");
            int kiraBedeli = int.Parse(Console.ReadLine());
            a.KiralamaBedeli = kiraBedeli;


            Console.WriteLine("Araç Tipleri");
            Console.WriteLine("SUV için 1");
            Console.WriteLine("Hatchback için 2");
            Console.WriteLine("Sedan için 3");
            Console.Write("Araç Tipi : ");
            int aractipi = int.Parse(Console.ReadLine());

            if (aractipi == 0 || aractipi == 1 || aractipi == 2 || aractipi == 3)
            {
                a.ARAC_TIPI = aractipi;
            }
            else
            {
                Console.WriteLine("Hatalı tuşladınız. Tekrar deneyin.");
                return;
            }
            OtoGaleri.Arabalar.Add(a);
            Console.WriteLine("Araç başarılı bir şekilde eklendi.");
        }
        public void ArabaSil()
        {
            Console.WriteLine("-Araba Silme Islemleri-");

            Console.Write("Silmek istediğiniz arabanın plakasını giriniz : ");
            string plaka = Console.ReadLine();
            OtoGaleri.ArabaSil(plaka);

        }
        public void BilgileriGöster()
        {
            Console.WriteLine("-Galeri Bilgileri-");
            Console.WriteLine("Toplam Araç Sayısı : " + OtoGaleri.GaleridekiAracSayisi);
            Console.WriteLine("Kiradaki Araç Sayısı : " + OtoGaleri.KiradakiAracSayisi);
            Console.WriteLine("Bekleyen Araç Sayısı : " + OtoGaleri.GaleridekiAracSayisi);
            Console.WriteLine("Toplam Araç Kiralama Süresi : " + OtoGaleri.ToplamAracKiralanmaSuresi);
            Console.WriteLine("Toplam Araç Kiralama Adedi : " + OtoGaleri.ToplamAracKiralanmaAdedi);
            Console.WriteLine("Ciro : "+ OtoGaleri.Ciro);

        }

        public void SahteVeriGir()
        {
            Araba a = new Araba("11ab1111".ToUpper(), "OPEL", 50, ARAC_TIPI.Hatcback);
            OtoGaleri.Arabalar.Add(a);
            OtoGaleri.Arabalar.Add(new Araba("12ab1212".ToUpper(), "FIAT", 70, ARAC_TIPI.Sedan));
            OtoGaleri.Arabalar.Add(new Araba("13ab1313".ToUpper(), "KIA", 60, ARAC_TIPI.SUV));
            OtoGaleri.Arabalar.Add(new Araba("14ab1414".ToUpper(), "OPEL", 100, ARAC_TIPI.Hatcback));
            OtoGaleri.Arabalar.Add(new Araba("15ab1515".ToUpper(), "KIA", 60, ARAC_TIPI.SUV));
            OtoGaleri.Arabalar.Add(new Araba("16ab1616".ToUpper(), "FIAT", 80, ARAC_TIPI.Sedan));
        }


    }
}
