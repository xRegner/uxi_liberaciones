using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UXiModel;
using System.Configuration;




namespace NegocioBL
{
    public class Registro
    {

        /// <summary>
        /// Metodo para asegurar que no se meta con el mismo usuario
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public bool CompruebaUsuarioRegistro(string email)
        {
            UXI_Usuarios Usuario = new UXI_Usuarios();

            using (uxisolutionbdEntities Context = new uxisolutionbdEntities())
            {
                var query = from i in Context.UXI_Usuarios
                             where i.Email == email
                             select i;
            }


            return true;
        }



    }
}
