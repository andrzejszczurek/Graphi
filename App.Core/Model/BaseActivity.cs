using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Model
{
   public abstract class BaseActivity<T>
   {
      public string Id { get; set; }

      public T Duration { get; set; }

      public bool IsStart { get; set; }

      public bool IsEnd { get; set; }

      public T EarlyStart { get; set; }

      public T EarlyFinish { get; set; }

      public T LateStart { get; set; }

      public T LateFinish { get; set; }

   }
}
