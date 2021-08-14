
namespace PriSecDBClientPanel
{
    partial class DBLockUnlockChooser
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
            this.LockDBAccountBTN = new System.Windows.Forms.Button();
            this.UnlockDBAccountBTN = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(133, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(511, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Do you want to lock or unlock your db account?";
            // 
            // LockDBAccountBTN
            // 
            this.LockDBAccountBTN.Location = new System.Drawing.Point(252, 53);
            this.LockDBAccountBTN.Name = "LockDBAccountBTN";
            this.LockDBAccountBTN.Size = new System.Drawing.Size(271, 57);
            this.LockDBAccountBTN.TabIndex = 1;
            this.LockDBAccountBTN.Text = "Lock database account";
            this.LockDBAccountBTN.UseVisualStyleBackColor = true;
            this.LockDBAccountBTN.Click += new System.EventHandler(this.LockDBAccountBTN_Click);
            // 
            // UnlockDBAccountBTN
            // 
            this.UnlockDBAccountBTN.Location = new System.Drawing.Point(252, 159);
            this.UnlockDBAccountBTN.Name = "UnlockDBAccountBTN";
            this.UnlockDBAccountBTN.Size = new System.Drawing.Size(271, 57);
            this.UnlockDBAccountBTN.TabIndex = 2;
            this.UnlockDBAccountBTN.Text = "Unlock database account";
            this.UnlockDBAccountBTN.UseVisualStyleBackColor = true;
            this.UnlockDBAccountBTN.Click += new System.EventHandler(this.UnlockDBAccountBTN_Click);
            // 
            // DBLockUnlockChooser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.UnlockDBAccountBTN);
            this.Controls.Add(this.LockDBAccountBTN);
            this.Controls.Add(this.label1);
            this.Name = "DBLockUnlockChooser";
            this.Text = "DBLockUnlockChooser";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(OnClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button LockDBAccountBTN;
        private System.Windows.Forms.Button UnlockDBAccountBTN;
    }
}