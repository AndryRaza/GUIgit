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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
using System.Threading;
using System.ComponentModel;




namespace GUIClone
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Cloner()
        {
            String urlSource_ = urlSource.Text;
            String urlGithub_ = urlGithub.Text;

            String disk = getDisk(urlSource_);

            ProcessStartInfo proc = new ProcessStartInfo();
            proc.FileName = "cmd.exe";
            proc.Arguments = @"/k " + disk + " && cd " + urlSource_ + " && git clone " + urlGithub_;
            proc.WindowStyle = ProcessWindowStyle.Hidden;
            
            Process p = Process.Start(proc);
            
            if(!p.HasExited)
            {
                success.Text = @"L'opération a été un succès !";
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Cloner();
        }

        private void ShowFolderBrowserDialog()
        {
            var dialog = new Ookii.Dialogs.Wpf.VistaFolderBrowserDialog();
            dialog.Description = "Choose the root folder of you music collection";
            dialog.UseDescriptionForTitle = true;
            dialog.ShowNewFolderButton = true;
            var result = dialog.ShowDialog();
            if (result == true)
            {
                urlSource.Text= dialog.SelectedPath;
            }
        }

        private string getDisk(string path)
        {
            string result;

            result = path[0].ToString() + path[1];

            return result;
        }


        private void urlSource_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void urlGithub_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void _showDialogButton_Click(object sender, RoutedEventArgs e)
        {
            ShowFolderBrowserDialog();
        }
    }
}
