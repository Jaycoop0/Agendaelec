using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            if (dgvContactos.CurrentRow != null)
            {
                Contacto c = new Contacto()
                {
                    Id = Convert.ToInt32(dgvContactos.CurrentRow.Cells["Id"].Value),
                    Nombre = txtNombre.Text,
                    Telefono = txtTelefono.Text,
                    Correo = txtCorreo.Text
                };
                logica.Modificar(c);
                MessageBox.Show("Contacto modificado.");
            }
    }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvContactos.CurrentRow != null)
            {
                int id = Convert.ToInt32(dgvContactos.CurrentRow.Cells["Id"].Value);
                logica.Eliminar(id);
                MessageBox.Show("Contacto eliminado.");
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dgvContactos.DataSource = logica.Buscar(btnBuscar.Text);
        }
    }
}



