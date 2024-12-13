using Prolab3.DataStructures;
using Prolab3.Utils;
using System;
using System.Windows.Forms;
using WindowsFormsApp1;

namespace Prolab3
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                // Excel dosyasından veri yükleme
                string excelDosyaYolu = @"C:\Users\Asus\Desktop\PROLAB 3 - DATASET.xlsx";
                var veriYukleyici = new VeriYukleyici(excelDosyaYolu);
                var graf = veriYukleyici.GrafiGetir();

                // Graf görselleştirici oluştur
                var grafGorsellestirici = new GrafGorsellestirici();

                // Form1 oluşturuluyor
                Form1 anaForm = new Form1(graf, grafGorsellestirici);

#if DEBUG
                // Debug kontrolleri
                DebugKontrol(graf);
#endif

                Application.Run(anaForm);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Uygulama başlatılırken hata oluştu:\n{ex.Message}",
                                "Hata",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

#if DEBUG
        // Debug Modunda Kontroller
        private static void DebugKontrol(Graf graf)
        {
            Console.WriteLine($"Toplam düğüm sayısı: {graf.TumDugumleriGetir().Count}");
            var enCokIsbirlikci = graf.EnCokIsbirligiYapanYazariBul();
            Console.WriteLine($"En çok işbirliği yapan yazar: {enCokIsbirlikci?.YazarBilgisi?.Ad}");
        }
#endif
    }
}
