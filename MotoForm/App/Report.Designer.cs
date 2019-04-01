namespace MotoForm.App
{
    partial class Report
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpStartDateTime = new System.Windows.Forms.DateTimePicker();
            this.dtpEndDateTime = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.cbQueryCategory = new System.Windows.Forms.ComboBox();
            this.btnQuery = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.gvReportData = new System.Windows.Forms.DataGridView();
            this.reportModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.CategoryGroupName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RecordCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalReceivableAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalActualHarvestAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvReportData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btnExport);
            this.splitContainer1.Panel1.Controls.Add(this.btnQuery);
            this.splitContainer1.Panel1.Controls.Add(this.cbQueryCategory);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.dtpEndDateTime);
            this.splitContainer1.Panel1.Controls.Add(this.dtpStartDateTime);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.label8);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gvReportData);
            this.splitContainer1.Size = new System.Drawing.Size(844, 729);
            this.splitContainer1.SplitterDistance = 120;
            this.splitContainer1.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("新細明體", 20F);
            this.label8.Location = new System.Drawing.Point(20, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(147, 27);
            this.label8.TabIndex = 15;
            this.label8.Text = "開始時間：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 20F);
            this.label1.Location = new System.Drawing.Point(20, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 27);
            this.label1.TabIndex = 16;
            this.label1.Text = "結束時間：";
            // 
            // dtpStartDateTime
            // 
            this.dtpStartDateTime.CustomFormat = "yyyy-MM-dd hh:mm:ss";
            this.dtpStartDateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartDateTime.Location = new System.Drawing.Point(170, 20);
            this.dtpStartDateTime.Name = "dtpStartDateTime";
            this.dtpStartDateTime.ShowUpDown = true;
            this.dtpStartDateTime.Size = new System.Drawing.Size(204, 33);
            this.dtpStartDateTime.TabIndex = 23;
            // 
            // dtpEndDateTime
            // 
            this.dtpEndDateTime.CustomFormat = "yyyy-MM-dd hh:mm:ss";
            this.dtpEndDateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndDateTime.Location = new System.Drawing.Point(170, 70);
            this.dtpEndDateTime.Name = "dtpEndDateTime";
            this.dtpEndDateTime.ShowUpDown = true;
            this.dtpEndDateTime.Size = new System.Drawing.Size(204, 33);
            this.dtpEndDateTime.TabIndex = 24;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("新細明體", 20F);
            this.label2.Location = new System.Drawing.Point(400, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 27);
            this.label2.TabIndex = 25;
            this.label2.Text = "查詢分類：";
            // 
            // cbQueryCategory
            // 
            this.cbQueryCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbQueryCategory.FormattingEnabled = true;
            this.cbQueryCategory.Location = new System.Drawing.Point(540, 20);
            this.cbQueryCategory.Name = "cbQueryCategory";
            this.cbQueryCategory.Size = new System.Drawing.Size(150, 29);
            this.cbQueryCategory.TabIndex = 26;
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(720, 20);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(100, 30);
            this.btnQuery.TabIndex = 27;
            this.btnQuery.Text = "查詢";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(720, 70);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(100, 30);
            this.btnExport.TabIndex = 28;
            this.btnExport.Text = "匯出";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // gvReportData
            // 
            this.gvReportData.AllowUserToAddRows = false;
            this.gvReportData.AllowUserToDeleteRows = false;
            this.gvReportData.AutoGenerateColumns = false;
            this.gvReportData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvReportData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CategoryGroupName,
            this.RecordCount,
            this.TotalReceivableAmount,
            this.TotalActualHarvestAmount});
            this.gvReportData.DataSource = this.reportModelBindingSource;
            this.gvReportData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvReportData.Location = new System.Drawing.Point(0, 0);
            this.gvReportData.Name = "gvReportData";
            this.gvReportData.ReadOnly = true;
            this.gvReportData.RowTemplate.Height = 24;
            this.gvReportData.Size = new System.Drawing.Size(844, 605);
            this.gvReportData.TabIndex = 0;
            // 
            // reportModelBindingSource
            // 
            this.reportModelBindingSource.DataSource = typeof(MotoForm.Model.ReportModel);
            // 
            // CategoryGroupName
            // 
            this.CategoryGroupName.DataPropertyName = "CategoryGroupName";
            this.CategoryGroupName.HeaderText = "查詢分類";
            this.CategoryGroupName.Name = "CategoryGroupName";
            this.CategoryGroupName.ReadOnly = true;
            this.CategoryGroupName.Width = 200;
            // 
            // RecordCount
            // 
            this.RecordCount.DataPropertyName = "RecordCount";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.RecordCount.DefaultCellStyle = dataGridViewCellStyle4;
            this.RecordCount.HeaderText = "維修筆數";
            this.RecordCount.Name = "RecordCount";
            this.RecordCount.ReadOnly = true;
            this.RecordCount.Width = 200;
            // 
            // TotalReceivableAmount
            // 
            this.TotalReceivableAmount.DataPropertyName = "TotalReceivableAmount";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.TotalReceivableAmount.DefaultCellStyle = dataGridViewCellStyle5;
            this.TotalReceivableAmount.HeaderText = "應收";
            this.TotalReceivableAmount.Name = "TotalReceivableAmount";
            this.TotalReceivableAmount.ReadOnly = true;
            this.TotalReceivableAmount.Width = 200;
            // 
            // TotalActualHarvestAmount
            // 
            this.TotalActualHarvestAmount.DataPropertyName = "TotalActualHarvestAmount";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.TotalActualHarvestAmount.DefaultCellStyle = dataGridViewCellStyle6;
            this.TotalActualHarvestAmount.HeaderText = "實收";
            this.TotalActualHarvestAmount.Name = "TotalActualHarvestAmount";
            this.TotalActualHarvestAmount.ReadOnly = true;
            this.TotalActualHarvestAmount.Width = 200;
            // 
            // Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 729);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "Report";
            this.Text = "Report";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvReportData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportModelBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpEndDateTime;
        private System.Windows.Forms.DateTimePicker dtpStartDateTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbQueryCategory;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.DataGridView gvReportData;
        private System.Windows.Forms.BindingSource reportModelBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn CategoryGroupName;
        private System.Windows.Forms.DataGridViewTextBoxColumn RecordCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalReceivableAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalActualHarvestAmount;
    }
}