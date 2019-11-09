using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        public bool Guardar(string archivo,T datos)
        {
            try
            {
                using (XmlTextWriter writer = new XmlTextWriter(archivo, Encoding.UTF8))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(T));
                    serializer.Serialize(writer, datos);                   
                }
                return true;
            }
            catch(Exception exception)
            {
                throw new ArchivosException(exception);
            }
        }

        public bool Leer(string archivo,out T datos)
        {
            try
            {
                using (XmlTextReader reader = new XmlTextReader(archivo))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(T));
                    datos = (T)serializer.Deserialize(reader);
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
