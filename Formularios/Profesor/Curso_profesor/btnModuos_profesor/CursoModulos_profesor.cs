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

namespace Proyecto_GestionAcademica_Grupo05.Formularios.Profesor.Curso_profesor
{
    public partial class CursoModulos_profesor : Form
    {
        public string idCred;
        public string idCurso;

        //Se usa para pasar un string que no sea apto para las asignaciones que no sean grupales
        public string noApto = "noApto";
        public CursoModulos_profesor(string idCred, string idCurso)
        {
            InitializeComponent();
            this.idCred = idCred;
            this.idCurso = idCurso;
            editarDisenno();
            RellenarVistas();
            btnColapsarExpandir.Visible = false;
        }

        private void editarDisenno()
        {
            subMenuSemana1.Visible = false;
            subMenuSemana2.Visible = false;
            subMenuSemana3.Visible = false;
            subMenuSemana4.Visible = false;
            subMenuSemana5.Visible = false;
            subMenuSemana6.Visible = false;
            subMenuSemana7.Visible = false;
            subMenuSemana8.Visible = false;
            subMenuSemana9.Visible = false;
            subMenuSemana10.Visible = false;
            subMenuSemana11.Visible = false;
            subMenuSemana12.Visible = false;
            subMenuSemana13.Visible = false;
            subMenuSemana14.Visible = false;
            subMenuSemana15.Visible = false;
        }

        private void RellenarVistas()
        {
            RellenarVista1();
            RellenarVista1_grupo();
            RellenarVista2();
            RellenarVista2_grupo();
            RellenarVista3();
            RellenarVista3_grupo();
            RellenarVista4();
            RellenarVista4_grupo();
            RellenarVista5();
            RellenarVista5_grupo();
            RellenarVista6();
            RellenarVista6_grupo();
            RellenarVista7();
            RellenarVista7_grupo();
            RellenarVista8();
            RellenarVista8_grupo();
            RellenarVista9();
            RellenarVista9_grupo();
            RellenarVista10();
            RellenarVista10_grupo();
            RellenarVista11();
            RellenarVista11_grupo();
            RellenarVista12();
            RellenarVista12_grupo();
            RellenarVista13();
            RellenarVista13_grupo();
            RellenarVista14();
            RellenarVista14_grupo();
            RellenarVista15();
            RellenarVista15_grupo();
        }

