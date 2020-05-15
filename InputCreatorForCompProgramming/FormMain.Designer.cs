namespace InputCreatorForCompProgramming
{
    partial class FormMain
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.listBoxInputInfo = new System.Windows.Forms.ListBox();
            this.panelButton = new System.Windows.Forms.Panel();
            this.btnCreateInputData = new System.Windows.Forms.Button();
            this.btnDeleteInputInfo = new System.Windows.Forms.Button();
            this.btnEditInputInfo = new System.Windows.Forms.Button();
            this.groupAddButton = new System.Windows.Forms.GroupBox();
            this.btnInteger = new System.Windows.Forms.Button();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.btnList = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panelButton.SuspendLayout();
            this.groupAddButton.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.listBoxInputInfo);
            this.splitContainer1.Panel1.Controls.Add(this.panelButton);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txtOutput);
            this.splitContainer1.Size = new System.Drawing.Size(800, 450);
            this.splitContainer1.SplitterDistance = 464;
            this.splitContainer1.TabIndex = 0;
            // 
            // listBoxInputInfo
            // 
            this.listBoxInputInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxInputInfo.FormattingEnabled = true;
            this.listBoxInputInfo.ItemHeight = 12;
            this.listBoxInputInfo.Location = new System.Drawing.Point(0, 0);
            this.listBoxInputInfo.Name = "listBoxInputInfo";
            this.listBoxInputInfo.ScrollAlwaysVisible = true;
            this.listBoxInputInfo.Size = new System.Drawing.Size(460, 304);
            this.listBoxInputInfo.TabIndex = 1;
            // 
            // panelButton
            // 
            this.panelButton.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelButton.Controls.Add(this.btnCreateInputData);
            this.panelButton.Controls.Add(this.btnDeleteInputInfo);
            this.panelButton.Controls.Add(this.btnEditInputInfo);
            this.panelButton.Controls.Add(this.groupAddButton);
            this.panelButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButton.Location = new System.Drawing.Point(0, 304);
            this.panelButton.Name = "panelButton";
            this.panelButton.Size = new System.Drawing.Size(460, 142);
            this.panelButton.TabIndex = 0;
            // 
            // btnCreateInputData
            // 
            this.btnCreateInputData.Location = new System.Drawing.Point(280, 94);
            this.btnCreateInputData.Name = "btnCreateInputData";
            this.btnCreateInputData.Size = new System.Drawing.Size(167, 39);
            this.btnCreateInputData.TabIndex = 0;
            this.btnCreateInputData.Text = "入力データを生成";
            this.btnCreateInputData.UseVisualStyleBackColor = true;
            this.btnCreateInputData.Click += new System.EventHandler(this.btnCreateInputData_Click);
            // 
            // btnDeleteInputInfo
            // 
            this.btnDeleteInputInfo.Location = new System.Drawing.Point(361, 4);
            this.btnDeleteInputInfo.Name = "btnDeleteInputInfo";
            this.btnDeleteInputInfo.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteInputInfo.TabIndex = 3;
            this.btnDeleteInputInfo.Text = "削除";
            this.btnDeleteInputInfo.UseVisualStyleBackColor = true;
            // 
            // btnEditInputInfo
            // 
            this.btnEditInputInfo.Location = new System.Drawing.Point(280, 3);
            this.btnEditInputInfo.Name = "btnEditInputInfo";
            this.btnEditInputInfo.Size = new System.Drawing.Size(75, 23);
            this.btnEditInputInfo.TabIndex = 2;
            this.btnEditInputInfo.Text = "編集";
            this.btnEditInputInfo.UseVisualStyleBackColor = true;
            // 
            // groupAddButton
            // 
            this.groupAddButton.Controls.Add(this.btnList);
            this.groupAddButton.Controls.Add(this.btnInteger);
            this.groupAddButton.Location = new System.Drawing.Point(5, 3);
            this.groupAddButton.Name = "groupAddButton";
            this.groupAddButton.Size = new System.Drawing.Size(269, 132);
            this.groupAddButton.TabIndex = 1;
            this.groupAddButton.TabStop = false;
            this.groupAddButton.Text = "入力情報を追加";
            // 
            // btnInteger
            // 
            this.btnInteger.Location = new System.Drawing.Point(6, 18);
            this.btnInteger.Name = "btnInteger";
            this.btnInteger.Size = new System.Drawing.Size(75, 23);
            this.btnInteger.TabIndex = 0;
            this.btnInteger.Text = "整数";
            this.btnInteger.UseVisualStyleBackColor = true;
            this.btnInteger.Click += new System.EventHandler(this.btnInteger_Click);
            // 
            // txtOutput
            // 
            this.txtOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtOutput.Location = new System.Drawing.Point(0, 0);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.Size = new System.Drawing.Size(328, 446);
            this.txtOutput.TabIndex = 0;
            // 
            // btnList
            // 
            this.btnList.Location = new System.Drawing.Point(87, 18);
            this.btnList.Name = "btnList";
            this.btnList.Size = new System.Drawing.Size(75, 23);
            this.btnList.TabIndex = 4;
            this.btnList.Text = "リスト";
            this.btnList.UseVisualStyleBackColor = true;
            this.btnList.Click += new System.EventHandler(this.btnList_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FormMain";
            this.Text = "Input Creator for Competitive Programming";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panelButton.ResumeLayout(false);
            this.groupAddButton.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.Panel panelButton;
        private System.Windows.Forms.GroupBox groupAddButton;
        private System.Windows.Forms.Button btnCreateInputData;
        private System.Windows.Forms.Button btnDeleteInputInfo;
        private System.Windows.Forms.Button btnEditInputInfo;
        private System.Windows.Forms.Button btnInteger;
        private System.Windows.Forms.ListBox listBoxInputInfo;
        private System.Windows.Forms.Button btnList;
    }
}

