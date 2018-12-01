using App.Core.Model;
using Microsoft.Msagl.Drawing;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Brigde
{
   public class ActivityToNodeConverter
   {
      private readonly IEnumerable<Activity> m_activities;

      private readonly List<Node> m_testNodes;

      public ActivityToNodeConverter(IEnumerable<Activity> a_activities)
      {
         m_activities = a_activities;
         m_testNodes = GenerateTestNodes();
      }

      private List<Node> GenerateTestNodes()
      {
         var nodes = new List<Node>();
         var events = new List<(int, int)>()
         {
            (1, 2),
            (1, 3),
            (1, 4),
            (2, 3),
            (2, 5),
            (3, 6),
            (3, 7),
            (4, 7),
            (5, 8),
            (6, 8),
            (7, 8),
         };

         foreach (var e in events)
         {

         }

         return nodes;
      }


      public IEnumerable<Node> GetNodes()
      {
         var nodes = new List<Node>();
         return nodes;
      }

   }
}
