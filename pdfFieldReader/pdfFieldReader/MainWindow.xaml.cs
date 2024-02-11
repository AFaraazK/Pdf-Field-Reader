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
using IronPython.Hosting;
using System.Diagnostics;

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

            Debug.WriteLine("SELECTED PDF");
        }

        private void btn_loadPdf_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("ENTER CLICKED");

            var engine = Python.CreateEngine();
            var scope = engine.CreateScope();


            engine.ExecuteFile(@"test.py", scope);

            dynamic testFunction = scope.GetVariable("test_python");
            string output = testFunction();

            tb_topleft.Text = output;
        }
    }
}