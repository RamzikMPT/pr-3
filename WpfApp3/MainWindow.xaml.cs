using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.IO;
using System.Windows;

namespace WpfApp3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public static string[] Musicopener;
        public static int numbermusic = 0;
        
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void downloadmusic(object sender, RoutedEventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = true;

            var result = dialog.ShowDialog();
            if (result == CommonFileDialogResult.Ok)
            {
                // get the list of files in the selected folder
                string[] Musicopener = Directory.GetFiles(dialog.FileName);

                // display the list of files
                foreach (var file in Musicopener)
                {
                    Console.WriteLine(file);
                }

                // play the first file in the list
                media.Source = new Uri(Musicopener[0]);
                media.Play();

                // hide start and show stop button
                Start.Visibility = Visibility.Hidden;
                Stop.Visibility = Visibility.Visible;
            }
            else
            {
                MessageBox.Show("ERRROOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOR");
            }
        }

        private void PAUSE(object sender, RoutedEventArgs e)
        {
            media.Play();
            Stop.Visibility = Visibility.Visible;
            Start.Visibility = Visibility.Hidden;
        }

        private void START(object sender, RoutedEventArgs e)
        {
            media.Pause();
            Stop.Visibility = Visibility.Hidden;
            Start.Visibility = Visibility.Visible;
        }
        private void nazad(object sender, RoutedEventArgs e)
        {
            numbermusic = (numbermusic == 0) ? 3 : numbermusic - 1;
            media.Source = new Uri(Musicopener[numbermusic]);
        }
        private void vpered(object sender, RoutedEventArgs e)
        {
            if (numbermusic == Musicopener.Length - 1)
            {
                numbermusic = 0;
            }
            else
            {
                numbermusic = (numbermusic + 1) % Musicopener.Length;
            }

            media.Source = new Uri(Musicopener[numbermusic]);
        }










    }
}
