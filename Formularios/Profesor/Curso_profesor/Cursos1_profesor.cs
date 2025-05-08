using Proyecto_GestionAcademica_Grupo05.Formularios.Estudiante.FormularioHijo2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_GestionAcademica_Grupo05.Formularios.Profesor.Curso_profesor
{
    public partial class Cursos1_profesor : Form
    {
        public string idCred;
        public Cursos1_profesor(string id)
        {
            InitializeComponent();
            this.idCred = id;
            RellenarVista();
        }

        //Método para cargar la "miniatura" en cada UC dependiendo de los cursos en los que esté el usuario (estudiante)
        //Se añade tantas UC como cursos matriculados
        //Cada UC tiene: codigo del curso, nombre del curso y un label con esta infomación "3º CUATRIMESTRE DEL 2023"
        private void RellenarVista()
        {
            int contador = 0;
            SqlConnection conexion = new SqlConnection($"server={Logins.ObtenerInstancia().nombreServidor}; database =GestorAcademico; integrated security = true");
            conexion.Open();
            string cadena = "select * from usuario_x_curso where fkUsuario = " + idCred;
            SqlCommand comando = new SqlCommand(cadena, conexion);
            SqlDataReader lector = comando.ExecuteReader();

            while (lector.Read())
            {
                contador++;
                var miniatura = new UC_CursoProf(idCred, obtenerIDdelCurso(lector["fkCurso"] + ""), obtenerCodigodelCurso(lector["fkCurso"] + ""), obtenerNombredelCurso(lector["fkCurso"] + ""));
                VistaCursos.Controls.Add(miniatura);
            }
            if (contador == 0)
            {
                MessageBox.Show("No hay ningún curso para impartir");
            }
        }

        //String para obtener el codigo del curso (enviado a la miniatura de cada UC)
        private string obtenerCodigodelCurso(string id)
        {
            string codigoCurso = "";
            using (SqlConnection conexion = new SqlConnection($"server={Logins.ObtenerInstancia().nombreServidor}; database=GestorAcademico; integrated security=true"))
            {
                conexion.Open();
                string cadena = "SELECT codigo FROM curso WHERE idCurso = @id";
                SqlCommand comando = new SqlCommand(cadena, conexion);
                comando.Parameters.AddWithValue("@id", id);
                SqlDataReader lector = comando.ExecuteReader();
                if (lector.Read())
                {
                    codigoCurso = lector["codigo"].ToString();
                }
            }
            return codigoCurso;
        }

        //String para obtener el id del curso (idCurso), (enviado a la miniatura de cada UC)
        private string obtenerIDdelCurso(string id)
        {
            string idCurso = "";
            using (SqlConnection conexion = new SqlConnection($"server={Logins.ObtenerInstancia().nombreServidor}; database=GestorAcademico; integrated security=true"))
            {
                conexion.Open();
                string cadena = "SELECT fkCurso FROM usuario_x_curso WHERE fkCurso = @id";
                SqlCommand comando = new SqlCommand(cadena, conexion);
                comando.Parameters.AddWithValue("@id", id);
                SqlDataReader lector = comando.ExecuteReader();
                if (lector.Read())
                {
                    idCurso = lector["fkCurso"].ToString();
                }
            }
            return idCurso;
        }

        //String para obtener el nombre del curso (enviado a la miniatura de cada UC)
        private string obtenerNombredelCurso(string id)
        {

            string nombre = "";
            SqlConnection conexion = new SqlConnection($"server={Logins.ObtenerInstancia().nombreServidor}; database =GestorAcademico; integrated security = true");
            conexion.Open();
            string cadena = $"select * from curso where idCurso={id}";
            SqlCommand comando = new SqlCommand(cadena, conexion);
            SqlDataReader lector = comando.ExecuteReader();
            if (lector.Read())
            {
                nombre = lector["nombre"].ToString();
            }
            conexion.Close();

            return nombre;
        }

        //Evento que cierra el formulario (lo oculta, para dar la sensación de submenú)
        private void btnCerrar_Click(object sender, EventArgs e)
        {
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
    }
}
