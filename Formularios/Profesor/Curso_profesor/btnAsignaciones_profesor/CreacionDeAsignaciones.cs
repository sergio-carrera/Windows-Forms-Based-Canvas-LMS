using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Forms;

namespace Proyecto_GestionAcademica_Grupo05.Formularios.Profesor.Curso_profesor.btnAsignaciones
{
    public partial class CreacionDeAsignaciones : Form
    {
        public CursoInicioProf FormularioPadre { get; set; }

        public string idCred;
        public string idCurso;
        public string nombreCurso;

        public int id_Asignacion; //Se asigna sumándole 1 al último registro de id_Asignacion en la tabla Asignacion
        public int id_Asignacion_tipo;
        public int id_Asignacion_modalidad;

        public int id_Semana;
        public int id_Asignacion_x_Estudiante;
        public int id_Asignacion_x_Grupo;

        public int cantidadEstudiantesEnElCurso;
        public int cantidadEstudiantesConGrupos = 0;

        public CreacionDeAsignaciones(string idCred, string idCurso, string nombreCurso)
        {
            InitializeComponent();
            this.idCred = idCred;
            this.idCurso = idCurso;
            this.nombreCurso = nombreCurso;
            obtenerCantEst();
            obtenerCantEstEnGrupos();
        }

        //Eventos designados para los placeholder
        private void txtNombreAsignacion_Enter(object sender, EventArgs e)
        {
            if (txtNombreAsignacion.Text == "Ingrese el título de la asignación")
            {
                txtNombreAsignacion.Text = "";
                txtNombreAsignacion.ForeColor = Color.Black;
            }
        }

        private void txtNombreAsignacion_MouseLeave(object sender, EventArgs e)
        {
            if (txtNombreAsignacion.Text == "")
            {
                txtNombreAsignacion.Text = "Ingrese el título de la asignación";
                txtNombreAsignacion.ForeColor = Color.DarkGray;
            }
        }

        private void txtDetalleAsignacion_Enter(object sender, EventArgs e)
        {
            if (txtDetalleAsignacion.Text == "Agregue el detalle de la asignación")
            {
                txtDetalleAsignacion.Text = "";
                txtDetalleAsignacion.ForeColor = Color.Black;
            }
        }

        private void txtDetalleAsignacion_Leave(object sender, EventArgs e)
        {
            if (txtDetalleAsignacion.Text == "")
            {
                txtDetalleAsignacion.Text = "Agregue el detalle de la asignación";
                txtDetalleAsignacion.ForeColor = Color.DarkGray;
            }
        }

