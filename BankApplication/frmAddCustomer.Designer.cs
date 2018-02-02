namespace BankApplication
{
    partial class frmAddCustomer
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtCustId = new System.Windows.Forms.TextBox();
            this.btnResetCustDetails = new System.Windows.Forms.Button();
            this.btnAddCustomer = new System.Windows.Forms.Button();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtDOB = new System.Windows.Forms.TextBox();
            this.txtAccNumber = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblAccountNumber = new System.Windows.Forms.Label();
            this.lblDOB = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCustName = new System.Windows.Forms.TextBox();
            this.lblCustomerID = new System.Windows.Forms.Label();
            this.chkIsMarried = new System.Windows.Forms.CheckBox();
            this.lblValidationMessage = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42.68775F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 57.31225F));
            this.tableLayoutPanel1.Controls.Add(this.txtCustId, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.btnResetCustDetails, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.btnAddCustomer, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.txtEmail, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtDOB, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtAccNumber, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblAccountNumber, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblDOB, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtCustName, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblCustomerID, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.chkIsMarried, 1, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 25);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(319, 199);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // txtCustId
            // 
            this.txtCustId.Location = new System.Drawing.Point(139, 128);
            this.txtCustId.Name = "txtCustId";
            this.txtCustId.Size = new System.Drawing.Size(166, 20);
            this.txtCustId.TabIndex = 16;
            // 
            // btnResetCustDetails
            // 
            this.btnResetCustDetails.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnResetCustDetails.Location = new System.Drawing.Point(190, 159);
            this.btnResetCustDetails.Name = "btnResetCustDetails";
            this.btnResetCustDetails.Size = new System.Drawing.Size(75, 31);
            this.btnResetCustDetails.TabIndex = 14;
            this.btnResetCustDetails.Text = "Reset";
            this.btnResetCustDetails.UseVisualStyleBackColor = true;
            // 
            // btnAddCustomer
            // 
            this.btnAddCustomer.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAddCustomer.Location = new System.Drawing.Point(30, 161);
            this.btnAddCustomer.Name = "btnAddCustomer";
            this.btnAddCustomer.Size = new System.Drawing.Size(75, 27);
            this.btnAddCustomer.TabIndex = 13;
            this.btnAddCustomer.Text = "Add";
            this.btnAddCustomer.UseVisualStyleBackColor = true;
            this.btnAddCustomer.Click += new System.EventHandler(this.btnAddCustomer_Click);
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(139, 104);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(166, 20);
            this.txtEmail.TabIndex = 12;
            // 
            // txtDOB
            // 
            this.txtDOB.Location = new System.Drawing.Point(139, 53);
            this.txtDOB.Name = "txtDOB";
            this.txtDOB.Size = new System.Drawing.Size(166, 20);
            this.txtDOB.TabIndex = 10;
            // 
            // txtAccNumber
            // 
            this.txtAccNumber.Location = new System.Drawing.Point(139, 28);
            this.txtAccNumber.Name = "txtAccNumber";
            this.txtAccNumber.Size = new System.Drawing.Size(166, 20);
            this.txtAccNumber.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // lblAccountNumber
            // 
            this.lblAccountNumber.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblAccountNumber.AutoSize = true;
            this.lblAccountNumber.Location = new System.Drawing.Point(24, 31);
            this.lblAccountNumber.Name = "lblAccountNumber";
            this.lblAccountNumber.Size = new System.Drawing.Size(87, 13);
            this.lblAccountNumber.TabIndex = 1;
            this.lblAccountNumber.Text = "Account Number";
            // 
            // lblDOB
            // 
            this.lblDOB.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblDOB.AutoSize = true;
            this.lblDOB.Location = new System.Drawing.Point(53, 56);
            this.lblDOB.Name = "lblDOB";
            this.lblDOB.Size = new System.Drawing.Size(30, 13);
            this.lblDOB.TabIndex = 2;
            this.lblDOB.Text = "DOB";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Is Married";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "EmailAddress";
            // 
            // txtCustName
            // 
            this.txtCustName.Location = new System.Drawing.Point(139, 3);
            this.txtCustName.Name = "txtCustName";
            this.txtCustName.Size = new System.Drawing.Size(166, 20);
            this.txtCustName.TabIndex = 8;
            // 
            // lblCustomerID
            // 
            this.lblCustomerID.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCustomerID.AutoSize = true;
            this.lblCustomerID.Location = new System.Drawing.Point(37, 131);
            this.lblCustomerID.Name = "lblCustomerID";
            this.lblCustomerID.Size = new System.Drawing.Size(62, 13);
            this.lblCustomerID.TabIndex = 15;
            this.lblCustomerID.Text = "CustomerID";
            // 
            // chkIsMarried
            // 
            this.chkIsMarried.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkIsMarried.AutoSize = true;
            this.chkIsMarried.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkIsMarried.Location = new System.Drawing.Point(139, 81);
            this.chkIsMarried.Name = "chkIsMarried";
            this.chkIsMarried.Size = new System.Drawing.Size(15, 14);
            this.chkIsMarried.TabIndex = 17;
            this.chkIsMarried.UseVisualStyleBackColor = true;
            // 
            // lblValidationMessage
            // 
            this.lblValidationMessage.Location = new System.Drawing.Point(12, 6);
            this.lblValidationMessage.Name = "lblValidationMessage";
            this.lblValidationMessage.Size = new System.Drawing.Size(319, 19);
            this.lblValidationMessage.TabIndex = 1;
            this.lblValidationMessage.Visible = false;
            // 
            // frmAddCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 256);
            this.Controls.Add(this.lblValidationMessage);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmAddCustomer";
            this.Text = "frmAddCustomer";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblAccountNumber;
        private System.Windows.Forms.Label lblDOB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtDOB;
        private System.Windows.Forms.TextBox txtAccNumber;
        private System.Windows.Forms.TextBox txtCustName;
        private System.Windows.Forms.Button btnResetCustDetails;
        private System.Windows.Forms.Button btnAddCustomer;
        private System.Windows.Forms.Label lblCustomerID;
        private System.Windows.Forms.TextBox txtCustId;
        private System.Windows.Forms.CheckBox chkIsMarried;
        private System.Windows.Forms.Label lblValidationMessage;
    }
}