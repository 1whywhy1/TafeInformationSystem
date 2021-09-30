using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TafeInformationSystem.Enums;

namespace TafeInformationSystem
{
    public partial class frmStudent : Form
    {
        #region Variables
        private int sdntID;
        AustralianState austate;

        List<TextBox> profileTxtBoxes;

        #endregion

        #region OnLoad
        private void frmStudent_Load(object sender, EventArgs e)
        {

            //txtSdntFirstName.Text = "Hello";
        }
        #endregion

        #region Constructor
        public frmStudent(int sdntID)
        {
            InitializeComponent();
            cmbState.DataSource = Enum.GetValues(typeof(AustralianState));

            this.sdntID = sdntID;
        }
        #endregion

        private void btnStaff_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

      
        // Rework these to look nicer
        private void btnEdit_Click(object sender, EventArgs e)
        {
            ActivateText(true, pnlProfileInfo);
            dtpSdntDOB.Enabled = true;
            cmbState.Enabled = true;
            btnEdit.Hide();
            btnSave.Show();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ActivateText(false, pnlProfileInfo);
            dtpSdntDOB.Enabled = false;
            cmbState.Enabled = false;
            btnSave.Hide();
            btnEdit.Show();
        }

        private void btnSavePassword_Click(object sender, EventArgs e)
        {
            // Add save password logic here
            btnChangePass.Show();
            btnSavePassword.Hide();
            pnlPassword.Hide();
            txtOldPass.Enabled = false;
            txtNewPass.Enabled = false;
        }

        private void btnChangePass_Click(object sender, EventArgs e)
        {
            btnChangePass.Hide();
            btnSavePassword.Show();
            pnlPassword.Show();
            txtOldPass.Enabled = true;
            txtNewPass.Enabled = true;
        }

        private void ActivateText(bool active, Panel panel)
        {
            foreach (TextBox txt in panel.Controls.OfType<TextBox>())
            {
                txt.Enabled = active;
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            // Put Logout from DB logic here
            frmLogin frmLogin = new frmLogin();
             frmLogin.FormClosed += (s, args) => this.Close();
            frmLogin.Show();
            this.Hide();
            frmLogin.Focus();
        }

        private void pctQuit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
