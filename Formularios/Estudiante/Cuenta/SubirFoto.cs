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
    public partial class SubirFoto : Form
    {

        /*
         "public Image SelectedImage": 
         Esto define una propiedad pública llamada "SelectedImage" que devuelve un objeto de tipo "Image". 
         En C#, las propiedades permiten acceder a valores privados o calculados de un objeto de una manera 
         controlada y orientada a objetos.

        "{ get { return btnSeleccionarImg.Image; } }": 
        Esta parte del código se refiere a la implementación de la propiedad "SelectedImage". El bloque 
        "get" especifica cómo se debe obtener el valor de la propiedad. En este caso, cuando alguien intente 
        obtener el valor de "SelectedImage", se devolverá la imagen almacenada en la propiedad "Image" del botón 
        "btnSeleccionarImg".
        */
        public Image SelectedImage
        {
            get { return btnSeleccionarImg.Image; }
        }

        public SubirFoto()
        {
            InitializeComponent();
        }

        private void btnSeleccionarImg_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofdSeleccionar = new OpenFileDialog();
            ofdSeleccionar.Filter = "Imagenes|*.jpg; *.png";
            ofdSeleccionar.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            ofdSeleccionar.Title = "Selecciona una imagen";
            if (ofdSeleccionar.ShowDialog() == DialogResult.OK)
            {
                btnSeleccionarImg.Image = Image.FromFile(ofdSeleccionar.FileName);
            }
        }

        private void SubirFoto_MouseEnter(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
        }

        private void SubirFoto_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }

        private void btnSeleccionarImg_MouseEnter(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
        }

        private void btnSeleccionarImg_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }
    }
}
