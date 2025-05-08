namespace Proyecto_GestionAcademica_Grupo05.Formularios.Profesor.Curso_profesor.btnAsistencia
{
    partial class CursoAsistencia
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
            this.panelSecundario = new System.Windows.Forms.Panel();
            this.comboBox = new System.Windows.Forms.ComboBox();
            this.btnActualizarSemana = new FontAwesome.Sharp.IconButton();
            this.panelPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelPrincipal
            // 
            this.panelPrincipal.BackColor = System.Drawing.Color.White;
            this.panelPrincipal.Controls.Add(this.btnActualizarSemana);
            this.panelPrincipal.Controls.Add(this.comboBox);
            this.panelPrincipal.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelPrincipal.Location = new System.Drawing.Point(0, 0);
            this.panelPrincipal.Name = "panelPrincipal";
            this.panelPrincipal.Size = new System.Drawing.Size(1485, 92);
            this.panelPrincipal.TabIndex = 0;
            // 
            // panelSecundario
            // 
            this.panelSecundario.BackColor = System.Drawing.Color.White;
            this.panelSecundario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSecundario.Location = new System.Drawing.Point(0, 92);
            this.panelSecundario.Name = "panelSecundario";
            this.panelSecundario.Size = new System.Drawing.Size(1485, 702);
            this.panelSecundario.TabIndex = 1;
            // 
            // comboBox
            // 
            this.comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox.Font = new System.Drawing.Font("Lato", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox.FormattingEnabled = true;
            this.comboBox.Items.AddRange(new object[] {
            "Semana 1",
            "Semana 2",
            "Semana 3",
            "Semana 4",
            "Semana 5",
            "Semana 6",
            "Semana 7",
            "Semana 8",
            "Semana 9",
            "Semana 10",
            "Semana 11",
            "Semana 10",
            "Semana 11",
            "Semana 12",
            "Semana 13",
            "Semana 14",
            "Semana 15"});
            this.comboBox.Location = new System.Drawing.Point(64, 32);
            this.comboBox.Name = "comboBox";
            this.comboBox.Size = new System.Drawing.Size(208, 27);
            this.comboBox.TabIndex = 0;
            // 
            // btnActualizarSemana
            // 
            this.btnActualizarSemana.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(45)))), ((int)(((byte)(95)))));
            this.btnActualizarSemana.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnActualizarSemana.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizarSemana.Font = new System.Drawing.Font("Lato Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizarSemana.ForeColor = System.Drawing.Color.White;
            this.btnActualizarSemana.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnActualizarSemana.IconColor = System.Drawing.Color.Black;
            this.btnActualizarSemana.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnActualizarSemana.Location = new System.Drawing.Point(291, 27);
            this.btnActualizarSemana.Name = "btnActualizarSemana";
            this.btnActualizarSemana.Size = new System.Drawing.Size(164, 35);
            this.btnActualizarSemana.TabIndex = 7;
            this.btnActualizarSemana.Text = "Actualizar semana";
            this.btnActualizarSemana.UseVisualStyleBackColor = false;
            this.btnActualizarSemana.Click += new System.EventHandler(this.btnActualizarSemana_Click);
            // 
            // CursoAsistencia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1485, 794);
            this.Controls.Add(this.panelSecundario);
            this.Controls.Add(this.panelPrincipal);
            this.Name = "CursoAsistencia";
            this.Text = "CursoAsistencia";
            this.panelPrincipal.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelPrincipal;
        private System.Windows.Forms.Panel panelSecundario;
        private System.Windows.Forms.ComboBox comboBox;
        private FontAwesome.Sharp.IconButton btnActualizarSemana;
    }
}