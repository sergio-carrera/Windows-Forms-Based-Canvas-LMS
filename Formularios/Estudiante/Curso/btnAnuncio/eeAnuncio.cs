using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_GestionAcademica_Grupo05.Formularios.Estudiante.Curso.btnAnuncio
{
    public partial class eeAnuncio : Form
    {

        public string idCred;
        public string idCurso;
        public string tituloAnuncio;

        public eeAnuncio(string id, string idCurso, string tituloAnuncio)
        {
            InitializeComponent();
            MostrarAnuncioE(tituloAnuncio, idCurso);
            this.idCred = id;
            this.idCurso = idCurso;
            this.tituloAnuncio = tituloAnuncio;
        }

        public void MostrarAnuncioE(string tituloAnuncio, string idCurso)
        {
            SqlConnection con = new SqlConnection($"server={Logins.ObtenerInstancia().nombreServidor}; database =GestorAcademico; integrated security = true");
            con.Open();
            string cadena = @"SELECT a.*, CONCAT(u.nombre, ' ', u.apellido1) AS nCompleto
                    FROM Anuncio AS a
                    JOIN Usuario_x_Curso AS uxc ON a.fkCurso = uxc.fkCurso
                    JOIN Usuario AS u ON u.idUsuario = uxc.fkUsuario
                    JOIN Credencial AS c ON u.fkCredencial = c.idCredencial
                    WHERE a.nombreAnuncio = '" + tituloAnuncio + "'" +
                    " AND c.fkCredencialTipo = 1" +
                    " AND uxc.fkCurso = " + idCurso;

            SqlCommand comando = new SqlCommand(cadena, con);
            using (SqlDataReader lector = comando.ExecuteReader())
            {

                while (lector.Read())
                {
                    string descAnuncio = lector["descripcionAnuncio"].ToString();
                    string nombre = lector["nCompleto"].ToString();

                    var miniatura = new UC_eAnuncioMostrar(tituloAnuncio, idCred, idCurso, descAnuncio, nombre);
                    flContenidoA.Controls.Add(miniatura);
                }
            }
        }

    }
}
