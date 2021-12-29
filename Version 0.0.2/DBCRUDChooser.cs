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
    public partial class DBCRUDChooser : Form
    {
        public DBCRUDChooser()
        {
            InitializeComponent();
        }

        private void DBInsertBTN_Click(object sender, EventArgs e)
        {
            MainFormHolder.OpenMainForm = false;
            DBInsertDemo NewForm = new DBInsertDemo();
            NewForm.Show();
            this.Close();
        }

        private void DBSelectSDHBTN_Click(object sender, EventArgs e)
        {
            MainFormHolder.OpenMainForm = false;
            SDHDBSelectDemo NewForm = new SDHDBSelectDemo();
            NewForm.Show();
            this.Close();
        }

        private void DBSelectSX3DHBTN_Click(object sender, EventArgs e)
        {
            MainFormHolder.OpenMainForm = false;
            SX3DHDBSelectDemo NewForm = new SX3DHDBSelectDemo();
            NewForm.Show();
            this.Close();
        }


        private void DBUpdateBTN_Click(object sender, EventArgs e)
        {
            MainFormHolder.OpenMainForm = false;
            DBUpdateDemo NewForm = new DBUpdateDemo();
            NewForm.Show();
            this.Close();
        }

        private void DeleteDBRecordBTN_Click(object sender, EventArgs e)
        {
            MainFormHolder.OpenMainForm = false;
            DeleteDBRecordDemo NewForm = new DeleteDBRecordDemo();
            NewForm.Show();
            this.Close();
        }

        private void SpecialDBInsertBTN_Click(object sender, EventArgs e)
        {
            MainFormHolder.OpenMainForm = false;
            SpecialDBInsertDemo NewForm = new SpecialDBInsertDemo();
            NewForm.Show();
            this.Close();
        }

        private void SpecialDBUpdateBTN_Click(object sender, EventArgs e)
        {
            MainFormHolder.OpenMainForm = false;
            SpecialDBUpdateDemo NewForm = new SpecialDBUpdateDemo();
            NewForm.Show();
            this.Close();
        }

        private void OnClosing(object sender, EventArgs e)
        {
            if (MainFormHolder.OpenMainForm == true)
            {
                MainFormHolder.OpenMainForm = false;
                MainFormHolder.myForm.Show();
            }
        }
    }
}
