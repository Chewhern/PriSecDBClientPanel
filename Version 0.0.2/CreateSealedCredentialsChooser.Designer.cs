
namespace PriSecDBClientPanel
{
    partial class CreateSealedCredentialsChooser
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
            this.label1 = new System.Windows.Forms.Label();
            this.CreateCredentialsBTN = new System.Windows.Forms.Button();
            this.DeleteCredentialsBTN = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(275, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(330, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Click any of the buttons below";
            // 
            // CreateCredentialsBTN
            // 
            this.CreateCredentialsBTN.Location = new System.Drawing.Point(259, 84);
            this.CreateCredentialsBTN.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.CreateCredentialsBTN.Name = "CreateCredentialsBTN";
            this.CreateCredentialsBTN.Size = new System.Drawing.Size(361, 74);
            this.CreateCredentialsBTN.TabIndex = 1;
            this.CreateCredentialsBTN.Text = "Create Sealed DB Credentials";
            this.CreateCredentialsBTN.UseVisualStyleBackColor = true;
            this.CreateCredentialsBTN.Click += new System.EventHandler(this.CreateCredentialsBTN_Click);
            // 
            // DeleteCredentialsBTN
            // 
            this.DeleteCredentialsBTN.Location = new System.Drawing.Point(259, 214);
            this.DeleteCredentialsBTN.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DeleteCredentialsBTN.Name = "DeleteCredentialsBTN";
            this.DeleteCredentialsBTN.Size = new System.Drawing.Size(361, 74);
            this.DeleteCredentialsBTN.TabIndex = 2;
            this.DeleteCredentialsBTN.Text = "Delete Sealed DB Credentials";
            this.DeleteCredentialsBTN.UseVisualStyleBackColor = true;
            this.DeleteCredentialsBTN.Click += new System.EventHandler(this.DeleteCredentialsBTN_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(13, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(168, 375);
            this.label2.TabIndex = 5;
            this.label2.Text = "The term sealed\r\nrefers to one\r\nway encryption\r\nthat only\r\nsingle party\r\ncan decr" +
    "ypts\r\nit.\r\n\r\nIn this case, \r\nonly server \r\nis able to\r\ndecrypt\r\nthe user\'s \r\ndb\r" +
    "\ncredentials";
            // 
            // CreateSealedCredentialsChooser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(889, 586);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DeleteCredentialsBTN);
            this.Controls.Add(this.CreateCredentialsBTN);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "CreateSealedCredentialsChooser";
            this.Text = "CreateSealedCredentialsChooser";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button CreateCredentialsBTN;
        private System.Windows.Forms.Button DeleteCredentialsBTN;
        private System.Windows.Forms.Label label2;
    }
}