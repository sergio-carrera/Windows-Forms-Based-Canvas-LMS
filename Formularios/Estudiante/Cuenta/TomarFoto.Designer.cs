namespace Proyecto_GestionAcademica_Grupo05.Formularios.FormularioHijo1
{
    partial class TomarFoto
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
            this.panelFotoPerfil = new System.Windows.Forms.Panel();
            this.btnCapturar = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.panelFotoPerfil.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // panelFotoPerfil
            // 
            this.panelFotoPerfil.BackColor = System.Drawing.Color.White;
            this.panelFotoPerfil.Controls.Add(this.btnCapturar);
            this.panelFotoPerfil.Controls.Add(this.pictureBox);
            this.panelFotoPerfil.Location = new System.Drawing.Point(0, 0);
            this.panelFotoPerfil.Name = "panelFotoPerfil";
            this.panelFotoPerfil.Size = new System.Drawing.Size(326, 292);
            this.panelFotoPerfil.TabIndex = 1;
            // 
            // btnCapturar
            // 
            this.btnCapturar.Location = new System.Drawing.Point(134, 249);
            this.btnCapturar.Name = "btnCapturar";
            this.btnCapturar.Size = new System.Drawing.Size(75, 23);
            this.btnCapturar.TabIndex = 1;
            this.btnCapturar.Text = "Capturar";
            this.btnCapturar.UseVisualStyleBackColor = true;
            this.btnCapturar.Click += new System.EventHandler(this.btnCapturar_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(38, 12);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(254, 220);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // TomarFoto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(327, 293);
            this.Controls.Add(this.panelFotoPerfil);
            this.Name = "TomarFoto";
            this.Text = "TomarFoto";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TomarFoto_FormClosing);
            this.Load += new System.EventHandler(this.TomarFoto_Load_1);
            this.panelFotoPerfil.ResumeLayout(false);
            this.panelFotoPerfil.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelFotoPerfil;
        private System.Windows.Forms.Button btnCapturar;
        private System.Windows.Forms.PictureBox pictureBox;
    }
}