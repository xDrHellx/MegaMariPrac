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
            this.tableLayoutPanel = WinFormHelpers.CreateTableLayoutPanel("tableLayoutPanel", new Point(9, 9), new Size(657, 306), this, 2, 6);
            this.tableLayoutPanel.TabIndex = 0;
            this.tableLayoutPanel.Dock = DockStyle.Fill;

            this.logoPictureBox = WinFormHelpers.CreatePictureBox("logoPictureBox", global::MegaMariPrac.Properties.Resources.Megamaricover1, new Point(3, 3), new Size(210, 300), tableLayoutPanel, sizeMode: "StretchImage");
            this.logoPictureBox.Dock = DockStyle.Fill;
            this.tableLayoutPanel.SetRowSpan(this.logoPictureBox, 6);
            this.logoPictureBox.TabIndex = 12;
            this.logoPictureBox.TabStop = false;

            this.labelProductName = WinFormHelpers.CreateLabel("labelProductName", "Product Name", new Point(222, 0), new Size(432, 17), control: tableLayoutPanel);
            this.labelProductName.TabIndex = 19;
            this.labelProductName.Margin = new Padding(6, 0, 3, 0);
            this.labelProductName.MaximumSize = new Size(0, 17);
            this.labelProductName.Dock = DockStyle.Fill;

            this.labelVersion = WinFormHelpers.CreateLabel("labelVersion", "Version", new Point(222, 30), new Size(432, 17), control: tableLayoutPanel);
            this.labelVersion.TabIndex = 0;
            this.labelVersion.Margin = new Padding(6, 0, 3, 0);
            this.labelVersion.MaximumSize = new Size(0, 17);
            this.labelVersion.Dock = DockStyle.Fill;

            this.labelCopyright = WinFormHelpers.CreateLabel("labelCopyright", "Copyright", new Point(222, 60), new Size(432, 17), control: tableLayoutPanel);
            this.labelCopyright.TabIndex = 21;
            this.labelCopyright.Margin = new Padding(6, 0, 3, 0);
            this.labelCopyright.MaximumSize = new Size(0, 17);
            this.labelCopyright.Dock = DockStyle.Fill;

            this.labelGameDev = WinFormHelpers.CreateLabel("labelGameDev", "Company Name", new Point(222, 90), new Size(432, 17), control: tableLayoutPanel);
            this.labelGameDev.TabIndex = 22;
            this.labelGameDev.Margin = new Padding(6, 0, 3, 0);
            this.labelGameDev.MaximumSize = new Size(0, 17);
            this.labelGameDev.Dock = DockStyle.Fill;
            
            this.textBoxDescription = WinFormHelpers.CreateTextBox("textBoxDescription", new Point(222, 123), new Size(432, 147), control: tableLayoutPanel, text: "Description");
            this.textBoxDescription.TabIndex = 23;
            this.textBoxDescription.TabStop = false;
            this.textBoxDescription.Margin = new Padding(6, 3, 3, 3);
            this.textBoxDescription.Dock = DockStyle.Fill;
            this.textBoxDescription.ScrollBars = ScrollBars.Both;
            this.textBoxDescription.AcceptsReturn = this.textBoxDescription.AcceptsTab = this.textBoxDescription.Multiline = this.textBoxDescription.ReadOnly = true;
            
            this.okButton = WinFormHelpers.CreateButton("okButton", "&OK", new Point(579, 280), new Size(75, 23), control: tableLayoutPanel);
            this.okButton.TabIndex = 24;
            this.okButton.DialogResult = DialogResult.Cancel;
            this.okButton.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Right)));

            // Add column & row styles to TableLayoutPanel
            this.tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33F));
            this.tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 67F));

            // Only update the layout once all styles are set
            this.tableLayoutPanel.SuspendLayout();
            foreach (float size in new[] { 10F, 10F, 10F, 10F, 50F, 10F })
            {
                tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, size));
            }

            // Layout stuff & set form parameters
            ((ISupportInitialize)(this.logoPictureBox)).BeginInit();
            this.SuspendLayout();
            SetFormParameters();
            this.tableLayoutPanel.ResumeLayout();
            this.tableLayoutPanel.PerformLayout();
            ((ISupportInitialize)(this.logoPictureBox)).EndInit();
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
            this.AcceptButton = this.okButton;
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel;
        private PictureBox logoPictureBox;
        private Label labelProductName,
            labelVersion,
            labelCopyright,
            labelGameDev;
        private TextBox textBoxDescription;
        private Button okButton;
    }
}
