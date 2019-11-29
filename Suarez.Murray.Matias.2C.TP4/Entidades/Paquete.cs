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

        /// <summary>
        /// Simula el ciclo de vida de un paquete
        /// </summary>
        public void MockCicloDeVida()
        {
            while(this.estado != EEstado.Entregado)
            {
                Thread.Sleep(4000);
                this.estado++;
                this.InformaEstado(this, new EventArgs());
            }
            PaqueteDAO.Insertar(this);
        }

        /// <summary>
        /// Devuelve los datos de un paquete
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos(this);
        }

        /// <summary>
        /// Verifica si un paquete ya esta en la lista
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static bool operator ==(Paquete p1,Paquete p2)
        {
            return p1.trackingID == p2.trackingID;
        }

        /// <summary>
        /// Verifica si un paquete no esta en la lista
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static bool operator !=(Paquete p1,Paquete p2)
        {
            return !(p1 == p2);
        }

        /// <summary>
        /// Devuelve los datos de un paquete
        /// </summary>
        /// <param name="elemento"></param>
        /// <returns></returns>
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
