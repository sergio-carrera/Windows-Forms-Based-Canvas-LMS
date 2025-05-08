namespace Proyecto_GestionAcademica_Grupo05.Formularios.Estudiante.FormularioHijo1.Curso.btnPersonas
{
    partial class CreacionDeGrupos
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancelarAsignacion = new FontAwesome.Sharp.IconButton();
            this.btnCrearGrupo = new FontAwesome.Sharp.IconButton();
            this.txtNombreGrupo = new System.Windows.Forms.TextBox();
            this.panelListaEst = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.panelListaEst);
            this.panel1.Controls.Add(this.txtNombreGrupo);
            this.panel1.Controls.Add(this.btnCrearGrupo);
            this.panel1.Controls.Add(this.btnCancelarAsignacion);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1485, 794);
            this.panel1.TabIndex = 0;
            // 
            // btnCancelarAsignacion
            // 
            this.btnCancelarAsignacion.BackColor = System.Drawing.Color.Gray;
            this.btnCancelarAsignacion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelarAsignacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelarAsignacion.Font = new System.Drawing.Font("Lato", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelarAsignacion.ForeColor = System.Drawing.Color.White;
            this.btnCancelarAsignacion.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnCancelarAsignacion.IconColor = System.Drawing.Color.Black;
            this.btnCancelarAsignacion.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCancelarAsignacion.Location = new System.Drawing.Point(1068, 12);
            this.btnCancelarAsignacion.Name = "btnCancelarAsignacion";
            this.btnCancelarAsignacion.Size = new System.Drawing.Size(153, 62);
            this.btnCancelarAsignacion.TabIndex = 7;
            this.btnCancelarAsignacion.Text = "Cancelar";
            this.btnCancelarAsignacion.UseVisualStyleBackColor = false;
            this.btnCancelarAsignacion.Click += new System.EventHandler(this.btnCancelarAsignacion_Click);
            // 
            // btnCrearGrupo
            // 
            this.btnCrearGrupo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(45)))), ((int)(((byte)(95)))));
            this.btnCrearGrupo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCrearGrupo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCrearGrupo.Font = new System.Drawing.Font("Lato", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCrearGrupo.ForeColor = System.Drawing.Color.White;
            this.btnCrearGrupo.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnCrearGrupo.IconColor = System.Drawing.Color.Black;
            this.btnCrearGrupo.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCrearGrupo.Location = new System.Drawing.Point(1276, 14);
            this.btnCrearGrupo.Name = "btnCrearGrupo";
            this.btnCrearGrupo.Size = new System.Drawing.Size(153, 62);
            this.btnCrearGrupo.TabIndex = 8;
            this.btnCrearGrupo.Text = "Crear grupo";
            this.btnCrearGrupo.UseVisualStyleBackColor = false;
            this.btnCrearGrupo.Click += new System.EventHandler(this.btnCrearGrupo_Click);
            // 
            // txtNombreGrupo
            // 
            this.txtNombreGrupo.BackColor = System.Drawing.Color.White;
            this.txtNombreGrupo.Font = new System.Drawing.Font("Lato", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreGrupo.ForeColor = System.Drawing.Color.DarkGray;
            this.txtNombreGrupo.Location = new System.Drawing.Point(45, 36);
            this.txtNombreGrupo.Name = "txtNombreGrupo";
            this.txtNombreGrupo.Size = new System.Drawing.Size(322, 27);
            this.txtNombreGrupo.TabIndex = 9;
            this.txtNombreGrupo.Text = "Ingrese el nombre del grupo";
            this.txtNombreGrupo.Enter += new System.EventHandler(this.txtNombreGrupo_Enter);
            this.txtNombreGrupo.MouseLeave += new System.EventHandler(this.txtNombreGrupo_MouseLeave);
            // 
            // panelListaEst
            // 
            this.panelListaEst.Location = new System.Drawing.Point(45, 112);
            this.panelListaEst.Name = "panelListaEst";
            this.panelListaEst.Size = new System.Drawing.Size(1384, 634);
            this.panelListaEst.TabIndex = 10;
            // 
            // CreacionDeGrupos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1485, 794);
            this.Controls.Add(this.panel1);
            this.Name = "CreacionDeGrupos";
            this.Text = "CreacionDeGrupos";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private FontAwesome.Sharp.IconButton btnCancelarAsignacion;
        private FontAwesome.Sharp.IconButton btnCrearGrupo;
        private System.Windows.Forms.TextBox txtNombreGrupo;
        private System.Windows.Forms.FlowLayoutPanel panelListaEst;
    }
}