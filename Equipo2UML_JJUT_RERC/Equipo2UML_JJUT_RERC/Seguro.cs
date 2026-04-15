using System;
using System.Collections.Generic;
using System.Text;

namespace Equipo2UML_JJUT_RERC
{
    internal class Seguro
    {
        protected string nombre;
        public string Nombre 
        { 
            get { return nombre; } 
            set 
            { 
                if (!string.IsNullOrWhiteSpace(value)) { nombre = value; } 
                else { throw new Exception("Nombre invalido"); } 
            } 
        }
        protected string placa;
        public string Placa 
        { 
            get { return placa; } 
            set 
            { 
                if (!string.IsNullOrWhiteSpace(value)) { placa = value; } 
                else { throw new Exception("Placa invalida"); } 
            }
        }
        protected string marca; 
        public string Marca 
        { 
            get { return marca; } 
            set 
            { 
                if (!string.IsNullOrWhiteSpace(value)) { marca = value; } 
                else { throw new Exception("Marca invalida"); } 
            } 
        }
        protected double precioVehiculo; 
        public double PrecioVehiculo     
        { 
            get { return precioVehiculo; } 
            set 
            { 
                if(value > 0) { precioVehiculo = value; }
                else { throw new Exception("Precio del vehiculo invalido"); }
            } 
        }
        protected DateTime fechaContratoInicio; 
        public DateTime FechaContratoInicio
        { 
            get { return fechaContratoInicio; } 
            set 
            { 
                if(value <= DateTime.Now) { fechaContratoInicio = value; }
                else { throw new Exception("Fecha de contrato invalida"); }
            } 
        }
        protected DateTime fechaContratoFin;
        public DateTime FechaContratoFin 
        { 
            get { return fechaContratoFin; } 
            set 
            { 
                if(value > FechaContratoInicio) { fechaContratoFin = value; }
                else { throw new Exception("Fecha de contrato invalida"); }
            }
        }

        protected int accidentes; 
        public int Accidentes 
        { 
            get { return accidentes; } 
            set 
            { 
                if(value >= 0) { accidentes = value; }
                else { throw new Exception("Numero de accidentes invalido"); }
            }
        }
        protected int aniosSinAccidentes; 
        public int AniosSinAccidentes    
        { 
            get { return aniosSinAccidentes; } 
            set 
            { 
                if(value >= 0) { aniosSinAccidentes = value; }
                else { throw new Exception("Numero de años sin accidentes invalido"); }
            }
        }
        protected double cuotaAnual; 
        public double CuotaAnual 
        { 
            get { return cuotaAnual; } 
            set 
            { 
                if(value >= 0) { cuotaAnual = value; }
                else { throw new Exception("Cuota anual invalida"); }
            }
        }
        protected string tipoPoliza; 
        public string TipoPoliza
        {
            get { return tipoPoliza; }
            set { if (value == "A" || value == "B" || value == "C" || value == "AB" || value == "AC") { tipoPoliza = value; }  
                  else { throw new Exception("Tipo de poliza invalido"); }
            }
        }
    
        public void llenarDatos(string nombre, string placa, string marca, double precioVehiculo, DateTime fechaContratoInicio, DateTime fechaContratoFin, int accidentes, int aniosSinAccidentes, string tipoPoliza)
        {
            Nombre = nombre;
            Placa = placa;
            Marca = marca;
            FechaContratoInicio = fechaContratoInicio;
            FechaContratoFin = fechaContratoFin;
            PrecioVehiculo = precioVehiculo;
            Accidentes = accidentes;
            AniosSinAccidentes = aniosSinAccidentes;
            TipoPoliza = tipoPoliza;
        }
    }
}
