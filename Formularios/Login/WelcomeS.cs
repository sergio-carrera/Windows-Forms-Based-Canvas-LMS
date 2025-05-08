using Proyecto_GestionAcademica_Grupo05.Formularios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_GestionAcademica_Grupo05
{
    public partial class WelcomeS : Form {
        public WelcomeS() {
            InitializeComponent();
        }

        //Evento que abre el formulario para entrar al programa como estudiante
        private void BtnEstudiantes_Click(object sender, EventArgs e) {
            this.Hide();
            LogInEstudiantes logInEstudiantes = new LogInEstudiantes();
            logInEstudiantes.Show();
        
        }

        //Evento que abre el formulario para entrar al programa como profesor
        private void BtnProfesores_Click(object sender, EventArgs e) {
            this.Hide();
            LogInProfesores logInProfesores = new LogInProfesores();
            logInProfesores.Show();
        }
    }
    }

