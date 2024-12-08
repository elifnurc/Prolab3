using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prolab3.Models;

namespace Prolab3.DataStructures
{
    public class YazarKuyrugu
    {
        private List<Yazar> elemanlar;
        private readonly bool minHeap; // true: min heap, false: max heap

        public int Count => elemanlar.Count;

        public YazarKuyrugu(bool minHeapMi = false)
        {
            elemanlar = new List<Yazar>();
            minHeap = minHeapMi;
        }

        public void Ekle(Yazar yazar)
        {
            elemanlar.Add(yazar);
            YukariTasi(elemanlar.Count - 1);
        }

        public Yazar Cikar()
        {
            if (elemanlar.Count == 0)
                throw new InvalidOperationException("Kuyruk boş!");

            Yazar kok = elemanlar[0];
            int sonIndex = elemanlar.Count - 1;
            elemanlar[0] = elemanlar[sonIndex];
            elemanlar.RemoveAt(sonIndex);

            if (elemanlar.Count > 0)
                AsagiTasi(0);

            return kok;
        }

        public Yazar Peek()
        {
            if (elemanlar.Count == 0)
                throw new InvalidOperationException("Kuyruk boş!");

            return elemanlar[0];
        }

        private void YukariTasi(int index)
        {
            while (index > 0)
            {
                int ebeveynIndex = (index - 1) / 2;

                if (KarsilastirmaYap(index, ebeveynIndex))
                {
                    Swap(index, ebeveynIndex);
                    index = ebeveynIndex;
                }
                else
                    break;
            }
        }

        private void AsagiTasi(int index)
        {
            while (true)
            {
                int enUygunIndex = index;
                int solCocuk = 2 * index + 1;
                int sagCocuk = 2 * index + 2;

                if (solCocuk < elemanlar.Count && KarsilastirmaYap(solCocuk, enUygunIndex))
                    enUygunIndex = solCocuk;

                if (sagCocuk < elemanlar.Count && KarsilastirmaYap(sagCocuk, enUygunIndex))
                    enUygunIndex = sagCocuk;

                if (enUygunIndex == index)
                    break;

                Swap(index, enUygunIndex);
                index = enUygunIndex;
            }
        }

        private bool KarsilastirmaYap(int index1, int index2)
        {
            if (minHeap)
                return elemanlar[index1].MakaleSayisi < elemanlar[index2].MakaleSayisi;
            return elemanlar[index1].MakaleSayisi > elemanlar[index2].MakaleSayisi;
        }

        private void Swap(int index1, int index2)
        {
            var temp = elemanlar[index1];
            elemanlar[index1] = elemanlar[index2];
            elemanlar[index2] = temp;
        }

        public void KuyrukGuncelle(string yazarId, int yeniMakaleSayisi)
        {
            int index = elemanlar.FindIndex(y => y.Id == yazarId);
            if (index == -1)
                throw new ArgumentException("Yazar bulunamadı!");

            int eskiMakaleSayisi = elemanlar[index].MakaleSayisi;
            elemanlar[index].MakaleSayisi = yeniMakaleSayisi;

            if ((minHeap && yeniMakaleSayisi < eskiMakaleSayisi) ||
                (!minHeap && yeniMakaleSayisi > eskiMakaleSayisi))
            {
                YukariTasi(index);
            }
            else
            {
                AsagiTasi(index);
            }
        }

        public List<Yazar> KuyrukListesiGetir()
        {
            return new List<Yazar>(elemanlar);
        }

        public List<Yazar> SiraliListeGetir()
        {
            var siraliListe = new List<Yazar>();
            var tempKuyruk = new YazarKuyrugu(minHeap);

            // Mevcut elemanları yeni kuyruğa kopyala
            foreach (var eleman in elemanlar)
            {
                tempKuyruk.Ekle(eleman);
            }

            // Sıralı listeyi oluştur
            while (tempKuyruk.Count > 0)
            {
                siraliListe.Add(tempKuyruk.Cikar());
            }

            return siraliListe;
        }

        public void Temizle()
        {
            elemanlar.Clear();
        }

        public bool YazarVarMi(string yazarId)
        {
            return elemanlar.Any(y => y.Id == yazarId);
        }

        public void KuyrukBirlestir(YazarKuyrugu digerKuyruk)
        {
            foreach (var yazar in digerKuyruk.elemanlar)
            {
                if (!YazarVarMi(yazar.Id))
                    Ekle(yazar);
            }
        }

        public List<Yazar> EnYuksekOncelikliNElemanGetir(int n)
        {
            if (n <= 0)
                return new List<Yazar>();

            var sonuc = new List<Yazar>();
            var tempKuyruk = new YazarKuyrugu(minHeap);

            // Mevcut elemanları yeni kuyruğa kopyala
            foreach (var eleman in elemanlar)
            {
                tempKuyruk.Ekle(eleman);
            }

            // İlk n elemanı al
            for (int i = 0; i < n && tempKuyruk.Count > 0; i++)
            {
                sonuc.Add(tempKuyruk.Cikar());
            }

            return sonuc;
        }
    }
}
