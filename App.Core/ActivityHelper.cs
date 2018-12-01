using App.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core
{
   public static class ActivityHelper
   {

      public static IList<Activity> MarkCriticalPath(this IList<Activity> a_activities)
      {
         var criticalActivities = GetCriticalActivities(a_activities);

         foreach (var critical in criticalActivities)
         {
            a_activities.Single(a => a.Id == critical.Id).IsCritical = true;
         }

         return a_activities;
      }

      private static IList<Activity> GetCriticalActivities(IList<Activity> a_activities)
      {
         // TODO: wyznaczanie sciezki krytycznej
         return a_activities;
      }

      private static void WalkAhead(this Activity activity)
      {
         foreach (var s in activity.Successors)
         {
            foreach (var p in s.Predecessors)
            {
               if (s.EarlyStart < p.EarlyFinish)
                  s.EarlyStart = p.EarlyFinish;
            }
            s.EarlyFinish = s.EarlyStart + s.Duration;
         }

         foreach (var s in activity.Successors)
            s.WalkAhead();
      }

      private static void WalkAback(this Activity activity)
      {
         foreach (var p in activity.Predecessors)
         {
            foreach (var s in p.Successors)
            {
               if (p.LateFinish == 0)
                  p.LateFinish = s.LateStart;
               else if (p.LateFinish > s.LateStart)
                  p.LateFinish = s.LateStart;
               p.LateStart = p.LateFinish - p.Duration;
            }
         }
         foreach (var p in activity.Predecessors)
         {
            p.WalkAback();
         }
      }
   }
}
