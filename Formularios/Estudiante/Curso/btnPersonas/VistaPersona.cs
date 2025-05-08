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

namespace Proyecto_GestionAcademica_Grupo05.Formularios.Estudiante.FormularioHijo1.Curso.btnPersonas
{
    public partial class VistaPersona : Form
    {
        private string idCred;
        private string nombre;
        private string correo;
        private string biografia;
        private string id;

        public VistaPersona(string idCred, string id)
        {
            InitializeComponent();
            this.idCred = idCred;
            this.id= id;
            cargarImg();
            RellenarVista();
        }

        //Método que carga la imagen del usuario
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
            catch (Exception ex) 
            { 
                MessageBox.Show("Error en el método 'cargarImg': " + ex.Message);
            }
        }

        //Método para rellenar vista (nombre y correo)
        private void RellenarVista()
        {
            nombre = obtenerNombre(id);
            lblNombre.Text = nombre;

            correo = obtenerCorreo(id);
            lblCorreo.Text = correo;

            biografia = obtenerBiografia(id);
            txtBiografia.Text = biografia;
        }

        //String que obtiene el nombre del usuario
        private string obtenerNombre(string id)
        {
            string nombre = "";

            using (SqlConnection conexion = new SqlConnection($"server={Logins.ObtenerInstancia().nombreServidor}; database=GestorAcademico; integrated security=true"))
            {
                conexion.Open();
                string cadena = "SELECT CONCAT(nombre, ' ', apellido1, ' ', apellido2) AS NombreCompleto FROM usuario WHERE idUsuario = @id";
                SqlCommand comando = new SqlCommand(cadena, conexion);
                comando.Parameters.AddWithValue("@id", id);
                SqlDataReader lector = comando.ExecuteReader();

                if (lector.Read())
                {
                    nombre = lector["NombreCompleto"].ToString();
                }
            }
            return nombre;
        }

        //String que obtiene el correo electrónico del usuario
        private string obtenerCorreo(string id)
        {
            string correo = "";
            using (SqlConnection conexion = new SqlConnection($"server={Logins.ObtenerInstancia().nombreServidor}; database=GestorAcademico; integrated security=true"))
            {
                conexion.Open();
                string cadena = "SELECT correo AS CorreoElectronico FROM Credencial WHERE idCredencial = @id";
                SqlCommand comando = new SqlCommand(cadena, conexion);
                comando.Parameters.AddWithValue("@id", id);
                SqlDataReader lector = comando.ExecuteReader();

                if (lector.Read())
                {
                    correo = lector["CorreoElectronico"].ToString();
                }
            }
            return correo;
        }

        private string obtenerBiografia(string id)
        {
            string biografia = "";
            using (SqlConnection conexion = new SqlConnection($"server={Logins.ObtenerInstancia().nombreServidor}; database=GestorAcademico; integrated security=true"))
            {
                conexion.Open();
                string cadena = "SELECT biografia AS Biografia FROM Usuario WHERE idUsuario = @id";
                SqlCommand comando = new SqlCommand(cadena, conexion);
                comando.Parameters.AddWithValue("@id", id);
                SqlDataReader lector = comando.ExecuteReader();

                if (lector.Read())
                {
                    biografia = lector["Biografia"].ToString();
                }

                if (!lector.Read())
                {
                    biografia = nombre + "no ha añadido una biografía";
                }
            }
            return biografia;
        }
    }
}
