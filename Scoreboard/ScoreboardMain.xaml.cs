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
   public partial class ScoreboardMain : Window
   {
      private ScoreboardScreen? sb = null; // SCREEN WINDOW


      // INIT
      public ScoreboardMain()
      {
         InitializeComponent();
         this.toggleFullScren.IsEnabled = false;
         this.updateScoreboard.IsEnabled = false;
      }

      // EXIT OVERRIDE
      protected override void OnClosing(CancelEventArgs e)
      {
         MessageBoxResult res = MessageBox.Show("Confirm exit?", "Exit", MessageBoxButton.YesNo);
         if (res == MessageBoxResult.Yes)
         {
            Application.Current.Shutdown();
         } 
         else
         {
            e.Cancel = true;
         }
      }

      // DRAGGABLE
      private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
      {
         this.DragMove();
      }

      // EXIT
      private void b_exit_Click(object sender, RoutedEventArgs e)
      {
         Close();
      }

      // MAXIMIZE
      private void b_maximize_Click(object sender, RoutedEventArgs e)
      {
         if (this.WindowState == WindowState.Maximized)
         {
            this.MainWindow.Margin = new Thickness(0);
            this.WindowState = WindowState.Normal;
            this.b_maximize.Content = "";
            
         } 
         else
         {
            this.WindowState = WindowState.Maximized;
            this.b_maximize.Content = "";
            this.MainWindow.Margin = new Thickness(5);
         }
      }

      // MINIMIZE
      private void b_minimize_Click(object sender, RoutedEventArgs e)
      {
         this.WindowState = WindowState.Minimized;
      }


      // TOGGLE SCREEN WINDOW
      private void toggleScoreboard_Click(object sender, RoutedEventArgs e)
      {
         if (this.sb == null) {

            Dictionary<string, string> options = new Dictionary<string, string>
            {
               { "bgColor", this.bgcolorpicker.SelectedColor.ToString() },
               { "fgColor", this.fgcolorpicker.SelectedColor.ToString() },
               { "eventName", this.eventName.Text },
               { "eventFase", this.eventFase.Text }
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

      // TOGGLE FULL SCREEN
      private void toggleFullScren_Click(object sender, RoutedEventArgs e)
      {
         if (this.sb != null)
         {
            this.sb.ToggleFullScreen();
            //this.Focus();
         }
      }

      // UPDATE SCREEN
      private void updateScoreboard_Click(object sender, RoutedEventArgs e)
      {
         if (this.sb != null)
         {
            sb.UpdateScreen(
               new Dictionary<string, string> {
                  { "bgColor", this.bgcolorpicker.SelectedColor.ToString() },
                  { "fgColor", this.fgcolorpicker.SelectedColor.ToString() },
                  { "eventName", this.eventName.Text },
                  { "eventFase", this.eventFase.Text }
               }
            );
         }
      }

      // CLOSE AND RESET SCREEN
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
