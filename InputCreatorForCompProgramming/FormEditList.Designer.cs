namespace InputCreatorForCompProgramming
{
    partial class FormEditList
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
            this.groupDivisor = new System.Windows.Forms.GroupBox();
            this.txtDivisorCustom = new System.Windows.Forms.TextBox();
            this.rbDivisorSpace = new System.Windows.Forms.RadioButton();
            this.rbDivisorEmpty = new System.Windows.Forms.RadioButton();
            this.rbDivisorCustom = new System.Windows.Forms.RadioButton();
            this.rbDivisorNewLine = new System.Windows.Forms.RadioButton();
            this.btnEnter = new System.Windows.Forms.Button();
            this.listBoxMain = new System.Windows.Forms.ListBox();
            this.btnItemAdd = new System.Windows.Forms.Button();
            this.txtItem = new System.Windows.Forms.TextBox();
            this.btnItemDelete = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.labelName = new System.Windows.Forms.Label();
            this.groupDivisor.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupDivisor
            // 
            this.groupDivisor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupDivisor.Controls.Add(this.txtDivisorCustom);
            this.groupDivisor.Controls.Add(this.rbDivisorSpace);
            this.groupDivisor.Controls.Add(this.rbDivisorEmpty);
            this.groupDivisor.Controls.Add(this.rbDivisorCustom);
            this.groupDivisor.Controls.Add(this.rbDivisorNewLine);
            this.groupDivisor.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.groupDivisor.Location = new System.Drawing.Point(12, 201);
            this.groupDivisor.Name = "groupDivisor";
            this.groupDivisor.Size = new System.Drawing.Size(172, 113);
            this.groupDivisor.TabIndex = 5;
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
            this.rbDivisorSpace.CheckedChanged += new System.EventHandler(this.rbDivisorCustom_CheckedChanged);
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
            this.rbDivisorEmpty.CheckedChanged += new System.EventHandler(this.rbDivisorCustom_CheckedChanged);
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
            this.rbDivisorNewLine.CheckedChanged += new System.EventHandler(this.rbDivisorCustom_CheckedChanged);
            // 
            // btnEnter
            // 
            this.btnEnter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEnter.Location = new System.Drawing.Point(109, 320);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(75, 23);
            this.btnEnter.TabIndex = 6;
            this.btnEnter.Text = "追加";
            this.btnEnter.UseVisualStyleBackColor = true;
            this.btnEnter.Click += new System.EventHandler(this.btnEnter_Click);
            // 
            // listBoxMain
            // 
            this.listBoxMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxMain.FormattingEnabled = true;
            this.listBoxMain.ItemHeight = 12;
            this.listBoxMain.Location = new System.Drawing.Point(12, 37);
            this.listBoxMain.Name = "listBoxMain";
            this.listBoxMain.ScrollAlwaysVisible = true;
            this.listBoxMain.Size = new System.Drawing.Size(172, 100);
            this.listBoxMain.TabIndex = 7;
            // 
            // btnItemAdd
            // 
            this.btnItemAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnItemAdd.Location = new System.Drawing.Point(12, 172);
            this.btnItemAdd.Name = "btnItemAdd";
            this.btnItemAdd.Size = new System.Drawing.Size(75, 23);
            this.btnItemAdd.TabIndex = 8;
            this.btnItemAdd.Text = "項目追加";
            this.btnItemAdd.UseVisualStyleBackColor = true;
            this.btnItemAdd.Click += new System.EventHandler(this.btnItemAdd_Click);
            // 
            // txtItem
            // 
            this.txtItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtItem.Location = new System.Drawing.Point(12, 147);
            this.txtItem.Name = "txtItem";
            this.txtItem.Size = new System.Drawing.Size(172, 19);
            this.txtItem.TabIndex = 9;
            // 
            // btnItemDelete
            // 
            this.btnItemDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnItemDelete.Location = new System.Drawing.Point(109, 172);
            this.btnItemDelete.Name = "btnItemDelete";
            this.btnItemDelete.Size = new System.Drawing.Size(75, 23);
            this.btnItemDelete.TabIndex = 10;
            this.btnItemDelete.Text = "項目削除";
            this.btnItemDelete.UseVisualStyleBackColor = true;
            this.btnItemDelete.Click += new System.EventHandler(this.btnItemDelete_Click);
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(84, 12);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 19);
            this.txtName.TabIndex = 12;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelName.Location = new System.Drawing.Point(12, 12);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(47, 19);
            this.labelName.TabIndex = 11;
            this.labelName.Text = "名前";
            // 
            // FormEditList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(196, 357);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.btnItemDelete);
            this.Controls.Add(this.txtItem);
            this.Controls.Add(this.btnItemAdd);
            this.Controls.Add(this.listBoxMain);
            this.Controls.Add(this.btnEnter);
            this.Controls.Add(this.groupDivisor);
            this.Name = "FormEditList";
            this.Text = "リスト";
            this.Load += new System.EventHandler(this.FormEditList_Load);
            this.groupDivisor.ResumeLayout(false);
            this.groupDivisor.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupDivisor;
        private System.Windows.Forms.TextBox txtDivisorCustom;
        private System.Windows.Forms.RadioButton rbDivisorSpace;
        private System.Windows.Forms.RadioButton rbDivisorEmpty;
        private System.Windows.Forms.RadioButton rbDivisorCustom;
        private System.Windows.Forms.RadioButton rbDivisorNewLine;
        private System.Windows.Forms.Button btnEnter;
        private System.Windows.Forms.ListBox listBoxMain;
        private System.Windows.Forms.Button btnItemAdd;
        private System.Windows.Forms.TextBox txtItem;
        private System.Windows.Forms.Button btnItemDelete;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label labelName;
    }
}