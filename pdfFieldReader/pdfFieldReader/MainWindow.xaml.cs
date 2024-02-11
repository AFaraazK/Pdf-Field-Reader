using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;

namespace pdfFieldReader
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_selectPdf_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "PDF Document | *.pdf";
            
            bool? file_success = fileDialog.ShowDialog();
            if(file_success == true)
            {
                string file_path = fileDialog.FileName;
                string file_name = fileDialog.SafeFileName;
                tb_topleft.Text = file_name + ": " + file_path;
            }
        }
    }
}