namespace PairDownloader
{
    partial class Premiun
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea9 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend9 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series17 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series18 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbCommodity = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbFrequency = new System.Windows.Forms.ComboBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.checkBoxRatio = new System.Windows.Forms.CheckBox();
            this.buttonRatio = new System.Windows.Forms.Button();
            this.checkBoxVariation = new System.Windows.Forms.CheckBox();
            this.textBoxFiltreSQLRCALL = new System.Windows.Forms.TextBox();
            this.buttonSQLCALL = new System.Windows.Forms.Button();
            this.textBoxFiltreSQL1VCALL = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxFiltreSQLRPUT = new System.Windows.Forms.TextBox();
            this.textBoxFiltreSQL1VPUT = new System.Windows.Forms.TextBox();
            this.buttonSQLP = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.textBoxDateStart = new System.Windows.Forms.TextBox();
            this.textBoxEndDate = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 34);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(961, 198);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Database premium_callput Table";
            // 
            // cmbCommodity
            // 
            this.cmbCommodity.FormattingEnabled = true;
            this.cmbCommodity.Location = new System.Drawing.Point(76, 248);
            this.cmbCommodity.Name = "cmbCommodity";
            this.cmbCommodity.Size = new System.Drawing.Size(324, 21);
            this.cmbCommodity.TabIndex = 2;
            this.cmbCommodity.SelectedIndexChanged += new System.EventHandler(this.cmbCommodity_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 251);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Commodity";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(414, 251);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Frequency";
            // 
            // cmbFrequency
            // 
            this.cmbFrequency.FormattingEnabled = true;
            this.cmbFrequency.Location = new System.Drawing.Point(477, 248);
            this.cmbFrequency.Name = "cmbFrequency";
            this.cmbFrequency.Size = new System.Drawing.Size(121, 21);
            this.cmbFrequency.TabIndex = 6;
            this.cmbFrequency.SelectedIndexChanged += new System.EventHandler(this.cmbFrequency_SelectedIndexChanged);
            // 
            // chart1
            // 
            this.chart1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chart1.BackColor = System.Drawing.Color.Gray;
            this.chart1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.Center;
            this.chart1.BackHatchStyle = System.Windows.Forms.DataVisualization.Charting.ChartHatchStyle.BackwardDiagonal;
            this.chart1.BackImageTransparentColor = System.Drawing.Color.LightGray;
            this.chart1.BackSecondaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.chart1.BorderlineColor = System.Drawing.Color.Black;
            chartArea9.AxisX.Title = "Current Price";
            chartArea9.AxisX2.Title = "Current Price";
            chartArea9.AxisY.Title = "Premium";
            chartArea9.AxisY2.Title = "Premium Put";
            chartArea9.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea9);
            this.chart1.Cursor = System.Windows.Forms.Cursors.Cross;
            legend9.Name = "Legend1";
            this.chart1.Legends.Add(legend9);
            this.chart1.Location = new System.Drawing.Point(15, 281);
            this.chart1.Name = "chart1";
            series17.ChartArea = "ChartArea1";
            series17.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series17.Legend = "Legend1";
            series17.Name = "Premium Call";
            series18.ChartArea = "ChartArea1";
            series18.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series18.Legend = "Legend1";
            series18.Name = "Premium Put";
            this.chart1.Series.Add(series17);
            this.chart1.Series.Add(series18);
            this.chart1.Size = new System.Drawing.Size(961, 236);
            this.chart1.TabIndex = 7;
            this.chart1.Text = "chart1";
            this.chart1.Click += new System.EventHandler(this.chart1_Click);
            this.chart1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chart1_MouseMove);
            // 
            // checkBoxRatio
            // 
            this.checkBoxRatio.AutoSize = true;
            this.checkBoxRatio.Location = new System.Drawing.Point(604, 254);
            this.checkBoxRatio.Name = "checkBoxRatio";
            this.checkBoxRatio.Size = new System.Drawing.Size(80, 17);
            this.checkBoxRatio.TabIndex = 8;
            this.checkBoxRatio.Text = "GraphRatio";
            this.checkBoxRatio.UseVisualStyleBackColor = true;
            // 
            // buttonRatio
            // 
            this.buttonRatio.Location = new System.Drawing.Point(706, 246);
            this.buttonRatio.Name = "buttonRatio";
            this.buttonRatio.Size = new System.Drawing.Size(48, 23);
            this.buttonRatio.TabIndex = 9;
            this.buttonRatio.Text = "Graph";
            this.buttonRatio.UseVisualStyleBackColor = true;
            this.buttonRatio.Click += new System.EventHandler(this.buttonRatio_Click);
            // 
            // checkBoxVariation
            // 
            this.checkBoxVariation.AutoSize = true;
            this.checkBoxVariation.Location = new System.Drawing.Point(604, 238);
            this.checkBoxVariation.Name = "checkBoxVariation";
            this.checkBoxVariation.Size = new System.Drawing.Size(96, 17);
            this.checkBoxVariation.TabIndex = 10;
            this.checkBoxVariation.Text = "VariationGraph";
            this.checkBoxVariation.UseVisualStyleBackColor = true;
            // 
            // textBoxFiltreSQLRCALL
            // 
            this.textBoxFiltreSQLRCALL.Location = new System.Drawing.Point(817, 233);
            this.textBoxFiltreSQLRCALL.Name = "textBoxFiltreSQLRCALL";
            this.textBoxFiltreSQLRCALL.Size = new System.Drawing.Size(26, 20);
            this.textBoxFiltreSQLRCALL.TabIndex = 11;
            this.textBoxFiltreSQLRCALL.Text = "0.6";
            // 
            // buttonSQLCALL
            // 
            this.buttonSQLCALL.Location = new System.Drawing.Point(849, 243);
            this.buttonSQLCALL.Name = "buttonSQLCALL";
            this.buttonSQLCALL.Size = new System.Drawing.Size(40, 19);
            this.buttonSQLCALL.TabIndex = 12;
            this.buttonSQLCALL.Text = "FilterC";
            this.buttonSQLCALL.UseVisualStyleBackColor = true;
            this.buttonSQLCALL.Click += new System.EventHandler(this.buttonSQL_Click);
            // 
            // textBoxFiltreSQL1VCALL
            // 
            this.textBoxFiltreSQL1VCALL.Location = new System.Drawing.Point(817, 252);
            this.textBoxFiltreSQL1VCALL.Name = "textBoxFiltreSQL1VCALL";
            this.textBoxFiltreSQL1VCALL.Size = new System.Drawing.Size(26, 20);
            this.textBoxFiltreSQL1VCALL.TabIndex = 13;
            this.textBoxFiltreSQL1VCALL.Text = "50";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(779, 236);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Ratio";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(772, 256);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Variation";
            // 
            // textBoxFiltreSQLRPUT
            // 
            this.textBoxFiltreSQLRPUT.Location = new System.Drawing.Point(904, 235);
            this.textBoxFiltreSQLRPUT.Name = "textBoxFiltreSQLRPUT";
            this.textBoxFiltreSQLRPUT.Size = new System.Drawing.Size(27, 20);
            this.textBoxFiltreSQLRPUT.TabIndex = 16;
            this.textBoxFiltreSQLRPUT.Text = "1.3";
            // 
            // textBoxFiltreSQL1VPUT
            // 
            this.textBoxFiltreSQL1VPUT.Location = new System.Drawing.Point(904, 255);
            this.textBoxFiltreSQL1VPUT.Name = "textBoxFiltreSQL1VPUT";
            this.textBoxFiltreSQL1VPUT.Size = new System.Drawing.Size(27, 20);
            this.textBoxFiltreSQL1VPUT.TabIndex = 17;
            this.textBoxFiltreSQL1VPUT.Text = "-47";
            // 
            // buttonSQLP
            // 
            this.buttonSQLP.Location = new System.Drawing.Point(937, 242);
            this.buttonSQLP.Name = "buttonSQLP";
            this.buttonSQLP.Size = new System.Drawing.Size(48, 20);
            this.buttonSQLP.TabIndex = 18;
            this.buttonSQLP.Text = "FilterP";
            this.buttonSQLP.UseVisualStyleBackColor = true;
            this.buttonSQLP.Click += new System.EventHandler(this.buttonSQLP_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(604, 11);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 19);
            this.button1.TabIndex = 19;
            this.button1.Text = "Date Filter";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBoxDateStart
            // 
            this.textBoxDateStart.Location = new System.Drawing.Point(357, 11);
            this.textBoxDateStart.Name = "textBoxDateStart";
            this.textBoxDateStart.Size = new System.Drawing.Size(73, 20);
            this.textBoxDateStart.TabIndex = 20;
            // 
            // textBoxEndDate
            // 
            this.textBoxEndDate.Location = new System.Drawing.Point(466, 11);
            this.textBoxEndDate.Name = "textBoxEndDate";
            this.textBoxEndDate.Size = new System.Drawing.Size(85, 20);
            this.textBoxEndDate.TabIndex = 21;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(706, 9);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(70, 22);
            this.button2.TabIndex = 22;
            this.button2.Text = "AVGbyDay";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Premiun
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(985, 523);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBoxEndDate);
            this.Controls.Add(this.textBoxDateStart);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonSQLP);
            this.Controls.Add(this.textBoxFiltreSQL1VPUT);
            this.Controls.Add(this.textBoxFiltreSQLRPUT);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxFiltreSQL1VCALL);
            this.Controls.Add(this.buttonSQLCALL);
            this.Controls.Add(this.textBoxFiltreSQLRCALL);
            this.Controls.Add(this.checkBoxVariation);
            this.Controls.Add(this.buttonRatio);
            this.Controls.Add(this.checkBoxRatio);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.cmbFrequency);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbCommodity);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Premiun";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Premiun Call & Put";
            this.Load += new System.EventHandler(this.Premiun_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbCommodity;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbFrequency;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.CheckBox checkBoxRatio;
        private System.Windows.Forms.Button buttonRatio;
        private System.Windows.Forms.CheckBox checkBoxVariation;
        private System.Windows.Forms.TextBox textBoxFiltreSQLRCALL;
        private System.Windows.Forms.Button buttonSQLCALL;
        private System.Windows.Forms.TextBox textBoxFiltreSQL1VCALL;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxFiltreSQLRPUT;
        private System.Windows.Forms.TextBox textBoxFiltreSQL1VPUT;
        private System.Windows.Forms.Button buttonSQLP;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBoxDateStart;
        private System.Windows.Forms.TextBox textBoxEndDate;
        private System.Windows.Forms.Button button2;
    }
}