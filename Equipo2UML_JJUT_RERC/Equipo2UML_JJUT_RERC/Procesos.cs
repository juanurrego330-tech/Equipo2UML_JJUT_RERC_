using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Drawing.Text;
using System.Text;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Equipo2UML_JJUT_RERC
{
    internal class Procesos
    {
        public bool ValidarCampos(string a)
        {
            if (string.IsNullOrWhiteSpace(a))
            {
                return false;
            }
            return true;
        }

        public bool ValidarComboBox(object a)
        {
            if (a == null)
            {
                MessageBox.Show("Por favor, seleccione una opción en (Marca y Periodo)");
                return false;
            }
            return true;
        }

        public bool ValidarEntero(string a)
        {
            if (int.TryParse(a, out _))
            {
                if (int.Parse(a) < 0)
                {
                    MessageBox.Show("Ingrese un número mayor o igual a cero en (Número de Accidentes y Años sin Accidentes)");
                    return false;
                }
                else { return true; }
            }
            else { MessageBox.Show("Ingrese un número entero válido"); return false; }
        }

        public bool ValidarDouble(string a)
        {
            if (double.TryParse(a, out _))
            {
                if (double.Parse(a) <= 0)
                {
                    MessageBox.Show("Ingrese un número mayor a cero (Precio del Vehículo)");
                    return false;
                }
                else { return true; }
            }
            else { MessageBox.Show("Ingrese un número entero válido"); return false; }
        }

        
        public int revisarAccidentes(string placa)
        {
            Archivo RevisarChoques = new Archivo();
            string texto = RevisarChoques.leerArchivo();
            string[] contenidoArchivo = texto.Split('\n');
            int AccidentesObtenidos = 0;

            for (int i = 0; i < contenidoArchivo.Length; i++)
            {
                if (contenidoArchivo[i].Trim().StartsWith("Placa:"))
                {
                    string placaEnArchivo = contenidoArchivo[i].Split(':')[1].Trim();
                    if (placaEnArchivo.ToLower() == placa.ToLower().Trim())
                    {
                        if ( i + 1 < contenidoArchivo.Length && contenidoArchivo[i + 1].Trim().StartsWith("Historial de Accidentes"))
                        {
                            if (int.TryParse(contenidoArchivo[i + 1].Split(':')[1].Trim(), out int accidentes))
                            {
                                AccidentesObtenidos += accidentes;
                            }
                        }
                    }
                }
            }
            return AccidentesObtenidos;
        }
        public bool RevisarPlaca(string placa)
        {
            if (placa == "fin1a")
            {
                cerrarPrograma();
                return false;
            }
            return true;
        }

        private DateTime inicio;
        private DateTime fin;
        public void calcularFecha(string tiempo)
        {
            inicio = DateTime.Now;

            if (tiempo == "1 año") fin = inicio.AddYears(1);
            else if (tiempo == "2 años") fin = inicio.AddYears(2);
            else fin = inicio.AddYears(3);
        }
        public double CalcularBonificacion(int añosSinAccidentes, double cuota)
        {
            double bonificacion = 0;
            if (añosSinAccidentes == 1) bonificacion = cuota * 0.02;
            else if (añosSinAccidentes == 2) bonificacion = cuota * 0.03;
            else if (añosSinAccidentes >= 3) bonificacion = cuota * 0.05;
            return bonificacion;
        }
        public void cerrarPrograma()
        {
           MessageBox.Show(
           $"--- INFORME DEL DÍA ---\n" +
           $"Pólizas A: {contadorA}\n" +
           $"Pólizas B: {contadorB}\n" +
           $"Pólizas C: {contadorC}\n" +
           $"Rechazos: {Rechazos}\n" +
           $"Total Recaudado A: {totalRecaudadoA}\n" +
           $"Total Recaudado B: {totalRecaudadoB}\n" +
           $"Total Recaudado C: {totalRecaudadoC}\n" +
           $"Total Recaudado: {totalRecaudadoA + totalRecaudadoB + totalRecaudadoC}");
            Application.Exit();
        }

        private int contadorA = 0;
        private int contadorB = 0;
        private int contadorC = 0;
        private int Rechazos = 0;
        private double totalRecaudadoA = 0;
        private double totalRecaudadoB = 0;
        private double totalRecaudadoC = 0;
        public void GuardarDatos(bool A, bool B, bool C, string nombre, string placa, string marca, double precioVeh, string periodo, int numeroAccidentes, int añosSinAccidentes)
        {
            calcularFecha(periodo);
            string poliza = "";
            int AntecedentesAccidentes = revisarAccidentes(placa);
            int totalAccidentes = AntecedentesAccidentes + numeroAccidentes;
            if (totalAccidentes <= 12)
            {
                if (A)
                {
                    contadorA++;
                    poliza = "A" + contadorA;
                    TipoSeguroA SeguroA = new TipoSeguroA();
                    SeguroA.llenarDatos(nombre, placa, marca, precioVeh, inicio, fin, numeroAccidentes, añosSinAccidentes, "A");
                    double costoAnualA = SeguroA.CalcularCostoAnual();
                    SeguroA.CuotaAnual = costoAnualA;
                    double bonificacion = CalcularBonificacion(añosSinAccidentes, costoAnualA);
                    double cuotaLiquidacion = costoAnualA - bonificacion;
                    totalRecaudadoA += cuotaLiquidacion;
                    Archivo A1 = new Archivo();
                    A1.escribirArchivo($"Seguros JJ\n# de Póliza: {poliza}\nNombre: {nombre}\nTipo de Seguro: A\nPeriodo: {inicio.ToShortDateString() + " - " + fin.ToShortDateString()}\nCuota Anual: {costoAnualA}\nBonificacion: {bonificacion}\nCuota a Liquidar: {cuotaLiquidacion}\nMarca: {marca}\nPlaca: {placa}\nHistorial de Accidentes: {totalAccidentes}\nAños sin Accidentes: {añosSinAccidentes}\nPrecio del Vehículo: {precioVeh}\nCantidad de Accidentes del año: {numeroAccidentes}\n");
                }
                if (B)
                {   
                    contadorB++;
                    poliza = "B" + contadorB;
                    TipoSeguroB SeguroB = new TipoSeguroB();
                    SeguroB.llenarDatos(nombre, placa, marca, precioVeh, inicio, fin, numeroAccidentes, añosSinAccidentes, "B");
                    double costoAnualB = SeguroB.CalcularCostoAnual();
                    SeguroB.CuotaAnual = costoAnualB;
                    double bonificacion = CalcularBonificacion(añosSinAccidentes, costoAnualB);
                    double cuotaLiquidacion = costoAnualB - bonificacion;
                    totalRecaudadoB += cuotaLiquidacion;
                    Archivo B1 = new Archivo();
                    B1.escribirArchivo($"Seguros JJ\n# de Póliza: {poliza}\nNombre: {nombre}\nTipo de Seguro: B\nPeriodo: {inicio.ToShortDateString() + " - " + fin.ToShortDateString()}\nCuota Anual: {costoAnualB}\nBonificacion: {bonificacion}\nCuota a Liquidar: {cuotaLiquidacion}\nMarca: {marca}\nPlaca: {placa}\nHistorial de Accidentes: {totalAccidentes}\nAños sin Accidentes: {añosSinAccidentes}\nPrecio del Vehículo: {precioVeh}\nCantidad de Accidentes del año: {numeroAccidentes}\n");
                }
                if (C)
                {   
                    contadorC++;
                    poliza = "C" + contadorC;
                    TipoSeguroC SeguroC = new TipoSeguroC();
                    SeguroC.llenarDatos(nombre, placa, marca, precioVeh, inicio, fin, numeroAccidentes, añosSinAccidentes, "C");
                    double costoAnualC = SeguroC.CalcularCostoAnual();
                    SeguroC.CuotaAnual = costoAnualC;
                    double bonificacion = CalcularBonificacion(añosSinAccidentes, costoAnualC);
                    double cuotaLiquidacion = costoAnualC - bonificacion;
                    totalRecaudadoC += cuotaLiquidacion;
                    Archivo C1 = new Archivo();
                    C1.escribirArchivo($"Seguros JJ\n# de Póliza: {poliza}\nNombre: {nombre}\nTipo de Seguro: C\nPeriodo: {inicio.ToShortDateString() + " - " + fin.ToShortDateString()}\nCuota Anual: {costoAnualC}\nBonificacion: {bonificacion}\nCuota a Liquidar: {cuotaLiquidacion}\nMarca: {marca}\nPlaca: {placa}\nHistorial de Accidentes: {totalAccidentes}\nAños sin Accidentes: {añosSinAccidentes}\nPrecio del Vehículo: {precioVeh}\nCantidad de Accidentes del año: {numeroAccidentes}\n");
                }           
            }
            else
            {
                Rechazos++;
                MessageBox.Show("Número de accidentes no puede ser mayor a 12" + "\n" + "Poliza Rechazada");
            }
        }
    }
}
