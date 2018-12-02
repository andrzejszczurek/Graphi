using App.Core.DataParser;
using App.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Brigde
{
   internal static class RawEventToActivityConverter
   {

      public static IEnumerable<Activity> Convert(IEnumerable<RawEvent> a_rawEvents)
      {
         var activities = new List<Activity>();

         foreach (var rawEvent in a_rawEvents.OrderBy(x => x.Id))
         {
            if (activities.Count == 0)
            {
               var startActivity = Create(rawEvent);
               startActivity.IsStart = true;
               startActivity.TechnicalId = rawEvent.RawNode.i;
               startActivity.Id = rawEvent.Id;

               var nextActivity = Create(rawEvent);
               startActivity.Successors.Add(nextActivity);
               nextActivity.Predecessors.Add(startActivity);
               nextActivity.TechnicalId = rawEvent.RawNode.j;
               nextActivity.Id = rawEvent.Id;

               activities.Add(startActivity);
               activities.Add(nextActivity);
            }
            else if (activities.Count == a_rawEvents.Count() - 1)
            {
               var activityFirst = activities.SingleOrDefault(a => a.TechnicalId == rawEvent.RawNode.i);
               if (activityFirst == null)
                  ThrowRawEventParseError(rawEvent);

               var activitySecond = activities.SingleOrDefault(a => a.TechnicalId == rawEvent.RawNode.j);
               if (activitySecond != null)
                  ThrowRawEventParseError(rawEvent);

               var endActivity = Create(rawEvent);
               endActivity.IsEnd = true;
               endActivity.TechnicalId = rawEvent.RawNode.j;
               endActivity.Id = rawEvent.Id;

               activityFirst.Successors.Add(endActivity);
               endActivity.Predecessors.Add(activityFirst);
               activities.Add(endActivity);
            }
            else
            {
               var activityFirst = activities.SingleOrDefault(a => a.TechnicalId == rawEvent.RawNode.i);
               if (activityFirst == null)
               {
                  ThrowRawEventParseError(rawEvent);
               }
               else
               {
                  var activitySecond = activities.SingleOrDefault(a => a.TechnicalId == rawEvent.RawNode.j);
                  if (activitySecond == null)
                  {
                     var nextActivity = Create(rawEvent);
                     nextActivity.TechnicalId = rawEvent.RawNode.j;
                     nextActivity.Id = rawEvent.Id;
                     activityFirst.Successors.Add(nextActivity);
                     nextActivity.Predecessors.Add(activityFirst);
                     activities.Add(nextActivity);
                  }
                  else
                  {
                     activityFirst.Successors.Add(activitySecond);
                     activitySecond.Predecessors.Add(activityFirst);
                  }
               }
            }
         }
         return activities;
      }


      private static Activity Create(RawEvent a_rawEvent)
      {
         var acv = new Activity();
         acv.Id = a_rawEvent.Id;
         //acv.Duration = a_rawEvent.Interval;
         //acv.IsStart = false;
         //acv.IsEnd = false;
         return acv;
      }

      private static void ThrowRawEventParseError(RawEvent rawEvent)
      {
         throw new Exception($"Błąd podczas tworzenia zależności zdarzeń: ID:{rawEvent.Id}"
                  + $"Następstwo zdarzeń: i:{rawEvent.RawNode.i} j:{rawEvent.RawNode.j}");
      }

   }
}
