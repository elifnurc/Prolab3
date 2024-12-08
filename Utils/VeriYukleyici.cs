using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prolab3.Models;
using ClosedXML.Excel;
using System.IO;
using System.Text.RegularExpressions;
using ClosedXML.Excel;
using OfficeOpenXml;
using Prolab3.DataStructures;
using System.ComponentModel;


namespace Prolab3.Utils
{
public class VeriYukleyici
    {
        private readonly string dosyaYolu;
        private readonly Graf graf;

        public VeriYukleyici(string dosyaYolu)
        {
            this.dosyaYolu = dosyaYolu;
            this.graf = new Graf();
        }

        public Graf GrafiGetir()
        {
            try
            {
                using (var workbook = new XLWorkbook(dosyaYolu))
                {
                    var worksheet = workbook.Worksheet(1);
                    var rows = worksheet.RowsUsed();

                    // Başlık satırını atla
                    foreach (var row in rows.Skip(1))
                    {
                        string doi = row.Cell("B").Value.ToString();
                        string yazarPozisyon = row.Cell("C").Value.ToString();
                        string yazarAd = row.Cell("D").Value.ToString();
                        string coauthors = row.Cell("E").Value.ToString();

                        ProcessYazar(yazarAd, doi);
                        ProcessCoauthors(coauthors, doi);
                    }

                    IsbirlikcilikleriBelirle();
                }

                return graf;
            }
            catch (Exception ex)
            {
                throw new Exception($"Excel dosyası okunurken hata oluştu: {ex.Message}");
            }
        }

        private void ProcessYazar(string yazarAd, string doi)
        {
            string yazarId = YazarIdOlustur(yazarAd);

            if (!graf.DugumGetir(yazarId)?.YazarBilgisi.MakaleIdleri.Contains(doi) ?? true)
            {
                var yazar = new Yazar(yazarId, yazarAd);
                yazar.MakaleEkle(doi);
                graf.DugumEkle(yazar);
            }
            else
            {
                graf.DugumGetir(yazarId).YazarBilgisi.MakaleEkle(doi);
            }
        }

        private void ProcessCoauthors(string coauthors, string doi)
        {
            if (string.IsNullOrEmpty(coauthors)) return;

            // Köşeli parantezleri ve tek tırnakları temizle
            coauthors = coauthors.Replace("[", "").Replace("]", "").Replace("'", "");

            // Yazarları ayır
            var yazarlar = coauthors.Split(',')
                                   .Select(x => x.Trim())
                                   .Where(x => !string.IsNullOrEmpty(x))
                                   .ToList();

            foreach (var yazarAd in yazarlar)
            {
                ProcessYazar(yazarAd, doi);
            }
        }

        private void IsbirlikcilikleriBelirle()
        {
            var tumDugumler = graf.TumDugumleriGetir();

            foreach (var dugum1 in tumDugumler)
            {
                foreach (var dugum2 in tumDugumler)
                {
                    if (dugum1.Id == dugum2.Id) continue;

                    // Ortak makale sayısını hesapla
                    var ortakMakaleler = dugum1.YazarBilgisi.MakaleIdleri
                        .Intersect(dugum2.YazarBilgisi.MakaleIdleri)
                        .Count();

                    if (ortakMakaleler > 0)
                    {
                        graf.KenarEkle(dugum1.Id, dugum2.Id, ortakMakaleler);
                        dugum1.YazarBilgisi.IsbirlikciEkle(dugum2.Id);
                        dugum2.YazarBilgisi.IsbirlikciEkle(dugum1.Id);
                    }
                }
            }
        }

        private string YazarIdOlustur(string yazarAd)
        {
            // Özel karakterleri ve boşlukları temizle
            string id = Regex.Replace(yazarAd, @"[^a-zA-Z0-9]", "").ToLower();
            return id;
        }

        public Dictionary<string, string> YazarIdListesiGetir()
        {
            var yazarlar = new Dictionary<string, string>();
            var tumDugumler = graf.TumDugumleriGetir();

            foreach (var dugum in tumDugumler)
            {
                yazarlar.Add(dugum.Id, dugum.YazarBilgisi.Ad);
            }

            return yazarlar;
        }
    }
}
