using Proyecto_GestionAcademica_Grupo05.Formularios.Estudiante.Curso.btnAsignaciones_estudiante;
using Proyecto_GestionAcademica_Grupo05.Formularios.Profesor.Curso_profesor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_GestionAcademica_Grupo05.Formularios.Estudiante.FormularioHijo1.Curso
{
    public partial class VistaYEntregaAsignacion : Form
    {
        public string idCred;
        public string idCurso;
        public string idSemana;
        public string idAsignacion;
        public string idAsignacion_tipo;
        public string idAsignacion_modalidad;
        public string idAsignacion_X_Est_Grup;

        //Por si la asignacion es grupal, se guarda el id del grupo con el método 'obtenerIDGrupo'
        public string idGrupo;

        //Guardar la nota máxima de la asignación
        public int puntos_posibles;

        //Controlar fechas
        DateTime fechaLimite;
        DateTime fechaEntrega;

        public VistaYEntregaAsignacion(string idCred, string idCurso, string idSemana, string idAsignacion, string idAsignacion_tipo, string idAsignacion_modalidad, string idAsignacion_X_Est_Grup)
        {
            InitializeComponent();
            this.idCred = idCred;
            this.idCurso = idCurso;
            this.idSemana = idSemana;
            this.idAsignacion = idAsignacion;
            this.idAsignacion_tipo = idAsignacion_tipo;
            this.idAsignacion_modalidad = idAsignacion_modalidad;
            this.idAsignacion_X_Est_Grup = idAsignacion_X_Est_Grup;
            obtenerIDGrupo();
            cargarNombreArchivo();
            obtenerNombre();
            obtenerDetalle();
            obtenerPuntos();
            obtenerFecha();
            obtenerFechaEntrega();
            obtenerPuntosCalificados();
        }

        public void obtenerIDGrupo()
        {
            if (idAsignacion_modalidad == "1")
            {
                return;
            }
            else if (idAsignacion_modalidad == "2")
            {
                try
                {
                    using (SqlConnection conexion = new SqlConnection($"server={Logins.ObtenerInstancia().nombreServidor}; database =GestorAcademico; integrated security = true"))
                    {
                        conexion.Open();
                        string consulta = "SELECT fkGrupo FROM Asignacion_x_Grupo WHERE idAsignacion_x_Grupo =" + idAsignacion_X_Est_Grup;

                        using (SqlCommand comando = new SqlCommand(consulta, conexion))
                        {
                            using (SqlDataReader lector = comando.ExecuteReader())
                            {
                                while (lector.Read())
                                {
                                    idGrupo = lector.GetInt32(0).ToString();
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error en el método 'obtenerIDGrupo': " + ex.ToString());
                }
            }
        }

        public void cargarNombreArchivo()
        {
            try
            {
                if (idAsignacion_modalidad == "1")
                {
                    cargarNombreArchivoIndividual();
                }
                else if (idAsignacion_modalidad == "2")
                {
                    cargarNombreArchivoGrupal();
                }
            }catch  (Exception e) 
            {
                MessageBox.Show("Error en el método 'cargarNombreArchivo': " + e.ToString());
            }   
        }

        public void cargarNombreArchivoIndividual()
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection($"server={Logins.ObtenerInstancia().nombreServidor}; database =GestorAcademico; integrated security = true"))
                {
                    conexion.Open();

                    using (SqlCommand command = new SqlCommand("SELECT entrega FROM Asignacion_x_Estudiante WHERE fkAsignacion = @fkAsignacion AND fkUsuario = @fkUsuario", conexion))
                    {
                        command.Parameters.AddWithValue("@fkAsignacion", idAsignacion);
                        command.Parameters.AddWithValue("@fkUsuario", idCred);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                object entrega = reader["entrega"];

                                if (entrega != DBNull.Value)
                                {
                                    lblNombreArchivo.Text = "Ya se encuentra un archivo cargado";
                                }
                                else
                                {
                                    //En caso de que la entrega individual sea nula
                                    lblNombreArchivo.Text = "Ningún archivo cargado";
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error en el método 'cargarNombreArchivoIndividual': " + e.ToString());
            }           
        }

        public void cargarNombreArchivoGrupal()
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection($"server={Logins.ObtenerInstancia().nombreServidor}; database =GestorAcademico; integrated security = true"))
                {
                    conexion.Open();

                    using (SqlCommand command = new SqlCommand("SELECT entrega FROM Asignacion_x_Grupo WHERE fkAsignacion = @fkAsignacion AND fkGrupo = @fkGrupo", conexion))
                    {
                        command.Parameters.AddWithValue("@fkAsignacion", idAsignacion);
                        command.Parameters.AddWithValue("@fkGrupo", idGrupo);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                object entrega = reader["entrega"];

                                if (entrega != DBNull.Value)
                                {
                                    lblNombreArchivo.Text = "Ya se encuentra un archivo cargado";
                                }
                                else
                                {
                                    //En caso de que la entrega individual sea nula
                                    lblNombreArchivo.Text = "Ningún archivo cargado";
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error en el método 'cargarNombreArchivoGrupal': " + e.ToString());
            }
        }

        public void obtenerNombre()
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection($"server={Logins.ObtenerInstancia().nombreServidor}; database =GestorAcademico; integrated security = true"))
                {
                    conexion.Open();
                    string consulta = "SELECT nombre FROM Asignacion WHERE idAsignacion =" + idAsignacion;

                    using (SqlCommand comando = new SqlCommand(consulta, conexion))
                    {
                        using (SqlDataReader lector = comando.ExecuteReader())
                        {
                            while (lector.Read())
                            {
                                string nombreAsignacion = lector.GetString(0);
                                lblNombreAsignacion.Text = nombreAsignacion;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en el método 'obtenerNombre': " + ex.ToString());
            }
        }

        public void obtenerDetalle()
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection($"server={Logins.ObtenerInstancia().nombreServidor}; database =GestorAcademico; integrated security = true"))
                {
                    conexion.Open();
                    string consulta = "SELECT detalle FROM Asignacion WHERE idAsignacion =" + idAsignacion;

                    using (SqlCommand comando = new SqlCommand(consulta, conexion))
                    {
                        using (SqlDataReader lector = comando.ExecuteReader())
                        {
                            while (lector.Read())
                            {
                                string detalleAsignacion = lector.GetString(0);
                                txtInstrucciones.Text = detalleAsignacion;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en el método 'obtenerDetalle': " + ex.ToString());
            }
        }

        public void obtenerPuntos()
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection($"server={Logins.ObtenerInstancia().nombreServidor}; database =GestorAcademico; integrated security = true"))
                {
                    conexion.Open();
                    string consulta = "SELECT nota FROM Asignacion WHERE idAsignacion =" + idAsignacion;

                    using (SqlCommand comando = new SqlCommand(consulta, conexion))
                    {
                        using (SqlDataReader lector = comando.ExecuteReader())
                        {
                            while (lector.Read())
                            {
                                decimal nota = lector.GetDecimal(0);
                                puntos_posibles = (int)nota;

                                string notaFormateada = nota.ToString("0 Puntos Posibles");

                                lblPuntosPosibles.Text = notaFormateada;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en el método 'obtenerPuntos': " + ex.ToString());
            }
        }
        
        public void obtenerPuntosCalificados()
        {
            try
            {
                if (idAsignacion_modalidad == "1")
                {
                    using (SqlConnection conexion = new SqlConnection($"server={Logins.ObtenerInstancia().nombreServidor}; database =GestorAcademico; integrated security = true"))
                    {
                        conexion.Open();
                        string consulta = @"SELECT calificacion FROM Asignacion_x_Estudiante where fkAsignacion = @fkAsignacion AND fkUsuario = @fkUsuario";

                        using (SqlCommand comando = new SqlCommand(consulta, conexion))
                        {
                            comando.Parameters.AddWithValue("@fkAsignacion", idAsignacion);
                            comando.Parameters.AddWithValue("@fkUsuario", idCred);

                            using (SqlDataReader lector = comando.ExecuteReader())
                            {
                                if (lector.Read())
                                {
                                    if (!lector.IsDBNull(0)) // Verificar si el valor no es nulo
                                    {
                                        double calificacion_ = lector.GetDouble(0);
                                        lblPuntajeCalificado.Text = "Puntaje obtenido: " + calificacion_ + "/" + (int)puntos_posibles;
                                    }
                                    else
                                    {
                                        lblPuntajeCalificado.Text = "Puntaje obtenido: -/" + (int)puntos_posibles;
                                    }
                                }
                                else
                                {
                                    lblPuntajeCalificado.Text = "Puntaje obtenido: -/" + (int)puntos_posibles;
                                }
                            }
                        }
                    }
                }
                else if (idAsignacion_modalidad == "2")
                {
                    using (SqlConnection conexion = new SqlConnection($"server={Logins.ObtenerInstancia().nombreServidor}; database =GestorAcademico; integrated security = true"))
                    {
                        conexion.Open();
                        string consulta = @"SELECT calificacion FROM Asignacion_x_Grupo WHERE fkAsignacion = @fkAsignacion AND fkGrupo = @fkGrupo";

                        using (SqlCommand comando = new SqlCommand(consulta, conexion))
                        {
                            comando.Parameters.AddWithValue("@fkAsignacion", idAsignacion);
                            comando.Parameters.AddWithValue("@fkGrupo", idGrupo);

                            using (SqlDataReader lector = comando.ExecuteReader())
                            {
                                if (lector.Read())
                                {
                                    if (!lector.IsDBNull(0)) // Verificar si el valor no es nulo
                                    {
                                        double calificacion_ = lector.GetDouble(0);
                                        lblPuntajeCalificado.Text = "Puntaje obtenido: " + calificacion_ + "/" + (int)puntos_posibles;
                                    }
                                    else
                                    {
                                        lblPuntajeCalificado.Text = "Puntaje obtenido: -/" + (int)puntos_posibles;
                                    }
                                }
                                else
                                {
                                    lblPuntajeCalificado.Text = "Puntaje obtenido: -/" + (int)puntos_posibles;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en el método 'obtenerPuntajeCalificado': " + ex.ToString());
            }
        }

        public void obtenerFecha()
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection($"server={Logins.ObtenerInstancia().nombreServidor}; database =GestorAcademico; integrated security = true"))
                {
                    conexion.Open();
                    string consulta = "SELECT fecha_limite FROM Asignacion WHERE idAsignacion =" + idAsignacion;

                    using (SqlCommand comando = new SqlCommand(consulta, conexion))
                    {
                        using (SqlDataReader lector = comando.ExecuteReader())
                        {
                            while (lector.Read())
                            {
                                DateTime fecha = lector.GetDateTime(0);
                                fechaLimite = fecha;

                                string fechaFormateada = fecha.ToString("dddd d 'de' MMM", new CultureInfo("es-ES")).ToLower().TrimEnd('.');

                                string resultado = $"Fecha de entrega: {fechaFormateada}";

                                lblFechaAsignacion.Text = resultado;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en el método 'obtenerFecha': " + ex.ToString());
            }
        }

        public void obtenerFechaEntrega()
        {
            try
            {
                if (idAsignacion_modalidad == "1")
                {
                    using (SqlConnection conexion = new SqlConnection($"server={Logins.ObtenerInstancia().nombreServidor}; database =GestorAcademico; integrated security = true"))
                    {
                        conexion.Open();
                        string consulta = "SELECT fecha_entrega FROM Asignacion_x_Estudiante WHERE fkUsuario = @fkUsuario AND fkAsignacion = @fkAsignacion";

                        using (SqlCommand comando = new SqlCommand(consulta, conexion))
                        {
                            comando.Parameters.AddWithValue("@fkUsuario", idCred);
                            comando.Parameters.AddWithValue("@fkAsignacion", idAsignacion);
                            using (SqlDataReader lector = comando.ExecuteReader())
                            {
                                while (lector.Read())
                                {
                                    if (!lector.IsDBNull(0)) // Verificar si el valor en la columna es nulo
                                    {
                                        DateTime fecha = lector.GetDateTime(0);

                                        fechaEntrega = fecha;

                                        string fechaFormateada = fecha.ToString("dddd d 'de' MMM", new CultureInfo("es-ES")).ToLower().TrimEnd('.');

                                        string resultado = $"ENTREGADO: {fechaFormateada}";

                                        lblFechaEntrega.Text = resultado;

                                        if (fechaLimite > fechaEntrega)
                                        {
                                            lblEstadoEntrega.Text = "Entregado a tiempo";
                                        }
                                        else if (fechaLimite < fechaEntrega)
                                        {
                                            lblEstadoEntrega.Text = "Entregado tarde";
                                        }
                                        else if (fechaLimite == fechaEntrega)
                                        {
                                            lblEstadoEntrega.Text = "Entregado a tiempo";
                                        }
                                        else
                                        {
                                            lblEstadoEntrega.Text = "No se ha recibido ninguna entrega";
                                        }
                                    }
                                    else
                                    {
                                        // Manejo de la situación cuando el valor es nulo
                                        lblFechaEntrega.Text = " ";
                                        lblEstadoEntrega.Text = "No se ha recibido ninguna entrega";
                                    }
                                }
                            }
                        }
                    }
                }
                else if (idAsignacion_modalidad == "2")
                {
                    using (SqlConnection conexion = new SqlConnection($"server={Logins.ObtenerInstancia().nombreServidor}; database =GestorAcademico; integrated security = true"))
                    {
                        conexion.Open();
                        string consulta = "SELECT fecha_entrega FROM Asignacion_x_Grupo WHERE fkAsignacion = @fkAsignacion AND fkGrupo = @fkGrupo";

                        using (SqlCommand comando = new SqlCommand(consulta, conexion))
                        {
                            comando.Parameters.AddWithValue("@fkAsignacion", idAsignacion);
                            comando.Parameters.AddWithValue("@fkGrupo", idGrupo);
                            using (SqlDataReader lector = comando.ExecuteReader())
                            {
                                while (lector.Read())
                                {
                                    if (!lector.IsDBNull(0)) // Verificar si el valor en la columna es nulo
                                    {
                                        DateTime fecha = lector.GetDateTime(0);

                                        fechaEntrega = fecha;

                                        string fechaFormateada = fecha.ToString("dddd d 'de' MMM", new CultureInfo("es-ES")).ToLower().TrimEnd('.');

                                        string resultado = $"ENTREGADO: {fechaFormateada}";

                                        lblFechaEntrega.Text = resultado;

                                        if (fechaLimite > fechaEntrega)
                                        {
                                            lblEstadoEntrega.Text = "Entregado a tiempo";
                                        }
                                        else if (fechaLimite < fechaEntrega)
                                        {
                                            lblEstadoEntrega.Text = "Entregado tarde";
                                        }
                                        else if (fechaLimite == fechaEntrega)
                                        {
                                            lblEstadoEntrega.Text = "Entregado a tiempo";
                                        }
                                        else
                                        {
                                            lblEstadoEntrega.Text = "No se ha recibido ninguna entrega";
                                        }
                                    }
                                    else
                                    {
                                        // Manejo de la situación cuando el valor es nulo
                                        lblFechaEntrega.Text = " ";
                                        lblEstadoEntrega.Text = "No se ha recibido ninguna entrega";
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en el método 'obtenerFechaEntrega': " + ex.ToString());
            }
        }

        private void btnSubirTarea_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar si ya hay una entrega existente.
                byte[] entregaExistente = obtenerEntrega(idAsignacion, idCred);

                if (entregaExistente != null)
                {
                    MessageBox.Show("Ya has realizado una entrega previa. No puedes realizar otra entrega.");
                    return; // Salir del método si ya hay una entrega existente.
                }

                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "Archivos PDF|*.pdf|Archivos compatibles|*.doc;*.docx;*.txt|Todos los archivos|*.*";

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string fileName = Path.GetFileName(openFileDialog.FileName);
                        string fileExtension = Path.GetExtension(openFileDialog.FileName).ToLower();

                        if (fileExtension == ".pdf")
                        {
                            byte[] fileContent = File.ReadAllBytes(openFileDialog.FileName);

                            // Insertar la entrega en la tabla Asignacion_x_Estudiante.
                            insertarEntrega(idAsignacion, idCred, idSemana, fileContent);

                            MessageBox.Show("Entrega enviada correctamente.");
                            cargarNombreArchivo();
                            obtenerFechaEntrega();
                        }
                        else
                        {
                            MessageBox.Show("Por favor, seleccione un archivo PDF.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en el evento 'btnSubirTarea_Click': " + ex.ToString());
            }           
        }

        private void insertarEntrega(string idAsignacion, string idUsuario, string idSemana, byte[] fileContent)
        {
            try
            {
                if (idAsignacion_modalidad == "1")
                {
                    using (SqlConnection conexion = new SqlConnection($"server={Logins.ObtenerInstancia().nombreServidor}; database =GestorAcademico; integrated security = true"))
                    {
                        conexion.Open();

                        using (SqlCommand command = new SqlCommand("UPDATE Asignacion_x_Estudiante SET entrega = @entrega, fecha_entrega = GETDATE() WHERE idAsignacion_x_Estudiante = @idAsignacion_x_Estudiante", conexion))
                        {
                            command.Parameters.AddWithValue("@idAsignacion_x_Estudiante", idAsignacion_X_Est_Grup);
                            command.Parameters.AddWithValue("@entrega", fileContent);

                            command.ExecuteNonQuery();
                        }
                    }
                }
                else if (idAsignacion_modalidad == "2")
                {
                    using (SqlConnection conexion = new SqlConnection($"server={Logins.ObtenerInstancia().nombreServidor}; database =GestorAcademico; integrated security = true"))
                    {
                        conexion.Open();

                        using (SqlCommand command = new SqlCommand("UPDATE Asignacion_x_Grupo SET entrega = @entrega, fecha_entrega = GETDATE() WHERE idAsignacion_x_Grupo = @idAsignacion_x_Grupo", conexion))
                        {
                            command.Parameters.AddWithValue("@idAsignacion_x_Grupo", idAsignacion_X_Est_Grup);
                            command.Parameters.AddWithValue("@entrega", fileContent);

                            command.ExecuteNonQuery();
                        }
                    }
                }

            }catch (Exception ex) 
            {
                MessageBox.Show("Error en el método 'insertarEntrega': " + ex.ToString());
            }           
        }

        private void btnDescargarArchivo_Click(object sender, EventArgs e)
        {
            try
            {
                //Se obtiene la entrega desde la base de datos.
                byte[] entrega = obtenerEntrega(idAsignacion, idCred);

                //Verifica que haya algo en la entrega antes de descargar
                if (entrega != null)
                {
                    //Se permite al usuario elegir dónde guardar el archivo descargado.
                    using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                    {
                        saveFileDialog.Filter = "Archivos compatibles|*.pdf;*.doc;*.docx;*.txt|Todos los archivos|*.*";
                        saveFileDialog.Title = "Guardar Archivo";


                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            // Guarda el archivo descargado en la ubicación seleccionada por el usuario.
                            File.WriteAllBytes(saveFileDialog.FileName, entrega);

                            MessageBox.Show("Entrega descargada correctamente.");
                        }
                        else
                        {
                            MessageBox.Show("No se ha podido descargar correctamente.");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No se encontró una entrega para descargar.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en el evento 'btnDescargarArchivo_Click': " + ex.ToString());
            }
        }

        private byte[] obtenerEntrega(string idAsignacion, string idUsuario)
        {
            if (idAsignacion_modalidad == "1")
            {
                byte[] entrega = null;

                using (SqlConnection conexion = new SqlConnection($"server={Logins.ObtenerInstancia().nombreServidor}; database =GestorAcademico; integrated security = true"))
                {
                    conexion.Open();

                    string consulta = @"SELECT ae.entrega 
                                        FROM Asignacion_x_Estudiante ae
                                        JOIN Asignacion a ON ae.fkAsignacion = a.idAsignacion
                                        WHERE ae.fkAsignacion = @fkAsignacion
                                        AND ae.fkUsuario = @fkUsuario
                                        AND a.fkCurso = @fkCurso;";

                    using (SqlCommand command = new SqlCommand(consulta, conexion))
                    {
                        command.Parameters.AddWithValue("@fkAsignacion", idAsignacion);
                        command.Parameters.AddWithValue("@fkUsuario", idUsuario);
                        command.Parameters.AddWithValue("@fkCurso", idCurso);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                if (!reader.IsDBNull(reader.GetOrdinal("entrega")))
                                {
                                    entrega = (byte[])reader["entrega"];
                                }
                            }
                        }
                    }
                }
                return entrega;
            }
            else if (idAsignacion_modalidad == "2")
            {
                byte[] entrega = null;

                using (SqlConnection conexion = new SqlConnection($"server={Logins.ObtenerInstancia().nombreServidor}; database =GestorAcademico; integrated security = true"))
                {
                    conexion.Open();

                    string consultaG = @"SELECT ag.entrega 
                                        FROM Asignacion_x_Grupo ag
                                        JOIN Asignacion a ON ag.fkAsignacion = a.idAsignacion
                                        WHERE ag.fkAsignacion = @fkAsignacion
                                        AND ag.fkGrupo = @fkGrupo
                                        AND a.fkCurso = @fkCurso;";

                    using (SqlCommand command = new SqlCommand(consultaG, conexion))
                    {
                        command.Parameters.AddWithValue("@fkAsignacion", idAsignacion);
                        command.Parameters.AddWithValue("@fkGrupo", idGrupo);
                        command.Parameters.AddWithValue("@fkCurso", idCurso);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                if (!reader.IsDBNull(reader.GetOrdinal("entrega")))
                                {
                                    entrega = (byte[])reader["entrega"];
                                }
                            }
                        }
                    }
                }
                return entrega;
            }
            else
            {
                byte[] entrega = null;
                return entrega;
            }
        }

        private void btnAgregarComentarios_Click(object sender, EventArgs e)
        {
            ReclamosAsignaciones reclamosAsignaciones = new ReclamosAsignaciones(idCred, idCurso, idAsignacion);
            reclamosAsignaciones.Show();
        }
    }
}
