using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Model
{
   public class RawEvent
   {
      public int Id { get; set; }

      public (int i, int j) RawNode { get; set; }

      public int Interval { get; set; }

      public RawEvent()
      {
      }
   }
}
