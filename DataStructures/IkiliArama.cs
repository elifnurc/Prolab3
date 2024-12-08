using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prolab3.Models;

namespace Prolab3.DataStructures
{
    // Ağaç düğümü sınıfı
    public class IkiliArama
    {
        private class Dugum
        {
            public Yazar Veri { get; set; }
            public Dugum Sol { get; set; }
            public Dugum Sag { get; set; }

            public Dugum(Yazar veri)
            {
                Veri = veri;
                Sol = null;
                Sag = null;
            }
        }

        private Dugum kok;
        private int dugumSayisi;

        public IkiliArama()
        {
            kok = null;
            dugumSayisi = 0;
        }

        public void Ekle(Yazar yazar)
        {
            kok = EkleRecursive(kok, yazar);
            dugumSayisi++;
        }

        private Dugum EkleRecursive(Dugum current, Yazar yazar)
        {
            if (current == null)
            {
                return new Dugum(yazar);
            }

            // Makale sayısına göre karşılaştırma
            if (yazar.MakaleSayisi < current.Veri.MakaleSayisi)
            {
                current.Sol = EkleRecursive(current.Sol, yazar);
            }
            else
            {
                current.Sag = EkleRecursive(current.Sag, yazar);
            }

            return current;
        }

        public bool Sil(string yazarId)
        {
            int oncekiDugumSayisi = dugumSayisi;
            kok = SilRecursive(kok, yazarId);
            return dugumSayisi < oncekiDugumSayisi;
        }

        private Dugum SilRecursive(Dugum current, string yazarId)
        {
            if (current == null)
                return null;

            if (yazarId == current.Veri.Id)
            {
                dugumSayisi--;

                // Durum 1: Yaprak düğüm
                if (current.Sol == null && current.Sag == null)
                    return null;

                // Durum 2: Tek çocuk
                if (current.Sol == null)
                    return current.Sag;
                if (current.Sag == null)
                    return current.Sol;

                // Durum 3: İki çocuk
                var enKucuk = EnKucukDegeriBul(current.Sag);
                current.Veri = enKucuk.Veri;
                current.Sag = SilRecursive(current.Sag, enKucuk.Veri.Id);
                dugumSayisi++; // Çift azaltmayı önle
                return current;
            }

            if (yazarId.CompareTo(current.Veri.Id) < 0)
                current.Sol = SilRecursive(current.Sol, yazarId);
            else
                current.Sag = SilRecursive(current.Sag, yazarId);

            return current;
        }

        private Dugum EnKucukDegeriBul(Dugum dugum)
        {
            while (dugum.Sol != null)
                dugum = dugum.Sol;
            return dugum;
        }

        public List<Yazar> SeviyeSiraliDolas()
        {
            var sonuc = new List<Yazar>();
            if (kok == null)
                return sonuc;

            var kuyruk = new Queue<Dugum>();
            kuyruk.Enqueue(kok);

            while (kuyruk.Count > 0)
            {
                var current = kuyruk.Dequeue();
                sonuc.Add(current.Veri);

                if (current.Sol != null)
                    kuyruk.Enqueue(current.Sol);
                if (current.Sag != null)
                    kuyruk.Enqueue(current.Sag);
            }

            return sonuc;
        }

        public List<Yazar> InorderDolas()
        {
            var sonuc = new List<Yazar>();
            InorderDolasRecursive(kok, sonuc);
            return sonuc;
        }

        private void InorderDolasRecursive(Dugum dugum, List<Yazar> sonuc)
        {
            if (dugum != null)
            {
                InorderDolasRecursive(dugum.Sol, sonuc);
                sonuc.Add(dugum.Veri);
                InorderDolasRecursive(dugum.Sag, sonuc);
            }
        }

        public bool Bul(string yazarId)
        {
            return BulRecursive(kok, yazarId) != null;
        }

        private Dugum BulRecursive(Dugum current, string yazarId)
        {
            if (current == null || current.Veri.Id == yazarId)
                return current;

            if (yazarId.CompareTo(current.Veri.Id) < 0)
                return BulRecursive(current.Sol, yazarId);

            return BulRecursive(current.Sag, yazarId);
        }

        public int Derinlik()
        {
            return DerinlikHesapla(kok);
        }

        private int DerinlikHesapla(Dugum dugum)
        {
            if (dugum == null)
                return 0;

            int solDerinlik = DerinlikHesapla(dugum.Sol);
            int sagDerinlik = DerinlikHesapla(dugum.Sag);

            return Math.Max(solDerinlik, sagDerinlik) + 1;
        }

        public Dictionary<int, List<Yazar>> SeviyeyeGoreYazarlar()
        {
            var sonuc = new Dictionary<int, List<Yazar>>();
            SeviyeyeGoreYazarlarRecursive(kok, 0, sonuc);
            return sonuc;
        }

        private void SeviyeyeGoreYazarlarRecursive(Dugum dugum, int seviye, Dictionary<int, List<Yazar>> sonuc)
        {
            if (dugum == null)
                return;

            if (!sonuc.ContainsKey(seviye))
                sonuc[seviye] = new List<Yazar>();

            sonuc[seviye].Add(dugum.Veri);

            SeviyeyeGoreYazarlarRecursive(dugum.Sol, seviye + 1, sonuc);
            SeviyeyeGoreYazarlarRecursive(dugum.Sag, seviye + 1, sonuc);
        }

        public bool DengeliMi()
        {
            return DengeKontrol(kok) != -1;
        }

        private int DengeKontrol(Dugum dugum)
        {
            if (dugum == null)
                return 0;

            int solYukseklik = DengeKontrol(dugum.Sol);
            if (solYukseklik == -1)
                return -1;

            int sagYukseklik = DengeKontrol(dugum.Sag);
            if (sagYukseklik == -1)
                return -1;

            if (Math.Abs(solYukseklik - sagYukseklik) > 1)
                return -1;

            return Math.Max(solYukseklik, sagYukseklik) + 1;
        }
    }
}
