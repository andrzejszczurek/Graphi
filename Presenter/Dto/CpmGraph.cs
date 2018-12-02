using Microsoft.Msagl.Drawing;

namespace Presenter.Dto
{
   internal class CpmGraph
   {
      public string Name { get; set; }

      public Graph Graph { get; set; }

      public CpmGraph(string name, Graph graph)
      {
         Name = name;
         Graph = graph;
      }

      public static CpmGraph Create(string name, Graph graph)
         => new CpmGraph(name, graph);

      public static CpmGraph Create((string Name, Graph Graph) a_data)
         => new CpmGraph(a_data.Name, a_data.Graph);

      public override string ToString()
      {
         return Name;
      }

   }
}
