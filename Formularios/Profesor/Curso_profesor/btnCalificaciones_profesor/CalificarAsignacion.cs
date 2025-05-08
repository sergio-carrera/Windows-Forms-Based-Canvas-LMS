using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_GestionAcademica_Grupo05.Formularios.Profesor.Curso_profesor.btnAsignaciones_profesor
{
    public partial class CalificarAsignacion : Form
    {
        public string nombre_Estudiante_O_Grupo;
        public string idCred;
        public string idCurso;
        public string idAsignacion;
        public string idAsignacion_tipo;
        public string idAsignacion_modalidad;
        public string idAsignacion_X_Est_Grup;

        //En caso de que la asignación sea individual
        public string nombreEstudiante;
        public string idEstudiante;
        //En caso de que la asignación sea grupal
        public string nombreGrupo;
        public string idGrupo;

        DateTime fechaLimite;
        DateTime fechaEntrega;

        public decimal puntos_posibles;

        public CalificarAsignacion(string nombre_Estudiante_O_Grupo, string idCred, string idCurso, string idAsignacion, string idAsignacion_tipo, string idAsignacion_modalidad, string idAsignacion_X_Est_Grup)
        {
            InitializeComponent();
            this.nombre_Estudiante_O_Grupo = nombre_Estudiante_O_Grupo;
            this.idCred = idCred;
            this.idCurso = idCurso;
            this.idAsignacion = idAsignacion;
            this.idAsignacion_tipo = idAsignacion_tipo;
            this.idAsignacion_modalidad = idAsignacion_modalidad;
            this.idAsignacion_X_Est_Grup = idAsignacion_X_Est_Grup;
            //MessageBox.Show("idAsignacion_X_Est_Grup: " + idAsignacion_X_Est_Grup);

            if (idAsignacion_modalidad == "1")
            {
                convertirNombreEstudianteOGrupo();
                obtenerIdEstudiante();
            }
            else if (idAsignacion_modalidad == "2")
            {
                convertirNombreEstudianteOGrupo();
                obtenerIdGrupo();
            }
            else
            {
                MessageBox.Show("No se ha obtenido un valor para 'idAsignacion_modalidad' correcto");
            }

            obtenerNombreAsignacion();
            obtenerDetalle();
            obtenerPuntos();
            obtenerFechaLimite();
            cargarNombreArchivo();
            obtenerFechaEntrega();
            obtenerPuntajeCalificado();
        }

        /*
        Método que obtiene el nombre del estudiante o grupo.
        En caso de que la aignación sea "individual", entonces 
        el nombre del estudiante se obtiene con un ".Split(' ')" para
        dividir el nombre completo que se pasa desde el formulario
        'VistaYCalificacionAsignacion'. Con esto se obtiene solo el
        nombre y no los apellidos, que nos servirá para obtener posteriormente
        el id del estudiante de la tabla 'Usuario'
        */
        public void convertirNombreEstudianteOGrupo()
        {
            try
            {
                if (idAsignacion_modalidad == "1")
                {
                    string[] partes = nombre_Estudiante_O_Grupo.Split(' ');
                    nombreEstudiante = partes[0];
                }
                else if (idAsignacion_modalidad == "2")
                {
                    nombreGrupo = nombre_Estudiante_O_Grupo;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error en el método 'convertirNombreEstudiante': " + e.ToString());
            }
        }

        public void obtenerIdEstudiante()
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection($"server={Logins.ObtenerInstancia().nombreServidor}; database =GestorAcademico; integrated security = true"))
                {
                    conexion.Open();
                    string consulta = "SELECT idUsuario FROM Usuario WHERE nombre = @nombreEstudiante";

                    using (SqlCommand comando = new SqlCommand(consulta, conexion))                       
                    {
                        comando.Parameters.AddWithValue("@nombreEstudiante", nombreEstudiante);
                        using (SqlDataReader lector = comando.ExecuteReader())
                        {
                            while (lector.Read())
                            {
                                string idUsuario_ = lector.GetInt32(0).ToString();
                                idEstudiante = idUsuario_;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en el método 'obtenerIdEstudiante': " + ex.ToString());
            }
        }

        public void obtenerIdGrupo()
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection($"server={Logins.ObtenerInstancia().nombreServidor}; database =GestorAcademico; integrated security = true"))
                {
                    conexion.Open();
                    string consulta = "SELECT idGrupo FROM Grupo WHERE fkCurso = @idCurso AND nombreGrupo = @nombreGrupo";

                    using (SqlCommand comando = new SqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@idCurso", idCurso);
                        comando.Parameters.AddWithValue("@nombreGrupo", nombreGrupo);
                        using (SqlDataReader lector = comando.ExecuteReader())
                        {
                            while (lector.Read())
                            {
                                string idGrupo_ = lector.GetInt32(0).ToString();
                                idGrupo = idGrupo_;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en el método 'obtenerIdGrupo': " + ex.ToString());
            }
        }

        public void obtenerPuntajeCalificado()
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
                            comando.Parameters.AddWithValue("@fkUsuario", idEstudiante);

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

        public void cargarNombreArchivo()
        {
            try
            {
                if (idAsignacion_modalidad == "1")
                {
                    using (SqlConnection conexion = new SqlConnection($"server={Logins.ObtenerInstancia().nombreServidor}; database =GestorAcademico; integrated security = true"))
                    {
                        conexion.Open();

                        using (SqlCommand command = new SqlCommand("SELECT entrega FROM Asignacion_x_Estudiante WHERE fkAsignacion = @fkAsignacion AND fkUsuario = @fkUsuario", conexion))
                        {
                            command.Parameters.AddWithValue("@fkAsignacion", idAsignacion);
                            command.Parameters.AddWithValue("@fkUsuario", idEstudiante);

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
                                        //En caso de que la entrega sea nula
                                        lblNombreArchivo.Text = "Ningún archivo cargado";
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
                                        //En caso de que la entrega sea nula
                                        lblNombreArchivo.Text = "Ningún archivo cargado";
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en el método 'cargarNombreArchivo': " + ex.ToString());
            }   
        }

        //Métodos para rellenar nombre, detalle, puntos y fecha de la asignación
        public void obtenerNombreAsignacion()
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

                MessageBox.Show("Error en el método 'obtenerNombreAsignacion': " + ex.ToString());
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
                                puntos_posibles = nota;
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

        public void obtenerFechaLimite()
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

                MessageBox.Show("Error en el método 'obtenerFechaLimite': " + ex.ToString());
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
                            comando.Parameters.AddWithValue("@fkUsuario", idEstudiante);
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

        private void txtPuntajeObtenido_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b') // Permitir solo dígitos y retroceso (backspace)
            {
                e.Handled = true;
            }
            else
            {
                // Si el carácter es un dígito, verifica el valor del número ingresado
                string currentText = textBox.Text + e.KeyChar;

                if (!string.IsNullOrEmpty(currentText) && int.TryParse(currentText, out int number))
                {
                    if (number < 0 || number > puntos_posibles || (currentText.StartsWith("0") && currentText.Length > 1))
                    {
                        e.Handled = true; // No permitir números fuera del rango 0-puntos_posibles y no permitir números después de un "0"
                    }
                }
            }
        }

        private void btnDescargarArchivo_Click(object sender, EventArgs e)
        {
            try
            {
                //Se obtiene la entrega desde la base de datos.
                byte[] entrega = obtenerEntrega(idAsignacion, idEstudiante);

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

        private byte[] obtenerEntrega(string idAsignacion, string idEstudiante)
        {
            if (idAsignacion_modalidad == "1")
            {
                byte[] entrega = null;

                //Se implementa la lógica para obtener la entrega desde la base de datos.
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
                        command.Parameters.AddWithValue("@fkUsuario", idEstudiante);
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

                //Se implementa la lógica para obtener la entrega desde la base de datos.
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

        private void btnCalificarTarea_Click(object sender, EventArgs e)
        {
            try
            {
                if (idAsignacion_modalidad == "1")
                {
                    if (txtPuntajeObtenido.Text == "" || txtPuntajeObtenido.Text == null)
                    {
                        MessageBox.Show("Favor de ingresar un puntaje a la asignación");
                    }
                    else
                    {
                        using (SqlConnection conexion = new SqlConnection($"server={Logins.ObtenerInstancia().nombreServidor}; database =GestorAcademico; integrated security = true"))
                        {
                            conexion.Open();
                            string consulta = @"UPDATE Asignacion_x_Estudiante
                                                SET calificacion = @nuevaCalificacion
                                                FROM Asignacion_x_Estudiante ae
                                                JOIN Asignacion a ON ae.fkAsignacion = a.idAsignacion
                                                WHERE ae.fkAsignacion = @fkAsignacion
                                                AND ae.fkUsuario = @fkUsuario
                                                AND a.fkCurso = @fkCurso;";

                            using (SqlCommand comando = new SqlCommand(consulta, conexion))
                            {
                                comando.Parameters.AddWithValue("@fkAsignacion", idAsignacion);
                                comando.Parameters.AddWithValue("@nuevaCalificacion", float.Parse(txtPuntajeObtenido.Text));
                                comando.Parameters.AddWithValue("@fkUsuario", idEstudiante);
                                comando.Parameters.AddWithValue("@fkCurso", idCurso);
                                comando.ExecuteNonQuery();
                                MessageBox.Show("Se ha calificado correctamente la asignación");
                                txtPuntajeObtenido.Text = "";
                                obtenerPuntajeCalificado();
                            }
                        }

                    }
                }
                else if (idAsignacion_modalidad == "2")
                {
                    if (txtPuntajeObtenido.Text == "" || txtPuntajeObtenido.Text == null)
                    {
                        MessageBox.Show("Favor de ingresar un puntaje a la asignación");
                    }
                    else
                    {
                        using (SqlConnection conexion = new SqlConnection($"server={Logins.ObtenerInstancia().nombreServidor}; database =GestorAcademico; integrated security = true"))
                        {
                            conexion.Open();
                            string consulta = @"UPDATE Asignacion_x_Grupo
                                                SET calificacion = @nuevaCalificacion
                                                FROM Asignacion_x_Grupo ag
                                                JOIN Asignacion a ON ag.fkAsignacion = a.idAsignacion
                                                WHERE ag.fkAsignacion = @fkAsignacion
                                                AND ag.fkGrupo = @fkGrupo
                                                AND a.fkCurso = @fkCurso;";

                            using (SqlCommand comando = new SqlCommand(consulta, conexion))
                            {
                                comando.Parameters.AddWithValue("@fkAsignacion", idAsignacion);
                                comando.Parameters.AddWithValue("@nuevaCalificacion", float.Parse(txtPuntajeObtenido.Text));
                                comando.Parameters.AddWithValue("@fkGrupo", idGrupo);
                                comando.Parameters.AddWithValue("@fkCurso", idCurso);
                                comando.ExecuteNonQuery();
                                MessageBox.Show("Se ha calificado correctamente la asignación");
                                txtPuntajeObtenido.Text = "";
                                obtenerPuntajeCalificado();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en el evento de 'btnCalificarTarea_Click': " + ex.ToString());
            }
        }
    }
}
