namespace MotoForm.App
{
    partial class EditRepairRecord
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
            this.gvRepairItems = new System.Windows.Forms.DataGridView();
            this.customRepairRecordBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.customRepairItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.RepairItemId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CategoryDisplayName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnUpdate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvRepairItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customRepairRecordBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customRepairItemBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gvRepairItems);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnUpdate);
            this.splitContainer1.Size = new System.Drawing.Size(384, 261);
            this.splitContainer1.SplitterDistance = 323;
            this.splitContainer1.TabIndex = 0;
            // 
            // gvRepairItems
            // 
            this.gvRepairItems.AllowUserToAddRows = false;
            this.gvRepairItems.AllowUserToDeleteRows = false;
            this.gvRepairItems.AutoGenerateColumns = false;
            this.gvRepairItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvRepairItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RepairItemId,
            this.Category,
            this.CategoryDisplayName,
            this.ItemName,
            this.Qty,
            this.Price});
            this.gvRepairItems.DataSource = this.customRepairItemBindingSource;
            this.gvRepairItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvRepairItems.Location = new System.Drawing.Point(0, 0);
            this.gvRepairItems.Name = "gvRepairItems";
            this.gvRepairItems.RowTemplate.Height = 24;
            this.gvRepairItems.Size = new System.Drawing.Size(323, 261);
            this.gvRepairItems.TabIndex = 0;
            // 
            // customRepairRecordBindingSource
            // 
            this.customRepairRecordBindingSource.DataSource = typeof(MotoForm.Model.CustomRepairRecord);
            // 
            // customRepairItemBindingSource
            // 
            this.customRepairItemBindingSource.DataSource = typeof(MotoForm.Model.CustomRepairItem);
            // 
            // RepairItemId
            // 
            this.RepairItemId.DataPropertyName = "RepairItemId";
            this.RepairItemId.HeaderText = "RepairItemId";
            this.RepairItemId.Name = "RepairItemId";
            this.RepairItemId.Visible = false;
            // 
            // Category
            // 
            this.Category.DataPropertyName = "Category";
            this.Category.HeaderText = "Category";
            this.Category.Name = "Category";
            this.Category.Visible = false;
            // 
            // CategoryDisplayName
            // 
            this.CategoryDisplayName.DataPropertyName = "CategoryDisplayName";
            this.CategoryDisplayName.HeaderText = "類別";
            this.CategoryDisplayName.Name = "CategoryDisplayName";
            this.CategoryDisplayName.Width = 60;
            // 
            // ItemName
            // 
            this.ItemName.DataPropertyName = "ItemName";
            this.ItemName.HeaderText = "項目名稱";
            this.ItemName.Name = "ItemName";
            // 
            // Qty
            // 
            this.Qty.DataPropertyName = "Qty";
            this.Qty.HeaderText = "數量";
            this.Qty.Name = "Qty";
            this.Qty.Width = 60;
            // 
            // Price
            // 
            this.Price.DataPropertyName = "Price";
            this.Price.HeaderText = "價錢";
            this.Price.Name = "Price";
            this.Price.Width = 60;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnUpdate.Location = new System.Drawing.Point(0, 0);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(57, 261);
            this.btnUpdate.TabIndex = 0;
            this.btnUpdate.Text = "更新";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // EditRepairRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 261);
            this.Controls.Add(this.splitContainer1);
            this.Name = "EditRepairRecord";
            this.Text = "EditRepairRecord";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvRepairItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customRepairRecordBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customRepairItemBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView gvRepairItems;
        private System.Windows.Forms.BindingSource customRepairItemBindingSource;
        private System.Windows.Forms.BindingSource customRepairRecordBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn RepairItemId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Category;
        private System.Windows.Forms.DataGridViewTextBoxColumn CategoryDisplayName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.Button btnUpdate;
    }
}