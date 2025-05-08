using Proyecto_GestionAcademica_Grupo05.Formularios.Profesor.Curso_profesor.btnAsignaciones_profesor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_GestionAcademica_Grupo05.Formularios.Profesor.Curso_profesor.btnAsistencia
{
    public partial class CursoAsistencia : Form
    {
        public string idCred;
        public string idCurso;

        //Valor global para pasar al formulario "PasarAsistencia"
        public string idSemana;

        private Form formHijoActual;

        /*
        El comboBox que almacena las semanas ya está llenado de manera 
        manual, porque siempre van a ser 15 semanas.
        */
        public CursoAsistencia(string idCred, string idCurso)
        {
            InitializeComponent();
            this.idCred = idCred;
            this.idCurso = idCurso;
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

        /*
        Método que obtiene la semana y abre el formulario para pasar asistencia 
        en dicha semana
        */
        private void btnActualizarSemana_Click(object sender, EventArgs e)
        {
            string semana = comboBox.SelectedItem as string;

            if (semana != null && semana.StartsWith("Semana "))
            {
                string numeroSemana = semana.Substring(7); 

                if (int.TryParse(numeroSemana, out int numero))
                {
                    idSemana = numero.ToString();
                }
                else
                {
                    MessageBox.Show("Número de semana no válido");
                }
            }
            else
            {
                Console.WriteLine("Semana no válida");
            }

            if (!string.IsNullOrEmpty(semana))
            {
                AbrirFormHijo(new PasarAsistencia(idCred, idCurso, idSemana));
            }
            else
            {
                MessageBox.Show("Por favor, selecciona una opción antes de proceder.");
            }
        }
    }
}
