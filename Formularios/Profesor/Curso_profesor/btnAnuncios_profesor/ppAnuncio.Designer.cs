namespace Proyecto_GestionAcademica_Grupo05.Formularios.Profesor.Curso_profesor.btnAnuncios
{
    partial class ppAnuncio
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
            this.flContenido = new System.Windows.Forms.FlowLayoutPanel();
            this.btnBorrarA = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // flContenido
            // 
            this.flContenido.Location = new System.Drawing.Point(12, 12);
            this.flContenido.Name = "flContenido";
            this.flContenido.Size = new System.Drawing.Size(1243, 536);
            this.flContenido.TabIndex = 1;
            // 
            // btnBorrarA
            // 
            this.btnBorrarA.AutoSize = true;
            this.btnBorrarA.BackColor = System.Drawing.Color.Gray;
            this.btnBorrarA.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBorrarA.ForeColor = System.Drawing.Color.White;
            this.btnBorrarA.Location = new System.Drawing.Point(1111, 571);
            this.btnBorrarA.Name = "btnBorrarA";
            this.btnBorrarA.Size = new System.Drawing.Size(144, 49);
            this.btnBorrarA.TabIndex = 7;
            this.btnBorrarA.Text = "Borrar";
            this.btnBorrarA.UseVisualStyleBackColor = false;
            this.btnBorrarA.Click += new System.EventHandler(this.btnBorrarA_Click_1);
            // 
            // ppAnuncio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1267, 654);
            this.Controls.Add(this.btnBorrarA);
            this.Controls.Add(this.flContenido);
            this.Name = "ppAnuncio";
            this.Text = "ppAnuncio";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flContenido;
        private System.Windows.Forms.Button btnBorrarA;
    }
}