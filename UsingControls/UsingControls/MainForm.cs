using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UsingControls
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            var Fonts = FontFamily.Families;
            foreach (FontFamily f in Fonts)
                cboFont.Items.Add(f.Name);
        }

        public void ChangeFont()
        {
            if(cboFont.SelectedIndex < 0)
            {
                return;
            }

            FontStyle style = FontStyle.Regular;
            if(chkBold.Checked)
            {
                style |= FontStyle.Bold;
            }
            if(chkItalic.Checked)
            {
                style |= FontStyle.Italic;
            }

            txtSampleText.Font = new Font((string)cboFont.SelectedItem, 10, style);
        }

        private void cboFont_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeFont();
        }

        private void chkBold_CheckedChanged(object sender, EventArgs e)
        {
            ChangeFont();
        }

        private void chkItalic_CheckedChanged(object sender, EventArgs e)
        {
            ChangeFont();
        }
    }
}
