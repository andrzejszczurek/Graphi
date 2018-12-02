using App.Core.DataParser;
using App.Core.Model;
using Microsoft.Msagl.Drawing;
using System.Collections.Generic;
using System.Linq;

namespace App.Core.Brigde
{
   internal static class ActivityToNodeConverter
   {

      public static Graph PrepareGraph(IEnumerable<Activity> a_activities, string a_name)
      {
         Graph graph = new Graph(a_name);

         var nodes = new List<Node>();
         foreach (var activity in a_activities.OrderBy(x => x.Id))
         {
            Node node;
            if (activity.IsStart == true)
               node = Create(activity.TechnicalId, true);
            else
               node = Create(activity.TechnicalId);

            nodes.Add(node);
            graph.AddNode(node);
         }

         foreach (var node in nodes.OrderBy(x => x.Id))
         {
            var activityForNode = a_activities.Single(x => x.TechnicalId == int.Parse(node.Id));
            foreach (var act in activityForNode.Successors)
            {
               var nodeForActivity = nodes.Single(x => x.Id == act.TechnicalId.ToString());
               graph.AddEdge(activityForNode.TechnicalId.ToString(), nodeForActivity.Id);
            }
         }
         return graph;
      }

      private static Node Create(int Id, bool IsStart = false)
      {
         Node n = new Node(Id.ToString());
         n.Attr.Color = IsStart ? Color.Green : Color.Black;
         n.Attr.Shape = Shape.Circle;
         n.LabelText = DataGenerator.IdAsLiteral(Id);
         return n;
      }
   }
}
