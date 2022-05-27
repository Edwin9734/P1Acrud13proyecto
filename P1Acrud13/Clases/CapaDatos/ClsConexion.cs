using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P1Acrud13.Clases.CapaDatos
{
    public class ClsConexion
    {
        public string NombreServidor = "UMG-LAB\\SQLEXPRESS";
        public string NombreBaseDatos = "Programacion1";
       
        public SqlConnection conexion;
        public String CadenaConexion { get; }


        public ClsConexion()
        {
            CadenaConexion = $"Data source = {NombreServidor}; Initial Catalog = {NombreBaseDatos}; Integrated Security = True";
        }

    
        
        public DataTable ConsulaTabaDirecta (String sqll)
        {
            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {try 
            { 
                    conexion.Open ();
                    SqlDataReader dr;
                    SqlCommand cdm = new SqlCommand(sqll,conexion);
                    dr = cdm.ExecuteReader ();

                    var dataTable = new DataTable();
                    dataTable.Load (dr);
                    return dataTable;
            }catch (Exception ex)
            {
                Console.WriteLine($" Ups hubo  un clavo en tabla dtecta {ex.Message}");
                return null;
            }
            }
        }


        public int EjecutarSQLDirecto(String sqll)
        {
            int status = -1;
            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                try
                {
                    conexion.Open();                 
                    SqlCommand cmd = new SqlCommand(sqll, conexion);
                    status = cmd.ExecuteNonQuery ();
                    return status; 
                }
                catch (Exception ex)
                {
                    return status;
                    //Console.WriteLine($" Ups hubo  un clavo con Sqldirecto {ex.Message}");
                    
                }
            }
        }  
    }

}
