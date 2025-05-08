using Proyecto_GestionAcademica_Grupo05.ControlesPersonalizados;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_GestionAcademica_Grupo05.Formularios.FormularioHijo1
{
    public partial class FotoDePerfil : Form
    {
        private Form formHijoActual;
        private bool btnHabilitado = false;

        public FotoDePerfil()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false;
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;

            btnCerrar.FlatAppearance.BorderSize = 0;
            btnSubirFoto.FlatAppearance.BorderSize = 0;
            btnTomarFoto.FlatAppearance.BorderSize = 0;
            btnCancelar.FlatAppearance.BorderSize = 0;
            btnGuardar.FlatAppearance.BorderSize = 0;

            btnCerrar.Hide();
            //btnGuardar.Enabled = false;
        }

        private void panelMover_MouseEnter(object sender, EventArgs e)
        {
            Cursor = Cursors.SizeAll;
        }

        private void panelMover_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }

        //Arrastre de formulario

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);


        private void panelMover_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0xA1, 0x2, 0);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        public void AbrirFormHijo(Form formHijo)
        {
            try
            {
                if (formHijoActual != null)
                {
                    //abrir único formulario 
                    formHijoActual.Close();
                }
                formHijoActual = formHijo;
                formHijo.TopLevel = false;
                formHijo.FormBorderStyle = FormBorderStyle.None;
                formHijo.Dock = DockStyle.Fill;
                panelFotoPerfil.Controls.Add(formHijoActual);
                panelFotoPerfil.Tag = formHijo;
                panelFotoPerfil.Visible = true;
                formHijo.BringToFront();
                formHijo.Show();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }




        private void btnSubirFoto_Click(object sender, EventArgs e)
        {
            AbrirFormHijo(new SubirFoto());
        }

        private void btnTomarFoto_Click(object sender, EventArgs e)
        {
            AbrirFormHijo(new TomarFoto());
        }


        //Botón Cancelar
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancelar_MouseEnter(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
        }

        private void btnCancelar_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }

        //Botón Cerrar
        private void btnCerrar_MouseEnter(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
        }

        private void btnCerrar_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }


        //Botón Guardar
        private void btnGuardar_MouseEnter(object sender, EventArgs e)
        {
            if (btnHabilitado)
            {
                Cursor = Cursors.Hand;
            }
        }

        private void btnGuardar_MouseLeave(object sender, EventArgs e)
        {
            if (btnHabilitado)
            {
                Cursor = Cursors.Default;
            }
        }

        //Método para cargar imagen en la base de datos
        public void cargarImgBD(Image image)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection($"server=LAPTOP-CP7CKNAR; database = Pruebas; integrated security = true"))
                {
                    conexion.Open();

                    MemoryStream ms = new MemoryStream();
                    image.Save(ms, ImageFormat.Jpeg);
                    byte[] aByte = ms.ToArray();

                    string consulta = "INSERT INTO Imagenes (id, imagen) VALUES (1, @imagen)";

                    using (SqlCommand comando = new SqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("imagen", aByte);
                        comando.ExecuteNonQuery();
                    }
                    conexion.Close();
                }
            }
            catch (SqlException) { }



            /*
            try
            {
                using (SqlConnection conexion = new SqlConnection($"server=LAPTOP-CP7CKNAR; database = Pruebas; integrated security = true"))
                {
                    conexion.Open();

                    SubirFoto subirFotoForm = new SubirFoto();

                    MemoryStream ms = new MemoryStream();
                    subirFotoForm.btnSeleccionarImg.Image.Save(ms, ImageFormat.Jpeg);
                    byte[] aByte = ms.ToArray();

                    string consulta = "INSERT INTO Imagenes (id, imagen) VALUES (1, @imagen)";

                    using (SqlCommand comando = new SqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("imagen", aByte);
                        comando.ExecuteNonQuery();

                        subirFotoForm.btnSeleccionarImg = null;
                    }
                    conexion.Close();
                }
            }catch(SqlException) { }
            */
        }
        

        //Método para cargar imagen en el CirculaPictureBox del form "Cuenta2"
        public void cargarImgPB()
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection($"server=LAPTOP-CP7CKNAR; database = Pruebas; integrated security = true"))
                {
                    conexion.Open();

                    string consulta = "SELECT imagen FROM Imagenes WHERE id = 1";

                    using (SqlCommand comando = new SqlCommand(consulta, conexion))
                    {
                        using (SqlDataReader reader = comando.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                reader.Read();
                                MemoryStream ms2 = new MemoryStream((byte[])reader["imagen"]);
                                Bitmap bm = new Bitmap(ms2);

                                Cuenta2 cuenta2f = Application.OpenForms.OfType<Cuenta2>().FirstOrDefault();

                                PictureBox circularPictureBox = cuenta2f.Controls.Find("circularPictureBox1", true).OfType<PictureBox>().FirstOrDefault();

                                circularPictureBox.Image = bm;

                            }
                            else
                            {
                                MessageBox.Show("No se encontró");
                            }
                        }
                    }
                }

                
            }catch (SqlException) { }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (btnHabilitado == false)
            {
                // Obtén la imagen seleccionada desde SubirFoto
                SubirFoto subirFotoForm = formHijoActual as SubirFoto;
                if (subirFotoForm != null)
                {
                    Image selectedImage = subirFotoForm.SelectedImage;

                    if (selectedImage != null)
                    {
                        cargarImgBD(selectedImage); // Guarda la imagen en la base de datos
                    }
                }

                cargarImgPB(); // Carga la imagen desde la base de datos y establécela en el PictureBox en "Cuenta2"
            }
            else
            {
                // Realiza alguna acción adicional si es necesario
            }
        }

        /*
        Estos dos métodos aún no están terminados (es para mantener el botón de "Guardar" 
        desactivado hasta que se actualice el picture box con una nueva imagen)
        */
        public void HabilitarGuardar(bool habilitar)
        {
            btnGuardar.Enabled = habilitar;
        }

        public void ponerFotoDePerfil()
        {
            btnHabilitado = true;
            btnGuardar.Enabled = true;
        }
    }
}
