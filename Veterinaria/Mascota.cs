using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterinaria
{
    public class Mascota
    
   
    {
        public int CodigoMascota { get; set; }
        public int CodigoCliente { get; set; }
        public string Cliente { get; set; }
        public string AliasMascota { get; set; }
        public double Peso { get; set; }
        public int Edad { get; set; }
        public string Raza { get; set; }
        public string Sexo { get; set; }

        public override string ToString()
        {
            return $"{CodigoMascota,-6} {CodigoCliente,-6} {Cliente,-30} {AliasMascota,-15} {Peso,-8:F2} {Edad,-6} {Raza,-15} {Sexo}";
        }

    }

}
