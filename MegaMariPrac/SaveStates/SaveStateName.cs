using System;
using System.Windows.Forms;

namespace MegaMariPrac.SaveStates
{
    public partial class SaveStateName : Form
    {
        public SaveStateName()
        {
            InitializeComponent();
            CenterToScreen();
            MinimizeBox = MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        public string name
        {
            get { return _textName.Text; }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (_textName.Text.Length > 0)
            {
                _textName.Text = _textName.Text.Replace("|", "");
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("No value entered. Try again.",
                                "Nice name",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
            }
        }
    }
}
