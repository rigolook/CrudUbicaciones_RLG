using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SQLDBHerlper
    {
        //tabla donde se guardaran los registros
        DataTable Tabla;
        //string de conexion
        SqlConnection strConexion = new SqlConnection("Data Source=DESKTOP-2G5NMNO\\SQLEXPRESS;Initial Catalog=BDUbicaciones;Integrated Security=True");
        //objeto cmd para sqlcommamnd
        SqlCommand cmd = new SqlCommand();

        public bool EjecutarComandoSQL(SqlCommand strSQLCommand)
        {
            //Insertar, modificar, borrar
            bool Respuesta = true;
            cmd = strSQLCommand;
            cmd.Connection = strConexion;
            strConexion.Open();
            Respuesta = (cmd.ExecuteNonQuery() <= 0) ? false : true;
            strConexion.Close();
            return Respuesta;
        }
        public DataTable EjecutarSentenciaSQL(SqlCommand strSQLCommand)
        {
            cmd = strSQLCommand;
            cmd.Connection = strConexion;
            strConexion.Open();
            Tabla = new DataTable();
            Tabla.Load(cmd.ExecuteReader());
            strConexion.Close();
            return Tabla;
        }
    }
}
