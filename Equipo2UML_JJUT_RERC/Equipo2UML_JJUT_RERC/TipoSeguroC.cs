using System;
using System.Collections.Generic;
using System.Text;

namespace Equipo2UML_JJUT_RERC
{
    internal class TipoSeguroC : Seguro
    {
        private double PorcentajeAnual = 0.04;
        public double CalcularCostoAnual()
        {
            return PrecioVehiculo * PorcentajeAnual;
        }

    }
}
