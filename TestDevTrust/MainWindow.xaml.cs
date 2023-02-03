using DevExpress.Office.Utils;
using System.Diagnostics;
using System.IO;
using System.Windows;
using TestDevTrust.Models;

namespace TestDevTrust
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
           InitializeComponent();
           DataContext = new ViewModels.MainWindowViewModel();
        }

        private void ExportToTXT(object sender, RoutedEventArgs e)
        {
            string fileName = @"TableData.txt";
            using (StreamWriter sw = new StreamWriter(fileName))
            {
                int[] selectedRowHandles = gridControl.GetSelectedRowHandles();
                foreach (int handle in selectedRowHandles)
                {
                    Person row = (Person)gridControl.GetRow(handle);
                    sw.WriteLine("Name: " + row.Name + ", Age: " + row.Age + ", Gender: " + row.Gender);
                }
            }
            var proc = new Process();
            proc.StartInfo.FileName = fileName;
            proc.StartInfo.UseShellExecute = true;
            proc.Start();
        }

        private void ExportToCSV(object sender, RoutedEventArgs e)
        {
            string fileName = @"TableData.csv";
            using (StreamWriter sw = new StreamWriter(fileName))
            {
                int[] selectedRowHandles = gridControl.GetSelectedRowHandles();
                foreach (int handle in selectedRowHandles)
                {
                    Person row = (Person)gridControl.GetRow(handle);
                    sw.WriteLine("Name: " + row.Name + ", Age: " + row.Age + ", Gender: " + row.Gender);
                }
            }
            var proc = new Process();
            proc.StartInfo.FileName = fileName;
            proc.StartInfo.UseShellExecute = true;
            proc.Start();
        }
    }
}

