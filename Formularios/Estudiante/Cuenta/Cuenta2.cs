using Proyecto_GestionAcademica_Grupo05.Formularios.Estudiante.FormularioHijo2;
using Proyecto_GestionAcademica_Grupo05.Formularios.Profesor.Cuenta_profesor;
using Proyecto_GestionAcademica_Grupo05.Formularios.Profesor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Proyecto_GestionAcademica_Grupo05.Formularios.Estudiante.Cuenta;

namespace Proyecto_GestionAcademica_Grupo05.Formularios.FormularioHijo1
{
    public partial class Cuenta2 : Form
    {
        private string nombreEstudiante;
        private string idCred;
        private string biografia;
        private string contacto;
        public Cuenta2(string idCred)
        {
            InitializeComponent();
            this.idCred = idCred;
            cargarImg();
            RellenarVista();
            panel2.Visible = false;
            circularPictureBox1.MouseMove += circularPictureBox1_MouseMove;
            btnCambiarFoto.Visible = false;
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
                            //if (reader.HasRows)
                            //{
                            //    reader.Read();
                            //    MemoryStream ms2 = new MemoryStream((byte[])reader["foto_perfil"]);
                            //    Bitmap bm = new Bitmap(ms2);

                            //    circularPictureBox1.Image = bm;
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
                                            circularPictureBox1.Image = bm;
                                        }
                                    }
                                    else
                                    {

                                        circularPictureBox1.Image = null;
                                    }
                                }
                                else
                                {

                                    circularPictureBox1.Image = null;
                                }
                            }
                        }
                        conexion.Close();
                    }
                }

            }
            catch (SqlException) { }
        }

        //Método que asigna el nombre y correo respectivo en el perfil del usuario (estudiante)
        private void RellenarVista()
        {
            nombreEstudiante = obtenerNombreDelEstudiante(idCred);
            lblNombreEstudiante.Text = nombreEstudiante;

            contacto = obtenerCorreoDelEstudiante(idCred);
            labelcontacto.Text = contacto;

            biografia = obtenerBiografiaDelUsuario(idCred);
            labelbio.Text = biografia;
        }

        //String que devuelve el nombre del estudiante así: [nombre] [apellido1] [apellido2]
        private string obtenerNombreDelEstudiante(string id)
        {
            //string nombre = "";

            //using (SqlConnection conexion = new SqlConnection($"server={Logins.ObtenerInstancia().nombreServidor}; database=GestorAcademico; integrated security=true"))
            //{
            //    conexion.Open();
            //    string cadena = "SELECT CONCAT(nombre, ' ', apellido1, ' ', apellido2) AS NombreCompleto FROM usuario WHERE idUsuario = @id";
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
        private string obtenerCorreoDelEstudiante(string id)
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

        //Evento que abre el formulario para cambiar la foto de perfil
        private void btnCambiarFoto_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;

            seleccionarfotoe seleccionarFotoForm = new seleccionarfotoe(this, idCred);

            seleccionarFotoForm.TopLevel = false;
            seleccionarFotoForm.FormBorderStyle = FormBorderStyle.None;
            seleccionarFotoForm.Dock = DockStyle.Fill;

            panel2.Controls.Clear();
            panel2.Controls.Add(seleccionarFotoForm);

            seleccionarFotoForm.Show();
        }

        //public void ActualizarLabel(string texto)
        //{
        //    labelcontacto.Text = texto;

        //}
        public void ActualizarLabel2(string texto)
        {
            labelbio.Text = texto;
        }

        private void btnCambiarFoto_Click_1(object sender, EventArgs e)
        {
            panel2.Visible = true;

            seleccionarfotoe seleccionarFotoForm = new seleccionarfotoe(this, idCred);

            seleccionarFotoForm.TopLevel = false;
            seleccionarFotoForm.FormBorderStyle = FormBorderStyle.None;
            seleccionarFotoForm.Dock = DockStyle.Fill;

            panel2.Controls.Clear();
            panel2.Controls.Add(seleccionarFotoForm);

            seleccionarFotoForm.Show();
        }
        public void CambiarVisibilidadPanel2(bool visible)
        {
            panel2.Visible = visible;
        }
        public void CambiarImagen(Image imagen)
        {
            circularPictureBox1.Image = imagen;
        }

        private void btnCambiarFoto_MouseLeave(object sender, EventArgs e)
        {
            btnCambiarFoto.Visible = false;
        }

        private void circularPictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (btnCambiarFoto.Visible == false)
            {
                btnCambiarFoto.Visible = true;
            }
        }

        private void iconButton1_Click_1(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;

            editarperfilhijoe edit = new editarperfilhijoe(idCred);

            MenuPrincipalEstudiante formularioPrincipal = Application.OpenForms.OfType<MenuPrincipalEstudiante>().FirstOrDefault();

            if (formularioPrincipal != null)
            {
                Control panelPrincipal = formularioPrincipal.Controls.Find("panelDesktop", true).FirstOrDefault();

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

