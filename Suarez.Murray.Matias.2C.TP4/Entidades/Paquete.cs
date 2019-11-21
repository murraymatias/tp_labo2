using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public class Paquete : IMostrar<Paquete>
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
            this.estado = EEstado.Ingresado;
        }

        public void MockCicloDeVida()
        {
            while(this.estado != EEstado.Entregado)
            {
                Thread.Sleep(4000);
                this.estado++;
                this.InformaEstado.Invoke(this.estado, new EventArgs());
            }
            PaqueteDAO.Insertar(this);
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

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
