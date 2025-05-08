namespace Proyecto_GestionAcademica_Grupo05.Formularios.Estudiante.FormularioHijo1.Curso
{
    partial class UC_Asignacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_Asignacion));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblNombreAsignacion = new System.Windows.Forms.Label();
            this.lblFechaYPuntos = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(18, 16);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(27, 26);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // lblNombreAsignacion
            // 
            this.lblNombreAsignacion.AutoSize = true;
            this.lblNombreAsignacion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblNombreAsignacion.Font = new System.Drawing.Font("Lato Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreAsignacion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(68)))), ((int)(((byte)(75)))));
            this.lblNombreAsignacion.Location = new System.Drawing.Point(63, 10);
            this.lblNombreAsignacion.Name = "lblNombreAsignacion";
            this.lblNombreAsignacion.Size = new System.Drawing.Size(138, 18);
            this.lblNombreAsignacion.TabIndex = 1;
            this.lblNombreAsignacion.Text = "Nombre asignacion";
            this.lblNombreAsignacion.Click += new System.EventHandler(this.lblNombreAsignacion_Click);
            // 
            // lblFechaYPuntos
            // 
            this.lblFechaYPuntos.AutoSize = true;
            this.lblFechaYPuntos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(159)))), ((int)(((byte)(152)))));
            this.lblFechaYPuntos.Location = new System.Drawing.Point(63, 33);
            this.lblFechaYPuntos.Name = "lblFechaYPuntos";
            this.lblFechaYPuntos.Size = new System.Drawing.Size(78, 13);
            this.lblFechaYPuntos.TabIndex = 2;
            this.lblFechaYPuntos.Text = "Fecha | Puntos";
            // 
            // UC_Asignacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblFechaYPuntos);
            this.Controls.Add(this.lblNombreAsignacion);
            this.Controls.Add(this.pictureBox1);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Name = "UC_Asignacion";
            this.Size = new System.Drawing.Size(1450, 56);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblNombreAsignacion;
        private System.Windows.Forms.Label lblFechaYPuntos;
    }
}
