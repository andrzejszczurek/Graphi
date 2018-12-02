using App.Core.Brigde;
using App.Core.DataParser;
using Microsoft.Msagl.Drawing;

namespace App.Core
{
   public class CpmGraphFacade
   {
      internal DataGenerator DataGenerator { get; private set; }

      public CpmGraphFacade()
      {
         DataGenerator = new DataGenerator();
      }

      public (string Name, Graph graph) CreateGraphFromFile(string a_path)
      {
         var rawData = DataGenerator.ParseFromFile(a_path);
         var activities = RawEventToActivityConverter.Convert(rawData);
         var name = GenerateDefaultGraphName(a_path);
         var graph = ActivityToNodeConverter.PrepareGraph(activities, name);
         return (name, graph);
      }

      private string GenerateDefaultGraphName(string a_path)
      {
         var fileNameWithExt = a_path.Split('\\');
         var fileNameWithoutExt = fileNameWithExt[fileNameWithExt.Length - 1].Split('.')[0];
         return fileNameWithoutExt;
      }

   }
}
