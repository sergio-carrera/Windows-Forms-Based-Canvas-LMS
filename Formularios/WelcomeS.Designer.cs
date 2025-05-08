namespace LogIn2
{
    partial class WelcomeS
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WelcomeS));
            this.panelBienvenida = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.BtnProfesores = new FontAwesome.Sharp.IconButton();
            this.BtnEstudiantes = new FontAwesome.Sharp.IconButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panelBienvenida.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelBienvenida
            // 
            this.panelBienvenida.BackColor = System.Drawing.Color.Transparent;
            this.panelBienvenida.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelBienvenida.BackgroundImage")));
            this.panelBienvenida.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelBienvenida.Controls.Add(this.panel2);
            this.panelBienvenida.Controls.Add(this.BtnProfesores);
            this.panelBienvenida.Controls.Add(this.BtnEstudiantes);
            this.panelBienvenida.Controls.Add(this.panel1);
            this.panelBienvenida.Cursor = System.Windows.Forms.Cursors.Default;
            this.panelBienvenida.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBienvenida.Location = new System.Drawing.Point(0, 0);
            this.panelBienvenida.Name = "panelBienvenida";
            this.panelBienvenida.Size = new System.Drawing.Size(1532, 790);
            this.panelBienvenida.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.panel2.Controls.Add(this.textBox2);
            this.panel2.Location = new System.Drawing.Point(932, 573);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(247, 47);
            this.panel2.TabIndex = 3;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(66, 18);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(114, 15);
            this.textBox2.TabIndex = 0;
            this.textBox2.Text = "PROFESORES";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // BtnProfesores
            // 
            this.BtnProfesores.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnProfesores.BackgroundImage")));
            this.BtnProfesores.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnProfesores.IconChar = FontAwesome.Sharp.IconChar.None;
            this.BtnProfesores.IconColor = System.Drawing.Color.Black;
            this.BtnProfesores.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.BtnProfesores.Location = new System.Drawing.Point(932, 320);
            this.BtnProfesores.Name = "BtnProfesores";
            this.BtnProfesores.Size = new System.Drawing.Size(247, 256);
            this.BtnProfesores.TabIndex = 4;
            this.BtnProfesores.UseVisualStyleBackColor = true;
            this.BtnProfesores.Click += new System.EventHandler(this.BtnProfesores_Click);
            // 
            // BtnEstudiantes
            // 
            this.BtnEstudiantes.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnEstudiantes.BackgroundImage")));
            this.BtnEstudiantes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnEstudiantes.IconChar = FontAwesome.Sharp.IconChar.None;
            this.BtnEstudiantes.IconColor = System.Drawing.Color.Black;
            this.BtnEstudiantes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.BtnEstudiantes.Location = new System.Drawing.Point(649, 320);
            this.BtnEstudiantes.Name = "BtnEstudiantes";
            this.BtnEstudiantes.Size = new System.Drawing.Size(242, 256);
            this.BtnEstudiantes.TabIndex = 3;
            this.BtnEstudiantes.UseVisualStyleBackColor = true;
            this.BtnEstudiantes.Click += new System.EventHandler(this.BtnEstudiantes_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Location = new System.Drawing.Point(649, 573);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(242, 47);
            this.panel1.TabIndex = 2;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(66, 18);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(114, 15);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "ESTUDIANTES";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // WelcomeS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1532, 790);
            this.Controls.Add(this.panelBienvenida);
            this.Name = "WelcomeS";
            this.Text = "Página de bienvenida";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panelBienvenida.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelBienvenida;
        private System.Windows.Forms.Panel panel1;
        private FontAwesome.Sharp.IconButton BtnProfesores;
        private FontAwesome.Sharp.IconButton BtnEstudiantes;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox textBox2;
    }
}

