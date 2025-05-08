namespace Proyecto_GestionAcademica_Grupo05.Formularios.Profesor.Curso_profesor.btnAsignaciones_profesor
{
    partial class VistaYCalificacionAsignacion
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
            this.btnConsultarEntrega = new FontAwesome.Sharp.IconButton();
            this.comboBox = new System.Windows.Forms.ComboBox();
            this.panelSecundario = new System.Windows.Forms.Panel();
            this.panelPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelPrincipal
            // 
            this.panelPrincipal.BackColor = System.Drawing.Color.White;
            this.panelPrincipal.Controls.Add(this.btnConsultarEntrega);
            this.panelPrincipal.Controls.Add(this.comboBox);
            this.panelPrincipal.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelPrincipal.Location = new System.Drawing.Point(0, 0);
            this.panelPrincipal.Name = "panelPrincipal";
            this.panelPrincipal.Size = new System.Drawing.Size(1385, 87);
            this.panelPrincipal.TabIndex = 5;
            // 
            // btnConsultarEntrega
            // 
            this.btnConsultarEntrega.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(45)))), ((int)(((byte)(95)))));
            this.btnConsultarEntrega.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConsultarEntrega.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConsultarEntrega.Font = new System.Drawing.Font("Lato Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConsultarEntrega.ForeColor = System.Drawing.Color.White;
            this.btnConsultarEntrega.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnConsultarEntrega.IconColor = System.Drawing.Color.Black;
            this.btnConsultarEntrega.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnConsultarEntrega.Location = new System.Drawing.Point(490, 25);
            this.btnConsultarEntrega.Name = "btnConsultarEntrega";
            this.btnConsultarEntrega.Size = new System.Drawing.Size(158, 35);
            this.btnConsultarEntrega.TabIndex = 15;
            this.btnConsultarEntrega.Text = "Consultar entrega";
            this.btnConsultarEntrega.UseVisualStyleBackColor = false;
            this.btnConsultarEntrega.Click += new System.EventHandler(this.btnConsultarEntrega_Click);
            // 
            // comboBox
            // 
            this.comboBox.BackColor = System.Drawing.Color.White;
            this.comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox.Font = new System.Drawing.Font("Lato", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox.FormattingEnabled = true;
            this.comboBox.Location = new System.Drawing.Point(55, 29);
            this.comboBox.Name = "comboBox";
            this.comboBox.Size = new System.Drawing.Size(399, 27);
            this.comboBox.TabIndex = 14;
            // 
            // panelSecundario
            // 
            this.panelSecundario.BackColor = System.Drawing.Color.White;
            this.panelSecundario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSecundario.Location = new System.Drawing.Point(0, 87);
            this.panelSecundario.Name = "panelSecundario";
            this.panelSecundario.Size = new System.Drawing.Size(1385, 774);
            this.panelSecundario.TabIndex = 6;
            // 
            // VistaYCalificacionAsignacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1385, 861);
            this.Controls.Add(this.panelSecundario);
            this.Controls.Add(this.panelPrincipal);
            this.Name = "VistaYCalificacionAsignacion";
            this.Text = "VistaYCalificacionAsignacion";
            this.panelPrincipal.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelPrincipal;
        private FontAwesome.Sharp.IconButton btnConsultarEntrega;
        private System.Windows.Forms.ComboBox comboBox;
        private System.Windows.Forms.Panel panelSecundario;
    }
}