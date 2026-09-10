using MegaMariPrac.Utils;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;

namespace MegaMariPrac.SaveStates
{
    partial class SaveStateName : Form
    {
        /// <summary>Required designer variable.</summary>
        private System.ComponentModel.IContainer components = null;
        private ComponentResourceManager resources = new ComponentResourceManager(typeof(SaveStateName));

        /// <summary>Clean up any resources being used.</summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
            this.buttonOK = WinFormHelpers.CreateButton("buttonOK", "OK", new Point(12, 53), new Size(161, 23), control: this);
            this.buttonOK.TabIndex = 5;
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);

            this.textName = WinFormHelpers.CreateTextBox("textName", new Point(12, 26), new Size(161, 20), control: this);
            this.textName.TabIndex = 4;

            this.label1 = WinFormHelpers.CreateLabel("label1", "Enter the name of the save state:", new Point(9, 10), new Size(161, 13), control: this);
            this.label1.TabIndex = 3;

            this.SuspendLayout();
            this.SetFormParameters();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        /// <summary>Set parameters & events for the this form</summary>
        void SetFormParameters()
        {
            this.Name = "SaveStateName";
            this.Text = "Save State";
            this.ClientSize = new Size(190, 88);
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.Icon = ((Icon)(resources.GetObject("$this.Icon")));
        }

        #endregion

        private Button buttonOK;
        private TextBox textName;
        private Label label1;
    }
}
