using FontAwesome.Sharp;
using Proyecto_GestionAcademica_Grupo05.Formularios.Estudiante.FormularioHijo1.Curso.btnPersonas;
using Proyecto_GestionAcademica_Grupo05.Formularios.Profesor.Curso_profesor.btnAsignaciones;
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

namespace Proyecto_GestionAcademica_Grupo05.Formularios.Estudiante.FormularioHijo1.Curso
{
    public partial class CursoPersonas : Form
    {
        private IconButton btnActual;
        //Campo para almacenar formulario "hijo" para el panelPrincipal
        private Form formHijoActual;

        public string idCred;
        public string idCurso;
        public string idCredTipo;

        public CursoPersonas(string idCred, string idCurso)
        {
            InitializeComponent();
            this.idCred = idCred;
            this.idCurso = idCurso;
            obtenerCredencialTipo();
            RellenarVista();
            ActivarBoton(btnTodos);
        }

        private void obtenerCredencialTipo()
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection($"server={Logins.ObtenerInstancia().nombreServidor}; database =GestorAcademico; integrated security = true"))
                {
                    conexion.Open();
                    string consulta = "SELECT fkCredencialTipo FROM Credencial WHERE idCredencial =" + idCred;

                    using (SqlCommand comando = new SqlCommand(consulta, conexion))
                    {
                        using (SqlDataReader lector = comando.ExecuteReader())
                        {
                            while (lector.Read())
                            {
                                int idCredencialTipo = lector.GetInt32(0);
                                idCredTipo = idCredencialTipo.ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error en el método 'obtenerCredencialTipo': " + ex.ToString());
            }
        }

        public void ActivarBoton(object senderBtn)
        {
            if (senderBtn != null)
            {
                DesactivarBoton();
                btnActual = (IconButton)senderBtn;
                btnActual.ForeColor = Color.FromArgb(45, 59, 69);
            }
        }

        public void DesactivarBoton()
        {
            if (btnActual != null)
            {
                btnActual.ForeColor = Color.FromArgb(126, 132, 136);
            }
        }

        public void AbrirFormHijo(Form formHijo)
        {
            try
            {
                if (formHijoActual != null)
                {
                    //abrir unico formulario 
                    formHijoActual.Close();
                }
                formHijoActual = formHijo;
                formHijo.TopLevel = false;
                formHijo.FormBorderStyle = FormBorderStyle.None;
                formHijo.Dock = DockStyle.Fill;
                panelPrincipal.Controls.Add(formHijoActual);
                panelPrincipal.Tag = formHijo;
                formHijo.BringToFront();
                formHijo.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en el método 'AbrirFormHijo': " + ex.ToString());
            }
        }

        public void Cancelar()
        {
            if (formHijoActual != null)
            {
                formHijoActual.Close();
            }
            CursoGrupos cursoGrupos = new CursoGrupos(idCred, idCurso, idCredTipo);
            cursoGrupos.FormularioPadre = this; // Establece la referencia al formulario padre
            AbrirFormHijo(cursoGrupos);
        }

        public void RellenarVista()
        {
            int cont = 0;
            SqlConnection con = new SqlConnection($"server={Logins.ObtenerInstancia().nombreServidor}; database =GestorAcademico; integrated security = true");
            con.Open();
            string cadena = @"SELECT uc.*FROM Usuario_x_Curso uc
                            JOIN Usuario u ON uc.fkUsuario = u.idUsuario
                            WHERE uc.fkCurso = @idCurso
                            ORDER BY u.apellido1;";

            SqlCommand comando = new SqlCommand(cadena, con);
            comando.Parameters.AddWithValue("@idCurso", idCurso);
            SqlDataReader lector = comando.ExecuteReader();

            while (lector.Read())
            {
                cont++;
                string id = lector["fkUsuario"].ToString();
                var miniatura = new UC_Persona(lector["fkUsuario"].ToString(), idCurso, obtenerNCompleto(lector["fkUsuario"] + ""), obtenerRol(lector["fkUsuario"] + ""), id, idCredTipo);
                panelLista.Controls.Add(miniatura);
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

        private string obtenerRol(string nombreC)
        {
            string Rol = "";
            using (SqlConnection conexion = new SqlConnection($"server={Logins.ObtenerInstancia().nombreServidor}; database=GestorAcademico; integrated security=true"))
            {
                conexion.Open();
                string cadena = @"SELECT CT.tipo AS rolUsu
                    FROM Credencial AS C
                    JOIN CredencialTipo AS CT ON C.fkCredencialTipo = CT.idCredencialTipo
                    JOIN Usuario AS U ON C.idCredencial = U.fkCredencial
                    JOIN Usuario_x_Curso AS UxC ON U.idUsuario = UxC.fkUsuario
                    JOIN Curso AS Cr ON UxC.fkCurso = Cr.idCurso
                    WHERE C.idCredencial = " + nombreC +
                        "AND Cr.idCurso = " + idCurso; ;
                SqlCommand comando = new SqlCommand(cadena, conexion);
                comando.Parameters.AddWithValue("@nombreC", nombreC);
                SqlDataReader lector = comando.ExecuteReader();
                if (lector.Read())
                {
                    Rol = lector["rolUsu"].ToString();
                }
            }
            return Rol;
        }

        private void btnGrupos_Click(object sender, EventArgs e)
        {
            ActivarBoton(sender);
            CursoGrupos cursoGrupos = new CursoGrupos(idCred, idCurso, idCredTipo);
            cursoGrupos.FormularioPadre = this; // Establece la referencia al formulario padre
            AbrirFormHijo(cursoGrupos);
        }

        private void btnTodos_Click(object sender, EventArgs e)
        {
            if (formHijoActual != null)
            {
                formHijoActual.Close();
            }
            ActivarBoton(sender);
        }
    }
}
