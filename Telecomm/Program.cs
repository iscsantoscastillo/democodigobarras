using System;
using Telecomm.Helper;
using Telecomm.Model;

namespace Telecomm
{
    class Program
    {
        static void Main(string[] args)
        {
            Base97TelecommBanco base97 = new Base97TelecommBanco();
            
            base97.Convenio = "C0001";
            //base97.Referencia = "SL123456789012RTLM";
            base97.Referencia = "SL202100040682RTLM";
            base97.Fecha = "31/12/2021";
            base97.Importe = "199.55";

            Util.CalcularBase97TelecommBanco(base97);
            
            Console.WriteLine("Resuldato: " + base97.CadenaFinal);
        }
    }
}
