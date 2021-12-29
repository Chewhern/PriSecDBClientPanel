
namespace PriSecDBClientPanel
{
    partial class MakeRenewPaymentChooser
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
            this.MakePaymentBTN = new System.Windows.Forms.Button();
            this.RenewPaymentBTN = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(237, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(326, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "What do you want to do?";
            // 
            // MakePaymentBTN
            // 
            this.MakePaymentBTN.Location = new System.Drawing.Point(243, 73);
            this.MakePaymentBTN.Name = "MakePaymentBTN";
            this.MakePaymentBTN.Size = new System.Drawing.Size(320, 54);
            this.MakePaymentBTN.TabIndex = 1;
            this.MakePaymentBTN.Text = "Make Payment";
            this.MakePaymentBTN.UseVisualStyleBackColor = true;
            this.MakePaymentBTN.Click += new System.EventHandler(this.MakePaymentBTN_Click);
            // 
            // RenewPaymentBTN
            // 
            this.RenewPaymentBTN.Location = new System.Drawing.Point(243, 166);
            this.RenewPaymentBTN.Name = "RenewPaymentBTN";
            this.RenewPaymentBTN.Size = new System.Drawing.Size(320, 54);
            this.RenewPaymentBTN.TabIndex = 2;
            this.RenewPaymentBTN.Text = "Renew Payment";
            this.RenewPaymentBTN.UseVisualStyleBackColor = true;
            this.RenewPaymentBTN.Click += new System.EventHandler(this.RenewPaymentBTN_Click);
            // 
            // MakeRenewPaymentChooser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.RenewPaymentBTN);
            this.Controls.Add(this.MakePaymentBTN);
            this.Controls.Add(this.label1);
            this.Name = "MakeRenewPaymentChooser";
            this.Text = "MakeRenewPaymentChooser";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(OnClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button MakePaymentBTN;
        private System.Windows.Forms.Button RenewPaymentBTN;
    }
}