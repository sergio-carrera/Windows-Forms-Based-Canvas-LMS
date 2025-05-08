using Proyecto_GestionAcademica_Grupo05.Formularios.Estudiante.FormularioHijo1;
using Proyecto_GestionAcademica_Grupo05.Formularios.Estudiante.FormularioHijo1.Curso;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_GestionAcademica_Grupo05.Formularios.Estudiante.Curso.btnCalificaciones_estudiante
{
    public partial class UC_AsignacionCalificaciones : UserControl
    {
        public string idCurso;
        public string idUsuario;
        public string idSemana;
        public string idAsignacion;
        public string idCred;
        public string idAsignacion_x_Grup;
        public string idGrupo;
        public string idAsignacion_x_Est_O_Grup;
        public string idAsignacion_modalidad;
        public string nombre;
        public string calificacion;
        public string nota;

        public string idAsignacion_tipo;

        //Controlar fechas
        DateTime fechaLimite;
        DateTime fechaEntrega;

        public UC_AsignacionCalificaciones(string idCurso, string idUsuario, string idSemana, string idAsignacion, string idCred, string idAsignacion_x_Grup, string idGrup, string idAsignacion_x_Est_O_Grup, string idAsignacion_modalidad, string nombre, string calificacion, string nota)
        {
            InitializeComponent();
            this.idCurso = idCurso;
            this.idUsuario = idUsuario;
            this.idSemana = idSemana;
            this.idAsignacion = idAsignacion;
            this.idCred = idCred;
            this.idAsignacion_x_Grup = idAsignacion_x_Grup;
            this.idGrupo = idGrup;
            this.idAsignacion_x_Est_O_Grup = idAsignacion_x_Est_O_Grup;
            this.idAsignacion_modalidad = idAsignacion_modalidad;
            this.nombre = nombre;
            this.calificacion = calificacion;
            this.nota = nota;
            pbEstado.Visible = false;
            ObtenerFecha();
            ObtenerFechaEntrega();
            ObtenerAsignacion_tipo();

            lblNombre.Text = nombre;
            lblPuntaje.Text = calificacion + " / " + nota;
        }

        public void ObtenerFecha()
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection($"server={Logins.ObtenerInstancia().nombreServidor}; database =GestorAcademico; integrated security = true"))
                {
                    conexion.Open();
                    string consulta = "SELECT fecha_limite FROM Asignacion WHERE idAsignacion =" + idAsignacion;

                    using (SqlCommand comando = new SqlCommand(consulta, conexion))
                    {
                        using (SqlDataReader lector = comando.ExecuteReader())
                        {
                            while (lector.Read())
                            {
                                DateTime fecha = lector.GetDateTime(0);
                                fechaLimite = fecha;

                                string fechaFormateada = fecha.ToString("dddd d 'de' MMM", new CultureInfo("es-ES")).ToLower().TrimEnd('.');
                                lblFechaEntrega.Text = fechaFormateada;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en el método 'ObtenerFecha': " + ex.ToString());
            }
        }

        public void ObtenerFechaEntrega()
        {
            try
            {
                if (idAsignacion_modalidad == "1")
                {
                    using (SqlConnection conexion = new SqlConnection($"server={Logins.ObtenerInstancia().nombreServidor}; database =GestorAcademico; integrated security = true"))
                    {
                        conexion.Open();
                        string consulta = "SELECT fecha_entrega FROM Asignacion_x_Estudiante WHERE fkUsuario = @fkUsuario AND fkAsignacion = @fkAsignacion";

                        using (SqlCommand comando = new SqlCommand(consulta, conexion))
                        {
                            comando.Parameters.AddWithValue("@fkUsuario", idCred);
                            comando.Parameters.AddWithValue("@fkAsignacion", idAsignacion);
                            using (SqlDataReader lector = comando.ExecuteReader())
                            {
                                while (lector.Read())
                                {
                                    if (!lector.IsDBNull(0)) // Verificar si el valor en la columna es nulo
                                    {
                                        DateTime fecha = lector.GetDateTime(0);

                                        fechaEntrega = fecha;

                                        if (fechaLimite > fechaEntrega)
                                        {
                                            lblEstado.Text = "Entregado a tiempo";
                                        }
                                        else if (fechaLimite < fechaEntrega)
                                        {
                                            lblEstado.Text = "Entregado tarde";
                                        }
                                        else if (fechaLimite == fechaEntrega)
                                        {
                                            lblEstado.Text = "Entregado a tiempo";
                                        }
                                        else
                                        {
                                            lblEstado.Visible = false;
                                            pbEstado.Visible = true;
                                        }
                                    }
                                    else
                                    {
                                        lblEstado.Visible = false;
                                        pbEstado.Visible = true;
                                    }
                                }
                            }
                        }
                    }
                }
                else if (idAsignacion_modalidad == "2")
                {
                    using (SqlConnection conexion = new SqlConnection($"server={Logins.ObtenerInstancia().nombreServidor}; database =GestorAcademico; integrated security = true"))
                    {
                        conexion.Open();
                        string consulta = "SELECT fecha_entrega FROM Asignacion_x_Grupo WHERE fkAsignacion = @fkAsignacion AND fkGrupo = @fkGrupo";

                        using (SqlCommand comando = new SqlCommand(consulta, conexion))
                        {
                            comando.Parameters.AddWithValue("@fkAsignacion", idAsignacion);
                            comando.Parameters.AddWithValue("@fkGrupo", idGrupo);
                            using (SqlDataReader lector = comando.ExecuteReader())
                            {
                                while (lector.Read())
                                {
                                    if (!lector.IsDBNull(0)) // Verificar si el valor en la columna es nulo
                                    {
                                        DateTime fecha = lector.GetDateTime(0);

                                        fechaEntrega = fecha;

                                        if (fechaLimite > fechaEntrega)
                                        {
                                            lblEstado.Text = "Entregado a tiempo";
                                        }
                                        else if (fechaLimite < fechaEntrega)
                                        {
                                            lblEstado.Text = "Entregado tarde";
                                        }
                                        else if (fechaLimite == fechaEntrega)
                                        {
                                            lblEstado.Text = "Entregado a tiempo";
                                        }
                                        else
                                        {                                          
                                            lblEstado.Visible = false;
                                            pbEstado.Visible = true;
                                        }
                                    }
                                    else
                                    {
                                        lblEstado.Visible = false;
                                        pbEstado.Visible = true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en el método 'ObtenerFechaEntrega': " + ex.ToString());
            }
        }

        private void ObtenerAsignacion_tipo()
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
                MessageBox.Show("Mensaje de error para el método 'ObtenerAsignacion_tipo' " + ex.ToString());
            }
        }

        private void lblNombre_Click(object sender, EventArgs e)
        {
            Form VistaYEntregaAsignacion = new VistaYEntregaAsignacion(idCred, idCurso, idSemana, idAsignacion, idAsignacion_tipo, idAsignacion_modalidad, idAsignacion_x_Est_O_Grup);

            CursoInicio cursoInicio = Application.OpenForms.OfType<CursoInicio>().FirstOrDefault();

            cursoInicio.AbrirFormHijo(VistaYEntregaAsignacion);
        }
    }
}
