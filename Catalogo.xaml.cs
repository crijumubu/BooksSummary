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
            AjustarImagenYBorde(borBook1, imgBook1, "Ética para Amador"); // SE DEBE COPIAR EL MISMO NOMBRE DEL LIBRO TAL CUAL COMO SE GUARDÓ EN LA IMÁGEN CORRESPONDIENTE
            AjustarImagenYBorde(borBook2, imgBook2, "Prohibido Rendirse");
            AjustarImagenYBorde(borBook3, imgBook3, "Quién se ha llevado mi queso");
            AjustarImagenYBorde(borBook4, imgBook4, "Sangre de campeón INVENCIBLE");
            AjustarImagenYBorde(borBook5, imgBook5, "Sangre de campeón SIN CADENAS");
        }
        private void BtnInformacionLibro_Click(object sender, RoutedEventArgs e)
        {
            string stringVacio = "";
            string nombreLibro = Libro.IdentificarLibro(sender, stringVacio);
            for (int i = 0; i < Libro.GetLibros().Count; i++)
            {
                if (nombreLibro == Libro.GetLibros()[i])
                {
                    Libro.Nombre = nombreLibro;
                    Libro.AsignarRutaImagen();
                    Libro.AsignarRutaDocumento();
                    Libro.AsignarRutaDescarga();
                    break;
                }
            }

            //MessageBox.Show("Nom: " + nombreLibro + ". Nom sender: " + ((Button)sender).Content);
            MainWindow w = (MainWindow)Window.GetWindow(this);
            w.mainFrame.NavigationService.Navigate(new InformacionLibro());
        }
        private void AjustarImagenYBorde(Border borde, Image imagen, string nombreLibro)
        {
            string rutaImagen = $"{nombreLibro}.jpg"; //Tratar de que todos los formatos de imagen sean jpg
            BitmapImage bi3 = new BitmapImage();
            bi3.BeginInit();
            bi3.UriSource = new Uri(rutaImagen, UriKind.Relative);
            bi3.EndInit();
            imagen.Stretch = Stretch.Fill;
            imagen.Source = bi3;
            imagen.Width = borde.Width;
            imagen.Height = borde.Height;
            imagen.Margin = borde.Margin;
        }
    }
}
