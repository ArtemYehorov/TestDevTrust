using System.IO;
using System.Windows;

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
           DataContext = new MainWindowViewModel();
        }

        private void ExportToTXT(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Ok");
            string fileName = @"C:/1/TableData.txt";
            using (StreamWriter sw = new StreamWriter(fileName))
            {
                int[] selectedRowHandles = gridControl.GetSelectedRowHandles();
                foreach (int handle in selectedRowHandles)
                {
                    Person row = (Person)gridControl.GetRow(handle);
                    sw.WriteLine("Name: " + row.Name + ", Age: " + row.Age + ", Gender: " + row.Gender);
                }
            }
        }

        private void ExportToCSV(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Ok");
            string fileName = @"C:/1/TableData.csv";
            using (StreamWriter sw = new StreamWriter(fileName))
            {
                int[] selectedRowHandles = gridControl.GetSelectedRowHandles();
                foreach (int handle in selectedRowHandles)
                {
                    Person row = (Person)gridControl.GetRow(handle);
                    sw.WriteLine("Name: " + row.Name + ", Age: " + row.Age + ", Gender: " + row.Gender);
                }
            }
        }
    }
}

