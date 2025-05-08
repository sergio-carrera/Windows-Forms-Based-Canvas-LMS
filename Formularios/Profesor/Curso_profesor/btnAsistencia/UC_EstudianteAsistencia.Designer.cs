namespace Proyecto_GestionAcademica_Grupo05.Formularios.Profesor.Curso_profesor.btnAsistencia
{
    partial class UC_EstudianteAsistencia
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblNombre = new System.Windows.Forms.Label();
            this.pBFotoPerfil = new System.Windows.Forms.PictureBox();
            this.btnCambiarEstado = new Proyecto_GestionAcademica_Grupo05.ControlesPersonalizados.CircularPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pBFotoPerfil)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCambiarEstado)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblNombre.Font = new System.Drawing.Font("Lato", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(105)))), ((int)(((byte)(108)))));
            this.lblNombre.Location = new System.Drawing.Point(130, 16);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(85, 18);
            this.lblNombre.TabIndex = 3;
            this.lblNombre.Text = "--Nombre--";
            this.lblNombre.Click += new System.EventHandler(this.lblNombre_Click);
            // 
            // pBFotoPerfil
            // 
            this.pBFotoPerfil.Location = new System.Drawing.Point(7, 3);
            this.pBFotoPerfil.Name = "pBFotoPerfil";
            this.pBFotoPerfil.Size = new System.Drawing.Size(49, 46);
            this.pBFotoPerfil.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pBFotoPerfil.TabIndex = 6;
            this.pBFotoPerfil.TabStop = false;
            // 
            // btnCambiarEstado
            // 
            this.btnCambiarEstado.BorderCapStyle = System.Drawing.Drawing2D.DashCap.Flat;
            this.btnCambiarEstado.BorderColor = System.Drawing.Color.Gray;
            this.btnCambiarEstado.BorderColor2 = System.Drawing.Color.Gray;
            this.btnCambiarEstado.BorderLineStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.btnCambiarEstado.BorderSize = 2;
            this.btnCambiarEstado.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCambiarEstado.GradientAngle = 50F;
            this.btnCambiarEstado.Location = new System.Drawing.Point(75, 9);
            this.btnCambiarEstado.Name = "btnCambiarEstado";
            this.btnCambiarEstado.Size = new System.Drawing.Size(37, 35);
            this.btnCambiarEstado.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnCambiarEstado.TabIndex = 5;
            this.btnCambiarEstado.TabStop = false;
            this.btnCambiarEstado.Click += new System.EventHandler(this.btnCambiarEstado_Click);
            // 
            // UC_EstudianteAsistencia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.pBFotoPerfil);
            this.Controls.Add(this.btnCambiarEstado);
            this.Controls.Add(this.lblNombre);
            this.Name = "UC_EstudianteAsistencia";
            this.Size = new System.Drawing.Size(1379, 54);
            ((System.ComponentModel.ISupportInitialize)(this.pBFotoPerfil)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCambiarEstado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNombre;
        private ControlesPersonalizados.CircularPictureBox btnCambiarEstado;
        private System.Windows.Forms.PictureBox pBFotoPerfil;
    }
}
