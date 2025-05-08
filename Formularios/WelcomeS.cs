using LogIn2.Formularios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogIn2
{
    public partial class WelcomeS : Form {


        public WelcomeS() {
            InitializeComponent();
        }


        private void BtnEstudiantes_Click(object sender, EventArgs e) {
            this.Hide();
            LogInEstudiantes logInEstudiantes = new LogInEstudiantes();
            logInEstudiantes.Show();
        
        }

        private void BtnProfesores_Click(object sender, EventArgs e) {
            this.Hide();
            LogInProfesores logInProfesores = new LogInProfesores();
            logInProfesores.Show();
        }
    }
    }

