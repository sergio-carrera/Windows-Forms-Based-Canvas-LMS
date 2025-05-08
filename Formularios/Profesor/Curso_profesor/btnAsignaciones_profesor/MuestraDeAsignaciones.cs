using Proyecto_GestionAcademica_Grupo05.Formularios.Estudiante.FormularioHijo1.Curso;
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

namespace Proyecto_GestionAcademica_Grupo05.Formularios.Profesor.Curso_profesor.btnAsignaciones
{
    public partial class MuestraDeAsignaciones : Form
    {
        public CursoInicioProf FormularioPadre { get; set; }

        public string idCred;
        public string idCurso;
        public string nombreCurso;

        public string noApto = "noApto";

        public string idGrupo;

        public MuestraDeAsignaciones(string idCred, string idCurso, string nombreCurso)
        {
            InitializeComponent();
            this.idCred = idCred;
            this.idCurso = idCurso;
            this.nombreCurso = nombreCurso;
            obtenerIDGrupo();
            editarDisenno();
            RellenarVistaAsigProx();
            RellenarVistaAsigProxGrup();
            RellenarVistaAsigPasa();
            RellenarVistaAsigPasaGrup();
        }

        public void editarDisenno()
        {
            subMenuAsigProx.Visible = true;
            subMenuAsigPasa.Visible = true;
        }

        //Método para obtener primer idGrupo dependiendo del curso para poder mostrar bien las asignaciones grupales
        public void obtenerIDGrupo()
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection($"server={Logins.ObtenerInstancia().nombreServidor}; database=GestorAcademico; integrated security=true"))
                {
                    conexion.Open();
                    string consulta = "select top 1 idGrupo from grupo WHERE fkCurso = @idCurso ORDER BY idGrupo";

                    using (SqlCommand comando = new SqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@idCurso", idCurso);
                        using (SqlDataReader lector = comando.ExecuteReader())
                        {
                            if (lector.HasRows)
                            {
                                lector.Read();
                                idGrupo = lector["idGrupo"]?.ToString() ?? "0";
                            }
                            else
                            {
                                idGrupo = "1500000";
                            }
                        }
                    }
                    conexion.Close();
                }

            }
            catch(Exception ex) 
            {
                MessageBox.Show("Error en el método 'obtenerIDGrupo': " + ex.ToString());
            }
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

                string consulta = @"SELECT ag.idAsignacion_x_Grupo, ag.fkAsignacion, ag.fkGrupo, ag.fkSemana, a.idAsignacion
                                    FROM Asignacion_x_Grupo AS ag
                                    JOIN Asignacion AS a ON ag.fkAsignacion = a.idAsignacion
                                    JOIN Usuario_x_Curso AS uxc ON a.fkCurso = uxc.fkCurso
                                    WHERE uxc.fkUsuario = @credencial AND a.fecha_limite >= GETDATE() AND fkGrupo = @idGrupo ORDER BY a.fecha_limite ASC;";

                using (SqlCommand command = new SqlCommand(consulta, conexion))
                {
                    command.Parameters.AddWithValue("@credencial", idCred);
                    command.Parameters.AddWithValue("@idGrupo", idGrupo);
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
                    command.Parameters.AddWithValue("@credencial", idCred);
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

                string consulta = @"SELECT ag.idAsignacion_x_Grupo, ag.fkAsignacion, ag.fkGrupo, ag.fkSemana, a.idAsignacion
                                    FROM Asignacion_x_Grupo AS ag
                                    JOIN Asignacion AS a ON ag.fkAsignacion = a.idAsignacion
                                    JOIN Usuario_x_Curso AS uxc ON a.fkCurso = uxc.fkCurso
                                    WHERE uxc.fkUsuario = @credencial AND a.fecha_limite < GETDATE() AND fkGrupo = @idGrupo ORDER BY a.fecha_limite ASC;";

                using (SqlCommand command = new SqlCommand(consulta, conexion))
                {
                    command.Parameters.AddWithValue("@credencial", idCred);
                    command.Parameters.AddWithValue("@idGrupo", idGrupo);
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

        private void btnCrearAsignacion_Click(object sender, EventArgs e)
        {
            // Cierra el formulario actual (MuestraDeAsignaciones)
            this.Close();

            // Crea una nueva instancia de CreacionDeAsignaciones
            CreacionDeAsignaciones creacionDeAsignaciones = new CreacionDeAsignaciones(idCred, idCurso, nombreCurso);

            // Asigna el formulario padre al formulario hijo
            creacionDeAsignaciones.FormularioPadre = FormularioPadre;

            // Abre el formulario hijo en el formulario padre
            FormularioPadre.AbrirFormHijo(creacionDeAsignaciones);
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
