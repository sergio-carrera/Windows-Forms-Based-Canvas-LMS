namespace Proyecto_GestionAcademica_Grupo05.Formularios.Profesor.Curso_profesor.btnAnuncios
{
    partial class UC_Anuncio
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
            this.pbxProfesor = new Proyecto_GestionAcademica_Grupo05.ControlesPersonalizados.CircularPictureBox();
            this.lblTitulo = new System.Windows.Forms.LinkLabel();
            this.lblPublicado = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbxProfesor)).BeginInit();
            this.SuspendLayout();
            // 
            // pbxProfesor
            // 
            this.pbxProfesor.BorderCapStyle = System.Drawing.Drawing2D.DashCap.Flat;
            this.pbxProfesor.BorderColor = System.Drawing.Color.Black;
            this.pbxProfesor.BorderColor2 = System.Drawing.Color.Black;
            this.pbxProfesor.BorderLineStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.pbxProfesor.BorderSize = 4;
            this.pbxProfesor.Cursor = System.Windows.Forms.Cursors.Default;
            this.pbxProfesor.GradientAngle = 50F;
            this.pbxProfesor.Location = new System.Drawing.Point(47, 14);
            this.pbxProfesor.Name = "pbxProfesor";
            this.pbxProfesor.Size = new System.Drawing.Size(100, 100);
            this.pbxProfesor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxProfesor.TabIndex = 2;
            this.pbxProfesor.TabStop = false;
            // 
            // lblTitulo
            // 
            this.lblTitulo.ActiveLinkColor = System.Drawing.Color.Black;
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft YaHei UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.LinkColor = System.Drawing.Color.Black;
            this.lblTitulo.Location = new System.Drawing.Point(184, 52);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(74, 28);
            this.lblTitulo.TabIndex = 3;
            this.lblTitulo.TabStop = true;
            this.lblTitulo.Text = "Titulo";
            this.lblTitulo.VisitedLinkColor = System.Drawing.Color.Black;
            this.lblTitulo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblTitulo_LinkClicked);
            // 
            // lblPublicado
            // 
            this.lblPublicado.AutoSize = true;
            this.lblPublicado.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPublicado.Location = new System.Drawing.Point(833, 52);
            this.lblPublicado.Name = "lblPublicado";
            this.lblPublicado.Size = new System.Drawing.Size(115, 22);
            this.lblPublicado.TabIndex = 5;
            this.lblPublicado.Text = "Publicado el:";
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.Location = new System.Drawing.Point(825, 84);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(123, 19);
            this.lblFecha.TabIndex = 6;
            this.lblFecha.Text = "Fecha Creacion";
            // 
            // UC_Anuncio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.lblPublicado);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.pbxProfesor);
            this.Name = "UC_Anuncio";
            this.Size = new System.Drawing.Size(959, 128);
            ((System.ComponentModel.ISupportInitialize)(this.pbxProfesor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ControlesPersonalizados.CircularPictureBox pbxProfesor;
        private System.Windows.Forms.LinkLabel lblTitulo;
        private System.Windows.Forms.Label lblPublicado;
        private System.Windows.Forms.Label lblFecha;
    }
}
