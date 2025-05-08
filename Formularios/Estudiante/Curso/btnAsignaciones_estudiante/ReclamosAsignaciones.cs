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

namespace Proyecto_GestionAcademica_Grupo05.Formularios.Estudiante.Curso.btnAsignaciones_estudiante
{
    public partial class ReclamosAsignaciones : Form
    {
        //Variables necesarias para utilizar en las consultas conectadas a la base de datos
        //nombreServidor necesario para acceder al nombre de la maquina e iniciar la base de datos
        private string nombreServidor = Logins.ObtenerInstancia().nombreServidor;
        string idCred;
        string idCurso;
        string idAsignacion;

        private string cadenaConexion;

        //Se obtienen los datos heredados del id del estudiante, el curso al que está conectado y la asignación a la cual va a ingresar un reclamo.
        public ReclamosAsignaciones(string idCred, string idCurso, string idAsignacion)
        {
            InitializeComponent();
            this.idCred = idCred;
            this.idCurso = idCurso;
            this.idAsignacion = idAsignacion;
            cadenaConexion = $"server={nombreServidor}; database=GestorAcademico; integrated security=true";
        }


        //En este metodo heredamos los datos antes mencionados para utilizarlos en las consultas de SQL Server
        //En este metodo se va a obtener el comentario ingresado en el TextBox y el nombre completo del estudiante
        public void CrearComentarioYObtenerUsuario(string idCred, string idAsignacion, string descripcionComentario)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                {
                    conexion.Open();

                    //Se inicializa la conexion con la base de datos para crear las consultas necesarias para obtener, el id del comentario, el id de la asignacion
                    //el id que identifica al usuario, la fecha cuando se creó el anuncio y el comentario
                    int idComentario = ObtenerSiguienteidComentario(conexion);
                    DateTime fecha = DateTime.Now;
                    string consulta = "INSERT INTO Comentario_Asignacion_x_Estudiante (idComentario_Asignacion_x_Estudiante, fkAsignacion_x_Estudiante, fkUsuario, fecha, comentario) " +
                                      "VALUES (@idComentario_Asignacion_x_Estudiante, @fkAsignacion_x_Estudiante, @fkUsuario, @fecha, @comentario)";

                    using (SqlCommand comando = new SqlCommand(consulta, conexion))
                    {
                        //Se igualan los valores seleccionados de la tabla Comentario_Asignacion_x_Estudiante a variables que se suben en un User Control
                        //Con el fin de guardar y/o mostrar los datos obtenidos.
                        comando.Parameters.AddWithValue("@idComentario_Asignacion_x_Estudiante", idComentario);
                        comando.Parameters.AddWithValue("@fkAsignacion_x_Estudiante", idAsignacion);
                        comando.Parameters.AddWithValue("@fkUsuario", idCred);
                        comando.Parameters.AddWithValue("@fecha", fecha);
                        comando.Parameters.AddWithValue("@comentario", descripcionComentario);
                        comando.ExecuteNonQuery();
                    }

                    //Cuadro de texto que confirma que el comentario fue subido en la base de datos
                    MessageBox.Show("Comentario creado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                ObtenerUsuario(idCred, idCurso, descripcionComentario); // Llamada al método ObtenerUsuario después de crear el comentario
            }
            catch (Exception ex)
            {
                //manejo de excepciones en caso de haber un error en los valores ingresados y que el programa se cierre a la fuerza
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Método necesario para obtener el nombre completo del usuario que está accediendo a la sección de reclamos
        private void ObtenerUsuario(string idCred, string idCurso, string descripcionComentario)
        {
            int cont = 0;
            SqlConnection con = new SqlConnection($"server={Logins.ObtenerInstancia().nombreServidor}; database =GestorAcademico; integrated security = true");
            con.Open();
            //Se obtiene el nombre y el apellido del estudiante y se unen en una variable 'NombreUsuario'
            string cadena = "SELECT CONCAT (U.nombre,' ' , U.apellido1) AS NombreUsuario" +
                            " FROM Comentario_Asignacion_x_Estudiante AS CAE " +
                            " JOIN Usuario AS U ON CAE.fkUsuario = U.idUsuario" +
                            " WHERE CAE.fkUsuario = 2";
            SqlCommand comando = new SqlCommand(cadena, con);
            SqlDataReader lector = comando.ExecuteReader();

            while (lector.Read())
            {
                cont++;
                string NombreUsuario = lector["NombreUsuario"].ToString();
                //este metodo var miniatura es necesario para enviar los datos obtenidos en los métodos anteriores a los espacios a rellenar
                var miniatura = new UC_Comentarios(idCred, idCurso, NombreUsuario, descripcionComentario);
                flContenido.Controls.Add(miniatura);
            }

            if (cont == 0)
            {
                //Mensaje informativo en caso de no tener comentarios creados
                MessageBox.Show("¡No tienes comentarios creados!");
            }
        }

        //Este metodo es muy importante ya que es el encargado de generar las claves primarias para los comentarios de reclamo.
        //La consulta en SQL permite no tener un ID repetido y que se generan x+1
        private int ObtenerSiguienteidComentario(SqlConnection conexion)
        {
            try
            {
                string consulta = "SELECT ISNULL(MAX(idComentario_Asignacion_x_Estudiante), 0) + 1 FROM Comentario_Asignacion_x_Estudiante";

                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    object resultado = comando.ExecuteScalar();
                    return Convert.ToInt32(resultado);
                }
            }
            catch (Exception ex)
            {
                //Cuadro de texto que muestra un error en caso de que el SQL tenga un error y falle al generar los IDs
                //Esto permite no terminar el programa o genere problemas en un futuro.
                MessageBox.Show("Error al obtener el siguiente ID de Comentario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }

        //Este evento 'Click' en el boton de entrega es el que permite obtener el texto ingresado en el TextBox
        //Despues envia el dato 'descripcionComentario' al metodo 'CrearComentarioYObtenerUsuario'
        private void btnEntrega_Click_1(object sender, EventArgs e)
        {
            string descripcionComentario = txtBoxComentario.Text;

            CrearComentarioYObtenerUsuario(idCred, idAsignacion, descripcionComentario);

            txtBoxComentario.Clear();
        }
    }
}

