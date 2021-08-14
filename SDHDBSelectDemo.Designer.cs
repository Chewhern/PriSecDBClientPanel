
namespace PriSecDBClientPanel
{
    partial class SDHDBSelectDemo
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
            this.SelectRecordBTN = new System.Windows.Forms.Button();
            this.SampleJSONStringTB = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.SQLParameterValueB64TB = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.SQLParameterNameB64TB = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.SQLQueryStringB64TB = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.SQLParameterValueTB = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.SQLParameterNameTB = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.SQLQueryStringTB = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.RequestTypeTB = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.WebAPIURLTB = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.UniquePaymentIDTB = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SealedDBUserPasswordTB = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SealedDBUserNameTB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SealedDBNameTB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SealedSessionIDTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // SelectRecordBTN
            // 
            this.SelectRecordBTN.Location = new System.Drawing.Point(575, 481);
            this.SelectRecordBTN.Name = "SelectRecordBTN";
            this.SelectRecordBTN.Size = new System.Drawing.Size(263, 65);
            this.SelectRecordBTN.TabIndex = 57;
            this.SelectRecordBTN.Text = "Select DB Table Record";
            this.SelectRecordBTN.UseVisualStyleBackColor = true;
            this.SelectRecordBTN.Click += new System.EventHandler(this.SelectRecordBTN_Click);
            // 
            // SampleJSONStringTB
            // 
            this.SampleJSONStringTB.Location = new System.Drawing.Point(575, 368);
            this.SampleJSONStringTB.Multiline = true;
            this.SampleJSONStringTB.Name = "SampleJSONStringTB";
            this.SampleJSONStringTB.ReadOnly = true;
            this.SampleJSONStringTB.Size = new System.Drawing.Size(263, 83);
            this.SampleJSONStringTB.TabIndex = 56;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(571, 344);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(155, 20);
            this.label14.TabIndex = 55;
            this.label14.Text = "Sample JSON String";
            // 
            // SQLParameterValueB64TB
            // 
            this.SQLParameterValueB64TB.Location = new System.Drawing.Point(575, 251);
            this.SQLParameterValueB64TB.Multiline = true;
            this.SQLParameterValueB64TB.Name = "SQLParameterValueB64TB";
            this.SQLParameterValueB64TB.ReadOnly = true;
            this.SQLParameterValueB64TB.Size = new System.Drawing.Size(263, 83);
            this.SQLParameterValueB64TB.TabIndex = 54;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(571, 227);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(229, 20);
            this.label13.TabIndex = 53;
            this.label13.Text = "SQL Parameter Value(Base64)";
            // 
            // SQLParameterNameB64TB
            // 
            this.SQLParameterNameB64TB.Location = new System.Drawing.Point(575, 142);
            this.SQLParameterNameB64TB.Multiline = true;
            this.SQLParameterNameB64TB.Name = "SQLParameterNameB64TB";
            this.SQLParameterNameB64TB.ReadOnly = true;
            this.SQLParameterNameB64TB.Size = new System.Drawing.Size(263, 83);
            this.SQLParameterNameB64TB.TabIndex = 52;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(571, 118);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(230, 20);
            this.label12.TabIndex = 51;
            this.label12.Text = "SQL Parameter Name(Base64)";
            // 
            // SQLQueryStringB64TB
            // 
            this.SQLQueryStringB64TB.Location = new System.Drawing.Point(575, 33);
            this.SQLQueryStringB64TB.Multiline = true;
            this.SQLQueryStringB64TB.Name = "SQLQueryStringB64TB";
            this.SQLQueryStringB64TB.ReadOnly = true;
            this.SQLQueryStringB64TB.Size = new System.Drawing.Size(263, 83);
            this.SQLQueryStringB64TB.TabIndex = 50;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(571, 9);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(198, 20);
            this.label11.TabIndex = 49;
            this.label11.Text = "SQL Query String(Base64)";
            // 
            // SQLParameterValueTB
            // 
            this.SQLParameterValueTB.Location = new System.Drawing.Point(302, 481);
            this.SQLParameterValueTB.Multiline = true;
            this.SQLParameterValueTB.Name = "SQLParameterValueTB";
            this.SQLParameterValueTB.Size = new System.Drawing.Size(263, 83);
            this.SQLParameterValueTB.TabIndex = 48;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(298, 457);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(164, 20);
            this.label10.TabIndex = 47;
            this.label10.Text = "SQL Parameter Value";
            // 
            // SQLParameterNameTB
            // 
            this.SQLParameterNameTB.Location = new System.Drawing.Point(302, 368);
            this.SQLParameterNameTB.Multiline = true;
            this.SQLParameterNameTB.Name = "SQLParameterNameTB";
            this.SQLParameterNameTB.Size = new System.Drawing.Size(263, 83);
            this.SQLParameterNameTB.TabIndex = 46;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(298, 344);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(165, 20);
            this.label9.TabIndex = 45;
            this.label9.Text = "SQL Parameter Name";
            // 
            // SQLQueryStringTB
            // 
            this.SQLQueryStringTB.Location = new System.Drawing.Point(302, 251);
            this.SQLQueryStringTB.Multiline = true;
            this.SQLQueryStringTB.Name = "SQLQueryStringTB";
            this.SQLQueryStringTB.Size = new System.Drawing.Size(263, 83);
            this.SQLQueryStringTB.TabIndex = 44;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(298, 227);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(133, 20);
            this.label8.TabIndex = 43;
            this.label8.Text = "SQL Query String";
            // 
            // RequestTypeTB
            // 
            this.RequestTypeTB.Location = new System.Drawing.Point(302, 142);
            this.RequestTypeTB.Multiline = true;
            this.RequestTypeTB.Name = "RequestTypeTB";
            this.RequestTypeTB.ReadOnly = true;
            this.RequestTypeTB.Size = new System.Drawing.Size(263, 83);
            this.RequestTypeTB.TabIndex = 42;
            this.RequestTypeTB.Text = "POST";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(298, 118);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(108, 20);
            this.label7.TabIndex = 41;
            this.label7.Text = "Request Type";
            // 
            // WebAPIURLTB
            // 
            this.WebAPIURLTB.Location = new System.Drawing.Point(302, 33);
            this.WebAPIURLTB.Multiline = true;
            this.WebAPIURLTB.Name = "WebAPIURLTB";
            this.WebAPIURLTB.ReadOnly = true;
            this.WebAPIURLTB.Size = new System.Drawing.Size(263, 83);
            this.WebAPIURLTB.TabIndex = 40;
            this.WebAPIURLTB.Text = "https://mrchewitsoftware.com.my:5002/api/SelectDBRecord/";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(298, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 20);
            this.label6.TabIndex = 39;
            this.label6.Text = "Web API URL";
            // 
            // UniquePaymentIDTB
            // 
            this.UniquePaymentIDTB.Location = new System.Drawing.Point(16, 142);
            this.UniquePaymentIDTB.Multiline = true;
            this.UniquePaymentIDTB.Name = "UniquePaymentIDTB";
            this.UniquePaymentIDTB.ReadOnly = true;
            this.UniquePaymentIDTB.Size = new System.Drawing.Size(263, 83);
            this.UniquePaymentIDTB.TabIndex = 38;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 119);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(147, 20);
            this.label5.TabIndex = 37;
            this.label5.Text = "Unique Payment ID";
            // 
            // SealedDBUserPasswordTB
            // 
            this.SealedDBUserPasswordTB.Location = new System.Drawing.Point(16, 481);
            this.SealedDBUserPasswordTB.Multiline = true;
            this.SealedDBUserPasswordTB.Name = "SealedDBUserPasswordTB";
            this.SealedDBUserPasswordTB.ReadOnly = true;
            this.SealedDBUserPasswordTB.Size = new System.Drawing.Size(263, 83);
            this.SealedDBUserPasswordTB.TabIndex = 36;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 458);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(197, 20);
            this.label4.TabIndex = 35;
            this.label4.Text = "Sealed DB User Password";
            // 
            // SealedDBUserNameTB
            // 
            this.SealedDBUserNameTB.Location = new System.Drawing.Point(16, 368);
            this.SealedDBUserNameTB.Multiline = true;
            this.SealedDBUserNameTB.Name = "SealedDBUserNameTB";
            this.SealedDBUserNameTB.ReadOnly = true;
            this.SealedDBUserNameTB.Size = new System.Drawing.Size(263, 83);
            this.SealedDBUserNameTB.TabIndex = 34;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 345);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(170, 20);
            this.label3.TabIndex = 33;
            this.label3.Text = "Sealed DB User Name";
            // 
            // SealedDBNameTB
            // 
            this.SealedDBNameTB.Location = new System.Drawing.Point(16, 251);
            this.SealedDBNameTB.Multiline = true;
            this.SealedDBNameTB.Name = "SealedDBNameTB";
            this.SealedDBNameTB.ReadOnly = true;
            this.SealedDBNameTB.Size = new System.Drawing.Size(263, 83);
            this.SealedDBNameTB.TabIndex = 32;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 228);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 20);
            this.label2.TabIndex = 31;
            this.label2.Text = "Sealed DB Name";
            // 
            // SealedSessionIDTB
            // 
            this.SealedSessionIDTB.Location = new System.Drawing.Point(16, 33);
            this.SealedSessionIDTB.Multiline = true;
            this.SealedSessionIDTB.Name = "SealedSessionIDTB";
            this.SealedSessionIDTB.ReadOnly = true;
            this.SealedSessionIDTB.Size = new System.Drawing.Size(263, 83);
            this.SealedSessionIDTB.TabIndex = 30;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 20);
            this.label1.TabIndex = 29;
            this.label1.Text = "Sealed Session ID";
            // 
            // SDHDBSelectDemo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 619);
            this.Controls.Add(this.SelectRecordBTN);
            this.Controls.Add(this.SampleJSONStringTB);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.SQLParameterValueB64TB);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.SQLParameterNameB64TB);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.SQLQueryStringB64TB);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.SQLParameterValueTB);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.SQLParameterNameTB);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.SQLQueryStringTB);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.RequestTypeTB);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.WebAPIURLTB);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.UniquePaymentIDTB);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.SealedDBUserPasswordTB);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.SealedDBUserNameTB);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.SealedDBNameTB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SealedSessionIDTB);
            this.Controls.Add(this.label1);
            this.Name = "SDHDBSelectDemo";
            this.Text = "SDHDBSelectDemo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SelectRecordBTN;
        private System.Windows.Forms.TextBox SampleJSONStringTB;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox SQLParameterValueB64TB;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox SQLParameterNameB64TB;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox SQLQueryStringB64TB;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox SQLParameterValueTB;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox SQLParameterNameTB;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox SQLQueryStringTB;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox RequestTypeTB;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox WebAPIURLTB;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox UniquePaymentIDTB;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox SealedDBUserPasswordTB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox SealedDBUserNameTB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox SealedDBNameTB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox SealedSessionIDTB;
        private System.Windows.Forms.Label label1;
    }
}