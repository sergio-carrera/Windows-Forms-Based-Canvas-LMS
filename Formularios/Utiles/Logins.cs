using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_GestionAcademica_Grupo05.Formularios
{
    public partial class Logins : Form
    {
        /*
        Variable string que almacena el nombre del servidor ingresado en el
        textbox "respuesta" del formulario "CuadroInput"
        */
        public string nombreServidor;

        public Logins()
        {
            InitializeComponent();
        }

        /*
        Se implementa un Singleton para la clase Logins. Cuando se llama al método ObtenerInstancia(), 
        se devuelve una única instancia de la clase Logins. Si aún no se ha creado, se crea; de lo contrario, 
        se devuelve la instancia ya existente. 
        Esto puede ser útil en situaciones donde se desea tener una única instancia de una clase en un programa.
        Se utiliza a lo largo del programa para obtener el nombre del servidor de la base de datos y conectarse a este.
        */
        private static Logins instancia;
        public static Logins ObtenerInstancia()
        {
            if (instancia == null)
                instancia = new Logins();
            return instancia;
        }
    }
}
