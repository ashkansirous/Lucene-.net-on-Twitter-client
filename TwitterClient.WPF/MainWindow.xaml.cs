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
using TwitterClient.Service;
using TwitterClient.Services;
using TwitterClient.Services.models;

namespace TwitterClient.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public IList<Twit> TwitList { get; set; }
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtSearch.Text))
            {
                MessageBox.Show($"Error! search criteria cannot be empty!", "Error");
                return;
            }
            try
            {
                var tws = new SearchService();
                TwitList = tws.Search(TxtSearch.Text);
                lstData.ItemsSource = TwitList;
                lblCount.Text = $"Count:{TwitList.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error! {ex.Message}", "Error");

            }

        }

        private async void btnFilter_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFilter.Text))
            {
                MessageBox.Show($"Error! Filter criteria cannot be empty!", "Error");
                return;
            }
            try
            {

                var results = SearchService.FindInIndexes(txtFilter.Text);
                TwitList = results.Select(r => (Twit)r).ToList();
                lstData.ItemsSource = TwitList;
                lblCount.Text = $"Count:{results.Count}";
            }
            catch (Exception ex)
            {
                var dialog = MessageBox.Show($"Error! {ex.Message}", "Error");
            }
        }

        private void btnExport_Click(object sender, RoutedEventArgs e)
        {
            if (TwitList == null || !TwitList.Any())
            {
                MessageBox.Show($"Error! Twit list is empty!", "Error");
                return;
            }
            try
            {

                var checkdTwits = TwitList.Where(t => t.Checked).ToList();
                if (checkdTwits == null || !checkdTwits.Any())
                {
                    MessageBox.Show($"Error! No twits has been selected!", "Error");
                    return;
                }
                Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
                dlg.FileName = "Document"; // Default file name
                dlg.DefaultExt = ".Json"; // Default file extension
                dlg.Filter = "Json Files (.Json)|*.json"; // Filter files by extension

                // Show save file dialog box
                var result = dlg.ShowDialog();

                // Process save file dialog box results
                if (result == true)
                {
                    // Save document
                    string filename = dlg.FileName;
                    FileService.Export(filename, checkdTwits);
                    MessageBox.Show("Exported!", "Action successful");
                }
            }
            catch (Exception ex)
            {
                var dialog = MessageBox.Show($"Error! {ex.Message}", "Error");
            }
        }
    }
}
