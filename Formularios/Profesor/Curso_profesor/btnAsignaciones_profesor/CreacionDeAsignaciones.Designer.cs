namespace Proyecto_GestionAcademica_Grupo05.Formularios.Profesor.Curso_profesor.btnAsignaciones
{
    partial class CreacionDeAsignaciones
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
            this.txtNombreAsignacion = new System.Windows.Forms.TextBox();
            this.txtDetalleAsignacion = new System.Windows.Forms.TextBox();
            this.dtpFecha_limite = new System.Windows.Forms.DateTimePicker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblPuntos = new System.Windows.Forms.Label();
            this.btnCrearAsignacion2 = new FontAwesome.Sharp.IconButton();
            this.btnCancelarAsignacion = new FontAwesome.Sharp.IconButton();
            this.txtPuntosAsignacion = new System.Windows.Forms.TextBox();
            this.txtSemanaAsignacion = new System.Windows.Forms.ComboBox();
            this.txtTipoAsignacion = new System.Windows.Forms.ComboBox();
            this.txtModalidadAsignacion = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtNombreAsignacion
            // 
            this.txtNombreAsignacion.BackColor = System.Drawing.Color.White;
            this.txtNombreAsignacion.Font = new System.Drawing.Font("Lato", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreAsignacion.ForeColor = System.Drawing.Color.DarkGray;
            this.txtNombreAsignacion.Location = new System.Drawing.Point(39, 43);
            this.txtNombreAsignacion.Name = "txtNombreAsignacion";
            this.txtNombreAsignacion.Size = new System.Drawing.Size(322, 27);
            this.txtNombreAsignacion.TabIndex = 0;
            this.txtNombreAsignacion.Text = "Ingrese el título de la asignación";
            this.txtNombreAsignacion.Enter += new System.EventHandler(this.txtNombreAsignacion_Enter);
            this.txtNombreAsignacion.MouseLeave += new System.EventHandler(this.txtNombreAsignacion_MouseLeave);
            // 
            // txtDetalleAsignacion
            // 
            this.txtDetalleAsignacion.BackColor = System.Drawing.Color.White;
            this.txtDetalleAsignacion.Font = new System.Drawing.Font("Lato", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDetalleAsignacion.ForeColor = System.Drawing.Color.DarkGray;
            this.txtDetalleAsignacion.Location = new System.Drawing.Point(39, 581);
            this.txtDetalleAsignacion.Multiline = true;
            this.txtDetalleAsignacion.Name = "txtDetalleAsignacion";
            this.txtDetalleAsignacion.Size = new System.Drawing.Size(895, 337);
            this.txtDetalleAsignacion.TabIndex = 1;
            this.txtDetalleAsignacion.Text = "Agregue el detalle de la asignación";
            this.txtDetalleAsignacion.Enter += new System.EventHandler(this.txtDetalleAsignacion_Enter);
            this.txtDetalleAsignacion.Leave += new System.EventHandler(this.txtDetalleAsignacion_Leave);
            // 
            // dtpFecha_limite
            // 
            this.dtpFecha_limite.CustomFormat = "yyyy/MM/dd";
            this.dtpFecha_limite.Font = new System.Drawing.Font("Lato", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFecha_limite.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFecha_limite.Location = new System.Drawing.Point(39, 98);
            this.dtpFecha_limite.Name = "dtpFecha_limite";
            this.dtpFecha_limite.Size = new System.Drawing.Size(322, 27);
            this.dtpFecha_limite.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.lblPuntos);
            this.panel1.Controls.Add(this.btnCrearAsignacion2);
            this.panel1.Controls.Add(this.btnCancelarAsignacion);
            this.panel1.Controls.Add(this.txtNombreAsignacion);
            this.panel1.Controls.Add(this.txtDetalleAsignacion);
            this.panel1.Controls.Add(this.txtPuntosAsignacion);
            this.panel1.Controls.Add(this.txtSemanaAsignacion);
            this.panel1.Controls.Add(this.txtTipoAsignacion);
            this.panel1.Controls.Add(this.txtModalidadAsignacion);
            this.panel1.Controls.Add(this.dtpFecha_limite);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1385, 1061);
            this.panel1.TabIndex = 4;
            // 
            // lblPuntos
            // 
            this.lblPuntos.AutoSize = true;
            this.lblPuntos.Font = new System.Drawing.Font("Lato", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPuntos.Location = new System.Drawing.Point(1156, 32);
            this.lblPuntos.Name = "lblPuntos";
            this.lblPuntos.Size = new System.Drawing.Size(63, 19);
            this.lblPuntos.TabIndex = 10;
            this.lblPuntos.Text = "Puntos:";
            // 
            // btnCrearAsignacion2
            // 
            this.btnCrearAsignacion2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(45)))), ((int)(((byte)(95)))));
            this.btnCrearAsignacion2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCrearAsignacion2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCrearAsignacion2.Font = new System.Drawing.Font("Lato", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCrearAsignacion2.ForeColor = System.Drawing.Color.White;
            this.btnCrearAsignacion2.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnCrearAsignacion2.IconColor = System.Drawing.Color.Black;
            this.btnCrearAsignacion2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCrearAsignacion2.Location = new System.Drawing.Point(1106, 838);
            this.btnCrearAsignacion2.Name = "btnCrearAsignacion2";
            this.btnCrearAsignacion2.Size = new System.Drawing.Size(203, 80);
            this.btnCrearAsignacion2.TabIndex = 7;
            this.btnCrearAsignacion2.Text = "Crear asignación";
            this.btnCrearAsignacion2.UseVisualStyleBackColor = false;
            this.btnCrearAsignacion2.Click += new System.EventHandler(this.btnCrearAsignacion2_Click);
            // 
            // btnCancelarAsignacion
            // 
            this.btnCancelarAsignacion.BackColor = System.Drawing.Color.Gray;
            this.btnCancelarAsignacion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelarAsignacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelarAsignacion.Font = new System.Drawing.Font("Lato", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelarAsignacion.ForeColor = System.Drawing.Color.White;
            this.btnCancelarAsignacion.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnCancelarAsignacion.IconColor = System.Drawing.Color.Black;
            this.btnCancelarAsignacion.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCancelarAsignacion.Location = new System.Drawing.Point(1106, 709);
            this.btnCancelarAsignacion.Name = "btnCancelarAsignacion";
            this.btnCancelarAsignacion.Size = new System.Drawing.Size(203, 80);
            this.btnCancelarAsignacion.TabIndex = 6;
            this.btnCancelarAsignacion.Text = "Cancelar";
            this.btnCancelarAsignacion.UseVisualStyleBackColor = false;
            this.btnCancelarAsignacion.Click += new System.EventHandler(this.btnCancelarAsignacion_Click);
            // 
            // txtPuntosAsignacion
            // 
            this.txtPuntosAsignacion.BackColor = System.Drawing.Color.White;
            this.txtPuntosAsignacion.Font = new System.Drawing.Font("Lato", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPuntosAsignacion.ForeColor = System.Drawing.Color.Black;
            this.txtPuntosAsignacion.Location = new System.Drawing.Point(1225, 24);
            this.txtPuntosAsignacion.Name = "txtPuntosAsignacion";
            this.txtPuntosAsignacion.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txtPuntosAsignacion.Size = new System.Drawing.Size(84, 27);
            this.txtPuntosAsignacion.TabIndex = 5;
            this.txtPuntosAsignacion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPuntos_KeyPress);
            // 
            // txtSemanaAsignacion
            // 
            this.txtSemanaAsignacion.BackColor = System.Drawing.Color.White;
            this.txtSemanaAsignacion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtSemanaAsignacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtSemanaAsignacion.Font = new System.Drawing.Font("Lato", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSemanaAsignacion.ForeColor = System.Drawing.Color.Black;
            this.txtSemanaAsignacion.FormattingEnabled = true;
            this.txtSemanaAsignacion.Items.AddRange(new object[] {
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
            "Semana 12",
            "Semana 13",
            "Semana 14",
            "Semana 15"});
            this.txtSemanaAsignacion.Location = new System.Drawing.Point(39, 158);
            this.txtSemanaAsignacion.Name = "txtSemanaAsignacion";
            this.txtSemanaAsignacion.Size = new System.Drawing.Size(121, 27);
            this.txtSemanaAsignacion.TabIndex = 4;
            // 
            // txtTipoAsignacion
            // 
            this.txtTipoAsignacion.BackColor = System.Drawing.Color.White;
            this.txtTipoAsignacion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtTipoAsignacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtTipoAsignacion.Font = new System.Drawing.Font("Lato", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTipoAsignacion.ForeColor = System.Drawing.Color.Black;
            this.txtTipoAsignacion.FormattingEnabled = true;
            this.txtTipoAsignacion.Items.AddRange(new object[] {
            "Tarea",
            "Laboratorio",
            "Proyecto"});
            this.txtTipoAsignacion.Location = new System.Drawing.Point(39, 214);
            this.txtTipoAsignacion.Name = "txtTipoAsignacion";
            this.txtTipoAsignacion.Size = new System.Drawing.Size(121, 27);
            this.txtTipoAsignacion.TabIndex = 8;
            // 
            // txtModalidadAsignacion
            // 
            this.txtModalidadAsignacion.BackColor = System.Drawing.Color.White;
            this.txtModalidadAsignacion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtModalidadAsignacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtModalidadAsignacion.Font = new System.Drawing.Font("Lato", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtModalidadAsignacion.ForeColor = System.Drawing.Color.Black;
            this.txtModalidadAsignacion.FormattingEnabled = true;
            this.txtModalidadAsignacion.Items.AddRange(new object[] {
            "Individual",
            "Grupal"});
            this.txtModalidadAsignacion.Location = new System.Drawing.Point(39, 271);
            this.txtModalidadAsignacion.Name = "txtModalidadAsignacion";
            this.txtModalidadAsignacion.Size = new System.Drawing.Size(121, 27);
            this.txtModalidadAsignacion.TabIndex = 9;
            // 
            // CreacionDeAsignaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1385, 1061);
            this.Controls.Add(this.panel1);
            this.Name = "CreacionDeAsignaciones";
            this.Text = "CreacionAsignaciones";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtNombreAsignacion;
        private System.Windows.Forms.TextBox txtDetalleAsignacion;
        private System.Windows.Forms.DateTimePicker dtpFecha_limite;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox txtSemanaAsignacion;
        private System.Windows.Forms.TextBox txtPuntosAsignacion;
        private FontAwesome.Sharp.IconButton btnCrearAsignacion2;
        private FontAwesome.Sharp.IconButton btnCancelarAsignacion;
        private System.Windows.Forms.ComboBox txtTipoAsignacion;
        private System.Windows.Forms.ComboBox txtModalidadAsignacion;
        private System.Windows.Forms.Label lblPuntos;
    }
}