namespace Proyecto_GestionAcademica_Grupo05.Formularios.Estudiante.Curso.btnAnuncio
{
    partial class eAnuncio
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
            this.flPanelAnuncio = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // flPanelAnuncio
            // 
            this.flPanelAnuncio.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flPanelAnuncio.Location = new System.Drawing.Point(0, 78);
            this.flPanelAnuncio.Name = "flPanelAnuncio";
            this.flPanelAnuncio.Size = new System.Drawing.Size(1267, 576);
            this.flPanelAnuncio.TabIndex = 1;
            // 
            // eAnuncio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1267, 654);
            this.Controls.Add(this.flPanelAnuncio);
            this.Name = "eAnuncio";
            this.Text = "eAnuncio";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flPanelAnuncio;
    }
}