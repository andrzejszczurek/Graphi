using Microsoft.Msagl.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presenter
{
   public class SandBox
   {

      public static Graph Generate()
      {
         Graph graph = new Graph("Start");

         int i = 0;
         Node nStart = new Node("A");
         nStart.Attr.Color = Color.Red;
         nStart.Attr.Shape = Shape.Circle;
         nStart.LabelText = $"{i++}";

         Node n1 = new Node("B");
         n1.Attr.Color = Color.Red;
         n1.Attr.Shape = Shape.Circle;
         n1.LabelText = $"{i++}";

         Node n2 = new Node("C");
         n2.Attr.Color = Color.Red;
         n2.Attr.Shape = Shape.Circle;
         n2.LabelText = $"{i++}";

         Node n3 = new Node("D");
         n3.Attr.Color = Color.Black;
         n3.Attr.Shape = Shape.Circle;
         n3.LabelText = $"{i++}";

         graph.AddNode(nStart);
         graph.AddNode(n1);
         graph.AddNode(n2);
         graph.AddNode(n3);
         graph.AddEdge(n1.Id, nStart.Id).Attr.Color = Color.Red;
         graph.AddEdge(nStart.Id, n2.Id).Attr.Color = Color.Red; ;
         graph.AddEdge(n1.Id, n3.Id);

         return graph;
      }
   }
}
