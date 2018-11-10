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


         Node nStart = new Node("A");
         nStart.Attr.Color = Color.AliceBlue;
         nStart.Attr.Shape = Shape.Circle;
         nStart.LabelText = "10\n0 5\n0";

         Node n1 = new Node("B");
         n1.Attr.Color = Color.Black;
         n1.Attr.Shape = Shape.Circle;
         n1.LabelText = "10\n0 5\n0";

         Node n2 = new Node("C");
         n2.Attr.Color = Color.Black;
         n2.Attr.Shape = Shape.Circle;
         n2.LabelText = "10\n0 5\n0";

         Node n3 = new Node("D");
         n3.Attr.Color = Color.Black;
         n3.Attr.Shape = Shape.Circle;
         n3.LabelText = "10\n0 5\n0";

         graph.AddNode(nStart);
         graph.AddNode(n1);
         graph.AddNode(n2);
         graph.AddNode(n3);
         graph.AddEdge(n1.Id, nStart.Id);
         graph.AddEdge(nStart.Id, n2.Id);
         graph.AddEdge(n1.Id, n3.Id);

         return graph;
      }
   }
}
