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

namespace Books_Sumaary
{
    /// <summary>
    /// Lógica de interacción para InformacionLibro.xaml
    /// </summary>
    public partial class InformacionLibro : Page
    {
        public InformacionLibro()
        {
            InitializeComponent();
            BitmapImage bi3 = new BitmapImage();
            bi3.BeginInit();
            bi3.UriSource = new Uri(Libro.RutaImagen, UriKind.Relative);
            bi3.EndInit();
            imgLibro.Stretch = Stretch.Fill;
            imgLibro.Source = bi3;
            lblNombreLibro.Content = Libro.Nombre;
            Libro.AsignarSinopsis();
            txtOutput.Text = Libro.Sinopsis;
        }
        private void BtnConocerMas_Click(object sender, RoutedEventArgs e)
        {
            MainWindow w = (MainWindow)Window.GetWindow(this);
            w.mainFrame.NavigationService.Navigate(new Detalles());
        }
        private void BtnVolver_Click(object sender, RoutedEventArgs e)
        {
            MainWindow w = (MainWindow)Window.GetWindow(this);
            w.mainFrame.NavigationService.Navigate(new Catalogo());
        }
    }
}
