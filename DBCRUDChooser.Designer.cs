
namespace PriSecDBClientPanel
{
    partial class DBCRUDChooser
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
            this.DeleteDBRecordBTN = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.DBInsertBTN = new System.Windows.Forms.Button();
            this.DBUpdateBTN = new System.Windows.Forms.Button();
            this.DBSelectSX3DHBTN = new System.Windows.Forms.Button();
            this.DBSelectSDHBTN = new System.Windows.Forms.Button();
            this.SpecialDBInsertBTN = new System.Windows.Forms.Button();
            this.SpecialDBUpdateBTN = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(223, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(330, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Click any of the buttons below";
            // 
            // DeleteDBRecordBTN
            // 
            this.DeleteDBRecordBTN.Location = new System.Drawing.Point(228, 501);
            this.DeleteDBRecordBTN.Name = "DeleteDBRecordBTN";
            this.DeleteDBRecordBTN.Size = new System.Drawing.Size(325, 52);
            this.DeleteDBRecordBTN.TabIndex = 3;
            this.DeleteDBRecordBTN.Text = "Delete DB Table Record";
            this.DeleteDBRecordBTN.UseVisualStyleBackColor = true;
            this.DeleteDBRecordBTN.Click += new System.EventHandler(this.DeleteDBRecordBTN_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(12, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(174, 300);
            this.label2.TabIndex = 4;
            this.label2.Text = "The term sealed\r\nrefers to one\r\nway encryption \r\nthat only \r\nsingle party \r\ncan d" +
    "ecrypts\r\nit.\r\n\r\nIn this case, only\r\nuser is able to\r\ndecrypt the db\r\ntable\'s rec" +
    "ord";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(569, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(192, 275);
            this.label3.TabIndex = 5;
            this.label3.Text = "X3 Diffie Hellman\r\nhas another more\r\nuser friendly name\r\nwhich is end to\r\nend enc" +
    "ryption\r\nthat exists in\r\nSignal, WhatsApp,\r\nSession, Threema\r\nand Matrix \r\nmessa" +
    "ging \r\napplications.";
            // 
            // DBInsertBTN
            // 
            this.DBInsertBTN.Location = new System.Drawing.Point(228, 52);
            this.DBInsertBTN.Name = "DBInsertBTN";
            this.DBInsertBTN.Size = new System.Drawing.Size(325, 52);
            this.DBInsertBTN.TabIndex = 6;
            this.DBInsertBTN.Text = "DB Insert";
            this.DBInsertBTN.UseVisualStyleBackColor = true;
            this.DBInsertBTN.Click += new System.EventHandler(this.DBInsertBTN_Click);
            // 
            // DBUpdateBTN
            // 
            this.DBUpdateBTN.Location = new System.Drawing.Point(228, 351);
            this.DBUpdateBTN.Name = "DBUpdateBTN";
            this.DBUpdateBTN.Size = new System.Drawing.Size(325, 52);
            this.DBUpdateBTN.TabIndex = 7;
            this.DBUpdateBTN.Text = "DB Update";
            this.DBUpdateBTN.UseVisualStyleBackColor = true;
            this.DBUpdateBTN.Click += new System.EventHandler(this.DBUpdateBTN_Click);
            // 
            // DBSelectSX3DHBTN
            // 
            this.DBSelectSX3DHBTN.Location = new System.Drawing.Point(228, 275);
            this.DBSelectSX3DHBTN.Name = "DBSelectSX3DHBTN";
            this.DBSelectSX3DHBTN.Size = new System.Drawing.Size(325, 52);
            this.DBSelectSX3DHBTN.TabIndex = 8;
            this.DBSelectSX3DHBTN.Text = "DB Select with Sealed X3 Diffie Hellman";
            this.DBSelectSX3DHBTN.UseVisualStyleBackColor = true;
            this.DBSelectSX3DHBTN.Click += new System.EventHandler(this.DBSelectSX3DHBTN_Click);
            // 
            // DBSelectSDHBTN
            // 
            this.DBSelectSDHBTN.Location = new System.Drawing.Point(228, 197);
            this.DBSelectSDHBTN.Name = "DBSelectSDHBTN";
            this.DBSelectSDHBTN.Size = new System.Drawing.Size(325, 52);
            this.DBSelectSDHBTN.TabIndex = 9;
            this.DBSelectSDHBTN.Text = "DB Select with Sealed Diffie Hellman";
            this.DBSelectSDHBTN.UseVisualStyleBackColor = true;
            this.DBSelectSDHBTN.Click += new System.EventHandler(this.DBSelectSDHBTN_Click);
            // 
            // SpecialDBInsertBTN
            // 
            this.SpecialDBInsertBTN.Location = new System.Drawing.Point(228, 123);
            this.SpecialDBInsertBTN.Name = "SpecialDBInsertBTN";
            this.SpecialDBInsertBTN.Size = new System.Drawing.Size(325, 52);
            this.SpecialDBInsertBTN.TabIndex = 10;
            this.SpecialDBInsertBTN.Text = "Special DB Insert";
            this.SpecialDBInsertBTN.UseVisualStyleBackColor = true;
            this.SpecialDBInsertBTN.Click += new System.EventHandler(this.SpecialDBInsertBTN_Click);
            // 
            // SpecialDBUpdateBTN
            // 
            this.SpecialDBUpdateBTN.Location = new System.Drawing.Point(228, 429);
            this.SpecialDBUpdateBTN.Name = "SpecialDBUpdateBTN";
            this.SpecialDBUpdateBTN.Size = new System.Drawing.Size(325, 52);
            this.SpecialDBUpdateBTN.TabIndex = 11;
            this.SpecialDBUpdateBTN.Text = "Special DB Update";
            this.SpecialDBUpdateBTN.UseVisualStyleBackColor = true;
            this.SpecialDBUpdateBTN.Click += new System.EventHandler(this.SpecialDBUpdateBTN_Click);
            // 
            // DBCRUDChooser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 576);
            this.Controls.Add(this.SpecialDBUpdateBTN);
            this.Controls.Add(this.SpecialDBInsertBTN);
            this.Controls.Add(this.DBSelectSDHBTN);
            this.Controls.Add(this.DBSelectSX3DHBTN);
            this.Controls.Add(this.DBUpdateBTN);
            this.Controls.Add(this.DBInsertBTN);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DeleteDBRecordBTN);
            this.Controls.Add(this.label1);
            this.Name = "DBCRUDChooser";
            this.Text = "DBCRUDChooser";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button DeleteDBRecordBTN;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button DBInsertBTN;
        private System.Windows.Forms.Button DBUpdateBTN;
        private System.Windows.Forms.Button DBSelectSX3DHBTN;
        private System.Windows.Forms.Button DBSelectSDHBTN;
        private System.Windows.Forms.Button SpecialDBInsertBTN;
        private System.Windows.Forms.Button SpecialDBUpdateBTN;
    }
}