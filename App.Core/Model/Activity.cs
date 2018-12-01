using Microsoft.Msagl.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Model
{
   public class Activity : BaseActivity<int>
   {
      public IList<Activity> Predecessors { get; set; }

      public IList<Activity> Successors { get; set; }

      public bool IsCritical { get; set; }

      public Activity()
      {
         Predecessors = new List<Activity>();
         Successors = new List<Activity>();
      }
   }
} 