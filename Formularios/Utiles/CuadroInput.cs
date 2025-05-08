using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_GestionAcademica_Grupo05.Formularios.Utiles
{
    public partial class CuadroInput : Form
    {
        //Variable "String (System.String específicamente del framework .NET, realmente no hay diferencia)
        public String respuesta;
        public CuadroInput()
        {
            InitializeComponent();
            //Se muestra en el medio de la pantalla el formulario
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                //Guarda lo añadido en el textbox en la variable "respuesta"
                respuesta = textBox1.Text;
                DialogResult = DialogResult.OK;
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
