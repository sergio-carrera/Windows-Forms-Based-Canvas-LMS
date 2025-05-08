using Proyecto_GestionAcademica_Grupo05.Formularios.Estudiante.FormularioHijo1.Curso;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_GestionAcademica_Grupo05.Formularios.Estudiante.Curso.btnCalificaciones_estudiante
{
    public partial class VistaCalificaciones : Form
    {
        //Variables que se pasan desde "CursoInicio"
        public string idCred;
        public string idCurso;

        //Variables para calcular nota
        public decimal tareasTotal;
        public decimal laboratoriosTotal;
        public decimal proyectoTotal;
        public decimal asistenciaTotal_;
        public decimal asistenciaTotal;
        public decimal total;

        //1 = reprobado
        public decimal aprobado_reprobado_asistencia;

        //Variables para rellenar las vistas de las asignaciones
        public string idSemana;
        public string idAsignacion;
        public string idAsignacion_x_Grup;
        public string idGrup;
        public string idAsignacion_x_Est_O_Grup;
        public string idAsignacion_modalidad;
        public string nombre;
        public string calificacion;
        public string nota;

        public VistaCalificaciones(string idCred, string idCurso)
        {
            InitializeComponent();
            this.idCred = idCred;
            this.idCurso = idCurso;
            lblNombreTit.Visible = false;
            lblFechaEntregaTit.Visible = false;
            lblEstadoTit.Visible = false;
            lblPuntajeTit.Visible = false;
            //Llamado de métodos de obtención de datos
            ObtenerNombreCompletoMayus();
            ObtenerTareasPorcentaje();
            ObtenerLaboratoriosPorcentaje();
            ObtenerProyectoPorcentaje();
            ObtenerAsistenciaPorcentaje();
            ObtenerTotalPorcentaje();
            ObtenerEstadoDeAusencias();
        }

        public void ObtenerNombreCompletoMayus()
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection($"server={Logins.ObtenerInstancia().nombreServidor}; database =GestorAcademico; integrated security = true"))
                {
                    conexion.Open();

                    string consulta = @"SELECT nombre + ' ' + apellido1 + ' ' + apellido2 AS NombreCompleto
                                       FROM Usuario
                                       WHERE idUsuario = @idUsuario";

                    using (SqlCommand comando = new SqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@idUsuario", idCred);

                        string nombreCompleto = comando.ExecuteScalar().ToString();

                        if (!string.IsNullOrEmpty(nombreCompleto))
                        {
                            lblTitulo.Text = "Calificaciones para: " + nombreCompleto.ToUpper();
                        }
                        else
                        {
                            
                        }
                    }

                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Error en el método 'ObtenerNombreCompletoMayus': " + ex.ToString());
            }
        }

        public void ObtenerTareasPorcentaje()
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection($"server={Logins.ObtenerInstancia().nombreServidor}; database =GestorAcademico; integrated security = true"))
                {
                    conexion.Open();

                    string consulta = @"DECLARE @ID_ESTUDIANTE INT = @idCred;
                                        DECLARE @ID_CURSO INT = @idCurso;

                                        WITH CalificacionesTareas AS (
                                            SELECT
                                                COALESCE(ae.calificacion, 0) AS calificacion,
                                                a.nota
                                            FROM
                                                Asignacion_x_Estudiante ae
                                                JOIN Asignacion a ON ae.fkAsignacion = a.idAsignacion
                                            WHERE
                                                ae.fkUsuario = @ID_ESTUDIANTE
                                                AND a.fkCurso = @ID_CURSO
                                                AND a.fkAsignacion_tipo = 1

                                            UNION ALL

                                            SELECT
                                                COALESCE(ag.calificacion, 0) AS calificacion,
                                                a.nota
                                            FROM
                                                Asignacion_x_Grupo ag
                                                JOIN Asignacion a ON ag.fkAsignacion = a.idAsignacion
                                                JOIN Usuario_x_Grupo ug ON ag.fkGrupo = ug.fkGrupo -- Relación con Usuario_x_Grupo
                                            WHERE
                                                ug.fkUsuario = @ID_ESTUDIANTE -- Filtrar por el ID del estudiante
                                                AND a.fkCurso = @ID_CURSO
                                                AND a.fkAsignacion_tipo = 1
                                        )
                                        SELECT
                                            ROUND(SUM((calificacion / nota) * 100) / COUNT(*) * 0.20, 2) AS tareasTotal
                                        FROM
                                            CalificacionesTareas;";

                    using (SqlCommand comando = new SqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@idCred", idCred);
                        comando.Parameters.AddWithValue("@idCurso", idCurso);

                        object resultado = comando.ExecuteScalar();

                        if (resultado != DBNull.Value)
                        {
                            tareasTotal = Convert.ToDecimal(resultado);
                            lblTareasPorcentaje.Text = tareasTotal.ToString() + "% / 20%";
                        }
                        else if (resultado == DBNull.Value)
                        {
                            lblTareasPorcentaje.Text = "0 / 20%";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en el método 'ObtenerTareasPorcentaje': " + ex.ToString());
            }
        }

        public void ObtenerLaboratoriosPorcentaje()
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection($"server={Logins.ObtenerInstancia().nombreServidor}; database =GestorAcademico; integrated security = true"))
                {
                    conexion.Open();

                    string consulta = @"DECLARE @ID_ESTUDIANTE INT = @idCred;
                                        DECLARE @ID_CURSO INT = @idCurso;

                                        WITH CalificacionesLaboratorios AS (
                                            SELECT
                                                COALESCE(ae.calificacion, 0) AS calificacion,
                                                a.nota
                                            FROM
                                                Asignacion_x_Estudiante ae
                                                JOIN Asignacion a ON ae.fkAsignacion = a.idAsignacion
                                            WHERE
                                                ae.fkUsuario = @ID_ESTUDIANTE
                                                AND a.fkCurso = @ID_CURSO
                                                AND a.fkAsignacion_tipo = 2

                                            UNION ALL

                                            SELECT
                                                COALESCE(ag.calificacion, 0) AS calificacion,
                                                a.nota
                                            FROM
                                                Asignacion_x_Grupo ag
                                                JOIN Asignacion a ON ag.fkAsignacion = a.idAsignacion
                                                JOIN Usuario_x_Grupo ug ON ag.fkGrupo = ug.fkGrupo -- Relación con Usuario_x_Grupo
                                            WHERE
                                                ug.fkUsuario = @ID_ESTUDIANTE -- Filtrar por el ID del estudiante
                                                AND a.fkCurso = @ID_CURSO
                                                AND a.fkAsignacion_tipo = 2
                                        )
                                        SELECT
                                            ROUND(SUM((calificacion / nota) * 100) / COUNT(*) * 0.30, 2) AS laboratoriosTotal
                                        FROM
                                            CalificacionesLaboratorios;";

                    using (SqlCommand comando = new SqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@idCred", idCred);
                        comando.Parameters.AddWithValue("@idCurso", idCurso);

                        object resultado = comando.ExecuteScalar();

                        if (resultado != DBNull.Value)
                        {
                            laboratoriosTotal = Convert.ToDecimal(resultado);
                            lblLaboratoriosPorcentaje.Text = laboratoriosTotal.ToString() + "% / 30%";
                        }
                        else if (resultado == DBNull.Value)
                        {
                            lblLaboratoriosPorcentaje.Text = "0% / 30%";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en el método 'ObtenerLaboratoriosPorcentaje': " + ex.ToString());
            }
        }

        public void ObtenerProyectoPorcentaje()
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection($"server={Logins.ObtenerInstancia().nombreServidor}; database =GestorAcademico; integrated security = true"))
                {
                    conexion.Open();

                    string consulta = @"DECLARE @ID_ESTUDIANTE INT = @idCred;
                                        DECLARE @ID_CURSO INT = @idCurso;

                                        WITH CalificacionesProyecto AS (
                                            SELECT
                                                COALESCE(ae.calificacion, 0) AS calificacion,
                                                a.nota
                                            FROM
                                                Asignacion_x_Estudiante ae
                                                JOIN Asignacion a ON ae.fkAsignacion = a.idAsignacion
                                            WHERE
                                                ae.fkUsuario = @ID_ESTUDIANTE
                                                AND a.fkCurso = @ID_CURSO
                                                AND a.fkAsignacion_tipo = 3

                                            UNION ALL

                                            SELECT
                                                COALESCE(ag.calificacion, 0) AS calificacion,
                                                a.nota
                                            FROM
                                                Asignacion_x_Grupo ag
                                                JOIN Asignacion a ON ag.fkAsignacion = a.idAsignacion
                                                JOIN Usuario_x_Grupo ug ON ag.fkGrupo = ug.fkGrupo -- Relación con Usuario_x_Grupo
                                            WHERE
                                                ug.fkUsuario = @ID_ESTUDIANTE -- Filtrar por el ID del estudiante
                                                AND a.fkCurso = @ID_CURSO
                                                AND a.fkAsignacion_tipo = 3
                                        )
                                        SELECT
                                            ROUND(SUM((calificacion / nota) * 100) / COUNT(*) * 0.40, 2) AS tareasProyecto
                                        FROM
                                            CalificacionesProyecto;";

                    using (SqlCommand comando = new SqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@idCred", idCred);
                        comando.Parameters.AddWithValue("@idCurso", idCurso);

                        object resultado = comando.ExecuteScalar();

                        if (resultado != DBNull.Value)
                        {
                            proyectoTotal = Convert.ToDecimal(resultado);
                            lblProyectoPorcentaje.Text = proyectoTotal.ToString() + "% / 40%";
                        }
                        else if (resultado == DBNull.Value) 
                        {
                            lblProyectoPorcentaje.Text = "0% / 40%";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en el método 'ObtenerProyectoPorcentaje': " + ex.ToString());
            }
        }

        public void ObtenerEstadoDeAusencias()
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection($"server={Logins.ObtenerInstancia().nombreServidor}; database =GestorAcademico; integrated security = true"))
                {
                    conexion.Open();

                    string consulta = @"DECLARE @ID_ESTUDIANTE INT = @idCred;
                                        DECLARE @ID_CURSO INT = @idCurso;

                                        DECLARE @ResultadoFinal DECIMAL(5, 2);

                                        WITH AsistenciasUsuario AS (
                                            SELECT
                                                fkAsistencia_estado,
                                                COUNT(*) AS cantAsistencia
                                            FROM
                                                Asistencia
                                            WHERE
                                                fkUsuario = @ID_ESTUDIANTE
                                                AND fkCurso = @ID_CURSO
                                            GROUP BY
                                                fkAsistencia_estado
                                        )
                                        SELECT
                                            @ResultadoFinal = 
                                                CASE
                                                    WHEN fkAsistencia_estado = 2 THEN
                                                        CASE
                                                            WHEN cantAsistencia >= 3 THEN 1  -- Return a numeric value, adjust as needed
                                                            ELSE 0
                                                        END
                                                    ELSE
                                                        0
                                                END
                                        FROM
                                            AsistenciasUsuario
                                        WHERE
                                            fkAsistencia_estado IN (1, 2);

                                        SELECT @ResultadoFinal AS ResultadoFinal;";

                    using (SqlCommand comando = new SqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@idCred", idCred);
                        comando.Parameters.AddWithValue("@idCurso", idCurso);

                        object resultado = comando.ExecuteScalar();

                        if (resultado != DBNull.Value)
                        {
                            aprobado_reprobado_asistencia = Convert.ToDecimal(resultado);

                            if ((int)aprobado_reprobado_asistencia == 0)
                            {
                                if (total >= 70)
                                {
                                    lblAprobadoReprobado.Text = "Estado: APROBADO";
                                }
                                else if (total < 70)
                                {
                                    lblAprobadoReprobado.Text = "Estado: REPROBADO";
                                }
                            }
                            else if ((int)aprobado_reprobado_asistencia == 1)
                            {
                                lblAprobadoReprobado.Text = "Estado: REPROBADO por ausencias";
                            }
                        }
                        else if (resultado == DBNull.Value)
                        {
                            if (total >= 70)
                            {
                                lblAprobadoReprobado.Text = "Estado: APROBADO";
                            }
                            else if (total < 70)
                            {
                                lblAprobadoReprobado.Text = "Estado: REPROBADO";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en el método 'ObtenerLaboratoriosPorcentaje': " + ex.ToString());
            }
        }

        public void ObtenerAsistenciaPorcentaje()
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection($"server={Logins.ObtenerInstancia().nombreServidor}; database =GestorAcademico; integrated security = true"))
                {
                    conexion.Open();

                    string consulta = @"DECLARE @ID_ESTUDIANTE INT = @idCred;
                                        DECLARE @ID_CURSO INT = @idCurso;

                                        WITH AsistenciasUsuario AS (
                                            SELECT
                                                fkAsistencia_estado,
                                                COUNT(*) AS cantAsistencia
                                            FROM
                                                Asistencia
                                            WHERE
                                                fkUsuario = @ID_ESTUDIANTE
                                                AND fkCurso = @ID_CURSO
                                            GROUP BY
                                                fkAsistencia_estado
                                        )
                                        SELECT
                                            CASE
                                                WHEN fkAsistencia_estado = 1 THEN
                                                    ROUND((cantAsistencia / 15.0) * 100 * 0.10, 2)          
                                            END AS Resultado
                                        FROM
                                            AsistenciasUsuario
                                        WHERE
                                            fkAsistencia_estado IN (1);";

                    using (SqlCommand comando = new SqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@idCred", idCred);
                        comando.Parameters.AddWithValue("@idCurso", idCurso);

                        object resultado = comando.ExecuteScalar();

                        if (resultado != DBNull.Value)
                        {
                            asistenciaTotal_ = Convert.ToDecimal(resultado);
                            asistenciaTotal = Math.Round(asistenciaTotal_, 2);
                            lblAsistenciaPorcentaje.Text = asistenciaTotal.ToString() + "% / 10%";
                        }
                        else if (resultado == DBNull.Value)
                        {
                            lblProyectoPorcentaje.Text = "0% / 10%";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en el método 'ObtenerProyectoPorcentaje': " + ex.ToString());
            }
        }

        public void ObtenerTotalPorcentaje()
        {
            try
            {
                total = tareasTotal + laboratoriosTotal + proyectoTotal + asistenciaTotal;
                lblTotalPorcentaje.Text = total.ToString() + " % / 100%";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en el método 'ObtenerTotalPorcentaje': " + ex.ToString());
            }
        }

        public void ActivarTitulos()
        {
            lblNombreTit.Text = "Nombre";
            lblNombreTit.Visible = true;
            lblFechaEntregaTit.Visible = true;
            lblEstadoTit.Visible = true;
            lblPuntajeTit.Visible = true;
        }
        
        public void ActivarTitulosAsist()
        {
            lblNombreTit.Text = "Semana";
            lblNombreTit.Visible = true;
            lblFechaEntregaTit.Visible = false;
            lblEstadoTit.Visible = true;
            lblPuntajeTit.Visible = false;
        }

        //Eventos para mostrar tareas, laboratorios, proyecto o asistencia
        private void lblTareas_Click(object sender, EventArgs e)
        {
            ActivarTitulos();
            RellenarVistaTareas();
        }

        private void lblLaboratorios_Click(object sender, EventArgs e)
        {
            ActivarTitulos();
            RellenarVistaLaboratorios();
        }

        private void lblProyecto_Click(object sender, EventArgs e)
        {
            ActivarTitulos();
            RellenarVistaProyecto();
        }

        private void lblAsistencia_Click(object sender, EventArgs e)
        {
            ActivarTitulosAsist();
            RellenarVistaAsistencia();
        }

        //Método para obtener id de grupo del estudiante
        private void ObtenerIdGrupo()
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection($"server={Logins.ObtenerInstancia().nombreServidor}; database =GestorAcademico; integrated security = true"))
                {
                    conexion.Open();
                    string consulta = @"select fkGrupo from Asignacion_x_Grupo where idAsignacion_x_Grupo = @idAsignacion_x_Grupo";

                    using (SqlCommand comando = new SqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@idAsignacion_x_Grupo", idAsignacion_x_Est_O_Grup);
                        using (SqlDataReader lector = comando.ExecuteReader())
                        {
                            if (lector.Read())
                            {
                                idGrup = Convert.ToInt32(lector["fkGrupo"]).ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en el método 'ObtenerIdGrupo': " + ex.ToString());
            }
        }

        //Métodos para rellenar el flowLayoutPanel con los User Controls respectivos
        public void RellenarVistaTareas()
        {
            try
            {
                listaAsignaciones.Controls.Clear();
                int contador = 0;

                using (SqlConnection conexion = new SqlConnection($"server={Logins.ObtenerInstancia().nombreServidor}; database =GestorAcademico; integrated security = true"))
                {
                    conexion.Open();

                    string consulta = @"SELECT
		                                a.nombre,
                                        a.idAsignacion,
                                        a.fkAsignacion_modalidad,
                                        ae.idAsignacion_x_Estudiante AS idAsignacion_x_Est_O_Grup,
                                        COALESCE(ae.calificacion, 0) AS calificacion,
                                        a.nota,
                                        ae.fkSemana
                                    FROM
                                        Asignacion_x_Estudiante ae
                                        JOIN Asignacion a ON ae.fkAsignacion = a.idAsignacion
                                    WHERE
                                        ae.fkUsuario = @idCred
                                        AND a.fkCurso = @idCurso
                                        AND a.fkAsignacion_tipo = 1

                                    UNION ALL

                                    SELECT
		                                a.nombre,
                                        a.idAsignacion,
                                        a.fkAsignacion_modalidad,
                                        ag.idAsignacion_x_Grupo,
                                        COALESCE(ag.calificacion, 0) AS calificacion,
                                        a.nota,
                                        ag.fkSemana
                                    FROM
                                        Asignacion_x_Grupo ag
                                        JOIN Asignacion a ON ag.fkAsignacion = a.idAsignacion
                                        JOIN Usuario_x_Grupo ug ON ag.fkGrupo = ug.fkGrupo 
                                    WHERE
                                        ug.fkUsuario = @idCred 
                                        AND a.fkCurso = @idCurso
                                        AND a.fkAsignacion_tipo = 1";

                    using (SqlCommand comando = new SqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@idCred", idCred);
                        comando.Parameters.AddWithValue("@idCurso", idCurso);

                        using (SqlDataReader lector = comando.ExecuteReader())
                        {
                            while (lector.Read())
                            {
                                contador++;

                                idSemana = Convert.ToInt32(lector["fkSemana"]).ToString();
                                idAsignacion = Convert.ToInt32(lector["idAsignacion"]).ToString();
                                idAsignacion_x_Est_O_Grup = Convert.ToInt32(lector["idAsignacion_x_Est_O_Grup"]).ToString();
                                idAsignacion_modalidad = Convert.ToInt32(lector["fkAsignacion_modalidad"]).ToString();

                                if (idAsignacion_modalidad == "1")
                                {
                                    idGrup = "noAto";
                                }
                                else if (idAsignacion_modalidad == "2")
                                {
                                    ObtenerIdGrupo();
                                }

                                nombre = lector["nombre"].ToString();
                                int calificacion_ = Convert.ToInt32(lector["calificacion"]);
                                calificacion = calificacion_.ToString();
                                int nota_ = (int)Convert.ToDecimal(lector["nota"]);
                                nota = nota_.ToString();


                                var miniatura = new UC_AsignacionCalificaciones(idCurso, idCred, idSemana, idAsignacion, idCred, idAsignacion_x_Grup, idGrup, idAsignacion_x_Est_O_Grup, idAsignacion_modalidad, nombre, calificacion, nota);

                                listaAsignaciones.Controls.Add(miniatura);
                            }
                        }
                    }
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Error en el método 'RellenarVistaTareas': " + ex.ToString());
            }
        }

        public void RellenarVistaLaboratorios()
        {
            try
            {
                listaAsignaciones.Controls.Clear();
                int contador = 0;

                using (SqlConnection conexion = new SqlConnection($"server={Logins.ObtenerInstancia().nombreServidor}; database =GestorAcademico; integrated security = true"))
                {
                    conexion.Open();

                    string consulta = @"SELECT
		                                a.nombre,
                                        a.idAsignacion,
                                        a.fkAsignacion_modalidad,
                                        ae.idAsignacion_x_Estudiante AS idAsignacion_x_Est_O_Grup,
                                        COALESCE(ae.calificacion, 0) AS calificacion,
                                        a.nota,
                                        ae.fkSemana
                                    FROM
                                        Asignacion_x_Estudiante ae
                                        JOIN Asignacion a ON ae.fkAsignacion = a.idAsignacion
                                    WHERE
                                        ae.fkUsuario = @idCred
                                        AND a.fkCurso = @idCurso
                                        AND a.fkAsignacion_tipo = 2

                                    UNION ALL

                                    SELECT
		                                a.nombre,
                                        a.idAsignacion,
                                        a.fkAsignacion_modalidad,
                                        ag.idAsignacion_x_Grupo,
                                        COALESCE(ag.calificacion, 0) AS calificacion,
                                        a.nota,
                                        ag.fkSemana
                                    FROM
                                        Asignacion_x_Grupo ag
                                        JOIN Asignacion a ON ag.fkAsignacion = a.idAsignacion
                                        JOIN Usuario_x_Grupo ug ON ag.fkGrupo = ug.fkGrupo 
                                    WHERE
                                        ug.fkUsuario = @idCred 
                                        AND a.fkCurso = @idCurso
                                        AND a.fkAsignacion_tipo = 2";

                    using (SqlCommand comando = new SqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@idCred", idCred);
                        comando.Parameters.AddWithValue("@idCurso", idCurso);

                        using (SqlDataReader lector = comando.ExecuteReader())
                        {
                            while (lector.Read())
                            {
                                contador++;

                                idSemana = Convert.ToInt32(lector["fkSemana"]).ToString();
                                idAsignacion = Convert.ToInt32(lector["idAsignacion"]).ToString();
                                idAsignacion_x_Est_O_Grup = Convert.ToInt32(lector["idAsignacion_x_Est_O_Grup"]).ToString();
                                idAsignacion_modalidad = Convert.ToInt32(lector["fkAsignacion_modalidad"]).ToString();

                                if (idAsignacion_modalidad == "1")
                                {
                                    idGrup = "noAto";
                                }
                                else if (idAsignacion_modalidad == "2")
                                {
                                    ObtenerIdGrupo();
                                }

                                nombre = lector["nombre"].ToString();
                                int calificacion_ = Convert.ToInt32(lector["calificacion"]);
                                calificacion = calificacion_.ToString();
                                int nota_ = (int)Convert.ToDecimal(lector["nota"]);
                                nota = nota_.ToString();


                                var miniatura = new UC_AsignacionCalificaciones(idCurso, idCred, idSemana, idAsignacion, idCred, idAsignacion_x_Grup, idGrup, idAsignacion_x_Est_O_Grup, idAsignacion_modalidad, nombre, calificacion, nota);

                                listaAsignaciones.Controls.Add(miniatura);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en el método 'RellenarVistaLaboratorios': " + ex.ToString());
            }
        }

        public void RellenarVistaProyecto()
        {
            try
            {
                listaAsignaciones.Controls.Clear();
                int contador = 0;

                using (SqlConnection conexion = new SqlConnection($"server={Logins.ObtenerInstancia().nombreServidor}; database =GestorAcademico; integrated security = true"))
                {
                    conexion.Open();

                    string consulta = @"SELECT
		                                a.nombre,
                                        a.idAsignacion,
                                        a.fkAsignacion_modalidad,
                                        ae.idAsignacion_x_Estudiante AS idAsignacion_x_Est_O_Grup,
                                        COALESCE(ae.calificacion, 0) AS calificacion,
                                        a.nota,
                                        ae.fkSemana
                                    FROM
                                        Asignacion_x_Estudiante ae
                                        JOIN Asignacion a ON ae.fkAsignacion = a.idAsignacion
                                    WHERE
                                        ae.fkUsuario = @idCred
                                        AND a.fkCurso = @idCurso
                                        AND a.fkAsignacion_tipo = 3

                                    UNION ALL

                                    SELECT
		                                a.nombre,
                                        a.idAsignacion,
                                        a.fkAsignacion_modalidad,
                                        ag.idAsignacion_x_Grupo,
                                        COALESCE(ag.calificacion, 0) AS calificacion,
                                        a.nota,
                                        ag.fkSemana
                                    FROM
                                        Asignacion_x_Grupo ag
                                        JOIN Asignacion a ON ag.fkAsignacion = a.idAsignacion
                                        JOIN Usuario_x_Grupo ug ON ag.fkGrupo = ug.fkGrupo 
                                    WHERE
                                        ug.fkUsuario = @idCred 
                                        AND a.fkCurso = @idCurso
                                        AND a.fkAsignacion_tipo = 3";

                    using (SqlCommand comando = new SqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@idCred", idCred);
                        comando.Parameters.AddWithValue("@idCurso", idCurso);

                        using (SqlDataReader lector = comando.ExecuteReader())
                        {
                            while (lector.Read())
                            {
                                contador++;

                                idSemana = Convert.ToInt32(lector["fkSemana"]).ToString();
                                idAsignacion = Convert.ToInt32(lector["idAsignacion"]).ToString();
                                idAsignacion_x_Est_O_Grup = Convert.ToInt32(lector["idAsignacion_x_Est_O_Grup"]).ToString();
                                idAsignacion_modalidad = Convert.ToInt32(lector["fkAsignacion_modalidad"]).ToString();

                                if (idAsignacion_modalidad == "1")
                                {
                                    idGrup = "noAto";
                                }
                                else if (idAsignacion_modalidad == "2")
                                {
                                    ObtenerIdGrupo();
                                }

                                nombre = lector["nombre"].ToString();
                                int calificacion_ = Convert.ToInt32(lector["calificacion"]);
                                calificacion = calificacion_.ToString();
                                int nota_ = (int)Convert.ToDecimal(lector["nota"]);
                                nota = nota_.ToString();


                                var miniatura = new UC_AsignacionCalificaciones(idCurso, idCred, idSemana, idAsignacion, idCred, idAsignacion_x_Grup, idGrup, idAsignacion_x_Est_O_Grup, idAsignacion_modalidad, nombre, calificacion, nota);

                                listaAsignaciones.Controls.Add(miniatura);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en el método 'RellenarVistaProyecto': " + ex.ToString());
            }
        }

        public void RellenarVistaAsistencia()
        {
            try
            {
                listaAsignaciones.Controls.Clear();
                int contador = 0;

                using (SqlConnection conexion = new SqlConnection($"server={Logins.ObtenerInstancia().nombreServidor}; database =GestorAcademico; integrated security = true"))
                {
                    conexion.Open();

                    string consulta = @"SELECT fkSemana, fkAsistencia_estado FROM Asistencia WHERE fkUsuario = @idCred and fkCurso = @idCurso ORDER BY fkSemana ASC";

                    using (SqlCommand comando = new SqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@idCred", idCred);
                        comando.Parameters.AddWithValue("@idCurso", idCurso);

                        using (SqlDataReader lector = comando.ExecuteReader())
                        {
                            while (lector.Read())
                            {
                                contador++;

                                string semana = Convert.ToInt32(lector["fkSemana"]).ToString();
                                int AsistenciaEstado = Convert.ToInt32(lector["fkAsistencia_estado"]);


                                var miniatura = new UC_AsistenciaCalificaciones(semana, AsistenciaEstado);

                                listaAsignaciones.Controls.Add(miniatura);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en el método 'RellenarVistaAsistencia': " + ex.ToString());
            }
        }
    }
}