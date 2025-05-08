namespace Proyecto_GestionAcademica_Grupo05.Formularios.Estudiante.FormularioHijo1.Curso
{
    partial class CursoPersonas
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnGrupos = new FontAwesome.Sharp.IconButton();
            this.btnTodos = new FontAwesome.Sharp.IconButton();
            this.panelPrincipal = new System.Windows.Forms.Panel();
            this.lblRol_ = new System.Windows.Forms.Label();
            this.lblCurso_ = new System.Windows.Forms.Label();
            this.lblNombre_ = new System.Windows.Forms.Label();
            this.panelLista = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1.SuspendLayout();
            this.panelPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btnGrupos);
            this.panel1.Controls.Add(this.btnTodos);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1501, 143);
            this.panel1.TabIndex = 0;
            // 
            // btnGrupos
            // 
            this.btnGrupos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGrupos.FlatAppearance.BorderSize = 0;
            this.btnGrupos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGrupos.Font = new System.Drawing.Font("Lato", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGrupos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(132)))), ((int)(((byte)(136)))));
            this.btnGrupos.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnGrupos.IconColor = System.Drawing.Color.Black;
            this.btnGrupos.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnGrupos.Location = new System.Drawing.Point(135, 115);
            this.btnGrupos.Name = "btnGrupos";
            this.btnGrupos.Size = new System.Drawing.Size(70, 28);
            this.btnGrupos.TabIndex = 6;
            this.btnGrupos.Text = "Grupos";
            this.btnGrupos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGrupos.UseVisualStyleBackColor = true;
            this.btnGrupos.Click += new System.EventHandler(this.btnGrupos_Click);
            // 
            // btnTodos
            // 
            this.btnTodos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTodos.FlatAppearance.BorderSize = 0;
            this.btnTodos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTodos.Font = new System.Drawing.Font("Lato", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTodos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(132)))), ((int)(((byte)(136)))));
            this.btnTodos.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnTodos.IconColor = System.Drawing.Color.Black;
            this.btnTodos.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnTodos.Location = new System.Drawing.Point(49, 115);
            this.btnTodos.Name = "btnTodos";
            this.btnTodos.Size = new System.Drawing.Size(66, 28);
            this.btnTodos.TabIndex = 5;
            this.btnTodos.Text = "Todos";
            this.btnTodos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTodos.UseVisualStyleBackColor = true;
            this.btnTodos.Click += new System.EventHandler(this.btnTodos_Click);
            // 
            // panelPrincipal
            // 
            this.panelPrincipal.BackColor = System.Drawing.Color.White;
            this.panelPrincipal.Controls.Add(this.lblRol_);
            this.panelPrincipal.Controls.Add(this.lblCurso_);
            this.panelPrincipal.Controls.Add(this.lblNombre_);
            this.panelPrincipal.Controls.Add(this.panelLista);
            this.panelPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPrincipal.Location = new System.Drawing.Point(0, 143);
            this.panelPrincipal.Name = "panelPrincipal";
            this.panelPrincipal.Size = new System.Drawing.Size(1501, 918);
            this.panelPrincipal.TabIndex = 1;
            // 
            // lblRol_
            // 
            this.lblRol_.AutoSize = true;
            this.lblRol_.Font = new System.Drawing.Font("Lato", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRol_.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(59)))), ((int)(((byte)(69)))));
            this.lblRol_.Location = new System.Drawing.Point(1327, 54);
            this.lblRol_.Name = "lblRol_";
            this.lblRol_.Size = new System.Drawing.Size(30, 18);
            this.lblRol_.TabIndex = 3;
            this.lblRol_.Text = "Rol";
            // 
            // lblCurso_
            // 
            this.lblCurso_.AutoSize = true;
            this.lblCurso_.Font = new System.Drawing.Font("Lato", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurso_.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(59)))), ((int)(((byte)(69)))));
            this.lblCurso_.Location = new System.Drawing.Point(613, 54);
            this.lblCurso_.Name = "lblCurso_";
            this.lblCurso_.Size = new System.Drawing.Size(47, 18);
            this.lblCurso_.TabIndex = 2;
            this.lblCurso_.Text = "Curso";
            // 
            // lblNombre_
            // 
            this.lblNombre_.AutoSize = true;
            this.lblNombre_.Font = new System.Drawing.Font("Lato", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre_.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(59)))), ((int)(((byte)(69)))));
            this.lblNombre_.Location = new System.Drawing.Point(158, 54);
            this.lblNombre_.Name = "lblNombre_";
            this.lblNombre_.Size = new System.Drawing.Size(61, 18);
            this.lblNombre_.TabIndex = 1;
            this.lblNombre_.Text = "Nombre";
            // 
            // panelLista
            // 
            this.panelLista.Location = new System.Drawing.Point(51, 75);
            this.panelLista.Name = "panelLista";
            this.panelLista.Size = new System.Drawing.Size(1384, 794);
            this.panelLista.TabIndex = 0;
            // 
            // CursoPersonas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1501, 1061);
            this.Controls.Add(this.panelPrincipal);
            this.Controls.Add(this.panel1);
            this.Name = "CursoPersonas";
            this.Text = "CursoPersonas";
            this.panel1.ResumeLayout(false);
            this.panelPrincipal.ResumeLayout(false);
            this.panelPrincipal.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelPrincipal;
        private FontAwesome.Sharp.IconButton btnGrupos;
        private FontAwesome.Sharp.IconButton btnTodos;
        private System.Windows.Forms.FlowLayoutPanel panelLista;
        private System.Windows.Forms.Label lblCurso_;
        private System.Windows.Forms.Label lblNombre_;
        private System.Windows.Forms.Label lblRol_;
    }
}