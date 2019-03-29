namespace MotoForm
{
    partial class LobbyForm
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.BtnSale = new System.Windows.Forms.Button();
            this.BtnItemMaintaince = new System.Windows.Forms.Button();
            this.BtnReport = new System.Windows.Forms.Button();
            this.LbTotalCount = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BtnSale
            // 
            this.BtnSale.Location = new System.Drawing.Point(12, 48);
            this.BtnSale.Name = "BtnSale";
            this.BtnSale.Size = new System.Drawing.Size(245, 68);
            this.BtnSale.TabIndex = 0;
            this.BtnSale.Text = "銷      售";
            this.BtnSale.UseVisualStyleBackColor = true;
            this.BtnSale.Click += new System.EventHandler(this.Btn_Click);
            // 
            // BtnItemMaintaince
            // 
            this.BtnItemMaintaince.Location = new System.Drawing.Point(10, 122);
            this.BtnItemMaintaince.Name = "BtnItemMaintaince";
            this.BtnItemMaintaince.Size = new System.Drawing.Size(245, 68);
            this.BtnItemMaintaince.TabIndex = 1;
            this.BtnItemMaintaince.Text = "商品維護";
            this.BtnItemMaintaince.UseVisualStyleBackColor = true;
            this.BtnItemMaintaince.Click += new System.EventHandler(this.Btn_Click);
            // 
            // BtnReport
            // 
            this.BtnReport.Location = new System.Drawing.Point(12, 196);
            this.BtnReport.Name = "BtnReport";
            this.BtnReport.Size = new System.Drawing.Size(245, 68);
            this.BtnReport.TabIndex = 2;
            this.BtnReport.Text = "報表查詢";
            this.BtnReport.UseVisualStyleBackColor = true;
            this.BtnReport.Click += new System.EventHandler(this.Btn_Click);
            // 
            // LbTotalCount
            // 
            this.LbTotalCount.AutoSize = true;
            this.LbTotalCount.Location = new System.Drawing.Point(12, 9);
            this.LbTotalCount.Name = "LbTotalCount";
            this.LbTotalCount.Size = new System.Drawing.Size(178, 24);
            this.LbTotalCount.TabIndex = 3;
            this.LbTotalCount.Text = "今日修車統計：";
            // 
            // LobbyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(267, 275);
            this.Controls.Add(this.LbTotalCount);
            this.Controls.Add(this.BtnReport);
            this.Controls.Add(this.BtnItemMaintaince);
            this.Controls.Add(this.BtnSale);
            this.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.Name = "LobbyForm";
            this.Text = "大廳";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnSale;
        private System.Windows.Forms.Button BtnItemMaintaince;
        private System.Windows.Forms.Button BtnReport;
        private System.Windows.Forms.Label LbTotalCount;
    }
}

