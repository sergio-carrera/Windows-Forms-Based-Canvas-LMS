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

namespace Proyecto_GestionAcademica_Grupo05.Formularios.Estudiante.FormularioHijo1.Curso.btnAsignaciones_estudiante
{
    public partial class MuestraDeAsignacionesEstudiante : Form
    {
        public string idCred;
        public string idCurso;

        public string nombreGrupo;

        public string noApto = "noApto";
        public MuestraDeAsignacionesEstudiante(string idCred, string idCurso)
        {
            InitializeComponent();
            this.idCred = idCred;
            this.idCurso = idCurso;
            editarDisenno();
            obtenerNombreGrupo();
            RellenarVistaAsigProx();
            RellenarVistaAsigProxGrup();
            RellenarVistaAsigPasa();
            RellenarVistaAsigPasaGrup();
        }

        public void obtenerNombreGrupo()
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection($"server={Logins.ObtenerInstancia().nombreServidor}; database =GestorAcademico; integrated security = true"))
                {
                    conexion.Open();

                    string consulta = @"SELECT g.nombreGrupo
                                        FROM Grupo g
                                        JOIN Usuario_x_Grupo uxg ON g.idGrupo = uxg.fkGrupo
                                        WHERE g.fkCurso = " + idCurso +
                                        "AND uxg.fkUsuario = " + idCred + ";";

                    using (SqlCommand command = new SqlCommand(consulta, conexion))
                    {
                        object result = command.ExecuteScalar();

                        if (result != null)
                        {
                            nombreGrupo = Convert.ToString(result);
                        }
                        else
                        {
                            nombreGrupo = "1500000";
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error en el método 'obtenerIDGrupo': " + ex.ToString()); ;
            }
        }

        //Método que sirve para inicializar todos los FlowLayoutPaneles en falso para dar la sensación de que están ocultos
        public void editarDisenno()
        {
            subMenuAsigProx.Visible = true;
            subMenuAsigPasa.Visible = true;
        }

        public void RellenarVistaAsigProx()
        {
            int contador = 0;

            using (SqlConnection conexion = new SqlConnection($"server={Logins.ObtenerInstancia().nombreServidor}; database =GestorAcademico; integrated security = true"))
            {
                conexion.Open();

                string consulta = @"SELECT uxc.fkCurso AS idCurso, uxc.fkUsuario AS idEstudiante, axe.fkSemana AS idSemana, a.idAsignacion
                            FROM Asignacion AS a
                            JOIN Usuario_x_Curso AS uxc ON a.fkCurso = uxc.fkCurso
                            JOIN Asignacion_x_Estudiante AS axe ON a.idAsignacion = axe.fkAsignacion AND uxc.fkUsuario = axe.fkUsuario
                            WHERE uxc.fkUsuario = " + idCred + " AND uxc.fkCurso = " + idCurso + "AND a.fecha_limite >= GETDATE() " +
                            "ORDER BY a.fecha_limite ASC;";

                using (SqlCommand command = new SqlCommand(consulta, conexion))
                {
                    using (SqlDataReader lector = command.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            contador++;
                            int idCurso = lector.GetInt32(lector.GetOrdinal("idCurso"));
                            int idEstudiante = lector.GetInt32(lector.GetOrdinal("idEstudiante"));
                            int idSemana = lector.GetInt32(lector.GetOrdinal("idSemana"));
                            int idAsignacion = lector.GetInt32(lector.GetOrdinal("idAsignacion"));

                            string idCurs = idCurso.ToString();
                            string idEstudiant = idEstudiante.ToString();
                            string idSeman = idSemana.ToString();
                            string idAsignaci = idAsignacion.ToString();

                            var miniatura = new UC_Asignacion(idCurs, idEstudiant, idSeman, idAsignaci, idCred, noApto, noApto);
                            subMenuAsigProx.Controls.Add(miniatura);
                        }
                    }
                }
            }
        }

