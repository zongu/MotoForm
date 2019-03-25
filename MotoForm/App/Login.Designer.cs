namespace MotoForm.App
{
    partial class Login
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.TbMsg = new System.Windows.Forms.TextBox();
            this.TbPwd = new System.Windows.Forms.TextBox();
            this.BtnLogin = new System.Windows.Forms.Button();
            this.BtnUpdateDb = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.TbMsg);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.BtnUpdateDb);
            this.splitContainer1.Panel2.Controls.Add(this.BtnLogin);
            this.splitContainer1.Panel2.Controls.Add(this.TbPwd);
            this.splitContainer1.Size = new System.Drawing.Size(211, 278);
            this.splitContainer1.SplitterDistance = 109;
            this.splitContainer1.SplitterWidth = 8;
            this.splitContainer1.TabIndex = 0;
            // 
            // TbMsg
            // 
            this.TbMsg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TbMsg.Enabled = false;
            this.TbMsg.Location = new System.Drawing.Point(0, 0);
            this.TbMsg.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.TbMsg.Multiline = true;
            this.TbMsg.Name = "TbMsg";
            this.TbMsg.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TbMsg.Size = new System.Drawing.Size(211, 109);
            this.TbMsg.TabIndex = 0;
            // 
            // TbPwd
            // 
            this.TbPwd.Location = new System.Drawing.Point(7, 0);
            this.TbPwd.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.TbPwd.Name = "TbPwd";
            this.TbPwd.Size = new System.Drawing.Size(197, 36);
            this.TbPwd.TabIndex = 0;
            // 
            // BtnLogin
            // 
            this.BtnLogin.Location = new System.Drawing.Point(7, 48);
            this.BtnLogin.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.BtnLogin.Name = "BtnLogin";
            this.BtnLogin.Size = new System.Drawing.Size(197, 58);
            this.BtnLogin.TabIndex = 1;
            this.BtnLogin.Text = "登入";
            this.BtnLogin.UseVisualStyleBackColor = true;
            this.BtnLogin.Click += new System.EventHandler(this.BtnLogin_Click);
            // 
            // BtnUpdateDb
            // 
            this.BtnUpdateDb.Location = new System.Drawing.Point(7, 118);
            this.BtnUpdateDb.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.BtnUpdateDb.Name = "BtnUpdateDb";
            this.BtnUpdateDb.Size = new System.Drawing.Size(197, 34);
            this.BtnUpdateDb.TabIndex = 2;
            this.BtnUpdateDb.Text = "更新資料庫";
            this.BtnUpdateDb.UseVisualStyleBackColor = true;
            this.BtnUpdateDb.Click += new System.EventHandler(this.BtnUpdateDb_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(211, 278);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.Name = "Login";
            this.Text = "登入";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox TbMsg;
        private System.Windows.Forms.TextBox TbPwd;
        private System.Windows.Forms.Button BtnUpdateDb;
        private System.Windows.Forms.Button BtnLogin;
    }
}