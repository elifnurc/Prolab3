using Microsoft.Msagl.Drawing;
using Microsoft.Msagl.GraphViewerGdi;
using Prolab3.DataStructures;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Windows.Forms;
using WindowsFormsApp1.DataStructures;
using Color = Microsoft.Msagl.Drawing.Color;

public class GrafGorsellestirici
{
    private Graph msaglGraph;
    private GViewer viewer;
    private Graf graf;
    private Dictionary<string, Node> dugumNodeMap;

    public GrafGorsellestirici()
    {
        msaglGraph = new Graph("graf");
        viewer = new GViewer();
        dugumNodeMap = new Dictionary<string, Node>();

        // Viewer ayarları
        viewer.OutsideAreaBrush = System.Drawing.Brushes.White;
        viewer.LayoutAlgorithmSettingsButtonVisible = false;
        viewer.EdgeInsertButtonVisible = false;
        viewer.UndoRedoButtonsVisible = false;
        viewer.ZoomF = 1.0;
    }

    public Control GrafKontrolunuGetir()
    {
        return viewer;
    }

    public void GrafiGoster(Graf graf, IWin32Window owner = null)
    {
        this.graf = graf;
        msaglGraph = new Graph("graf");
        dugumNodeMap.Clear();

        GrafDugumleriniOlustur();
        GrafKenarlariniOlustur();
        GrafDuzenlemeleriniYap();

        viewer.Graph = msaglGraph;

        if (owner != null)
        {
            // Form içinde gösterme durumu
            viewer.Dock = DockStyle.Fill;
        }
    }

   private void GrafDugumleriniOlustur()
{
    foreach (var dugum in graf.TumDugumleriGetir())
    {
        var node = msaglGraph.AddNode(dugum.Id);
        
        // Ana etiket olarak yazar adını göster
        node.LabelText = dugum.YazarBilgisi.Ad;
        
        // Düğüm boyutu ve rengini ayarla
        node.Attr.Shape = Microsoft.Msagl.Drawing.Shape.Circle;
        node.Attr.FillColor = new Microsoft.Msagl.Drawing.Color(100, 149, 237); // Cornflower Blue
        
        // Boyutu makale sayısına göre ayarla
        double boyut = dugum.Boyut * 20; // Baz boyut
        node.Attr.XRadius = boyut;
        node.Attr.YRadius = boyut;

        dugumNodeMap.Add(dugum.Id, node);
    }
}

// NodeInfo sınıfını GrafGorsellestirici içinde tanımlayalım
private class NodeInfo
{
    public string YazarAd { get; set; }
    public int MakaleSayisi { get; set; }
    public int IsbirlikciSayisi { get; set; }
}
    private void GrafKenarlariniOlustur()
    {
        var islenenKenarlar = new HashSet<string>();

        foreach (var dugum in graf.TumDugumleriGetir())
        {
            foreach (var komsu in dugum.Komsular)
            {
                string kenarId = GetKenarId(dugum.Id, komsu.Key.Id);

                if (!islenenKenarlar.Contains(kenarId))
                {
                    var edge = msaglGraph.AddEdge(dugum.Id, komsu.Key.Id);

                    // Kenar kalınlığını ortak makale sayısına göre ayarla
                    edge.Attr.LineWidth = Math.Min(komsu.Value, 5);

                    // Kenar etiketini ortak makale sayısı yap
                    edge.LabelText = komsu.Value.ToString();

                    // Kenar rengini ayarla
                    edge.Attr.Color = Color.Gray;

                    islenenKenarlar.Add(kenarId);
                }
            }
        }
    }

    private string GetKenarId(string id1, string id2)
    {
        // Kenar ID'sini oluştururken sıralamayı garanti et
        var ids = new[] { id1, id2 }.OrderBy(x => x);
        return string.Join("-", ids);
    }

    private void GrafDuzenlemeleriniYap()
    {
        // Graf düzenleme ayarları
        msaglGraph.LayoutAlgorithmSettings.EdgeRoutingSettings.EdgeRoutingMode =
            Microsoft.Msagl.Core.Routing.EdgeRoutingMode.SugiyamaSplines;

        // Düğümler arası minimum mesafe
        msaglGraph.LayoutAlgorithmSettings.NodeSeparation = 40;
    }

    public void YoluVurgula(List<Dugum> yol, Color renk)
    {
        // Tüm düğüm ve kenarları normal renge çevir
        foreach (var node in msaglGraph.Nodes)
        {
            node.Attr.Color = Color.Black;
        }
        foreach (var edge in msaglGraph.Edges)
        {
            edge.Attr.Color = Color.Gray;
        }

        // Yoldaki düğüm ve kenarları vurgula
        for (int i = 0; i < yol.Count - 1; i++)
        {
            var currentNode = dugumNodeMap[yol[i].Id];
            var nextNode = dugumNodeMap[yol[i + 1].Id];

            currentNode.Attr.Color = renk;
            nextNode.Attr.Color = renk;

            // İlgili kenarı bul ve vurgula
            var edge = msaglGraph.EdgeById(GetKenarId(yol[i].Id, yol[i + 1].Id));
            if (edge != null)
            {
                edge.Attr.Color = renk;
                edge.Attr.LineWidth *= 2;
            }
        }

        viewer.Graph = msaglGraph;
    }

    public void DugumuVurgula(string dugumId, Color renk)
    {
        if (dugumNodeMap.TryGetValue(dugumId, out var node))
        {
            node.Attr.Color = renk;
            viewer.Graph = msaglGraph;
        }
    }

    public void GrafiYenile()
    {
        viewer.Graph = msaglGraph;
    }

    public void ZoomReset()
    {
        viewer.ZoomF = 1;
    }
}