using Proyecto_GestionAcademica_Grupo05.Formularios.Estudiante.Curso.btnPersonas;
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

namespace Proyecto_GestionAcademica_Grupo05.Formularios.Estudiante.FormularioHijo1.Curso.btnPersonas
{
    public partial class UC_Grupo : UserControl
    {
        public string idCred;
        public string idCurso;
        public string nombreGrupo; 

        public UC_Grupo(string idCred, string idCurso, string nombreGrupo)
        {
            InitializeComponent();
            this.idCred = idCred;
            this.idCurso = idCurso;
            this.nombreGrupo = nombreGrupo;
            flpIntegrantes.Visible = false;
            lblGrupo.Text = nombreGrupo;
            obtenerInfoGrupo();
            RellenarVista();
        }

        public void obtenerInfoGrupo()
        {
            try
            {
                SqlConnection con = new SqlConnection($"server={Logins.ObtenerInstancia().nombreServidor}; database =GestorAcademico; integrated security = true");
                con.Open();
                string cadena = @"SELECT g.nombreGrupo, COUNT(ug.fkUsuario) AS CantidadPersonas
                                FROM Grupo g
                                JOIN Usuario_x_Grupo ug ON g.idGrupo = ug.fkGrupo
                                WHERE g.nombreGrupo = @nombreGrupo
                                AND g.fkCurso = @idCurso
                                GROUP BY g.nombreGrupo;";

                SqlCommand comando = new SqlCommand(cadena, con);
                comando.Parameters.AddWithValue("@nombreGrupo", nombreGrupo);
                comando.Parameters.AddWithValue("@idCurso", idCurso);
                SqlDataReader lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    int cantidadPersonas = lector.GetInt32(lector.GetOrdinal("CantidadPersonas"));
                    lblCantidadEst.Text = $"{cantidadPersonas} estudiantes"; 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en el método 'obtenerInfoGrupo': " + ex.ToString());
            }
        }

        //Método para agregar a los integrantes del grupo
        public void RellenarVista()
        {
            try
            {
                int cont = 0;
                SqlConnection con = new SqlConnection($"server={Logins.ObtenerInstancia().nombreServidor}; database =GestorAcademico; integrated security = true");
                con.Open();
                string cadena = @"SELECT UPPER(CONCAT(u.nombre, ' ', u.apellido1, ' ', u.apellido2)) AS NombreCompletoEnMayusculas
                                FROM Usuario u
                                JOIN Usuario_x_Grupo ug ON u.idUsuario = ug.fkUsuario
                                JOIN Grupo g ON ug.fkGrupo = g.idGrupo
                                WHERE g.nombreGrupo = @nombreGrupo
                                AND g.fkCurso = @idCurso;";     

                SqlCommand comando = new SqlCommand(cadena, con);
                comando.Parameters.AddWithValue("@nombreGrupo", nombreGrupo);
                comando.Parameters.AddWithValue("@idCurso", idCurso);
                SqlDataReader lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    string nombreCompleto = lector.GetString(0);
                    cont++;
                    var miniatura = new UC_IntegranteGrupo(nombreCompleto);
                    flpIntegrantes.Controls.Add(miniatura);
                }
            }
            catch(Exception ex) 
            {
                MessageBox.Show("Error en el método 'RellenarVista': " + ex.ToString());
            }
        }

        private void lblGrupo_Click_1(object sender, EventArgs e)
        {
            try
            {
                foreach (Control control in flpIntegrantes.Controls)
                {
                    if (control is FlowLayoutPanel && control != flpIntegrantes)
                    {
                        control.Visible = false;
                    }
                }
                flpIntegrantes.Visible = !flpIntegrantes.Visible;
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Error en el evento 'lblGrupo_Click_1': " + ex.ToString());
            }
        }
    }
}
