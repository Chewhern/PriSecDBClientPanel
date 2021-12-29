
namespace PriSecDBClientPanel
{
    partial class DBInsertDemo
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
            this.InsertRecordBTN = new System.Windows.Forms.Button();
            this.SampleJSONStringTB = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.SQLParameterValueArrayTB = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.SQLParameterNameArrayTB = new System.Windows.Forms.TextBox();
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
            this.EncryptionTypeGB = new System.Windows.Forms.GroupBox();
            this.SealedX3DiffieHellmanRB = new System.Windows.Forms.RadioButton();
            this.SealedDiffieHellmanRB = new System.Windows.Forms.RadioButton();
            this.SymmetricEncryptionAlgorithmGB = new System.Windows.Forms.GroupBox();
            this.XChaCha20Poly1305RB = new System.Windows.Forms.RadioButton();
            this.XSalsa20Poly1305RB = new System.Windows.Forms.RadioButton();
            this.label11 = new System.Windows.Forms.Label();
            this.IsPrimaryKeyTableCB = new System.Windows.Forms.CheckBox();
            this.ForeignKeyValueTB = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.SuccessResponseTB = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.EncryptionTypeGB.SuspendLayout();
            this.SymmetricEncryptionAlgorithmGB.SuspendLayout();
            this.SuspendLayout();
            // 
            // InsertRecordBTN
            // 
            this.InsertRecordBTN.Location = new System.Drawing.Point(941, 179);
            this.InsertRecordBTN.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.InsertRecordBTN.Name = "InsertRecordBTN";
            this.InsertRecordBTN.Size = new System.Drawing.Size(292, 81);
            this.InsertRecordBTN.TabIndex = 57;
            this.InsertRecordBTN.Text = "Insert DB Table Record";
            this.InsertRecordBTN.UseVisualStyleBackColor = true;
            this.InsertRecordBTN.Click += new System.EventHandler(this.InsertRecordBTN_Click);
            // 
            // SampleJSONStringTB
            // 
            this.SampleJSONStringTB.Location = new System.Drawing.Point(634, 602);
            this.SampleJSONStringTB.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SampleJSONStringTB.Multiline = true;
            this.SampleJSONStringTB.Name = "SampleJSONStringTB";
            this.SampleJSONStringTB.ReadOnly = true;
            this.SampleJSONStringTB.Size = new System.Drawing.Size(292, 103);
            this.SampleJSONStringTB.TabIndex = 56;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(630, 572);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(170, 25);
            this.label14.TabIndex = 55;
            this.label14.Text = "Sample JSON String";
            // 
            // SQLParameterValueArrayTB
            // 
            this.SQLParameterValueArrayTB.Location = new System.Drawing.Point(331, 602);
            this.SQLParameterValueArrayTB.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SQLParameterValueArrayTB.Multiline = true;
            this.SQLParameterValueArrayTB.Name = "SQLParameterValueArrayTB";
            this.SQLParameterValueArrayTB.Size = new System.Drawing.Size(292, 103);
            this.SQLParameterValueArrayTB.TabIndex = 48;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(327, 572);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(183, 25);
            this.label10.TabIndex = 47;
            this.label10.Text = "SQL Parameter Values";
            // 
            // SQLParameterNameArrayTB
            // 
            this.SQLParameterNameArrayTB.Location = new System.Drawing.Point(331, 461);
            this.SQLParameterNameArrayTB.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SQLParameterNameArrayTB.Multiline = true;
            this.SQLParameterNameArrayTB.Name = "SQLParameterNameArrayTB";
            this.SQLParameterNameArrayTB.Size = new System.Drawing.Size(292, 103);
            this.SQLParameterNameArrayTB.TabIndex = 46;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(327, 431);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(188, 25);
            this.label9.TabIndex = 45;
            this.label9.Text = "SQL Parameter Names";
            // 
            // SQLQueryStringTB
            // 
            this.SQLQueryStringTB.Location = new System.Drawing.Point(331, 315);
            this.SQLQueryStringTB.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SQLQueryStringTB.Multiline = true;
            this.SQLQueryStringTB.Name = "SQLQueryStringTB";
            this.SQLQueryStringTB.Size = new System.Drawing.Size(292, 103);
            this.SQLQueryStringTB.TabIndex = 44;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(327, 285);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(148, 25);
            this.label8.TabIndex = 43;
            this.label8.Text = "SQL Query String";
            // 
            // RequestTypeTB
            // 
            this.RequestTypeTB.Location = new System.Drawing.Point(331, 179);
            this.RequestTypeTB.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.RequestTypeTB.Multiline = true;
            this.RequestTypeTB.Name = "RequestTypeTB";
            this.RequestTypeTB.ReadOnly = true;
            this.RequestTypeTB.Size = new System.Drawing.Size(292, 103);
            this.RequestTypeTB.TabIndex = 42;
            this.RequestTypeTB.Text = "POST";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(327, 149);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(117, 25);
            this.label7.TabIndex = 41;
            this.label7.Text = "Request Type";
            // 
            // WebAPIURLTB
            // 
            this.WebAPIURLTB.Location = new System.Drawing.Point(331, 42);
            this.WebAPIURLTB.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.WebAPIURLTB.Multiline = true;
            this.WebAPIURLTB.Name = "WebAPIURLTB";
            this.WebAPIURLTB.ReadOnly = true;
            this.WebAPIURLTB.Size = new System.Drawing.Size(292, 103);
            this.WebAPIURLTB.TabIndex = 40;
            this.WebAPIURLTB.Text = "https://mrchewitsoftware.com.my:5002/NormalSealedDHDBInsert/";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(327, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(116, 25);
            this.label6.TabIndex = 39;
            this.label6.Text = "Web API URL";
            // 
            // UniquePaymentIDTB
            // 
            this.UniquePaymentIDTB.Location = new System.Drawing.Point(13, 179);
            this.UniquePaymentIDTB.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.UniquePaymentIDTB.Multiline = true;
            this.UniquePaymentIDTB.Name = "UniquePaymentIDTB";
            this.UniquePaymentIDTB.ReadOnly = true;
            this.UniquePaymentIDTB.Size = new System.Drawing.Size(292, 103);
            this.UniquePaymentIDTB.TabIndex = 38;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 150);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(164, 25);
            this.label5.TabIndex = 37;
            this.label5.Text = "Unique Payment ID";
            // 
            // SealedDBUserPasswordTB
            // 
            this.SealedDBUserPasswordTB.Location = new System.Drawing.Point(13, 602);
            this.SealedDBUserPasswordTB.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SealedDBUserPasswordTB.Multiline = true;
            this.SealedDBUserPasswordTB.Name = "SealedDBUserPasswordTB";
            this.SealedDBUserPasswordTB.ReadOnly = true;
            this.SealedDBUserPasswordTB.Size = new System.Drawing.Size(292, 103);
            this.SealedDBUserPasswordTB.TabIndex = 36;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 574);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(212, 25);
            this.label4.TabIndex = 35;
            this.label4.Text = "Sealed DB User Password";
            // 
            // SealedDBUserNameTB
            // 
            this.SealedDBUserNameTB.Location = new System.Drawing.Point(13, 461);
            this.SealedDBUserNameTB.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SealedDBUserNameTB.Multiline = true;
            this.SealedDBUserNameTB.Name = "SealedDBUserNameTB";
            this.SealedDBUserNameTB.ReadOnly = true;
            this.SealedDBUserNameTB.Size = new System.Drawing.Size(292, 103);
            this.SealedDBUserNameTB.TabIndex = 34;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 432);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(184, 25);
            this.label3.TabIndex = 33;
            this.label3.Text = "Sealed DB User Name";
            // 
            // SealedDBNameTB
            // 
            this.SealedDBNameTB.Location = new System.Drawing.Point(13, 315);
            this.SealedDBNameTB.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SealedDBNameTB.Multiline = true;
            this.SealedDBNameTB.Name = "SealedDBNameTB";
            this.SealedDBNameTB.ReadOnly = true;
            this.SealedDBNameTB.Size = new System.Drawing.Size(292, 103);
            this.SealedDBNameTB.TabIndex = 32;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 286);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 25);
            this.label2.TabIndex = 31;
            this.label2.Text = "Sealed DB Name";
            // 
            // SealedSessionIDTB
            // 
            this.SealedSessionIDTB.Location = new System.Drawing.Point(13, 42);
            this.SealedSessionIDTB.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SealedSessionIDTB.Multiline = true;
            this.SealedSessionIDTB.Name = "SealedSessionIDTB";
            this.SealedSessionIDTB.ReadOnly = true;
            this.SealedSessionIDTB.Size = new System.Drawing.Size(292, 103);
            this.SealedSessionIDTB.TabIndex = 30;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 25);
            this.label1.TabIndex = 29;
            this.label1.Text = "Sealed Session ID";
            // 
            // EncryptionTypeGB
            // 
            this.EncryptionTypeGB.Controls.Add(this.SealedX3DiffieHellmanRB);
            this.EncryptionTypeGB.Controls.Add(this.SealedDiffieHellmanRB);
            this.EncryptionTypeGB.Location = new System.Drawing.Point(634, 16);
            this.EncryptionTypeGB.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.EncryptionTypeGB.Name = "EncryptionTypeGB";
            this.EncryptionTypeGB.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.EncryptionTypeGB.Size = new System.Drawing.Size(292, 130);
            this.EncryptionTypeGB.TabIndex = 58;
            this.EncryptionTypeGB.TabStop = false;
            this.EncryptionTypeGB.Text = "Encryption Type";
            // 
            // SealedX3DiffieHellmanRB
            // 
            this.SealedX3DiffieHellmanRB.AutoSize = true;
            this.SealedX3DiffieHellmanRB.Location = new System.Drawing.Point(7, 69);
            this.SealedX3DiffieHellmanRB.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SealedX3DiffieHellmanRB.Name = "SealedX3DiffieHellmanRB";
            this.SealedX3DiffieHellmanRB.Size = new System.Drawing.Size(232, 29);
            this.SealedX3DiffieHellmanRB.TabIndex = 1;
            this.SealedX3DiffieHellmanRB.Text = "Sealed X3 Diffie Hellman";
            this.SealedX3DiffieHellmanRB.UseVisualStyleBackColor = true;
            this.SealedX3DiffieHellmanRB.CheckedChanged += new System.EventHandler(this.EncryptionTypeDeterminer);
            // 
            // SealedDiffieHellmanRB
            // 
            this.SealedDiffieHellmanRB.AutoSize = true;
            this.SealedDiffieHellmanRB.Checked = true;
            this.SealedDiffieHellmanRB.Location = new System.Drawing.Point(7, 31);
            this.SealedDiffieHellmanRB.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SealedDiffieHellmanRB.Name = "SealedDiffieHellmanRB";
            this.SealedDiffieHellmanRB.Size = new System.Drawing.Size(206, 29);
            this.SealedDiffieHellmanRB.TabIndex = 0;
            this.SealedDiffieHellmanRB.TabStop = true;
            this.SealedDiffieHellmanRB.Text = "Sealed Diffie Hellman";
            this.SealedDiffieHellmanRB.UseVisualStyleBackColor = true;
            this.SealedDiffieHellmanRB.CheckedChanged += new System.EventHandler(this.EncryptionTypeDeterminer);
            // 
            // SymmetricEncryptionAlgorithmGB
            // 
            this.SymmetricEncryptionAlgorithmGB.Controls.Add(this.XChaCha20Poly1305RB);
            this.SymmetricEncryptionAlgorithmGB.Controls.Add(this.XSalsa20Poly1305RB);
            this.SymmetricEncryptionAlgorithmGB.Location = new System.Drawing.Point(634, 154);
            this.SymmetricEncryptionAlgorithmGB.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SymmetricEncryptionAlgorithmGB.Name = "SymmetricEncryptionAlgorithmGB";
            this.SymmetricEncryptionAlgorithmGB.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SymmetricEncryptionAlgorithmGB.Size = new System.Drawing.Size(292, 129);
            this.SymmetricEncryptionAlgorithmGB.TabIndex = 59;
            this.SymmetricEncryptionAlgorithmGB.TabStop = false;
            this.SymmetricEncryptionAlgorithmGB.Text = "Symmetric Encryption Algorithm";
            // 
            // XChaCha20Poly1305RB
            // 
            this.XChaCha20Poly1305RB.AutoSize = true;
            this.XChaCha20Poly1305RB.Location = new System.Drawing.Point(7, 69);
            this.XChaCha20Poly1305RB.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.XChaCha20Poly1305RB.Name = "XChaCha20Poly1305RB";
            this.XChaCha20Poly1305RB.Size = new System.Drawing.Size(201, 29);
            this.XChaCha20Poly1305RB.TabIndex = 1;
            this.XChaCha20Poly1305RB.Text = "XChaCha20Poly1305";
            this.XChaCha20Poly1305RB.UseVisualStyleBackColor = true;
            // 
            // XSalsa20Poly1305RB
            // 
            this.XSalsa20Poly1305RB.AutoSize = true;
            this.XSalsa20Poly1305RB.Checked = true;
            this.XSalsa20Poly1305RB.Location = new System.Drawing.Point(7, 31);
            this.XSalsa20Poly1305RB.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.XSalsa20Poly1305RB.Name = "XSalsa20Poly1305RB";
            this.XSalsa20Poly1305RB.Size = new System.Drawing.Size(255, 29);
            this.XSalsa20Poly1305RB.TabIndex = 0;
            this.XSalsa20Poly1305RB.TabStop = true;
            this.XSalsa20Poly1305RB.Text = "XSalsa20Poly1305 - Default";
            this.XSalsa20Poly1305RB.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(630, 319);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(168, 25);
            this.label11.TabIndex = 60;
            this.label11.Text = "Is Primary Key Table";
            // 
            // IsPrimaryKeyTableCB
            // 
            this.IsPrimaryKeyTableCB.AutoSize = true;
            this.IsPrimaryKeyTableCB.Checked = true;
            this.IsPrimaryKeyTableCB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.IsPrimaryKeyTableCB.Location = new System.Drawing.Point(634, 348);
            this.IsPrimaryKeyTableCB.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.IsPrimaryKeyTableCB.Name = "IsPrimaryKeyTableCB";
            this.IsPrimaryKeyTableCB.Size = new System.Drawing.Size(63, 29);
            this.IsPrimaryKeyTableCB.TabIndex = 61;
            this.IsPrimaryKeyTableCB.Text = "Yes";
            this.IsPrimaryKeyTableCB.UseVisualStyleBackColor = true;
            this.IsPrimaryKeyTableCB.CheckedChanged += new System.EventHandler(this.IsPrimaryKeyTableCB_CheckedChanged);
            // 
            // ForeignKeyValueTB
            // 
            this.ForeignKeyValueTB.Location = new System.Drawing.Point(634, 461);
            this.ForeignKeyValueTB.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ForeignKeyValueTB.Multiline = true;
            this.ForeignKeyValueTB.Name = "ForeignKeyValueTB";
            this.ForeignKeyValueTB.ReadOnly = true;
            this.ForeignKeyValueTB.Size = new System.Drawing.Size(292, 103);
            this.ForeignKeyValueTB.TabIndex = 63;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(630, 431);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(152, 25);
            this.label12.TabIndex = 62;
            this.label12.Text = "Foreign Key Value";
            // 
            // SuccessResponseTB
            // 
            this.SuccessResponseTB.Location = new System.Drawing.Point(941, 41);
            this.SuccessResponseTB.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SuccessResponseTB.Multiline = true;
            this.SuccessResponseTB.Name = "SuccessResponseTB";
            this.SuccessResponseTB.ReadOnly = true;
            this.SuccessResponseTB.Size = new System.Drawing.Size(292, 103);
            this.SuccessResponseTB.TabIndex = 65;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(937, 11);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(154, 25);
            this.label13.TabIndex = 64;
            this.label13.Text = "Success Response";
            // 
            // DBInsertDemo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1247, 732);
            this.Controls.Add(this.SuccessResponseTB);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.ForeignKeyValueTB);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.IsPrimaryKeyTableCB);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.SymmetricEncryptionAlgorithmGB);
            this.Controls.Add(this.EncryptionTypeGB);
            this.Controls.Add(this.InsertRecordBTN);
            this.Controls.Add(this.SampleJSONStringTB);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.SQLParameterValueArrayTB);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.SQLParameterNameArrayTB);
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
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "DBInsertDemo";
            this.Text = "DBInsertDemo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnClosing);
            this.EncryptionTypeGB.ResumeLayout(false);
            this.EncryptionTypeGB.PerformLayout();
            this.SymmetricEncryptionAlgorithmGB.ResumeLayout(false);
            this.SymmetricEncryptionAlgorithmGB.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button InsertRecordBTN;
        private System.Windows.Forms.TextBox SampleJSONStringTB;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox SQLParameterValueArrayTB;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox SQLParameterNameArrayTB;
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
        private System.Windows.Forms.GroupBox EncryptionTypeGB;
        private System.Windows.Forms.RadioButton SealedX3DiffieHellmanRB;
        private System.Windows.Forms.RadioButton SealedDiffieHellmanRB;
        private System.Windows.Forms.GroupBox SymmetricEncryptionAlgorithmGB;
        private System.Windows.Forms.RadioButton XChaCha20Poly1305RB;
        private System.Windows.Forms.RadioButton XSalsa20Poly1305RB;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox IsPrimaryKeyTableCB;
        private System.Windows.Forms.TextBox ForeignKeyValueTB;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox SuccessResponseTB;
        private System.Windows.Forms.Label label13;
    }
}