using System;
using System.Collections.Generic;
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
using System.IO;
using System.Net;

namespace Books_Sumaary
{
    /// <summary>
    /// Lógica de interacción para Detalles.xaml
    /// </summary>
    public partial class Detalles : Page
    {

        public Detalles()
        {
            InitializeComponent();
            lblNombreLibro.Content = Libro.Nombre;
            txtOutput.Text = File.ReadAllText(Libro.RutaDocumento);
        }
        private void BtnVolver_Click(object sender, RoutedEventArgs e)
        {
            MainWindow w = (MainWindow)Window.GetWindow(this);
            w.mainFrame.NavigationService.Navigate(new InformacionLibro());
        }
        private void BtnDescargar_Click(object sender, RoutedEventArgs e)
        {
            string rutaDirectorio = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filename = getFilename(Libro.EnlaceDescarga);
            WebClient cliente = new WebClient();
            cliente.DownloadFile(Libro.EnlaceDescarga, rutaDirectorio + "/" + filename);
            MessageBox.Show("Tú documento se ha descargado se forma exitosa, ve y compruebalo tu mismo en el escritorio", "¡Solicitud exitosa!", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        private string getFilename(string hreflink)
        {
            Uri enlace = new Uri(hreflink);
            string filename = System.IO.Path.GetFileName(enlace.LocalPath);
            return filename;
        }
    }
}
