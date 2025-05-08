namespace Proyecto_GestionAcademica_Grupo05.Formularios.FormularioHijo1
{
    partial class FotoDePerfil
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
            this.panelMover = new System.Windows.Forms.Panel();
            this.panelPrincipal = new System.Windows.Forms.Panel();
            this.btnTomarFoto = new System.Windows.Forms.Button();
            this.btnSubirFoto = new System.Windows.Forms.Button();
            this.panelFotoPerfil = new System.Windows.Forms.Panel();
            this.panelAbajo = new System.Windows.Forms.Panel();
            this.lblSeleccionaFoto = new System.Windows.Forms.Label();
            this.btnCerrar = new FontAwesome.Sharp.IconButton();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.panelMover.SuspendLayout();
            this.panelPrincipal.SuspendLayout();
            this.panelAbajo.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMover
            // 
            this.panelMover.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panelMover.Controls.Add(this.lblSeleccionaFoto);
            this.panelMover.Controls.Add(this.btnCerrar);
            this.panelMover.Location = new System.Drawing.Point(0, 0);
            this.panelMover.Name = "panelMover";
            this.panelMover.Size = new System.Drawing.Size(672, 68);
            this.panelMover.TabIndex = 0;
            this.panelMover.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelMover_MouseDown);
            this.panelMover.MouseEnter += new System.EventHandler(this.panelMover_MouseEnter);
            this.panelMover.MouseLeave += new System.EventHandler(this.panelMover_MouseLeave);
            // 
            // panelPrincipal
            // 
            this.panelPrincipal.BackColor = System.Drawing.Color.White;
            this.panelPrincipal.Controls.Add(this.btnTomarFoto);
            this.panelPrincipal.Controls.Add(this.btnSubirFoto);
            this.panelPrincipal.Controls.Add(this.panelFotoPerfil);
            this.panelPrincipal.Location = new System.Drawing.Point(1, 68);
            this.panelPrincipal.Name = "panelPrincipal";
            this.panelPrincipal.Size = new System.Drawing.Size(672, 383);
            this.panelPrincipal.TabIndex = 1;
            // 
            // btnTomarFoto
            // 
            this.btnTomarFoto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTomarFoto.Font = new System.Drawing.Font("Lato", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTomarFoto.Location = new System.Drawing.Point(353, 12);
            this.btnTomarFoto.Name = "btnTomarFoto";
            this.btnTomarFoto.Size = new System.Drawing.Size(124, 28);
            this.btnTomarFoto.TabIndex = 2;
            this.btnTomarFoto.Text = "Tomar una foto";
            this.btnTomarFoto.UseVisualStyleBackColor = true;
            this.btnTomarFoto.Click += new System.EventHandler(this.btnTomarFoto_Click);
            // 
            // btnSubirFoto
            // 
            this.btnSubirFoto.BackColor = System.Drawing.Color.White;
            this.btnSubirFoto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSubirFoto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubirFoto.Font = new System.Drawing.Font("Lato", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubirFoto.Location = new System.Drawing.Point(204, 12);
            this.btnSubirFoto.Name = "btnSubirFoto";
            this.btnSubirFoto.Size = new System.Drawing.Size(120, 28);
            this.btnSubirFoto.TabIndex = 1;
            this.btnSubirFoto.Text = "Subir una foto";
            this.btnSubirFoto.UseVisualStyleBackColor = false;
            this.btnSubirFoto.Click += new System.EventHandler(this.btnSubirFoto_Click);
            // 
            // panelFotoPerfil
            // 
            this.panelFotoPerfil.Location = new System.Drawing.Point(175, 53);
            this.panelFotoPerfil.Name = "panelFotoPerfil";
            this.panelFotoPerfil.Size = new System.Drawing.Size(326, 292);
            this.panelFotoPerfil.TabIndex = 0;
            // 
            // panelAbajo
            // 
            this.panelAbajo.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panelAbajo.Controls.Add(this.btnGuardar);
            this.panelAbajo.Controls.Add(this.btnCancelar);
            this.panelAbajo.Location = new System.Drawing.Point(1, 436);
            this.panelAbajo.Name = "panelAbajo";
            this.panelAbajo.Size = new System.Drawing.Size(672, 68);
            this.panelAbajo.TabIndex = 1;
            // 
            // lblSeleccionaFoto
            // 
            this.lblSeleccionaFoto.AutoSize = true;
            this.lblSeleccionaFoto.Font = new System.Drawing.Font("Lato", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSeleccionaFoto.Location = new System.Drawing.Point(17, 22);
            this.lblSeleccionaFoto.Name = "lblSeleccionaFoto";
            this.lblSeleccionaFoto.Size = new System.Drawing.Size(273, 25);
            this.lblSeleccionaFoto.TabIndex = 1;
            this.lblSeleccionaFoto.Text = "Selecciona una foto de perfil";
            // 
            // btnCerrar
            // 
            this.btnCerrar.Flip = FontAwesome.Sharp.FlipOrientation.Horizontal;
            this.btnCerrar.IconChar = FontAwesome.Sharp.IconChar.X;
            this.btnCerrar.IconColor = System.Drawing.Color.Black;
            this.btnCerrar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCerrar.IconSize = 22;
            this.btnCerrar.Location = new System.Drawing.Point(625, 11);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(31, 32);
            this.btnCerrar.TabIndex = 0;
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            this.btnCerrar.MouseEnter += new System.EventHandler(this.btnCerrar_MouseEnter);
            this.btnCerrar.MouseLeave += new System.EventHandler(this.btnCerrar_MouseLeave);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.SystemColors.Control;
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Lato", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(469, 18);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(78, 32);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            this.btnCancelar.MouseEnter += new System.EventHandler(this.btnCancelar_MouseEnter);
            this.btnCancelar.MouseLeave += new System.EventHandler(this.btnCancelar_MouseLeave);
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnGuardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Lato", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(577, 19);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(78, 31);
            this.btnGuardar.TabIndex = 3;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            this.btnGuardar.MouseEnter += new System.EventHandler(this.btnGuardar_MouseEnter);
            this.btnGuardar.MouseLeave += new System.EventHandler(this.btnGuardar_MouseLeave);
            // 
            // FotoDePerfil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 501);
            this.Controls.Add(this.panelMover);
            this.Controls.Add(this.panelAbajo);
            this.Controls.Add(this.panelPrincipal);
            this.Name = "FotoDePerfil";
            this.Text = "FotoDePerfil";
            this.panelMover.ResumeLayout(false);
            this.panelMover.PerformLayout();
            this.panelPrincipal.ResumeLayout(false);
            this.panelAbajo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMover;
        private System.Windows.Forms.Panel panelPrincipal;
        private System.Windows.Forms.Panel panelFotoPerfil;
        private System.Windows.Forms.Panel panelAbajo;
        private FontAwesome.Sharp.IconButton btnCerrar;
        private System.Windows.Forms.Button btnTomarFoto;
        private System.Windows.Forms.Button btnSubirFoto;
        private System.Windows.Forms.Label lblSeleccionaFoto;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
    }
}