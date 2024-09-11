using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PAW
{
    public partial class Statistics : Form
    {
        public Statistics()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void histogramControl1_MouseMove(object sender, MouseEventArgs e)
        {
            statusStripLabel.Text = "Fat - Frequency Pizza data report";
        }

        private void histogramControl1_MouseLeave(object sender, EventArgs e)
        {
            statusStripLabel.Text = string.Empty;
        }

        private void btnExit_MouseMove(object sender, MouseEventArgs e)
        {
            statusStripLabel.Text = "Close statistics";
        }

        private void btnExit_MouseLeave(object sender, EventArgs e)
        {
            statusStripLabel.Text = string.Empty;
        }
    }
}
