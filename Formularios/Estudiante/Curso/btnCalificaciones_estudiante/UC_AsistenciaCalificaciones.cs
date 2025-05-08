using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_GestionAcademica_Grupo05.Formularios.Estudiante.Curso.btnCalificaciones_estudiante
{
    public partial class UC_AsistenciaCalificaciones : UserControl
    {
        public string idSemana;
        public int idAsistencia_estado;

        public UC_AsistenciaCalificaciones(string idSemana, int idAsistencia_estado)
        {
            InitializeComponent();
            this.idSemana = idSemana;
            this.idAsistencia_estado = idAsistencia_estado;
            ObtenerSemana();
            ObtenerEstadoAsistencia();
        }

        public void ObtenerSemana()
        {
            try
            {
                if (idSemana == "1")
                {
                    lblSemana.Text = "Semana #1";
                }
                else if (idSemana == "2")
                {
                    lblSemana.Text = "Semana #2";
                }
                else if (idSemana == "3")
                {
                    lblSemana.Text = "Semana #3";
                }
                else if (idSemana == "4")
                {
                    lblSemana.Text = "Semana #4";
                }
                else if (idSemana == "5")
                {
                    lblSemana.Text = "Semana #5";
                }
                else if (idSemana == "6")
                {
                    lblSemana.Text = "Semana #6";
                }
                else if (idSemana == "7")
                {
                    lblSemana.Text = "Semana #7";
                }
                else if (idSemana == "8")
                {
                    lblSemana.Text = "Semana #8";
                }
                else if (idSemana == "9")
                {
                    lblSemana.Text = "Semana #9";
                }
                else if (idSemana == "10")
                {
                    lblSemana.Text = "Semana #10";
                }
                else if (idSemana == "11")
                {
                    lblSemana.Text = "Semana #11";
                }
                else if (idSemana == "12")
                {
                    lblSemana.Text = "Semana #12";
                }
                else if (idSemana == "13")
                {
                    lblSemana.Text = "Semana #13";
                }
                else if (idSemana == "14")
                {
                    lblSemana.Text = "Semana #14";
                }
                else if (idSemana == "15")
                {
                    lblSemana.Text = "Semana #15";
                }
            }
            catch(Exception ex) 
            {
                MessageBox.Show("Error en el método 'ObtenerSemana': " + ex.ToString());
            }
        }

        public void ObtenerEstadoAsistencia()
        {
            try
            {
                switch (idAsistencia_estado)
                {
                    case 1: // Presente
                        pbEstado.Image = Proyecto_GestionAcademica_Grupo05.Properties.Resources.uc_presente;
                        break;
                    case 2: // Ausente
                        pbEstado.Image = Proyecto_GestionAcademica_Grupo05.Properties.Resources.uc_ausente;
                        break;
                    case 3: // Tarde
                        pbEstado.Image = Proyecto_GestionAcademica_Grupo05.Properties.Resources.UC_tarde;
                        break;
                    case 4: // No Asignado
                        pbEstado.Image = Proyecto_GestionAcademica_Grupo05.Properties.Resources.uc_sinasignar;
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en el método 'ObtenerEstadoAsistencia': " + ex.ToString());
            }
        }
    }
}
