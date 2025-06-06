namespace CapaPresentacion
{
    partial class FormAdminProhibicionAnticipada
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
            this.label28 = new System.Windows.Forms.Label();
            this.pagHistorial = new System.Windows.Forms.TabPage();
            this.pagProhibicion = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnLevantar = new System.Windows.Forms.Button();
            this.btnCancelarLevantar = new System.Windows.Forms.Button();
            this.btnGuardarLevantar = new System.Windows.Forms.Button();
            this.label38 = new System.Windows.Forms.Label();
            this.txtMotivoLevantar = new System.Windows.Forms.TextBox();
            this.dtpFechaFinLevantar = new System.Windows.Forms.DateTimePicker();
            this.label37 = new System.Windows.Forms.Label();
            this.groupBox14 = new System.Windows.Forms.GroupBox();
            this.txtMotivoDetalle = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.dtpkFechaFinProhibicion = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpkFechaInicioProhibicion = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.btnEditarProhibicion = new System.Windows.Forms.Button();
            this.btnGuardarProhibicion = new System.Windows.Forms.Button();
            this.btnCancelarProhibicion = new System.Windows.Forms.Button();
            this.txtIdProhibicionAnticipada = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbSexoVisita = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chkProhibicionVigente = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.chkExInterno = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtDetalleProhibicionAnticipada = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtFechaProhibicion = new System.Windows.Forms.TextBox();
            this.txtOrganismoAlta = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUsuarioAlta = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtTipoLevantamiento = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.txtNombreInterno = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtApellidoInterno = new System.Windows.Forms.TextBox();
            this.txtDniVisita = new System.Windows.Forms.TextBox();
            this.txtNombreVisita = new System.Windows.Forms.TextBox();
            this.txtApellidoVisita = new System.Windows.Forms.TextBox();
            this.tabVisita = new System.Windows.Forms.TabControl();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.label47 = new System.Windows.Forms.Label();
            this.txtNovedad = new System.Windows.Forms.TextBox();
            this.txtUsuarioNovedad = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.txtDetalleNovedad = new System.Windows.Forms.TextBox();
            this.txtOrganismoNovedad = new System.Windows.Forms.TextBox();
            this.label43 = new System.Windows.Forms.Label();
            this.txtFechaNovedad = new System.Windows.Forms.TextBox();
            this.label45 = new System.Windows.Forms.Label();
            this.txtIdNovedad = new System.Windows.Forms.TextBox();
            this.label46 = new System.Windows.Forms.Label();
            this.dtgvNovedades = new System.Windows.Forms.DataGridView();
            this.btnVerNovedades = new System.Windows.Forms.Button();
            this.pagHistorial.SuspendLayout();
            this.pagProhibicion.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox14.SuspendLayout();
            this.tabVisita.SuspendLayout();
            this.groupBox10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvNovedades)).BeginInit();
            this.SuspendLayout();
            // 
            // label28
            // 
            this.label28.BackColor = System.Drawing.Color.Indigo;
            this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.ForeColor = System.Drawing.Color.White;
            this.label28.Location = new System.Drawing.Point(2, 1);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(1090, 29);
            this.label28.TabIndex = 74;
            this.label28.Text = "ADMINISTRAR PROHIBICION ANTICIPADA";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pagHistorial
            // 
            this.pagHistorial.Controls.Add(this.groupBox10);
            this.pagHistorial.Controls.Add(this.dtgvNovedades);
            this.pagHistorial.Controls.Add(this.btnVerNovedades);
            this.pagHistorial.Location = new System.Drawing.Point(4, 25);
            this.pagHistorial.Name = "pagHistorial";
            this.pagHistorial.Padding = new System.Windows.Forms.Padding(3);
            this.pagHistorial.Size = new System.Drawing.Size(1072, 661);
            this.pagHistorial.TabIndex = 1;
            this.pagHistorial.Text = "Historial";
            this.pagHistorial.UseVisualStyleBackColor = true;
            // 
            // pagProhibicion
            // 
            this.pagProhibicion.Controls.Add(this.groupBox2);
            this.pagProhibicion.Controls.Add(this.groupBox14);
            this.pagProhibicion.Location = new System.Drawing.Point(4, 25);
            this.pagProhibicion.Name = "pagProhibicion";
            this.pagProhibicion.Padding = new System.Windows.Forms.Padding(3);
            this.pagProhibicion.Size = new System.Drawing.Size(1072, 685);
            this.pagProhibicion.TabIndex = 0;
            this.pagProhibicion.Text = "Prohibicion";
            this.pagProhibicion.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnLevantar);
            this.groupBox2.Controls.Add(this.btnCancelarLevantar);
            this.groupBox2.Controls.Add(this.btnGuardarLevantar);
            this.groupBox2.Controls.Add(this.label38);
            this.groupBox2.Controls.Add(this.txtMotivoLevantar);
            this.groupBox2.Controls.Add(this.dtpFechaFinLevantar);
            this.groupBox2.Controls.Add(this.label37);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(550, 8);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(506, 290);
            this.groupBox2.TabIndex = 93;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Levantar";
            // 
            // btnLevantar
            // 
            this.btnLevantar.BackColor = System.Drawing.Color.Indigo;
            this.btnLevantar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnLevantar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLevantar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLevantar.ForeColor = System.Drawing.Color.White;
            this.btnLevantar.Location = new System.Drawing.Point(10, 21);
            this.btnLevantar.Name = "btnLevantar";
            this.btnLevantar.Size = new System.Drawing.Size(101, 37);
            this.btnLevantar.TabIndex = 81;
            this.btnLevantar.Text = "LEVANTAR";
            this.btnLevantar.UseVisualStyleBackColor = false;
            this.btnLevantar.Click += new System.EventHandler(this.btnLevantar_Click);
            // 
            // btnCancelarLevantar
            // 
            this.btnCancelarLevantar.BackColor = System.Drawing.Color.DarkOrange;
            this.btnCancelarLevantar.Enabled = false;
            this.btnCancelarLevantar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnCancelarLevantar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelarLevantar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelarLevantar.ForeColor = System.Drawing.Color.White;
            this.btnCancelarLevantar.Location = new System.Drawing.Point(111, 239);
            this.btnCancelarLevantar.Name = "btnCancelarLevantar";
            this.btnCancelarLevantar.Size = new System.Drawing.Size(98, 40);
            this.btnCancelarLevantar.TabIndex = 80;
            this.btnCancelarLevantar.Text = "CANCELAR";
            this.btnCancelarLevantar.UseVisualStyleBackColor = false;
            this.btnCancelarLevantar.Click += new System.EventHandler(this.btnCancelarLevantar_Click);
            // 
            // btnGuardarLevantar
            // 
            this.btnGuardarLevantar.BackColor = System.Drawing.Color.Green;
            this.btnGuardarLevantar.Enabled = false;
            this.btnGuardarLevantar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarLevantar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardarLevantar.ForeColor = System.Drawing.Color.White;
            this.btnGuardarLevantar.Location = new System.Drawing.Point(10, 239);
            this.btnGuardarLevantar.Name = "btnGuardarLevantar";
            this.btnGuardarLevantar.Size = new System.Drawing.Size(98, 40);
            this.btnGuardarLevantar.TabIndex = 79;
            this.btnGuardarLevantar.Text = "GUARDAR";
            this.btnGuardarLevantar.UseVisualStyleBackColor = false;
            this.btnGuardarLevantar.Click += new System.EventHandler(this.btnGuardarLevantar_Click);
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label38.Location = new System.Drawing.Point(7, 122);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(62, 16);
            this.label38.TabIndex = 78;
            this.label38.Text = "MOTIVO:";
            // 
            // txtMotivoLevantar
            // 
            this.txtMotivoLevantar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMotivoLevantar.Enabled = false;
            this.txtMotivoLevantar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMotivoLevantar.Location = new System.Drawing.Point(10, 141);
            this.txtMotivoLevantar.Multiline = true;
            this.txtMotivoLevantar.Name = "txtMotivoLevantar";
            this.txtMotivoLevantar.Size = new System.Drawing.Size(484, 85);
            this.txtMotivoLevantar.TabIndex = 77;
            // 
            // dtpFechaFinLevantar
            // 
            this.dtpFechaFinLevantar.Enabled = false;
            this.dtpFechaFinLevantar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaFinLevantar.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFinLevantar.Location = new System.Drawing.Point(10, 87);
            this.dtpFechaFinLevantar.Name = "dtpFechaFinLevantar";
            this.dtpFechaFinLevantar.Size = new System.Drawing.Size(115, 22);
            this.dtpFechaFinLevantar.TabIndex = 43;
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label37.Location = new System.Drawing.Point(7, 68);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(79, 16);
            this.label37.TabIndex = 44;
            this.label37.Text = "FECHA FIN:";
            // 
            // groupBox14
            // 
            this.groupBox14.Controls.Add(this.txtMotivoDetalle);
            this.groupBox14.Controls.Add(this.label9);
            this.groupBox14.Controls.Add(this.dtpkFechaFinProhibicion);
            this.groupBox14.Controls.Add(this.label3);
            this.groupBox14.Controls.Add(this.dtpkFechaInicioProhibicion);
            this.groupBox14.Controls.Add(this.label8);
            this.groupBox14.Controls.Add(this.btnEditarProhibicion);
            this.groupBox14.Controls.Add(this.btnGuardarProhibicion);
            this.groupBox14.Controls.Add(this.btnCancelarProhibicion);
            this.groupBox14.Controls.Add(this.txtIdProhibicionAnticipada);
            this.groupBox14.Controls.Add(this.label7);
            this.groupBox14.Controls.Add(this.label1);
            this.groupBox14.Controls.Add(this.cmbSexoVisita);
            this.groupBox14.Controls.Add(this.label4);
            this.groupBox14.Controls.Add(this.chkProhibicionVigente);
            this.groupBox14.Controls.Add(this.label5);
            this.groupBox14.Controls.Add(this.chkExInterno);
            this.groupBox14.Controls.Add(this.label10);
            this.groupBox14.Controls.Add(this.txtDetalleProhibicionAnticipada);
            this.groupBox14.Controls.Add(this.label13);
            this.groupBox14.Controls.Add(this.txtFechaProhibicion);
            this.groupBox14.Controls.Add(this.txtOrganismoAlta);
            this.groupBox14.Controls.Add(this.label2);
            this.groupBox14.Controls.Add(this.txtUsuarioAlta);
            this.groupBox14.Controls.Add(this.label14);
            this.groupBox14.Controls.Add(this.txtTipoLevantamiento);
            this.groupBox14.Controls.Add(this.label15);
            this.groupBox14.Controls.Add(this.label27);
            this.groupBox14.Controls.Add(this.label30);
            this.groupBox14.Controls.Add(this.txtNombreInterno);
            this.groupBox14.Controls.Add(this.label6);
            this.groupBox14.Controls.Add(this.txtApellidoInterno);
            this.groupBox14.Controls.Add(this.txtDniVisita);
            this.groupBox14.Controls.Add(this.txtNombreVisita);
            this.groupBox14.Controls.Add(this.txtApellidoVisita);
            this.groupBox14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox14.Location = new System.Drawing.Point(10, 8);
            this.groupBox14.Name = "groupBox14";
            this.groupBox14.Size = new System.Drawing.Size(532, 665);
            this.groupBox14.TabIndex = 92;
            this.groupBox14.TabStop = false;
            this.groupBox14.Text = "Editar";
            // 
            // txtMotivoDetalle
            // 
            this.txtMotivoDetalle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMotivoDetalle.Location = new System.Drawing.Point(11, 380);
            this.txtMotivoDetalle.Multiline = true;
            this.txtMotivoDetalle.Name = "txtMotivoDetalle";
            this.txtMotivoDetalle.ReadOnly = true;
            this.txtMotivoDetalle.Size = new System.Drawing.Size(512, 60);
            this.txtMotivoDetalle.TabIndex = 118;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(8, 359);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(119, 16);
            this.label9.TabIndex = 119;
            this.label9.Text = "MOTIVO EDICION:";
            // 
            // dtpkFechaFinProhibicion
            // 
            this.dtpkFechaFinProhibicion.Enabled = false;
            this.dtpkFechaFinProhibicion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpkFechaFinProhibicion.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpkFechaFinProhibicion.Location = new System.Drawing.Point(263, 324);
            this.dtpkFechaFinProhibicion.Name = "dtpkFechaFinProhibicion";
            this.dtpkFechaFinProhibicion.Size = new System.Drawing.Size(115, 22);
            this.dtpkFechaFinProhibicion.TabIndex = 115;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(260, 307);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 16);
            this.label3.TabIndex = 116;
            this.label3.Text = "FECHA FIN:";
            // 
            // dtpkFechaInicioProhibicion
            // 
            this.dtpkFechaInicioProhibicion.Enabled = false;
            this.dtpkFechaInicioProhibicion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpkFechaInicioProhibicion.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpkFechaInicioProhibicion.Location = new System.Drawing.Point(11, 326);
            this.dtpkFechaInicioProhibicion.Name = "dtpkFechaInicioProhibicion";
            this.dtpkFechaInicioProhibicion.Size = new System.Drawing.Size(115, 22);
            this.dtpkFechaInicioProhibicion.TabIndex = 114;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(7, 307);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(96, 16);
            this.label8.TabIndex = 117;
            this.label8.Text = "FECHA INICIO:";
            // 
            // btnEditarProhibicion
            // 
            this.btnEditarProhibicion.BackColor = System.Drawing.Color.Indigo;
            this.btnEditarProhibicion.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnEditarProhibicion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditarProhibicion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditarProhibicion.ForeColor = System.Drawing.Color.White;
            this.btnEditarProhibicion.Location = new System.Drawing.Point(11, 610);
            this.btnEditarProhibicion.Name = "btnEditarProhibicion";
            this.btnEditarProhibicion.Size = new System.Drawing.Size(98, 40);
            this.btnEditarProhibicion.TabIndex = 91;
            this.btnEditarProhibicion.Text = "EDITAR";
            this.btnEditarProhibicion.UseVisualStyleBackColor = false;
            this.btnEditarProhibicion.Click += new System.EventHandler(this.btnEditarProhibicion_Click);
            // 
            // btnGuardarProhibicion
            // 
            this.btnGuardarProhibicion.BackColor = System.Drawing.Color.Green;
            this.btnGuardarProhibicion.Enabled = false;
            this.btnGuardarProhibicion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarProhibicion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardarProhibicion.ForeColor = System.Drawing.Color.White;
            this.btnGuardarProhibicion.Location = new System.Drawing.Point(141, 610);
            this.btnGuardarProhibicion.Name = "btnGuardarProhibicion";
            this.btnGuardarProhibicion.Size = new System.Drawing.Size(98, 40);
            this.btnGuardarProhibicion.TabIndex = 92;
            this.btnGuardarProhibicion.Text = "GUARDAR";
            this.btnGuardarProhibicion.UseVisualStyleBackColor = false;
            this.btnGuardarProhibicion.Click += new System.EventHandler(this.btnGuardarProhibicion_Click);
            // 
            // btnCancelarProhibicion
            // 
            this.btnCancelarProhibicion.BackColor = System.Drawing.Color.DarkOrange;
            this.btnCancelarProhibicion.Enabled = false;
            this.btnCancelarProhibicion.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnCancelarProhibicion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelarProhibicion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelarProhibicion.ForeColor = System.Drawing.Color.White;
            this.btnCancelarProhibicion.Location = new System.Drawing.Point(245, 610);
            this.btnCancelarProhibicion.Name = "btnCancelarProhibicion";
            this.btnCancelarProhibicion.Size = new System.Drawing.Size(98, 40);
            this.btnCancelarProhibicion.TabIndex = 93;
            this.btnCancelarProhibicion.Text = "CANCELAR";
            this.btnCancelarProhibicion.UseVisualStyleBackColor = false;
            this.btnCancelarProhibicion.Click += new System.EventHandler(this.btnCancelarProhibicion_Click);
            // 
            // txtIdProhibicionAnticipada
            // 
            this.txtIdProhibicionAnticipada.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIdProhibicionAnticipada.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdProhibicionAnticipada.Location = new System.Drawing.Point(11, 38);
            this.txtIdProhibicionAnticipada.Name = "txtIdProhibicionAnticipada";
            this.txtIdProhibicionAnticipada.ReadOnly = true;
            this.txtIdProhibicionAnticipada.Size = new System.Drawing.Size(228, 22);
            this.txtIdProhibicionAnticipada.TabIndex = 54;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(260, 118);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 16);
            this.label7.TabIndex = 90;
            this.label7.Text = "SEXO:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 16);
            this.label1.TabIndex = 23;
            this.label1.Text = "DNI VISITA:";
            // 
            // cmbSexoVisita
            // 
            this.cmbSexoVisita.Enabled = false;
            this.cmbSexoVisita.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSexoVisita.FormattingEnabled = true;
            this.cmbSexoVisita.Location = new System.Drawing.Point(263, 137);
            this.cmbSexoVisita.Name = "cmbSexoVisita";
            this.cmbSexoVisita.Size = new System.Drawing.Size(228, 24);
            this.cmbSexoVisita.TabIndex = 89;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 16);
            this.label4.TabIndex = 28;
            this.label4.Text = "APELLIDO VISITA";
            // 
            // chkProhibicionVigente
            // 
            this.chkProhibicionVigente.AutoSize = true;
            this.chkProhibicionVigente.Enabled = false;
            this.chkProhibicionVigente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkProhibicionVigente.Location = new System.Drawing.Point(11, 456);
            this.chkProhibicionVigente.Name = "chkProhibicionVigente";
            this.chkProhibicionVigente.Size = new System.Drawing.Size(85, 20);
            this.chkProhibicionVigente.TabIndex = 88;
            this.chkProhibicionVigente.Text = "VIGENTE";
            this.chkProhibicionVigente.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(260, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 16);
            this.label5.TabIndex = 29;
            this.label5.Text = "NOMBRE VISITA";
            // 
            // chkExInterno
            // 
            this.chkExInterno.AutoSize = true;
            this.chkExInterno.Enabled = false;
            this.chkExInterno.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkExInterno.Location = new System.Drawing.Point(261, 40);
            this.chkExInterno.Name = "chkExInterno";
            this.chkExInterno.Size = new System.Drawing.Size(125, 20);
            this.chkExInterno.TabIndex = 87;
            this.chkExInterno.Text = "ES EXINTERNO";
            this.chkExInterno.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(8, 258);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(138, 16);
            this.label10.TabIndex = 40;
            this.label10.Text = "APELLIDO INTERNO:";
            // 
            // txtDetalleProhibicionAnticipada
            // 
            this.txtDetalleProhibicionAnticipada.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDetalleProhibicionAnticipada.Location = new System.Drawing.Point(11, 188);
            this.txtDetalleProhibicionAnticipada.Multiline = true;
            this.txtDetalleProhibicionAnticipada.Name = "txtDetalleProhibicionAnticipada";
            this.txtDetalleProhibicionAnticipada.ReadOnly = true;
            this.txtDetalleProhibicionAnticipada.Size = new System.Drawing.Size(512, 60);
            this.txtDetalleProhibicionAnticipada.TabIndex = 63;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(260, 258);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(133, 16);
            this.label13.TabIndex = 44;
            this.label13.Text = "NOMBRE INTERNO:";
            // 
            // txtFechaProhibicion
            // 
            this.txtFechaProhibicion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFechaProhibicion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaProhibicion.Location = new System.Drawing.Point(11, 574);
            this.txtFechaProhibicion.Name = "txtFechaProhibicion";
            this.txtFechaProhibicion.ReadOnly = true;
            this.txtFechaProhibicion.Size = new System.Drawing.Size(228, 22);
            this.txtFechaProhibicion.TabIndex = 62;
            // 
            // txtOrganismoAlta
            // 
            this.txtOrganismoAlta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOrganismoAlta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOrganismoAlta.Location = new System.Drawing.Point(261, 524);
            this.txtOrganismoAlta.Name = "txtOrganismoAlta";
            this.txtOrganismoAlta.ReadOnly = true;
            this.txtOrganismoAlta.Size = new System.Drawing.Size(228, 22);
            this.txtOrganismoAlta.TabIndex = 58;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(258, 449);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(158, 16);
            this.label2.TabIndex = 50;
            this.label2.Text = "TIPO LEVANTAMIENTO:";
            // 
            // txtUsuarioAlta
            // 
            this.txtUsuarioAlta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUsuarioAlta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuarioAlta.Location = new System.Drawing.Point(11, 524);
            this.txtUsuarioAlta.Name = "txtUsuarioAlta";
            this.txtUsuarioAlta.ReadOnly = true;
            this.txtUsuarioAlta.Size = new System.Drawing.Size(228, 22);
            this.txtUsuarioAlta.TabIndex = 53;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(8, 505);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(108, 16);
            this.label14.TabIndex = 52;
            this.label14.Text = "USUARIO ALTA:";
            // 
            // txtTipoLevantamiento
            // 
            this.txtTipoLevantamiento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTipoLevantamiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTipoLevantamiento.Location = new System.Drawing.Point(261, 468);
            this.txtTipoLevantamiento.Name = "txtTipoLevantamiento";
            this.txtTipoLevantamiento.ReadOnly = true;
            this.txtTipoLevantamiento.Size = new System.Drawing.Size(228, 22);
            this.txtTipoLevantamiento.TabIndex = 51;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(8, 19);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(23, 16);
            this.label15.TabIndex = 55;
            this.label15.Text = "ID:";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.Location = new System.Drawing.Point(258, 505);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(126, 16);
            this.label27.TabIndex = 57;
            this.label27.Text = "ORGANISMO ALTA";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.Location = new System.Drawing.Point(8, 555);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(144, 16);
            this.label30.TabIndex = 61;
            this.label30.Text = "FECHA PROHIBICION:";
            // 
            // txtNombreInterno
            // 
            this.txtNombreInterno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNombreInterno.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreInterno.Location = new System.Drawing.Point(263, 277);
            this.txtNombreInterno.Name = "txtNombreInterno";
            this.txtNombreInterno.ReadOnly = true;
            this.txtNombreInterno.Size = new System.Drawing.Size(228, 22);
            this.txtNombreInterno.TabIndex = 45;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(8, 167);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 16);
            this.label6.TabIndex = 64;
            this.label6.Text = "DETALLE:";
            // 
            // txtApellidoInterno
            // 
            this.txtApellidoInterno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtApellidoInterno.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApellidoInterno.Location = new System.Drawing.Point(11, 277);
            this.txtApellidoInterno.Name = "txtApellidoInterno";
            this.txtApellidoInterno.ReadOnly = true;
            this.txtApellidoInterno.Size = new System.Drawing.Size(228, 22);
            this.txtApellidoInterno.TabIndex = 41;
            // 
            // txtDniVisita
            // 
            this.txtDniVisita.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDniVisita.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDniVisita.Location = new System.Drawing.Point(11, 137);
            this.txtDniVisita.Name = "txtDniVisita";
            this.txtDniVisita.ReadOnly = true;
            this.txtDniVisita.Size = new System.Drawing.Size(228, 22);
            this.txtDniVisita.TabIndex = 21;
            // 
            // txtNombreVisita
            // 
            this.txtNombreVisita.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNombreVisita.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreVisita.Location = new System.Drawing.Point(263, 87);
            this.txtNombreVisita.Name = "txtNombreVisita";
            this.txtNombreVisita.ReadOnly = true;
            this.txtNombreVisita.Size = new System.Drawing.Size(228, 22);
            this.txtNombreVisita.TabIndex = 20;
            // 
            // txtApellidoVisita
            // 
            this.txtApellidoVisita.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtApellidoVisita.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApellidoVisita.Location = new System.Drawing.Point(11, 87);
            this.txtApellidoVisita.Name = "txtApellidoVisita";
            this.txtApellidoVisita.ReadOnly = true;
            this.txtApellidoVisita.Size = new System.Drawing.Size(228, 22);
            this.txtApellidoVisita.TabIndex = 19;
            // 
            // tabVisita
            // 
            this.tabVisita.Controls.Add(this.pagProhibicion);
            this.tabVisita.Controls.Add(this.pagHistorial);
            this.tabVisita.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabVisita.Location = new System.Drawing.Point(2, 35);
            this.tabVisita.Name = "tabVisita";
            this.tabVisita.SelectedIndex = 0;
            this.tabVisita.Size = new System.Drawing.Size(1080, 714);
            this.tabVisita.TabIndex = 0;
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.label47);
            this.groupBox10.Controls.Add(this.txtNovedad);
            this.groupBox10.Controls.Add(this.txtUsuarioNovedad);
            this.groupBox10.Controls.Add(this.label23);
            this.groupBox10.Controls.Add(this.label20);
            this.groupBox10.Controls.Add(this.txtDetalleNovedad);
            this.groupBox10.Controls.Add(this.txtOrganismoNovedad);
            this.groupBox10.Controls.Add(this.label43);
            this.groupBox10.Controls.Add(this.txtFechaNovedad);
            this.groupBox10.Controls.Add(this.label45);
            this.groupBox10.Controls.Add(this.txtIdNovedad);
            this.groupBox10.Controls.Add(this.label46);
            this.groupBox10.Location = new System.Drawing.Point(8, 385);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(1035, 186);
            this.groupBox10.TabIndex = 83;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Novedad";
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label47.Location = new System.Drawing.Point(6, 79);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(77, 16);
            this.label47.TabIndex = 86;
            this.label47.Text = "NOVEDAD:";
            // 
            // txtNovedad
            // 
            this.txtNovedad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNovedad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNovedad.Location = new System.Drawing.Point(9, 98);
            this.txtNovedad.Multiline = true;
            this.txtNovedad.Name = "txtNovedad";
            this.txtNovedad.ReadOnly = true;
            this.txtNovedad.Size = new System.Drawing.Size(317, 67);
            this.txtNovedad.TabIndex = 85;
            // 
            // txtUsuarioNovedad
            // 
            this.txtUsuarioNovedad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuarioNovedad.Location = new System.Drawing.Point(570, 43);
            this.txtUsuarioNovedad.Name = "txtUsuarioNovedad";
            this.txtUsuarioNovedad.ReadOnly = true;
            this.txtUsuarioNovedad.Size = new System.Drawing.Size(227, 22);
            this.txtUsuarioNovedad.TabIndex = 84;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(566, 24);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(71, 16);
            this.label23.TabIndex = 83;
            this.label23.Text = "USUARIO:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(335, 79);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(70, 16);
            this.label20.TabIndex = 82;
            this.label20.Text = "DETALLE:";
            // 
            // txtDetalleNovedad
            // 
            this.txtDetalleNovedad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDetalleNovedad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDetalleNovedad.Location = new System.Drawing.Point(338, 98);
            this.txtDetalleNovedad.Multiline = true;
            this.txtDetalleNovedad.Name = "txtDetalleNovedad";
            this.txtDetalleNovedad.ReadOnly = true;
            this.txtDetalleNovedad.Size = new System.Drawing.Size(682, 67);
            this.txtDetalleNovedad.TabIndex = 81;
            // 
            // txtOrganismoNovedad
            // 
            this.txtOrganismoNovedad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOrganismoNovedad.Location = new System.Drawing.Point(210, 43);
            this.txtOrganismoNovedad.Name = "txtOrganismoNovedad";
            this.txtOrganismoNovedad.ReadOnly = true;
            this.txtOrganismoNovedad.Size = new System.Drawing.Size(349, 22);
            this.txtOrganismoNovedad.TabIndex = 80;
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label43.Location = new System.Drawing.Point(6, 24);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(23, 16);
            this.label43.TabIndex = 78;
            this.label43.Text = "ID:";
            // 
            // txtFechaNovedad
            // 
            this.txtFechaNovedad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaNovedad.Location = new System.Drawing.Point(103, 44);
            this.txtFechaNovedad.Name = "txtFechaNovedad";
            this.txtFechaNovedad.ReadOnly = true;
            this.txtFechaNovedad.Size = new System.Drawing.Size(95, 22);
            this.txtFechaNovedad.TabIndex = 64;
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label45.Location = new System.Drawing.Point(100, 24);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(55, 16);
            this.label45.TabIndex = 66;
            this.label45.Text = "FECHA:";
            // 
            // txtIdNovedad
            // 
            this.txtIdNovedad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdNovedad.Location = new System.Drawing.Point(9, 44);
            this.txtIdNovedad.Name = "txtIdNovedad";
            this.txtIdNovedad.ReadOnly = true;
            this.txtIdNovedad.Size = new System.Drawing.Size(80, 22);
            this.txtIdNovedad.TabIndex = 77;
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label46.Location = new System.Drawing.Point(206, 24);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(92, 16);
            this.label46.TabIndex = 72;
            this.label46.Text = "ORGANISMO:";
            // 
            // dtgvNovedades
            // 
            this.dtgvNovedades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvNovedades.Location = new System.Drawing.Point(8, 61);
            this.dtgvNovedades.Name = "dtgvNovedades";
            this.dtgvNovedades.Size = new System.Drawing.Size(1035, 310);
            this.dtgvNovedades.TabIndex = 82;
            // 
            // btnVerNovedades
            // 
            this.btnVerNovedades.BackColor = System.Drawing.Color.Indigo;
            this.btnVerNovedades.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnVerNovedades.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerNovedades.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerNovedades.ForeColor = System.Drawing.Color.White;
            this.btnVerNovedades.Location = new System.Drawing.Point(8, 8);
            this.btnVerNovedades.Name = "btnVerNovedades";
            this.btnVerNovedades.Size = new System.Drawing.Size(141, 45);
            this.btnVerNovedades.TabIndex = 81;
            this.btnVerNovedades.Text = "Ver novedades";
            this.btnVerNovedades.UseVisualStyleBackColor = false;
            // 
            // FormAdminProhibicionAnticipada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1094, 749);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.tabVisita);
            this.Name = "FormAdminProhibicionAnticipada";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Administrar Prohibicion Anticipada";
            this.Load += new System.EventHandler(this.FormAdminProhibicionAnticipada_Load_1);
            this.pagHistorial.ResumeLayout(false);
            this.pagProhibicion.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox14.ResumeLayout(false);
            this.groupBox14.PerformLayout();
            this.tabVisita.ResumeLayout(false);
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvNovedades)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TabPage pagHistorial;
        private System.Windows.Forms.TabPage pagProhibicion;
        private System.Windows.Forms.GroupBox groupBox14;
        private System.Windows.Forms.DateTimePicker dtpkFechaFinProhibicion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpkFechaInicioProhibicion;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnEditarProhibicion;
        private System.Windows.Forms.Button btnGuardarProhibicion;
        private System.Windows.Forms.Button btnCancelarProhibicion;
        private System.Windows.Forms.TextBox txtIdProhibicionAnticipada;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbSexoVisita;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkProhibicionVigente;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkExInterno;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtDetalleProhibicionAnticipada;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtFechaProhibicion;
        private System.Windows.Forms.TextBox txtOrganismoAlta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUsuarioAlta;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtTipoLevantamiento;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.TextBox txtNombreInterno;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtApellidoInterno;
        private System.Windows.Forms.TextBox txtDniVisita;
        private System.Windows.Forms.TextBox txtNombreVisita;
        private System.Windows.Forms.TextBox txtApellidoVisita;
        private System.Windows.Forms.TabControl tabVisita;
        private System.Windows.Forms.TextBox txtMotivoDetalle;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnLevantar;
        private System.Windows.Forms.Button btnCancelarLevantar;
        private System.Windows.Forms.Button btnGuardarLevantar;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.TextBox txtMotivoLevantar;
        private System.Windows.Forms.DateTimePicker dtpFechaFinLevantar;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.TextBox txtNovedad;
        private System.Windows.Forms.TextBox txtUsuarioNovedad;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtDetalleNovedad;
        private System.Windows.Forms.TextBox txtOrganismoNovedad;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.TextBox txtFechaNovedad;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.TextBox txtIdNovedad;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.DataGridView dtgvNovedades;
        private System.Windows.Forms.Button btnVerNovedades;
    }
}