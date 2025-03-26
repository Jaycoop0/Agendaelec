using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AgendaElectronica.Entidades;
using AgendaElectronica.Logica;

namespace AgendaElectronica_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        LogicaContacto logica = new LogicaContacto();
        private void btnInsertar_Click(object sender, EventArgs e)
        {
            Contacto c = new Contacto()
            {
                Nombre = txtNombre.Text,
                Telefono = txtTelefono.Text,
                Correo = txtCorreo.Text
            };
            logica.Insertar(c);
            MessageBox.Show("Contacto insertado.");
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {

            // Verificar que haya un contacto seleccionado
            if (dgvContactos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un contacto para modificar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idContacto = Convert.ToInt32(dgvContactos.SelectedRows[0].Cells["IdContacto"].Value);

            using (SqlConnection conexion = new SqlConnection("Server=DESKTOP-NU1LEFQ\\SQLEXPRESS; database=AgendaElectronicaDB; Integrated Security=True"))
            {
                {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("ModificarContacto", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdContacto", idContacto);
                cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text.Trim());
                cmd.Parameters.AddWithValue("@Telefono", txtTelefono.Text.Trim());
                cmd.Parameters.AddWithValue("@Correo", txtCorreo.Text.Trim());

                cmd.ExecuteNonQuery();
                MessageBox.Show("Contacto modificado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarContactos(); // Recargar la tabla después de modificar
            }
            }
        }


        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Verificar que haya un contacto seleccionado
            if (dgvContactos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un contacto para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Confirmación antes de eliminar
            DialogResult resultado = MessageBox.Show("¿Seguro que desea eliminar este contacto?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado != DialogResult.Yes) return;

            int idContacto = Convert.ToInt32(dgvContactos.SelectedRows[0].Cells["IdContacto"].Value);

            using (SqlConnection conexion = new SqlConnection("Server=DESKTOP-NU1LEFQ\\SQLEXPRESS; database=AgendaElectronicaDB; Integrated Security=True"))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("EliminarContacto", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdContacto", idContacto);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Contacto eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarContactos(); // 🔄 Recargar la tabla después de eliminar
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            using (SqlConnection conexion = new SqlConnection("Server=DESKTOP-NU1LEFQ\\SQLEXPRESS; database=AgendaElectronicaDB; Integrated Security=True"))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("BuscarContacto", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre", txtBuscar.Text.Trim());

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvContactos.DataSource = dt;
            }
        }
        private void CargarContactos()
        {
            using (SqlConnection conexion = new SqlConnection("Server=DESKTOP-NU1LEFQ\\SQLEXPRESS; database=AgendaElectronicaDB; Integrated Security=True"))
            {
                conexion.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT IdContacto, Nombre, Telefono, Correo FROM Contactos", conexion);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvContactos.DataSource = dt;
            }
        }
    }
}






