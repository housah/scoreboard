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
   /// <summary>
   /// Interaction logic for Scoreboard.xaml
   /// </summary>
   public partial class ScoreboardScreen : Window
   {

      private ScoreboardMain? parent = null;

      public ScoreboardScreen(ScoreboardMain parent, string eventTitle)
      {
         InitializeComponent();
         this.eventTitle.Content = eventTitle;
         this.parent = parent;
      }

      private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
      {
          this.parent.resetScoreboard();
      }
   }
}
