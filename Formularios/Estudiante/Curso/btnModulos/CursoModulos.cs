using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Proyecto_GestionAcademica_Grupo05.Formularios.Estudiante.FormularioHijo1.Curso
{
    public partial class CursoModulos : Form
    {
        public string idCred;
        public string idCurso;
        public string nombreGrupo;

        //Se usa para pasar un string que no sea apto para las asignaciones que no sean grupales
        public string noApto = "noApto";

        public CursoModulos(string idCred, string idCurso)
        {
            InitializeComponent();
            this.idCred = idCred;
            this.idCurso = idCurso;
            editarDisenno();
            obtenerNombreGrupo();
            RellenarVistas();
            btnColapsarExpandir.Text = "Expandir todos";
            btnColapsarExpandir.Visible = false;
        }

        //Método que obtiene el nombre del grupo para usarlo como parámetro en los métodos de RellenarVistas grupales
        //para poder ingresar a las asignaciones grupales con el idAsignacion_x_Gripo y idGrupo
        //Sirve para luego controlar la entrega de cada asignación
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
                                        WHERE g.fkCurso = "+idCurso+
                                        "AND uxg.fkUsuario = " +idCred+";";

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

                MessageBox.Show("Error en el método 'obtenerIDGrupo': "+ex.ToString()); ;
            }
        }

        //Método que sirve para inicializar todos los FlowLayoutPaneles en falso para dar la sensación de que están ocultos
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

        //Métodos para rellenar cada FlowLayoutPanel de cada semana con las asignaciones respectivas
        private void RellenarVistas()
        {
            RellenarVista1();
            RellenarVista1_grupo();
            RellenarVista2();
            RellenarVistas2_grupo();
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

                string consulta = @"SELECT ag.idAsignacion_x_Grupo, ag.fkAsignacion, ag.fkGrupo, ag.fkSemana
                        FROM Asignacion_x_Grupo AS ag
                        JOIN Asignacion AS a ON ag.fkAsignacion = a.idAsignacion
                        WHERE ag.fkGrupo = (SELECT idGrupo FROM Grupo WHERE nombreGrupo = @nombreGrupo AND fkCurso = @idCurso) AND ag.fkSemana = 1;";

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
                            WHERE uxc.fkUsuario = "+ idCred +" AND axe.fkSemana = 2 AND uxc.fkCurso = "+ idCurso +
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
        
        private void RellenarVistas2_grupo()
        {
            int contador = 0;

            using (SqlConnection conexion = new SqlConnection($"server={Logins.ObtenerInstancia().nombreServidor}; database =GestorAcademico; integrated security = true"))
            {
                conexion.Open();

                string consulta = @"SELECT ag.idAsignacion_x_Grupo, ag.fkAsignacion, ag.fkGrupo, ag.fkSemana
                        FROM Asignacion_x_Grupo AS ag
                        JOIN Asignacion AS a ON ag.fkAsignacion = a.idAsignacion
                        WHERE ag.fkGrupo = (SELECT idGrupo FROM Grupo WHERE nombreGrupo = @nombreGrupo AND fkCurso = @idCurso) AND ag.fkSemana = 2;";

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

                string consulta = @"SELECT ag.idAsignacion_x_Grupo, ag.fkAsignacion, ag.fkGrupo, ag.fkSemana
                        FROM Asignacion_x_Grupo AS ag
                        JOIN Asignacion AS a ON ag.fkAsignacion = a.idAsignacion
                        WHERE ag.fkGrupo = (SELECT idGrupo FROM Grupo WHERE nombreGrupo = @nombreGrupo AND fkCurso = @idCurso) AND ag.fkSemana = 3;";

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

                string consulta = @"SELECT ag.idAsignacion_x_Grupo, ag.fkAsignacion, ag.fkGrupo, ag.fkSemana
                        FROM Asignacion_x_Grupo AS ag
                        JOIN Asignacion AS a ON ag.fkAsignacion = a.idAsignacion
                        WHERE ag.fkGrupo = (SELECT idGrupo FROM Grupo WHERE nombreGrupo = @nombreGrupo AND fkCurso = @idCurso) AND ag.fkSemana = 4;";

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

                string consulta = @"SELECT ag.idAsignacion_x_Grupo, ag.fkAsignacion, ag.fkGrupo, ag.fkSemana
                        FROM Asignacion_x_Grupo AS ag
                        JOIN Asignacion AS a ON ag.fkAsignacion = a.idAsignacion
                        WHERE ag.fkGrupo = (SELECT idGrupo FROM Grupo WHERE nombreGrupo = @nombreGrupo AND fkCurso = @idCurso) AND ag.fkSemana = 5;";

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

                string consulta = @"SELECT ag.idAsignacion_x_Grupo, ag.fkAsignacion, ag.fkGrupo, ag.fkSemana
                        FROM Asignacion_x_Grupo AS ag
                        JOIN Asignacion AS a ON ag.fkAsignacion = a.idAsignacion
                        WHERE ag.fkGrupo = (SELECT idGrupo FROM Grupo WHERE nombreGrupo = @nombreGrupo AND fkCurso = @idCurso) AND ag.fkSemana = 6;";

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

                string consulta = @"SELECT ag.idAsignacion_x_Grupo, ag.fkAsignacion, ag.fkGrupo, ag.fkSemana
                        FROM Asignacion_x_Grupo AS ag
                        JOIN Asignacion AS a ON ag.fkAsignacion = a.idAsignacion
                        WHERE ag.fkGrupo = (SELECT idGrupo FROM Grupo WHERE nombreGrupo = @nombreGrupo AND fkCurso = @idCurso) AND ag.fkSemana = 7;";

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

                string consulta = @"SELECT ag.idAsignacion_x_Grupo, ag.fkAsignacion, ag.fkGrupo, ag.fkSemana
                        FROM Asignacion_x_Grupo AS ag
                        JOIN Asignacion AS a ON ag.fkAsignacion = a.idAsignacion
                        WHERE ag.fkGrupo = (SELECT idGrupo FROM Grupo WHERE nombreGrupo = @nombreGrupo AND fkCurso = @idCurso) AND ag.fkSemana = 8;";

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

                string consulta = @"SELECT ag.idAsignacion_x_Grupo, ag.fkAsignacion, ag.fkGrupo, ag.fkSemana
                        FROM Asignacion_x_Grupo AS ag
                        JOIN Asignacion AS a ON ag.fkAsignacion = a.idAsignacion
                        WHERE ag.fkGrupo = (SELECT idGrupo FROM Grupo WHERE nombreGrupo = @nombreGrupo AND fkCurso = @idCurso) AND ag.fkSemana = 9;";

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

                string consulta = @"SELECT ag.idAsignacion_x_Grupo, ag.fkAsignacion, ag.fkGrupo, ag.fkSemana
                        FROM Asignacion_x_Grupo AS ag
                        JOIN Asignacion AS a ON ag.fkAsignacion = a.idAsignacion
                        WHERE ag.fkGrupo = (SELECT idGrupo FROM Grupo WHERE nombreGrupo = @nombreGrupo AND fkCurso = @idCurso) AND ag.fkSemana = 10;";

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

                string consulta = @"SELECT ag.idAsignacion_x_Grupo, ag.fkAsignacion, ag.fkGrupo, ag.fkSemana
                        FROM Asignacion_x_Grupo AS ag
                        JOIN Asignacion AS a ON ag.fkAsignacion = a.idAsignacion
                        WHERE ag.fkGrupo = (SELECT idGrupo FROM Grupo WHERE nombreGrupo = @nombreGrupo AND fkCurso = @idCurso) AND ag.fkSemana = 11;";

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

                string consulta = @"SELECT ag.idAsignacion_x_Grupo, ag.fkAsignacion, ag.fkGrupo, ag.fkSemana
                        FROM Asignacion_x_Grupo AS ag
                        JOIN Asignacion AS a ON ag.fkAsignacion = a.idAsignacion
                        WHERE ag.fkGrupo = (SELECT idGrupo FROM Grupo WHERE nombreGrupo = @nombreGrupo AND fkCurso = @idCurso) AND ag.fkSemana = 12;";

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

                string consulta = @"SELECT ag.idAsignacion_x_Grupo, ag.fkAsignacion, ag.fkGrupo, ag.fkSemana
                        FROM Asignacion_x_Grupo AS ag
                        JOIN Asignacion AS a ON ag.fkAsignacion = a.idAsignacion
                        WHERE ag.fkGrupo = (SELECT idGrupo FROM Grupo WHERE nombreGrupo = @nombreGrupo AND fkCurso = @idCurso) AND ag.fkSemana = 13;";

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

                string consulta = @"SELECT ag.idAsignacion_x_Grupo, ag.fkAsignacion, ag.fkGrupo, ag.fkSemana
                        FROM Asignacion_x_Grupo AS ag
                        JOIN Asignacion AS a ON ag.fkAsignacion = a.idAsignacion
                        WHERE ag.fkGrupo = (SELECT idGrupo FROM Grupo WHERE nombreGrupo = @nombreGrupo AND fkCurso = @idCurso) AND ag.fkSemana = 14;";

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

                string consulta = @"SELECT ag.idAsignacion_x_Grupo, ag.fkAsignacion, ag.fkGrupo, ag.fkSemana
                        FROM Asignacion_x_Grupo AS ag
                        JOIN Asignacion AS a ON ag.fkAsignacion = a.idAsignacion
                        WHERE ag.fkGrupo = (SELECT idGrupo FROM Grupo WHERE nombreGrupo = @nombreGrupo AND fkCurso = @idCurso) AND ag.fkSemana = 15;";

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
            // Itera a través de los controles en el FlowLayoutPanel
            foreach (Control control in subMenuSemana2.Controls)
            {
                // Si el control es un FlowLayoutPanel y no es el submenú actual
                if (control is Panel && control != subMenuSemana2)
                {
                    // Oculta el submenú
                    control.Visible = false;
                }
            }
            // Muestra u oculta el submenú actual
            subMenuSemana2.Visible = !subMenuSemana2.Visible;
        }

        private void btnSemana3_Click(object sender, EventArgs e)
        {
            // Itera a través de los controles en el FlowLayoutPanel
            foreach (Control control in subMenuSemana3.Controls)
            {
                // Si el control es un FlowLayoutPanel y no es el submenú actual
                if (control is Panel && control != subMenuSemana3)
                {
                    // Oculta el submenú
                    control.Visible = false;
                }
            }
            // Muestra u oculta el submenú actual
            subMenuSemana3.Visible = !subMenuSemana3.Visible;
        }

        private void btnSemana4_Click(object sender, EventArgs e)
        {
            // Itera a través de los controles en el FlowLayoutPanel
            foreach (Control control in subMenuSemana4.Controls)
            {
                // Si el control es un FlowLayoutPanel y no es el submenú actual
                if (control is Panel && control != subMenuSemana4)
                {
                    // Oculta el submenú
                    control.Visible = false;
                }
            }
            // Muestra u oculta el submenú actual
            subMenuSemana4.Visible = !subMenuSemana4.Visible;
        }

        private void btnSemana5_Click(object sender, EventArgs e)
        {
            // Itera a través de los controles en el FlowLayoutPanel
            foreach (Control control in subMenuSemana5.Controls)
            {
                // Si el control es un FlowLayoutPanel y no es el submenú actual
                if (control is Panel && control != subMenuSemana5)
                {
                    // Oculta el submenú
                    control.Visible = false;
                }
            }
            // Muestra u oculta el submenú actual
            subMenuSemana5.Visible = !subMenuSemana5.Visible;
        }

        private void btnSemana6_Click(object sender, EventArgs e)
        {
            // Itera a través de los controles en el FlowLayoutPanel
            foreach (Control control in subMenuSemana6.Controls)
            {
                // Si el control es un FlowLayoutPanel y no es el submenú actual
                if (control is Panel && control != subMenuSemana6)
                {
                    // Oculta el submenú
                    control.Visible = false;
                }
            }
            // Muestra u oculta el submenú actual
            subMenuSemana6.Visible = !subMenuSemana6.Visible;

        }

        private void btnSemana7_Click(object sender, EventArgs e)
        {
            // Itera a través de los controles en el FlowLayoutPanel
            foreach (Control control in subMenuSemana7.Controls)
            {
                // Si el control es un FlowLayoutPanel y no es el submenú actual
                if (control is Panel && control != subMenuSemana7)
                {
                    // Oculta el submenú
                    control.Visible = false;
                }
            }
            // Muestra u oculta el submenú actual
            subMenuSemana7.Visible = !subMenuSemana7.Visible;

        }

        private void btnSemana8_Click(object sender, EventArgs e)
        {
            // Itera a través de los controles en el FlowLayoutPanel
            foreach (Control control in subMenuSemana8.Controls)
            {
                // Si el control es un FlowLayoutPanel y no es el submenú actual
                if (control is Panel && control != subMenuSemana8)
                {
                    // Oculta el submenú
                    control.Visible = false;
                }
            }
            // Muestra u oculta el submenú actual
            subMenuSemana8.Visible = !subMenuSemana8.Visible;

        }

        private void btnSemana9_Click(object sender, EventArgs e)
        {
            // Itera a través de los controles en el FlowLayoutPanel
            foreach (Control control in subMenuSemana9.Controls)
            {
                // Si el control es un FlowLayoutPanel y no es el submenú actual
                if (control is Panel && control != subMenuSemana9)
                {
                    // Oculta el submenú
                    control.Visible = false;
                }
            }
            // Muestra u oculta el submenú actual
            subMenuSemana9.Visible = !subMenuSemana9.Visible;

        }

        private void btnSemana10_Click(object sender, EventArgs e)
        {
            // Itera a través de los controles en el FlowLayoutPanel
            foreach (Control control in subMenuSemana10.Controls)
            {
                // Si el control es un FlowLayoutPanel y no es el submenú actual
                if (control is Panel && control != subMenuSemana10)
                {
                    // Oculta el submenú
                    control.Visible = false;
                }
            }
            // Muestra u oculta el submenú actual
            subMenuSemana10.Visible = !subMenuSemana10.Visible;

        }

        private void btnSemana11_Click(object sender, EventArgs e)
        {
            // Itera a través de los controles en el FlowLayoutPanel
            foreach (Control control in subMenuSemana11.Controls)
            {
                // Si el control es un FlowLayoutPanel y no es el submenú actual
                if (control is Panel && control != subMenuSemana11)
                {
                    // Oculta el submenú
                    control.Visible = false;
                }
            }
            // Muestra u oculta el submenú actual
            subMenuSemana11.Visible = !subMenuSemana11.Visible;

        }

        private void btnSemana12_Click(object sender, EventArgs e)
        {
            // Itera a través de los controles en el FlowLayoutPanel
            foreach (Control control in subMenuSemana12.Controls)
            {
                // Si el control es un FlowLayoutPanel y no es el submenú actual
                if (control is Panel && control != subMenuSemana12)
                {
                    // Oculta el submenú
                    control.Visible = false;
                }
            }
            // Muestra u oculta el submenú actual
            subMenuSemana12.Visible = !subMenuSemana12.Visible;

        }

        private void btnSemana13_Click(object sender, EventArgs e)
        {
            // Itera a través de los controles en el FlowLayoutPanel
            foreach (Control control in subMenuSemana13.Controls)
            {
                // Si el control es un FlowLayoutPanel y no es el submenú actual
                if (control is Panel && control != subMenuSemana13)
                {
                    // Oculta el submenú
                    control.Visible = false;
                }
            }
            // Muestra u oculta el submenú actual
            subMenuSemana13.Visible = !subMenuSemana13.Visible;

        }

        private void btnSemana14_Click(object sender, EventArgs e)
        {
            // Itera a través de los controles en el FlowLayoutPanel
            foreach (Control control in subMenuSemana14.Controls)
            {
                // Si el control es un FlowLayoutPanel y no es el submenú actual
                if (control is Panel && control != subMenuSemana14)
                {
                    // Oculta el submenú
                    control.Visible = false;
                }
            }
            // Muestra u oculta el submenú actual
            subMenuSemana14.Visible = !subMenuSemana14.Visible;

        }

        private void btnSemana15_Click(object sender, EventArgs e)
        {
            // Itera a través de los controles en el FlowLayoutPanel
            foreach (Control control in subMenuSemana15.Controls)
            {
                // Si el control es un FlowLayoutPanel y no es el submenú actual
                if (control is Panel && control != subMenuSemana15)
                {
                    // Oculta el submenú
                    control.Visible = false;
                }
            }
            // Muestra u oculta el submenú actual
            subMenuSemana15.Visible = !subMenuSemana15.Visible;

        }

        //Botón para expandir o colapsar todo (no funcional)
        private void btnColapsarExpandir_Click(object sender, EventArgs e)
        {
            if (btnColapsarExpandir.Text == "Expandir todos")
            {
                subMenuSemana1.Visible = true;
                subMenuSemana2.Visible = true;
                subMenuSemana3.Visible = true;
                subMenuSemana4.Visible = true;
                subMenuSemana5.Visible = true;
                subMenuSemana6.Visible = true;
                subMenuSemana7.Visible = true;
                subMenuSemana8.Visible = true;
                subMenuSemana9.Visible = true;
                subMenuSemana10.Visible = true;
                subMenuSemana11.Visible = true;
                subMenuSemana12.Visible = true;
                subMenuSemana13.Visible = true;
                subMenuSemana14.Visible = true;
                subMenuSemana15.Visible = true;
                btnColapsarExpandir.Text = "Colapsar todos";
            }
            else if (btnColapsarExpandir.Text == "Colapsar todos")
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
                btnColapsarExpandir.Text = "Expandir todos";
            }
        }
    }
}
