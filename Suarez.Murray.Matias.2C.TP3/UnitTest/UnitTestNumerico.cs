using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Clases_Abstractas;
using Clases_Instanciables;

namespace UnitTest
{
    [TestClass]
    public class UnitTestNumerico
    {
        [TestMethod]
        public void TestCantidadDeAlumnos()
        {

            Universidad uni = new Universidad();

            Alumno a1 = new Alumno(10, "Lorem", "Ipsum", "100", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
            Alumno a2 = new Alumno(20, "Sit", "Amet", "101", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);

            uni += a1;
            uni += a2;

            Assert.AreEqual(2, uni.Alumnos.Count);
        }
    }
}
