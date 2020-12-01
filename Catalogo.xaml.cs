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

namespace Books_Sumaary
{
    /// <summary>
    /// Lógica de interacción para Catalogo.xaml
    /// </summary>
    public partial class Catalogo : Page
    {
        public Catalogo()
        {
            InitializeComponent();
        }
        private void BtnInformacionLibro_Click(object sender, RoutedEventArgs e)
        {
            string stringVacio = "";
            string nombreLibro = Libro.IdentificarLibro(sender, stringVacio);
            Libro libro = new Libro();
            txtOutput.Text = nombreLibro;
            for (int i = 0; i < Libro.GetLibros().Count; i++)
            {
                if (nombreLibro == Libro.GetLibros()[i])
                {
                    libro.Nombre = nombreLibro;
                    libro.RutaImagen = @$"/{nombreLibro}.jpg";
                    libro.AsignarRutaDocumento();
                    MessageBox.Show(libro.RutaDocumento);
                    break;
                }
            }
            MainWindow w = (MainWindow)Window.GetWindow(this);
            w.mainFrame.NavigationService.Navigate(new InformacionLibro());
        }
    }
}
