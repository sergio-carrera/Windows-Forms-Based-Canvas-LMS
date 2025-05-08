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

namespace LogIn2.Formularios
{
    public partial class LogInEstudiantes : Form

    {
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
            

            SqlConnection conexion = new SqlConnection("server= DESKTOP-FABIAN0; database=LogInEstudiantes ; integrated security = true");
            conexion.Open();


            string verificarE = "SELECT COUNT(*) FROM LogIn WHERE Correo_Elec = @CorreoElec AND Contraseña_E = @Contraseña_E";

            using (SqlCommand cmd = new SqlCommand(verificarE, conexion))
            {
                cmd.Parameters.AddWithValue("@CorreoElec", textBoxCorreoElec.Text);
                cmd.Parameters.AddWithValue("@Contraseña_E", textBoxCont.Text);

                int count = (int)cmd.ExecuteScalar();
                

                if (count > 0)
                {
                    MessageBox.Show("Inicio de sesión exitoso");  // El usuario y la contraseña son válidos.
                }
                else
                {
                    MessageBox.Show("Credenciales incorrectas, favor intentar de nuevo");  // Usuario o contraseña incorrectos.
                }
            }
        }
    }
}

            
        
    

