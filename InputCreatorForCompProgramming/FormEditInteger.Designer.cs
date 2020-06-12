namespace InputCreatorForCompProgramming
{
    partial class FormEditInteger
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
            this.btnEnter = new System.Windows.Forms.Button();
            this.labelMin = new System.Windows.Forms.Label();
            this.txtMax = new System.Windows.Forms.TextBox();
            this.labelMax = new System.Windows.Forms.Label();
            this.groupDivisor = new System.Windows.Forms.GroupBox();
            this.txtDivisorCustom = new System.Windows.Forms.TextBox();
            this.rbDivisorSpace = new System.Windows.Forms.RadioButton();
            this.rbDivisorEmpty = new System.Windows.Forms.RadioButton();
            this.rbDivisorCustom = new System.Windows.Forms.RadioButton();
            this.rbDivisorNewLine = new System.Windows.Forms.RadioButton();
            this.txtMin = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.labelName = new System.Windows.Forms.Label();
            this.groupDivisor.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnEnter
            // 
            this.btnEnter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEnter.Location = new System.Drawing.Point(108, 210);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(75, 23);
            this.btnEnter.TabIndex = 5;
            this.btnEnter.Text = "追加";
            this.btnEnter.UseVisualStyleBackColor = true;
            this.btnEnter.Click += new System.EventHandler(this.btnEnter_Click);
            // 
            // labelMin
            // 
            this.labelMin.AutoSize = true;
            this.labelMin.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelMin.Location = new System.Drawing.Point(11, 37);
            this.labelMin.Name = "labelMin";
            this.labelMin.Size = new System.Drawing.Size(66, 19);
            this.labelMin.TabIndex = 0;
            this.labelMin.Text = "最小値";
            // 
            // txtMax
            // 
            this.txtMax.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMax.Location = new System.Drawing.Point(83, 66);
            this.txtMax.Name = "txtMax";
            this.txtMax.Size = new System.Drawing.Size(100, 19);
            this.txtMax.TabIndex = 3;
            // 
            // labelMax
            // 
            this.labelMax.AutoSize = true;
            this.labelMax.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelMax.Location = new System.Drawing.Point(11, 66);
            this.labelMax.Name = "labelMax";
            this.labelMax.Size = new System.Drawing.Size(66, 19);
            this.labelMax.TabIndex = 2;
            this.labelMax.Text = "最大値";
            // 
            // groupDivisor
            // 
            this.groupDivisor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupDivisor.Controls.Add(this.txtDivisorCustom);
            this.groupDivisor.Controls.Add(this.rbDivisorSpace);
            this.groupDivisor.Controls.Add(this.rbDivisorEmpty);
            this.groupDivisor.Controls.Add(this.rbDivisorCustom);
            this.groupDivisor.Controls.Add(this.rbDivisorNewLine);
            this.groupDivisor.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.groupDivisor.Location = new System.Drawing.Point(11, 91);
            this.groupDivisor.Name = "groupDivisor";
            this.groupDivisor.Size = new System.Drawing.Size(172, 113);
            this.groupDivisor.TabIndex = 4;
            this.groupDivisor.TabStop = false;
            this.groupDivisor.Text = "区切り文字";
            // 
            // txtDivisorCustom
            // 
            this.txtDivisorCustom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDivisorCustom.Enabled = false;
            this.txtDivisorCustom.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtDivisorCustom.Location = new System.Drawing.Point(6, 83);
            this.txtDivisorCustom.Name = "txtDivisorCustom";
            this.txtDivisorCustom.Size = new System.Drawing.Size(156, 19);
            this.txtDivisorCustom.TabIndex = 4;
            // 
            // rbDivisorSpace
            // 
            this.rbDivisorSpace.AutoSize = true;
            this.rbDivisorSpace.Location = new System.Drawing.Point(77, 25);
            this.rbDivisorSpace.Name = "rbDivisorSpace";
            this.rbDivisorSpace.Size = new System.Drawing.Size(89, 23);
            this.rbDivisorSpace.TabIndex = 1;
            this.rbDivisorSpace.Text = "スペース";
            this.rbDivisorSpace.UseVisualStyleBackColor = true;
            // 
            // rbDivisorEmpty
            // 
            this.rbDivisorEmpty.AutoSize = true;
            this.rbDivisorEmpty.Location = new System.Drawing.Point(6, 54);
            this.rbDivisorEmpty.Name = "rbDivisorEmpty";
            this.rbDivisorEmpty.Size = new System.Drawing.Size(60, 23);
            this.rbDivisorEmpty.TabIndex = 2;
            this.rbDivisorEmpty.Text = "無し";
            this.rbDivisorEmpty.UseVisualStyleBackColor = true;
            // 
            // rbDivisorCustom
            // 
            this.rbDivisorCustom.AutoSize = true;
            this.rbDivisorCustom.Location = new System.Drawing.Point(77, 54);
            this.rbDivisorCustom.Name = "rbDivisorCustom";
            this.rbDivisorCustom.Size = new System.Drawing.Size(85, 23);
            this.rbDivisorCustom.TabIndex = 3;
            this.rbDivisorCustom.Text = "カスタム";
            this.rbDivisorCustom.UseVisualStyleBackColor = true;
            this.rbDivisorCustom.CheckedChanged += new System.EventHandler(this.rbDivisorCustom_CheckedChanged);
            // 
            // rbDivisorNewLine
            // 
            this.rbDivisorNewLine.AutoSize = true;
            this.rbDivisorNewLine.Checked = true;
            this.rbDivisorNewLine.Location = new System.Drawing.Point(6, 25);
            this.rbDivisorNewLine.Name = "rbDivisorNewLine";
            this.rbDivisorNewLine.Size = new System.Drawing.Size(65, 23);
            this.rbDivisorNewLine.TabIndex = 0;
            this.rbDivisorNewLine.TabStop = true;
            this.rbDivisorNewLine.Text = "改行";
            this.rbDivisorNewLine.UseVisualStyleBackColor = true;
            // 
            // txtMin
            // 
            this.txtMin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMin.Location = new System.Drawing.Point(83, 37);
            this.txtMin.Name = "txtMin";
            this.txtMin.Size = new System.Drawing.Size(100, 19);
            this.txtMin.TabIndex = 1;
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(83, 12);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 19);
            this.txtName.TabIndex = 7;
            // 
            // labelName
            // 
            this.labelName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelName.Location = new System.Drawing.Point(11, 12);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(47, 19);
            this.labelName.TabIndex = 6;
            this.labelName.Text = "名前";
            // 
            // FormEditInteger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(195, 242);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.txtMin);
            this.Controls.Add(this.groupDivisor);
            this.Controls.Add(this.labelMax);
            this.Controls.Add(this.txtMax);
            this.Controls.Add(this.labelMin);
            this.Controls.Add(this.btnEnter);
            this.Name = "FormEditInteger";
            this.Text = "整数";
            this.groupDivisor.ResumeLayout(false);
            this.groupDivisor.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEnter;
        private System.Windows.Forms.Label labelMin;
        private System.Windows.Forms.TextBox txtMax;
        private System.Windows.Forms.Label labelMax;
        private System.Windows.Forms.GroupBox groupDivisor;
        private System.Windows.Forms.RadioButton rbDivisorEmpty;
        private System.Windows.Forms.RadioButton rbDivisorCustom;
        private System.Windows.Forms.RadioButton rbDivisorNewLine;
        private System.Windows.Forms.RadioButton rbDivisorSpace;
        private System.Windows.Forms.TextBox txtDivisorCustom;
        private System.Windows.Forms.TextBox txtMin;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label labelName;
    }
}