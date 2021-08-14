using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PriSecDBClientPanel.Helper;

namespace PriSecDBClientPanel
{
    public partial class MakeRenewPaymentChooser : Form
    {
        public MakeRenewPaymentChooser()
        {
            InitializeComponent();
        }

        private void MakePaymentBTN_Click(object sender, EventArgs e)
        {
            MainFormHolder.OpenMainForm = false;
            MakePayment NewForm = new MakePayment();
            NewForm.Show();
            this.Close();
        }

        private void RenewPaymentBTN_Click(object sender, EventArgs e)
        {
            MainFormHolder.OpenMainForm = false;
            RenewPayment NewForm = new RenewPayment();
            NewForm.Show();
            this.Close();
        }

        private void OnClosing(object sender, EventArgs e) 
        {
            if (MainFormHolder.OpenMainForm == true) 
            {
                MainFormHolder.myForm.Show();
                MainFormHolder.OpenMainForm = false;
            }
        }
    }
}
