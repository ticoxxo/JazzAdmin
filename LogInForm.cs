using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JazzAdmin.test_jazzclubDataSetTableAdapters;

namespace JazzAdmin
{
    public partial class LogInForm : Form
    {
        public LogInForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            HomeForm homeForm = new HomeForm();
            usersTableAdapter.ClearBeforeFill = true;
            usersTableAdapter.FillByNameAndPass(test_jazzclubDataSet.users, txtUser.Text, txtPassword.Text);
            if(test_jazzclubDataSet.users.Count == 0)
            {
                MessageBox.Show("No matches user and pass");
                txtUser.Clear();
                txtUser.Focus();
                txtPassword.Clear();
            } else
            {
                this.Hide();
                homeForm.ShowDialog();
                this.Close();
            }
        }

        private void LogInForm_Load(object sender, EventArgs e) {}

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnForgotPass_Click(object sender, EventArgs e)
        {
            string passWord;
            usersTableAdapter.ClearBeforeFill = true;
            passWord = usersTableAdapter.GetPassWordQuery(txtUser.Text);
            if (passWord != String.Empty || passWord != null) { 
                MessageBox.Show("The password esssss : " + passWord);
            }
            else { 
                MessageBox.Show("No matched pass");
            }
        }
    }
}