        public void RellenarVistaAsigProxGrup()
        {
            int contador = 0;

            using (SqlConnection conexion = new SqlConnection($"server={Logins.ObtenerInstancia().nombreServidor}; database =GestorAcademico; integrated security = true"))
            {
                conexion.Open();

                string consulta = @"SELECT ag.idAsignacion_x_Grupo, ag.fkAsignacion, ag.fkGrupo, ag.fkSemana
                        FROM Asignacion_x_Grupo AS ag
                        JOIN Asignacion AS a ON ag.fkAsignacion = a.idAsignacion
                        WHERE ag.fkGrupo = (SELECT idGrupo FROM Grupo WHERE nombreGrupo = @nombreGrupo AND fkCurso = @idCurso) AND a.fecha_limite >= GETDATE() ORDER BY a.fecha_limite ASC;";

                using (SqlCommand command = new SqlCommand(consulta, conexion))
                {
                    command.Parameters.AddWithValue("@nombreGrupo", nombreGrupo);
                    command.Parameters.AddWithValue("@idCurso", idCurso);
                    using (SqlDataReader lector = command.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            contador++;
                            int idAsignacion_x_Grupo = lector.GetInt32(lector.GetOrdinal("idAsignacion_x_Grupo"));
                            int idAsignacion = lector.GetInt32(lector.GetOrdinal("fkAsignacion"));
                            int idGrupo = lector.GetInt32(lector.GetOrdinal("fkGrupo"));
                            int idSemana = lector.GetInt32(lector.GetOrdinal("fkSemana"));

                            string idAsignacion_x_Grup = idAsignacion_x_Grupo.ToString();
                            string idAsignacio = idAsignacion.ToString();
                            string idGrup = idGrupo.ToString();
                            string idSeman = idSemana.ToString();

                            var miniatura = new UC_Asignacion(idCurso, idCred, idSeman, idAsignacio, idCred, idAsignacion_x_Grup, idGrup);
                            subMenuAsigProx.Controls.Add(miniatura);
                        }
                    }
                }
            }
        }

        public void RellenarVistaAsigPasa()
        {
            int contador = 0;

            using (SqlConnection conexion = new SqlConnection($"server={Logins.ObtenerInstancia().nombreServidor}; database =GestorAcademico; integrated security = true"))
            {
                conexion.Open();

                string consulta = @"SELECT uxc.fkCurso AS idCurso, uxc.fkUsuario AS idEstudiante, axe.fkSemana AS idSemana, a.idAsignacion
                            FROM Asignacion AS a
                            JOIN Usuario_x_Curso AS uxc ON a.fkCurso = uxc.fkCurso
                            JOIN Asignacion_x_Estudiante AS axe ON a.idAsignacion = axe.fkAsignacion AND uxc.fkUsuario = axe.fkUsuario
                            WHERE uxc.fkUsuario = " + idCred + " AND uxc.fkCurso = " + idCurso + "AND a.fecha_limite < GETDATE() " +
                            "ORDER BY a.fecha_limite ASC;";

                using (SqlCommand command = new SqlCommand(consulta, conexion))
                {
                    using (SqlDataReader lector = command.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            contador++;
                            int idCurso = lector.GetInt32(lector.GetOrdinal("idCurso"));
                            int idEstudiante = lector.GetInt32(lector.GetOrdinal("idEstudiante"));
                            int idSemana = lector.GetInt32(lector.GetOrdinal("idSemana"));
                            int idAsignacion = lector.GetInt32(lector.GetOrdinal("idAsignacion"));

                            string idCurs = idCurso.ToString();
                            string idEstudiant = idEstudiante.ToString();
                            string idSeman = idSemana.ToString();
                            string idAsignaci = idAsignacion.ToString();

                            var miniatura = new UC_Asignacion(idCurs, idEstudiant, idSeman, idAsignaci, idCred, noApto, noApto);
                            subMenuAsigPasa.Controls.Add(miniatura);
                        }
                    }
                }
            }
        }

        public void RellenarVistaAsigPasaGrup()
        {
            int contador = 0;

            using (SqlConnection conexion = new SqlConnection($"server={Logins.ObtenerInstancia().nombreServidor}; database =GestorAcademico; integrated security = true"))
            {
                conexion.Open();

                string consulta = @"SELECT ag.idAsignacion_x_Grupo, ag.fkAsignacion, ag.fkGrupo, ag.fkSemana
                        FROM Asignacion_x_Grupo AS ag
                        JOIN Asignacion AS a ON ag.fkAsignacion = a.idAsignacion
                        WHERE ag.fkGrupo = (SELECT idGrupo FROM Grupo WHERE nombreGrupo = @nombreGrupo AND fkCurso = @idCurso) AND a.fecha_limite < GETDATE() ORDER BY a.fecha_limite ASC;";

                using (SqlCommand command = new SqlCommand(consulta, conexion))
                {
                    command.Parameters.AddWithValue("@nombreGrupo", nombreGrupo);
                    command.Parameters.AddWithValue("@idCurso", idCurso);
                    using (SqlDataReader lector = command.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            contador++;
                            int idAsignacion_x_Grupo = lector.GetInt32(lector.GetOrdinal("idAsignacion_x_Grupo"));
                            int idAsignacion = lector.GetInt32(lector.GetOrdinal("fkAsignacion"));
                            int idGrupo = lector.GetInt32(lector.GetOrdinal("fkGrupo"));
                            int idSemana = lector.GetInt32(lector.GetOrdinal("fkSemana"));

                            string idAsignacion_x_Grup = idAsignacion_x_Grupo.ToString();
                            string idAsignacio = idAsignacion.ToString();
                            string idGrup = idGrupo.ToString();
                            string idSeman = idSemana.ToString();

                            var miniatura = new UC_Asignacion(idCurso, idCred, idSeman, idAsignacio, idCred, idAsignacion_x_Grup, idGrup);
                            subMenuAsigPasa.Controls.Add(miniatura);
                        }
                    }
                }
            }
        }

        private void btnAsignacionesProximas_Click(object sender, EventArgs e)
        {
            foreach (Control control in subMenuAsigProx.Controls)
            {
                if (control is Panel && control != subMenuAsigProx)
                {
                    control.Visible = false;
                }
            }
            // Muestra u oculta el submenú actual
            subMenuAsigProx.Visible = !subMenuAsigProx.Visible;
        }

        private void btnAsignacionesPasadas_Click(object sender, EventArgs e)
        {
            foreach (Control control in subMenuAsigPasa.Controls)
            {
                if (control is Panel && control != subMenuAsigPasa)
                {
                    control.Visible = false;
                }
            }
            // Muestra u oculta el submenú actual
            subMenuAsigPasa.Visible = !subMenuAsigPasa.Visible;
        }
    }
}
