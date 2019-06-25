using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CapaAplicacion;
using CapaEntidad;
namespace UnitTestPrestamos
{
    [TestClass]
    public class PrestamosUT
    {
        //***Monto********************************************************************
        // Prestamo debe ser mayor o igual a 1000 soles y menor o igual a 30000 
        [TestMethod]
        public void TestMontoCorrecto()
        {
            Double monto = 1000;

            PrestamoEntidad prestamo = new PrestamoEntidad();
            prestamo.monto_prestado=monto;
            Boolean expResult = true;
            Boolean result = prestamo.MontoCorrecto();
            Assert.AreEqual(expResult, result);

        }
        /*

        [TestMethod]
        public void TestMontoCorrecto2()
        {
            decimal monto = 30000;

            logPrestamos instance = new logPrestamos();
            Boolean expResult = true;
            Boolean result = instance.MontoCorrecto(monto);
            Assert.AreEqual(expResult, result);

        }





        //***Porcentaje********************************************************************

        [TestMethod]
        public void TestPorcTeaCorrecto()
        {
            decimal tea = 0.10m;

            logPrestamos instance = new logPrestamos();
            Boolean expResult = true;
            Boolean result = instance.PorcTeaCorrecto(tea);
            Assert.AreEqual(expResult, result);

        }

        [TestMethod]
        public void TestPorcTeaCorrecto2()
        {
            decimal tea = 0.20m;

            logPrestamos instance = new logPrestamos();
            Boolean expResult = true;
            Boolean result = instance.PorcTeaCorrecto(tea);
            Assert.AreEqual(expResult, result);

        }


        //***Cuotas********************************************************************
        [TestMethod]
        public void TestCuotasCorrectas()
        {
            int cuotas = 3;

            logPrestamos instance = new logPrestamos();
            Boolean expResult = true;
            Boolean result = instance.CuotasCorrectas(cuotas);
            Assert.AreEqual(expResult, result);

        }


        [TestMethod]
        public void TestCuotasCorrectas2()
        {
            int cuota = 24;

            logPrestamos instance = new logPrestamos();
            Boolean expResult = true;
            Boolean result = instance.CuotasCorrectas(cuota);
            Assert.AreEqual(expResult, result);

        }


        //***Tea********************************************************************
        //TEA debe ser mayor o igual a 0.10 y menor o igual a 0.20
        [TestMethod]
        public void TestCalcularTEA()
        {

            Prestamo prestamos = new Prestamo();
            prestamos.Tea = 0.18f;
            logPrestamos instance = new logPrestamos();
            double expResult = 0.01;
            double result = Math.Round(instance.CalcularTEA(prestamos), 2);
            Assert.AreEqual(expResult, result);

        }

        [TestMethod]
        public void TestCalcularTEA2()
        {

            Prestamo prestamos = new Prestamo();
            prestamos.Tea = 0.13f;
            logPrestamos instance = new logPrestamos();
            double expResult = 0.01;
            double result = Math.Round(instance.CalcularTEA(prestamos), 2);
            Assert.AreEqual(expResult, result);

        }

        //***CuotaFija********************************************************************


        [TestMethod]
        public void TestCalcularCuotaFijaMensual1()
        {

            Prestamo prestamos = new Prestamo();
            prestamos.Tea = 0.11;
            logPrestamos instance = new logPrestamos();
            double expResult = 0.01;
            double result = Math.Round(instance.CalcularTEA(prestamos), 2);
            Assert.AreEqual(expResult, result);

        }

        //***CalcularCronograma**************************************************************





    }*/
    }
}
