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

namespace Proyecto_GestionAcademica_Grupo05.Formularios.Profesor.Curso_profesor.btnCalificaciones_profesor
{
    public partial class MuestraDeCalificacionesProfesor : Form
    {
        public string idCred;
        public string idCurso;

        public string noApto = "noApto";

        public string idGrupo;

        public MuestraDeCalificacionesProfesor(string idCred, string idCurso)
        {
            InitializeComponent();
            this.idCred = idCred;
            this.idCurso = idCurso;
            obtenerIDGrupo();
            RellenarVistaAsigIndividuales();
            RellenarVistaAsigGrupales();
        }

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
            catch (Exception ex)
            {
                MessageBox.Show("Error en el método 'obtenerIDGrupo': " + ex.ToString());
            }
        }

        public void RellenarVistaAsigIndividuales()
        {
            try
            {
                int contador = 0;

                using (SqlConnection conexion = new SqlConnection($"server={Logins.ObtenerInstancia().nombreServidor}; database =GestorAcademico; integrated security = true"))
                {
                    conexion.Open();

                    string consulta = @"SELECT uxc.fkCurso AS idCurso, uxc.fkUsuario AS idEstudiante, axe.fkSemana AS idSemana, a.idAsignacion
                                    FROM Asignacion AS a
                                    JOIN Usuario_x_Curso AS uxc ON a.fkCurso = uxc.fkCurso
                                    JOIN Asignacion_x_Estudiante AS axe ON a.idAsignacion = axe.fkAsignacion AND uxc.fkUsuario = axe.fkUsuario
                                    WHERE uxc.fkUsuario = " + idCred + " AND uxc.fkCurso = " + idCurso + "ORDER BY a.fecha_limite ASC;";

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
                                subMenuAsig.Controls.Add(miniatura);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en el método 'RellenarVistaAsigIndividuales': " + ex.ToString());
            }
        }

        public void RellenarVistaAsigGrupales()
        {
            try
            {
                int contador = 0;

                using (SqlConnection conexion = new SqlConnection($"server={Logins.ObtenerInstancia().nombreServidor}; database =GestorAcademico; integrated security = true"))
                {
                    conexion.Open();

                    string consulta = @"SELECT ag.idAsignacion_x_Grupo, ag.fkAsignacion, ag.fkGrupo, ag.fkSemana, a.idAsignacion
                                    FROM Asignacion_x_Grupo AS ag
                                    JOIN Asignacion AS a ON ag.fkAsignacion = a.idAsignacion
                                    JOIN Usuario_x_Curso AS uxc ON a.fkCurso = uxc.fkCurso
                                    WHERE uxc.fkUsuario = @credencial AND fkGrupo = @idGrupo ORDER BY a.fecha_limite ASC;";

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
                                subMenuAsig.Controls.Add(miniatura);
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error en el método 'RellenarVistaAsigGrupales': " + ex.ToString());
            }
        }
    }
}
