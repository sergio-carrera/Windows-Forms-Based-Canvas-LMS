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

namespace Proyecto_GestionAcademica_Grupo05.Formularios.Profesor.Curso_profesor.btnAnuncios
{
    public partial class UC_Anuncio : UserControl
    {
        public string idCurso;
        public string idCred;
        public UC_Anuncio(string idCurso, string nombreAnuncio, string fechaAnuncio, string id)
        {
            InitializeComponent();
            cargarImg(id);
            this.idCurso = idCurso;
            this.idCred = id;
            lblTitulo.Text = nombreAnuncio;
            lblFecha.Text = fechaAnuncio;
        }

        private void cargarImg(string idCred)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection($"server={Logins.ObtenerInstancia().nombreServidor}; database = GestorAcademico; integrated security = true"))
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

                                pbxProfesor.Image = bm;
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

        private void lblTitulo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string tituloAnuncio = lblTitulo.Text;
            ppAnuncio pAnuncioForm = new ppAnuncio(idCred, idCurso, tituloAnuncio);
            pAnuncioForm.Show();
        }
    }
}
