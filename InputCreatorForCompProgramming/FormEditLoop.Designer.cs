namespace InputCreatorForCompProgramming
{
    partial class FormEditLoop
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
            this.groupDivisorInter = new System.Windows.Forms.GroupBox();
            this.txtDivisorInterCustom = new System.Windows.Forms.TextBox();
            this.rbDivisorInterSpace = new System.Windows.Forms.RadioButton();
            this.rbDivisorInterEmpty = new System.Windows.Forms.RadioButton();
            this.rbDivisorInterCustom = new System.Windows.Forms.RadioButton();
            this.rbDivisorInterNewLine = new System.Windows.Forms.RadioButton();
            this.groupDivisorLast = new System.Windows.Forms.GroupBox();
            this.txtDivisorLastCustom = new System.Windows.Forms.TextBox();
            this.rbDivisorLastSpace = new System.Windows.Forms.RadioButton();
            this.rbDivisorLastEmpty = new System.Windows.Forms.RadioButton();
            this.rbDivisorLastCustom = new System.Windows.Forms.RadioButton();
            this.rbDivisorLastNewLine = new System.Windows.Forms.RadioButton();
            this.txtLoopMin = new System.Windows.Forms.TextBox();
            this.labelLoopMax = new System.Windows.Forms.Label();
            this.txtLoopMax = new System.Windows.Forms.TextBox();
            this.labelLoopMin = new System.Windows.Forms.Label();
            this.btnEnter = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.labelName = new System.Windows.Forms.Label();
            this.groupDivisorInter.SuspendLayout();
            this.groupDivisorLast.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupDivisorInter
            // 
            this.groupDivisorInter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupDivisorInter.Controls.Add(this.txtDivisorInterCustom);
            this.groupDivisorInter.Controls.Add(this.rbDivisorInterSpace);
            this.groupDivisorInter.Controls.Add(this.rbDivisorInterEmpty);
            this.groupDivisorInter.Controls.Add(this.rbDivisorInterCustom);
            this.groupDivisorInter.Controls.Add(this.rbDivisorInterNewLine);
            this.groupDivisorInter.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.groupDivisorInter.Location = new System.Drawing.Point(16, 134);
            this.groupDivisorInter.Name = "groupDivisorInter";
            this.groupDivisorInter.Size = new System.Drawing.Size(172, 113);
            this.groupDivisorInter.TabIndex = 6;
            this.groupDivisorInter.TabStop = false;
            this.groupDivisorInter.Text = "区切り文字(中間)";
            // 
            // txtDivisorInterCustom
            // 
            this.txtDivisorInterCustom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDivisorInterCustom.Enabled = false;
            this.txtDivisorInterCustom.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtDivisorInterCustom.Location = new System.Drawing.Point(6, 83);
            this.txtDivisorInterCustom.Name = "txtDivisorInterCustom";
            this.txtDivisorInterCustom.Size = new System.Drawing.Size(156, 19);
            this.txtDivisorInterCustom.TabIndex = 4;
            this.txtDivisorInterCustom.Enter += new System.EventHandler(this.textBox_Enter);
            // 
            // rbDivisorInterSpace
            // 
            this.rbDivisorInterSpace.AutoSize = true;
            this.rbDivisorInterSpace.Location = new System.Drawing.Point(77, 25);
            this.rbDivisorInterSpace.Name = "rbDivisorInterSpace";
            this.rbDivisorInterSpace.Size = new System.Drawing.Size(89, 23);
            this.rbDivisorInterSpace.TabIndex = 1;
            this.rbDivisorInterSpace.Text = "スペース";
            this.rbDivisorInterSpace.UseVisualStyleBackColor = true;
            // 
            // rbDivisorInterEmpty
            // 
            this.rbDivisorInterEmpty.AutoSize = true;
            this.rbDivisorInterEmpty.Location = new System.Drawing.Point(6, 54);
            this.rbDivisorInterEmpty.Name = "rbDivisorInterEmpty";
            this.rbDivisorInterEmpty.Size = new System.Drawing.Size(60, 23);
            this.rbDivisorInterEmpty.TabIndex = 2;
            this.rbDivisorInterEmpty.Text = "無し";
            this.rbDivisorInterEmpty.UseVisualStyleBackColor = true;
            // 
            // rbDivisorInterCustom
            // 
            this.rbDivisorInterCustom.AutoSize = true;
            this.rbDivisorInterCustom.Location = new System.Drawing.Point(77, 54);
            this.rbDivisorInterCustom.Name = "rbDivisorInterCustom";
            this.rbDivisorInterCustom.Size = new System.Drawing.Size(85, 23);
            this.rbDivisorInterCustom.TabIndex = 3;
            this.rbDivisorInterCustom.Text = "カスタム";
            this.rbDivisorInterCustom.UseVisualStyleBackColor = true;
            this.rbDivisorInterCustom.CheckedChanged += new System.EventHandler(this.rbDivisorInterCustom_CheckedChanged);
            // 
            // rbDivisorInterNewLine
            // 
            this.rbDivisorInterNewLine.AutoSize = true;
            this.rbDivisorInterNewLine.Checked = true;
            this.rbDivisorInterNewLine.Location = new System.Drawing.Point(6, 25);
            this.rbDivisorInterNewLine.Name = "rbDivisorInterNewLine";
            this.rbDivisorInterNewLine.Size = new System.Drawing.Size(65, 23);
            this.rbDivisorInterNewLine.TabIndex = 0;
            this.rbDivisorInterNewLine.TabStop = true;
            this.rbDivisorInterNewLine.Text = "改行";
            this.rbDivisorInterNewLine.UseVisualStyleBackColor = true;
            // 
            // groupDivisorLast
            // 
            this.groupDivisorLast.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupDivisorLast.Controls.Add(this.txtDivisorLastCustom);
            this.groupDivisorLast.Controls.Add(this.rbDivisorLastSpace);
            this.groupDivisorLast.Controls.Add(this.rbDivisorLastEmpty);
            this.groupDivisorLast.Controls.Add(this.rbDivisorLastCustom);
            this.groupDivisorLast.Controls.Add(this.rbDivisorLastNewLine);
            this.groupDivisorLast.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.groupDivisorLast.Location = new System.Drawing.Point(16, 253);
            this.groupDivisorLast.Name = "groupDivisorLast";
            this.groupDivisorLast.Size = new System.Drawing.Size(172, 113);
            this.groupDivisorLast.TabIndex = 7;
            this.groupDivisorLast.TabStop = false;
            this.groupDivisorLast.Text = "区切り文字(最後)";
            // 
            // txtDivisorLastCustom
            // 
            this.txtDivisorLastCustom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDivisorLastCustom.Enabled = false;
            this.txtDivisorLastCustom.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtDivisorLastCustom.Location = new System.Drawing.Point(6, 83);
            this.txtDivisorLastCustom.Name = "txtDivisorLastCustom";
            this.txtDivisorLastCustom.Size = new System.Drawing.Size(156, 19);
            this.txtDivisorLastCustom.TabIndex = 4;
            this.txtDivisorLastCustom.Enter += new System.EventHandler(this.textBox_Enter);
            // 
            // rbDivisorLastSpace
            // 
            this.rbDivisorLastSpace.AutoSize = true;
            this.rbDivisorLastSpace.Location = new System.Drawing.Point(77, 25);
            this.rbDivisorLastSpace.Name = "rbDivisorLastSpace";
            this.rbDivisorLastSpace.Size = new System.Drawing.Size(89, 23);
            this.rbDivisorLastSpace.TabIndex = 1;
            this.rbDivisorLastSpace.Text = "スペース";
            this.rbDivisorLastSpace.UseVisualStyleBackColor = true;
            // 
            // rbDivisorLastEmpty
            // 
            this.rbDivisorLastEmpty.AutoSize = true;
            this.rbDivisorLastEmpty.Location = new System.Drawing.Point(6, 54);
            this.rbDivisorLastEmpty.Name = "rbDivisorLastEmpty";
            this.rbDivisorLastEmpty.Size = new System.Drawing.Size(60, 23);
            this.rbDivisorLastEmpty.TabIndex = 2;
            this.rbDivisorLastEmpty.Text = "無し";
            this.rbDivisorLastEmpty.UseVisualStyleBackColor = true;
            // 
            // rbDivisorLastCustom
            // 
            this.rbDivisorLastCustom.AutoSize = true;
            this.rbDivisorLastCustom.Location = new System.Drawing.Point(77, 54);
            this.rbDivisorLastCustom.Name = "rbDivisorLastCustom";
            this.rbDivisorLastCustom.Size = new System.Drawing.Size(85, 23);
            this.rbDivisorLastCustom.TabIndex = 3;
            this.rbDivisorLastCustom.Text = "カスタム";
            this.rbDivisorLastCustom.UseVisualStyleBackColor = true;
            this.rbDivisorLastCustom.CheckedChanged += new System.EventHandler(this.rbDivisorLastCustom_CheckedChanged);
            // 
            // rbDivisorLastNewLine
            // 
            this.rbDivisorLastNewLine.AutoSize = true;
            this.rbDivisorLastNewLine.Checked = true;
            this.rbDivisorLastNewLine.Location = new System.Drawing.Point(6, 25);
            this.rbDivisorLastNewLine.Name = "rbDivisorLastNewLine";
            this.rbDivisorLastNewLine.Size = new System.Drawing.Size(65, 23);
            this.rbDivisorLastNewLine.TabIndex = 0;
            this.rbDivisorLastNewLine.TabStop = true;
            this.rbDivisorLastNewLine.Text = "改行";
            this.rbDivisorLastNewLine.UseVisualStyleBackColor = true;
            // 
            // txtLoopMin
            // 
            this.txtLoopMin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLoopMin.Location = new System.Drawing.Point(16, 65);
            this.txtLoopMin.Name = "txtLoopMin";
            this.txtLoopMin.Size = new System.Drawing.Size(168, 19);
            this.txtLoopMin.TabIndex = 3;
            this.txtLoopMin.Enter += new System.EventHandler(this.textBox_Enter);
            // 
            // labelLoopMax
            // 
            this.labelLoopMax.AutoSize = true;
            this.labelLoopMax.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelLoopMax.Location = new System.Drawing.Point(12, 87);
            this.labelLoopMax.Name = "labelLoopMax";
            this.labelLoopMax.Size = new System.Drawing.Size(112, 19);
            this.labelLoopMax.TabIndex = 4;
            this.labelLoopMax.Text = "ループ最大値";
            // 
            // txtLoopMax
            // 
            this.txtLoopMax.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLoopMax.Location = new System.Drawing.Point(16, 109);
            this.txtLoopMax.Name = "txtLoopMax";
            this.txtLoopMax.Size = new System.Drawing.Size(168, 19);
            this.txtLoopMax.TabIndex = 5;
            this.txtLoopMax.Enter += new System.EventHandler(this.textBox_Enter);
            // 
            // labelLoopMin
            // 
            this.labelLoopMin.AutoSize = true;
            this.labelLoopMin.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelLoopMin.Location = new System.Drawing.Point(12, 43);
            this.labelLoopMin.Name = "labelLoopMin";
            this.labelLoopMin.Size = new System.Drawing.Size(112, 19);
            this.labelLoopMin.TabIndex = 2;
            this.labelLoopMin.Text = "ループ最小値";
            // 
            // btnEnter
            // 
            this.btnEnter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEnter.Location = new System.Drawing.Point(113, 372);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(75, 23);
            this.btnEnter.TabIndex = 8;
            this.btnEnter.Text = "追加";
            this.btnEnter.UseVisualStyleBackColor = true;
            this.btnEnter.Click += new System.EventHandler(this.btnEnter_Click);
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(88, 12);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 19);
            this.txtName.TabIndex = 1;
            this.txtName.Enter += new System.EventHandler(this.textBox_Enter);
            // 
            // labelName
            // 
            this.labelName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelName.Location = new System.Drawing.Point(16, 12);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(47, 19);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "名前";
            // 
            // FormEditLoop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(200, 404);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.btnEnter);
            this.Controls.Add(this.txtLoopMin);
            this.Controls.Add(this.labelLoopMax);
            this.Controls.Add(this.txtLoopMax);
            this.Controls.Add(this.labelLoopMin);
            this.Controls.Add(this.groupDivisorLast);
            this.Controls.Add(this.groupDivisorInter);
            this.Name = "FormEditLoop";
            this.Text = "ループ";
            this.Load += new System.EventHandler(this.FormEditLoop_Load);
            this.groupDivisorInter.ResumeLayout(false);
            this.groupDivisorInter.PerformLayout();
            this.groupDivisorLast.ResumeLayout(false);
            this.groupDivisorLast.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupDivisorInter;
        private System.Windows.Forms.TextBox txtDivisorInterCustom;
        private System.Windows.Forms.RadioButton rbDivisorInterSpace;
        private System.Windows.Forms.RadioButton rbDivisorInterEmpty;
        private System.Windows.Forms.RadioButton rbDivisorInterCustom;
        private System.Windows.Forms.RadioButton rbDivisorInterNewLine;
        private System.Windows.Forms.GroupBox groupDivisorLast;
        private System.Windows.Forms.TextBox txtDivisorLastCustom;
        private System.Windows.Forms.RadioButton rbDivisorLastSpace;
        private System.Windows.Forms.RadioButton rbDivisorLastEmpty;
        private System.Windows.Forms.RadioButton rbDivisorLastCustom;
        private System.Windows.Forms.RadioButton rbDivisorLastNewLine;
        private System.Windows.Forms.TextBox txtLoopMin;
        private System.Windows.Forms.Label labelLoopMax;
        private System.Windows.Forms.TextBox txtLoopMax;
        private System.Windows.Forms.Label labelLoopMin;
        private System.Windows.Forms.Button btnEnter;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label labelName;
    }
}