using P1Acrud13.Clases.edentidades;
using P1Acrud13.Clases.Servicio;
using System.Data;

namespace WFP1AC14
{
    public partial class Form1 : Form
    {
        ServicioAlumno srvAlumno = new();
        MdAlumno oAlumno = new();

        public Form1()
        {
            InitializeComponent();
        }

        private void DesplegarGrid()
        {
          var respuesta = srvAlumno.ConsultaSQL("select * from tb_alumnos");
            dataGridViewAlumnos.DataSource = respuesta;  
        }

        private void buttonObtenerDatos_Click(object sender, EventArgs e)
        {
            DesplegarGrid();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void MapaDatosFormulario(MdAlumno _alumno)
        {
            textBoxCarnet.Text = _alumno.carnet;
            textBoxNombre.Text = _alumno.nombre;
            textBoxCorreo.Text = _alumno.correo;
            comboBoxClase.Text = _alumno.clase;
            comboBoxSeccion.Text = _alumno.seccion;
            textBoxParcial1.Text = _alumno.parcial1.ToString();
            textBoxParcial2.Text = _alumno.parcial2.ToString();
            textBoxParcial3.Text = _alumno.parcial3.ToString();

        }


        private void LimpiarDatos()
        {
            oAlumno = new();
            MapaDatosFormulario(oAlumno);
        }
        private void buscarAlumno(string carnet)
        {
            oAlumno = null;
            oAlumno = srvAlumno.ObtenerAlumno(carnet);
            if (oAlumno == null)
            {
                MessageBox.Show("no existe ese cuate");
                LimpiarDatos();
            }
            else
            {
                MapaDatosFormulario(oAlumno);
            }
        }
        
        private void consulta()
        {
            string carnet = textBoxCarnet.Text;
            buscarAlumno(carnet);
        }
        private void buttonConsulta_Click(object sender, EventArgs e)
        {
           consulta();
        }

        private MdAlumno DatosFormulario()
        {
            MdAlumno _alumno = new();
            _alumno.carnet = textBoxCarnet.Text.Trim();
            _alumno.nombre = textBoxNombre.Text.Trim();
            _alumno.correo = textBoxCorreo.Text.Trim();
            _alumno.clase  = comboBoxClase.Text;
            _alumno.seccion= comboBoxSeccion.Text;
            if (Convert.ToInt32(textBoxParcial1.Text) >= 0 && Convert.ToInt32(textBoxParcial1.Text) <= 20)
            {
                _alumno.parcial1 = Convert.ToInt32(textBoxParcial1.Text.Trim());
            }
            else
            {
                MessageBox.Show("Datos ingresados no validos\n  !El programa se cerrará¡ ");
                Application.Exit();
            }

            if (Convert.ToInt32(textBoxParcial1.Text) >= 0 && Convert.ToInt32(textBoxParcial1.Text) <= 20)
            {
                _alumno.parcial2 = Convert.ToInt32(textBoxParcial2.Text.Trim());
            }
            else
            {
                MessageBox.Show("Datos ingresados no validos\n  !El programa se cerrará¡ ");
                Application.Exit();
            }

            if (Convert.ToInt32(textBoxParcial1.Text) >= 0 && Convert.ToInt32(textBoxParcial1.Text) <= 35)
            {
                _alumno.parcial3 = Convert.ToInt32(textBoxParcial3.Text.Trim());
            }
            else
            {
                MessageBox.Show("Datos ingresados no validos\n  !El programa se cerrará¡ ");
                Application.Exit();
            }


            return _alumno;

        }


        private void Alumnonuevo()
        {
            string carnet = textBoxCarnet.Text;
            oAlumno = srvAlumno.ObtenerAlumno(carnet);
            if (oAlumno == null)
            {
                oAlumno = DatosFormulario();
                int respuesta = srvAlumno.CrearAlumno(oAlumno);
                if (respuesta > 0)
                {
                    MessageBox.Show("Se creo con exito el Alumno");
                    LimpiarDatos();
                    DesplegarGrid();
                    textBoxNombre.Text = oAlumno.nombre;
                }
                else
                {
                    MessageBox.Show("Perdon hay un problema con la Grabacion");
                }
            }
            else
            {
                MessageBox.Show("Perdon ese carnet ya existe");
            }
        }


        private void buttonCrearAlumno_Click(object sender, EventArgs e)
        {
            Alumnonuevo();
        }


        private void actualizacion()
        {
            string nombre = "";
            oAlumno = DatosFormulario();
            int respuesta = srvAlumno.actualizarAlumno(oAlumno);
            if (respuesta > 0)
            {
                MessageBox.Show("Se actualizo con exito el Alumno");
                nombre = oAlumno.nombre;
                LimpiarDatos();
                DesplegarGrid();
                
            }
            else
            {
                MessageBox.Show("Perdon hay un problema con la Grabacion");
            }
            textBoxNombre.Text = nombre;
        }



        private void buttonActualizar_Click(object sender, EventArgs e)
        {
            actualizacion();
        }


        private void Importacion()
        {
            string archivo = @"C:\Users\alumno\Documents\alunos (1).txt";
            ClsImportExport im = new();
            MessageBox.Show(im.importar(archivo));
        }
        private void buttonImportar_Click(object sender, EventArgs e)
        {
           Importacion();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void Exportacion()
        {
            string archivo = @"C:\Users\alumno\Documents\salida.csv";
            ClsImportExport im = new();
            MessageBox.Show(im.exportar("select * from tb_alumnos where seccion = 'A' ", archivo));
        }

        private void buttonExportar_Click(object sender, EventArgs e)
        {
            Exportacion();
        }

        private void BorrarAlumno()
        {
            string carnet = textBoxCarnet.Text;
            oAlumno = srvAlumno.ObtenerAlumno(carnet);
            if (oAlumno == null)
            {
               

                MessageBox.Show("Perdon ese carnet no existe");
            }
            else
            {
                MessageBox.Show("El alumno ha sido borrado");
                srvAlumno.BorrarAlumno(oAlumno);
                LimpiarDatos();
                DesplegarGrid();    
            }
        }

        private void buttonBorrarAlumno_Click(object sender, EventArgs e)
        {
            BorrarAlumno();
        }
    }
} 