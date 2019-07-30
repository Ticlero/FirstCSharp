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
        Random rand = new Random(37);
        public MainForm()
        {
            InitializeComponent();

            lvDummy.Columns.Add("Name");
            lvDummy.Columns.Add("Depth");
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

        private void tbDummy_Scroll(object sender, EventArgs e)
        {
            pbDummy.Value = tbDummy.Value;
        }

        private void btn_Modal_Click(object sender, EventArgs e)
        {
            Form form = new Form();
            form.Text = "Modal Form";
            form.Width = 300;
            form.Height = 200;
            form.BackColor = Color.Red;
            form.ShowDialog();
        }

        private void btn_Modaless_Click(object sender, EventArgs e)
        {
            Form form = new Form();
            form.Text = "Modal Form";
            form.Width = 300;
            form.Height = 200;
            form.BackColor = Color.PowderBlue;
            form.Show();
        }

        private void btnMassage_Click(object sender, EventArgs e)
        {
            MessageBox.Show(txtSampleText.Text, "MessageBox Test", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void TreeToList()
        {
            lvDummy.Items.Clear();
            foreach (TreeNode node in tvDummy.Nodes)
                TreeToList(node);
        }

        private void TreeToList(TreeNode node)
        {
            lvDummy.Items.Add(new ListViewItem(new string[] { node.Text, node.FullPath.Count(f => f == '\\').ToString() }));

            foreach (TreeNode n in node.Nodes)
                TreeToList(n);
        }

        private void btnRoot_Click(object sender, EventArgs e)
        {
            tvDummy.Nodes.Add(rand.Next().ToString());
            TreeToList();
        }

        private void btnChild_Click(object sender, EventArgs e)
        {
            if(tvDummy.SelectedNode == null)
            {
                MessageBox.Show("선택된 노드가 없습니다.", "TreeView Test", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            tvDummy.SelectedNode.Nodes.Add(rand.Next().ToString());
            tvDummy.SelectedNode.Expand();
            TreeToList();
        }
    }
}
