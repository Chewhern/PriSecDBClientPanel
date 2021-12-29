
namespace PriSecDBClientPanel
{
    partial class Greetings
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
            this.StatusLabel = new System.Windows.Forms.Label();
            this.MakeRenewPaymentBTN = new System.Windows.Forms.Button();
            this.LockUnlockDBAccountBTN = new System.Windows.Forms.Button();
            this.CreateSealedDBCredentialsBTN = new System.Windows.Forms.Button();
            this.DBCRUDDemoBTN = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // StatusLabel
            // 
            this.StatusLabel.AutoSize = true;
            this.StatusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.StatusLabel.Location = new System.Drawing.Point(13, 13);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(184, 32);
            this.StatusLabel.TabIndex = 0;
            this.StatusLabel.Text = "Default Label";
            // 
            // MakeRenewPaymentBTN
            // 
            this.MakeRenewPaymentBTN.Enabled = false;
            this.MakeRenewPaymentBTN.Location = new System.Drawing.Point(196, 90);
            this.MakeRenewPaymentBTN.Name = "MakeRenewPaymentBTN";
            this.MakeRenewPaymentBTN.Size = new System.Drawing.Size(348, 50);
            this.MakeRenewPaymentBTN.TabIndex = 1;
            this.MakeRenewPaymentBTN.Text = "1. Make/Renew Payment";
            this.MakeRenewPaymentBTN.UseVisualStyleBackColor = true;
            this.MakeRenewPaymentBTN.Click += new System.EventHandler(this.MakeRenewPaymentBTN_Click);
            // 
            // LockUnlockDBAccountBTN
            // 
            this.LockUnlockDBAccountBTN.Enabled = false;
            this.LockUnlockDBAccountBTN.Location = new System.Drawing.Point(196, 329);
            this.LockUnlockDBAccountBTN.Name = "LockUnlockDBAccountBTN";
            this.LockUnlockDBAccountBTN.Size = new System.Drawing.Size(348, 50);
            this.LockUnlockDBAccountBTN.TabIndex = 2;
            this.LockUnlockDBAccountBTN.Text = "3. Lock/Unlock DB Account";
            this.LockUnlockDBAccountBTN.UseVisualStyleBackColor = true;
            this.LockUnlockDBAccountBTN.Click += new System.EventHandler(this.LockUnlockDBAccountBTN_Click);
            // 
            // CreateSealedDBCredentialsBTN
            // 
            this.CreateSealedDBCredentialsBTN.Enabled = false;
            this.CreateSealedDBCredentialsBTN.Location = new System.Drawing.Point(196, 170);
            this.CreateSealedDBCredentialsBTN.Name = "CreateSealedDBCredentialsBTN";
            this.CreateSealedDBCredentialsBTN.Size = new System.Drawing.Size(348, 50);
            this.CreateSealedDBCredentialsBTN.TabIndex = 3;
            this.CreateSealedDBCredentialsBTN.Text = "2. Create Sealed DB Credentials";
            this.CreateSealedDBCredentialsBTN.UseVisualStyleBackColor = true;
            this.CreateSealedDBCredentialsBTN.Click += new System.EventHandler(this.CreateSealedDBCredentialsBTN_Click);
            // 
            // DBCRUDDemoBTN
            // 
            this.DBCRUDDemoBTN.Enabled = false;
            this.DBCRUDDemoBTN.Location = new System.Drawing.Point(196, 250);
            this.DBCRUDDemoBTN.Name = "DBCRUDDemoBTN";
            this.DBCRUDDemoBTN.Size = new System.Drawing.Size(348, 50);
            this.DBCRUDDemoBTN.TabIndex = 4;
            this.DBCRUDDemoBTN.Text = "3. Demonstration of DB CRUD";
            this.DBCRUDDemoBTN.UseVisualStyleBackColor = true;
            this.DBCRUDDemoBTN.Click += new System.EventHandler(this.DBCRUDDemoBTN_Click);
            // 
            // Greetings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.DBCRUDDemoBTN);
            this.Controls.Add(this.CreateSealedDBCredentialsBTN);
            this.Controls.Add(this.LockUnlockDBAccountBTN);
            this.Controls.Add(this.MakeRenewPaymentBTN);
            this.Controls.Add(this.StatusLabel);
            this.Name = "Greetings";
            this.Text = "Greetings";
            this.Load += new System.EventHandler(this.Greetings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label StatusLabel;
        private System.Windows.Forms.Button MakeRenewPaymentBTN;
        private System.Windows.Forms.Button LockUnlockDBAccountBTN;
        private System.Windows.Forms.Button CreateSealedDBCredentialsBTN;
        private System.Windows.Forms.Button DBCRUDDemoBTN;
    }
}

