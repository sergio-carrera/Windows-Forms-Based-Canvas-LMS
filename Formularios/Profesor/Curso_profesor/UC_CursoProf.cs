using Proyecto_GestionAcademica_Grupo05.Formularios.Estudiante.FormularioHijo1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_GestionAcademica_Grupo05.Formularios.Profesor.Curso_profesor
{
    public partial class UC_CursoProf : UserControl
    {
        //A partir de este user control, se obtiene y se va pasando el idCurso que servirá para prácticamente todas las funcionalidades 
        //del apartartado de "Cursos"
        public string idCred;
        public string idCurso;
        public UC_CursoProf(string idCred, string idCurso, string codigo, string nombreCurso)
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
                // Crear una instancia del formulario "prueba"
                Form formCursoInicioProf = new CursoInicioProf(idCred, idCurso, lblNombreCurso.Text);

                // Acceder al formulario principal
                MenuPrincipalProf formularioPrincipal = Application.OpenForms.OfType<MenuPrincipalProf>().FirstOrDefault();

                // Cerrar el panelDesktop2
                Control panelDesktop2_profesor = formularioPrincipal.Controls.Find("panelDesktop2_profesor", true).FirstOrDefault();
                if (panelDesktop2_profesor != null)
                {
                    panelDesktop2_profesor.Visible = false;
                    formularioPrincipal.DesactivarBoton();
                }

                // Abrir el formulario "Cursos2" en el panelDesktop
                formularioPrincipal.AbrirFormHijo(formCursoInicioProf);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
