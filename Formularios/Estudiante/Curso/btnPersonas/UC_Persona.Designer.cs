namespace Proyecto_GestionAcademica_Grupo05.Formularios.Estudiante.FormularioHijo1.Curso
{
    partial class UC_Persona
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
            this.cpbFotoPerfil = new Proyecto_GestionAcademica_Grupo05.ControlesPersonalizados.CircularPictureBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblCurso = new System.Windows.Forms.Label();
            this.lblRol = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.cpbFotoPerfil)).BeginInit();
            this.SuspendLayout();
            // 
            // cpbFotoPerfil
            // 
            this.cpbFotoPerfil.BorderCapStyle = System.Drawing.Drawing2D.DashCap.Flat;
            this.cpbFotoPerfil.BorderColor = System.Drawing.Color.Gray;
            this.cpbFotoPerfil.BorderColor2 = System.Drawing.Color.Gray;
            this.cpbFotoPerfil.BorderLineStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.cpbFotoPerfil.BorderSize = 2;
            this.cpbFotoPerfil.GradientAngle = 50F;
            this.cpbFotoPerfil.Location = new System.Drawing.Point(10, 5);
            this.cpbFotoPerfil.Name = "cpbFotoPerfil";
            this.cpbFotoPerfil.Size = new System.Drawing.Size(48, 46);
            this.cpbFotoPerfil.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.cpbFotoPerfil.TabIndex = 0;
            this.cpbFotoPerfil.TabStop = false;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblNombre.Font = new System.Drawing.Font("Lato", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(105)))), ((int)(((byte)(108)))));
            this.lblNombre.Location = new System.Drawing.Point(107, 19);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(85, 18);
            this.lblNombre.TabIndex = 1;
            this.lblNombre.Text = "--Nombre--";
            this.lblNombre.Click += new System.EventHandler(this.lblNombre_Click);
            // 
            // lblCurso
            // 
            this.lblCurso.AutoSize = true;
            this.lblCurso.Font = new System.Drawing.Font("Lato", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurso.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(105)))), ((int)(((byte)(108)))));
            this.lblCurso.Location = new System.Drawing.Point(562, 19);
            this.lblCurso.Name = "lblCurso";
            this.lblCurso.Size = new System.Drawing.Size(71, 18);
            this.lblCurso.TabIndex = 2;
            this.lblCurso.Text = "--Curso--";
            // 
            // lblRol
            // 
            this.lblRol.AutoSize = true;
            this.lblRol.Font = new System.Drawing.Font("Lato", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRol.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(105)))), ((int)(((byte)(108)))));
            this.lblRol.Location = new System.Drawing.Point(1276, 19);
            this.lblRol.Name = "lblRol";
            this.lblRol.Size = new System.Drawing.Size(54, 18);
            this.lblRol.TabIndex = 3;
            this.lblRol.Text = "--Rol--";
            // 
            // UC_Persona
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblRol);
            this.Controls.Add(this.lblCurso);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.cpbFotoPerfil);
            this.Name = "UC_Persona";
            this.Size = new System.Drawing.Size(1383, 56);
            ((System.ComponentModel.ISupportInitialize)(this.cpbFotoPerfil)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ControlesPersonalizados.CircularPictureBox cpbFotoPerfil;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblCurso;
        private System.Windows.Forms.Label lblRol;
    }
}
