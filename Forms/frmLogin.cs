using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TafeInformationSystem.Enums;

namespace TafeInformationSystem
{
    public partial class frmLogin : Form
    {
        #region Variables
        LoginType loginType = LoginType.none;
        private int loginID;
        #endregion

        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            switch (loginType)
            {
                case LoginType.none:
                    MessageBox.Show("Choose if you are a student or a teacher");
                    break;

                case LoginType.staff:
                    try
                    {
                     
                        loginID = Convert.ToInt32(txtLogin.Text);
                    }
                    catch
                    {

                    }

                    //frmStaff frmStaff = new frmStudent(loginID);

                    //frmStaff.FormClosed += (s, args) => this.Close();
                    //frmStaff.Show();
                    //this.Hide();
                    //frmStaff.Focus();

                    break;

                case LoginType.student:
                   
                        if (DLLValidation.clsValidation.ValidateEmpty(txtLogin.Text) && DLLValidation.clsValidation.ValidateLength(txtLogin.Text, 4,6) && DLLValidation.clsValidation.ValidateNumeric(txtLogin.Text))
                        {

                            MessageBox.Show(Convert.ToString(DLLValidation.clsValidation.ValidateEmpty(txtLogin.Text)));
                            MessageBox.Show(Convert.ToString(DLLValidation.clsValidation.ValidateLength(txtLogin.Text,4,6)));
                            MessageBox.Show(Convert.ToString(DLLValidation.clsValidation.ValidateNumeric(txtLogin.Text)));
                            loginID = Convert.ToInt32(txtLogin.Text);

                            frmStudent frmStudent = new frmStudent(loginID);

                            frmStudent.FormClosed += (s, args) => this.Close();
                            frmStudent.Show();
                            this.Hide();
                            frmStudent.Focus();
                    } 
                        else
                        {
                            MessageBox.Show("Wboom");
                        }
                 
                    break;

                default:

                    break;
            }
        }

        private void btnStudent_Click(object sender, EventArgs e)
        {
            loginType = LoginType.student;
            btnStudent.BackColor = Color.FromArgb(55, 55, 55);
            btnStaff.BackColor = Color.FromArgb(77, 77, 77);
        }

        private void btnStaff_Click(object sender, EventArgs e)
        {
            loginType = LoginType.staff;
            btnStaff.BackColor = Color.FromArgb(55, 55, 55);
            btnStudent.BackColor = Color.FromArgb(77, 77, 77);
        }

        private void pctQuit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
