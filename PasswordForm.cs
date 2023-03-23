using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OperatorUI
{
    public partial class PasswordForm : Form
    {
        public PasswordForm()
        {
            InitializeComponent();
        }

        private void ok_Btn_Click(object sender, EventArgs e)
        {
            string password = "23456";
            if (pw_txt.Text ==password)
            {
                // The password is ok.
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                // The password is invalid.
                pw_txt.Clear();
                MessageBox.Show("Invalid password.");
                pw_txt.Focus();
            }
        }

        private void cancel_Btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
