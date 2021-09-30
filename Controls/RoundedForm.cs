using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace TafeInformationSystem.Controls
{
    public partial class RoundedForm : Form
          //  public partial class frmLogin : Form
    {
        public RoundedForm()
        {
            this.BackColor = Color.DarkGray;
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            using (var gp = new GraphicsPath())
            {
                gp.AddEllipse(new Rectangle(0, 0, this.Width - 1, this.Height - 1));
                this.Region = new Region(gp);
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // RoundedForm
            // 
            this.ClientSize = new System.Drawing.Size(736, 317);
            this.Name = "RoundedForm";
            this.ResumeLayout(false);

        }
    }
}
