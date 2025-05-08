using Proyecto_GestionAcademica_Grupo05;
using Proyecto_GestionAcademica_Grupo05.Formularios.Estudiante.FormularioHijo1;
using Proyecto_GestionAcademica_Grupo05.Formularios.FormularioHijo1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_GestionAcademica_Grupo05.Formularios.Estudiante.FormularioHijo2
{
    public partial class UC_Curso : UserControl
    {
        //A partir de este user control, se obtiene y se va pasando el idCurso que servirá para prácticamente todas las funcionalidades 
        //del apartartado de "Cursos"
        public string idCred;
        public string idCurso;
        public UC_Curso(string idCred, string idCurso, string codigo, string nombreCurso)
        {
            InitializeComponent();
            //El texto del label del código del curso se estable con el string enviado anteiormente en la miniatura
            lblCodigo.Text = codigo;
            //El texto del label del nombre del curso se estable con el string enviado anteiormente en la miniatura
            lblNombreCurso.Text = nombreCurso;
            this.idCred = idCred;
            this.idCurso = idCurso;
        }

        //Al presionar el label del nombre del curso, activa el evento para entrar al CursoInicio del estudiante, y se oculta el 
        //panel del submenú
        private void lblNombreCurso_Click(object sender, EventArgs e)
        {
            try
            {
                //Se crea una instancia del formulario "CursoInicio"
                Form formCursoInicio = new CursoInicio(idCred, idCurso, lblNombreCurso.Text);

                //Se accede al menú principal (entendiento este menú como formulario principal)
                MenuPrincipalEstudiante formularioPrincipal = Application.OpenForms.OfType<MenuPrincipalEstudiante>().FirstOrDefault();

                //Cerrar el panelDesktop2 (oculta)
                Control panelDesktop2 = formularioPrincipal.Controls.Find("panelDesktop2", true).FirstOrDefault();
                if (panelDesktop2 != null)
                {
                    panelDesktop2.Visible = false;
                    formularioPrincipal.DesactivarBoton();
                }
                // Abrir el formulario "CursoInicio" en el panelDesktop del formulario principal "MenuPrincipalEstudiante"
                formularioPrincipal.AbrirFormHijo(formCursoInicio);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
