namespace CapaPresentacion.Reportes
{
    partial class ReporteInternosVinculados
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
            this.reportInternosVinculados = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // reportInternosVinculados
            // 
            this.reportInternosVinculados.Location = new System.Drawing.Point(12, 12);
            this.reportInternosVinculados.Name = "reportInternosVinculados";
            this.reportInternosVinculados.ServerReport.BearerToken = null;
            this.reportInternosVinculados.Size = new System.Drawing.Size(601, 274);
            this.reportInternosVinculados.TabIndex = 0;
            // 
            // ReporteInternosVinculados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportInternosVinculados);
            this.Name = "ReporteInternosVinculados";
            this.Text = "ReporteInternosVinculados";
            this.Load += new System.EventHandler(this.ReporteInternosVinculados_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportInternosVinculados;
    }
}