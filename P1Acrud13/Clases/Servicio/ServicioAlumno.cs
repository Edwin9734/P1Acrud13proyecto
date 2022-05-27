using P1Acrud13.Clases.CapaDatos;
using P1Acrud13.Clases.edentidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace P1Acrud13.Clases.Servicio
{
    public class ServicioAlumno
    {
        ClsConexion cone = new ClsConexion();
        //public void  promedio(string instruccion)
        //{
        //    int acumNotas = 0;            
        //    DataTable respuesta  = cone.ConsulaTabaDirecta(instruccion);

        //    foreach ( DataRow dr in respuesta.Rows)
        //    {
        //        acumNotas = acumNotas + Convert.ToInt32(dr["parcial1"]);
        //    }
        //    int promedio = acumNotas / respuesta.Rows.Count;
        //    Console.WriteLine("Promedio=" + promedio);
        //}

        public DataTable ConsultaSQL(string instruccion)
        {

            DataTable respuesta = cone.ConsulaTabaDirecta(instruccion);
            return respuesta;            
        }

        //public void inserta(string nombre,string carnet, string correo, string clase, string seccion)
        //{
            
        //    ClsConexion conn = new ClsConexion();
        //    string instruccion = $"insert into tb_alumnos ( carnet,nombre,correo,clase,seccion) values ('{carnet}','{nombre}', '{correo}','{clase}','{seccion}')";
        //    conn.EjecutarSQLDirecto(instruccion);
        //}

        //public void cambia()
        //{
        //    string instruccion = "update tb_alumnos set parcial1 = 25 where carnet = '21-11951' ";
        //    cone.EjecutarSQLDirecto(instruccion);
        //}
   
        public int CrearAlumno( MdAlumno alu)
        {
            string instruccion = $"insert into tb_alumnos (carnet,nombre,seccion,clase,correo,parcial1,parcial2,parcial3) values('{alu.carnet}','{alu.nombre}','{alu.seccion}','{alu.clase}','{alu.correo}','{alu.parcial1}','{alu.parcial2}','{alu.parcial3}')";
             return cone.EjecutarSQLDirecto(instruccion);   
        }

        public MdAlumno ObtenerAlumno(string carnet)
        {

            MdAlumno alu = new MdAlumno();

            DataTable resp = cone.ConsulaTabaDirecta($"select * from tb_alumnos where carnet ='{carnet}'");
            if (resp.Rows.Count > 0)
            {
                foreach (DataRow item in resp.Rows)
                {
                    alu.idAlumno = Convert.ToInt32(item["idAlumno"]);
                    alu.carnet = item["carnet"].ToString();
                    alu.nombre = item["nombre"].ToString();
                    alu.seccion = item["seccion"].ToString();
                    alu.clase = item["clase"].ToString();
                    alu.correo = item["correo"].ToString();
                    alu.parcial1 = (Int32)item["parcial1"];
                    alu.parcial2 = (Int32)item["parcial2"];
                    alu.parcial3 = (Int32)item["parcial3"];

                }
                return alu;
            }
            else
            {
                return null;
            }
        }

        public int actualizarAlumno(MdAlumno alu)
        {
            string instruccion = $"update tb_alumnos set  nombre = '{alu.nombre}',correo = '{alu.correo}', clase = '{alu.clase}',seccion= '{alu.seccion}' , parcial1 =  '{alu.parcial1}', parcial2 =  '{alu.parcial2}',parcial3 =  '{alu.parcial3}' where carnet ='{alu.carnet}'";
            return cone.EjecutarSQLDirecto(instruccion);
        }

        public int BorrarAlumno(MdAlumno alu)
        {
            string instruccion = $"delete from tb_alumnos where   carnet = '{alu.carnet}' ";
            return cone.EjecutarSQLDirecto(instruccion);
        }

    }
}
