using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Yazar
{
    public string Id { get; set; }
    public string Ad { get; set; }
    public int MakaleSayisi { get; set; }
    public List<string> MakaleIdleri { get; set; }
    public Dictionary<string, int> IsbirlikciYazarlar { get; set; }  // <YazarId, Ortak Makale Sayısı>

    public Yazar(string id, string ad)
    {
        Id = id;
        Ad = ad;
        MakaleSayisi = 0;
        MakaleIdleri = new List<string>();
        IsbirlikciYazarlar = new Dictionary<string, int>();
    }

    public void MakaleEkle(string makaleId)
    {
        if (!MakaleIdleri.Contains(makaleId))
        {
            MakaleIdleri.Add(makaleId);
            MakaleSayisi++;
        }
    }

    public void IsbirlikciEkle(string yazarId)
    {
        if (IsbirlikciYazarlar.ContainsKey(yazarId))
            IsbirlikciYazarlar[yazarId]++;
        else
            IsbirlikciYazarlar.Add(yazarId, 1);
    }

    public int GetIsbirligiSayisi(string yazarId)
    {
        return IsbirlikciYazarlar.ContainsKey(yazarId) ? IsbirlikciYazarlar[yazarId] : 0;
    }

    public override string ToString()
    {
        return $"{Ad} (Makale Sayısı: {MakaleSayisi})";
    }
}
