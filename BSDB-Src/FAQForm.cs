using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mercenary
{
    public partial class FAQForm : Form
    {
        public FAQForm()
        {
            InitializeComponent();
            // Disable automatic tooltip display
            toolTip1.AutoPopDelay = 0;
            toolTip1.InitialDelay = 0;
            toolTip1.ReshowDelay = 0;
            toolTip1.ShowAlways = false;
        }

        private void label6_Click(object sender, EventArgs e)
        {
            // Copy the text of label6 to the clipboard
            Clipboard.SetText(label6.Text);

            // Show the tooltip confirming the copy action
            toolTip1.Show("Copied to clipboard.", label6);
        }
    }
}
