using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Contracts;
using AgendaElectronica.Entidades;

namespace AgendaElectronica.Datos
{
    public class DatosContactos
    {

        private string cadenaConexion = "Data Source=localhost; Initial Catalog=AgendaElectronicaDB; Integrated Security=True";

        public void InsertarContacto(Contacto contacto)
        {
            using (SqlConnection conexion = new SqlConnection("Server=DESKTOP-NU1LEFQ\\SQLEXPRESS; database=AgendaElectronicaDB; Integrated Security=True"))
            {
                SqlCommand cmd = new SqlCommand("InsertarContacto", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre", contacto.Nombre);
                cmd.Parameters.AddWithValue("@Telefono", contacto.Telefono);
                cmd.Parameters.AddWithValue("@Correo", contacto.Correo);

                conexion.Open();
                cmd.ExecuteNonQuery();
            }
}
        public void ModificarContacto(Contacto contacto)
        {
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand("ModificarContacto", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", contacto.Id);
                cmd.Parameters.AddWithValue("@Nombre", contacto.Nombre);
                cmd.Parameters.AddWithValue("@Telefono", contacto.Telefono);
                cmd.Parameters.AddWithValue("@Correo", contacto.Correo);

                conexion.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void EliminarContacto(int id)
        {
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand("EliminarContacto", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);

                conexion.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public DataTable BuscarContactos(string nombre)
        {
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand("BuscarContactos", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre", nombre);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

              
                return dt;
            }
        }
    }
}
