namespace Proyecto_GestionAcademica_Grupo05.Formularios.Estudiante.FormularioHijo1.Curso.btnPersonas
{
    partial class CursoGrupos
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
            this.panelPrincipal = new System.Windows.Forms.Panel();
            this.panelGrupos = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCrearGrupo = new FontAwesome.Sharp.IconButton();
            this.panelPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelPrincipal
            // 
            this.panelPrincipal.AutoScroll = true;
            this.panelPrincipal.BackColor = System.Drawing.Color.White;
            this.panelPrincipal.Controls.Add(this.panelGrupos);
            this.panelPrincipal.Controls.Add(this.btnCrearGrupo);
            this.panelPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPrincipal.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panelPrincipal.Location = new System.Drawing.Point(0, 0);
            this.panelPrincipal.Name = "panelPrincipal";
            this.panelPrincipal.Size = new System.Drawing.Size(1485, 873);
            this.panelPrincipal.TabIndex = 0;
            // 
            // panelGrupos
            // 
            this.panelGrupos.Location = new System.Drawing.Point(45, 120);
            this.panelGrupos.Name = "panelGrupos";
            this.panelGrupos.Size = new System.Drawing.Size(1384, 718);
            this.panelGrupos.TabIndex = 2;
            // 
            // btnCrearGrupo
            // 
            this.btnCrearGrupo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(45)))), ((int)(((byte)(95)))));
            this.btnCrearGrupo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnCrearGrupo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCrearGrupo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCrearGrupo.Font = new System.Drawing.Font("Lato Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCrearGrupo.ForeColor = System.Drawing.Color.White;
            this.btnCrearGrupo.IconChar = FontAwesome.Sharp.IconChar.Add;
            this.btnCrearGrupo.IconColor = System.Drawing.Color.White;
            this.btnCrearGrupo.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCrearGrupo.IconSize = 32;
            this.btnCrearGrupo.Location = new System.Drawing.Point(1329, 38);
            this.btnCrearGrupo.Name = "btnCrearGrupo";
            this.btnCrearGrupo.Size = new System.Drawing.Size(100, 40);
            this.btnCrearGrupo.TabIndex = 1;
            this.btnCrearGrupo.Text = "Grupo";
            this.btnCrearGrupo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCrearGrupo.UseVisualStyleBackColor = false;
            this.btnCrearGrupo.Click += new System.EventHandler(this.btnCrearGrupo_Click);
            // 
            // CursoGrupos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1485, 873);
            this.Controls.Add(this.panelPrincipal);
            this.Name = "CursoGrupos";
            this.Text = "-";
            this.panelPrincipal.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelPrincipal;
        private FontAwesome.Sharp.IconButton btnCrearGrupo;
        private System.Windows.Forms.FlowLayoutPanel panelGrupos;
    }
}