namespace Proyecto_GestionAcademica_Grupo05.Formularios.Estudiante.FormularioHijo1.Curso.btnPersonas
{
    partial class UC_Grupo
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
            this.flpIntegrantes = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblCantidadEst = new System.Windows.Forms.Label();
            this.lblGrupo = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flpIntegrantes
            // 
            this.flpIntegrantes.BackColor = System.Drawing.Color.White;
            this.flpIntegrantes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flpIntegrantes.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flpIntegrantes.Location = new System.Drawing.Point(0, 50);
            this.flpIntegrantes.Name = "flpIntegrantes";
            this.flpIntegrantes.Size = new System.Drawing.Size(1380, 135);
            this.flpIntegrantes.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.lblCantidadEst);
            this.panel1.Controls.Add(this.lblGrupo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1380, 52);
            this.panel1.TabIndex = 0;
            // 
            // lblCantidadEst
            // 
            this.lblCantidadEst.AutoSize = true;
            this.lblCantidadEst.Font = new System.Drawing.Font("Lato", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidadEst.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(109)))), ((int)(((byte)(107)))));
            this.lblCantidadEst.Location = new System.Drawing.Point(1027, 19);
            this.lblCantidadEst.Name = "lblCantidadEst";
            this.lblCantidadEst.Size = new System.Drawing.Size(84, 16);
            this.lblCantidadEst.TabIndex = 4;
            this.lblCantidadEst.Text = "X estudiantes";
            // 
            // lblGrupo
            // 
            this.lblGrupo.AutoSize = true;
            this.lblGrupo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblGrupo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblGrupo.Font = new System.Drawing.Font("Lato Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGrupo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(59)))), ((int)(((byte)(69)))));
            this.lblGrupo.Location = new System.Drawing.Point(63, 17);
            this.lblGrupo.Name = "lblGrupo";
            this.lblGrupo.Size = new System.Drawing.Size(96, 18);
            this.lblGrupo.TabIndex = 3;
            this.lblGrupo.Text = "--Grupo 00--";
            this.lblGrupo.Click += new System.EventHandler(this.lblGrupo_Click_1);
            // 
            // UC_Grupo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.flpIntegrantes);
            this.Name = "UC_Grupo";
            this.Size = new System.Drawing.Size(1380, 185);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpIntegrantes;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblCantidadEst;
        private System.Windows.Forms.Label lblGrupo;
    }
}
