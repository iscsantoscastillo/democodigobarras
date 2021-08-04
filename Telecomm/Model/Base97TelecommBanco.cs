using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telecomm.Model
{
    public class Base97TelecommBanco
    {
        
        public string Convenio { get; set; }
        public string Referencia { get; set; }
        public string Fecha { get; set; }
        public string Importe { get; set; }
        public string DigitoVerificador { get; set; }
        public string CadenaFinal { get; set; }
    }
}
