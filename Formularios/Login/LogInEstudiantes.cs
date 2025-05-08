using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Proyecto_GestionAcademica_Grupo05.Formularios
{
    public partial class LogInEstudiantes : Form
    {
        public string idCredencial;
        public LogInEstudiantes()
        {
            InitializeComponent();
        }

        private void LogInEstudiantes_Load(object sender, EventArgs e)
        {
            CentrarPanel();
        }

        private void CentrarPanel()
        {
            int X = (this.Width - panelAgruparLogin.Width) / 2;
            int Y = 264;
            panelAgruparLogin.Location = new Point(X, Y);
        }

        private void buttonReverse_Click(object sender, EventArgs e)
        {
            this.Close();
            WelcomeS welcomeS = new WelcomeS();
            welcomeS.Show();

        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            SqlConnection conexion = new SqlConnection($"server={Logins.ObtenerInstancia().nombreServidor}; database =GestorAcademico; integrated security = true");
            conexion.Open();

            string verificarE = "SELECT COUNT(*) FROM Credencial WHERE correo = @CorreoElec AND contrasenna = @Contraseña_E AND fkCredencialTipo = 2";

            using (SqlCommand cmd = new SqlCommand(verificarE, conexion))
            {
                cmd.Parameters.AddWithValue("@CorreoElec", textBoxCorreoElec.Text);
                cmd.Parameters.AddWithValue("@Contraseña_E", textBoxCont.Text);

                int count = (int)cmd.ExecuteScalar();
                
                if (count > 0)
                {
                    try
                    {
                        //Ejecutar una nueva consulta para obtener cred_id
                        string obtenerCredIdQuery = "SELECT idCredencial FROM Credencial WHERE correo = @CorreoElec";
                        using (SqlCommand obtenerCredIdCmd = new SqlCommand(obtenerCredIdQuery, conexion))
                        {
                            obtenerCredIdCmd.Parameters.AddWithValue("@CorreoElec", textBoxCorreoElec.Text);
                            int cred_id = (int)obtenerCredIdCmd.ExecuteScalar();

                            //Ahora tienes el valor cred_id
                            idCredencial = cred_id.ToString();
                        }

                        MenuPrincipalEstudiante menuPrincipalEstudiante = new MenuPrincipalEstudiante(idCredencial);
                        menuPrincipalEstudiante.Show();
                        this.Hide();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
                else
                {
                    MessageBox.Show("Credenciales incorrectas, favor intentar de nuevo");  // Usuario o contraseña incorrectos.
                }
            }
            conexion.Close();
        }
    }
}