using Proyecto_GestionAcademica_Grupo05.ControlesPersonalizados;
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
    public partial class editarperfilhijop : Form
    {
        private string idCred;
        private Image imagenSeleccionada;

        public editarperfilhijop(string idCred)
        {
            InitializeComponent();
            this.idCred = idCred;
            cargarImg();

        }

        private void GuardarBiografiaEnDB(string biografia)
        {
            try
            {
                string connectionString = $"server={Logins.ObtenerInstancia().nombreServidor}; database=GestorAcademico; integrated security=true";
                string query = "IF EXISTS (SELECT * FROM Usuario WHERE idUsuario = @id) " +
                               "BEGIN " +
                               "    UPDATE Usuario SET biografia = @biografia WHERE idUsuario = @id " +
                               "END " +
                               "ELSE " +
                               "BEGIN " +
                               "    INSERT INTO Usuario (idUsuario, biografia) VALUES (@id, @biografia) " +
                               "END";

                if (string.IsNullOrWhiteSpace(biografia))
                {
                    biografia = "No ha añadido una bio";
                }

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@biografia", biografia);
                        command.Parameters.AddWithValue("@id", idCred);
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException)
            {

            }
        }
        //private void GuardarContactoEnDB(string contacto)
        //{
        //    try
        //    {
        //        string connectionString = $"server={Logins.ObtenerInstancia().nombreServidor}; database=GestorAcademico; integrated security=true";
        //        string query = "IF EXISTS (SELECT * FROM Usuario WHERE idUsuario = @id) " +
        //                       "BEGIN " +
        //                       "    UPDATE Usuario SET contacto = @contacto WHERE idUsuario = @id " +
        //                       "END " +
        //                       "ELSE " +
        //                       "BEGIN " +
        //                       "    INSERT INTO Usuario (idUsuario, contacto) VALUES (@id, @contacto) " +
        //                       "END";

        //        if (string.IsNullOrWhiteSpace(contacto))
        //        {
        //            contacto = "No se ha añadido información de contacto adicional";
        //        }

        //        using (SqlConnection connection = new SqlConnection(connectionString))
        //        {
        //            using (SqlCommand command = new SqlCommand(query, connection))
        //            {
        //                command.Parameters.AddWithValue("@contacto", contacto);
        //                command.Parameters.AddWithValue("@id", idCred);
        //                connection.Open();
        //                command.ExecuteNonQuery();
        //            }
        //        }
        //    }
        //    catch (SqlException)
        //    {

        //    }
        //}

        public void CambiarImagen2(Image imagen1)
        {
            circularPictureBox1Prof.Image = imagen1; // Establecer la imagen en el PictureBox
        }
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
                            //    imagenSeleccionada = new Bitmap(ms2); // Guardar la imagen en la variable de clase

                            //    circularPictureBox1Prof.Image = imagenSeleccionada;
                            //}
                            //else
                            //{
                            //    // Lógica para el caso en que no haya imagen en la base de datos
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Los datos han sido guardados");
            Cursor = Cursors.Hand;
            Cuenta2_profesor formHijo1 = new Cuenta2_profesor(idCred);

            //string textoTextBox = textBox1.Text.Trim();
            string textoTextBox2 = textBox2.Text.Trim();

            // Verifica y guarda el contacto
            //if (!string.IsNullOrEmpty(textoTextBox))
            //{
            //    GuardarContactoEnDB(textoTextBox);
            //    formHijo1.ActualizarLabel(textoTextBox);
            //}
            //else
            //{
            //    GuardarContactoEnDB("No se ha añadido información de contacto adicional");
            //    formHijo1.ActualizarLabel("No se ha añadido información de contacto adicional");
            //}
            // Verifica y guarda el biografia
            if (!string.IsNullOrEmpty(textoTextBox2))
            {
                GuardarBiografiaEnDB(textoTextBox2);
                formHijo1.ActualizarLabel2(textoTextBox2);
            }
            else
            {
                GuardarBiografiaEnDB("No ha añadido una bio");
                formHijo1.ActualizarLabel2("No ha añadido una bio");
            }




            MenuPrincipalProf formularioPrincipal = Application.OpenForms.OfType<MenuPrincipalProf>().FirstOrDefault();

            if (formularioPrincipal != null)
            {
                Control panelPrincipal = formularioPrincipal.Controls.Find("panelDesktop_profesor", true).FirstOrDefault();

                if (panelPrincipal != null)
                {
                    panelPrincipal.Controls.Clear();

                    formHijo1.TopLevel = false;
                    formHijo1.FormBorderStyle = FormBorderStyle.None;
                    formHijo1.Dock = DockStyle.Fill;

                    panelPrincipal.Controls.Add(formHijo1);

                    formHijo1.Show();
                }
            }
        }
    }

}
