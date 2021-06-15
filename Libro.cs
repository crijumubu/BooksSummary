using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Books_Sumaary
{
    public static class Libro
    {
        private static string nombre;
        private static string sinopsis;
        private static string rutaImagen;
        private static string rutaDocumento;
        private static string enlaceDescarga;
        private static List<string> libros = new List<string> {"Ética para Amador", "Prohibido Rendirse", "¿Quién se ha llevado mi queso?", "Sangre de campeón INVENCIBLE", "Sangre de campeón SIN CADENAS"};

        public static string Nombre { get => nombre; set => nombre = value; }
        public static string Sinopsis { get => sinopsis; set => sinopsis = value; }
        public static string RutaImagen { get => rutaImagen; set => rutaImagen = value; }
        public static string RutaDocumento { get => rutaDocumento; set => rutaDocumento = value; }
        public static string EnlaceDescarga { get => enlaceDescarga; set => enlaceDescarga = value; }

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
        public static void AsignarRutaDocumento()
        {
            string nombreLibro = "";
            string rutaLibro = "";
            string RutaTxt = @"C:\Program Files\Books Summary\Rutas.txt";
            string[] content = File.ReadAllLines(RutaTxt);
            bool ok = false;
            for (int i=1; i < 6; i++)
            {
                nombreLibro = "";
                rutaLibro = "";
                foreach (char c in content[i])
                {
                    if(c != '|')
                    {
                        if (ok == true)
                        {
                            rutaLibro += c;
                        }
                        else
                        {
                            nombreLibro += c;
                        }
                    }
                    else
                    {
                        if (nombreLibro == Nombre)
                        {
                            ok = true;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                if (ok == true)
                {
                    break;
                }
            }
            RutaDocumento = @rutaLibro;
        }
        public static void AsignarRutaImagen()
        {
            string nombreLibro = "";
            string rutaImagen = "";
            string RutaTxt = @"C:\Program Files\Books Summary\Rutas.txt";
            string[] content = File.ReadAllLines(RutaTxt);
            bool ok = false;
            for (int i = 7; i < 12; i++)
            {
                nombreLibro = "";
                rutaImagen = "";
                foreach (char c in content[i])
                {
                    if (c != '|')
                    {
                        if (ok == true)
                        {
                            rutaImagen += c;
                        }
                        else
                        {
                            nombreLibro += c;
                        }
                    }
                    else
                    {
                        if (nombreLibro == Nombre)
                        {
                            ok = true;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                if (ok == true)
                {
                    break;
                }
            }
            RutaImagen = rutaImagen;
        }
        public static void AsignarSinopsis()
        {
            string rutaSinopsis = @"C:\Program Files\Books Summary\Sinopsis.txt";
            string[] content = File.ReadAllLines(rutaSinopsis);
            string textoSinopsis = "";
            bool ok = false;
            for (int i = 1; i < content.Length; i++)
            {
                string nombreLibro = "";
                foreach (char c in content[i])
                {
                    if (c != '|')
                    {
                        if (ok == true)
                        {
                            textoSinopsis += c;
                        }
                        else
                        {
                            nombreLibro += c;
                        }
                    }
                    else
                    {
                        if (nombreLibro == Nombre)
                        {
                            ok = true;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                if (ok == true)
                {
                    break;
                }
            }
            Sinopsis = textoSinopsis;
        }
        public static void AsignarRutaDescarga()
        {
            string rutaDescarga = @"C:\Program Files\Books Summary\Rutas de descarga.txt";
            string[] content = File.ReadAllLines(rutaDescarga);
            string enlace = "";
            bool ok = false;
            for (int i = 1; i < content.Length; i++)
            {
                string nombreLibro = "";
                foreach (char c in content[i])
                {
                    if (c != '|')
                    {
                        if (ok == true)
                        {
                            enlace += c;
                        }
                        else
                        {
                            nombreLibro += c;
                        }
                    }
                    else
                    {
                        if (nombreLibro == Nombre)
                        {
                            ok = true;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                if (ok == true)
                {
                    break;
                }
            }
            enlaceDescarga = enlace;
        }
    }
}