        private void RellenarVista1()
        {
            int contador = 0;

            using (SqlConnection conexion = new SqlConnection($"server={Logins.ObtenerInstancia().nombreServidor}; database =GestorAcademico; integrated security = true"))
            {
                conexion.Open();

                string consulta = @"SELECT uxc.fkCurso AS idCurso, uxc.fkUsuario AS idEstudiante, axe.fkSemana AS idSemana, a.idAsignacion
                            FROM Asignacion AS a
                            JOIN Usuario_x_Curso AS uxc ON a.fkCurso = uxc.fkCurso
                            JOIN Asignacion_x_Estudiante AS axe ON a.idAsignacion = axe.fkAsignacion AND uxc.fkUsuario = axe.fkUsuario
                            WHERE uxc.fkUsuario = " + idCred + " AND axe.fkSemana = 1 AND uxc.fkCurso = " + idCurso +
                            " ORDER BY uxc.fkCurso, uxc.fkUsuario, axe.fkSemana, a.idAsignacion;";

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
                            subMenuSemana1.Controls.Add(miniatura);
                        }
                    }
                }
            }
        }

        private void RellenarVista1_grupo()
        {
            int contador = 0;

            using (SqlConnection conexion = new SqlConnection($"server={Logins.ObtenerInstancia().nombreServidor}; database =GestorAcademico; integrated security = true"))
            {
                conexion.Open();

                string consulta = @"SELECT ag.idAsignacion_x_Grupo, ag.fkAsignacion, ag.fkGrupo, ag.fkSemana, a.idAsignacion
                                    FROM Asignacion_x_Grupo AS ag
                                    JOIN Asignacion AS a ON ag.fkAsignacion = a.idAsignacion
                                    JOIN (
                                        SELECT a.idAsignacion, MIN(ag.idAsignacion_x_Grupo) AS min_id
                                        FROM Asignacion_x_Grupo AS ag
                                        JOIN Asignacion AS a ON ag.fkAsignacion = a.idAsignacion
                                        JOIN Usuario_x_Curso AS uxc ON a.fkCurso = uxc.fkCurso
                                        WHERE uxc.fkUsuario = @credencial AND ag.fkSemana = 1
                                        GROUP BY a.idAsignacion
                                    ) AS unique_assignments ON ag.idAsignacion_x_Grupo = unique_assignments.min_id;";

                using (SqlCommand command = new SqlCommand(consulta, conexion))
                {
                    command.Parameters.AddWithValue("@credencial", idCred);
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
                            subMenuSemana1.Controls.Add(miniatura);
                        }
                    }
                }
            }
        }

        private void RellenarVista2()
        {
            int contador = 0;

            using (SqlConnection conexion = new SqlConnection($"server={Logins.ObtenerInstancia().nombreServidor}; database =GestorAcademico; integrated security = true"))
            {
                conexion.Open();

                string consulta = @"SELECT uxc.fkCurso AS idCurso, uxc.fkUsuario AS idEstudiante, axe.fkSemana AS idSemana, a.idAsignacion
                            FROM Asignacion AS a
                            JOIN Usuario_x_Curso AS uxc ON a.fkCurso = uxc.fkCurso
                            JOIN Asignacion_x_Estudiante AS axe ON a.idAsignacion = axe.fkAsignacion AND uxc.fkUsuario = axe.fkUsuario
                            WHERE uxc.fkUsuario = " + idCred + " AND axe.fkSemana = 2 AND uxc.fkCurso = " + idCurso +
                            " ORDER BY uxc.fkCurso, uxc.fkUsuario, axe.fkSemana, a.idAsignacion;";

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
                            subMenuSemana2.Controls.Add(miniatura);
                        }
                    }
                }
            }
        }

        private void RellenarVista2_grupo()
        {
            int contador = 0;

            using (SqlConnection conexion = new SqlConnection($"server={Logins.ObtenerInstancia().nombreServidor}; database =GestorAcademico; integrated security = true"))
            {
                conexion.Open();

                string consulta = @"SELECT ag.idAsignacion_x_Grupo, ag.fkAsignacion, ag.fkGrupo, ag.fkSemana, a.idAsignacion
                                    FROM Asignacion_x_Grupo AS ag
                                    JOIN Asignacion AS a ON ag.fkAsignacion = a.idAsignacion
                                    JOIN (
                                        SELECT a.idAsignacion, MIN(ag.idAsignacion_x_Grupo) AS min_id
                                        FROM Asignacion_x_Grupo AS ag
                                        JOIN Asignacion AS a ON ag.fkAsignacion = a.idAsignacion
                                        JOIN Usuario_x_Curso AS uxc ON a.fkCurso = uxc.fkCurso
                                        WHERE uxc.fkUsuario = @credencial AND ag.fkSemana = 2
                                        GROUP BY a.idAsignacion
                                    ) AS unique_assignments ON ag.idAsignacion_x_Grupo = unique_assignments.min_id;";

                using (SqlCommand command = new SqlCommand(consulta, conexion))
                {
                    command.Parameters.AddWithValue("@credencial", idCred);
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
                            subMenuSemana2.Controls.Add(miniatura);
                        }
                    }
                }
            }
        }

        private void RellenarVista3()
        {
            int contador = 0;

            using (SqlConnection conexion = new SqlConnection($"server={Logins.ObtenerInstancia().nombreServidor}; database =GestorAcademico; integrated security = true"))
            {
                conexion.Open();

                string consulta = @"SELECT uxc.fkCurso AS idCurso, uxc.fkUsuario AS idEstudiante, axe.fkSemana AS idSemana, a.idAsignacion
                            FROM Asignacion AS a
                            JOIN Usuario_x_Curso AS uxc ON a.fkCurso = uxc.fkCurso
                            JOIN Asignacion_x_Estudiante AS axe ON a.idAsignacion = axe.fkAsignacion AND uxc.fkUsuario = axe.fkUsuario
                            WHERE uxc.fkUsuario = " + idCred + " AND axe.fkSemana = 3 AND uxc.fkCurso = " + idCurso +
                            " ORDER BY uxc.fkCurso, uxc.fkUsuario, axe.fkSemana, a.idAsignacion;";

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
                            subMenuSemana3.Controls.Add(miniatura);
                        }
                    }
                }
            }
        }

        private void RellenarVista3_grupo()
        {
            int contador = 0;

            using (SqlConnection conexion = new SqlConnection($"server={Logins.ObtenerInstancia().nombreServidor}; database =GestorAcademico; integrated security = true"))
            {
                conexion.Open();

                string consulta = @"SELECT ag.idAsignacion_x_Grupo, ag.fkAsignacion, ag.fkGrupo, ag.fkSemana, a.idAsignacion
                                    FROM Asignacion_x_Grupo AS ag
                                    JOIN Asignacion AS a ON ag.fkAsignacion = a.idAsignacion
                                    JOIN (
                                        SELECT a.idAsignacion, MIN(ag.idAsignacion_x_Grupo) AS min_id
                                        FROM Asignacion_x_Grupo AS ag
                                        JOIN Asignacion AS a ON ag.fkAsignacion = a.idAsignacion
                                        JOIN Usuario_x_Curso AS uxc ON a.fkCurso = uxc.fkCurso
                                        WHERE uxc.fkUsuario = @credencial AND ag.fkSemana = 3
                                        GROUP BY a.idAsignacion
                                    ) AS unique_assignments ON ag.idAsignacion_x_Grupo = unique_assignments.min_id;";

                using (SqlCommand command = new SqlCommand(consulta, conexion))
                {
                    command.Parameters.AddWithValue("@credencial", idCred);
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
                            subMenuSemana3.Controls.Add(miniatura);
                        }
                    }
                }
            }
        }

        private void RellenarVista4()
        {
            int contador = 0;

            using (SqlConnection conexion = new SqlConnection($"server={Logins.ObtenerInstancia().nombreServidor}; database =GestorAcademico; integrated security = true"))
            {
                conexion.Open();

                string consulta = @"SELECT uxc.fkCurso AS idCurso, uxc.fkUsuario AS idEstudiante, axe.fkSemana AS idSemana, a.idAsignacion
                            FROM Asignacion AS a
                            JOIN Usuario_x_Curso AS uxc ON a.fkCurso = uxc.fkCurso
                            JOIN Asignacion_x_Estudiante AS axe ON a.idAsignacion = axe.fkAsignacion AND uxc.fkUsuario = axe.fkUsuario
                            WHERE uxc.fkUsuario = " + idCred + " AND axe.fkSemana = 4 AND uxc.fkCurso = " + idCurso +
                            " ORDER BY uxc.fkCurso, uxc.fkUsuario, axe.fkSemana, a.idAsignacion;";

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
                            subMenuSemana4.Controls.Add(miniatura);
                        }
                    }
                }
            }
        }

        private void RellenarVista4_grupo()
        {
            int contador = 0;

            using (SqlConnection conexion = new SqlConnection($"server={Logins.ObtenerInstancia().nombreServidor}; database =GestorAcademico; integrated security = true"))
            {
                conexion.Open();

                string consulta = @"SELECT ag.idAsignacion_x_Grupo, ag.fkAsignacion, ag.fkGrupo, ag.fkSemana, a.idAsignacion
                                    FROM Asignacion_x_Grupo AS ag
                                    JOIN Asignacion AS a ON ag.fkAsignacion = a.idAsignacion
                                    JOIN (
                                        SELECT a.idAsignacion, MIN(ag.idAsignacion_x_Grupo) AS min_id
                                        FROM Asignacion_x_Grupo AS ag
                                        JOIN Asignacion AS a ON ag.fkAsignacion = a.idAsignacion
                                        JOIN Usuario_x_Curso AS uxc ON a.fkCurso = uxc.fkCurso
                                        WHERE uxc.fkUsuario = @credencial AND ag.fkSemana = 4
                                        GROUP BY a.idAsignacion
                                    ) AS unique_assignments ON ag.idAsignacion_x_Grupo = unique_assignments.min_id;";

                using (SqlCommand command = new SqlCommand(consulta, conexion))
                {
                    command.Parameters.AddWithValue("@credencial", idCred);
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
                            subMenuSemana4.Controls.Add(miniatura);
                        }
                    }
                }
            }
        }

        private void RellenarVista5()
        {
            int contador = 0;

            using (SqlConnection conexion = new SqlConnection($"server={Logins.ObtenerInstancia().nombreServidor}; database =GestorAcademico; integrated security = true"))
            {
                conexion.Open();

                string consulta = @"SELECT uxc.fkCurso AS idCurso, uxc.fkUsuario AS idEstudiante, axe.fkSemana AS idSemana, a.idAsignacion
                            FROM Asignacion AS a
                            JOIN Usuario_x_Curso AS uxc ON a.fkCurso = uxc.fkCurso
                            JOIN Asignacion_x_Estudiante AS axe ON a.idAsignacion = axe.fkAsignacion AND uxc.fkUsuario = axe.fkUsuario
                            WHERE uxc.fkUsuario = " + idCred + " AND axe.fkSemana = 5 AND uxc.fkCurso = " + idCurso +
                            " ORDER BY uxc.fkCurso, uxc.fkUsuario, axe.fkSemana, a.idAsignacion;";

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
                            subMenuSemana5.Controls.Add(miniatura);
                        }
                    }
                }
            }
        }

        private void RellenarVista5_grupo()
        {
            int contador = 0;

            using (SqlConnection conexion = new SqlConnection($"server={Logins.ObtenerInstancia().nombreServidor}; database =GestorAcademico; integrated security = true"))
            {
                conexion.Open();

                string consulta = @"SELECT ag.idAsignacion_x_Grupo, ag.fkAsignacion, ag.fkGrupo, ag.fkSemana, a.idAsignacion
                                    FROM Asignacion_x_Grupo AS ag
                                    JOIN Asignacion AS a ON ag.fkAsignacion = a.idAsignacion
                                    JOIN (
                                        SELECT a.idAsignacion, MIN(ag.idAsignacion_x_Grupo) AS min_id
                                        FROM Asignacion_x_Grupo AS ag
                                        JOIN Asignacion AS a ON ag.fkAsignacion = a.idAsignacion
                                        JOIN Usuario_x_Curso AS uxc ON a.fkCurso = uxc.fkCurso
                                        WHERE uxc.fkUsuario = @credencial AND ag.fkSemana = 5
                                        GROUP BY a.idAsignacion
                                    ) AS unique_assignments ON ag.idAsignacion_x_Grupo = unique_assignments.min_id;";

                using (SqlCommand command = new SqlCommand(consulta, conexion))
                {
                    command.Parameters.AddWithValue("@credencial", idCred);
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
                            subMenuSemana5.Controls.Add(miniatura);
                        }
                    }
                }
            }
        }

        private void RellenarVista6()
        {
            int contador = 0;

            using (SqlConnection conexion = new SqlConnection($"server={Logins.ObtenerInstancia().nombreServidor}; database =GestorAcademico; integrated security = true"))
            {
                conexion.Open();

                string consulta = @"SELECT uxc.fkCurso AS idCurso, uxc.fkUsuario AS idEstudiante, axe.fkSemana AS idSemana, a.idAsignacion
                            FROM Asignacion AS a
                            JOIN Usuario_x_Curso AS uxc ON a.fkCurso = uxc.fkCurso
                            JOIN Asignacion_x_Estudiante AS axe ON a.idAsignacion = axe.fkAsignacion AND uxc.fkUsuario = axe.fkUsuario
                            WHERE uxc.fkUsuario = " + idCred + " AND axe.fkSemana = 6 AND uxc.fkCurso = " + idCurso +
                            " ORDER BY uxc.fkCurso, uxc.fkUsuario, axe.fkSemana, a.idAsignacion;";

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
                            subMenuSemana6.Controls.Add(miniatura);
                        }
                    }
                }
            }
        }

        private void RellenarVista6_grupo()
        {
            int contador = 0;

            using (SqlConnection conexion = new SqlConnection($"server={Logins.ObtenerInstancia().nombreServidor}; database =GestorAcademico; integrated security = true"))
            {
                conexion.Open();

                string consulta = @"SELECT ag.idAsignacion_x_Grupo, ag.fkAsignacion, ag.fkGrupo, ag.fkSemana, a.idAsignacion
                                    FROM Asignacion_x_Grupo AS ag
                                    JOIN Asignacion AS a ON ag.fkAsignacion = a.idAsignacion
                                    JOIN (
                                        SELECT a.idAsignacion, MIN(ag.idAsignacion_x_Grupo) AS min_id
                                        FROM Asignacion_x_Grupo AS ag
                                        JOIN Asignacion AS a ON ag.fkAsignacion = a.idAsignacion
                                        JOIN Usuario_x_Curso AS uxc ON a.fkCurso = uxc.fkCurso
                                        WHERE uxc.fkUsuario = @credencial AND ag.fkSemana = 6
                                        GROUP BY a.idAsignacion
                                    ) AS unique_assignments ON ag.idAsignacion_x_Grupo = unique_assignments.min_id;";

                using (SqlCommand command = new SqlCommand(consulta, conexion))
                {
                    command.Parameters.AddWithValue("@credencial", idCred);
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
                            subMenuSemana6.Controls.Add(miniatura);
                        }
                    }
                }
            }
        }

        private void RellenarVista7()
        {
            int contador = 0;

            using (SqlConnection conexion = new SqlConnection($"server={Logins.ObtenerInstancia().nombreServidor}; database =GestorAcademico; integrated security = true"))
            {
                conexion.Open();

                string consulta = @"SELECT uxc.fkCurso AS idCurso, uxc.fkUsuario AS idEstudiante, axe.fkSemana AS idSemana, a.idAsignacion
                            FROM Asignacion AS a
                            JOIN Usuario_x_Curso AS uxc ON a.fkCurso = uxc.fkCurso
                            JOIN Asignacion_x_Estudiante AS axe ON a.idAsignacion = axe.fkAsignacion AND uxc.fkUsuario = axe.fkUsuario
                            WHERE uxc.fkUsuario = " + idCred + " AND axe.fkSemana = 7 AND uxc.fkCurso = " + idCurso +
                            " ORDER BY uxc.fkCurso, uxc.fkUsuario, axe.fkSemana, a.idAsignacion;";

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
                            subMenuSemana7.Controls.Add(miniatura);
                        }
                    }
                }
            }
        }

        private void RellenarVista7_grupo()
        {
            int contador = 0;

            using (SqlConnection conexion = new SqlConnection($"server={Logins.ObtenerInstancia().nombreServidor}; database =GestorAcademico; integrated security = true"))
            {
                conexion.Open();

                string consulta = @"SELECT ag.idAsignacion_x_Grupo, ag.fkAsignacion, ag.fkGrupo, ag.fkSemana, a.idAsignacion
                                    FROM Asignacion_x_Grupo AS ag
                                    JOIN Asignacion AS a ON ag.fkAsignacion = a.idAsignacion
                                    JOIN (
                                        SELECT a.idAsignacion, MIN(ag.idAsignacion_x_Grupo) AS min_id
                                        FROM Asignacion_x_Grupo AS ag
                                        JOIN Asignacion AS a ON ag.fkAsignacion = a.idAsignacion
                                        JOIN Usuario_x_Curso AS uxc ON a.fkCurso = uxc.fkCurso
                                        WHERE uxc.fkUsuario = @credencial AND ag.fkSemana = 7
                                        GROUP BY a.idAsignacion
                                    ) AS unique_assignments ON ag.idAsignacion_x_Grupo = unique_assignments.min_id;";

                using (SqlCommand command = new SqlCommand(consulta, conexion))
                {
                    command.Parameters.AddWithValue("@credencial", idCred);
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
                            subMenuSemana7.Controls.Add(miniatura);
                        }
                    }
                }
            }
        }

        private void RellenarVista8()
        {
            int contador = 0;

            using (SqlConnection conexion = new SqlConnection($"server={Logins.ObtenerInstancia().nombreServidor}; database =GestorAcademico; integrated security = true"))
            {
                conexion.Open();

                string consulta = @"SELECT uxc.fkCurso AS idCurso, uxc.fkUsuario AS idEstudiante, axe.fkSemana AS idSemana, a.idAsignacion
                            FROM Asignacion AS a
                            JOIN Usuario_x_Curso AS uxc ON a.fkCurso = uxc.fkCurso
                            JOIN Asignacion_x_Estudiante AS axe ON a.idAsignacion = axe.fkAsignacion AND uxc.fkUsuario = axe.fkUsuario
                            WHERE uxc.fkUsuario = " + idCred + " AND axe.fkSemana = 8 AND uxc.fkCurso = " + idCurso +
                            " ORDER BY uxc.fkCurso, uxc.fkUsuario, axe.fkSemana, a.idAsignacion;";

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
                            subMenuSemana8.Controls.Add(miniatura);
                        }
                    }
                }
            }
        }

        private void RellenarVista8_grupo()
        {
            int contador = 0;

            using (SqlConnection conexion = new SqlConnection($"server={Logins.ObtenerInstancia().nombreServidor}; database =GestorAcademico; integrated security = true"))
            {
                conexion.Open();

                string consulta = @"SELECT ag.idAsignacion_x_Grupo, ag.fkAsignacion, ag.fkGrupo, ag.fkSemana, a.idAsignacion
                                    FROM Asignacion_x_Grupo AS ag
                                    JOIN Asignacion AS a ON ag.fkAsignacion = a.idAsignacion
                                    JOIN (
                                        SELECT a.idAsignacion, MIN(ag.idAsignacion_x_Grupo) AS min_id
                                        FROM Asignacion_x_Grupo AS ag
                                        JOIN Asignacion AS a ON ag.fkAsignacion = a.idAsignacion
                                        JOIN Usuario_x_Curso AS uxc ON a.fkCurso = uxc.fkCurso
                                        WHERE uxc.fkUsuario = @credencial AND ag.fkSemana = 8
                                        GROUP BY a.idAsignacion
                                    ) AS unique_assignments ON ag.idAsignacion_x_Grupo = unique_assignments.min_id;";

                using (SqlCommand command = new SqlCommand(consulta, conexion))
                {
                    command.Parameters.AddWithValue("@credencial", idCred);
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
                            subMenuSemana8.Controls.Add(miniatura);
                        }
                    }
                }
            }
        }

        private void RellenarVista9()
        {
            int contador = 0;

            using (SqlConnection conexion = new SqlConnection($"server={Logins.ObtenerInstancia().nombreServidor}; database =GestorAcademico; integrated security = true"))
            {
                conexion.Open();

                string consulta = @"SELECT uxc.fkCurso AS idCurso, uxc.fkUsuario AS idEstudiante, axe.fkSemana AS idSemana, a.idAsignacion
                            FROM Asignacion AS a
                            JOIN Usuario_x_Curso AS uxc ON a.fkCurso = uxc.fkCurso
                            JOIN Asignacion_x_Estudiante AS axe ON a.idAsignacion = axe.fkAsignacion AND uxc.fkUsuario = axe.fkUsuario
                            WHERE uxc.fkUsuario = " + idCred + " AND axe.fkSemana = 9 AND uxc.fkCurso = " + idCurso +
                            " ORDER BY uxc.fkCurso, uxc.fkUsuario, axe.fkSemana, a.idAsignacion;";

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
                            subMenuSemana9.Controls.Add(miniatura);
                        }
                    }
                }
            }
        }

        private void RellenarVista9_grupo()
        {
            int contador = 0;

            using (SqlConnection conexion = new SqlConnection($"server={Logins.ObtenerInstancia().nombreServidor}; database =GestorAcademico; integrated security = true"))
            {
                conexion.Open();

                string consulta = @"SELECT ag.idAsignacion_x_Grupo, ag.fkAsignacion, ag.fkGrupo, ag.fkSemana, a.idAsignacion
                                    FROM Asignacion_x_Grupo AS ag
                                    JOIN Asignacion AS a ON ag.fkAsignacion = a.idAsignacion
                                    JOIN (
                                        SELECT a.idAsignacion, MIN(ag.idAsignacion_x_Grupo) AS min_id
                                        FROM Asignacion_x_Grupo AS ag
                                        JOIN Asignacion AS a ON ag.fkAsignacion = a.idAsignacion
                                        JOIN Usuario_x_Curso AS uxc ON a.fkCurso = uxc.fkCurso
                                        WHERE uxc.fkUsuario = @credencial AND ag.fkSemana = 9
                                        GROUP BY a.idAsignacion
                                    ) AS unique_assignments ON ag.idAsignacion_x_Grupo = unique_assignments.min_id;";

                using (SqlCommand command = new SqlCommand(consulta, conexion))
                {
                    command.Parameters.AddWithValue("@credencial", idCred);
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
                            subMenuSemana9.Controls.Add(miniatura);
                        }
                    }
                }
            }
        }

        private void RellenarVista10()
        {
            int contador = 0;

            using (SqlConnection conexion = new SqlConnection($"server={Logins.ObtenerInstancia().nombreServidor}; database =GestorAcademico; integrated security = true"))
            {
                conexion.Open();

                string consulta = @"SELECT uxc.fkCurso AS idCurso, uxc.fkUsuario AS idEstudiante, axe.fkSemana AS idSemana, a.idAsignacion
                            FROM Asignacion AS a
                            JOIN Usuario_x_Curso AS uxc ON a.fkCurso = uxc.fkCurso
                            JOIN Asignacion_x_Estudiante AS axe ON a.idAsignacion = axe.fkAsignacion AND uxc.fkUsuario = axe.fkUsuario
                            WHERE uxc.fkUsuario = " + idCred + " AND axe.fkSemana = 10 AND uxc.fkCurso = " + idCurso +
                            " ORDER BY uxc.fkCurso, uxc.fkUsuario, axe.fkSemana, a.idAsignacion;";

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
                            subMenuSemana10.Controls.Add(miniatura);
                        }
                    }
                }
            }
        }

        private void RellenarVista10_grupo()
        {
            int contador = 0;

            using (SqlConnection conexion = new SqlConnection($"server={Logins.ObtenerInstancia().nombreServidor}; database =GestorAcademico; integrated security = true"))
            {
                conexion.Open();

                string consulta = @"SELECT ag.idAsignacion_x_Grupo, ag.fkAsignacion, ag.fkGrupo, ag.fkSemana, a.idAsignacion
                                    FROM Asignacion_x_Grupo AS ag
                                    JOIN Asignacion AS a ON ag.fkAsignacion = a.idAsignacion
                                    JOIN (
                                        SELECT a.idAsignacion, MIN(ag.idAsignacion_x_Grupo) AS min_id
                                        FROM Asignacion_x_Grupo AS ag
                                        JOIN Asignacion AS a ON ag.fkAsignacion = a.idAsignacion
                                        JOIN Usuario_x_Curso AS uxc ON a.fkCurso = uxc.fkCurso
                                        WHERE uxc.fkUsuario = @credencial AND ag.fkSemana = 10
                                        GROUP BY a.idAsignacion
                                    ) AS unique_assignments ON ag.idAsignacion_x_Grupo = unique_assignments.min_id;";

                using (SqlCommand command = new SqlCommand(consulta, conexion))
                {
                    command.Parameters.AddWithValue("@credencial", idCred);
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
                            subMenuSemana10.Controls.Add(miniatura);
                        }
                    }
                }
            }
        }

        private void RellenarVista11()
        {
            int contador = 0;

            using (SqlConnection conexion = new SqlConnection($"server={Logins.ObtenerInstancia().nombreServidor}; database =GestorAcademico; integrated security = true"))
            {
                conexion.Open();

                string consulta = @"SELECT uxc.fkCurso AS idCurso, uxc.fkUsuario AS idEstudiante, axe.fkSemana AS idSemana, a.idAsignacion
                            FROM Asignacion AS a
                            JOIN Usuario_x_Curso AS uxc ON a.fkCurso = uxc.fkCurso
                            JOIN Asignacion_x_Estudiante AS axe ON a.idAsignacion = axe.fkAsignacion AND uxc.fkUsuario = axe.fkUsuario
                            WHERE uxc.fkUsuario = " + idCred + " AND axe.fkSemana = 11 AND uxc.fkCurso = " + idCurso +
                            " ORDER BY uxc.fkCurso, uxc.fkUsuario, axe.fkSemana, a.idAsignacion;";

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
                            subMenuSemana11.Controls.Add(miniatura);
                        }
                    }
                }
            }
        }

        private void RellenarVista11_grupo()
        {
            int contador = 0;

            using (SqlConnection conexion = new SqlConnection($"server={Logins.ObtenerInstancia().nombreServidor}; database =GestorAcademico; integrated security = true"))
            {
                conexion.Open();

                string consulta = @"SELECT ag.idAsignacion_x_Grupo, ag.fkAsignacion, ag.fkGrupo, ag.fkSemana, a.idAsignacion
                                    FROM Asignacion_x_Grupo AS ag
                                    JOIN Asignacion AS a ON ag.fkAsignacion = a.idAsignacion
                                    JOIN (
                                        SELECT a.idAsignacion, MIN(ag.idAsignacion_x_Grupo) AS min_id
                                        FROM Asignacion_x_Grupo AS ag
                                        JOIN Asignacion AS a ON ag.fkAsignacion = a.idAsignacion
                                        JOIN Usuario_x_Curso AS uxc ON a.fkCurso = uxc.fkCurso
                                        WHERE uxc.fkUsuario = @credencial AND ag.fkSemana = 11
                                        GROUP BY a.idAsignacion
                                    ) AS unique_assignments ON ag.idAsignacion_x_Grupo = unique_assignments.min_id;";

                using (SqlCommand command = new SqlCommand(consulta, conexion))
                {
                    command.Parameters.AddWithValue("@credencial", idCred);
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
                            subMenuSemana11.Controls.Add(miniatura);
                        }
                    }
                }
            }
        }

        private void RellenarVista12()
        {
            int contador = 0;

            using (SqlConnection conexion = new SqlConnection($"server={Logins.ObtenerInstancia().nombreServidor}; database =GestorAcademico; integrated security = true"))
            {
                conexion.Open();

                string consulta = @"SELECT uxc.fkCurso AS idCurso, uxc.fkUsuario AS idEstudiante, axe.fkSemana AS idSemana, a.idAsignacion
                            FROM Asignacion AS a
                            JOIN Usuario_x_Curso AS uxc ON a.fkCurso = uxc.fkCurso
                            JOIN Asignacion_x_Estudiante AS axe ON a.idAsignacion = axe.fkAsignacion AND uxc.fkUsuario = axe.fkUsuario
                            WHERE uxc.fkUsuario = " + idCred + " AND axe.fkSemana = 12 AND uxc.fkCurso = " + idCurso +
                            " ORDER BY uxc.fkCurso, uxc.fkUsuario, axe.fkSemana, a.idAsignacion;";

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
                            subMenuSemana12.Controls.Add(miniatura);
                        }
                    }
                }
            }
        }

        private void RellenarVista12_grupo()
        {
            int contador = 0;

            using (SqlConnection conexion = new SqlConnection($"server={Logins.ObtenerInstancia().nombreServidor}; database =GestorAcademico; integrated security = true"))
            {
                conexion.Open();

                string consulta = @"SELECT ag.idAsignacion_x_Grupo, ag.fkAsignacion, ag.fkGrupo, ag.fkSemana, a.idAsignacion
                                    FROM Asignacion_x_Grupo AS ag
                                    JOIN Asignacion AS a ON ag.fkAsignacion = a.idAsignacion
                                    JOIN (
                                        SELECT a.idAsignacion, MIN(ag.idAsignacion_x_Grupo) AS min_id
                                        FROM Asignacion_x_Grupo AS ag
                                        JOIN Asignacion AS a ON ag.fkAsignacion = a.idAsignacion
                                        JOIN Usuario_x_Curso AS uxc ON a.fkCurso = uxc.fkCurso
                                        WHERE uxc.fkUsuario = @credencial AND ag.fkSemana = 12
                                        GROUP BY a.idAsignacion
                                    ) AS unique_assignments ON ag.idAsignacion_x_Grupo = unique_assignments.min_id;";

                using (SqlCommand command = new SqlCommand(consulta, conexion))
                {
                    command.Parameters.AddWithValue("@credencial", idCred);
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
                            subMenuSemana12.Controls.Add(miniatura);
                        }
                    }
                }
            }
        }

        private void RellenarVista13()
        {
            int contador = 0;

            using (SqlConnection conexion = new SqlConnection($"server={Logins.ObtenerInstancia().nombreServidor}; database =GestorAcademico; integrated security = true"))
            {
                conexion.Open();

                string consulta = @"SELECT uxc.fkCurso AS idCurso, uxc.fkUsuario AS idEstudiante, axe.fkSemana AS idSemana, a.idAsignacion
                            FROM Asignacion AS a
                            JOIN Usuario_x_Curso AS uxc ON a.fkCurso = uxc.fkCurso
                            JOIN Asignacion_x_Estudiante AS axe ON a.idAsignacion = axe.fkAsignacion AND uxc.fkUsuario = axe.fkUsuario
                            WHERE uxc.fkUsuario = " + idCred + " AND axe.fkSemana = 13 AND uxc.fkCurso = " + idCurso +
                            " ORDER BY uxc.fkCurso, uxc.fkUsuario, axe.fkSemana, a.idAsignacion;";

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
                            subMenuSemana13.Controls.Add(miniatura);
                        }
                    }
                }
            }
        }

        private void RellenarVista13_grupo()
        {
            int contador = 0;

            using (SqlConnection conexion = new SqlConnection($"server={Logins.ObtenerInstancia().nombreServidor}; database =GestorAcademico; integrated security = true"))
            {
                conexion.Open();

                string consulta = @"SELECT ag.idAsignacion_x_Grupo, ag.fkAsignacion, ag.fkGrupo, ag.fkSemana, a.idAsignacion
                                    FROM Asignacion_x_Grupo AS ag
                                    JOIN Asignacion AS a ON ag.fkAsignacion = a.idAsignacion
                                    JOIN (
                                        SELECT a.idAsignacion, MIN(ag.idAsignacion_x_Grupo) AS min_id
                                        FROM Asignacion_x_Grupo AS ag
                                        JOIN Asignacion AS a ON ag.fkAsignacion = a.idAsignacion
                                        JOIN Usuario_x_Curso AS uxc ON a.fkCurso = uxc.fkCurso
                                        WHERE uxc.fkUsuario = @credencial AND ag.fkSemana = 13
                                        GROUP BY a.idAsignacion
                                    ) AS unique_assignments ON ag.idAsignacion_x_Grupo = unique_assignments.min_id;";

                using (SqlCommand command = new SqlCommand(consulta, conexion))
                {
                    command.Parameters.AddWithValue("@credencial", idCred);
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
                            subMenuSemana13.Controls.Add(miniatura);
                        }
                    }
                }
            }
        }

        private void RellenarVista14()
        {
            int contador = 0;

            using (SqlConnection conexion = new SqlConnection($"server={Logins.ObtenerInstancia().nombreServidor}; database =GestorAcademico; integrated security = true"))
            {
                conexion.Open();

                string consulta = @"SELECT uxc.fkCurso AS idCurso, uxc.fkUsuario AS idEstudiante, axe.fkSemana AS idSemana, a.idAsignacion
                            FROM Asignacion AS a
                            JOIN Usuario_x_Curso AS uxc ON a.fkCurso = uxc.fkCurso
                            JOIN Asignacion_x_Estudiante AS axe ON a.idAsignacion = axe.fkAsignacion AND uxc.fkUsuario = axe.fkUsuario
                            WHERE uxc.fkUsuario = " + idCred + " AND axe.fkSemana = 14 AND uxc.fkCurso = " + idCurso +
                            " ORDER BY uxc.fkCurso, uxc.fkUsuario, axe.fkSemana, a.idAsignacion;";

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
                            subMenuSemana14.Controls.Add(miniatura);
                        }
                    }
                }
            }
        }

        private void RellenarVista14_grupo()
        {
            int contador = 0;

            using (SqlConnection conexion = new SqlConnection($"server={Logins.ObtenerInstancia().nombreServidor}; database =GestorAcademico; integrated security = true"))
            {
                conexion.Open();

                string consulta = @"SELECT ag.idAsignacion_x_Grupo, ag.fkAsignacion, ag.fkGrupo, ag.fkSemana, a.idAsignacion
                                    FROM Asignacion_x_Grupo AS ag
                                    JOIN Asignacion AS a ON ag.fkAsignacion = a.idAsignacion
                                    JOIN (
                                        SELECT a.idAsignacion, MIN(ag.idAsignacion_x_Grupo) AS min_id
                                        FROM Asignacion_x_Grupo AS ag
                                        JOIN Asignacion AS a ON ag.fkAsignacion = a.idAsignacion
                                        JOIN Usuario_x_Curso AS uxc ON a.fkCurso = uxc.fkCurso
                                        WHERE uxc.fkUsuario = @credencial AND ag.fkSemana = 14
                                        GROUP BY a.idAsignacion
                                    ) AS unique_assignments ON ag.idAsignacion_x_Grupo = unique_assignments.min_id;";

                using (SqlCommand command = new SqlCommand(consulta, conexion))
                {
                    command.Parameters.AddWithValue("@credencial", idCred);
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
                            subMenuSemana14.Controls.Add(miniatura);
                        }
                    }
                }
            }
        }

        private void RellenarVista15()
        {
            int contador = 0;

            using (SqlConnection conexion = new SqlConnection($"server={Logins.ObtenerInstancia().nombreServidor}; database =GestorAcademico; integrated security = true"))
            {
                conexion.Open();

                string consulta = @"SELECT uxc.fkCurso AS idCurso, uxc.fkUsuario AS idEstudiante, axe.fkSemana AS idSemana, a.idAsignacion
                            FROM Asignacion AS a
                            JOIN Usuario_x_Curso AS uxc ON a.fkCurso = uxc.fkCurso
                            JOIN Asignacion_x_Estudiante AS axe ON a.idAsignacion = axe.fkAsignacion AND uxc.fkUsuario = axe.fkUsuario
                            WHERE uxc.fkUsuario = " + idCred + " AND axe.fkSemana = 15 AND uxc.fkCurso = " + idCurso +
                            " ORDER BY uxc.fkCurso, uxc.fkUsuario, axe.fkSemana, a.idAsignacion;";

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
                            subMenuSemana15.Controls.Add(miniatura);
                        }
                    }
                }
            }
        }

        private void RellenarVista15_grupo()
        {
            int contador = 0;

            using (SqlConnection conexion = new SqlConnection($"server={Logins.ObtenerInstancia().nombreServidor}; database =GestorAcademico; integrated security = true"))
            {
                conexion.Open();

                string consulta = @"SELECT ag.idAsignacion_x_Grupo, ag.fkAsignacion, ag.fkGrupo, ag.fkSemana, a.idAsignacion
                                    FROM Asignacion_x_Grupo AS ag
                                    JOIN Asignacion AS a ON ag.fkAsignacion = a.idAsignacion
                                    JOIN (
                                        SELECT a.idAsignacion, MIN(ag.idAsignacion_x_Grupo) AS min_id
                                        FROM Asignacion_x_Grupo AS ag
                                        JOIN Asignacion AS a ON ag.fkAsignacion = a.idAsignacion
                                        JOIN Usuario_x_Curso AS uxc ON a.fkCurso = uxc.fkCurso
                                        WHERE uxc.fkUsuario = @credencial AND ag.fkSemana = 15
                                        GROUP BY a.idAsignacion
                                    ) AS unique_assignments ON ag.idAsignacion_x_Grupo = unique_assignments.min_id;";

                using (SqlCommand command = new SqlCommand(consulta, conexion))
                {
                    command.Parameters.AddWithValue("@credencial", idCred);
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
                            subMenuSemana15.Controls.Add(miniatura);
                        }
                    }
                }
            }
        }

        //Métodos para abrir u ocultar el FlowLayoutPanel debajo de cada botón de la semana
        private void btnSemana1_Click(object sender, EventArgs e)
        {
            // Itera a través de los controles en el FlowLayoutPanel
            foreach (Control control in subMenuSemana1.Controls)
            {
                // Si el control es un FlowLayoutPanel y no es el submenú actual
                if (control is FlowLayoutPanel && control != subMenuSemana1)
                {
                    // Oculta el submenú
                    control.Visible = false;
                }
            }
            subMenuSemana1.Visible = !subMenuSemana1.Visible;
        }

        private void btnSemana2_Click(object sender, EventArgs e)
        {
            foreach (Control control in subMenuSemana2.Controls)
            {
                // Si el control es un FlowLayoutPanel y no es el submenú actual
                if (control is FlowLayoutPanel && control != subMenuSemana2)
                {
                    // Oculta el submenú
                    control.Visible = false;
                }
            }
            subMenuSemana2.Visible = !subMenuSemana2.Visible;
        }

        private void btnSemana3_Click(object sender, EventArgs e)
        {
            foreach (Control control in subMenuSemana3.Controls)
            {
                // Si el control es un FlowLayoutPanel y no es el submenú actual
                if (control is FlowLayoutPanel && control != subMenuSemana3)
                {
                    // Oculta el submenú
                    control.Visible = false;
                }
            }
            subMenuSemana3.Visible = !subMenuSemana3.Visible;
        }

        private void btnSemana4_Click(object sender, EventArgs e)
        {
            foreach (Control control in subMenuSemana4.Controls)
            {
                // Si el control es un FlowLayoutPanel y no es el submenú actual
                if (control is FlowLayoutPanel && control != subMenuSemana4)
                {
                    // Oculta el submenú
                    control.Visible = false;
                }
            }
            subMenuSemana4.Visible = !subMenuSemana4.Visible;
        }

        private void btnSemana5_Click(object sender, EventArgs e)
        {
            foreach (Control control in subMenuSemana5.Controls)
            {
                // Si el control es un FlowLayoutPanel y no es el submenú actual
                if (control is FlowLayoutPanel && control != subMenuSemana5)
                {
                    // Oculta el submenú
                    control.Visible = false;
                }
            }
            subMenuSemana5.Visible = !subMenuSemana5.Visible;
        }

        private void btnSemana6_Click(object sender, EventArgs e)
        {
            foreach (Control control in subMenuSemana6.Controls)
            {
                // Si el control es un FlowLayoutPanel y no es el submenú actual
                if (control is FlowLayoutPanel && control != subMenuSemana6)
                {
                    // Oculta el submenú
                    control.Visible = false;
                }
            }
            subMenuSemana6.Visible = !subMenuSemana6.Visible;
        }

        private void btnSemana7_Click(object sender, EventArgs e)
        {
            foreach (Control control in subMenuSemana7.Controls)
            {
                // Si el control es un FlowLayoutPanel y no es el submenú actual
                if (control is FlowLayoutPanel && control != subMenuSemana7)
                {
                    // Oculta el submenú
                    control.Visible = false;
                }
            }
            subMenuSemana7.Visible = !subMenuSemana7.Visible;
        }

        private void btnSemana8_Click(object sender, EventArgs e)
        {
            foreach (Control control in subMenuSemana8.Controls)
            {
                // Si el control es un FlowLayoutPanel y no es el submenú actual
                if (control is FlowLayoutPanel && control != subMenuSemana8)
                {
                    // Oculta el submenú
                    control.Visible = false;
                }
            }
            subMenuSemana8.Visible = !subMenuSemana8.Visible;
        }

        private void btnSemana9_Click(object sender, EventArgs e)
        {
            foreach (Control control in subMenuSemana9.Controls)
            {
                // Si el control es un FlowLayoutPanel y no es el submenú actual
                if (control is FlowLayoutPanel && control != subMenuSemana9)
                {
                    // Oculta el submenú
                    control.Visible = false;
                }
            }
            subMenuSemana9.Visible = !subMenuSemana9.Visible;
        }

        private void btnSemana10_Click(object sender, EventArgs e)
        {
            foreach (Control control in subMenuSemana10.Controls)
            {
                // Si el control es un FlowLayoutPanel y no es el submenú actual
                if (control is FlowLayoutPanel && control != subMenuSemana10)
                {
                    // Oculta el submenú
                    control.Visible = false;
                }
            }
            subMenuSemana10.Visible = !subMenuSemana10.Visible;
        }

        private void btnSemana11_Click(object sender, EventArgs e)
        {
            foreach (Control control in subMenuSemana11.Controls)
            {
                // Si el control es un FlowLayoutPanel y no es el submenú actual
                if (control is FlowLayoutPanel && control != subMenuSemana11)
                {
                    // Oculta el submenú
                    control.Visible = false;
                }
            }
            subMenuSemana11.Visible = !subMenuSemana11.Visible;
        }

        private void btnSemana12_Click(object sender, EventArgs e)
        {
            foreach (Control control in subMenuSemana12.Controls)
            {
                // Si el control es un FlowLayoutPanel y no es el submenú actual
                if (control is FlowLayoutPanel && control != subMenuSemana12)
                {
                    // Oculta el submenú
                    control.Visible = false;
                }
            }
            subMenuSemana12.Visible = !subMenuSemana12.Visible;
        }

        private void btnSemana13_Click(object sender, EventArgs e)
        {
            foreach (Control control in subMenuSemana13.Controls)
            {
                // Si el control es un FlowLayoutPanel y no es el submenú actual
                if (control is FlowLayoutPanel && control != subMenuSemana13)
                {
                    // Oculta el submenú
                    control.Visible = false;
                }
            }
            subMenuSemana13.Visible = !subMenuSemana13.Visible;
        }

        private void btnSemana14_Click(object sender, EventArgs e)
        {
            foreach (Control control in subMenuSemana14.Controls)
            {
                // Si el control es un FlowLayoutPanel y no es el submenú actual
                if (control is FlowLayoutPanel && control != subMenuSemana14)
                {
                    // Oculta el submenú
                    control.Visible = false;
                }
            }
            subMenuSemana14.Visible = !subMenuSemana14.Visible;
        }

        private void btnSemana15_Click(object sender, EventArgs e)
        {
            foreach (Control control in subMenuSemana15.Controls)
            {
                // Si el control es un FlowLayoutPanel y no es el submenú actual
                if (control is FlowLayoutPanel && control != subMenuSemana15)
                {
                    // Oculta el submenú
                    control.Visible = false;
                }
            }
            subMenuSemana15.Visible = !subMenuSemana15.Visible;
        }
    }
}
