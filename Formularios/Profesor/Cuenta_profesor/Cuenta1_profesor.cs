using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_GestionAcademica_Grupo05.Formularios.Profesor.Cuenta_profesor
{
    public partial class Cuenta1_profesor : Form
    {
        private string nombreProfesor;
        private string idCred;
        public Cuenta1_profesor(string id)
        {
            InitializeComponent();
            this.idCred = id;
            cargarImg();
            RellenarVista();
        }

        //Método para cargar la imagen en el "circularPictureBox1" dependiendo del usuario ingresado
        private void cargarImg()
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection($"server={Logins.ObtenerInstancia().nombreServidor}; database =GestorAcademico; integrated security = true"))
                {
                    conexion.Open();

                    string consulta = "SELECT foto_perfil FROM Usuario WHERE idUsuario = " + idCred;

                    using (SqlCommand comando = new SqlCommand(consulta, conexion))
                    {
                        using (SqlDataReader reader = comando.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                reader.Read();
                                MemoryStream ms2 = new MemoryStream((byte[])reader["foto_perfil"]);
                                Bitmap bm = new Bitmap(ms2);

                                circularPictureBox1.Image = bm;
                            }
                            else
                            {
                                MessageBox.Show("No se encontró");
                            }
                        }
                    }
                    conexion.Close();
                }


            }
            catch (SqlException) { }
        }

        //Método para rellenar el nombre de estudiante
        private void RellenarVista()
        {
            nombreProfesor = obtenerNombreDelProfesor(idCred);
            //txtNombreCuenta1.Text = nombreEstudiante;
            lblNombreCuenta.Text = nombreProfesor;
        }

        //String que me devuelve ordenado el nombre del estudiante basado en el idCred.
        //Ordena el nombre para que se vea en mayúsucla y así: [apellido1], [nombre]
        private string obtenerNombreDelProfesor(string id)
        {
            string nombre = "";

            using (SqlConnection conexion = new SqlConnection($"server={Logins.ObtenerInstancia().nombreServidor}; database=GestorAcademico; integrated security=true"))
            {
                conexion.Open();
                string cadena = "SELECT CONCAT(UPPER(apellido1), ', ', UPPER(nombre)) AS NombreCompleto FROM usuario WHERE idUsuario = @id";
                SqlCommand comando = new SqlCommand(cadena, conexion);
                comando.Parameters.AddWithValue("@id", id);
                SqlDataReader lector = comando.ExecuteReader();

                if (lector.Read())
                {
                    nombre = lector["NombreCompleto"].ToString();
                }
                conexion.Close();
            }
            return nombre;
        }

        //Evento que sirve para abrir el perfil del estudiante (en ese perfil se puede modificar la biografía y foto de perfil del usuario)
        private void btnPerfil_Click(object sender, EventArgs e)
        {
            try
            {
                Form Cuenta2_profesor = new Cuenta2_profesor(idCred);

                MenuPrincipalProf formularioPrincipalProf = ActiveForm as MenuPrincipalProf;

                this.Close();

                formularioPrincipalProf.AbrirFormHijo(Cuenta2_profesor);
            }
            catch (Exception ex) { 
                MessageBox.Show(ex.Message);
            }
        }

        //Evento que cierra el formulario (lo oculta, para dar la sensación de submenú)
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            // Buscar el formulario principal por su nombre
            MenuPrincipalProf formularioPrincipal = Application.OpenForms.OfType<MenuPrincipalProf>().FirstOrDefault();

            if (formularioPrincipal != null)
            {
                // Acceder al panelDesktop2 y ocultarlo
                Control panelDesktop2_profesor = formularioPrincipal.Controls.Find("panelDesktop2_profesor", true).FirstOrDefault();

                if (panelDesktop2_profesor != null)
                {
                    panelDesktop2_profesor.Visible = false;
                    formularioPrincipal.DesactivarBoton();
                }
            }
        }

        //Evento qye cierra la sesión para poder devolverse al login
        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            MenuPrincipalProf formularioPrincipal = Application.OpenForms.OfType<MenuPrincipalProf>().FirstOrDefault();

            if (formularioPrincipal != null)
            {
                // Cierra el formulario principal y, por lo tanto, todos los formularios hijos
                formularioPrincipal.Close();
            }

            // Abre el formulario de inicio de sesión (LogInEstudiantes)
            LogInProfesores logInEstudiantes = new LogInProfesores();
            logInEstudiantes.Show();
        }
    }
}
