using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_GestionAcademica_Grupo05.Formularios.Profesor.Curso_profesor.btnAnuncios
{
    public partial class pAnuncio : Form
    {

        public string idCurso;
        public string idCred;
        public pAnuncio(string id, string idCurso)
        {
            InitializeComponent();
            MostrarAnuncios(idCurso);
            this.idCurso = idCurso;
            this.idCred = id;
        }

        public void MostrarAnuncios(string idCurso)
        {
            int cont = 0;
            SqlConnection con = new SqlConnection($"server={Logins.ObtenerInstancia().nombreServidor}; database =GestorAcademico; integrated security = true");
            con.Open();
            string cadena = "Select * from Anuncio where fkCurso = " + idCurso + " ORDER BY fechaAnuncio DESC";
            SqlCommand comando = new SqlCommand(cadena, con);
            SqlDataReader lector = comando.ExecuteReader();

            while (lector.Read())
            {
                cont++;
                string tituloAnuncio = lector["nombreAnuncio"].ToString();
                string fechaAnuncio = lector["fechaAnuncio"].ToString();

                // Crear una instancia de UC_Anuncio con título y fecha
                var miniatura = new UC_Anuncio(idCurso, tituloAnuncio, fechaAnuncio, idCred);
                flPanelAnuncios.Controls.Add(miniatura);
            }

            if (cont == 0)
            {
                MessageBox.Show("¡No tienes anuncios creados!");
            }
        }

        private void btnCrearA_Click_1(object sender, EventArgs e)
        {
            AnuncioCreate anuncioCreate = new AnuncioCreate(idCurso, idCred);
            anuncioCreate.Show();
        }
    }
}
