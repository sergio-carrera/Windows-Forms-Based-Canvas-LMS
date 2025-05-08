namespace Proyecto_GestionAcademica_Grupo05.Formularios.Profesor.Curso_profesor.btnCalificaciones_profesor
{
    partial class MuestraDeCalificacionesProfesor
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAsignaciones = new FontAwesome.Sharp.IconButton();
            this.subMenuAsig = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1581, 1061);
            this.panel1.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnAsignaciones);
            this.flowLayoutPanel1.Controls.Add(this.subMenuAsig);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(60, 54);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1460, 952);
            this.flowLayoutPanel1.TabIndex = 8;
            // 
            // btnAsignaciones
            // 
            this.btnAsignaciones.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnAsignaciones.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAsignaciones.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAsignaciones.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnAsignaciones.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAsignaciones.Font = new System.Drawing.Font("Lato Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAsignaciones.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(69)))), ((int)(((byte)(76)))));
            this.btnAsignaciones.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnAsignaciones.IconColor = System.Drawing.Color.Black;
            this.btnAsignaciones.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnAsignaciones.Location = new System.Drawing.Point(3, 3);
            this.btnAsignaciones.Name = "btnAsignaciones";
            this.btnAsignaciones.Size = new System.Drawing.Size(1456, 51);
            this.btnAsignaciones.TabIndex = 1;
            this.btnAsignaciones.Text = "Asignaciones";
            this.btnAsignaciones.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAsignaciones.UseVisualStyleBackColor = false;
            // 
            // subMenuAsig
            // 
            this.subMenuAsig.AutoScroll = true;
            this.subMenuAsig.Dock = System.Windows.Forms.DockStyle.Top;
            this.subMenuAsig.Location = new System.Drawing.Point(3, 60);
            this.subMenuAsig.Name = "subMenuAsig";
            this.subMenuAsig.Size = new System.Drawing.Size(1456, 892);
            this.subMenuAsig.TabIndex = 9;
            // 
            // MuestraDeCalificacionesProfesor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1581, 1061);
            this.Controls.Add(this.panel1);
            this.Name = "MuestraDeCalificacionesProfesor";
            this.Text = "MuestraDeCalificacionesProfesor";
            this.panel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private FontAwesome.Sharp.IconButton btnAsignaciones;
        private System.Windows.Forms.FlowLayoutPanel subMenuAsig;
    }
}