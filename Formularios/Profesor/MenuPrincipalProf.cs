using FontAwesome.Sharp;
using Proyecto_GestionAcademica_Grupo05.Formularios.FormularioHijo2;
using Proyecto_GestionAcademica_Grupo05.Formularios.Profesor.Cuenta_profesor;
using Proyecto_GestionAcademica_Grupo05.Formularios.Profesor.Curso_profesor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_GestionAcademica_Grupo05.Formularios.Profesor
{
    public partial class MenuPrincipalProf : Form
    {
        //Campo para almacenar y editar botón "actual"
        private IconButton btnActual;
        //Campo para almacenar formulario "hijo" para el panelDesktop
        private Form formHijoActual;
        //Campo para almacenar formulario "hijo" para el panelDesktop2
        private Form formHijoActual2;

        public static string idCred;
        public MenuPrincipalProf(string id)
        {
            InitializeComponent();
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            panelDesktop2_profesor.Visible = false;

            idCred = id;
        }

        //Métodos
        public void ActivarBoton(object senderBtn)
        {
            if (senderBtn != null)
            {
                DesactivarBoton();
                btnActual = (IconButton)senderBtn;
                btnActual.BackColor = Color.FromArgb(255, 255, 255);
                btnActual.ForeColor = Color.FromArgb(63, 42, 85);
                btnActual.IconColor = Color.FromArgb(63, 42, 85);
            }
        }

        public void DesactivarBoton()
        {
            if (btnActual != null)
            {
                btnActual.BackColor = Color.FromArgb(63, 42, 85);
                btnActual.ForeColor = Color.Gainsboro;
                btnActual.IconColor = Color.White;
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
                panelDesktop_profesor.Controls.Add(formHijoActual);
                panelDesktop_profesor.Tag = formHijo;
                panelDesktop2_profesor.Visible = false;
                formHijo.BringToFront();
                formHijo.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void AbrirFormHijo2(Form formHijo)
        {
            try
            {
                if (formHijoActual2 != null)
                {
                    //abrir unico formulario 
                    formHijoActual2.Close();
                }
                formHijoActual2 = formHijo;
                formHijo.TopLevel = false;
                formHijo.FormBorderStyle = FormBorderStyle.None;
                formHijo.Dock = DockStyle.Fill;
                panelDesktop2_profesor.Controls.Add(formHijoActual2);
                panelDesktop2_profesor.Tag = formHijo;
                panelDesktop2_profesor.Visible = true;
                formHijo.BringToFront();
                formHijo.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        //Botón "Inicio/Logo"
        private void btnInicio_Click(object sender, EventArgs e)
        {
            if (formHijoActual != null)
            {
                formHijoActual.Close();
            }
            if (formHijoActual2 != null)
            {
                panelDesktop2_profesor.Visible = false;
            }
            if (formHijoActual != null && formHijoActual2 != null)
            {
                formHijoActual.Close();
                panelDesktop2_profesor.Visible = false;
            }
            DesactivarBoton();
        }

        //Botón "Cuenta"
        private void iconButton1_Click(object sender, EventArgs e)
        {
            ActivarBoton(sender);
            AbrirFormHijo2(new Cuenta1_profesor(idCred));
        }

        //Botón "Cursos"
        private void iconButton2_Click(object sender, EventArgs e)
        {
            ActivarBoton(sender);
            AbrirFormHijo2(new Cursos1_profesor(idCred));
        }

        //Botón "Salir"
        private void iconButton6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Manejar el formulario (biblioteca de vínculos dinámicos (DLL))
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        //Con este evento se puede manejar el formulario
        private void panelMenu_profesor_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0xA1, 0x2, 0);
        }
    }
}
