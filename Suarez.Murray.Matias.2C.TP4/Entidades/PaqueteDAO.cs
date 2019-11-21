using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Entidades
{
    public static class PaqueteDAO
    {
        private static SqlConnection connection;
        private static SqlCommand command;

        static PaqueteDAO() 
        {
            connection = new SqlConnection("Server=.\\SQLEXPRESS;Database=correo-sp-2017;Trusted_Connection=True;");
            command = new SqlCommand
            {
                Connection = connection,
                CommandType = System.Data.CommandType.Text
            };
        }

        public static bool Insertar(Paquete p)
        {
            try
            {
                connection.Open();
                string comando = string.Format("INSERT INTO Paquetes (direccionEntrega,trackingID,alumno) VALUES ('{0}','{1}','Suarez.Murray.Matias')", p.DireccionEntrega, p.TrackingID);

                command.CommandText = comando;
                command.ExecuteNonQuery();
            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open && connection != null)
                {
                    connection.Close();
                }
            }
            return true;
        }
    }
}
