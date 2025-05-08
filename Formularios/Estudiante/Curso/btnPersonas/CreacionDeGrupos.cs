using Proyecto_GestionAcademica_Grupo05.Formularios.Profesor.Curso_profesor;
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

namespace Proyecto_GestionAcademica_Grupo05.Formularios.Estudiante.FormularioHijo1.Curso.btnPersonas
{
    public partial class CreacionDeGrupos : Form
    {
        public CursoPersonas FormularioPadre { get; set; }

        public string idCred;
        public string idCurso;

        public int id_Grupo;
        public int id_Usuario_x_Grupo;

        public CreacionDeGrupos(string idCred, string idCurso)
        {
            InitializeComponent();
            this.idCred = idCred;
            this.idCurso = idCurso;
            RellenarVista();
        }

        //Método que muestra todos los estudiantes del curso que no tengan grupo
        public void RellenarVista()
        {
            panelListaEst.Controls.Clear();
            int cont = 0;
            SqlConnection con = new SqlConnection($"server={Logins.ObtenerInstancia().nombreServidor}; database =GestorAcademico; integrated security = true");
            con.Open();
            string cadena = @"SELECT uc.*
                            FROM Usuario_x_Curso uc
                            JOIN Usuario u ON uc.fkUsuario = u.idUsuario
                            JOIN Credencial c ON u.fkCredencial = c.idCredencial
                            WHERE uc.fkCurso = @idCurso AND c.fkCredencialTipo = 2
                            AND NOT EXISTS (
                                SELECT 1
                                FROM Usuario_x_Grupo ug
                                JOIN Grupo g ON ug.fkGrupo = g.idGrupo
                                WHERE u.idUsuario = ug.fkUsuario AND g.fkCurso = @idCurso
                            )
                            ORDER BY u.apellido1;";

            SqlCommand comando = new SqlCommand(cadena, con);
            comando.Parameters.AddWithValue("@idCurso", idCurso);
            SqlDataReader lector = comando.ExecuteReader();

            while (lector.Read())
            {
                cont++;
                var miniatura = new UC_PersonaEstudiante(lector["fkUsuario"].ToString(), idCurso, obtenerNCompleto(lector["fkUsuario"] + ""));
                panelListaEst.Controls.Add(miniatura);
            }
        }

        private string obtenerNCompleto(string nombreC)
        {
            string nombreCompleto = "";
            using (SqlConnection conexion = new SqlConnection($"server={Logins.ObtenerInstancia().nombreServidor}; database=GestorAcademico; integrated security=true"))
            {
                conexion.Open();
                string cadena = @"SELECT CONCAT(nombre, ' ', apellido1) AS nCompleto
               FROM Usuario AS u
               JOIN Usuario_x_Curso AS uxc ON u.idUsuario = uxc.fkUsuario 
               WHERE idUsuario = " + nombreC +
               "ORDER BY apellido1 ASC";

                SqlCommand comando = new SqlCommand(cadena, conexion);
                comando.Parameters.AddWithValue("@nombreC", nombreC);
                SqlDataReader lector = comando.ExecuteReader();
                if (lector.Read())
                {
                    nombreCompleto = lector["nCompleto"].ToString();
                }
            }
            return nombreCompleto;
        }

        private void btnCancelarAsignacion_Click(object sender, EventArgs e)
        {
            FormularioPadre.Cancelar();
        }

