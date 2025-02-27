namespace CapaPresentacion
{
    partial class FormPrincipal
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
            this.btnVerVisitas = new System.Windows.Forms.Button();
            this.label28 = new System.Windows.Forms.Label();
            this.btnCerrarSistema = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnVerVisitas
            // 
            this.btnVerVisitas.BackColor = System.Drawing.Color.Indigo;
            this.btnVerVisitas.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnVerVisitas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerVisitas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerVisitas.ForeColor = System.Drawing.Color.White;
            this.btnVerVisitas.Location = new System.Drawing.Point(23, 49);
            this.btnVerVisitas.Name = "btnVerVisitas";
            this.btnVerVisitas.Size = new System.Drawing.Size(93, 45);
            this.btnVerVisitas.TabIndex = 0;
            this.btnVerVisitas.Text = "Visitas";
            this.btnVerVisitas.UseVisualStyleBackColor = false;
            this.btnVerVisitas.Click += new System.EventHandler(this.btnVerVisitas_Click);
            // 
            // label28
            // 
            this.label28.BackColor = System.Drawing.Color.Indigo;
            this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.ForeColor = System.Drawing.Color.White;
            this.label28.Location = new System.Drawing.Point(1, 1);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(811, 29);
            this.label28.TabIndex = 76;
            this.label28.Text = "RESTRICCION DE VISITAS";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCerrarSistema
            // 
            this.btnCerrarSistema.BackColor = System.Drawing.Color.White;
            this.btnCerrarSistema.FlatAppearance.BorderColor = System.Drawing.Color.Indigo;
            this.btnCerrarSistema.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrarSistema.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrarSistema.ForeColor = System.Drawing.Color.Indigo;
            this.btnCerrarSistema.Location = new System.Drawing.Point(708, 438);
            this.btnCerrarSistema.Name = "btnCerrarSistema";
            this.btnCerrarSistema.Size = new System.Drawing.Size(93, 45);
            this.btnCerrarSistema.TabIndex = 77;
            this.btnCerrarSistema.Text = "Cerrar sistema";
            this.btnCerrarSistema.UseVisualStyleBackColor = false;
            this.btnCerrarSistema.Click += new System.EventHandler(this.btnCerrarSistema_Click);
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(813, 495);
            this.Controls.Add(this.btnCerrarSistema);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.btnVerVisitas);
            this.Name = "FormPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Principal";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnVerVisitas;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Button btnCerrarSistema;
    }
}

