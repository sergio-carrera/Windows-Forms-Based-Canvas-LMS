using Proyecto_GestionAcademica_Grupo05.Formularios.Utiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Proyecto_GestionAcademica_Grupo05.Formularios;

namespace Proyecto_GestionAcademica_Grupo05
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            /*
            Se abre primero el formulario "CuadroInput" para obtener el nombre del sevidor de la base de datos
            */
            CuadroInput cuadroInput = new CuadroInput();
            string nombreDelServidor;
            bool permiso = false;

            
            while (!permiso)
            {
                switch (cuadroInput.ShowDialog())
                {
                    case DialogResult.OK:
                        nombreDelServidor = cuadroInput.respuesta;
                        try
                        {
                            SqlConnection conexion = new SqlConnection($"server={nombreDelServidor}; database =Pruebas; integrated security = true");
                            conexion.Open();
                            conexion.Close();
                            permiso = true;
                            /*
                            Se establece mediante el patrón "Singleton", el nombre del servidor almacenado en el 
                            campo "nombreServidor" del formulario "Logins"
                            */
                            Logins.ObtenerInstancia().nombreServidor = nombreDelServidor;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error: nombre de servidor inválido, ingrese uno nuevo.\n\n" + ex.InnerException);
                        }

                        if (permiso)
                            //Se abre el formulario del Login
                            Application.Run(new WelcomeS());
                        break;
                    case DialogResult.Cancel:
                        permiso = true;
                        break;
                }
            }
            
        }
    }
}
