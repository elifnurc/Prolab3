using Prolab3.DataStructures;
using Prolab3.Utils;
using System;
using System.Windows.Forms;
using WindowsFormsApp1;

namespace Prolab3
{
    static class Program
    {
        /// <summary>
        /// Uygulamanın ana girdi noktası.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                // Veri yükleme işlemleri
                string excelDosyaYolu = "yazarlar.xlsx"; // Excel dosyasının yolu
                var veriYukleyici = new VeriYukleyici(excelDosyaYolu);
                var graf = veriYukleyici.GrafiGetir();

                // Graf görselleştirici oluştur
                var grafGorsellestirici = new GrafGorsellestirici();

                // Ana formu başlat
                Form1 anaForm = new Form1(graf, grafGorsellestirici);

                // Debug modunda bazı temel kontroller
#if DEBUG
                KontrolYap(graf);
#endif

                Application.Run(anaForm);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Uygulama başlatılırken bir hata oluştu:\n{ex.Message}\n\nDetaylar:\n{ex.StackTrace}",
                              "Hata",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
            }
        }

#if DEBUG
        private static void KontrolYap(Graf graf)
        {
            try
            {
                // Temel graf kontrollerini yap
                var tumDugumler = graf.TumDugumleriGetir();
                Console.WriteLine($"Toplam düğüm sayısı: {tumDugumler.Count}");

                // En çok işbirliği yapan yazarı bul
                var enCokIsbirlikci = graf.EnCokIsbirligiYapanYazariBul();
                if (enCokIsbirlikci != null)
                {
                    Console.WriteLine($"En çok işbirliği yapan yazar: {enCokIsbirlikci.YazarBilgisi.Ad}");
                    Console.WriteLine($"İşbirliği sayısı: {enCokIsbirlikci.KomsuSayisi()}");
                }

                // Örnek bir yol bulma denemesi yap
                if (tumDugumler.Count >= 2)
                {
                    var ilkYazar = tumDugumler[0];
                    var sonYazar = tumDugumler[tumDugumler.Count - 1];
                    var yol = graf.EnKisaYolBul(ilkYazar.Id, sonYazar.Id);
                    Console.WriteLine($"İki yazar arasında yol {(yol.yol.Count > 0 ? "bulundu" : "bulunamadı")}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Debug kontrollerinde hata: {ex.Message}");
            }
        }
#endif

        public static void UygulamayiKapat(string hataDetay = null)
        {
            if (!string.IsNullOrEmpty(hataDetay))
            {
                MessageBox.Show($"Uygulama kapatılıyor. Sebep:\n{hataDetay}",
                              "Uygulama Kapatılıyor",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Warning);
            }

            Application.Exit();
        }
    }
}