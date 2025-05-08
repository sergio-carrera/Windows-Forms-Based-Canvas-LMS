namespace Proyecto_GestionAcademica_Grupo05.Formularios.Profesor.Curso_profesor
{
    partial class CursoInicioProf
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CursoInicioProf));
            this.panelPrincipal = new System.Windows.Forms.Panel();
            this.txtDescripcionCurso = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblNombreCurso = new System.Windows.Forms.Label();
            this.panelMenuLateral = new System.Windows.Forms.Panel();
            this.btnAsistencia = new FontAwesome.Sharp.IconButton();
            this.btnPersonas = new FontAwesome.Sharp.IconButton();
            this.btnCalificaciones = new FontAwesome.Sharp.IconButton();
            this.btnAsignacion = new FontAwesome.Sharp.IconButton();
            this.btnModulos = new FontAwesome.Sharp.IconButton();
            this.btnInicio = new FontAwesome.Sharp.IconButton();
            this.lblCuatri = new System.Windows.Forms.Label();
            this.panelTop = new System.Windows.Forms.Panel();
            this.lblControl = new System.Windows.Forms.Label();
            this.BtnAnuncios = new FontAwesome.Sharp.IconButton();
            this.panelPrincipal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelMenuLateral.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelPrincipal
            // 
            this.panelPrincipal.BackColor = System.Drawing.Color.White;
            this.panelPrincipal.Controls.Add(this.txtDescripcionCurso);
            this.panelPrincipal.Controls.Add(this.pictureBox1);
            this.panelPrincipal.Controls.Add(this.lblNombreCurso);
            this.panelPrincipal.Controls.Add(this.panelMenuLateral);
            this.panelPrincipal.Controls.Add(this.panelTop);
            this.panelPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPrincipal.Location = new System.Drawing.Point(0, 0);
            this.panelPrincipal.Name = "panelPrincipal";
            this.panelPrincipal.Size = new System.Drawing.Size(1385, 793);
            this.panelPrincipal.TabIndex = 1;
            // 
            // txtDescripcionCurso
            // 
            this.txtDescripcionCurso.BackColor = System.Drawing.Color.White;
            this.txtDescripcionCurso.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDescripcionCurso.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txtDescripcionCurso.Font = new System.Drawing.Font("Lato", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcionCurso.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(59)))), ((int)(((byte)(69)))));
            this.txtDescripcionCurso.Location = new System.Drawing.Point(250, 217);
            this.txtDescripcionCurso.Multiline = true;
            this.txtDescripcionCurso.Name = "txtDescripcionCurso";
            this.txtDescripcionCurso.ReadOnly = true;
            this.txtDescripcionCurso.Size = new System.Drawing.Size(998, 390);
            this.txtDescripcionCurso.TabIndex = 12;
            this.txtDescripcionCurso.Text = "----Descripcion del curso----";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(250, 167);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1005, 10);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // lblNombreCurso
            // 
            this.lblNombreCurso.AutoSize = true;
            this.lblNombreCurso.Font = new System.Drawing.Font("Lato", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreCurso.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.lblNombreCurso.Location = new System.Drawing.Point(244, 115);
            this.lblNombreCurso.Name = "lblNombreCurso";
            this.lblNombreCurso.Size = new System.Drawing.Size(314, 35);
            this.lblNombreCurso.TabIndex = 10;
            this.lblNombreCurso.Text = "---Nombre del Curso---";
            // 
            // panelMenuLateral
            // 
            this.panelMenuLateral.Controls.Add(this.BtnAnuncios);
            this.panelMenuLateral.Controls.Add(this.btnAsistencia);
            this.panelMenuLateral.Controls.Add(this.btnPersonas);
            this.panelMenuLateral.Controls.Add(this.btnCalificaciones);
            this.panelMenuLateral.Controls.Add(this.btnAsignacion);
            this.panelMenuLateral.Controls.Add(this.btnModulos);
            this.panelMenuLateral.Controls.Add(this.btnInicio);
            this.panelMenuLateral.Controls.Add(this.lblCuatri);
            this.panelMenuLateral.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenuLateral.Location = new System.Drawing.Point(0, 72);
            this.panelMenuLateral.Name = "panelMenuLateral";
            this.panelMenuLateral.Size = new System.Drawing.Size(200, 721);
            this.panelMenuLateral.TabIndex = 2;
            // 
            // btnAsistencia
            // 
            this.btnAsistencia.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAsistencia.FlatAppearance.BorderSize = 0;
            this.btnAsistencia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAsistencia.Font = new System.Drawing.Font("Lato", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAsistencia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(132)))), ((int)(((byte)(136)))));
            this.btnAsistencia.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnAsistencia.IconColor = System.Drawing.Color.Black;
            this.btnAsistencia.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnAsistencia.Location = new System.Drawing.Point(26, 111);
            this.btnAsistencia.Name = "btnAsistencia";
            this.btnAsistencia.Size = new System.Drawing.Size(114, 28);
            this.btnAsistencia.TabIndex = 9;
            this.btnAsistencia.Text = "Asistencia";
            this.btnAsistencia.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAsistencia.UseVisualStyleBackColor = true;
            this.btnAsistencia.Click += new System.EventHandler(this.btnAsistencia_Click);
            // 
            // btnPersonas
            // 
            this.btnPersonas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPersonas.FlatAppearance.BorderSize = 0;
            this.btnPersonas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPersonas.Font = new System.Drawing.Font("Lato", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPersonas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(132)))), ((int)(((byte)(136)))));
            this.btnPersonas.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnPersonas.IconColor = System.Drawing.Color.Black;
            this.btnPersonas.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnPersonas.Location = new System.Drawing.Point(26, 213);
            this.btnPersonas.Name = "btnPersonas";
            this.btnPersonas.Size = new System.Drawing.Size(114, 28);
            this.btnPersonas.TabIndex = 8;
            this.btnPersonas.Text = "Personas";
            this.btnPersonas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPersonas.UseVisualStyleBackColor = true;
            this.btnPersonas.Click += new System.EventHandler(this.btnPersonas_Click);
            // 
            // btnCalificaciones
            // 
            this.btnCalificaciones.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCalificaciones.FlatAppearance.BorderSize = 0;
            this.btnCalificaciones.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCalificaciones.Font = new System.Drawing.Font("Lato", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCalificaciones.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(132)))), ((int)(((byte)(136)))));
            this.btnCalificaciones.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnCalificaciones.IconColor = System.Drawing.Color.Black;
            this.btnCalificaciones.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCalificaciones.Location = new System.Drawing.Point(26, 179);
            this.btnCalificaciones.Name = "btnCalificaciones";
            this.btnCalificaciones.Size = new System.Drawing.Size(114, 28);
            this.btnCalificaciones.TabIndex = 7;
            this.btnCalificaciones.Text = "Calificaciones";
            this.btnCalificaciones.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCalificaciones.UseVisualStyleBackColor = true;
            this.btnCalificaciones.Click += new System.EventHandler(this.btnCalificaciones_Click);
            // 
            // btnAsignacion
            // 
            this.btnAsignacion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAsignacion.FlatAppearance.BorderSize = 0;
            this.btnAsignacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAsignacion.Font = new System.Drawing.Font("Lato", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAsignacion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(132)))), ((int)(((byte)(136)))));
            this.btnAsignacion.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnAsignacion.IconColor = System.Drawing.Color.Black;
            this.btnAsignacion.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnAsignacion.Location = new System.Drawing.Point(26, 145);
            this.btnAsignacion.Name = "btnAsignacion";
            this.btnAsignacion.Size = new System.Drawing.Size(114, 28);
            this.btnAsignacion.TabIndex = 6;
            this.btnAsignacion.Text = "Asignaciones";
            this.btnAsignacion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAsignacion.UseVisualStyleBackColor = true;
            this.btnAsignacion.Click += new System.EventHandler(this.btnAsignacion_Click);
            // 
            // btnModulos
            // 
            this.btnModulos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnModulos.FlatAppearance.BorderSize = 0;
            this.btnModulos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModulos.Font = new System.Drawing.Font("Lato", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModulos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(132)))), ((int)(((byte)(136)))));
            this.btnModulos.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnModulos.IconColor = System.Drawing.Color.Black;
            this.btnModulos.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnModulos.Location = new System.Drawing.Point(26, 77);
            this.btnModulos.Name = "btnModulos";
            this.btnModulos.Size = new System.Drawing.Size(114, 28);
            this.btnModulos.TabIndex = 5;
            this.btnModulos.Text = "Módulos";
            this.btnModulos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnModulos.UseVisualStyleBackColor = true;
            this.btnModulos.Click += new System.EventHandler(this.btnModulos_Click);
            // 
            // btnInicio
            // 
            this.btnInicio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInicio.FlatAppearance.BorderSize = 0;
            this.btnInicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInicio.Font = new System.Drawing.Font("Lato", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInicio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(132)))), ((int)(((byte)(136)))));
            this.btnInicio.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnInicio.IconColor = System.Drawing.Color.Black;
            this.btnInicio.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnInicio.Location = new System.Drawing.Point(26, 43);
            this.btnInicio.Name = "btnInicio";
            this.btnInicio.Size = new System.Drawing.Size(114, 28);
            this.btnInicio.TabIndex = 4;
            this.btnInicio.Text = "Inicio";
            this.btnInicio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInicio.UseVisualStyleBackColor = true;
            this.btnInicio.Click += new System.EventHandler(this.btnInicio_Click);
            // 
            // lblCuatri
            // 
            this.lblCuatri.AutoSize = true;
            this.lblCuatri.BackColor = System.Drawing.Color.Transparent;
            this.lblCuatri.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.lblCuatri.Font = new System.Drawing.Font("Lato Semibold", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCuatri.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(116)))), ((int)(((byte)(120)))));
            this.lblCuatri.Location = new System.Drawing.Point(23, 14);
            this.lblCuatri.Name = "lblCuatri";
            this.lblCuatri.Size = new System.Drawing.Size(145, 13);
            this.lblCuatri.TabIndex = 3;
            this.lblCuatri.Text = "3º CUATRIMESTRE DEL 2023";
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.lblControl);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1385, 72);
            this.panelTop.TabIndex = 1;
            // 
            // lblControl
            // 
            this.lblControl.AutoSize = true;
            this.lblControl.Font = new System.Drawing.Font("Lato", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblControl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(68)))), ((int)(((byte)(69)))));
            this.lblControl.Location = new System.Drawing.Point(95, 28);
            this.lblControl.Name = "lblControl";
            this.lblControl.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblControl.Size = new System.Drawing.Size(108, 19);
            this.lblControl.TabIndex = 0;
            this.lblControl.Text = "NombreCurso";
            // 
            // BtnAnuncios
            // 
            this.BtnAnuncios.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnAnuncios.FlatAppearance.BorderSize = 0;
            this.BtnAnuncios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAnuncios.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAnuncios.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(132)))), ((int)(((byte)(136)))));
            this.BtnAnuncios.IconChar = FontAwesome.Sharp.IconChar.None;
            this.BtnAnuncios.IconColor = System.Drawing.Color.Black;
            this.BtnAnuncios.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.BtnAnuncios.Location = new System.Drawing.Point(26, 247);
            this.BtnAnuncios.Name = "BtnAnuncios";
            this.BtnAnuncios.Size = new System.Drawing.Size(114, 28);
            this.BtnAnuncios.TabIndex = 12;
            this.BtnAnuncios.Text = "Anuncios";
            this.BtnAnuncios.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnAnuncios.UseVisualStyleBackColor = true;
            this.BtnAnuncios.Click += new System.EventHandler(this.BtnAnuncios_Click);
            // 
            // CursoInicioProf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1385, 793);
            this.Controls.Add(this.panelPrincipal);
            this.Name = "CursoInicioProf";
            this.Text = "CursoInicioProf";
            this.panelPrincipal.ResumeLayout(false);
            this.panelPrincipal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelMenuLateral.ResumeLayout(false);
            this.panelMenuLateral.PerformLayout();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelPrincipal;
        private System.Windows.Forms.Panel panelMenuLateral;
        private FontAwesome.Sharp.IconButton btnPersonas;
        private FontAwesome.Sharp.IconButton btnCalificaciones;
        private FontAwesome.Sharp.IconButton btnAsignacion;
        private FontAwesome.Sharp.IconButton btnModulos;
        private FontAwesome.Sharp.IconButton btnInicio;
        private System.Windows.Forms.Label lblCuatri;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblControl;
        private FontAwesome.Sharp.IconButton btnAsistencia;
        private System.Windows.Forms.Label lblNombreCurso;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtDescripcionCurso;
        private FontAwesome.Sharp.IconButton BtnAnuncios;
    }
}