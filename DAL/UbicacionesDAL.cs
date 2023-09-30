using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ubicacionesDAL
    {
        SQLDBHerlper oConexion;
        //iniciar la conexion con la base de datos constructor
        public ubicacionesDAL()
        {
            oConexion = new SQLDBHerlper();
        }
        public bool Agregar(ubicacionesBLL OubicacionesBLL) 
        {
            SqlCommand cmdComando = new SqlCommand();
            cmdComando.CommandText = "INSERT INTO Direcciones (Ubicacion, Latitud, Longitud) VALUES (@Ubicacion, @Latitud, @Longitud)";
            
            cmdComando.Parameters.Add("@Ubicacion", SqlDbType.VarChar).Value = OubicacionesBLL.Ubicacion;
            cmdComando.Parameters.Add("@Latitud", SqlDbType.VarChar).Value = OubicacionesBLL.Latitud;
            cmdComando.Parameters.Add("@Longitud", SqlDbType.VarChar).Value = OubicacionesBLL.Longitud;

           return oConexion.EjecutarComandoSQL(cmdComando);
        }
        public bool Eliminar(ubicacionesBLL Oubicaciones_BILL) 
        {
            //SQL BORRADO DE DATOS
            SqlCommand cmdComando = new SqlCommand();
            cmdComando.CommandText = "DELETE FROM Direcciones WHERE ID=@ID";
            cmdComando.Parameters.Add("@ID", SqlDbType.Int).Value = Oubicaciones_BILL.ID;

            return oConexion.EjecutarComandoSQL(cmdComando);
        }
        public bool Modificar(ubicacionesBLL Oubicaciones_BILL) 
        {
            SqlCommand cmdComando = new SqlCommand();

            cmdComando.CommandText = "Update Direcciones set Ubicacion=@Ubicacion, Latitud=@Latitud, Longitud=@Longitud Where ID=@ID";
            cmdComando.Parameters.Add("ID", SqlDbType.Int).Value = Oubicaciones_BILL.ID;
            cmdComando.Parameters.Add("@Ubicacion", SqlDbType.VarChar).Value = Oubicaciones_BILL.Ubicacion;
            cmdComando.Parameters.Add("@Latitud", SqlDbType.VarChar).Value = Oubicaciones_BILL.Latitud;
            cmdComando.Parameters.Add("@Longitud", SqlDbType.VarChar).Value = Oubicaciones_BILL.Longitud;

            return oConexion.EjecutarComandoSQL(cmdComando);

        }
        //seleccion de registros de tabla por medio de un select
        public DataTable Listar() 
        {
            SqlCommand cmdComando = new SqlCommand();
            cmdComando.CommandText = "SELECT * FROM Direcciones";
            cmdComando.CommandType = CommandType.Text;

            DataTable TablaResultante = oConexion.EjecutarSentenciaSQL(cmdComando);

            return TablaResultante;
        }

    }
}
