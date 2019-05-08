using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class entPago
    {
        public int pagoID { get; set; }
        public DateTime pago_fecha { get; set; }
        public DateTime pago_pagado { get; set; }
        public Boolean completo { get; set; }
        public int pago_periodo { get; set; }
        public float pago_cuota { get; set; }
        public float pago_amortizacion { get; set; }
        public float pago_interes { get; set; }
        public Boolean activo { get; set; }
        public entPrestamo prestamoID { get; set; }
    }
}
