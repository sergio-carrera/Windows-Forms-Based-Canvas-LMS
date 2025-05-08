using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_GestionAcademica_Grupo05.Formularios.Profesor.Curso_profesor.btnAsignaciones_profesor
{
    public partial class VistaYCalificacionAsignacion : Form
    {
        private Form formHijoActual;

        public string idCred;
        public string idCurso;
        public string idAsignacion;
        public string idAsignacion_tipo;
        public string idAsignacion_modalidad;
        public string idAsignacion_X_Est_Grup;

        public VistaYCalificacionAsignacion(string idCred, string idCurso, string idAsignacion, string idAsignacion_tipo, string idAsignacion_modalidad, string idAsignacion_X_Est_Grup)
        {
            InitializeComponent();
            this.idCred = idCred;
            this.idCurso = idCurso;
            this.idAsignacion = idAsignacion;
            this.idAsignacion_tipo = idAsignacion_tipo;
            this.idAsignacion_modalidad = idAsignacion_modalidad;
            this.idAsignacion_X_Est_Grup = idAsignacion_X_Est_Grup;
            if (idAsignacion_modalidad == "1")
            {
                //Inidividual
                RellenarComboBoxInd();
            }
            else if (idAsignacion_modalidad == "2")
            {
                //Grupal
                RellenarComboBoxGrup();
            }
            else
            {
                MessageBox.Show("No se ha obtenido un 'idAsignacion_modalidad' correcto");
            }        
        }

        //Rellenar el comboBox con todos los estudiantes del curso 
        public void RellenarComboBoxInd()
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection($"server={Logins.ObtenerInstancia().nombreServidor}; database =GestorAcademico; integrated security = true"))
                {
                    conexion.Open();
                    string consulta = @"SELECT 
                                            u.nombre, 
                                            u.apellido1, 
                                            u.apellido2
                                        FROM 
                                            Usuario u
                                        JOIN 
                                            Credencial c ON u.fkCredencial = c.idCredencial
                                        JOIN 
                                            CredencialTipo ct ON c.fkCredencialTipo = ct.idCredencialTipo
                                        JOIN 
                                            Asignacion_x_Estudiante ae ON u.idUsuario = ae.fkUsuario
                                        WHERE 
                                            ct.idCredencialTipo = 2
                                        AND 
	                                        ae.fkAsignacion = @idAsignacion
                                        ORDER BY
                                            u.apellido1;";

                    using (SqlCommand comando = new SqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@idAsignacion", idAsignacion);
                        using (SqlDataReader lector = comando.ExecuteReader()) 
                        {
                            while (lector.Read())
                            {
                                string nombreCompleto = $"{lector["nombre"]} {lector["apellido1"]} {lector["apellido2"]}";
                                comboBox.Items.Add(nombreCompleto);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en el método 'RellenarComboBoxInd': " + ex.ToString());
            }
        }

        //Rellenar el comboBox con todos los grupos del curso 
        public void RellenarComboBoxGrup()
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection($"server={Logins.ObtenerInstancia().nombreServidor}; database =GestorAcademico; integrated security = true"))
                {
                    conexion.Open();
                    string consulta = @"SELECT
                                            g.nombreGrupo 
                                        FROM
                                            Grupo g
                                        JOIN
                                            Asignacion_x_Grupo ag ON g.idGrupo = ag.fkGrupo
                                        JOIN
                                            Asignacion a ON ag.fkAsignacion = a.idAsignacion
                                        JOIN
                                            Curso c ON a.fkCurso = c.idCurso
                                        WHERE
                                            c.idCurso = @idCurso
                                        AND
	                                        a.idAsignacion = @idAsignacion
                                        ORDER BY
	                                        g.nombreGrupo;";

                    using (SqlCommand comando = new SqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@idCurso", idCurso);
                        comando.Parameters.AddWithValue("@idAsignacion", idAsignacion);
                        using (SqlDataReader lector = comando.ExecuteReader())
                        {
                            while (lector.Read())
                            {
                                string nombreGrupo = $"{lector["nombreGrupo"]}";
                                comboBox.Items.Add(nombreGrupo);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en el método 'RellenarComboBoxGrup': " + ex.ToString());
            }
        }

        public void AbrirFormHijo(Form formHijo)
        {
            try
            {
                if (formHijoActual != null)
                {
                    //abrir unico formulario 
                    formHijoActual.Close();
                }
                formHijoActual = formHijo;
                formHijo.TopLevel = false;
                formHijo.FormBorderStyle = FormBorderStyle.None;
                formHijo.Dock = DockStyle.Fill;
                panelSecundario.Controls.Add(formHijoActual);
                panelSecundario.Tag = formHijo;
                formHijo.BringToFront();
                formHijo.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnConsultarEntrega_Click(object sender, EventArgs e)
        {
            string nombreEst_O_Grup = comboBox.SelectedItem as string;

            if (!string.IsNullOrEmpty(nombreEst_O_Grup))
            {
                AbrirFormHijo(new CalificarAsignacion(nombreEst_O_Grup, idCred, idCurso, idAsignacion, idAsignacion_tipo, idAsignacion_modalidad, idAsignacion_X_Est_Grup));
            }
            else
            {
                MessageBox.Show("Por favor, selecciona una opción antes de proceder.");
            }
        }
    }
}
