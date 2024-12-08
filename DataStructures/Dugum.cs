using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.DataStructures
{
    public class Dugum
    {
        public string Id { get; set; }
        public Yazar YazarBilgisi { get; set; }
        public Dictionary<Dugum, int> Komsular { get; set; }  // <Komşu Düğüm, Kenar Ağırlığı>
        public bool Ziyaret { get; set; }
        public double X { get; set; }  // Görselleştirme için x koordinatı
        public double Y { get; set; }  // Görselleştirme için y koordinatı
        public double Boyut { get; set; }  // Düğümün görsel boyutu
        public string RenkKodu { get; set; }  // Düğümün rengi

        public Dugum(string id, Yazar yazarBilgisi)
        {
            Id = id;
            YazarBilgisi = yazarBilgisi;
            Komsular = new Dictionary<Dugum, int>();
            Ziyaret = false;
            X = 0;
            Y = 0;
            Boyut = 1.0;
            RenkKodu = "#808080"; // Varsayılan gri renk
        }

        public void KomsuEkle(Dugum komsu, int agirlik)
        {
            if (!Komsular.ContainsKey(komsu))
            {
                Komsular.Add(komsu, agirlik);
                if (!komsu.Komsular.ContainsKey(this))
                {
                    komsu.Komsular.Add(this, agirlik); // Çift yönlü bağlantı
                }
            }
            else
            {
                Komsular[komsu] = agirlik;
                komsu.Komsular[this] = agirlik;
            }
        }
        public bool KomsuMu(Dugum digerDugum)
        {
            return Komsular.ContainsKey(digerDugum);
        }

        public int KomsuSayisi()
        {
            return Komsular.Count;
        }

        public void BoyutHesapla(double ortalamaYayinSayisi)
        {
            // Düğümün boyutunu yayın sayısına göre ayarla
            double oran = YazarBilgisi.MakaleSayisi / ortalamaYayinSayisi;
            if (oran > 1.2) // %20 üzerinde
            {
                Boyut = 1.5;
                RenkKodu = "#2F4F4F"; // Koyu gri-mavi
            }
            else if (oran < 0.8) // %20 altında
            {
                Boyut = 0.8;
                RenkKodu = "#B0C4DE"; // Açık mavi
            }
            else
            {
                Boyut = 1.0;
                RenkKodu = "#778899"; // Normal gri-mavi
            }
        }

        public void ZiyaretSifirla()
        {
            Ziyaret = false;
        }

        public List<Dugum> KomsulariGetir()
        {
            return Komsular.Keys.ToList();
        }

        public void KonumAyarla(double x, double y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return YazarBilgisi.ToString();
        }

        public override bool Equals(object obj)
        {
            if (obj is Dugum digerDugum)
            {
                return Id == digerDugum.Id;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
