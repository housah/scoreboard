using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Scoreboard
{
   /// <summary>
   /// Interaction logic for MainWindow.xaml
   /// </summary>
   public partial class ScoreboardMain : Window
   {

      private ScoreboardScreen? sb = null;
      private bool fs = false;

      public ScoreboardMain()
      {
         InitializeComponent();
         this.toggleFullScren.IsEnabled = false;
         this.updateScoreboard.IsEnabled = false;
      }

      protected override void OnClosing(CancelEventArgs e)
      {
         e.Cancel = true;
         Application.Current.Shutdown();
      }

      private void toggleScoreboard_Click(object sender, RoutedEventArgs e)
      {
         if (this.sb == null) {

            Dictionary<string, string> options = new Dictionary<string, string>
            {
               { "bgColor", this.bgcolorpicker.SelectedColor.ToString() },
               { "fgColor", this.fgcolorpicker.SelectedColor.ToString() },
               { "eventName", this.eventName.Text },

            };

            this.sb = new ScoreboardScreen(this, options);
            this.sb.WindowState = WindowState.Normal;
            this.sb.Show();
            this.toggleScoreboard.Content = "Hide Scoreboard";
            this.toggleFullScren.IsEnabled = true;
            this.updateScoreboard.IsEnabled = true;
         } else
         {
            this.sb.Close();
            this.sb = null;
            this.toggleScoreboard.Content = "Show Scoreboard";
            this.toggleFullScren.IsEnabled = false;
            this.updateScoreboard.IsEnabled = false;
         }
      }

      private void toggleFullScren_Click(object sender, RoutedEventArgs e)
      {
         if (this.sb != null) { 
            if (!fs) {
               this.sb.WindowStyle = WindowStyle.None;
               this.sb.WindowState = WindowState.Maximized;
               
               this.fs = true;
               this.Focus();
            } else
            {
               this.sb.WindowState = WindowState.Normal;
               this.sb.WindowStyle = WindowStyle.SingleBorderWindow;
               this.fs = false;
               this.Focus();
            }
         }
      }

      private void updateScoreboard_Click(object sender, RoutedEventArgs e)
      {
         if (this.sb != null)
         {
            sb.UpdateScreen(
               new Dictionary<string, string> {
                  { "bgColor", this.bgcolorpicker.SelectedColor.ToString() },
                  { "fgColor", this.fgcolorpicker.SelectedColor.ToString() },
                  { "eventName", this.eventName.Text }
               }
            );
         }
      }

      public void resetScoreboard()
      {
         this.sb = null;
         this.toggleScoreboard.Content = "Show Scoreboard";
         this.toggleFullScren.IsEnabled = false;
         this.updateScoreboard.IsEnabled = false;
      }

     


      // END
   }
}
