








using P1Acrud13.Clases.edentidades;
using P1Acrud13.Clases.Servicio;





ServicioAlumno alu = new();

//string cuerito = "select * from tb_alumnos Where carnet = '21-11951'";
//alu.lee(cuerito);
//Console.WriteLine("antes de cambiar");
//Console.ReadLine();
//alu.cambia();
//Console.WriteLine(" Despues de cambiar");
//Console.ReadLine();
//alu.lee(cuerito);

string cuerito = "select * from tb_alumnos where seccion= 'c'";
//alu.lee(cuerito);
//Console.WriteLine("antes de cambiar");
//Console.ReadLine();

//string nombre = "Juana Peres";
//string carnet = "2023-1";
//string correo = "xx@xx.com";
//string clase = "Progra";
//string seccion = "c";


//Console.WriteLine("Ingrese su nombre ");
//nombre = Console.ReadLine();


//Console.WriteLine("Ingrese su carnet ");
//carnet= Console.ReadLine();

//Console.WriteLine("Ingrese su correo ");
//correo = Console.ReadLine();

//Console.WriteLine("Ingrese su clase ");
//clase = Console.ReadLine();

//Console.WriteLine("Ingrese su seccion");
//seccion = Console.ReadLine();


//alu.inserta(nombre, carnet,correo,clase,seccion);
//alu.lee(cuerito);


MdAlumno oalumno = new();
//oalumno.nombre = "Gabrciela Garcia";
//oalumno.carnet = " 20283-8";
//oalumno.seccion = "c";
//oalumno.correo = "cami@.com";
//oalumno.clase = "Progra avanzada";

//alu.CrearAlumno(oalumno);
//Console.WriteLine(oalumno.ToString());
//alu.lee(cuerito);


oalumno = alu.ObtenerAlumno("18-11486");
if (oalumno == null)
{
    Console.WriteLine($"Ese cuate no existe");

}else
{
    Console.WriteLine($"nombre: {oalumno.nombre}");
    //Console.WriteLine(oalumno.ToString());
    //oalumno.clase = "Electronica";
    alu.actualizarAlumno(oalumno);
}





