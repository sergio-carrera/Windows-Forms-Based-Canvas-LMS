using Proyecto_GestionAcademica_Grupo05.Formularios.Estudiante.FormularioHijo1.Curso.btnPersonas;
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
using System.Windows.Media.Media3D;

namespace Proyecto_GestionAcademica_Grupo05.Formularios.Profesor.Curso_profesor.btnAsistencia
{
    public partial class UC_EstudianteAsistencia : UserControl
    {
        public string idEstudiante;
        public string idCurso;
        public string idSemana;
        public string nombreCompleto;

        public string fkAsistencia_estado;

        public UC_EstudianteAsistencia(string idEstudiante, string idCurso, string idSemana, string nombreCompleto)
        {
            InitializeComponent();
            this.idEstudiante = idEstudiante;
            this.idCurso = idCurso;
            this.idSemana = idSemana;
            this.nombreCompleto = nombreCompleto;
            lblNombre.Text = nombreCompleto;
            cargar_Foto();
            cargarEstadoAsistencia();
        }

        //Método que obtiene la foto del usuario.
        public void cargar_Foto()
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection($"server={Logins.ObtenerInstancia().nombreServidor}; database=GestorAcademico; integrated security=true"))
                {
                    conexion.Open();
                    string consulta = "SELECT foto_perfil FROM Usuario Where idUsuario = " + idEstudiante;

                    using (SqlCommand comando = new SqlCommand(consulta, conexion))
                    {
                        using (SqlDataReader reader = comando.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                reader.Read();
                                MemoryStream ms3 = new MemoryStream((byte[])reader["foto_perfil"]);
                                Bitmap bm = new Bitmap(ms3);
                                pBFotoPerfil.Image = bm;
                            }
                            else
                            {
                                MessageBox.Show("No se encontró");
                            }
                        }
                    }
                    conexion.Close();
                }
            }
            catch (SqlException) { }
        }

        /*
        Método que actualiza la imagen del picturebox "btnCambiarEstado" dependiendo del estado
        de la asistencia del usuario en el curso y semana especificados.
        */
        public void cargarEstadoAsistencia()
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection($"server={Logins.ObtenerInstancia().nombreServidor}; database=GestorAcademico; integrated security=true"))
                {
                    conexion.Open();
                    string consulta = "SELECT fkAsistencia_estado FROM Asistencia WHERE fkUsuario = @idUsuario AND fkCurso = @idCurso AND fkSemana = @idSemana";

                    using (SqlCommand comando = new SqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@idUsuario", idEstudiante);
                        comando.Parameters.AddWithValue("@idCurso", idCurso);
                        comando.Parameters.AddWithValue("@idSemana", idSemana);

                        using (SqlDataReader reader = comando.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                reader.Read();
                                int estadoAsistencia = reader.GetInt32(0);

                                AsignarImagenDesdeEstadoAsistencia(estadoAsistencia);
                            }
                            else
                            {
                                MessageBox.Show("No se encontró el estado de asistencia para el usuario.");
                            }
                        }
                    }
                    conexion.Close();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al cargar el estado de asistencia: " + ex.ToString());
            }
        }

        /*
        Método que actualiza la imagen y la variable global "fkAsistencia_estado"
        */
        private void AsignarImagenDesdeEstadoAsistencia(int estadoAsistencia)
        {
            try
            {
                switch (estadoAsistencia)
                {
                    case 1: // Presente
                        btnCambiarEstado.Image = Proyecto_GestionAcademica_Grupo05.Properties.Resources.presente;
                        fkAsistencia_estado = "1";
                        break;
                    case 2: // Ausente
                        btnCambiarEstado.Image = Proyecto_GestionAcademica_Grupo05.Properties.Resources.ausente;
                        fkAsistencia_estado = "2";
                        break;
                    case 3: // Tarde
                        btnCambiarEstado.Image = Proyecto_GestionAcademica_Grupo05.Properties.Resources.tarde;
                        fkAsistencia_estado = "3";
                        break;
                    case 4: // No Asignado
                        btnCambiarEstado.Image = Proyecto_GestionAcademica_Grupo05.Properties.Resources.noasignado;
                        fkAsistencia_estado = "4";
                        break;
                    default:
                        
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en el método 'AsignarImagenDesdeEstadoAsistencia': " + ex.ToString());
            }
        }

        /*
        Evento que cambia la imagen y actualiza el estado de asistencia en la base de datos
        */
        private void btnCambiarEstado_Click(object sender, EventArgs e)
        {
            try
            {
                int estadoActual = int.Parse(fkAsistencia_estado);

                // Cambiar al siguiente estado (circular)
                estadoActual = (estadoActual % 4) + 1;

                // Asignar la imagen y actualizar la variable
                AsignarImagenDesdeEstadoAsistencia(estadoActual);
                fkAsistencia_estado = estadoActual.ToString();

                using (SqlConnection conexion = new SqlConnection($"server={Logins.ObtenerInstancia().nombreServidor}; database=GestorAcademico; integrated security=true"))
                {
                    conexion.Open();

                    string consulta = "UPDATE Asistencia SET fkAsistencia_estado = @estado WHERE fkUsuario = @idUsuario AND fkCurso = @idCurso AND fkSemana = @idSemana";

                    using (SqlCommand comando = new SqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@estado", estadoActual);
                        comando.Parameters.AddWithValue("@idUsuario", idEstudiante);
                        comando.Parameters.AddWithValue("@idCurso", idCurso);
                        comando.Parameters.AddWithValue("@idSemana", idSemana);

                        int filasAfectadas = comando.ExecuteNonQuery();

                        if (filasAfectadas > 0)
                        {
                            //MessageBox.Show("Estado de asistencia actualizado en la base de datos.");
                        }
                        else
                        {
                            MessageBox.Show("No se pudo actualizar el estado de asistencia en la base de datos.");
                        }
                    }

                    conexion.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error el evento 'btnCambiarEstado_Click': " + ex.ToString());
            }

        }

        private void lblNombre_Click(object sender, EventArgs e)
        {
            Form VistaPersona = new VistaPersona(idEstudiante, idEstudiante);

            CursoInicioProf cursoInicioProf = Application.OpenForms.OfType<CursoInicioProf>().FirstOrDefault();

            cursoInicioProf.AbrirFormHijo(VistaPersona);
        }
    }
}