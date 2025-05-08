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

namespace Proyecto_GestionAcademica_Grupo05.Formularios.Estudiante.Curso.btnPersonas
{
    public partial class UC_IntegranteGrupo : UserControl
    {
        public string nombreCompleto;

        public UC_IntegranteGrupo(string nombreCompleto)
        {
            InitializeComponent();
            this.nombreCompleto = nombreCompleto;
            lblNombre.Text = nombreCompleto;
        }   
    }
}
