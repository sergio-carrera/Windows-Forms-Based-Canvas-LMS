using Proyecto_GestionAcademica_Grupo05.Formularios.Profesor.Curso_profesor.btnAsignaciones;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_GestionAcademica_Grupo05.Formularios.Estudiante.FormularioHijo1.Curso.btnPersonas
{
    public partial class CursoGrupos : Form
    {
        public CursoPersonas FormularioPadre { get; set; }

        public string idCred;
        public string idCurso;
        public string idCredTipo;

        public CursoGrupos(string idCred, string idCurso, string idCredTipo)
        {
            InitializeComponent();
            this.idCred = idCred;
            this.idCurso = idCurso;
            this.idCredTipo = idCredTipo;
            RellenarVista();
            /*
            En caso de que el usuario sea estudiante, entonces no va a poder 
            crear un grupo
            */
            if (idCredTipo.ToString() == "1")
            {
                btnCrearGrupo.Visible = true;
            }
            else if (idCredTipo.ToString() == "2")
            {
                btnCrearGrupo.Visible = false;
            }

        }

        public void RellenarVista()
        {
            try
            {
                int cont = 0;
                SqlConnection con = new SqlConnection($"server={Logins.ObtenerInstancia().nombreServidor}; database =GestorAcademico; integrated security = true");
                con.Open();
                string cadena = @"SELECT * 
                                FROM Grupo
                                WHERE fkCurso = @idCurso;";

                SqlCommand comando = new SqlCommand(cadena, con);
                comando.Parameters.AddWithValue("@idCurso", idCurso);
                SqlDataReader lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    cont++;
                    string nombreGrupo = lector.GetString(lector.GetOrdinal("nombreGrupo"));
                    var miniatura = new UC_Grupo(idCred, idCurso, nombreGrupo);
                    panelGrupos.Controls.Add(miniatura);
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Error en el método 'RellenarVista': " + ex.ToString());
            }
        }

        private void btnCrearGrupo_Click(object sender, EventArgs e)
        {
            this.Close();
            CreacionDeGrupos creacionDeGrupos = new CreacionDeGrupos(idCred, idCurso);
            creacionDeGrupos.FormularioPadre = FormularioPadre;
            FormularioPadre.AbrirFormHijo(creacionDeGrupos);
        }
    }
}
