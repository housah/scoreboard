using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Scoreboard
{
   public partial class ScoreboardScreen : Window
   {
      private readonly ScoreboardMain? parent = null;
      private UserControl? child = null;
      
      public ScoreboardScreen(ScoreboardMain parent, Dictionary<string, string> options)
      {
         InitializeComponent();
         this.parent = parent;

         child = new Intro(options);
         this.ScreenWindowContent.Children.Add(child);

         UpdateScreen(options);
      }

      // ON CLOSING
      private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
      {  
         parent?.resetScoreboard();
      }

      // UPDATE BACKGROUND COLOR
      public void UpdateScreen(Dictionary<string, string> options)
      {
         BrushConverter bc = new BrushConverter();
         this.Background = bc.ConvertFrom(options["bgColor"]) as Brush;

         ((Intro)child).UpdateContent(options);
      }

      // CLOSE WINDOW
      private void b_exit_Click(object sender, RoutedEventArgs e)
      {
         this.Close();
      }

      // FULLSCREEN
      private void b_fullscreen_Click(object sender, RoutedEventArgs e)
      {
         ToggleFullScreen();
      }

      // DRAGGABLE
      private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
      {
         this.DragMove();
      }

      // TOGGLE FULLSCREEN
      public void ToggleFullScreen()
      {
         if (this.WindowState == WindowState.Maximized)
         {
            this.ScreenWindow.Margin = new Thickness(0);
            this.WindowState = WindowState.Normal;
            this.b_exit.Visibility = Visibility.Visible;
            this.b_exit.IsEnabled = true;
            this.b_fullscreen.Visibility = Visibility.Visible;
            this.b_fullscreen.IsEnabled = true;
         } 
         else
         {
            this.WindowState = WindowState.Maximized;
            this.b_exit.Visibility = Visibility.Hidden;
            this.b_exit.IsEnabled = false;
            this.b_fullscreen.Visibility = Visibility.Hidden;
            this.b_fullscreen.IsEnabled = false;
            this.ScreenWindow.Margin = new Thickness(0);
         }
      }

      // ESCAPE FULLSCREEN
      private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
      {
         if (e.Key == Key.Escape)
         {
            if (this.WindowState == WindowState.Maximized)
            {
               ToggleFullScreen();
            }
         }
      }

   // END
   }
}
