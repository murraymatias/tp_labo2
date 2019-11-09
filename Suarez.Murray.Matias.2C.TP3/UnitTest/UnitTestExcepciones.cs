using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Clases_Instanciables;
using Clases_Abstractas;
using Excepciones;

namespace UnitTest
{
    [TestClass]
    public class UnitTestExcepciones
    {
        [TestMethod]
        [ExpectedException(typeof(DniInvalidoException))]
        public void TestDNIInvalidoException()
        {
                Alumno alumno = new Alumno(10, "Lorem", "Ipsum", "Sit",Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
                Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(AlumnoRepetidoException))]
        public void TestAlumnoRepetidoException()
        {
                Alumno alumno = new Alumno(10, "Lorem", "Ipsum", "40000000",Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
                Universidad universidadTest = new Universidad();
                universidadTest += alumno;
                universidadTest += alumno;
                Assert.Fail();
        }
    }
}
