namespace SolisLuciaTPLab3
{
    partial class consultar
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chtConsulta = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dgvConsulta = new System.Windows.Forms.DataGridView();
            this.cmbGrafico = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dtpAnioConsulta = new System.Windows.Forms.DateTimePicker();
            this.cmbProvinciaConsulta = new System.Windows.Forms.ComboBox();
            this.optProvincia = new System.Windows.Forms.RadioButton();
            this.optAnio = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnConsultar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chtConsulta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsulta)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // chtConsulta
            // 
            chartArea1.Name = "ChartArea1";
            this.chtConsulta.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chtConsulta.Legends.Add(legend1);
            this.chtConsulta.Location = new System.Drawing.Point(12, 353);
            this.chtConsulta.Name = "chtConsulta";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chtConsulta.Series.Add(series1);
            this.chtConsulta.Size = new System.Drawing.Size(726, 284);
            this.chtConsulta.TabIndex = 14;
            this.chtConsulta.Text = "chart1";
            // 
            // dgvConsulta
            // 
            this.dgvConsulta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConsulta.Location = new System.Drawing.Point(12, 124);
            this.dgvConsulta.Name = "dgvConsulta";
            this.dgvConsulta.Size = new System.Drawing.Size(726, 223);
            this.dgvConsulta.TabIndex = 13;
            // 
            // cmbGrafico
            // 
            this.cmbGrafico.FormattingEnabled = true;
            this.cmbGrafico.Location = new System.Drawing.Point(373, 42);
            this.cmbGrafico.Name = "cmbGrafico";
            this.cmbGrafico.Size = new System.Drawing.Size(180, 21);
            this.cmbGrafico.TabIndex = 12;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dtpAnioConsulta);
            this.groupBox3.Controls.Add(this.cmbProvinciaConsulta);
            this.groupBox3.Controls.Add(this.optProvincia);
            this.groupBox3.Controls.Add(this.optAnio);
            this.groupBox3.Location = new System.Drawing.Point(12, 14);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(334, 90);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Tipo de Consulta";
            // 
            // dtpAnioConsulta
            // 
            this.dtpAnioConsulta.CustomFormat = "";
            this.dtpAnioConsulta.Location = new System.Drawing.Point(111, 25);
            this.dtpAnioConsulta.Name = "dtpAnioConsulta";
            this.dtpAnioConsulta.ShowUpDown = true;
            this.dtpAnioConsulta.Size = new System.Drawing.Size(76, 20);
            this.dtpAnioConsulta.TabIndex = 8;
            // 
            // cmbProvinciaConsulta
            // 
            this.cmbProvinciaConsulta.FormattingEnabled = true;
            this.cmbProvinciaConsulta.Location = new System.Drawing.Point(111, 55);
            this.cmbProvinciaConsulta.Name = "cmbProvinciaConsulta";
            this.cmbProvinciaConsulta.Size = new System.Drawing.Size(183, 21);
            this.cmbProvinciaConsulta.TabIndex = 4;
            // 
            // optProvincia
            // 
            this.optProvincia.AutoSize = true;
            this.optProvincia.Location = new System.Drawing.Point(17, 59);
            this.optProvincia.Name = "optProvincia";
            this.optProvincia.Size = new System.Drawing.Size(88, 17);
            this.optProvincia.TabIndex = 5;
            this.optProvincia.TabStop = true;
            this.optProvincia.Text = "Por Provincia";
            this.optProvincia.UseVisualStyleBackColor = true;
            // 
            // optAnio
            // 
            this.optAnio.AutoSize = true;
            this.optAnio.Location = new System.Drawing.Point(17, 28);
            this.optAnio.Name = "optAnio";
            this.optAnio.Size = new System.Drawing.Size(63, 17);
            this.optAnio.TabIndex = 4;
            this.optAnio.TabStop = true;
            this.optAnio.Text = "Por Año";
            this.optAnio.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(370, 26);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "Tipo de Gráfico";
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(607, 66);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(90, 32);
            this.btnSalir.TabIndex = 9;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnConsultar
            // 
            this.btnConsultar.Location = new System.Drawing.Point(607, 27);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(90, 32);
            this.btnConsultar.TabIndex = 8;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // consultar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 649);
            this.Controls.Add(this.chtConsulta);
            this.Controls.Add(this.dgvConsulta);
            this.Controls.Add(this.cmbGrafico);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnConsultar);
            this.Name = "consultar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "consultar";
            this.Load += new System.EventHandler(this.consultar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chtConsulta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsulta)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chtConsulta;
        private System.Windows.Forms.DataGridView dgvConsulta;
        private System.Windows.Forms.ComboBox cmbGrafico;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DateTimePicker dtpAnioConsulta;
        private System.Windows.Forms.ComboBox cmbProvinciaConsulta;
        private System.Windows.Forms.RadioButton optProvincia;
        private System.Windows.Forms.RadioButton optAnio;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnConsultar;
    }
}