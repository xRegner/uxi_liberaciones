using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UxiEntities.Utilities;
namespace UXITest
{
    /// <summary>
    /// Clase de pruebas para las utlidades
    /// </summary>
    [TestClass]
    public class UtilitiesTest
    {
        /// <summary>
        /// Método de pruebas para la validación del IMEI
        /// </summary>
        /// <param name="imei">el imei a validar</param>
        /// <param name="valid">Indica si el imei debe o no ser válido</param>
        [DataTestMethod]
        //Imei Vacio
        [DataRow("", false)]
        //Imei Nulo
        [DataRow(null, false)]
        ///Imei longitud menor
        [DataRow("120", false)]
        //Imei longitud correcta, con letras y numeros
        [DataRow("8650AA031130144", false)]
        //imei longitud correcta solo letras
        [DataRow("adfsyurlfoodiospl", false)]
        //Imei longitud correcta con simbolos especiales
        [DataRow("8650280311=)014", false)]
        ///imei longitud mayor
        [DataRow("86502803113014412", false)]
        //Imei incorrecto longitud correcta
        [DataRow("865028031130146", false)]
        //Imei correcto
        [DataRow("865028031130144", true)]
        //Imei correcto
        [DataRow("865028031130151", true)]
        public void TestMethod1(string imei, bool valid)
        {
            Assert.AreEqual(valid, imei.IsValidImei());   
        }
    }
}
