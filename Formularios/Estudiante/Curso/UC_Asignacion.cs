using Proyecto_GestionAcademica_Grupo05.Formularios.Profesor.Curso_profesor;
using Proyecto_GestionAcademica_Grupo05.Formularios.Profesor.Curso_profesor.btnAsignaciones_profesor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_GestionAcademica_Grupo05.Formularios.Estudiante.FormularioHijo1.Curso
{
    public partial class UC_Asignacion : UserControl
    {
        public string idCurso;
        //Estudiante o profesor
        public string idUsuario;
        public string idSemana;
        public string idAsignacion;
        public string idCred;
        public string idAsignacion_tipo;
        public string idAsignacion_modalidad;
        public string idAsignacion_X_Est_Grup;

        //public string idAsignacion_x_Grup;
        public string idGrup;

        public string idCredTipo;
        public UC_Asignacion(string idCurso, string idUsuario, string idSemana, string idAsignacion, string idCred, string idAsignacion_x_Grup, string idGrup)
        {
            InitializeComponent();
            this.idCurso = idCurso;
            this.idUsuario = idUsuario;
            this.idSemana = idSemana;
            this.idAsignacion = idAsignacion;
            this.idCred = idCred;
            //this.idAsignacion_x_Grup = idAsignacion_x_Grup;
            this.idGrup = idGrup;
            obtenerNombreAsignacion();
            obtenerFechaYPuntosAsignacion();
            obtenerCredencialTipo();
            obtenerAsignacion_tipo();
            obtenerAsignacion_modalidad();
            obtenerAsignacionXEst_Grup();
        }

        //Método para obtener y asignar el nombre del curso al label respectivo (lblNombreAsignacion)
        private void obtenerNombreAsignacion()
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection($"server={Logins.ObtenerInstancia().nombreServidor}; database =GestorAcademico; integrated security = true"))
                {
                    conexion.Open();
                    string consulta = "SELECT nombre FROM Asignacion WHERE idAsignacion =" + idAsignacion;

                    using (SqlCommand comando = new SqlCommand(consulta, conexion))
                    {
                        using (SqlDataReader lector = comando.ExecuteReader())
                        {
                            while (lector.Read())
                            {
                                string nombreAsignacion = lector.GetString(0);
                                lblNombreAsignacion.Text = nombreAsignacion;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error en el método 'obtenerNombreAsignacion': " + ex.ToString());
            }
        }

        /*
        Método para obtener y asignar la fecha (convertida al formato correspondiente) y los puntos
        de la asignación al label respectivo (lblFechaYPuntos)
        */
        private void obtenerFechaYPuntosAsignacion()
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection($"server={Logins.ObtenerInstancia().nombreServidor}; database =GestorAcademico; integrated security = true"))
                {
                    conexion.Open();
                    string consulta = "SELECT fecha_limite, nota FROM Asignacion WHERE idAsignacion =" + idAsignacion;

                    using (SqlCommand comando = new SqlCommand(consulta, conexion))
                    {
                        using (SqlDataReader lector = comando.ExecuteReader())
                        {
                            while (lector.Read())
                            {
                                DateTime fecha = lector.GetDateTime(0); 
                                decimal nota = lector.GetDecimal(1);    

                                string fechaFormateada = fecha.ToString("d 'de' MMM").ToLower().TrimEnd('.');
                                string notaFormateada = nota.ToString("0 pts");

                                string resultado = $"{fechaFormateada} | {notaFormateada}";

                                lblFechaYPuntos.Text = resultado;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en el método 'obtenerFechaYPuntosAsignacion': " + ex.ToString());
            }
        }

        private void obtenerCredencialTipo()
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection($"server={Logins.ObtenerInstancia().nombreServidor}; database =GestorAcademico; integrated security = true"))
                {
                    conexion.Open();
                    string consulta = "SELECT fkCredencialTipo FROM Credencial WHERE idCredencial =" + idCred;

                    using (SqlCommand comando = new SqlCommand(consulta, conexion))
                    {
                        using (SqlDataReader lector = comando.ExecuteReader())
                        {
                            while (lector.Read())
                            {
                                int idCredencialTipo = lector.GetInt32(0);
                                idCredTipo = idCredencialTipo.ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error en el método 'obtenerCredencialTipo': " + ex.ToString());
            }
        }

        private void obtenerAsignacion_tipo()
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection($"server={Logins.ObtenerInstancia().nombreServidor}; database =GestorAcademico; integrated security = true"))
                {
                    conexion.Open();
                    string consulta = "SELECT fkAsignacion_tipo FROM Asignacion WHERE idAsignacion =" + idAsignacion;

                    using (SqlCommand comando = new SqlCommand(consulta, conexion))
                    {
                        using (SqlDataReader lector = comando.ExecuteReader())
                        {
                            while (lector.Read())
                            {
                                int idAsignacion_tipo_ = lector.GetInt32(0);
                                idAsignacion_tipo = idAsignacion_tipo_.ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Mensaje de error para el método 'obtenerAsignacion_tipo' " + ex.ToString());
            }
        }
        
        private void obtenerAsignacion_modalidad()
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection($"server={Logins.ObtenerInstancia().nombreServidor}; database =GestorAcademico; integrated security = true"))
                {
                    conexion.Open();
                    string consulta = "SELECT fkAsignacion_modalidad FROM Asignacion WHERE idAsignacion =" + idAsignacion;

                    using (SqlCommand comando = new SqlCommand(consulta, conexion))
                    {
                        using (SqlDataReader lector = comando.ExecuteReader())
                        {
                            while (lector.Read())
                            {
                                int idAsignacion_modalidad_ = lector.GetInt32(0);
                                idAsignacion_modalidad = idAsignacion_modalidad_.ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Mensaje de error para el método 'obtenerAsignacion_modalidad' " + ex.ToString());
            }
        }
        
        private void obtenerAsignacionXEst_Grup()
        {
            try
            {
                if (idAsignacion_modalidad.ToString() == "1")
                {
                    using (SqlConnection conexion = new SqlConnection($"server={Logins.ObtenerInstancia().nombreServidor}; database =GestorAcademico; integrated security = true"))
                    {
                        conexion.Open();
                        string consulta = "SELECT idAsignacion_x_Estudiante FROM Asignacion_x_Estudiante WHERE fkAsignacion =" + idAsignacion + "AND fkUsuario =" + idCred;

                        using (SqlCommand comando = new SqlCommand(consulta, conexion))
                        {
                            using (SqlDataReader lector = comando.ExecuteReader())
                            {
                                while (lector.Read())
                                {
                                    int idAsignacion_X_Est_Grup_ = lector.GetInt32(0);
                                    idAsignacion_X_Est_Grup = idAsignacion_X_Est_Grup_.ToString();
                                }
                            }
                        }
                    }
                    //MessageBox.Show("Es una asignación Individual: " + idAsignacion_X_Est_Grup);
                }
                else if (idAsignacion_modalidad.ToString() == "2")
                {
                    using (SqlConnection conexion = new SqlConnection($"server={Logins.ObtenerInstancia().nombreServidor}; database =GestorAcademico; integrated security = true"))
                    {
                        conexion.Open();
                        string consulta = "SELECT idAsignacion_x_Grupo FROM Asignacion_x_Grupo WHERE fkAsignacion =" + idAsignacion + "AND fkGrupo =" + idGrup;

                        using (SqlCommand comando = new SqlCommand(consulta, conexion))
                        {
                            using (SqlDataReader lector = comando.ExecuteReader())
                            {
                                while (lector.Read())
                                {
                                    int idAsignacion_X_Est_Grup_ = lector.GetInt32(0);
                                    idAsignacion_X_Est_Grup = idAsignacion_X_Est_Grup_.ToString();
                                }
                            }
                        }
                    }
                    //MessageBox.Show("Es una asignación Grupal: " + idAsignacion_X_Est_Grup);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Mensaje de error para el método 'obtenerAsignacionXEst_Grup' " + ex.ToString());
            }
        }
        
        //Abrir formulario "VistaYEntregaAsignacion"
        private void lblNombreAsignacion_Click(object sender, EventArgs e)
        {
            if (idCredTipo.ToString() == "2")
            {
                Form VistaYEntregaAsignacion = new VistaYEntregaAsignacion(idCred, idCurso, idSemana, idAsignacion, idAsignacion_tipo, idAsignacion_modalidad, idAsignacion_X_Est_Grup);

                CursoInicio cursoInicio = Application.OpenForms.OfType<CursoInicio>().FirstOrDefault();

                cursoInicio.AbrirFormHijo(VistaYEntregaAsignacion);

            }
            else if (idCredTipo.ToString() == "1")
            {
                Form VistaYCalificacionAsignacion = new VistaYCalificacionAsignacion(idCred, idCurso, idAsignacion, idAsignacion_tipo, idAsignacion_modalidad, idAsignacion_X_Est_Grup);

                CursoInicioProf cursoInicioProf = Application.OpenForms.OfType<CursoInicioProf>().FirstOrDefault();

                cursoInicioProf.AbrirFormHijo(VistaYCalificacionAsignacion);

            }
        }
    }
}
