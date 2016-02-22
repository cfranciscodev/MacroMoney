namespace MacroMoney.QuickUI
{
    partial class AccountInfo
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
            this.txtAccountType = new System.Windows.Forms.TextBox();
            this.txtAccountName = new System.Windows.Forms.TextBox();
            this.txtStartingBalance = new System.Windows.Forms.TextBox();
            this.lblAccountType = new System.Windows.Forms.Label();
            this.lblAccountName = new System.Windows.Forms.Label();
            this.lblStartingBalance = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtAccountType
            // 
            this.txtAccountType.Location = new System.Drawing.Point(102, 12);
            this.txtAccountType.Name = "txtAccountType";
            this.txtAccountType.Size = new System.Drawing.Size(146, 20);
            this.txtAccountType.TabIndex = 0;
            // 
            // txtAccountName
            // 
            this.txtAccountName.Location = new System.Drawing.Point(102, 39);
            this.txtAccountName.Name = "txtAccountName";
            this.txtAccountName.Size = new System.Drawing.Size(146, 20);
            this.txtAccountName.TabIndex = 1;
            // 
            // txtStartingBalance
            // 
            this.txtStartingBalance.Location = new System.Drawing.Point(102, 66);
            this.txtStartingBalance.Name = "txtStartingBalance";
            this.txtStartingBalance.Size = new System.Drawing.Size(146, 20);
            this.txtStartingBalance.TabIndex = 2;
            // 
            // lblAccountType
            // 
            this.lblAccountType.AutoSize = true;
            this.lblAccountType.Location = new System.Drawing.Point(22, 15);
            this.lblAccountType.Name = "lblAccountType";
            this.lblAccountType.Size = new System.Drawing.Size(74, 13);
            this.lblAccountType.TabIndex = 3;
            this.lblAccountType.Text = "Account Type";
            // 
            // lblAccountName
            // 
            this.lblAccountName.AutoSize = true;
            this.lblAccountName.Location = new System.Drawing.Point(18, 42);
            this.lblAccountName.Name = "lblAccountName";
            this.lblAccountName.Size = new System.Drawing.Size(78, 13);
            this.lblAccountName.TabIndex = 4;
            this.lblAccountName.Text = "Account Name";
            // 
            // lblStartingBalance
            // 
            this.lblStartingBalance.AutoSize = true;
            this.lblStartingBalance.Location = new System.Drawing.Point(11, 69);
            this.lblStartingBalance.Name = "lblStartingBalance";
            this.lblStartingBalance.Size = new System.Drawing.Size(85, 13);
            this.lblStartingBalance.TabIndex = 5;
            this.lblStartingBalance.Text = "Starting Balance";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(302, 12);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(302, 41);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // AccountInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 117);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblStartingBalance);
            this.Controls.Add(this.lblAccountName);
            this.Controls.Add(this.lblAccountType);
            this.Controls.Add(this.txtStartingBalance);
            this.Controls.Add(this.txtAccountName);
            this.Controls.Add(this.txtAccountType);
            this.Name = "AccountInfo";
            this.Text = "Account";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtAccountType;
        private System.Windows.Forms.TextBox txtAccountName;
        private System.Windows.Forms.TextBox txtStartingBalance;
        private System.Windows.Forms.Label lblAccountType;
        private System.Windows.Forms.Label lblAccountName;
        private System.Windows.Forms.Label lblStartingBalance;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}