using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace UnitTest
{
    [TestClass]
    public class TestCorreo
    {
        [TestMethod]
        [ExpectedException(typeof(TrackingIdRepetidoException))]
        public void PaqueteRepetido()
        {
            Correo correo = new Correo();

            Paquete p1 = new Paquete("Sit amet", "420");
            Paquete p2 = new Paquete("Lorem ipsum","420");

            correo += p1;
            correo += p2;

            Assert.Fail();
        }
        
        [TestMethod]
        public void CorreoInstanciado()
        {
            Correo correo = new Correo();

            Assert.IsNotNull(correo.Paquetes);
        }
    }
}
