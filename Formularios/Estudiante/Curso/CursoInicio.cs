using FontAwesome.Sharp;
using Proyecto_GestionAcademica_Grupo05.Formularios.Estudiante.Curso.btnAnuncio;
using Proyecto_GestionAcademica_Grupo05.Formularios.Estudiante.Curso.btnCalificaciones_estudiante;
using Proyecto_GestionAcademica_Grupo05.Formularios.Estudiante.FormularioHijo1.Curso;
using Proyecto_GestionAcademica_Grupo05.Formularios.Estudiante.FormularioHijo1.Curso.btnAsignaciones_estudiante;
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

namespace Proyecto_GestionAcademica_Grupo05.Formularios.Estudiante.FormularioHijo1
{
    public partial class CursoInicio : Form
    {
        //Este formulario es un formulario principal para el apartado de Cursos
        //Acá están todos los métodos para cambiar entre las opciones del menú lateral:
        //-Inicio (este formulario); - Módulos; -Asignaciones; -Calificaciones; -Personas

        private IconButton btnActual;
        //Campo para almacenar formulario "hijo" para el panelPrincipal
        private Form formHijoActual;

        public string idCred;
        public string idCurso;
        public string nombreCurso;
        public CursoInicio(string idCred, string idCurso, string nombreCurso)
        {
            InitializeComponent();
            ActivarBoton(btnInicio);
            this.idCred = idCred;
            this.idCurso = idCurso;
            this.nombreCurso = nombreCurso;
            lblControl.Text = nombreCurso;
            lblNombreCurso.Text = nombreCurso;
            obtenerDescripcionCurso();
        }

        //Métodos
        public void ActivarBoton(object senderBtn)
        {
            if (senderBtn != null)
            {
                DesactivarBoton();
                btnActual = (IconButton)senderBtn;
                btnActual.ForeColor = Color.FromArgb(45, 59, 69);
            }
        }

        public void DesactivarBoton()
        {
            if (btnActual != null)
            {
                btnActual.ForeColor = Color.FromArgb(126, 132, 136);
            }
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
                panelPrincipal.Controls.Add(formHijoActual);
                panelPrincipal.Tag = formHijo;
                formHijo.BringToFront();
                formHijo.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        //Método para obtener la descripción del curso y ponerla en el txtDescripcionCurso.Text
        private void obtenerDescripcionCurso()
        {
            using (SqlConnection conexion = new SqlConnection($"server={Logins.ObtenerInstancia().nombreServidor}; database =GestorAcademico; integrated security = true"))
            {
                conexion.Open();
                string consulta = "SELECT descripcion FROM Curso WHERE idCurso =" + idCurso;
                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    using (SqlDataReader lector = comando.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            string descripcion = lector.GetString(0);
                            txtDescripcionCurso.Text = descripcion;
                        }
                    }
                }
                conexion.Close();
            }
        }
        
        //Botón "Inicio" que cierra todos aquellos formularios hijos
        private void btnInicio_Click(object sender, EventArgs e)
        {
            if (formHijoActual != null)
            {
                formHijoActual.Close();
            }
            ActivarBoton(sender);
            lblControl.Text = nombreCurso;
        }

        //Botón "Módulos"
        private void btnModulos_Click(object sender, EventArgs e)
        {
            ActivarBoton(sender);
            AbrirFormHijo(new CursoModulos(idCred, idCurso));
            lblControl.Text = nombreCurso + " > Módulos"; 
        }

        //Botón "Asignaciones"
        private void btnAsignacion_Click(object sender, EventArgs e)
        {
            ActivarBoton(sender);
            AbrirFormHijo(new MuestraDeAsignacionesEstudiante(idCred, idCurso));
            lblControl.Text = nombreCurso + " > Asignaciones";
        }
        
        //Botón "Calificaciones"
        private void btnCalificaciones_Click(object sender, EventArgs e)
        {
            ActivarBoton(sender);
            AbrirFormHijo(new VistaCalificaciones(idCred, idCurso));
            lblControl.Text = nombreCurso + " > Calificaciones";
        }

        //Botón "Personas"
        private void btnPersonas_Click(object sender, EventArgs e)
        {
            ActivarBoton(sender);
            AbrirFormHijo(new CursoPersonas(idCred, idCurso));
            lblControl.Text = nombreCurso + " > Personas";
        }

        private void BtnAnuncios_Click(object sender, EventArgs e)
        {
            ActivarBoton(sender);
            AbrirFormHijo(new eAnuncio(idCred, idCurso));
            lblControl.Text = nombreCurso + " > Anuncios";
        }
    }
}
