using System.Windows.Forms;
using System.Drawing;

namespace MegaMariPrac.About
{
    partial class AboutBox
    {
        /// <summary>Required designer variable.</summary>
        private System.ComponentModel.IContainer components = null;

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

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel = new TableLayoutPanel();
            this.logoPictureBox = new PictureBox();
            this.labelProductName = new Label();
            this.labelVersion = new Label();
            this.labelCopyright = new Label();
            this.labelGameDev = new Label();
            this.textBoxDescription = new TextBox();
            this.okButton = new Button();
            this.tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33F));
            this.tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 67F));
            this.tableLayoutPanel.Controls.Add(this.logoPictureBox, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.labelProductName, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.labelVersion, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.labelCopyright, 1, 2);
            this.tableLayoutPanel.Controls.Add(this.labelGameDev, 1, 3);
            this.tableLayoutPanel.Controls.Add(this.textBoxDescription, 1, 4);
            this.tableLayoutPanel.Controls.Add(this.okButton, 1, 5);
            this.tableLayoutPanel.Dock = DockStyle.Fill;
            this.tableLayoutPanel.Location = new Point(9, 9);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 6;
            this.tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            this.tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            this.tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            this.tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            this.tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            this.tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            this.tableLayoutPanel.Size = new Size(657, 306);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // logoPictureBox
            // 
            this.logoPictureBox.Dock = DockStyle.Fill;
            this.logoPictureBox.Image = global::MegaMariPrac.Properties.Resources.Megamaricover1;
            this.logoPictureBox.Location = new Point(3, 3);
            this.logoPictureBox.Name = "logoPictureBox";
            this.tableLayoutPanel.SetRowSpan(this.logoPictureBox, 6);
            this.logoPictureBox.Size = new Size(210, 300);
            this.logoPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            this.logoPictureBox.TabIndex = 12;
            this.logoPictureBox.TabStop = false;
            // 
            // labelProductName
            // 
            this.labelProductName.Dock = DockStyle.Fill;
            this.labelProductName.Location = new Point(222, 0);
            this.labelProductName.Margin = new Padding(6, 0, 3, 0);
            this.labelProductName.MaximumSize = new Size(0, 17);
            this.labelProductName.Name = "labelProductName";
            this.labelProductName.Size = new Size(432, 17);
            this.labelProductName.TabIndex = 19;
            this.labelProductName.Text = "Product Name";
            this.labelProductName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // labelVersion
            // 
            this.labelVersion.Dock = DockStyle.Fill;
            this.labelVersion.Location = new Point(222, 30);
            this.labelVersion.Margin = new Padding(6, 0, 3, 0);
            this.labelVersion.MaximumSize = new Size(0, 17);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new Size(432, 17);
            this.labelVersion.TabIndex = 0;
            this.labelVersion.Text = "Version";
            this.labelVersion.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // labelCopyright
            // 
            this.labelCopyright.Dock = DockStyle.Fill;
            this.labelCopyright.Location = new Point(222, 60);
            this.labelCopyright.Margin = new Padding(6, 0, 3, 0);
            this.labelCopyright.MaximumSize = new Size(0, 17);
            this.labelCopyright.Name = "labelCopyright";
            this.labelCopyright.Size = new Size(432, 17);
            this.labelCopyright.TabIndex = 21;
            this.labelCopyright.Text = "Copyright";
            this.labelCopyright.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // labelGameDev
            // 
            this.labelGameDev.Dock = DockStyle.Fill;
            this.labelGameDev.Location = new Point(222, 90);
            this.labelGameDev.Margin = new Padding(6, 0, 3, 0);
            this.labelGameDev.MaximumSize = new Size(0, 17);
            this.labelGameDev.Name = "labelGameDev";
            this.labelGameDev.Size = new Size(432, 17);
            this.labelGameDev.TabIndex = 22;
            this.labelGameDev.Text = "Company Name";
            this.labelGameDev.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.AcceptsReturn = true;
            this.textBoxDescription.AcceptsTab = true;
            this.textBoxDescription.Dock = DockStyle.Fill;
            this.textBoxDescription.Location = new Point(222, 123);
            this.textBoxDescription.Margin = new Padding(6, 3, 3, 3);
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.ReadOnly = true;
            this.textBoxDescription.ScrollBars = ScrollBars.Both;
            this.textBoxDescription.Size = new Size(432, 147);
            this.textBoxDescription.TabIndex = 23;
            this.textBoxDescription.TabStop = false;
            this.textBoxDescription.Text = "Description";
            // 
            // okButton
            // 
            this.okButton.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Right)));
            this.okButton.DialogResult = DialogResult.Cancel;
            this.okButton.Location = new Point(579, 280);
            this.okButton.Name = "okButton";
            this.okButton.Size = new Size(75, 23);
            this.okButton.TabIndex = 24;
            this.okButton.Text = "&OK";
            // 
            // AboutBox
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(675, 324);
            this.Controls.Add(this.tableLayoutPanel);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutBox";
            this.Padding = new Padding(9);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "AboutBox";
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).EndInit();
            this.ResumeLayout(false);

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
