using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FloatingGlucose
{
    public partial class FormGlucoseSettings : Form
    {
        public FormGlucoseSettings()
        {
            InitializeComponent();
        }

        private void txtNSURL_GotFocus(object sender, EventArgs e)
        {
            if (this.txtNSURL.Text == "https://mysite.azurewebsites.net")
            {
                this.txtNSURL.Select(8, 6);
            }

        }
        private void txtNSURL_LostFocus(object sender, EventArgs e)
        {
            if (this.txtNSURL.Text == "")
            {
                this.txtNSURL.Text = "https://mysite.azurewebsites.net";
            }

        }

        private void txtNSURL_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
