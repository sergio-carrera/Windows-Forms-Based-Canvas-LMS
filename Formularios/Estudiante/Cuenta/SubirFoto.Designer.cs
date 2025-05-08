namespace Proyecto_GestionAcademica_Grupo05.Formularios.FormularioHijo1
{
    partial class SubirFoto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SubirFoto));
            this.panelFotoPerfil = new System.Windows.Forms.Panel();
            this.btnSeleccionarImg = new System.Windows.Forms.PictureBox();
            this.panelFotoPerfil.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSeleccionarImg)).BeginInit();
            this.SuspendLayout();
            // 
            // panelFotoPerfil
            // 
            this.panelFotoPerfil.BackColor = System.Drawing.Color.White;
            this.panelFotoPerfil.Controls.Add(this.btnSeleccionarImg);
            this.panelFotoPerfil.Location = new System.Drawing.Point(1, 0);
            this.panelFotoPerfil.Name = "panelFotoPerfil";
            this.panelFotoPerfil.Size = new System.Drawing.Size(326, 292);
            this.panelFotoPerfil.TabIndex = 1;
            // 
            // btnSeleccionarImg
            // 
            this.btnSeleccionarImg.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSeleccionarImg.BackgroundImage")));
            this.btnSeleccionarImg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSeleccionarImg.Location = new System.Drawing.Point(0, 0);
            this.btnSeleccionarImg.Name = "btnSeleccionarImg";
            this.btnSeleccionarImg.Size = new System.Drawing.Size(326, 292);
            this.btnSeleccionarImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnSeleccionarImg.TabIndex = 0;
            this.btnSeleccionarImg.TabStop = false;
            this.btnSeleccionarImg.Click += new System.EventHandler(this.btnSeleccionarImg_Click);
            this.btnSeleccionarImg.MouseEnter += new System.EventHandler(this.btnSeleccionarImg_MouseEnter);
            this.btnSeleccionarImg.MouseLeave += new System.EventHandler(this.btnSeleccionarImg_MouseLeave);
            // 
            // SubirFoto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(327, 292);
            this.Controls.Add(this.panelFotoPerfil);
            this.Name = "SubirFoto";
            this.Text = "SubirFoto";
            this.MouseEnter += new System.EventHandler(this.SubirFoto_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.SubirFoto_MouseLeave);
            this.panelFotoPerfil.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnSeleccionarImg)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelFotoPerfil;
        public System.Windows.Forms.PictureBox btnSeleccionarImg;
    }
}