using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excepciones;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        public bool Guardar(string archivo,string datos)
        {
            try
            {
                using(StreamWriter writer = new StreamWriter(archivo))
                {
                    writer.WriteLine(datos);
                }
                return true;
            }
            catch(Exception exception)
            {
                throw new ArchivosException(exception);
            }
        }

        public bool Leer(string archivo,out string datos)
        {
            try
            {
                using(StreamReader reader = new StreamReader(archivo))
                {

                }
                return true;
            }
            catch(Exception exception)
            {
                throw new ArchivosException(exception);
            }
        }
    }
}
