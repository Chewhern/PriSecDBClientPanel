
namespace PriSecDBClientPanel
{
    partial class DBUpdateDemo
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
            this.SuccessResponseTB = new System.Windows.Forms.TextBox();
            this.SymmetricEncryptionAlgorithmGB = new System.Windows.Forms.GroupBox();
            this.XChaCha20Poly1305RB = new System.Windows.Forms.RadioButton();
            this.XSalsa20Poly1305RB = new System.Windows.Forms.RadioButton();
            this.EncryptionTypeGB = new System.Windows.Forms.GroupBox();
            this.SealedX3DiffieHellmanRB = new System.Windows.Forms.RadioButton();
            this.SealedDiffieHellmanRB = new System.Windows.Forms.RadioButton();
            this.SQLParameterValueArrayTB = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.SQLKeyValueTB = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.UpdateDBRecordBTN = new System.Windows.Forms.Button();
            this.SampleJSONStringTB = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
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
            this.SymmetricEncryptionAlgorithmGB.SuspendLayout();
            this.EncryptionTypeGB.SuspendLayout();
            this.SuspendLayout();
            // 
            // SuccessResponseTB
            // 
            this.SuccessResponseTB.Location = new System.Drawing.Point(851, 32);
            this.SuccessResponseTB.Multiline = true;
            this.SuccessResponseTB.Name = "SuccessResponseTB";
            this.SuccessResponseTB.ReadOnly = true;
            this.SuccessResponseTB.Size = new System.Drawing.Size(263, 83);
            this.SuccessResponseTB.TabIndex = 96;
            // 
            // SymmetricEncryptionAlgorithmGB
            // 
            this.SymmetricEncryptionAlgorithmGB.Controls.Add(this.XChaCha20Poly1305RB);
            this.SymmetricEncryptionAlgorithmGB.Controls.Add(this.XSalsa20Poly1305RB);
            this.SymmetricEncryptionAlgorithmGB.Location = new System.Drawing.Point(575, 122);
            this.SymmetricEncryptionAlgorithmGB.Name = "SymmetricEncryptionAlgorithmGB";
            this.SymmetricEncryptionAlgorithmGB.Size = new System.Drawing.Size(263, 103);
            this.SymmetricEncryptionAlgorithmGB.TabIndex = 90;
            this.SymmetricEncryptionAlgorithmGB.TabStop = false;
            this.SymmetricEncryptionAlgorithmGB.Text = "Symmetric Encryption Algorithm";
            // 
            // XChaCha20Poly1305RB
            // 
            this.XChaCha20Poly1305RB.AutoSize = true;
            this.XChaCha20Poly1305RB.Location = new System.Drawing.Point(6, 55);
            this.XChaCha20Poly1305RB.Name = "XChaCha20Poly1305RB";
            this.XChaCha20Poly1305RB.Size = new System.Drawing.Size(186, 24);
            this.XChaCha20Poly1305RB.TabIndex = 1;
            this.XChaCha20Poly1305RB.Text = "XChaCha20Poly1305";
            this.XChaCha20Poly1305RB.UseVisualStyleBackColor = true;
            // 
            // XSalsa20Poly1305RB
            // 
            this.XSalsa20Poly1305RB.AutoSize = true;
            this.XSalsa20Poly1305RB.Checked = true;
            this.XSalsa20Poly1305RB.Location = new System.Drawing.Point(6, 25);
            this.XSalsa20Poly1305RB.Name = "XSalsa20Poly1305RB";
            this.XSalsa20Poly1305RB.Size = new System.Drawing.Size(233, 24);
            this.XSalsa20Poly1305RB.TabIndex = 0;
            this.XSalsa20Poly1305RB.TabStop = true;
            this.XSalsa20Poly1305RB.Text = "XSalsa20Poly1305 - Default";
            this.XSalsa20Poly1305RB.UseVisualStyleBackColor = true;
            // 
            // EncryptionTypeGB
            // 
            this.EncryptionTypeGB.Controls.Add(this.SealedX3DiffieHellmanRB);
            this.EncryptionTypeGB.Controls.Add(this.SealedDiffieHellmanRB);
            this.EncryptionTypeGB.Location = new System.Drawing.Point(575, 12);
            this.EncryptionTypeGB.Name = "EncryptionTypeGB";
            this.EncryptionTypeGB.Size = new System.Drawing.Size(263, 104);
            this.EncryptionTypeGB.TabIndex = 89;
            this.EncryptionTypeGB.TabStop = false;
            this.EncryptionTypeGB.Text = "Encryption Type";
            // 
            // SealedX3DiffieHellmanRB
            // 
            this.SealedX3DiffieHellmanRB.AutoSize = true;
            this.SealedX3DiffieHellmanRB.Location = new System.Drawing.Point(6, 55);
            this.SealedX3DiffieHellmanRB.Name = "SealedX3DiffieHellmanRB";
            this.SealedX3DiffieHellmanRB.Size = new System.Drawing.Size(211, 24);
            this.SealedX3DiffieHellmanRB.TabIndex = 1;
            this.SealedX3DiffieHellmanRB.Text = "Sealed X3 Diffie Hellman";
            this.SealedX3DiffieHellmanRB.UseVisualStyleBackColor = true;
            this.SealedX3DiffieHellmanRB.CheckedChanged += new System.EventHandler(this.EncryptionTypeDeterminer);
            // 
            // SealedDiffieHellmanRB
            // 
            this.SealedDiffieHellmanRB.AutoSize = true;
            this.SealedDiffieHellmanRB.Checked = true;
            this.SealedDiffieHellmanRB.Location = new System.Drawing.Point(6, 25);
            this.SealedDiffieHellmanRB.Name = "SealedDiffieHellmanRB";
            this.SealedDiffieHellmanRB.Size = new System.Drawing.Size(187, 24);
            this.SealedDiffieHellmanRB.TabIndex = 0;
            this.SealedDiffieHellmanRB.TabStop = true;
            this.SealedDiffieHellmanRB.Text = "Sealed Diffie Hellman";
            this.SealedDiffieHellmanRB.UseVisualStyleBackColor = true;
            this.SealedDiffieHellmanRB.CheckedChanged += new System.EventHandler(this.EncryptionTypeDeterminer);
            // 
            // SQLParameterValueArrayTB
            // 
            this.SQLParameterValueArrayTB.Location = new System.Drawing.Point(302, 481);
            this.SQLParameterValueArrayTB.Multiline = true;
            this.SQLParameterValueArrayTB.Name = "SQLParameterValueArrayTB";
            this.SQLParameterValueArrayTB.Size = new System.Drawing.Size(263, 83);
            this.SQLParameterValueArrayTB.TabIndex = 85;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(298, 457);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(172, 20);
            this.label10.TabIndex = 84;
            this.label10.Text = "SQL Parameter Values";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(847, 8);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(147, 20);
            this.label13.TabIndex = 95;
            this.label13.Text = "Success Response";
            // 
            // SQLKeyValueTB
            // 
            this.SQLKeyValueTB.Location = new System.Drawing.Point(575, 251);
            this.SQLKeyValueTB.Multiline = true;
            this.SQLKeyValueTB.Name = "SQLKeyValueTB";
            this.SQLKeyValueTB.Size = new System.Drawing.Size(263, 83);
            this.SQLKeyValueTB.TabIndex = 94;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(571, 227);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(116, 20);
            this.label12.TabIndex = 93;
            this.label12.Text = "SQL Key Value";
            // 
            // UpdateDBRecordBTN
            // 
            this.UpdateDBRecordBTN.Location = new System.Drawing.Point(851, 142);
            this.UpdateDBRecordBTN.Name = "UpdateDBRecordBTN";
            this.UpdateDBRecordBTN.Size = new System.Drawing.Size(263, 65);
            this.UpdateDBRecordBTN.TabIndex = 88;
            this.UpdateDBRecordBTN.Text = "Update DB Table Record";
            this.UpdateDBRecordBTN.UseVisualStyleBackColor = true;
            this.UpdateDBRecordBTN.Click += new System.EventHandler(this.UpdateDBRecordBTN_Click);
            // 
            // SampleJSONStringTB
            // 
            this.SampleJSONStringTB.Location = new System.Drawing.Point(575, 368);
            this.SampleJSONStringTB.Multiline = true;
            this.SampleJSONStringTB.Name = "SampleJSONStringTB";
            this.SampleJSONStringTB.ReadOnly = true;
            this.SampleJSONStringTB.Size = new System.Drawing.Size(263, 83);
            this.SampleJSONStringTB.TabIndex = 87;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(571, 344);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(155, 20);
            this.label14.TabIndex = 86;
            this.label14.Text = "Sample JSON String";
            // 
            // SQLParameterNameArrayTB
            // 
            this.SQLParameterNameArrayTB.Location = new System.Drawing.Point(302, 368);
            this.SQLParameterNameArrayTB.Multiline = true;
            this.SQLParameterNameArrayTB.Name = "SQLParameterNameArrayTB";
            this.SQLParameterNameArrayTB.Size = new System.Drawing.Size(263, 83);
            this.SQLParameterNameArrayTB.TabIndex = 83;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(298, 344);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(173, 20);
            this.label9.TabIndex = 82;
            this.label9.Text = "SQL Parameter Names";
            // 
            // SQLQueryStringTB
            // 
            this.SQLQueryStringTB.Location = new System.Drawing.Point(302, 251);
            this.SQLQueryStringTB.Multiline = true;
            this.SQLQueryStringTB.Name = "SQLQueryStringTB";
            this.SQLQueryStringTB.Size = new System.Drawing.Size(263, 83);
            this.SQLQueryStringTB.TabIndex = 81;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(298, 227);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(133, 20);
            this.label8.TabIndex = 80;
            this.label8.Text = "SQL Query String";
            // 
            // RequestTypeTB
            // 
            this.RequestTypeTB.Location = new System.Drawing.Point(302, 142);
            this.RequestTypeTB.Multiline = true;
            this.RequestTypeTB.Name = "RequestTypeTB";
            this.RequestTypeTB.ReadOnly = true;
            this.RequestTypeTB.Size = new System.Drawing.Size(263, 83);
            this.RequestTypeTB.TabIndex = 79;
            this.RequestTypeTB.Text = "POST";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(298, 118);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(108, 20);
            this.label7.TabIndex = 78;
            this.label7.Text = "Request Type";
            // 
            // WebAPIURLTB
            // 
            this.WebAPIURLTB.Location = new System.Drawing.Point(302, 33);
            this.WebAPIURLTB.Multiline = true;
            this.WebAPIURLTB.Name = "WebAPIURLTB";
            this.WebAPIURLTB.ReadOnly = true;
            this.WebAPIURLTB.Size = new System.Drawing.Size(263, 83);
            this.WebAPIURLTB.TabIndex = 77;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(298, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 20);
            this.label6.TabIndex = 76;
            this.label6.Text = "Web API URL";
            // 
            // UniquePaymentIDTB
            // 
            this.UniquePaymentIDTB.Location = new System.Drawing.Point(16, 142);
            this.UniquePaymentIDTB.Multiline = true;
            this.UniquePaymentIDTB.Name = "UniquePaymentIDTB";
            this.UniquePaymentIDTB.ReadOnly = true;
            this.UniquePaymentIDTB.Size = new System.Drawing.Size(263, 83);
            this.UniquePaymentIDTB.TabIndex = 75;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 119);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(147, 20);
            this.label5.TabIndex = 74;
            this.label5.Text = "Unique Payment ID";
            // 
            // SealedDBUserPasswordTB
            // 
            this.SealedDBUserPasswordTB.Location = new System.Drawing.Point(16, 481);
            this.SealedDBUserPasswordTB.Multiline = true;
            this.SealedDBUserPasswordTB.Name = "SealedDBUserPasswordTB";
            this.SealedDBUserPasswordTB.ReadOnly = true;
            this.SealedDBUserPasswordTB.Size = new System.Drawing.Size(263, 83);
            this.SealedDBUserPasswordTB.TabIndex = 73;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 458);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(197, 20);
            this.label4.TabIndex = 72;
            this.label4.Text = "Sealed DB User Password";
            // 
            // SealedDBUserNameTB
            // 
            this.SealedDBUserNameTB.Location = new System.Drawing.Point(16, 368);
            this.SealedDBUserNameTB.Multiline = true;
            this.SealedDBUserNameTB.Name = "SealedDBUserNameTB";
            this.SealedDBUserNameTB.ReadOnly = true;
            this.SealedDBUserNameTB.Size = new System.Drawing.Size(263, 83);
            this.SealedDBUserNameTB.TabIndex = 71;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 345);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(170, 20);
            this.label3.TabIndex = 70;
            this.label3.Text = "Sealed DB User Name";
            // 
            // SealedDBNameTB
            // 
            this.SealedDBNameTB.Location = new System.Drawing.Point(16, 251);
            this.SealedDBNameTB.Multiline = true;
            this.SealedDBNameTB.Name = "SealedDBNameTB";
            this.SealedDBNameTB.ReadOnly = true;
            this.SealedDBNameTB.Size = new System.Drawing.Size(263, 83);
            this.SealedDBNameTB.TabIndex = 69;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 228);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 20);
            this.label2.TabIndex = 68;
            this.label2.Text = "Sealed DB Name";
            // 
            // SealedSessionIDTB
            // 
            this.SealedSessionIDTB.Location = new System.Drawing.Point(16, 33);
            this.SealedSessionIDTB.Multiline = true;
            this.SealedSessionIDTB.Name = "SealedSessionIDTB";
            this.SealedSessionIDTB.ReadOnly = true;
            this.SealedSessionIDTB.Size = new System.Drawing.Size(263, 83);
            this.SealedSessionIDTB.TabIndex = 67;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 20);
            this.label1.TabIndex = 66;
            this.label1.Text = "Sealed Session ID";
            // 
            // DBUpdateDemo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1202, 587);
            this.Controls.Add(this.SuccessResponseTB);
            this.Controls.Add(this.SymmetricEncryptionAlgorithmGB);
            this.Controls.Add(this.EncryptionTypeGB);
            this.Controls.Add(this.SQLParameterValueArrayTB);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.SQLKeyValueTB);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.UpdateDBRecordBTN);
            this.Controls.Add(this.SampleJSONStringTB);
            this.Controls.Add(this.label14);
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
            this.Name = "DBUpdateDemo";
            this.Text = "DBUpdateDemo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnClosing);
            this.SymmetricEncryptionAlgorithmGB.ResumeLayout(false);
            this.SymmetricEncryptionAlgorithmGB.PerformLayout();
            this.EncryptionTypeGB.ResumeLayout(false);
            this.EncryptionTypeGB.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox SuccessResponseTB;
        private System.Windows.Forms.GroupBox SymmetricEncryptionAlgorithmGB;
        private System.Windows.Forms.RadioButton XChaCha20Poly1305RB;
        private System.Windows.Forms.RadioButton XSalsa20Poly1305RB;
        private System.Windows.Forms.GroupBox EncryptionTypeGB;
        private System.Windows.Forms.RadioButton SealedX3DiffieHellmanRB;
        private System.Windows.Forms.RadioButton SealedDiffieHellmanRB;
        private System.Windows.Forms.TextBox SQLParameterValueArrayTB;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox SQLKeyValueTB;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button UpdateDBRecordBTN;
        private System.Windows.Forms.TextBox SampleJSONStringTB;
        private System.Windows.Forms.Label label14;
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
    }
}