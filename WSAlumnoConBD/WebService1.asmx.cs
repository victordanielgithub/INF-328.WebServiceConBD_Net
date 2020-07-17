using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;

namespace WSAlumnoConBD
{
    /// <summary>
    /// Descripción breve de WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hola a todos";
        }
        [WebMethod]
        public DataSet persona()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "server=(local);user=vico;pwd=123;database=persona";
            SqlDataAdapter ada = new SqlDataAdapter();
            ada.SelectCommand = new SqlCommand();
            ada.SelectCommand.Connection = con;
            ada.SelectCommand.CommandText = "select * from persona";
            ada.SelectCommand.CommandType = CommandType.Text;
            DataSet ds = new DataSet();
            ada.Fill(ds);

            return ds;
        }
        [WebMethod]
        public DataSet personaParametros(string id)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "server=(local);user=vico;pwd=123;database=persona";
            SqlDataAdapter ada = new SqlDataAdapter();
            ada.SelectCommand = new SqlCommand();
            ada.SelectCommand.Connection = con;
            //ada.SelectCommand.CommandText = "select * from persona where idPersona="+id;
            ada.SelectCommand.CommandText = "select * from persona where idPersona=@id";
            ada.SelectCommand.CommandType = CommandType.Text;
            ada.SelectCommand.Parameters.Add("@id", SqlDbType.Int).Value = id;
            DataSet ds = new DataSet();
            ada.Fill(ds);

            return ds;
        }
    }
}
