using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgendaElectronica.Datos;
using AgendaElectronica.Entidades;

namespace AgendaElectronica.Logica
{
    public class LogicaContacto
    {
        DatosContactos datos = new DatosContactos();

        public void Insertar(Contacto contacto) => datos.InsertarContacto(contacto);

        public void Modificar(Contacto contacto) => datos.ModificarContacto(contacto);

        public void Eliminar(int id) => datos.EliminarContacto(id);

        public DataTable Buscar(string nombre) => datos.BuscarContactos(nombre);
    }
}
