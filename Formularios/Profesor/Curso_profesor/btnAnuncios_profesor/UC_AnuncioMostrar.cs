﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_GestionAcademica_Grupo05.Formularios.Profesor.Curso_profesor.btnAnuncios
{
    public partial class UC_AnuncioMostrar : UserControl
    {
        public string idCurso;
        public string idCred;
        public string tituloAnuncio;
        public UC_AnuncioMostrar(string tituloAnuncio, string idCred, string idCurso, string descAnuncio, string nombre)
        {
            InitializeComponent();
            this.tituloAnuncio = tituloAnuncio;
            this.idCred = idCred;
            this.idCurso = idCurso;
            lblDescripcion.Text = descAnuncio;
            lblnombreAnuncio.Text = tituloAnuncio;
            nProfesor.Text = nombre;
        }



    }
}
