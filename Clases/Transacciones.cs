using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace PracticaCRUD.Clases
{
    

    internal class Transacciones
    {
        string sql = "";
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        Estudiante estudiante = new Estudiante();

        public Transacciones() 
        {
            this.con.ConnectionString =
                "Data source=HP_X360-13-A120;Initial Catalog=escuela;Integrated Security=true";
                
            //"Data source=nombreMaquina; Initial Catalog=nombredelabasededatos; Integrated Security=true";

        }

        public DataTable consultar(string nombreTabla)
        {
            DataTable datos = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter();

            switch (nombreTabla)
            {
                case "Estudiante":
                    this.sql = "select * from Estudiante";
                    break;
                case "Direccion":
                    this.sql = "select * from Direccion";
                    break;
                default:
                    MessageBox.Show("no existe esta tabla");
                    break;
            }
            try
            {
                this.con.Open();
                adapter = new SqlDataAdapter(this.sql, con.ConnectionString);
                adapter.Fill(datos);
            }
            catch (Exception ex)
            {

                MessageBox.Show("no se hizo la conexion con la base de datos");
            }
            finally { this.con.Close(); }
            return datos;
        }


        public bool insertar(string nombreTabla, Object obj)
        {
            switch (nombreTabla)
            {
                case "Estudiante":
                    this.estudiante = (Estudiante)obj;
                    this.sql="insert into Estudiante values("
                        +this.estudiante.matricula+",'"
                        +this.estudiante.nombre+"','"
                        +this.estudiante.apellidos +"','"
                        +this.estudiante.sexo+"',"
                        +this.estudiante.edad+")";
                    break;

                default: MessageBox.Show("No existe la tabla para registrar");
                break;
            }
           if(ejecutar(this.sql))
            {
                MessageBox.Show("realizando metodo ejecutar");
                return true;
            }
            else
            {
                MessageBox.Show("realizando metodo ejecutar como falso");
                return false;
            }
        }

        public bool ejecutar(string sql)
        {
            try
            {
                this.cmd.CommandText = this.sql;
                this.cmd.Connection = this.con;
                this.cmd.Connection.Open();
                this.cmd.ExecuteNonQuery();
                MessageBox.Show("guardando...");
                return true;
            }
            catch(Exception ex) 
            {
                return false;
            }
            finally
            {
                this.cmd.Connection.Close();
            }
        }
        public bool eliminar(string tabla, string campoId, string valor)
        {
            this.sql = "delete from " + tabla + " where " + campoId + "=" + valor;
            if(ejecutar(this.sql))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
