using Proyecto_GestionAcademica_Grupo05.Formularios.Estudiante.FormularioHijo1.Curso.btnPersonas;
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

namespace Proyecto_GestionAcademica_Grupo05.Formularios.Profesor.Curso_profesor.btnAsistencia
{
    public partial class PasarAsistencia : Form
    {
        public string idCred;
        public string idCurso;
        public string idSemana;

        public PasarAsistencia(string idCred, string idCurso, string idSemana)
        {
            InitializeComponent();
            this.idCred = idCred;
            this.idCurso = idCurso;
            this.idSemana = idSemana;
            RellenarVista();
        }

        public void RellenarVista()
        {
            try
            {
                int cont = 0;
                SqlConnection con = new SqlConnection($"server={Logins.ObtenerInstancia().nombreServidor}; database =GestorAcademico; integrated security = true");
                con.Open();
                string cadena = @"SELECT uc.*
                                FROM Usuario_x_Curso uc
                                JOIN Usuario u ON uc.fkUsuario = u.idUsuario
                                JOIN Credencial c ON u.fkCredencial = c.idCredencial
                                WHERE uc.fkCurso = @idCurso AND c.fkCredencialTipo = 2
                                ORDER BY u.apellido1;";

                SqlCommand comando = new SqlCommand(cadena, con);
                comando.Parameters.AddWithValue("@idCurso", idCurso);
                SqlDataReader lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    cont++;
                    var miniatura = new UC_EstudianteAsistencia(lector["fkUsuario"].ToString(), idCurso, idSemana, obtenerNCompleto(lector["fkUsuario"] + ""));
                    panelListaAsistencia.Controls.Add(miniatura);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en el método 'RellenarVista': " + ex.ToString());
            }
        }

        private string obtenerNCompleto(string nombreC)
        {
            string nombreCompleto = "";
            using (SqlConnection conexion = new SqlConnection($"server={Logins.ObtenerInstancia().nombreServidor}; database=GestorAcademico; integrated security=true"))
            {
                conexion.Open();
                string cadena = @"SELECT CONCAT(nombre, ' ', apellido1) AS nCompleto
               FROM Usuario AS u
               JOIN Usuario_x_Curso AS uxc ON u.idUsuario = uxc.fkUsuario 
               WHERE idUsuario = @nombreC ORDER BY apellido1 ASC";

                SqlCommand comando = new SqlCommand(cadena, conexion);
                comando.Parameters.AddWithValue("@nombreC", nombreC);
                SqlDataReader lector = comando.ExecuteReader();
                if (lector.Read())
                {
                    nombreCompleto = lector["nCompleto"].ToString();
                }
            }
            return nombreCompleto;
        }
    }
}
