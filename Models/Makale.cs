using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prolab3.Models
{
    public class Makale
    {
        public string Doi { get; private set; }
        public string Title { get; set; }
        private List<string> yazarIdleri;
        private Dictionary<string, int> yazarPozisyonlari;

        public IReadOnlyList<string> YazarIdleri => yazarIdleri.AsReadOnly();
        public IReadOnlyDictionary<string, int> YazarPozisyonlari => yazarPozisyonlari;

        public Makale(string doi)
        {
            Doi = doi;
            yazarIdleri = new List<string>();
            yazarPozisyonlari = new Dictionary<string, int>();
        }

        public void YazarEkle(string yazarId, int pozisyon)
        {
            if (!yazarIdleri.Contains(yazarId))
            {
                yazarIdleri.Add(yazarId);
                yazarPozisyonlari[yazarId] = pozisyon;
            }
            else if (!yazarPozisyonlari.ContainsKey(yazarId))
            {
                yazarPozisyonlari[yazarId] = pozisyon;
            }
        }

        public bool YazarVarMi(string yazarId)
        {
            return yazarIdleri.Contains(yazarId);
        }

        public int YazarPozisyonunuGetir(string yazarId)
        {
            return yazarPozisyonlari.TryGetValue(yazarId, out int pozisyon) ? pozisyon : -1;
        }

        public List<string> OrtakYazarlariGetir(string yazarId)
        {
            if (!YazarVarMi(yazarId))
                return new List<string>();

            return yazarIdleri.Where(id => id != yazarId).ToList();
        }

        public int YazarSayisi()
        {
            return yazarIdleri.Count;
        }

        public bool BirinciYazarMi(string yazarId)
        {
            return yazarPozisyonlari.TryGetValue(yazarId, out int pozisyon) && pozisyon == 1;
        }

        public List<string> SiraliYazarListesi()
        {
            return yazarIdleri
                .OrderBy(id => yazarPozisyonlari[id])
                .ToList();
        }

        public Dictionary<string, List<string>> YazarlarinOrtakYazarlari()
        {
            var ortakYazarlar = new Dictionary<string, List<string>>();

            foreach (var yazarId in yazarIdleri)
            {
                ortakYazarlar[yazarId] = OrtakYazarlariGetir(yazarId);
            }

            return ortakYazarlar;
        }

        public bool AyniMakaleMi(Makale digerMakale)
        {
            return Doi.Equals(digerMakale.Doi, StringComparison.OrdinalIgnoreCase);
        }

        public int OrtakYazarSayisi(Makale digerMakale)
        {
            return yazarIdleri.Intersect(digerMakale.yazarIdleri).Count();
        }

        public double IsbirligiSkoru(string yazar1Id, string yazar2Id)
        {
            if (!YazarVarMi(yazar1Id) || !YazarVarMi(yazar2Id))
                return 0;

            // Yazarların pozisyonlarına göre işbirliği skoru hesaplama
            int poz1 = YazarPozisyonunuGetir(yazar1Id);
            int poz2 = YazarPozisyonunuGetir(yazar2Id);

            // İlk yazarlar arası işbirliği daha yüksek skor alır
            if (poz1 <= 2 && poz2 <= 2)
                return 1.5;

            // Son yazarlar arası işbirliği normal skor alır
            return 1.0;
        }

        public override bool Equals(object obj)
        {
            if (obj is Makale digerMakale)
            {
                return AyniMakaleMi(digerMakale);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Doi.GetHashCode();
        }

        public override string ToString()
        {
            return $"DOI: {Doi}, Yazar Sayısı: {YazarSayisi()}";
        }

        public Dictionary<string, object> MakaleOzeti()
        {
            return new Dictionary<string, object>
        {
            {"DOI", Doi},
            {"Title", Title},
            {"YazarSayisi", YazarSayisi()},
            {"BirinciYazar", yazarIdleri.FirstOrDefault()},
            {"YazarListesi", SiraliYazarListesi()}
        };
        }
    }
}
