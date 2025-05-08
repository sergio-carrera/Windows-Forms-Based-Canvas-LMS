namespace Proyecto_GestionAcademica_Grupo05.Formularios.Estudiante.Curso.btnAnuncio
{
    partial class UC_eAnuncioMostrar
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
            this.lblNombreAnuncio = new System.Windows.Forms.Label();
            this.nProfesor = new System.Windows.Forms.Label();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblNombreAnuncio
            // 
            this.lblNombreAnuncio.AutoSize = true;
            this.lblNombreAnuncio.Font = new System.Drawing.Font("Microsoft YaHei UI", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreAnuncio.Location = new System.Drawing.Point(39, 42);
            this.lblNombreAnuncio.Name = "lblNombreAnuncio";
            this.lblNombreAnuncio.Size = new System.Drawing.Size(132, 31);
            this.lblNombreAnuncio.TabIndex = 1;
            this.lblNombreAnuncio.Text = "Anuncio #";
            // 
            // nProfesor
            // 
            this.nProfesor.AutoSize = true;
            this.nProfesor.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nProfesor.Location = new System.Drawing.Point(40, 90);
            this.nProfesor.Name = "nProfesor";
            this.nProfesor.Size = new System.Drawing.Size(208, 25);
            this.nProfesor.TabIndex = 2;
            this.nProfesor.Text = "(Nombre del Profesor)";
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescripcion.Location = new System.Drawing.Point(42, 159);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(644, 356);
            this.lblDescripcion.TabIndex = 3;
            this.lblDescripcion.Text = "Descripcion Anuncio";
            // 
            // UC_eAnuncioMostrar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblNombreAnuncio);
            this.Controls.Add(this.nProfesor);
            this.Controls.Add(this.lblDescripcion);
            this.Name = "UC_eAnuncioMostrar";
            this.Size = new System.Drawing.Size(925, 596);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNombreAnuncio;
        private System.Windows.Forms.Label nProfesor;
        private System.Windows.Forms.Label lblDescripcion;
    }
}
