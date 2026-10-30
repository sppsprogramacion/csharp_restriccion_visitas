namespace CapaPresentacion
{
    partial class FormConsultaProhibiciones
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
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnHistorial = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.txtDetalle = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtDisposicion = new System.Windows.Forms.TextBox();
            this.dtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.label36 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txtOrganismo = new System.Windows.Forms.TextBox();
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.chkAnulado = new System.Windows.Forms.CheckBox();
            this.label18 = new System.Windows.Forms.Label();
            this.chkVigente = new System.Windows.Forms.CheckBox();
            this.label35 = new System.Windows.Forms.Label();
            this.txtIdProhibicion = new System.Windows.Forms.TextBox();
            this.dtpFechaProhibicion = new System.Windows.Forms.DateTimePicker();
            this.label34 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dtgvProhibiciones = new System.Windows.Forms.DataGridView();
            this.btnVerProhibiciones = new System.Windows.Forms.Button();
            this.dtpFechaInicioSabana = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaFinSabana = new System.Windows.Forms.DateTimePicker();
            this.label21 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvProhibiciones)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnHistorial);
            this.groupBox4.Controls.Add(this.label17);
            this.groupBox4.Controls.Add(this.txtDetalle);
            this.groupBox4.Controls.Add(this.label19);
            this.groupBox4.Controls.Add(this.txtDisposicion);
            this.groupBox4.Controls.Add(this.dtpFechaFin);
            this.groupBox4.Controls.Add(this.label36);
            this.groupBox4.Controls.Add(this.label16);
            this.groupBox4.Controls.Add(this.txtOrganismo);
            this.groupBox4.Controls.Add(this.dtpFechaInicio);
            this.groupBox4.Controls.Add(this.chkAnulado);
            this.groupBox4.Controls.Add(this.label18);
            this.groupBox4.Controls.Add(this.chkVigente);
            this.groupBox4.Controls.Add(this.label35);
            this.groupBox4.Controls.Add(this.txtIdProhibicion);
            this.groupBox4.Controls.Add(this.dtpFechaProhibicion);
            this.groupBox4.Controls.Add(this.label34);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(6, 483);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(697, 223);
            this.groupBox4.TabIndex = 95;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Prohibición";
            // 
            // btnHistorial
            // 
            this.btnHistorial.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnHistorial.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnHistorial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHistorial.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHistorial.ForeColor = System.Drawing.Color.White;
            this.btnHistorial.Location = new System.Drawing.Point(547, 101);
            this.btnHistorial.Name = "btnHistorial";
            this.btnHistorial.Size = new System.Drawing.Size(98, 40);
            this.btnHistorial.TabIndex = 12;
            this.btnHistorial.Text = "HISTORIAL";
            this.btnHistorial.UseVisualStyleBackColor = false;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(6, 66);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(87, 15);
            this.label17.TabIndex = 41;
            this.label17.Text = "DISPOSICION:";
            // 
            // txtDetalle
            // 
            this.txtDetalle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDetalle.Location = new System.Drawing.Point(10, 135);
            this.txtDetalle.Multiline = true;
            this.txtDetalle.Name = "txtDetalle";
            this.txtDetalle.ReadOnly = true;
            this.txtDetalle.Size = new System.Drawing.Size(503, 77);
            this.txtDetalle.TabIndex = 8;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(7, 114);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(63, 15);
            this.label19.TabIndex = 37;
            this.label19.Text = "DETALLE:";
            // 
            // txtDisposicion
            // 
            this.txtDisposicion.Enabled = false;
            this.txtDisposicion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDisposicion.Location = new System.Drawing.Point(10, 85);
            this.txtDisposicion.Name = "txtDisposicion";
            this.txtDisposicion.Size = new System.Drawing.Size(228, 21);
            this.txtDisposicion.TabIndex = 5;
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.Enabled = false;
            this.dtpFechaFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFin.Location = new System.Drawing.Point(398, 84);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(115, 21);
            this.dtpFechaFin.TabIndex = 7;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label36.Location = new System.Drawing.Point(55, 21);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(84, 15);
            this.label36.TabIndex = 87;
            this.label36.Text = "ORGANISMO:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(395, 67);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(71, 15);
            this.label16.TabIndex = 42;
            this.label16.Text = "FECHA FIN:";
            // 
            // txtOrganismo
            // 
            this.txtOrganismo.Enabled = false;
            this.txtOrganismo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOrganismo.Location = new System.Drawing.Point(58, 40);
            this.txtOrganismo.Name = "txtOrganismo";
            this.txtOrganismo.Size = new System.Drawing.Size(213, 21);
            this.txtOrganismo.TabIndex = 86;
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.Enabled = false;
            this.dtpFechaInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaInicio.Location = new System.Drawing.Point(260, 85);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(115, 21);
            this.dtpFechaInicio.TabIndex = 6;
            // 
            // chkAnulado
            // 
            this.chkAnulado.AutoSize = true;
            this.chkAnulado.Enabled = false;
            this.chkAnulado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAnulado.Location = new System.Drawing.Point(516, 40);
            this.chkAnulado.Name = "chkAnulado";
            this.chkAnulado.Size = new System.Drawing.Size(83, 19);
            this.chkAnulado.TabIndex = 85;
            this.chkAnulado.Text = "ANULADO";
            this.chkAnulado.UseVisualStyleBackColor = true;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(256, 66);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(87, 15);
            this.label18.TabIndex = 44;
            this.label18.Text = "FECHA INICIO:";
            // 
            // chkVigente
            // 
            this.chkVigente.AutoSize = true;
            this.chkVigente.Enabled = false;
            this.chkVigente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkVigente.Location = new System.Drawing.Point(418, 40);
            this.chkVigente.Name = "chkVigente";
            this.chkVigente.Size = new System.Drawing.Size(77, 19);
            this.chkVigente.TabIndex = 84;
            this.chkVigente.Text = "VIGENTE";
            this.chkVigente.UseVisualStyleBackColor = true;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label35.Location = new System.Drawing.Point(6, 21);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(22, 15);
            this.label35.TabIndex = 83;
            this.label35.Text = "ID:";
            // 
            // txtIdProhibicion
            // 
            this.txtIdProhibicion.Enabled = false;
            this.txtIdProhibicion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdProhibicion.Location = new System.Drawing.Point(9, 40);
            this.txtIdProhibicion.Name = "txtIdProhibicion";
            this.txtIdProhibicion.Size = new System.Drawing.Size(41, 21);
            this.txtIdProhibicion.TabIndex = 82;
            // 
            // dtpFechaProhibicion
            // 
            this.dtpFechaProhibicion.Enabled = false;
            this.dtpFechaProhibicion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaProhibicion.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaProhibicion.Location = new System.Drawing.Point(290, 40);
            this.dtpFechaProhibicion.Name = "dtpFechaProhibicion";
            this.dtpFechaProhibicion.Size = new System.Drawing.Size(106, 21);
            this.dtpFechaProhibicion.TabIndex = 79;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label34.Location = new System.Drawing.Point(288, 21);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(98, 15);
            this.label34.TabIndex = 80;
            this.label34.Text = "FECHA PROHIB:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dtgvProhibiciones);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(6, 54);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1051, 423);
            this.groupBox3.TabIndex = 94;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Prohibiciones";
            // 
            // dtgvProhibiciones
            // 
            this.dtgvProhibiciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvProhibiciones.Location = new System.Drawing.Point(6, 20);
            this.dtgvProhibiciones.Name = "dtgvProhibiciones";
            this.dtgvProhibiciones.Size = new System.Drawing.Size(1036, 389);
            this.dtgvProhibiciones.TabIndex = 2;
            // 
            // btnVerProhibiciones
            // 
            this.btnVerProhibiciones.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnVerProhibiciones.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnVerProhibiciones.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerProhibiciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerProhibiciones.ForeColor = System.Drawing.Color.White;
            this.btnVerProhibiciones.Location = new System.Drawing.Point(272, 5);
            this.btnVerProhibiciones.Name = "btnVerProhibiciones";
            this.btnVerProhibiciones.Size = new System.Drawing.Size(160, 45);
            this.btnVerProhibiciones.TabIndex = 93;
            this.btnVerProhibiciones.Text = "VER PROHIBICIONES";
            this.btnVerProhibiciones.UseVisualStyleBackColor = false;
            // 
            // dtpFechaInicioSabana
            // 
            this.dtpFechaInicioSabana.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaInicioSabana.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaInicioSabana.Location = new System.Drawing.Point(14, 29);
            this.dtpFechaInicioSabana.Name = "dtpFechaInicioSabana";
            this.dtpFechaInicioSabana.Size = new System.Drawing.Size(115, 21);
            this.dtpFechaInicioSabana.TabIndex = 121;
            // 
            // dtpFechaFinSabana
            // 
            this.dtpFechaFinSabana.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaFinSabana.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFinSabana.Location = new System.Drawing.Point(144, 29);
            this.dtpFechaFinSabana.Name = "dtpFechaFinSabana";
            this.dtpFechaFinSabana.Size = new System.Drawing.Size(115, 21);
            this.dtpFechaFinSabana.TabIndex = 120;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(13, 9);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(87, 15);
            this.label21.TabIndex = 119;
            this.label21.Text = "FECHA INICIO:";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(141, 9);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(71, 15);
            this.label24.TabIndex = 118;
            this.label24.Text = "FECHA FIN:";
            // 
            // FormConsultaProhibiciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1058, 711);
            this.Controls.Add(this.dtpFechaInicioSabana);
            this.Controls.Add(this.dtpFechaFinSabana);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnVerProhibiciones);
            this.Name = "FormConsultaProhibiciones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CONSULTA PROHIBICIONES";
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvProhibiciones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnHistorial;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtDetalle;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtDisposicion;
        private System.Windows.Forms.DateTimePicker dtpFechaFin;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtOrganismo;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.CheckBox chkAnulado;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.CheckBox chkVigente;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.TextBox txtIdProhibicion;
        private System.Windows.Forms.DateTimePicker dtpFechaProhibicion;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dtgvProhibiciones;
        private System.Windows.Forms.Button btnVerProhibiciones;
        private System.Windows.Forms.DateTimePicker dtpFechaInicioSabana;
        private System.Windows.Forms.DateTimePicker dtpFechaFinSabana;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label24;
    }
}