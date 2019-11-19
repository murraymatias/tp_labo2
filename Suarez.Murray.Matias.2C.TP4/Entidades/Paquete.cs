using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    class Paquete : IMostrar<Paquete>
    {
        private string direccionEntrega;
        private EEstado estado;
        private string trackingID;

        public string DireccionEntrega
        {
            get => this.direccionEntrega;
            set => this.direccionEntrega = value;
        }

        public EEstado Estado
        {
            get => this.estado;
            set => this.estado = value;
        }

        public string TrackingID
        {
            get => this.trackingID;
            set => this.trackingID = value;
        }

        public Paquete(string direccionEntrega,string trackingID)
        {
            this.direccionEntrega = direccionEntrega;
            this.trackingID = trackingID;
        }

        public void MockCicloDeVida()
        {
            Thread.Sleep(4000);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Id: {0}\n", this.TrackingID);
            sb.AppendFormat("Estado: {0}\n",this.Estado.ToString());
            sb.AppendFormat("Destinatario {0}\n", this.DireccionEntrega);

            return sb.ToString();
        }
        public static bool operator ==(Paquete p1,Paquete p2)
        {
            return p1.trackingID == p2.trackingID;
        }

        public static bool operator !=(Paquete p1,Paquete p2)
        {
            return !(p1 == p2);
        }

        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            return string.Format("{0} para {1}", this.TrackingID, this.DireccionEntrega);
        }

        public delegate void DelegadoEstado(object sender,EventArgs e);

        public event DelegadoEstado InformaEstado;
        public enum EEstado
        {
            Ingresado,EnViaje,Entregado
        }
    }
}
