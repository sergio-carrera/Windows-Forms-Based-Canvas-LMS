using Proyecto_GestionAcademica_Grupo05.Formularios.FormularioHijo1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_GestionAcademica_Grupo05.Formularios.Estudiante.Cuenta
{
    public partial class seleccionarfotoe : Form
    {
        private Cuenta2 formHijo1;
        private editarperfilhijoe formHijo2;
        private string idCred;
        public Image ImagenSeleccionada { get; private set; }

        public seleccionarfotoe(Cuenta2 padre, string idCred)
        {
            InitializeComponent();
            formHijo1 = padre;
            this.idCred = idCred;

        }

        public void GuardarImagenEnDB(byte[] imagenBytes)
        {
            string connectionString = $"server={Logins.ObtenerInstancia().nombreServidor}; database=GestorAcademico; integrated security=true";
            string query = "IF EXISTS (SELECT * FROM Usuario WHERE idUsuario = @id) " +
                           "BEGIN " +
                           "    UPDATE Usuario SET foto_perfil = @imagen WHERE idUsuario = @id " +
                           "END " +
                           "ELSE " +
                           "BEGIN " +
                           "    INSERT INTO Usuario (idUsuario, foto_perfil) VALUES (@id, @imagen) " +
                           "END";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@imagen", imagenBytes);
                    command.Parameters.AddWithValue("@id", idCred);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        private byte[] ImageToByteArray(Image imagen)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                imagen.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg); // Puedes cambiar el formato si lo necesitas
                return ms.ToArray();
            }
        }


        private void iconPictureBox1_Click_1(object sender, EventArgs e)
        {
            if (formHijo1 != null)
            {
                formHijo1.CambiarVisibilidadPanel2(false);
            }
        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            if (formHijo1 != null)
            {
                formHijo1.CambiarVisibilidadPanel2(false);
            }
        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            // Verificar si se ha seleccionado una imagen
            if (pictureBox1.Image != null)
            {
                // Convertir la imagen a un array de bytes
                byte[] imagenBytes = ImageToByteArray(pictureBox1.Image);

                // Llamar al método para guardar la imagen en la base de datos
                GuardarImagenEnDB(imagenBytes);

                if (formHijo1 != null)
                {
                    //formHijo1.CambiarImagen(pictureBox1.Image); 
                    formHijo1.CambiarVisibilidadPanel2(false);
                    //formHijo2.CambiarImagen2(pictureBox1.Image); // Pasar la imagen a Formhijo2
                    formHijo1.CambiarImagen(pictureBox1.Image);

                }
                //if (formHijo2 != null)
                //{

                //}

            }
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            // Crear una instancia del OpenFileDialog
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Establecer el filtro para mostrar solo archivos de imagen
            openFileDialog.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.gif;*.bmp";

            // Mostrar el diálogo para que el usuario seleccione un archivo
            DialogResult result = openFileDialog.ShowDialog();

            // Verificar si se ha seleccionado un archivo
            if (result == DialogResult.OK)
            {
                // Obtener la ruta del archivo seleccionado
                string imagePath = openFileDialog.FileName;

                // Mostrar la imagen seleccionada en el pictureBox1
                pictureBox1.Image = new Bitmap(imagePath);
            }
        }
    }

}
