using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prolab3.Models;
using WindowsFormsApp1.DataStructures;

namespace Prolab3.DataStructures
{
    public class Graf
    {
        private Dictionary<string, Dugum> dugumler;
        private double ortalamaYayinSayisi;

        public Graf()
        {
            dugumler = new Dictionary<string, Dugum>();
            ortalamaYayinSayisi = 0;
        }

        // Temel Graf İşlemleri
        public void DugumEkle(Yazar yazar)
        {
            if (!dugumler.ContainsKey(yazar.Id))
            {
                var dugum = new Dugum(yazar.Id, yazar);
                dugumler.Add(yazar.Id, dugum);
                OrtalamaYayinSayisiniGuncelle();
            }
        }

        public void KenarEkle(string yazarId1, string yazarId2, int ortakMakaleSayisi)
        {
            if (dugumler.ContainsKey(yazarId1) && dugumler.ContainsKey(yazarId2))
            {
                dugumler[yazarId1].KomsuEkle(dugumler[yazarId2], ortakMakaleSayisi);
            }
        }

        private void OrtalamaYayinSayisiniGuncelle()
        {
            if (dugumler.Count == 0) return;

            int toplamYayin = dugumler.Values.Sum(d => d.YazarBilgisi.MakaleSayisi);
            ortalamaYayinSayisi = (double)toplamYayin / dugumler.Count;

            // Tüm düğümlerin boyutlarını güncelle
            foreach (var dugum in dugumler.Values)
            {
                dugum.BoyutHesapla(ortalamaYayinSayisi);
            }
        }

        // İster 1: En Kısa Yol Bulma (Dijkstra Algoritması)
        public (List<Dugum> yol, double mesafe) EnKisaYolBul(string baslangicId, string bitisId)
        {
            if (!dugumler.ContainsKey(baslangicId) || !dugumler.ContainsKey(bitisId))
                return (new List<Dugum>(), double.PositiveInfinity);

            var mesafeler = new Dictionary<string, double>();
            var oncekiler = new Dictionary<string, string>();
            var ziyaretEdilmemis = new HashSet<string>();

            foreach (var dugum in dugumler.Keys)
            {
                mesafeler[dugum] = double.PositiveInfinity;
                ziyaretEdilmemis.Add(dugum);
            }

            mesafeler[baslangicId] = 0;

            while (ziyaretEdilmemis.Count > 0)
            {
                string simdiki = null;
                double enKisaMesafe = double.PositiveInfinity;

                foreach (var dugum in ziyaretEdilmemis)
                {
                    if (mesafeler[dugum] < enKisaMesafe)
                    {
                        enKisaMesafe = mesafeler[dugum];
                        simdiki = dugum;
                    }
                }

                if (simdiki == null || simdiki == bitisId)
                    break;

                ziyaretEdilmemis.Remove(simdiki);

                foreach (var komsu in dugumler[simdiki].Komsular)
                {
                    double alternatifMesafe = mesafeler[simdiki] + komsu.Value;
                    string komsuId = komsu.Key.Id;

                    if (alternatifMesafe < mesafeler[komsuId])
                    {
                        mesafeler[komsuId] = alternatifMesafe;
                        oncekiler[komsuId] = simdiki;
                    }
                }
            }

            // Yolu oluştur
            var yol = new List<Dugum>();
            string current = bitisId;

            while (current != null)
            {
                yol.Insert(0, dugumler[current]);
                oncekiler.TryGetValue(current, out current);
            }

            return (yol, mesafeler[bitisId]);
        }

        // İster 2: İşbirlikçi Yazarları Kuyruk için Sırala
        public List<Dugum> IsbirlikciYazarlariSirala(string yazarId)
        {
            if (!dugumler.ContainsKey(yazarId))
                return new List<Dugum>();

            return dugumler[yazarId].Komsular
                .OrderByDescending(x => x.Key.YazarBilgisi.MakaleSayisi)
                .Select(x => x.Key)
                .ToList();
        }

        // İster 5: İşbirliği Sayısı Hesaplama
        public int IsbirligiSayisiHesapla(string yazarId)
        {
            if (!dugumler.ContainsKey(yazarId))
                return 0;

            return dugumler[yazarId].KomsuSayisi();
        }

        // İster 6: En Çok İşbirliği Yapan Yazar
        public Dugum EnCokIsbirligiYapanYazariBul()
        {
            return dugumler.Values
                .OrderByDescending(d => d.KomsuSayisi())
                .FirstOrDefault();
        }

        // İster 7: En Uzun Yol Bulma (DFS tabanlı)
        public List<Dugum> EnUzunYolBul(string baslangicId)
        {
            if (!dugumler.ContainsKey(baslangicId))
                return new List<Dugum>();

            foreach (var dugum in dugumler.Values)
                dugum.ZiyaretSifirla();

            var enUzunYol = new List<Dugum>();
            var mevcutYol = new List<Dugum>();

            DFSileEnUzunYol(dugumler[baslangicId], mevcutYol, ref enUzunYol);

            return enUzunYol;
        }

        private void DFSileEnUzunYol(Dugum dugum, List<Dugum> mevcutYol, ref List<Dugum> enUzunYol)
        {
            dugum.Ziyaret = true;
            mevcutYol.Add(dugum);

            if (mevcutYol.Count > enUzunYol.Count)
            {
                enUzunYol = new List<Dugum>(mevcutYol);
            }

            foreach (var komsu in dugum.Komsular)
            {
                if (!komsu.Key.Ziyaret)
                {
                    DFSileEnUzunYol(komsu.Key, mevcutYol, ref enUzunYol);
                }
            }

            mevcutYol.RemoveAt(mevcutYol.Count - 1);
            dugum.Ziyaret = false;
        }

        public List<Dugum> TumDugumleriGetir()
        {
            return dugumler.Values.ToList();
        }

        public Dugum DugumGetir(string id)
        {
            return dugumler.TryGetValue(id, out var dugum) ? dugum : null;
        }
    }

}
