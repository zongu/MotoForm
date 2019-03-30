namespace MotoForm.App
{
    partial class MotoDataListSelect
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gvMotoDataList = new System.Windows.Forms.DataGridView();
            this.motoIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ownerNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.telPhoneDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.motoNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.motoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnOK = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvMotoDataList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.motoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gvMotoDataList);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnOK);
            this.splitContainer1.Size = new System.Drawing.Size(384, 261);
            this.splitContainer1.SplitterDistance = 209;
            this.splitContainer1.TabIndex = 0;
            // 
            // gvMotoDataList
            // 
            this.gvMotoDataList.AllowUserToAddRows = false;
            this.gvMotoDataList.AllowUserToDeleteRows = false;
            this.gvMotoDataList.AllowUserToResizeColumns = false;
            this.gvMotoDataList.AllowUserToResizeRows = false;
            this.gvMotoDataList.AutoGenerateColumns = false;
            this.gvMotoDataList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvMotoDataList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.motoIdDataGridViewTextBoxColumn,
            this.ownerNameDataGridViewTextBoxColumn,
            this.telPhoneDataGridViewTextBoxColumn,
            this.motoNumberDataGridViewTextBoxColumn});
            this.gvMotoDataList.DataSource = this.motoBindingSource;
            this.gvMotoDataList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvMotoDataList.Location = new System.Drawing.Point(0, 0);
            this.gvMotoDataList.MultiSelect = false;
            this.gvMotoDataList.Name = "gvMotoDataList";
            this.gvMotoDataList.RowTemplate.Height = 24;
            this.gvMotoDataList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvMotoDataList.Size = new System.Drawing.Size(384, 209);
            this.gvMotoDataList.TabIndex = 0;
            // 
            // motoIdDataGridViewTextBoxColumn
            // 
            this.motoIdDataGridViewTextBoxColumn.DataPropertyName = "MotoId";
            this.motoIdDataGridViewTextBoxColumn.HeaderText = "MotoId";
            this.motoIdDataGridViewTextBoxColumn.Name = "motoIdDataGridViewTextBoxColumn";
            this.motoIdDataGridViewTextBoxColumn.Width = 50;
            // 
            // ownerNameDataGridViewTextBoxColumn
            // 
            this.ownerNameDataGridViewTextBoxColumn.DataPropertyName = "OwnerName";
            this.ownerNameDataGridViewTextBoxColumn.HeaderText = "車主名稱";
            this.ownerNameDataGridViewTextBoxColumn.Name = "ownerNameDataGridViewTextBoxColumn";
            this.ownerNameDataGridViewTextBoxColumn.Width = 90;
            // 
            // telPhoneDataGridViewTextBoxColumn
            // 
            this.telPhoneDataGridViewTextBoxColumn.DataPropertyName = "TelPhone";
            this.telPhoneDataGridViewTextBoxColumn.HeaderText = "手機電話";
            this.telPhoneDataGridViewTextBoxColumn.Name = "telPhoneDataGridViewTextBoxColumn";
            // 
            // motoNumberDataGridViewTextBoxColumn
            // 
            this.motoNumberDataGridViewTextBoxColumn.DataPropertyName = "MotoNumber";
            this.motoNumberDataGridViewTextBoxColumn.HeaderText = "車牌號碼";
            this.motoNumberDataGridViewTextBoxColumn.Name = "motoNumberDataGridViewTextBoxColumn";
            // 
            // motoBindingSource
            // 
            this.motoBindingSource.DataSource = typeof(MotoForm.Domain.Model.Moto);
            // 
            // btnOK
            // 
            this.btnOK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnOK.Location = new System.Drawing.Point(0, 0);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(384, 48);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "確認";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // MotoDataListSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 261);
            this.Controls.Add(this.splitContainer1);
            this.Name = "MotoDataListSelect";
            this.Text = "MotoDataListSelect";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvMotoDataList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.motoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView gvMotoDataList;
        private System.Windows.Forms.BindingSource motoBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn motoIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ownerNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn telPhoneDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn motoNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button btnOK;
    }
}