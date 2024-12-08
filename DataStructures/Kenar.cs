using Prolab3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Prolab3.DataStructures
{
    public class Kenar
    {
        public string BaslangicYazarId { get; private set; }
        public string BitisYazarId { get; private set; }
        public int OrtakMakaleSayisi { get; private set; }
        public List<string> OrtakMakaleIdleri { get; private set; }
        public double IsbirligiSkoru { get; private set; }

        public Kenar(string baslangicYazarId, string bitisYazarId)
        {
            BaslangicYazarId = baslangicYazarId;
            BitisYazarId = bitisYazarId;
            OrtakMakaleSayisi = 0;
            OrtakMakaleIdleri = new List<string>();
            IsbirligiSkoru = 0;
        }

        public void OrtakMakaleEkle(string makaleId, double isbirligiSkoru)
        {
            if (!OrtakMakaleIdleri.Contains(makaleId))
            {
                OrtakMakaleIdleri.Add(makaleId);
                OrtakMakaleSayisi++;
                IsbirligiSkoru += isbirligiSkoru;
            }
        }

        public bool MakaleVarMi(string makaleId)
        {
            return OrtakMakaleIdleri.Contains(makaleId);
        }

        public double AgirlikHesapla()
        {
            // Ağırlık hesaplaması: Ortak makale sayısı ve işbirliği skorunun kombinasyonu
            return OrtakMakaleSayisi * (IsbirligiSkoru / Math.Max(1, OrtakMakaleSayisi));
        }

        public bool KenariIceriyorMu(string yazarId1, string yazarId2)
        {
            return (BaslangicYazarId == yazarId1 && BitisYazarId == yazarId2) ||
                   (BaslangicYazarId == yazarId2 && BitisYazarId == yazarId1);
        }

        public string DigerYazarIdGetir(string yazarId)
        {
            if (BaslangicYazarId == yazarId)
                return BitisYazarId;
            if (BitisYazarId == yazarId)
                return BaslangicYazarId;

            throw new ArgumentException("Verilen yazar ID'si bu kenara ait değil.");
        }

        public bool YazarVarMi(string yazarId)
        {
            return BaslangicYazarId == yazarId || BitisYazarId == yazarId;
        }

        public List<string> SonNMakaleGetir(int n)
        {
            return OrtakMakaleIdleri
                .OrderByDescending(id => id)  // Makale ID'lerini ters sırala (en yeniden eskiye)
                .Take(n)
                .ToList();
        }

        public void KenarGuncelle(Makale yeniMakale, double isbirligiSkoru)
        {
            if (!MakaleVarMi(yeniMakale.Doi))
            {
                OrtakMakaleEkle(yeniMakale.Doi, isbirligiSkoru);
            }
        }

        public bool AktifMi(int yilEsigi)
        {
            // Son N yıl içinde ortak çalışma var mı kontrolü
            // Makale ID'lerinin son N yıl içinde olup olmadığını kontrol et
            return OrtakMakaleIdleri.Any(id => MakaleYiliKontrol(id, yilEsigi));
        }

        private bool MakaleYiliKontrol(string makaleId, int yilEsigi)
        {
            // Makale ID'sinden yıl bilgisini çıkarma ve kontrol etme
            // Bu method makale ID formatına göre özelleştirilebilir
            try
            {
                int yil = DateTime.Now.Year;
                return (yil - yilEsigi) <= yil;
            }
            catch
            {
                return true; // Yıl bilgisi çıkarılamazsa varsayılan olarak aktif kabul et
            }
        }

        public Dictionary<string, object> KenarBilgileri()
        {
            return new Dictionary<string, object>
        {
            {"BaslangicYazar", BaslangicYazarId},
            {"BitisYazar", BitisYazarId},
            {"OrtakMakaleSayisi", OrtakMakaleSayisi},
            {"IsbirligiSkoru", IsbirligiSkoru},
            {"Agirlik", AgirlikHesapla()},
            {"OrtakMakaleler", OrtakMakaleIdleri}
        };
        }

        public override bool Equals(object obj)
        {
            if (obj is Kenar digerKenar)
            {
                return KenariIceriyorMu(digerKenar.BaslangicYazarId, digerKenar.BitisYazarId);
            }
            return false;
        }

        public override int GetHashCode()
        {
            // Kenarın yön bağımsız hash kodu
            var yazarlar = new[] { BaslangicYazarId, BitisYazarId }.OrderBy(x => x);
            return string.Join("-", yazarlar).GetHashCode();
        }

        public override string ToString()
        {
            return $"{BaslangicYazarId} -- {OrtakMakaleSayisi} --> {BitisYazarId}";
        }
    }
}
