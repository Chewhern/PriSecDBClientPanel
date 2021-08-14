
namespace PriSecDBClientPanel
{
    partial class MakePayment
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
            this.VerifyPaymentBTN = new System.Windows.Forms.Button();
            this.CreatePaymentBTN = new System.Windows.Forms.Button();
            this.CheckOutPageURLTB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.OrderIDTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.DBNameTB = new System.Windows.Forms.TextBox();
            this.DBUserNameTB = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.DBUserPasswordTB = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.PaymentIDTB = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.RightPanel = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.LeftPanel = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.RightPanel.SuspendLayout();
            this.LeftPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // VerifyPaymentBTN
            // 
            this.VerifyPaymentBTN.Location = new System.Drawing.Point(12, 395);
            this.VerifyPaymentBTN.Name = "VerifyPaymentBTN";
            this.VerifyPaymentBTN.Size = new System.Drawing.Size(250, 54);
            this.VerifyPaymentBTN.TabIndex = 17;
            this.VerifyPaymentBTN.Text = "Verify Payment";
            this.VerifyPaymentBTN.UseVisualStyleBackColor = true;
            this.VerifyPaymentBTN.Click += new System.EventHandler(this.VerifyPaymentBTN_Click);
            // 
            // CreatePaymentBTN
            // 
            this.CreatePaymentBTN.Location = new System.Drawing.Point(12, 307);
            this.CreatePaymentBTN.Name = "CreatePaymentBTN";
            this.CreatePaymentBTN.Size = new System.Drawing.Size(250, 52);
            this.CreatePaymentBTN.TabIndex = 14;
            this.CreatePaymentBTN.Text = "Create Payment";
            this.CreatePaymentBTN.UseVisualStyleBackColor = true;
            this.CreatePaymentBTN.Click += new System.EventHandler(this.CreatePaymentBTN_Click);
            // 
            // CheckOutPageURLTB
            // 
            this.CheckOutPageURLTB.Location = new System.Drawing.Point(12, 210);
            this.CheckOutPageURLTB.Multiline = true;
            this.CheckOutPageURLTB.Name = "CheckOutPageURLTB";
            this.CheckOutPageURLTB.ReadOnly = true;
            this.CheckOutPageURLTB.Size = new System.Drawing.Size(250, 82);
            this.CheckOutPageURLTB.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 178);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(229, 20);
            this.label2.TabIndex = 12;
            this.label2.Text = "Make payment via this link/URL";
            // 
            // OrderIDTB
            // 
            this.OrderIDTB.Location = new System.Drawing.Point(12, 104);
            this.OrderIDTB.Multiline = true;
            this.OrderIDTB.Name = "OrderIDTB";
            this.OrderIDTB.ReadOnly = true;
            this.OrderIDTB.Size = new System.Drawing.Size(250, 58);
            this.OrderIDTB.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "Order ID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 186);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 20);
            this.label3.TabIndex = 18;
            this.label3.Text = "Database Name";
            // 
            // DBNameTB
            // 
            this.DBNameTB.Location = new System.Drawing.Point(24, 210);
            this.DBNameTB.Multiline = true;
            this.DBNameTB.Name = "DBNameTB";
            this.DBNameTB.ReadOnly = true;
            this.DBNameTB.Size = new System.Drawing.Size(459, 58);
            this.DBNameTB.TabIndex = 19;
            // 
            // DBUserNameTB
            // 
            this.DBUserNameTB.Location = new System.Drawing.Point(24, 319);
            this.DBUserNameTB.Multiline = true;
            this.DBUserNameTB.Name = "DBUserNameTB";
            this.DBUserNameTB.ReadOnly = true;
            this.DBUserNameTB.Size = new System.Drawing.Size(459, 58);
            this.DBUserNameTB.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 295);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(163, 20);
            this.label4.TabIndex = 20;
            this.label4.Text = "Database User Name";
            // 
            // DBUserPasswordTB
            // 
            this.DBUserPasswordTB.Location = new System.Drawing.Point(24, 426);
            this.DBUserPasswordTB.Multiline = true;
            this.DBUserPasswordTB.Name = "DBUserPasswordTB";
            this.DBUserPasswordTB.ReadOnly = true;
            this.DBUserPasswordTB.Size = new System.Drawing.Size(459, 58);
            this.DBUserPasswordTB.TabIndex = 23;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 402);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(190, 20);
            this.label5.TabIndex = 22;
            this.label5.Text = "Database User Password";
            // 
            // PaymentIDTB
            // 
            this.PaymentIDTB.Location = new System.Drawing.Point(24, 101);
            this.PaymentIDTB.Multiline = true;
            this.PaymentIDTB.Name = "PaymentIDTB";
            this.PaymentIDTB.ReadOnly = true;
            this.PaymentIDTB.Size = new System.Drawing.Size(459, 58);
            this.PaymentIDTB.TabIndex = 25;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 77);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(236, 20);
            this.label6.TabIndex = 24;
            this.label6.Text = "Payment ID(System Not PayPal)";
            // 
            // RightPanel
            // 
            this.RightPanel.Controls.Add(this.label7);
            this.RightPanel.Controls.Add(this.DBNameTB);
            this.RightPanel.Controls.Add(this.PaymentIDTB);
            this.RightPanel.Controls.Add(this.label3);
            this.RightPanel.Controls.Add(this.label6);
            this.RightPanel.Controls.Add(this.label4);
            this.RightPanel.Controls.Add(this.DBUserPasswordTB);
            this.RightPanel.Controls.Add(this.DBUserNameTB);
            this.RightPanel.Controls.Add(this.label5);
            this.RightPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.RightPanel.Location = new System.Drawing.Point(433, 0);
            this.RightPanel.Name = "RightPanel";
            this.RightPanel.Size = new System.Drawing.Size(524, 607);
            this.RightPanel.TabIndex = 26;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label7.Location = new System.Drawing.Point(19, 6);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(477, 58);
            this.label7.TabIndex = 26;
            this.label7.Text = "Please save all of these \r\ninformation into place that\'s safe and private";
            // 
            // LeftPanel
            // 
            this.LeftPanel.Controls.Add(this.label8);
            this.LeftPanel.Controls.Add(this.OrderIDTB);
            this.LeftPanel.Controls.Add(this.label1);
            this.LeftPanel.Controls.Add(this.VerifyPaymentBTN);
            this.LeftPanel.Controls.Add(this.label2);
            this.LeftPanel.Controls.Add(this.CreatePaymentBTN);
            this.LeftPanel.Controls.Add(this.CheckOutPageURLTB);
            this.LeftPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.LeftPanel.Location = new System.Drawing.Point(0, 0);
            this.LeftPanel.Name = "LeftPanel";
            this.LeftPanel.Size = new System.Drawing.Size(434, 607);
            this.LeftPanel.TabIndex = 27;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label8.Location = new System.Drawing.Point(12, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(171, 29);
            this.label8.TabIndex = 28;
            this.label8.Text = "Make Payment";
            // 
            // MakePayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(957, 607);
            this.Controls.Add(this.LeftPanel);
            this.Controls.Add(this.RightPanel);
            this.Name = "MakePayment";
            this.Text = "MakePayment";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(OnClosing);
            this.RightPanel.ResumeLayout(false);
            this.RightPanel.PerformLayout();
            this.LeftPanel.ResumeLayout(false);
            this.LeftPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button VerifyPaymentBTN;
        private System.Windows.Forms.Button CreatePaymentBTN;
        private System.Windows.Forms.TextBox CheckOutPageURLTB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox OrderIDTB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox DBNameTB;
        private System.Windows.Forms.TextBox DBUserNameTB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox DBUserPasswordTB;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox PaymentIDTB;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel RightPanel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel LeftPanel;
        private System.Windows.Forms.Label label8;
    }
}