namespace Proyecto_GestionAcademica_Grupo05.Formularios.Profesor.Curso_profesor
{
    partial class UC_CursoProf
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
            this.lblNombreCurso = new System.Windows.Forms.Label();
            this.lblCuatri = new System.Windows.Forms.Label();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblNombreCurso
            // 
            this.lblNombreCurso.AutoSize = true;
            this.lblNombreCurso.BackColor = System.Drawing.Color.Transparent;
            this.lblNombreCurso.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblNombreCurso.Font = new System.Drawing.Font("Lato", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreCurso.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(116)))), ((int)(((byte)(120)))));
            this.lblNombreCurso.Location = new System.Drawing.Point(2, 40);
            this.lblNombreCurso.Name = "lblNombreCurso";
            this.lblNombreCurso.Size = new System.Drawing.Size(88, 16);
            this.lblNombreCurso.TabIndex = 3;
            this.lblNombreCurso.Text = "NombreCurso";
            this.lblNombreCurso.Click += new System.EventHandler(this.lblNombreCurso_Click);
            // 
            // lblCuatri
            // 
            this.lblCuatri.AutoSize = true;
            this.lblCuatri.BackColor = System.Drawing.Color.Transparent;
            this.lblCuatri.Font = new System.Drawing.Font("Lato", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCuatri.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(116)))), ((int)(((byte)(120)))));
            this.lblCuatri.Location = new System.Drawing.Point(3, 68);
            this.lblCuatri.Name = "lblCuatri";
            this.lblCuatri.Size = new System.Drawing.Size(151, 13);
            this.lblCuatri.TabIndex = 4;
            this.lblCuatri.Text = "3º CUATRIMESTRE DEL 2023";
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.BackColor = System.Drawing.Color.Transparent;
            this.lblCodigo.Font = new System.Drawing.Font("Lato", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodigo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(116)))), ((int)(((byte)(120)))));
            this.lblCodigo.Location = new System.Drawing.Point(0, 7);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(97, 25);
            this.lblCodigo.TabIndex = 5;
            this.lblCodigo.Text = "CODIGO";
            // 
            // UC_CursoProf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.lblCodigo);
            this.Controls.Add(this.lblCuatri);
            this.Controls.Add(this.lblNombreCurso);
            this.Name = "UC_CursoProf";
            this.Size = new System.Drawing.Size(344, 85);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNombreCurso;
        private System.Windows.Forms.Label lblCuatri;
        private System.Windows.Forms.Label lblCodigo;
    }
}
