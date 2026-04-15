using System;
using System.Collections.Generic;
using System.Text;

namespace Equipo2UML_JJUT_RERC
{
    internal class TipoSeguroA : Seguro
    {
        private double PorcentajeAnual = 0.003;
        public double CalcularCostoAnual()
        {
            return PrecioVehiculo * PorcentajeAnual;
        }
    }
}
