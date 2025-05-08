using Proyecto_GestionAcademica_Grupo05.ControlesPersonalizados;
using Proyecto_GestionAcademica_Grupo05.Formularios.Estudiante.Cuenta;
using Proyecto_GestionAcademica_Grupo05.Formularios.FormularioHijo1;
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
    public partial class Cuenta2_profesor : Form
    {
        private string nombreProfesor;
        private string correoProfesor;
        private string idCred;
        private string biografia;
        private string contacto;

        public Cuenta2_profesor(string id)
        {
            InitializeComponent();
            this.idCred = id;
            cargarImg();
            RellenarVista();
            panel2.Visible = false;
            circularPictureBox1Prof.MouseMove += circularPictureBox1Prof_MouseMove;
            btnCambiarFoto.Visible = false;
        }

        //Método para cargar la imagen en el "circularPictureBox1Prof" dependiendo del usuario ingresado
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
                            //if (reader.HasRows)
                            //{
                            //    reader.Read();
                            //    MemoryStream ms2 = new MemoryStream((byte[])reader["foto_perfil"]);
                            //    Bitmap bm = new Bitmap(ms2);

                            //    circularPictureBox1Prof.Image = bm;
                            //}
                            //else
                            //{

                            //}
                            if (reader.HasRows)
                            {
                                reader.Read();

                                // Verificar si el valor obtenido no es DBNull.Value
                                if (reader["foto_perfil"] != DBNull.Value)
                                {
                                    // Obtener la imagen de la base de datos y asignarla al PictureBox
                                    byte[] imagenBytes = (byte[])reader["foto_perfil"];
                                    if (imagenBytes.Length > 0)
                                    {
                                        using (MemoryStream ms = new MemoryStream(imagenBytes))
                                        {
                                            Bitmap bm = new Bitmap(ms);
                                            circularPictureBox1Prof.Image = bm;
                                        }
                                    }
                                    else
                                    {

                                        circularPictureBox1Prof.Image = null;
                                    }
                                }
                                else
                                {

                                    circularPictureBox1Prof.Image = null;
                                }
                            }
                        }

                    }

                    conexion.Close();
                }


            }
            catch (SqlException) { }
        }

        //Método que asigna el nombre y correo respectivo en el perfil del usuario (estudiante)
        private void RellenarVista()
        {
            nombreProfesor = obtenerNombreDelProfesor(idCred);
            lblNombreProfesor.Text = nombreProfesor;


            contacto = obtenerCorreoDelProfesor(idCred);
            labelcontacto.Text = contacto;


            biografia = obtenerBiografiaDelUsuario(idCred);
            labelbio.Text = biografia;
        }

        //String que devuelve el nombre del estudiante así: [nombre] [apellido1] [apellido2]
        private string obtenerNombreDelProfesor(string id)
        {
            //string nombre = "";

            //using (SqlConnection conexion = new SqlConnection($"server={Logins.ObtenerInstancia().nombreServidor}; database=GestorAcademico; integrated security=true"))
            //{
            //    conexion.Open();
            //    string cadena = "SELECT CONCAT(nombre, ' ', apellido1, ' ', apellido2) AS NombreCompleto FROM Usuario WHERE idUsuario = @id";
            //    SqlCommand comando = new SqlCommand(cadena, conexion);
            //    comando.Parameters.AddWithValue("@id", id);
            //    SqlDataReader lector = comando.ExecuteReader();

            //    if (lector.Read())
            //    {
            //        nombre = lector["NombreCompleto"].ToString();
            //    }
            //}
            //return nombre;
            string nombre = "";

            // Check if id is null or empty
            if (string.IsNullOrEmpty(id))
            {
                return nombre;
            }

            using (SqlConnection conexion = new SqlConnection($"server={Logins.ObtenerInstancia().nombreServidor}; database=GestorAcademico; integrated security=true"))
            {
                conexion.Open();
                string cadena = "SELECT CONCAT(nombre, ' ', apellido1, ' ', apellido2) AS NombreCompleto FROM Usuario WHERE idUsuario = @id";

                using (SqlCommand comando = new SqlCommand(cadena, conexion))
                {
                    // Add parameter
                    comando.Parameters.AddWithValue("@id", id);

                    try
                    {
                        using (SqlDataReader lector = comando.ExecuteReader())
                        {
                            if (lector.Read())
                            {
                                nombre = lector["NombreCompleto"].ToString();
                            }
                        }
                    }
                    catch (SqlException ex)
                    {

                        Console.WriteLine("SQL Error: " + ex.Message);

                    }
                }
            }
            return nombre;

        }

        //String que devuele el correo del estudiante
        private string obtenerCorreoDelProfesor(string id)
        {
            //string correo = "";
            //using (SqlConnection conexion = new SqlConnection($"server={Logins.ObtenerInstancia().nombreServidor}; database=GestorAcademico; integrated security=true"))
            //{
            //    conexion.Open();
            //    string cadena = "SELECT correo AS CorreoElectronico FROM Credencial WHERE idCredencial = @id";
            //    SqlCommand comando = new SqlCommand(cadena, conexion);
            //    comando.Parameters.AddWithValue("@id", id);
            //    SqlDataReader lector = comando.ExecuteReader();

            //    if (lector.Read())
            //    {
            //        correo = lector["CorreoElectronico"].ToString();
            //    }
            //}
            //return correo;
            string correo = "";
            if (string.IsNullOrEmpty(id))
            {
                return correo;
            }

            try
            {
                using (SqlConnection conexion = new SqlConnection($"server={Logins.ObtenerInstancia().nombreServidor}; database=GestorAcademico; integrated security=true"))
                {
                    conexion.Open();
                    string cadena = "SELECT correo AS CorreoElectronico FROM Credencial WHERE idCredencial = @id";
                    SqlCommand comando = new SqlCommand(cadena, conexion);
                    comando.Parameters.AddWithValue("@id", id);

                    using (SqlDataReader lector = comando.ExecuteReader())
                    {
                        if (lector.Read())
                        {
                            correo = lector["CorreoElectronico"].ToString();
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                // Handle SQL exception
                Console.WriteLine("SQL Error: " + ex.Message);
                // Log or handle the exception accordingly
            }

            return correo;
        }
        private string obtenerBiografiaDelUsuario(string id)
        {
            string biografia = "";

            try
            {
                using (SqlConnection conexion = new SqlConnection($"server={Logins.ObtenerInstancia().nombreServidor}; database=GestorAcademico; integrated security=true"))
                {
                    conexion.Open();
                    string consulta = "SELECT biografia FROM Usuario WHERE idUsuario = @id";
                    using (SqlCommand comando = new SqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@id", id);
                        using (SqlDataReader lector = comando.ExecuteReader())
                        {
                            if (lector.Read())
                            {
                                biografia = lector["biografia"].ToString();
                            }
                        }
                    }
                }
            }
            catch (SqlException)
            {

            }

            return biografia;
        }

        // Método para obtener el contacto del usuario desde la base de datos
        private string obtenerContactoDelUsuario(string id)
        {
            string contacto = "";

            try
            {
                using (SqlConnection conexion = new SqlConnection($"server={Logins.ObtenerInstancia().nombreServidor}; database=GestorAcademico; integrated security=true"))
                {
                    conexion.Open();
                    string consulta = "SELECT contacto FROM Usuario WHERE idUsuario = @id";
                    using (SqlCommand comando = new SqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@id", id);
                        using (SqlDataReader lector = comando.ExecuteReader())
                        {
                            if (lector.Read())
                            {
                                contacto = lector["contacto"].ToString();
                            }
                        }
                    }
                }
            }
            catch (SqlException)
            {

            }

            return contacto;
        }

        public void ActualizarLabel(string texto)
        {
            labelcontacto.Text = texto;

        }
        public void ActualizarLabel2(string texto)
        {
            labelbio.Text = texto;
        }

        public void CambiarVisibilidadPanel2(bool visible)
        {
            panel2.Visible = visible;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        public void CambiarImagen(Image imagen)
        {
            circularPictureBox1Prof.Image = imagen;
        }

        private void Cuenta2_profesor_Load(object sender, EventArgs e)
        {
            //circularPictureBox1Prof.MouseEnter += MostrarBotonCambiarFoto;
            //circularPictureBox1Prof.MouseLeave += OcultarBotonCambiarFoto;
            //btnCambiarFoto.Visible = false;
            //btnCambiarFoto.Enabled = false;

            //btnCambiarFoto.MouseEnter += MostrarBotonCambiarFoto;
            //btnCambiarFoto.MouseLeave += OcultarBotonCambiarFoto;
        }
        //private void MostrarBotonCambiarFoto(object sender, EventArgs e)
        //{
        //    btnCambiarFoto.Visible = true;
        //    btnCambiarFoto.Enabled = true;
        //}

        //private void OcultarBotonCambiarFoto(object sender, EventArgs e)
        //{
        //    btnCambiarFoto.Visible = false;
        //    btnCambiarFoto.Enabled = false;
        //}

        private void circularPictureBox1Prof_MouseMove(object sender, MouseEventArgs e)
        {
            if (btnCambiarFoto.Visible == false)
            {
                btnCambiarFoto.Visible = true;
            }
        }

        private void btnCambiarFoto_MouseLeave(object sender, EventArgs e)
        {
            btnCambiarFoto.Visible = false;
        }

        private void btnCambiarFoto_Click_1(object sender, EventArgs e)
        {
            panel2.Visible = true;

            seleccionarfotop seleccionarFotoForm = new seleccionarfotop(this, idCred);

            seleccionarFotoForm.TopLevel = false;
            seleccionarFotoForm.FormBorderStyle = FormBorderStyle.None;
            seleccionarFotoForm.Dock = DockStyle.Fill;

            panel2.Controls.Clear();
            panel2.Controls.Add(seleccionarFotoForm);

            seleccionarFotoForm.Show();
        }

        private void iconButton1_Click_1(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;

            editarperfilhijop edit = new editarperfilhijop(idCred);

            MenuPrincipalProf formularioPrincipal = Application.OpenForms.OfType<MenuPrincipalProf>().FirstOrDefault();

            if (formularioPrincipal != null)
            {
                Control panelPrincipal = formularioPrincipal.Controls.Find("panelDesktop_profesor", true).FirstOrDefault();

                if (panelPrincipal != null)
                {
                    panelPrincipal.Controls.Clear();

                    edit.TopLevel = false;
                    edit.FormBorderStyle = FormBorderStyle.None;
                    edit.Dock = DockStyle.Fill;

                    panelPrincipal.Controls.Add(edit);

                    edit.Show();
                }
            }
        }
    }
}
