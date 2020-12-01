using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Books_Sumaary
{
    public class Libro
    {
        private string nombre;
        private string rutaImagen;
        private string rutaDocumento;
        private static List<string> libros = new List<string> {"Ética para Amador", "Prohibido Rendirse", "¿Quién se ha llevado mi queso?", "Sangre de campeón INVENCIBLE", "Sangre de campeón SIN CADENAS"};

        public string Nombre { get => nombre; set => nombre = value; }
        public string RutaImagen { get => rutaImagen; set => rutaImagen = value; }
        public string RutaDocumento { get => rutaDocumento; set => rutaDocumento = value; }
        public static List<string> GetLibros()
        {
            return libros;
        }
        public static string IdentificarLibro(object sender, string stringVacio_RetornaNombre)
        {
            bool ok = false;
            int cont = 0;
            char letraAnterior = 'l';
            foreach (char c in sender.ToString())
            {
                if (ok == true)
                {      
                    if ((cont != 0 && c!='&' && c!='#' && c!=';') && ((c != 'A' && letraAnterior != 'x') || (c == 'A' && letraAnterior != 'x')) && ((c != ' ' && letraAnterior != ' ') || (c != ' ' && letraAnterior == ' ') || (c == ' ' && letraAnterior != ' ') || (c != ' ' && letraAnterior == '\n')) && (c != '\n'))
                    {                        
                        stringVacio_RetornaNombre += c;
                    }
                    else
                    {
                        cont++;
                    }
                }
                if (c == ':')
                {
                    ok = true;
                }
                letraAnterior = c;
            }
            return stringVacio_RetornaNombre;
        }
        public void AsignarRutaDocumento()
        {
            string nombreLibro = "";
            string rutaLibro = "";
            bool ok = false;
            string RutaTxt = @"C:\Users\Administrador\source\repos\Books Summary\Extra\Rutas.txt";
            string[] content = File.ReadAllLines(RutaTxt);
            for (int i=1; i < content.Length; i++)
            {
                foreach (char c in content[i])
                {
                    if(c != '|' && ok == false)
                    {
                        nombreLibro += c;
                    }
                    if (ok == true)
                    {
                        rutaLibro += c;
                    }
                    else
                    {
                        if (Nombre == nombreLibro)
                        {
                            ok = true;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
            rutaLibro = @RutaDocumento;
        }
    }
}
