
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media;

namespace Scoreboard
{

   public partial class Intro : UserControl
   {
      public Intro(Dictionary<string, string> options)
      {
         InitializeComponent();
      }

      public void UpdateContent(Dictionary<string, string> options)
      {
         BrushConverter bc = new BrushConverter();

         eventName.Foreground = bc.ConvertFrom(options["fgColor"]) as Brush;
         eventFase.Foreground = bc.ConvertFrom(options["fgColor"]) as Brush;

         // event name & fase
         eventName.Content = options["eventName"];
         eventFase.Content = options["eventFase"];
      }
   }
}
