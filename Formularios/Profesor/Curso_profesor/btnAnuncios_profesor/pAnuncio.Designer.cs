namespace Proyecto_GestionAcademica_Grupo05.Formularios.Profesor.Curso_profesor.btnAnuncios
{
    partial class pAnuncio
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
            this.btnCrearA = new System.Windows.Forms.Button();
            this.flPanelAnuncios = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // btnCrearA
            // 
            this.btnCrearA.AutoSize = true;
            this.btnCrearA.BackColor = System.Drawing.Color.Gray;
            this.btnCrearA.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCrearA.ForeColor = System.Drawing.Color.White;
            this.btnCrearA.Location = new System.Drawing.Point(1086, 26);
            this.btnCrearA.Name = "btnCrearA";
            this.btnCrearA.Size = new System.Drawing.Size(159, 38);
            this.btnCrearA.TabIndex = 7;
            this.btnCrearA.Text = "Crear Anuncio";
            this.btnCrearA.UseVisualStyleBackColor = false;
            this.btnCrearA.Click += new System.EventHandler(this.btnCrearA_Click_1);
            // 
            // flPanelAnuncios
            // 
            this.flPanelAnuncios.AutoScroll = true;
            this.flPanelAnuncios.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flPanelAnuncios.Location = new System.Drawing.Point(0, 78);
            this.flPanelAnuncios.Name = "flPanelAnuncios";
            this.flPanelAnuncios.Size = new System.Drawing.Size(1267, 576);
            this.flPanelAnuncios.TabIndex = 8;
            // 
            // pAnuncio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1267, 654);
            this.Controls.Add(this.flPanelAnuncios);
            this.Controls.Add(this.btnCrearA);
            this.Name = "pAnuncio";
            this.Text = "pAnuncio";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCrearA;
        private System.Windows.Forms.FlowLayoutPanel flPanelAnuncios;
    }
}