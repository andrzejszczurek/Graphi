using Microsoft.Msagl.Drawing;
using Microsoft.Msagl.GraphViewerGdi;

using System.Windows.Forms;

namespace Presenter
{
   public partial class MainWindow : Form
   {
      public MainWindow()
      {
         InitializeComponent();

         ////create a viewer object 
         //Microsoft.Msagl.GraphViewerGdi.GViewer viewer = new Microsoft.Msagl.GraphViewerGdi.GViewer();
         ////create a graph object 
         //Microsoft.Msagl.Drawing.Graph graph = new Microsoft.Msagl.Drawing.Graph("graph");
         ////create the graph content 
         //graph.AddEdge("A", "B");
         //graph.AddEdge("B", "C");
         ////graph.AddEdge("A", "C").Attr.Color = Microsoft.Msagl.Drawing.Color.Green;
         ////graph.FindNode("A").Attr.FillColor = Microsoft.Msagl.Drawing.Color.Magenta;
         ////graph.FindNode("B").Attr.FillColor = Microsoft.Msagl.Drawing.Color.MistyRose;
         ////Microsoft.Msagl.Drawing.Node c = graph.FindNode("C");
         ////c.Attr.FillColor = Microsoft.Msagl.Drawing.Color.PaleGreen;
         ////c.Attr.Shape = Microsoft.Msagl.Drawing.Shape.Diamond;
         ////bind the graph to the viewer 
         //viewer.Graph = graph;
         ////associate the viewer with the form 
         //SuspendLayout();
         //viewer.Dock = System.Windows.Forms.DockStyle.Fill;
         //Controls.Add(viewer);
         //ResumeLayout();
         ////show the form 

         PrepareViewer();

      }

      private void PrepareViewer()
      {
         GViewer gViewer = new GViewer();
         gViewer.Dock = DockStyle.Fill;

         SuspendLayout();
         gViewer.Graph = SandBox.Generate();
         ResumeLayout();
         Controls.Add(gViewer);
      }
   }
}
