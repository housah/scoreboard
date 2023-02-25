using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Scoreboard
{
   public partial class ScoreboardScreen : Window
   {

      private readonly ScoreboardMain? parent = null;
      private Dictionary<string, string> options = new Dictionary<string, string>();

      public ScoreboardScreen(ScoreboardMain parent, Dictionary<string, string> options)
      {
         InitializeComponent();
         this.parent = parent;

         UpdateScreen(options);
      }

      private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
      {  
         parent?.resetScoreboard();
      }


      public void UpdateScreen(Dictionary<string, string> options)
      {
         this.options = options;

         BrushConverter bc = new BrushConverter();
         Background = bc.ConvertFrom(options["bgColor"]) as Brush;
         eventTitle.Foreground = bc.ConvertFrom(options["fgColor"]) as Brush;

         // event title
         eventTitle.Content = options["eventName"];
      }
   }
}
