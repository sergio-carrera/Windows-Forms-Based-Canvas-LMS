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

namespace Proyecto_GestionAcademica_Grupo05.Formularios.Profesor.Curso_profesor.btnAnuncios
{
    public partial class AnuncioCreate : Form
    {
        private string nombreServidor = Logins.ObtenerInstancia().nombreServidor;
        string idCred;
        string idCurso;
        private string cadenaConexion;
        public AnuncioCreate(string idCurso, string idCred)
        {
            InitializeComponent();
            this.idCred = idCred;
            this.idCurso = idCurso;
            cadenaConexion = ($"server={Logins.ObtenerInstancia().nombreServidor}; database=GestorAcademico; integrated security=true");
        }

        public void CrearAnuncio(string idCurso, string nombreAnuncio, string descripcionAnuncio)
        {
            try
            {
                SqlConnection con = new SqlConnection($"server={Logins.ObtenerInstancia().nombreServidor}; database =GestorAcademico; integrated security = true");
                con.Open();
                using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                {

                    int idAnuncio = ObtenerSiguienteIdAnuncio(conexion);
                    DateTime fechaAnuncio = DateTime.Now;
                    string consulta = "INSERT INTO Anuncio (idAnuncio, fkCurso, nombreAnuncio, descripcionAnuncio, fechaAnuncio) " +
                                      "VALUES (@idAnuncio, @fkCurso, @nombreAnuncio, @descripcionAnuncio, @fechaAnuncio)";

                    using (SqlCommand comando = new SqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@idAnuncio", idAnuncio);
                        comando.Parameters.AddWithValue("@fkCurso", idCurso);
                        comando.Parameters.AddWithValue("@nombreAnuncio", nombreAnuncio);
                        comando.Parameters.AddWithValue("@descripcionAnuncio", descripcionAnuncio);
                        comando.Parameters.AddWithValue("@fechaAnuncio", fechaAnuncio);

                        comando.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Anuncio creado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear el anuncio: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private int ObtenerSiguienteIdAnuncio(SqlConnection conexion)
        {
            conexion.Open();
            try
            {
                string consulta = "SELECT ISNULL(MAX(idAnuncio), 0) + 1 FROM Anuncio";

                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    object resultado = comando.ExecuteScalar();

                    return Convert.ToInt32(resultado);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener el siguiente ID de Anuncio: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return -1;
            }
        }



        private void btnSubir_Click(object sender, EventArgs e)
        {
            string nombreAnuncio = txtBoxTitulo.Text;
            string descripcionAnuncio = txtBoxDescripcion.Text;


            CrearAnuncio(idCurso, nombreAnuncio, descripcionAnuncio);


            txtBoxTitulo.Clear();
            txtBoxDescripcion.Clear();
        }
    }
}

