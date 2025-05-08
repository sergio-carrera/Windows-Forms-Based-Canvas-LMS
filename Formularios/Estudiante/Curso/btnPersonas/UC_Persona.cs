using Proyecto_GestionAcademica_Grupo05.Formularios.Estudiante.FormularioHijo1.Curso.btnPersonas;
using Proyecto_GestionAcademica_Grupo05.Formularios.Profesor.Curso_profesor;
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

namespace Proyecto_GestionAcademica_Grupo05.Formularios.Estudiante.FormularioHijo1.Curso
{
    public partial class UC_Persona : UserControl
    {
        public string idCred;
        public string idCurso;
        public string nombreCompleto;
        public string rol;
        public string id;
        public string idCredTipo;

        public UC_Persona(string idCred, string idCurso, string nombreCompleto, string rol, string id, string idCredTipo)
        {
            InitializeComponent();
            this.idCred = idCred;
            this.idCurso = idCurso;
            this.nombreCompleto = nombreCompleto;
            this.rol = rol;
            this.id = id;
            this.idCredTipo = idCredTipo;
            cargar_Foto();
            lblNombre.Text = nombreCompleto;
            obtenerCodigoYCurso();
            lblRol.Text = rol;
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

        private void obtenerCodigoYCurso()
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection($"server={Logins.ObtenerInstancia().nombreServidor}; database=GestorAcademico; integrated security=true"))
                {
                    conexion.Open();
                    string consulta = "SELECT codigo, nombre FROM Curso Where idCurso= " + idCurso;

                    using (SqlCommand comando = new SqlCommand(consulta, conexion))
                    {
                        using (SqlDataReader reader = comando.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                reader.Read();
                                string codigo = reader["codigo"].ToString();
                                string nombre = reader["nombre"].ToString();

                                lblCurso.Text = $"{codigo} {nombre}";
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

        private void lblNombre_Click(object sender, EventArgs e)
        {
            if (idCredTipo.ToString() == "1")
            {
                Form VistaPersona = new VistaPersona(idCred, id);

                CursoInicioProf cursoInicioProf = Application.OpenForms.OfType<CursoInicioProf>().FirstOrDefault();

                cursoInicioProf.AbrirFormHijo(VistaPersona);
            }
            else if (idCredTipo.ToString() == "2")
            {
                Form VistaPersona = new VistaPersona(idCred, id);

                CursoInicio cursoInicio = Application.OpenForms.OfType<CursoInicio>().FirstOrDefault();

                cursoInicio.AbrirFormHijo(VistaPersona);
            }
        }
    }
}
