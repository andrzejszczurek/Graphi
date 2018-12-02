using App.Core.Model;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace App.Core.DataParser
{
   internal class DataGenerator
   {
      private static readonly char[] literals
         = { '-', 'A', 'B', 'C', 'D', 'E', 'F', 'G'
           , 'H', 'I', 'J', 'K', 'L', 'M', 'N'
           , 'O', 'P', 'R', 'S', 'T', 'U', 'W'
           , 'X', 'Y', 'Z', };

      private int m_IdSeed;

      public DataGenerator()
      {
         m_IdSeed = 0;
      }

      public IEnumerable<RawEvent> ParseFromFile(string a_path)
      {
         var result = new List<RawEvent>();

         using (StreamReader sr = new StreamReader(a_path))
         {
            string line;
            while ((line = sr.ReadLine()) != null)
            {
               var data = line.Split('-');
               var re = Create(data);
               result.Add(re);
            }
         }
         return result;
      }

      private RawEvent Create(string[] a_data)
      {
         var re = new RawEvent();
         re.Id = m_IdSeed++;
         re.RawNode = (int.Parse(a_data[0]), int.Parse(a_data[1]));
         re.Interval = int.Parse(a_data[2]);
         return re;
      }

      public static string IdAsLiteral(int a_id)
      {
         //var charCount = (a_id / 23) + 1;
         //var sb = new StringBuilder();
         
         var val = a_id % 23;
         return literals[val].ToString();
      }

   }
}
