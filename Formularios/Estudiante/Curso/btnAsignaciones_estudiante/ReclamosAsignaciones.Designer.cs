namespace Proyecto_GestionAcademica_Grupo05.Formularios.Estudiante.Curso.btnAsignaciones_estudiante
{
    partial class ReclamosAsignaciones
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnEntrega = new System.Windows.Forms.Button();
            this.txtBoxComentario = new System.Windows.Forms.TextBox();
            this.lblTexto = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // flContenido
            // 
            this.flContenido.AutoScroll = true;
            this.flContenido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flContenido.Location = new System.Drawing.Point(12, 12);
            this.flContenido.Name = "flContenido";
            this.flContenido.Size = new System.Drawing.Size(570, 348);
            this.flContenido.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnEntrega);
            this.panel2.Controls.Add(this.txtBoxComentario);
            this.panel2.Controls.Add(this.lblTexto);
            this.panel2.Location = new System.Drawing.Point(12, 366);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(570, 262);
            this.panel2.TabIndex = 2;
            // 
            // btnEntrega
            // 
            this.btnEntrega.AutoSize = true;
            this.btnEntrega.BackColor = System.Drawing.Color.Gray;
            this.btnEntrega.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEntrega.ForeColor = System.Drawing.Color.White;
            this.btnEntrega.Location = new System.Drawing.Point(309, 196);
            this.btnEntrega.Name = "btnEntrega";
            this.btnEntrega.Size = new System.Drawing.Size(219, 49);
            this.btnEntrega.TabIndex = 7;
            this.btnEntrega.Text = "Entregar";
            this.btnEntrega.UseVisualStyleBackColor = false;
            this.btnEntrega.Click += new System.EventHandler(this.btnEntrega_Click_1);
            // 
            // txtBoxComentario
            // 
            this.txtBoxComentario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBoxComentario.Location = new System.Drawing.Point(36, 73);
            this.txtBoxComentario.Multiline = true;
            this.txtBoxComentario.Name = "txtBoxComentario";
            this.txtBoxComentario.Size = new System.Drawing.Size(492, 117);
            this.txtBoxComentario.TabIndex = 3;
            // 
            // lblTexto
            // 
            this.lblTexto.AutoSize = true;
            this.lblTexto.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTexto.Location = new System.Drawing.Point(32, 29);
            this.lblTexto.Name = "lblTexto";
            this.lblTexto.Size = new System.Drawing.Size(321, 19);
            this.lblTexto.TabIndex = 2;
            this.lblTexto.Text = "Redacte un reclamo para esta asignación:";
            // 
            // ReclamosAsignaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(594, 640);
            this.Controls.Add(this.flContenido);
            this.Controls.Add(this.panel2);
            this.Name = "ReclamosAsignaciones";
            this.Text = "ReclamosAsignaciones";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flContenido;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnEntrega;
        private System.Windows.Forms.TextBox txtBoxComentario;
        private System.Windows.Forms.Label lblTexto;
    }
}