        public void obtenerIDGrupo()
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection($"server={Logins.ObtenerInstancia().nombreServidor}; database =GestorAcademico; integrated security = true"))
                {
                    conexion.Open();
                    string cadenaVerificarPK = "SELECT * from Grupo ORDER BY idGrupo DESC";

                    using (SqlCommand comando = new SqlCommand(cadenaVerificarPK, conexion))
                    {
                        object result = comando.ExecuteScalar();

                        if (result != null && result != DBNull.Value)
                        {
                            id_Grupo = (int)result + 1;
                        }
                        else
                        {
                            id_Grupo = 1;
                        }
                    }
                    conexion.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en el método 'obtenerIDGrupo': " + ex.ToString());
            }
        }

        public void insertarEstudiante_x_Grupo()
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection($"server={Logins.ObtenerInstancia().nombreServidor}; database =GestorAcademico; integrated security = true"))
                {
                    conexion.Open();
                    obtenerIDUsuario_x_Grupo();

                    // Recorre los controles en el panelListaEst
                    foreach (Control control in panelListaEst.Controls)
                    {
                        if (control is UC_PersonaEstudiante)
                        {
                            UC_PersonaEstudiante ucPersona = (UC_PersonaEstudiante)control;

                            // Verifica si el CheckBox está marcado
                            if (ucPersona.CheckBoxEstudiante.Checked)
                            {
                                // Obtiene información del estudiante
                                string idUsuario = obtenerIdUsuarioPorNombreCompleto(ucPersona.nombreCompleto);

                                // Verifica si el estudiante ya está en el grupo
                                if (!estudianteEnGrupo(idUsuario, id_Grupo))
                                {
                                    // Inserta en la tabla Usuario_x_Grupo
                                    string cadenaInsertar = "INSERT INTO Usuario_x_Grupo (idUsuario_x_Grupo,fkGrupo,fkUsuario) VALUES (@idUsuario_x_Grupo,@fkGrupo,@fkUsuario)";
                                    using (SqlCommand comandoInsertar = new SqlCommand(cadenaInsertar, conexion))
                                    {
                                        comandoInsertar.Parameters.AddWithValue("@idUsuario_x_Grupo", id_Usuario_x_Grupo);
                                        comandoInsertar.Parameters.AddWithValue("@fkGrupo", id_Grupo);
                                        comandoInsertar.Parameters.AddWithValue("@fkUsuario", idUsuario);
                                        comandoInsertar.ExecuteNonQuery();
                                        obtenerIDUsuario_x_Grupo();
                                    }
                                }
                                else
                                {
                                    MessageBox.Show($"El estudiante con ID {idUsuario} ya está en el grupo.");
                                }
                            }
                        }                                           
                    }

                    RellenarVista();
                    MessageBox.Show("Estudiantes insertados en el grupo correctamente.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en el método 'insertarEstudiante_x_Grupo': " + ex.ToString());
            }
        }

        private bool estudianteEnGrupo(string idUsuario, int idGrupo)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection($"server={Logins.ObtenerInstancia().nombreServidor}; database =GestorAcademico; integrated security = true"))
                {
                    conexion.Open();
                    string cadena = "SELECT COUNT(*) FROM Usuario_x_Grupo WHERE fkUsuario = @fkUsuario AND fkGrupo = @fkGrupo";

                    using (SqlCommand comando = new SqlCommand(cadena, conexion))
                    {
                        comando.Parameters.AddWithValue("@fkUsuario", idUsuario);
                        comando.Parameters.AddWithValue("@fkGrupo", idGrupo);

                        int count = Convert.ToInt32(comando.ExecuteScalar());

                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al verificar si el estudiante está en el grupo: " + ex.ToString());
                return false; // En caso de error, asumimos que el estudiante no está en el grupo
            }
        }

        private string obtenerIdUsuarioPorNombreCompleto(string nombreCompleto)
        {
            string idUsuario = "";

            try
            {
                using (SqlConnection conexion = new SqlConnection($"server={Logins.ObtenerInstancia().nombreServidor}; database =GestorAcademico; integrated security = true"))
                {
                    conexion.Open();
                    string cadena = "SELECT idUsuario FROM Usuario WHERE CONCAT(nombre, ' ', apellido1, ' ', apellido2) = @nombreCompleto";

                    using (SqlCommand comando = new SqlCommand(cadena, conexion))
                    {
                        comando.Parameters.AddWithValue("@nombreCompleto", nombreCompleto);
                        object result = comando.ExecuteScalar();

                        if (result != null && result != DBNull.Value)
                        {
                            idUsuario = result.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener ID de usuario por nombre completo: " + ex.ToString());
            }
            return idUsuario;
        }

        public void obtenerIDUsuario_x_Grupo()
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection($"server={Logins.ObtenerInstancia().nombreServidor}; database =GestorAcademico; integrated security = true"))
                {
                    conexion.Open();
                    string cadenaVerificarPK = "SELECT idUsuario_x_Grupo from Usuario_x_Grupo ORDER BY idUsuario_x_Grupo DESC";

                    using (SqlCommand comando = new SqlCommand(cadenaVerificarPK, conexion))
                    {
                        object result = comando.ExecuteScalar();

                        if (result != null && result != DBNull.Value)
                        {
                            id_Usuario_x_Grupo = (int)result + 1;
                        }
                        else
                        {
                            id_Usuario_x_Grupo = 1;
                        }
                    }
                    conexion.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erroe en el método 'obtenerIDUsuario_x_Grupo': " + ex.ToString());
            }
        }

        private void btnCrearGrupo_Click(object sender, EventArgs e)
        {
            try
            {
                obtenerIDGrupo();

                // Verifica que el nombre del grupo sea válido
                string nombreGrupo = txtNombreGrupo.Text.Trim();
                if (nombreGrupoValido(nombreGrupo))
                {
                    // Verifica que al menos un estudiante haya sido seleccionado
                    if (alMenosUnEstudianteSeleccionado())
                    {
                        // Verifica que el nombre del grupo no esté repetido
                        if (!nombreGrupoRepetido(nombreGrupo))
                        {
                            using (SqlConnection conexion = new SqlConnection($"server={Logins.ObtenerInstancia().nombreServidor}; database =GestorAcademico; integrated security = true"))
                            {
                                conexion.Open();

                                // Inserta el grupo solo si el nombre no está repetido
                                string cadena = "INSERT INTO Grupo (idGrupo, fkCurso, nombreGrupo) VALUES (@idGrupo, @idCurso, @nombreGrupo)";
                                using (SqlCommand comando = new SqlCommand(cadena, conexion))
                                {
                                    comando.Parameters.AddWithValue("@idGrupo", id_Grupo);
                                    comando.Parameters.AddWithValue("@idCurso", idCurso);
                                    comando.Parameters.AddWithValue("@nombreGrupo", nombreGrupo);
                                    comando.ExecuteNonQuery();
                                    MessageBox.Show("Grupo creado");
                                    reiniciarCampos();
                                }

                                insertarEstudiante_x_Grupo();

                            }
                        }
                        else
                        {
                            MessageBox.Show("Ya existe un grupo con ese nombre. Por favor, elige otro nombre para el grupo.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Debes seleccionar al menos un estudiante para crear el grupo.");
                    }
                }
                else
                {
                    MessageBox.Show("El nombre del grupo no es válido. Por favor, ingresa un nombre válido para el grupo.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en el método de crear grupo: " + ex.ToString());
            }
        }

        public void reiniciarCampos()
        {
            txtNombreGrupo.Text = "Ingrese el nombre del grupo";
            txtNombreGrupo.ForeColor = Color.DarkGray;
        }

        private bool nombreGrupoValido(string nombreGrupo)
        {
            return !string.IsNullOrWhiteSpace(nombreGrupo) && !nombreGrupo.Equals("Ingrese el nombre del grupo");
        }

        private bool alMenosUnEstudianteSeleccionado()
        {
            foreach (Control control in panelListaEst.Controls)
            {
                if (control is UC_PersonaEstudiante)
                {
                    UC_PersonaEstudiante ucPersona = (UC_PersonaEstudiante)control;

                    // Verifica si el CheckBox está marcado
                    if (ucPersona.CheckBoxEstudiante.Checked)
                    {
                        return true; // Hay al menos un estudiante seleccionado
                    }
                }
            }
            return false; // Ningún estudiante seleccionado
        }

        private bool nombreGrupoRepetido(string nombreGrupo)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection($"server={Logins.ObtenerInstancia().nombreServidor}; database =GestorAcademico; integrated security = true"))
                {
                    conexion.Open();
                    string cadena = "SELECT COUNT(*) FROM Grupo WHERE fkCurso = @idCurso AND nombreGrupo = @nombreGrupo";

                    using (SqlCommand comando = new SqlCommand(cadena, conexion))
                    {
                        comando.Parameters.AddWithValue("@idCurso", idCurso);
                        comando.Parameters.AddWithValue("@nombreGrupo", nombreGrupo);

                        int count = Convert.ToInt32(comando.ExecuteScalar());

                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al verificar si el nombre del grupo está repetido: " + ex.ToString());
                return false; // En caso de error, asumimos que el nombre no está repetido
            }
        }

        private void txtNombreGrupo_Enter(object sender, EventArgs e)
        {
            if (txtNombreGrupo.Text == "Ingrese el nombre del grupo")
            {
                txtNombreGrupo.Text = "";
                txtNombreGrupo.ForeColor = Color.Black;
            }
        }

        private void txtNombreGrupo_MouseLeave(object sender, EventArgs e)
        {
            if (txtNombreGrupo.Text == "")
            {
                txtNombreGrupo.Text = "Ingrese el nombre del grupo";
                txtNombreGrupo.ForeColor = Color.DarkGray;
            }
        }
    }
}
