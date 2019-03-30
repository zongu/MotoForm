namespace MotoForm.App
{
    partial class ItemMaintaince
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
            this.btnRepairCategoryAll = new System.Windows.Forms.Button();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.gvRepairItem = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.lbCategoryDisplayName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbItemTotalCount = new System.Windows.Forms.Label();
            this.btnAddRepairItem = new System.Windows.Forms.Button();
            this.btnEditRepairItem = new System.Windows.Forms.Button();
            this.btnDisableRepairItem = new System.Windows.Forms.Button();
            this.repairItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.repairItemBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.repairItemBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.customRepairItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.RepairItemId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CategoryDisplayName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvRepairItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repairItemBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repairItemBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repairItemBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customRepairItemBindingSource)).BeginInit();
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
            this.splitContainer1.Panel1.Controls.Add(this.btnRepairCategoryAll);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1162, 729);
            this.splitContainer1.SplitterDistance = 72;
            this.splitContainer1.TabIndex = 0;
            // 
            // btnRepairCategoryAll
            // 
            this.btnRepairCategoryAll.Location = new System.Drawing.Point(15, 15);
            this.btnRepairCategoryAll.Name = "btnRepairCategoryAll";
            this.btnRepairCategoryAll.Size = new System.Drawing.Size(80, 40);
            this.btnRepairCategoryAll.TabIndex = 0;
            this.btnRepairCategoryAll.Text = "全部";
            this.btnRepairCategoryAll.UseVisualStyleBackColor = true;
            this.btnRepairCategoryAll.Click += new System.EventHandler(this.CategoryFilter);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.lbItemTotalCount);
            this.splitContainer2.Panel1.Controls.Add(this.label3);
            this.splitContainer2.Panel1.Controls.Add(this.label2);
            this.splitContainer2.Panel1.Controls.Add(this.lbCategoryDisplayName);
            this.splitContainer2.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer2.Size = new System.Drawing.Size(1162, 653);
            this.splitContainer2.SplitterDistance = 53;
            this.splitContainer2.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.gvRepairItem);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.btnDisableRepairItem);
            this.splitContainer3.Panel2.Controls.Add(this.btnEditRepairItem);
            this.splitContainer3.Panel2.Controls.Add(this.btnAddRepairItem);
            this.splitContainer3.Size = new System.Drawing.Size(1162, 596);
            this.splitContainer3.SplitterDistance = 840;
            this.splitContainer3.TabIndex = 0;
            // 
            // gvRepairItem
            // 
            this.gvRepairItem.AllowUserToAddRows = false;
            this.gvRepairItem.AllowUserToDeleteRows = false;
            this.gvRepairItem.AllowUserToOrderColumns = true;
            this.gvRepairItem.AllowUserToResizeRows = false;
            this.gvRepairItem.AutoGenerateColumns = false;
            this.gvRepairItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvRepairItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RepairItemId,
            this.ItemName,
            this.Category,
            this.CategoryDisplayName,
            this.Price});
            this.gvRepairItem.DataSource = this.customRepairItemBindingSource;
            this.gvRepairItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvRepairItem.Location = new System.Drawing.Point(0, 0);
            this.gvRepairItem.MultiSelect = false;
            this.gvRepairItem.Name = "gvRepairItem";
            this.gvRepairItem.RowTemplate.Height = 24;
            this.gvRepairItem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvRepairItem.Size = new System.Drawing.Size(840, 596);
            this.gvRepairItem.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "目前顯示類別：";
            // 
            // lbCategoryDisplayName
            // 
            this.lbCategoryDisplayName.AutoSize = true;
            this.lbCategoryDisplayName.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbCategoryDisplayName.Location = new System.Drawing.Point(200, 15);
            this.lbCategoryDisplayName.Name = "lbCategoryDisplayName";
            this.lbCategoryDisplayName.Size = new System.Drawing.Size(54, 21);
            this.lbCategoryDisplayName.TabIndex = 1;
            this.lbCategoryDisplayName.Text = "全部";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(295, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "，共有";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(467, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 21);
            this.label3.TabIndex = 3;
            this.label3.Text = "項";
            // 
            // lbItemTotalCount
            // 
            this.lbItemTotalCount.AutoSize = true;
            this.lbItemTotalCount.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbItemTotalCount.Location = new System.Drawing.Point(390, 15);
            this.lbItemTotalCount.Name = "lbItemTotalCount";
            this.lbItemTotalCount.Size = new System.Drawing.Size(43, 21);
            this.lbItemTotalCount.TabIndex = 4;
            this.lbItemTotalCount.Text = "999";
            // 
            // btnAddRepairItem
            // 
            this.btnAddRepairItem.Location = new System.Drawing.Point(20, 25);
            this.btnAddRepairItem.Name = "btnAddRepairItem";
            this.btnAddRepairItem.Size = new System.Drawing.Size(280, 70);
            this.btnAddRepairItem.TabIndex = 0;
            this.btnAddRepairItem.Text = "新增維修項目";
            this.btnAddRepairItem.UseVisualStyleBackColor = true;
            this.btnAddRepairItem.Click += new System.EventHandler(this.RepairItemOperation);
            // 
            // btnEditRepairItem
            // 
            this.btnEditRepairItem.Location = new System.Drawing.Point(20, 225);
            this.btnEditRepairItem.Name = "btnEditRepairItem";
            this.btnEditRepairItem.Size = new System.Drawing.Size(280, 70);
            this.btnEditRepairItem.TabIndex = 1;
            this.btnEditRepairItem.Text = "編輯維修項目";
            this.btnEditRepairItem.UseVisualStyleBackColor = true;
            this.btnEditRepairItem.Click += new System.EventHandler(this.RepairItemOperation);
            // 
            // btnDisableRepairItem
            // 
            this.btnDisableRepairItem.Location = new System.Drawing.Point(20, 125);
            this.btnDisableRepairItem.Name = "btnDisableRepairItem";
            this.btnDisableRepairItem.Size = new System.Drawing.Size(280, 70);
            this.btnDisableRepairItem.TabIndex = 2;
            this.btnDisableRepairItem.Text = "刪除維修項目";
            this.btnDisableRepairItem.UseVisualStyleBackColor = true;
            this.btnDisableRepairItem.Click += new System.EventHandler(this.RepairItemOperation);
            // 
            // repairItemBindingSource
            // 
            this.repairItemBindingSource.DataSource = typeof(MotoForm.Domain.Model.RepairItem);
            // 
            // repairItemBindingSource1
            // 
            this.repairItemBindingSource1.DataSource = typeof(MotoForm.Domain.Model.RepairItem);
            // 
            // repairItemBindingSource2
            // 
            this.repairItemBindingSource2.DataSource = typeof(MotoForm.Domain.Model.RepairItem);
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
            // ItemName
            // 
            this.ItemName.DataPropertyName = "ItemName";
            this.ItemName.HeaderText = "項目名稱";
            this.ItemName.Name = "ItemName";
            this.ItemName.Width = 500;
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
            this.CategoryDisplayName.Width = 150;
            // 
            // Price
            // 
            this.Price.DataPropertyName = "Price";
            this.Price.HeaderText = "價錢";
            this.Price.Name = "Price";
            this.Price.Width = 150;
            // 
            // ItemMaintaince
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1162, 729);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "ItemMaintaince";
            this.Text = "ItemMaintaince";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvRepairItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repairItemBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repairItemBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repairItemBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customRepairItemBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnRepairCategoryAll;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.DataGridView gvRepairItem;
        private System.Windows.Forms.BindingSource repairItemBindingSource;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbCategoryDisplayName;
        private System.Windows.Forms.Label lbItemTotalCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.BindingSource repairItemBindingSource2;
        private System.Windows.Forms.BindingSource repairItemBindingSource1;
        private System.Windows.Forms.DataGridViewTextBoxColumn categoryDisplayNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button btnAddRepairItem;
        private System.Windows.Forms.Button btnDisableRepairItem;
        private System.Windows.Forms.Button btnEditRepairItem;
        private System.Windows.Forms.BindingSource customRepairItemBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn RepairItemId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Category;
        private System.Windows.Forms.DataGridViewTextBoxColumn CategoryDisplayName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
    }
}