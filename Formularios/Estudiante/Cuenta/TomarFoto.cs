using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Proyecto_GestionAcademica_Grupo05.Formularios.FormularioHijo1
{
    public partial class TomarFoto : Form
    {
        public TomarFoto()
        {
            InitializeComponent();
            pictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
        }


        /*
        private FilterInfoCollection videoDevices;
        private VideoCaptureDevice videoSource;
        */

        /*
        private void videoSource_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap frame = (Bitmap)eventArgs.Frame.Clone();
            pictureBox.Image = frame;
            pictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
        }
        */

        private void btnCapturar_Click(object sender, EventArgs e)
        {
            /*
            if (videoSource != null && videoSource.IsRunning)
            {
                Bitmap currentFrame = (Bitmap)pictureBox.Image.Clone();

                // Define la ruta donde deseas guardar la imagen
                string savePath = "../Escritorio/imagen.jpg";
                currentFrame.Save(savePath);

                // Detén la cámara después de tomar la foto
                videoSource.SignalToStop();
                videoSource.WaitForStop();
            }
            */
        }

        private void TomarFoto_FormClosing(object sender, FormClosingEventArgs e)
        {
            /*
            if (videoSource != null && videoSource.IsRunning)
            {
                videoSource.SignalToStop();
                videoSource.WaitForStop();
            }
            */
        }

        private void TomarFoto_Load_1(object sender, EventArgs e)
        {
            /*
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            if (videoDevices.Count > 0)
            {
                videoSource = new VideoCaptureDevice(videoDevices[0].MonikerString);
                videoSource.NewFrame += new NewFrameEventHandler(videoSource_NewFrame);
                videoSource.Start();
            }
            else
            {
                MessageBox.Show("No se encontraron dispositivos de cámara.");
            }
            */
        }
    }
}
