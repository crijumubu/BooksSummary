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
using System.Net;
using System.IO;
using System.IO.Compression;

namespace Books_Sumaary
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            try
            {
                string rutaCarpeta = @"C:\Users\Administrador\source\repos\Books Summary\Extra";
                if (Directory.Exists(rutaCarpeta) == false)
                {
                    Directory.CreateDirectory(rutaCarpeta);
                }
                EmptyFolder(new DirectoryInfo(rutaCarpeta));
                WebClient cliente = new WebClient();
                string rutaDescarga = "https://download1525.mediafire.com/pryqmkp8vo0g/55p2juogitf3qzh/Documentos.zip";
                string rutaDelZip = @"C:\Users\Administrador\source\repos\Books Summary\Extra\Documentos.zip";
                cliente.DownloadFile(rutaDescarga, rutaDelZip);
                ZipFile.ExtractToDirectory(rutaDelZip, rutaCarpeta);
                File.Delete(rutaDelZip);
            }
            catch (Exception e)
            {
                MessageBox.Show("Ha ocurrido un error, esto se debe a que no pudimos cargar los archivos necesarios para el funcionamiento de la aplicación, esto puede ser causado por problemas de internet o que no tienes los permisos de administrador requeridos para el funcionamiento de la aplicación", "¡ERROR!", MessageBoxButton.OK, MessageBoxImage.Error);
                this.Close();
            }
        }
        private void BtnComenzar_Click(object sender, RoutedEventArgs e)
        {
            MainWindow w = (MainWindow)Window.GetWindow(this);
            w.mainFrame.NavigationService.Navigate(new Catalogo());
            btnComenzar.Visibility = Visibility.Hidden;
            lblTitulo.Visibility = Visibility.Hidden;
        }
        private void EmptyFolder(DirectoryInfo directoryInfo)
        {
            foreach (FileInfo file in directoryInfo.GetFiles())
            {
                file.Delete();
            }

            foreach (DirectoryInfo subfolder in directoryInfo.GetDirectories())
            {
                EmptyFolder(subfolder);
            }
        }
    }
}
