using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//Capas
using BLL;
using DAL;

namespace CrudUbicaciones_RLG
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        ubicacionesBLL oUbicacionesBLL;
        ubicacionesDAL oUbicacionesDAL;
        protected void Page_Load(object sender, EventArgs e)
        {
            //por seguridad al momento de obtener los datos 
            if(!IsPostBack)
            {
                //llamar al metodo
                ListarUbicaciones();
            }
        }
        //metodo encargado de listar datos de la base de datos en un GRIDView
        public void ListarUbicaciones()
        {
            oUbicacionesDAL = new ubicacionesDAL();
            gvUbicaciones.DataSource = oUbicacionesDAL.Listar();
            gvUbicaciones.DataBind();

        }
        //metodo recolectar datos de la interfaz
        public ubicacionesBLL datosUbicacion()
        {
            int ID = 0;
            int.TryParse(txtID.Value, out ID);
            oUbicacionesBLL = new ubicacionesBLL();
            //RECOLECTAR DATOS DE LA PRESENTACION DE CAPA
            oUbicacionesBLL.ID = ID;
            oUbicacionesBLL.Ubicacion = txtUbicacion.Text;
            oUbicacionesBLL.Latitud = txtLat.Text;
            oUbicacionesBLL.Longitud = txtLong.Text;

            return oUbicacionesBLL;
        }

        protected void AgregarRegistro(object sender, EventArgs e)
        {
            oUbicacionesDAL = new ubicacionesDAL();
            oUbicacionesDAL.Agregar(datosUbicacion());
            ListarUbicaciones();
                //para que muestre en el gridView
        }

        protected void EliminarRegistro(object sender, EventArgs e)
        {
            oUbicacionesDAL = new ubicacionesDAL();
            oUbicacionesDAL.Eliminar(datosUbicacion());
            ListarUbicaciones();
        }

        protected void SeleccionRegistros(object sender, GridViewCommandEventArgs e)
        {
            int FilaSeleccionada = int.Parse(e.CommandArgument.ToString());
            //indicamos el dato que se tiene en la celda con ID 1 de la fila seleccionada lo pondra en caja de texto correspondiente en caso este
            txtID.Value = gvUbicaciones.Rows[FilaSeleccionada].Cells[1].Text;

            txtUbicacion.Text = gvUbicaciones.Rows[FilaSeleccionada].Cells[2].Text;
            txtLat.Text = gvUbicaciones.Rows[FilaSeleccionada].Cells[3].Text;
            txtLong.Text = gvUbicaciones.Rows[FilaSeleccionada].Cells[4].Text;

            /*cuando demos clic en seleccionas "boton" se habilitara los botones de eliminar y modificar. en este caso tambien se dejara inhabilitado el boton de agregar*/
            btnEliminar.Enabled = true;
            btnModificar.Enabled = true;
            btnAgregar.Enabled = false;
            btnLimpiar.Enabled = true;
        }

        protected void ModificarRegistro(object sender, EventArgs e)
        {
            oUbicacionesDAL = new ubicacionesDAL();
            oUbicacionesDAL.Modificar(datosUbicacion());
            ListarUbicaciones();
        }

        protected void LimpiarRegistro(object sender, EventArgs e)
        {
            txtLat.Text = "27.48642";
            txtLong.Text = "-109.94083";

            btnAgregar.Enabled = true;
        }
    }
}