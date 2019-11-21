using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public class Correo : IMostrar<List<Paquete>>
    {
        private List<Thread> mockPaquetes;
        private List<Paquete> paquetes;

        public List<Paquete> Paquetes
        {
            get => this.paquetes;
            set => this.paquetes = value;
        }

        public Correo()
        {
            this.mockPaquetes = new List<Thread>();
            this.paquetes = new List<Paquete>();
        }

        public void FinEntregas()
        {
            foreach(Thread thread in this.mockPaquetes)
            {
                if (thread.IsAlive)
                {
                    thread.Abort();
                }
            }
        }

        public string MostrarDatos(IMostrar<List<Paquete>> elementos)
        {
            StringBuilder sb = new StringBuilder();
            foreach(Paquete p in this.paquetes)
            {
                sb.AppendFormat("{0} para {1} ({2})", p.TrackingID, p.DireccionEntrega, p.Estado.ToString());
            }
            return sb.ToString();
        }

        public static Correo operator +(Correo c,Paquete p)
        {
            foreach(Paquete paquete in c.Paquetes)
            {
                if(paquete == p)
                {
                    throw new TrackingIdRepetidoException("El paquete ya esta en la lista.");
                }
            }
            c.paquetes.Add(p);
            Thread thread = new Thread(p.MockCicloDeVida);
            c.mockPaquetes.Add(thread);
            thread.Start();
            return c;
        }
    }
}
