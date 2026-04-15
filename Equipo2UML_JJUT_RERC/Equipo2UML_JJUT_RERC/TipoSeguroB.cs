using System;
using System.Collections.Generic;
using System.Text;

namespace Equipo2UML_JJUT_RERC
{
    internal class TipoSeguroB : Seguro
    {
        private double PorcentajeAnual = 0.012;
        public double CalcularCostoAnual()
        {
            return PrecioVehiculo * PorcentajeAnual;
        }
    }
}
