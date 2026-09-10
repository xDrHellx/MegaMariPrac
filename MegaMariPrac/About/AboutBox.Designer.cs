using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using MegaMariPrac.Utils;

namespace MegaMariPrac.About
{
    partial class AboutBox : Form
    {
        /// <summary>Required designer variable.</summary>
        private IContainer components = null;

        /// <summary>Clean up any resources being used.</summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>Required method for Designer support - do not modify the contents of this method with the code editor.</summary>
        private void InitializeComponent()
        {
            // Generate TableLayoutPanel first
            this._tableLayoutPanel = WinFormHelpers.CreateTableLayoutPanel("tableLayoutPanel", new Point(9, 9), new Size(657, 306), this, 2, 6);
            this._tableLayoutPanel.TabIndex = 0;
            this._tableLayoutPanel.Dock = DockStyle.Fill;

            this._logoPictureBox = WinFormHelpers.CreatePictureBox("logoPictureBox", global::MegaMariPrac.Properties.Resources.Megamaricover1, new Point(3, 3), new Size(210, 300), _tableLayoutPanel, sizeMode: "StretchImage");
            this._logoPictureBox.Dock = DockStyle.Fill;
            this._tableLayoutPanel.SetRowSpan(this._logoPictureBox, 6);
            this._logoPictureBox.TabIndex = 12;
            this._logoPictureBox.TabStop = false;

            this._labelProductName = WinFormHelpers.CreateLabel("labelProductName", "Product Name", new Point(222, 0), new Size(432, 17), control: _tableLayoutPanel);
            this._labelProductName.TabIndex = 19;
            this._labelProductName.Margin = new Padding(6, 0, 3, 0);
            this._labelProductName.MaximumSize = new Size(0, 17);
            this._labelProductName.Dock = DockStyle.Fill;

            this._labelVersion = WinFormHelpers.CreateLabel("labelVersion", "Version", new Point(222, 30), new Size(432, 17), control: _tableLayoutPanel);
            this._labelVersion.TabIndex = 0;
            this._labelVersion.Margin = new Padding(6, 0, 3, 0);
            this._labelVersion.MaximumSize = new Size(0, 17);
            this._labelVersion.Dock = DockStyle.Fill;

            this._labelCopyright = WinFormHelpers.CreateLabel("labelCopyright", "Copyright", new Point(222, 60), new Size(432, 17), control: _tableLayoutPanel);
            this._labelCopyright.TabIndex = 21;
            this._labelCopyright.Margin = new Padding(6, 0, 3, 0);
            this._labelCopyright.MaximumSize = new Size(0, 17);
            this._labelCopyright.Dock = DockStyle.Fill;

            this._labelGameDev = WinFormHelpers.CreateLabel("labelGameDev", "Company Name", new Point(222, 90), new Size(432, 17), control: _tableLayoutPanel);
            this._labelGameDev.TabIndex = 22;
            this._labelGameDev.Margin = new Padding(6, 0, 3, 0);
            this._labelGameDev.MaximumSize = new Size(0, 17);
            this._labelGameDev.Dock = DockStyle.Fill;
            
            this._textBoxDescription = WinFormHelpers.CreateTextBox("textBoxDescription", new Point(222, 123), new Size(432, 147), control: _tableLayoutPanel, text: "Description");
            this._textBoxDescription.TabIndex = 23;
            this._textBoxDescription.TabStop = false;
            this._textBoxDescription.Margin = new Padding(6, 3, 3, 3);
            this._textBoxDescription.Dock = DockStyle.Fill;
            this._textBoxDescription.ScrollBars = ScrollBars.Both;
            this._textBoxDescription.AcceptsReturn = this._textBoxDescription.AcceptsTab = this._textBoxDescription.Multiline = this._textBoxDescription.ReadOnly = true;
            
            this._okButton = WinFormHelpers.CreateButton("okButton", "&OK", new Point(579, 280), new Size(75, 23), control: _tableLayoutPanel);
            this._okButton.TabIndex = 24;
            this._okButton.DialogResult = DialogResult.Cancel;
            this._okButton.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Right)));

            // Add column & row styles to TableLayoutPanel
            this._tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33F));
            this._tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 67F));

            // Only update the layout once all styles are set
            this._tableLayoutPanel.SuspendLayout();
            foreach (float size in new[] { 10F, 10F, 10F, 10F, 50F, 10F })
            {
                _tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, size));
            }

            // Layout stuff & set form parameters
            ((ISupportInitialize)(this._logoPictureBox)).BeginInit();
            this.SuspendLayout();
            SetFormParameters();
            this._tableLayoutPanel.ResumeLayout();
            this._tableLayoutPanel.PerformLayout();
            ((ISupportInitialize)(this._logoPictureBox)).EndInit();
            this.ResumeLayout(false);
        }

        /// <summary>Set parameters & events for the this form</summary>
        void SetFormParameters()
        {
            this.Name = this.Text = "AboutBox";
            this.ClientSize = new Size(675, 324);
            this.Padding = new Padding(9);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.MaximizeBox = this.MinimizeBox = this.ShowIcon = this.ShowInTaskbar = false;
            this.AcceptButton = this._okButton;
        }

        #endregion

        private TableLayoutPanel _tableLayoutPanel;
        private PictureBox _logoPictureBox;
        private Label _labelProductName,
            _labelVersion,
            _labelCopyright,
            _labelGameDev;
        private TextBox _textBoxDescription;
        private Button _okButton;
    }
}
