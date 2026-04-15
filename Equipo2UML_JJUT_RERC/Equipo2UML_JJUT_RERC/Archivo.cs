using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
namespace Equipo2UML_JJUT_RERC
{
    internal class Archivo
    {

        private string direccion = "Poliza.txt";

        public void escribirArchivo(string contenido)
        {
            try
            {
                StreamWriter Archivo = new StreamWriter(direccion, true);
                Archivo.WriteLine(contenido);
                Archivo.Close();
            }
            catch
            {
                Console.WriteLine("Error al escribir en el archivo");
            }
        }
        public string leerArchivo()
        {
            try
            {
                string texto = "";
                StreamReader Archivo = new StreamReader(direccion);
                texto = Archivo.ReadToEnd();
                Archivo.Close();
                return texto;
            }
            catch
            {
                Console.WriteLine("Error al leer el archivo");
                return string.Empty;
            }
        }
    }
}
