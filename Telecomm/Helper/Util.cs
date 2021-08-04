using System;
using System.Linq;
using Telecomm.Model;

namespace Telecomm.Helper
{
    public static class Util
    {
        public static Base97TelecommBanco CalcularBase97TelecommBanco(Base97TelecommBanco base97) {

            char[] aChar = base97.Referencia.ToArray<char>();            
            for (int i = 0; i < aChar.Length; i++) {
                aChar[i] = TablaBase97TelecommBanco(aChar[i]);                
            }
            string cadena = new string(aChar);
            base97.Referencia = cadena;

            base97.Fecha = GenerarFechaCondensada(base97.Fecha);            

            base97.Importe = GenerarImporteConsensado(base97.Importe);

            base97.DigitoVerificador = GenerarDigitoVerificador(base97);

            base97.CadenaFinal = base97.Convenio + base97.Referencia + base97.Fecha + base97.Importe + base97.DigitoVerificador;

            return base97;
        }
        private static char TablaBase97TelecommBanco(char ch) {
            ch = Char.ToUpper(ch);
            switch (ch)
            {
                case 'A':
                case 'B':
                case 'C':
                    return '2';
                case 'D':
                case 'E':
                case 'F':
                    return '3';
                case 'G':
                case 'H':
                case 'I':
                    return '4';
                case 'J':
                case 'K':
                case 'L':
                    return '5';
                case 'M':
                case 'N':
                case 'O':
                    return '6';
                case 'P':
                case 'Q':
                case 'R':
                    return '7';
                case 'S':
                case 'T':
                case 'U':
                    return '8';
                case 'V':
                case 'W':
                case 'X':
                    return '9';
                case 'Y':
                case 'Z':                
                    return '0';
            }
            return ch;
        }

        private static string GenerarFechaCondensada(string fecha) {            
            //Formato esperado de fecha: dd/mm/aaaa
            
            int iAnio = (Int32.Parse(fecha.Substring(6, 4)) - 2020) * 372;

            int iMes = (Int32.Parse(fecha.Substring(3, 2)) - 1) * 31;
            
            int iDia = (Int32.Parse(fecha.Substring(0, 2)) - 1);

            int iFC = iAnio + iMes + iDia;
            string s = iFC.ToString().PadLeft(4, '0');
            return iFC.ToString().PadLeft(4,'0');
        }

        private static string GenerarImporteConsensado(string imp) {
            char[] aChar = Convert.ToDecimal(imp).ToString("N2").Replace(".",String.Empty).ToArray<char>();           
            int[] aInt = { 1, 3, 7 };
            int iInt = 2;

            int suma = 0;
            for (int i = aChar.Length-1; i >= 0; i--) {
                int a = Int32.Parse(aChar[i].ToString());
                int b = aInt[iInt];
                suma = suma + (a * b);
                
                iInt--;
                if (iInt < 0) iInt = 2;
            }

            int rem = suma % 10;

            return rem.ToString();         
        }

        private static string GenerarDigitoVerificador(Base97TelecommBanco base97) {
            int[] iArray = { 11,13,17,19,23 };
            int j = 0;
            string cadena = base97.Referencia + base97.Fecha + base97.Importe;
            char[] cCadena = cadena.ToArray<char>();
            int suma = 0;
            for (int i = cCadena.Length - 1; i >= 0; i--) {
                int a = Int32.Parse(cCadena[i].ToString());
                int b = iArray[j];
                suma = suma + (a * b);
                j++;
                if (j > 4) j = 0;
            }
            int remanente = (suma % 97) + 1;
            return remanente.ToString();
        }
    }
}
