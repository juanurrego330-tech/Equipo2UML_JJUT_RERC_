using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Numerics;
using System.Security.Cryptography.Pkcs;
using System.Text;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Equipo2UML_JJUT_RERC
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public string BuscarPorNombre(string nombre)
        {
            Archivo Buscar = new Archivo();
            string linea = Buscar.leerArchivo();
            string[] contenido = linea.Split('\n');
            string informacion = "";
            for (int i = 0; i < contenido.Length; i++)
            {
                if (contenido[i].Trim().StartsWith("Nombre:"))
                {
                    string nombreEnArchivo = contenido[i].Split(':')[1].Trim();
                    if (nombreEnArchivo.ToLower().StartsWith(nombre.ToLower().Trim()))
                    {
                        informacion += "\n";
                        int inicioInformacion = Math.Max(0, i - 2);
                        for (int j = inicioInformacion; j < inicioInformacion + 14 && j < contenido.Length; j++)
                        {
                            informacion += contenido[j] + "\n";
                        }
                    }
                }
            }
            return informacion;
        }

        public string BuscarPorPlaca(string placa)
        {
            Archivo Buscar = new Archivo();
            string linea = Buscar.leerArchivo();
            string[] contenido = linea.Split('\n');
            string informacion = "";
            for (int i = 0; i < contenido.Length; i++)
            {
                if (contenido[i].Trim().StartsWith("Placa:"))
                {
                    string placaEnArchivo = contenido[i].Split(':')[1].Trim();
                    if (placaEnArchivo.ToLower().StartsWith(placa.ToLower().Trim()))
                    {
                        informacion += "\n";
                        int inicioInformacion = Math.Max(0, i - 9);
                        for (int j = inicioInformacion; j < inicioInformacion + 14 && j<contenido.Length; j++)
                        {
                            informacion += contenido[j] + "\n";
                        }
                    }
                }
            }
            return informacion;
        }
        public string Filtro(string texto)
        { string resultado = "";
            if (radioButton1.Checked) { resultado = BuscarPorNombre(texto); } else if (radioButton2.Checked) { resultado = BuscarPorPlaca(texto); }
            return resultado;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label3.Text = Filtro(textBox1.Text);
        }
    }
}
