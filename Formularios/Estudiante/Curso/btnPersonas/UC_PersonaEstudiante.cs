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
    public partial class UC_PersonaEstudiante : UserControl
    {
        public string idCred;
        public string idCurso;
        public string nombreCompleto;

        public CheckBox CheckBoxEstudiante
        {
            get { return cbxEscogerEst; }
        }

        public UC_PersonaEstudiante(string idCred, string idCurso, string nombreCompleto)
        {
            InitializeComponent();
            this.idCred = idCred;
            this.idCurso = idCurso;
            this.nombreCompleto = nombreCompleto;
            lblNombre.Text = nombreCompleto;
            cargar_Foto();
        }

        private void cargar_Foto()
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection($"server={Logins.ObtenerInstancia().nombreServidor}; database=GestorAcademico; integrated security=true"))
                {
                    conexion.Open();
                    string consulta = "SELECT foto_perfil FROM Usuario Where idUsuario = " + idCred;

                    using (SqlCommand comando = new SqlCommand(consulta, conexion))
                    {
                        using (SqlDataReader reader = comando.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                reader.Read();
                                MemoryStream ms3 = new MemoryStream((byte[])reader["foto_perfil"]);
                                Bitmap bm = new Bitmap(ms3);
                                cpbFotoPerfil.Image = bm;
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
    }
}
