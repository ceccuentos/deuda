using System;

namespace Dominio
{
    public class Deuda
    {
        public string Cliente { get; set; }
        public string NroDocumento { get; set; }
        public DateTime FechaEmision { get; set; }
        public DateTime FechaVcto { get; set; }
        public Decimal MontoTotal { get; set; }
        public Decimal MontoCancelado { get; set; }


    }


}

