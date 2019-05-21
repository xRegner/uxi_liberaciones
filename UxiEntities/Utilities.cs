using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UxiEntities.Utilities
{
    /// <summary>
    /// Clase con utilidades para algunos tipos de datos
    /// </summary>
    public static class Utilities
    {
        /// <summary>
        /// Revisa si una cadena de texto es un imei válido
        /// </summary>
        /// <param name="imei">El imei que se quiere consultar</param>
        /// <returns>true en caso de que el imei sea válido, false en caso contrario</returns>
        /// <example>string s; if(s.IsValidImei()) return true; return false;</example>
        /// <example>if(!object.imei.IsValidImei()) throw new exception("Imei invalido");</example>
        /// <remarks>Para la validación de la cadena se utiliza el algoritmo Luhn 
        /// Antes de la validación principal, revisamos si no es nulo y si la longitud es exactamente 15.
        /// Si se agregan caracteres diferentes a un numero, la validación va a regresar false
        /// para más información sobre el algoritmo, referirse al siguiente link:
        /// https://en.wikipedia.org/wiki/Luhn_algorithm
        /// </remarks>

        public static bool IsValidImei(this string imei)
        {
            if (string.IsNullOrEmpty(imei))
                return false;
            if (imei.Length != 15)
                return false;
            else
            {
                int[] PosIMEI = new int[15];
                for (int iterator = 0; iterator < 15; iterator++)
                {
                    int item = 0;
                    if (!int.TryParse(imei.Substring(iterator, 1), out item))
                        return false;
                    PosIMEI[iterator] = item;
                    if (iterator % 2 != 0) PosIMEI[iterator] = PosIMEI[iterator] * 2;
                    while (PosIMEI[iterator] > 9) PosIMEI[iterator] = (PosIMEI[iterator] % 10) + (PosIMEI[iterator] / 10);
                }
                int Totalval = PosIMEI.Sum();

                if (Totalval % 10==0)
                    return true;
                else
                    return false;
            }
        }
    }
}