        //Método que permite ingresar solo números del 0 - 100 como nota
        private void txtPuntos_KeyPress(object sender, KeyPressEventArgs e)
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
                    if (number < 0 || number > 100 || (currentText.StartsWith("0") && currentText.Length > 1))
                    {
                        e.Handled = true; // No permitir números fuera del rango 0-100 y no permitir números después de un "0"
                    }
                }
            }
        }

        //Botones
        private void btnCancelarAsignacion_Click(object sender, EventArgs e)
        {
            FormularioPadre.Cancelar();
        }

        private void btnCrearAsignacion2_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNombreAsignacion.Text != "" || txtNombreAsignacion.Text != "Ingrese el título de la asignación")
                {
                    if (txtSemanaAsignacion.Text != null || txtSemanaAsignacion.Text != "")
                    {
                        if (txtModalidadAsignacion.Text != null || txtModalidadAsignacion.Text != "")
                        {
                            if (txtTipoAsignacion.Text != null || txtTipoAsignacion.Text != "")
                            {
                                if (txtPuntosAsignacion.Text != "")
                                {
                                    if (txtDetalleAsignacion.Text != "" || txtDetalleAsignacion.Text != "Agregue el detalle de la asignación")
                                    {
                                        insertarAsignacion();
                                    }
                                }
                            }
                        }
                    }   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString()); 
            }
        }

        //Métodos obtención de datos
        public void obtenerCantEst()
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection($"server={Logins.ObtenerInstancia().nombreServidor}; database =GestorAcademico; integrated security = true"))
                {
                    conexion.Open();

                    string consulta = @"SELECT COUNT(DISTINCT U.idUsuario) AS CantidadEstudiantes
                                FROM Usuario U
                                JOIN Usuario_x_Curso UC ON U.idUsuario = UC.fkUsuario
                                JOIN Curso C ON UC.fkCurso = C.idCurso
                                JOIN Credencial CR ON U.fkCredencial = CR.idCredencial
                                JOIN CredencialTipo CT ON CR.fkCredencialTipo = CT.idCredencialTipo
                                WHERE CT.tipo = 'estudiante'
                                AND C.idCurso = @idCurso;";

                    using (SqlCommand comando = new SqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@idCurso", idCurso);

                        using (SqlDataReader reader = comando.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                reader.Read();
                                cantidadEstudiantesEnElCurso = reader.GetInt32(reader.GetOrdinal("CantidadEstudiantes"));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en el método 'obtenerCantEst': " + ex.ToString());
            }
        }

        public void obtenerCantEstEnGrupos()
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection($"server={Logins.ObtenerInstancia().nombreServidor}; database =GestorAcademico; integrated security = true"))
                {
                    conexion.Open();

                    string consulta = @"SELECT U.idUsuario, U.nombre, U.apellido1, U.apellido2, G.nombreGrupo " +
                             "FROM Usuario_x_Grupo UxG " +
                             "JOIN Usuario U ON UxG.fkUsuario = U.idUsuario " +
                             "JOIN Grupo G ON UxG.fkGrupo = G.idGrupo " +
                             "JOIN Curso C ON G.fkCurso = C.idCurso " +
                             "WHERE C.idCurso = @idCurso;";

                    using (SqlCommand comando = new SqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@idCurso", idCurso);

                        using (SqlDataReader reader = comando.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                Console.WriteLine("Se encontraron resultados:");

                                while (reader.Read())
                                {
                                    cantidadEstudiantesConGrupos++;
                                }
                            }
                            else
                            {
                                Console.WriteLine("No se encontraron resultados.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en el método 'obtenerCantEstEnGrupos': " + ex.ToString());
            }
        }

        private void obtenerIDAsignacion()
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection($"server={Logins.ObtenerInstancia().nombreServidor}; database =GestorAcademico; integrated security = true"))
                {
                    conexion.Open();
                    string cadenaVerificarPK = "SELECT * from Asignacion ORDER BY idAsignacion DESC";

                    using (SqlCommand comando = new SqlCommand(cadenaVerificarPK, conexion))
                    {
                        object result = comando.ExecuteScalar();

                        if (result != null && result != DBNull.Value)
                        {
                            id_Asignacion = (int)result + 1;
                        }
                        else
                        {
                            id_Asignacion = 1;
                        }
                    }
                    conexion.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en el método 'obtenerIDAsignacion': " + ex.ToString());
            }
        }
        
        private void obtenerIDAsignacion_x_Estudiante()
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection($"server={Logins.ObtenerInstancia().nombreServidor}; database =GestorAcademico; integrated security = true"))
                {
                    conexion.Open();
                    string cadenaVerificarPK = "SELECT * from Asignacion_x_Estudiante ORDER BY idAsignacion_x_Estudiante DESC";

                    using (SqlCommand comando = new SqlCommand(cadenaVerificarPK, conexion))
                    {
                        object result = comando.ExecuteScalar();

                        if (result != null && result != DBNull.Value)
                        {
                            id_Asignacion_x_Estudiante = (int)result + 1;
                        }
                        else
                        {
                            id_Asignacion_x_Estudiante = 1;
                        }
                    }
                    conexion.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en el método 'obtenerIDAsignacion_x_Estudiante': " + ex.ToString());
            }
        }
        
        private void obtenerIDAsignacion_x_Grupo()
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection($"server={Logins.ObtenerInstancia().nombreServidor}; database =GestorAcademico; integrated security = true"))
                {
                    conexion.Open();
                    string cadenaVerificarPK = "SELECT * from Asignacion_x_Grupo ORDER BY idAsignacion_x_Grupo DESC";

                    using (SqlCommand comando = new SqlCommand(cadenaVerificarPK, conexion))
                    {
                        object result = comando.ExecuteScalar();

                        if (result != null && result != DBNull.Value)
                        {
                            id_Asignacion_x_Grupo = (int)result + 1;
                        }
                        else
                        {
                            id_Asignacion_x_Grupo = 1;
                        }
                    }
                    conexion.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en el método 'obtenerIDAsignacion_x_Grupo': " + ex.ToString());
            }
        }

        private void obtenerAsignacion_tipo()
        {
            if (txtTipoAsignacion.Text == "Tarea")
            {
                id_Asignacion_tipo = 1;
            }
            else if (txtTipoAsignacion.Text == "Laboratorio")
            {
                id_Asignacion_tipo = 2;
            }
            else if (txtTipoAsignacion.Text == "Proyecto")
            {
                id_Asignacion_tipo = 3;
            }
        }

        private void obtenerAsignacion_modalidad()
        {
            if (txtModalidadAsignacion.Text == "Individual")
            {
                id_Asignacion_modalidad = 1;
            }
            else if (txtModalidadAsignacion.Text == "Grupal")
            {
                id_Asignacion_modalidad = 2;
            }
        }

        public void obtenerSemana()
        {
            if (txtSemanaAsignacion.Text == "Semana 1")
            {
                id_Semana = 1;
            }
            else if (txtSemanaAsignacion.Text == "Semana 2")
            {
                id_Semana = 2;
            }
            else if (txtSemanaAsignacion.Text == "Semana 3")
            {
                id_Semana = 3;
            }
            else if (txtSemanaAsignacion.Text == "Semana 4")
            {
                id_Semana = 4;
            }
            else if (txtSemanaAsignacion.Text == "Semana 5")
            {
                id_Semana = 5;
            }
            else if (txtSemanaAsignacion.Text == "Semana 6")
            {
                id_Semana = 6;
            }
            else if (txtSemanaAsignacion.Text == "Semana 7")
            {
                id_Semana = 7;
            }
            else if (txtSemanaAsignacion.Text == "Semana 8")
            {
                id_Semana = 8;
            }
            else if (txtSemanaAsignacion.Text == "Semana 9")
            {
                id_Semana = 9;
            }
            else if (txtSemanaAsignacion.Text == "Semana 10")
            {
                id_Semana = 10;
            }
            else if (txtSemanaAsignacion.Text == "Semana 11")
            {
                id_Semana = 11;
            }
            else if (txtSemanaAsignacion.Text == "Semana 12")
            {
                id_Semana = 12;
            }
            else if (txtSemanaAsignacion.Text == "Semana 13")
            {
                id_Semana = 13;
            }
            else if (txtSemanaAsignacion.Text == "Semana 14")
            {
                id_Semana = 14;
            }
            else if (txtSemanaAsignacion.Text == "Semana 15")
            {
                id_Semana = 15;
            }
        }

        private void insertarAsignacion()
        {

            try
            {
                obtenerIDAsignacion();
                obtenerAsignacion_tipo();
                obtenerAsignacion_modalidad();
                obtenerSemana();

                if (id_Asignacion_modalidad == 2)
                {
                    if (cantidadEstudiantesEnElCurso == cantidadEstudiantesConGrupos)
                    {
                        crearAsignacion();
                    }
                    else 
                    {
                        MessageBox.Show("Se deben asignar grupos a todos los estudiantes del curso antes de crear una asignación grupal");
                    }
                }
                else if (id_Asignacion_modalidad == 1)
                {
                    crearAsignacion();
                }   
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en el método 'insertarAsignacion': " + ex.ToString());
            }            
        }

        public void crearAsignacion()
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection($"server={Logins.ObtenerInstancia().nombreServidor}; database =GestorAcademico; integrated security = true"))
                {
                    conexion.Open();
                    string cadena = "INSERT INTO Asignacion (idAsignacion, fkCurso, fkAsignacion_tipo, fkAsignacion_modalidad, nombre, detalle, fecha_limite, entrega, nota) VALUES (@id_Asignacion, @idCurso, @txtTipoAsignacion, @txtModalidadAsignacion, @txtNombreAsignacion, @txtDetalleAsignacion, @fecha_limite, CONVERT(varbinary, @txtNombreAsignacion), @txtPuntosAsignacion)";
                    using (SqlCommand comando = new SqlCommand(cadena, conexion))
                    {
                        comando.Parameters.AddWithValue("@id_Asignacion", id_Asignacion);
                        comando.Parameters.AddWithValue("@idCurso", idCurso);
                        comando.Parameters.AddWithValue("@txtTipoAsignacion", id_Asignacion_tipo);
                        comando.Parameters.AddWithValue("@txtModalidadAsignacion", id_Asignacion_modalidad);
                        comando.Parameters.AddWithValue("@txtNombreAsignacion", txtNombreAsignacion.Text);
                        comando.Parameters.AddWithValue("@txtDetalleAsignacion", txtDetalleAsignacion.Text);
                        comando.Parameters.AddWithValue("@fecha_limite", dtpFecha_limite.Text);
                        comando.Parameters.AddWithValue("@txtEntrega", txtNombreAsignacion.Text);
                        comando.Parameters.AddWithValue("@txtPuntosAsignacion", float.Parse(txtPuntosAsignacion.Text));
                        comando.ExecuteNonQuery();
                    }

                    if (id_Asignacion_modalidad == 1)
                    {
                        insertaAsignacion_x_Estudiante();
                        reiniciarCampos();
                    }
                    else if (id_Asignacion_modalidad == 2)
                    {
                        insertaAsignacion_x_Grupo();
                        reiniciarCampos();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en el método 'crearAsignacion': " + ex.ToString());
            }
        }

        //Reinicia los placeholder y manda el mensaje que confirma que la asignación fue creada exitosamente
        private void reiniciarCampos()
        {
            txtNombreAsignacion.ForeColor = Color.DarkGray;
            txtNombreAsignacion.Text = "Ingrese el título de la asignación";

            txtDetalleAsignacion.ForeColor = Color.DarkGray;
            txtDetalleAsignacion.Text = "Agregue el detalle de la asignación";

            txtModalidadAsignacion.Text = "";
            txtSemanaAsignacion.Text = "";
            txtTipoAsignacion.Text = "";
            txtPuntosAsignacion.Text = "";

            MessageBox.Show("Asignación creada exitosamente");
        }

        public void insertaAsignacion_x_Estudiante() 
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection($"server={Logins.ObtenerInstancia().nombreServidor}; database =GestorAcademico; integrated security = true"))
                {
                    conexion.Open();
                    string cadena = "SELECT uxc.fkUsuario FROM Usuario_x_Curso uxc INNER JOIN Usuario u ON uxc.fkUsuario = u.idUsuario INNER JOIN Credencial c ON u.fkCredencial = c.idCredencial WHERE uxc.fkCurso = " + idCurso + " AND (c.fkCredencialTipo = 1 OR c.fkCredencialTipo = 2) ORDER BY uxc.fkUsuario ASC;";
                    using (SqlCommand comando = new SqlCommand(cadena, conexion))
                    {
                        List<int> usuarios = new List<int>();

                        using (SqlDataReader lector = comando.ExecuteReader())
                        {
                            while (lector.Read())
                            {
                                int fkUsuario = lector.GetInt32(0);
                                usuarios.Add(fkUsuario);
                            }
                        }
                        int[] arregloUsuarios = usuarios.ToArray();
                        conexion.Close();

                        obtenerIDAsignacion_x_Estudiante();
                        foreach (int usuario in arregloUsuarios)
                        {
                            conexion.Open();
                            string cadenaModalidadIndividual = "INSERT INTO Asignacion_x_Estudiante (idAsignacion_x_Estudiante, fkAsignacion, fkUsuario, fkSemana) VALUES (@id_Asignacion_x_Estudiante, @fkAsignacion, @fkUsuario, @fkSemana)";
                            using (SqlCommand comando2 = new SqlCommand(cadenaModalidadIndividual, conexion))
                            {
                                comando2.Parameters.AddWithValue("@id_Asignacion_x_Estudiante", id_Asignacion_x_Estudiante);
                                comando2.Parameters.AddWithValue("@fkAsignacion", id_Asignacion);
                                comando2.Parameters.AddWithValue("@fkUsuario", usuario);
                                comando2.Parameters.AddWithValue("@fkSemana", id_Semana);
                                comando2.ExecuteNonQuery();
                                obtenerIDAsignacion_x_Estudiante();
                            }
                            conexion.Close();
                        }
                    }
                }
            }catch(Exception ex)
            {
                MessageBox.Show("Error en el método 'insertaAsignacion_x_Estudiante': " + ex.ToString());
            }
        }
        
        public void insertaAsignacion_x_Grupo()     
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection($"server={Logins.ObtenerInstancia().nombreServidor}; database =GestorAcademico; integrated security = true"))
                {
                    conexion.Open();
                    string cadena = "SELECT idGrupo FROM Grupo WHERE fkCurso = " + idCurso;
                    using (SqlCommand comando = new SqlCommand(cadena, conexion))
                    {
                        List<int> grupos = new List<int>();

                        using (SqlDataReader lector = comando.ExecuteReader())
                        {
                            while (lector.Read())
                            {
                                int fkGrupo = lector.GetInt32(0);
                                grupos.Add(fkGrupo);
                            }
                        }
                        int[] arregloGrupos = grupos.ToArray();
                        conexion.Close();

                        obtenerIDAsignacion_x_Grupo();
                        foreach (int grupo in arregloGrupos)
                        {
                            conexion.Open();
                            string cadenaModalidadIndividual = "INSERT INTO Asignacion_x_Grupo (idAsignacion_x_Grupo, fkAsignacion, fkGrupo, fkSemana) VALUES (@idAsignacion_x_Grupo, @fkAsignacion, @fkGrupo, @fkSemana)";
                            using (SqlCommand comando2 = new SqlCommand(cadenaModalidadIndividual, conexion))
                            {
                                comando2.Parameters.AddWithValue("@idAsignacion_x_Grupo", id_Asignacion_x_Grupo);
                                comando2.Parameters.AddWithValue("@fkAsignacion", id_Asignacion);
                                comando2.Parameters.AddWithValue("@fkGrupo", grupo);
                                comando2.Parameters.AddWithValue("@fkSemana", id_Semana);
                                comando2.ExecuteNonQuery();
                                obtenerIDAsignacion_x_Grupo();
                            }
                            conexion.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en el método 'insertaAsignacion_x_Grupo': " + ex.ToString());
            }
        }
    }
}
