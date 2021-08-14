
namespace PriSecDBClientPanel
{
    partial class RenewPayment
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
            this.label8 = new System.Windows.Forms.Label();
            this.OrderIDTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.VerifyPaymentBTN = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.CreatePaymentBTN = new System.Windows.Forms.Button();
            this.CheckOutPageURLTB = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label8.Location = new System.Drawing.Point(344, 30);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(188, 29);
            this.label8.TabIndex = 35;
            this.label8.Text = "Renew Payment";
            // 
            // OrderIDTB
            // 
            this.OrderIDTB.Location = new System.Drawing.Point(344, 125);
            this.OrderIDTB.Multiline = true;
            this.OrderIDTB.Name = "OrderIDTB";
            this.OrderIDTB.ReadOnly = true;
            this.OrderIDTB.Size = new System.Drawing.Size(250, 58);
            this.OrderIDTB.TabIndex = 30;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(340, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 20);
            this.label1.TabIndex = 29;
            this.label1.Text = "Order ID";
            // 
            // VerifyPaymentBTN
            // 
            this.VerifyPaymentBTN.Location = new System.Drawing.Point(344, 416);
            this.VerifyPaymentBTN.Name = "VerifyPaymentBTN";
            this.VerifyPaymentBTN.Size = new System.Drawing.Size(250, 54);
            this.VerifyPaymentBTN.TabIndex = 34;
            this.VerifyPaymentBTN.Text = "Renew Payment";
            this.VerifyPaymentBTN.UseVisualStyleBackColor = true;
            this.VerifyPaymentBTN.Click += new System.EventHandler(this.VerifyPaymentBTN_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(340, 199);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(229, 20);
            this.label2.TabIndex = 31;
            this.label2.Text = "Make payment via this link/URL";
            // 
            // CreatePaymentBTN
            // 
            this.CreatePaymentBTN.Location = new System.Drawing.Point(344, 328);
            this.CreatePaymentBTN.Name = "CreatePaymentBTN";
            this.CreatePaymentBTN.Size = new System.Drawing.Size(250, 52);
            this.CreatePaymentBTN.TabIndex = 33;
            this.CreatePaymentBTN.Text = "Create Payment";
            this.CreatePaymentBTN.UseVisualStyleBackColor = true;
            this.CreatePaymentBTN.Click += new System.EventHandler(this.CreatePaymentBTN_Click);
            // 
            // CheckOutPageURLTB
            // 
            this.CheckOutPageURLTB.Location = new System.Drawing.Point(344, 231);
            this.CheckOutPageURLTB.Multiline = true;
            this.CheckOutPageURLTB.Name = "CheckOutPageURLTB";
            this.CheckOutPageURLTB.ReadOnly = true;
            this.CheckOutPageURLTB.Size = new System.Drawing.Size(250, 82);
            this.CheckOutPageURLTB.TabIndex = 32;
            // 
            // RenewPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(932, 530);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.OrderIDTB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.VerifyPaymentBTN);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CreatePaymentBTN);
            this.Controls.Add(this.CheckOutPageURLTB);
            this.Name = "RenewPayment";
            this.Text = "RenewPayment";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnClosing);
            this.Load += new System.EventHandler(this.RenewPayment_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox OrderIDTB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button VerifyPaymentBTN;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button CreatePaymentBTN;
        private System.Windows.Forms.TextBox CheckOutPageURLTB;
    }
}