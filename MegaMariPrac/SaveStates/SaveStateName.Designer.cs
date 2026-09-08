using System.Windows.Forms;
using System.Drawing;

namespace MegaMariPrac.SaveStates
{
    partial class SaveStateName
    {
        /// <summary>Required designer variable.</summary>
        private System.ComponentModel.IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SaveStateName));
            this.buttonOK = new Button();
            this.textName = new TextBox();
            this.label1 = new Label();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new Point(12, 53);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new Size(161, 23);
            this.buttonOK.TabIndex = 5;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // textName
            // 
            this.textName.Location = new Point(12, 26);
            this.textName.Name = "textName";
            this.textName.Size = new Size(161, 20);
            this.textName.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new Point(9, 10);
            this.label1.Name = "label1";
            this.label1.Size = new Size(164, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Enter the name of the save state:";
            // 
            // SaveStateName
            // 
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(190, 88);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.textName);
            this.Controls.Add(this.label1);
            this.Icon = ((Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SaveStateName";
            this.Text = "Save State";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button buttonOK;
        private TextBox textName;
        private Label label1;
    }
}
