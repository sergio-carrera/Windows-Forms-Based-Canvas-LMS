using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_GestionAcademica_Grupo05.Formularios.Estudiante.Curso.btnAsignaciones_estudiante
{
    public partial class UC_Comentarios : UserControl
    {

        public UC_Comentarios(string idCred, string idCurso, string NombreUsuario, string comentario)
        {
            //Aquí se actualiza el valor de los labels o cuadros de texto por los valores obtenidos en el formulario 'ReclamosAsignaciones'
            InitializeComponent();
            panel1.Paint += Panel1_Paint;
            lblEstudiante.Text = NombreUsuario;
            lblTexto.Text = comentario;


        }




        private void Panel1_Paint(object sender, PaintEventArgs e)
        {
            // Llama a un método para dibujar los bordes redondos
            DrawRoundedEdges(panel1, e.Graphics);
        }

        private void DrawRoundedEdges(Panel panel, Graphics g)
        {
            // Define un rectángulo que representa el área de dibujo del panel
            Rectangle rect = new Rectangle(0, 0, panel.Width - 1, panel.Height - 1);

            // Define el radio de los bordes redondos
            int radius = 15;

            // Crea un objeto de gráficos de trayectoria para dibujar los bordes redondos
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddArc(rect.X, rect.Y, radius, radius, 180, 90); // Esquina superior izquierda
                path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90); // Esquina superior derecha
                path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90); // Esquina inferior derecha
                path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90); // Esquina inferior izquierda
                path.CloseFigure();

                // Configura el recorte de la región de dibujo
                g.SetClip(path);

                // Dibuja el fondo del panel con un color o un fondo de imagen
                g.FillRectangle(Brushes.LightGray, rect);

                // Restablece el recorte
                g.ResetClip();

                // Dibuja el borde del panel
                g.DrawPath(Pens.Black, path);
            }
        }
    }
}
