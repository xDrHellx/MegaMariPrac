using System.Drawing;
using System.Windows.Forms;

using MegaMariPrac.Utils;

namespace MegaMariPrac
{
    partial class MainForm
    {
        #region Gen designer code

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

        #endregion

        #region Init

        /// <summary>Required method for Designer support - do not modify the contents of this method with the code editor.</summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));




            this.statusStrip = WinFormHelpers.CreateToolStatusStrip("statusStrip", "statusStrip1", new Point(0, 293), new Size(451, 22), control: this);
            this.statusStrip.BackColor = SystemColors.ControlText;
            this.statusStrip.Items.AddRange(new ToolStripItem[] {this.labelStatus});
            this.statusStrip.TabIndex = 2;

            this.labelStatus = WinFormHelpers.CreateToolStripStatusLabel("labelStatus", "labelStatus", new Size(64, 17));
            this.labelStatus.BackColor = this.labelStatus.ForeColor = SystemColors.Control;


            this.groupCoordinates = new GroupBox();




            Font font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F);
            this.labelStoredY = WinFormHelpers.CreateLabel("labelStoredY", "Y: 0", new Point(143, 44), new Size(26, 13), font, control: groupCoordinates);
            this.labelStoredY.ForeColor = Color.Red;
            this.labelStoredY.TabIndex = 28;

            this.labelStoredX = WinFormHelpers.CreateLabel("labelStoredX", "X: 0", new Point(51, 44), new Size(26, 13), font, control: groupCoordinates);
            this.labelStoredX.ForeColor = Color.Blue;
            this.labelStoredX.TabIndex = 27;

            this.buttonLoad = WinFormHelpers.CreateButton("buttonLoad", "Load", new Point(123, 66), new Size(112, 19), btnFont, control: groupCoordinates, enabled: false);
            this.buttonLoad.BackColor = SystemColors.Control;
            this.buttonLoad.TabIndex = 18;
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);

            this.buttonStore = WinFormHelpers.CreateButton("buttonStore", "Store", new Point(6, 66), new Size(112, 19), btnFont, control: groupCoordinates, enabled: false);
            this.buttonStore.BackColor = SystemColors.Control;
            this.buttonStore.TabIndex = 17;
            this.buttonStore.UseVisualStyleBackColor = true;
            this.buttonStore.Click += new System.EventHandler(this.buttonStore_Click);









            font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2 = WinFormHelpers.CreateLabel("label2", "Stored:", new Point(7, 4), new Size(41, 13), font, control: groupCoordinates);
            this.label2.TabIndex = 10;

            this.label1 = WinFormHelpers.CreateLabel("label1", "Coord:", new Point(7, 24), new Size(38, 13), font, control: groupCoordinates);
            this.label1.TabIndex = 7;

            this.labelY = WinFormHelpers.CreateLabel("labelY", "Y: 0", new Point(142, 25), new Size(30, 13), font, control: groupCoordinates);
            this.labelY.ForeColor = Color.Red;
            this.labelY.TabIndex = 6;

            this.labelX = WinFormHelpers.CreateLabel("labelX", "X: 0", new Point(50, 25), new Size(30, 13), font, control: groupCoordinates);
            this.labelX.ForeColor = Color.Blue;
            this.labelX.TabIndex = 5;





            this.groupSaves = new GroupBox();


            this.buttonDelete = WinFormHelpers.CreateButton("buttonDelete", "Delete", new Point(123, 21), new Size(112, 19), btnFont, control: groupSaves, enabled: false);
            this.buttonDelete.BackColor = SystemColors.Control;
            this.buttonDelete.TabIndex = 21;
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);


            this.comboSaves = new ComboBox();


            this.buttonSave = WinFormHelpers.CreateButton("buttonSave", "Save", new Point(6, 21), new Size(112, 19), btnFont, control: groupSaves, enabled: false);
            this.buttonSave.BackColor = SystemColors.Control;
            this.buttonSave.TabIndex = 20;
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);


            font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelScreenTime = WinFormHelpers.CreateLabel("labelScreenTime", "00:00.000", new Point(298, 262), new Size(62, 15), font, control: groupCoordinates);
            this.labelScreenTime.Anchor = topRightAnchor;
            this.labelScreenTime.TabIndex = 39;

            this.label6 = WinFormHelpers.CreateLabel("label6", "Screen timer:", new Point(216, 262), new Size(80, 15), font, control: groupCoordinates);
            this.label6.Anchor = topRightAnchor;
            this.label6.TabIndex = 38;

            this.labelLastScreenTime = WinFormHelpers.CreateLabel("labelLastScreenTime", "00:00.000", new Point(366, 262), new Size(62, 15), font, control: groupCoordinates);
            this.labelLastScreenTime.Anchor = topRightAnchor;
            this.labelLastScreenTime.TabIndex = 40;









            this.groupGeneral = new GroupBox();
            this.tankBox4 = new PictureBox();

            
            this.buttonCheckpoint = WinFormHelpers.CreateButton("buttonCheckPoint", "Checkpoint", new Point(86, 192), new Size(78, 24), btnFont, control: groupGeneral, enabled: false);
            this.buttonCheckpoint.TabIndex = 15;
            this.buttonCheckpoint.UseVisualStyleBackColor = true;
            this.buttonCheckpoint.Click += new System.EventHandler(this.buttonCheckpoint_Click);

            this.tankBox3 = new PictureBox();
            this.checkFreezeAll = new CheckBox();
            this.tankBox2 = new PictureBox();
            this.checkIframes = new CheckBox();
            this.tankBox1 = new PictureBox();
            this.weaponCheckDoll = new CheckBox();
            this.weaponCheckRemilia = new CheckBox();


            this.buttonWin = WinFormHelpers.CreateButton("buttonWin", "Win", new Point(86, 156), new Size(78, 24), btnFont, control: groupGeneral, enabled: false);
            this.buttonWin.Enabled = false;
            this.buttonWin.TabIndex = 13;
            this.buttonWin.UseVisualStyleBackColor = true;
            this.buttonWin.Click += new System.EventHandler(this.buttonWin_Click);

            this.weaponCheckReisen = new CheckBox();
            this.weaponCheckSakuya = new CheckBox();


            this.buttonGameOver = WinFormHelpers.CreateButton("buttonGameOver", "Game over", new Point(86, 120), new Size(78, 24), btnFont, control: groupGeneral, enabled: false);
            this.buttonGameOver.TabIndex = 8;
            this.buttonGameOver.UseVisualStyleBackColor = true;
            this.buttonGameOver.Click += new System.EventHandler(this.buttonGameOver_Click);


            this.weaponCheckEirin = new CheckBox();
            this.weaponCheckYuyuko = new CheckBox();
            this.checkHealth = new CheckBox();
            this.weaponCheckCirno = new CheckBox();


            this.buttonDie = WinFormHelpers.CreateButton("buttonDie", "Die", new Point(86, 84), new Size(78, 24), btnFont, control: groupGeneral, enabled: false);
            this.buttonDie.TabIndex = 6;
            this.buttonDie.UseVisualStyleBackColor = true;
            this.buttonDie.Click += new System.EventHandler(this.buttonDie_Click);

            this.weaponCheckYoumu = new CheckBox();
            this.weaponCheckReimu = new CheckBox();
            this.checkLives = new CheckBox();
            this.weaponCheckBroom = new CheckBox();
            this.weaponBoxEirin = new PictureBox();
            this.weaponBoxSakuya = new PictureBox();
            this.weaponBoxReisen = new PictureBox();
            this.weaponBoxDoll = new PictureBox();
            this.weaponBoxRemilia = new PictureBox();
            this.weaponBoxYuyuko = new PictureBox();
            this.weaponBoxCirno = new PictureBox();
            this.weaponBoxYoumu = new PictureBox();
            this.weaponBoxBroom = new PictureBox();
            this.weaponBoxReimu = new PictureBox();
            this.groupWarp = new GroupBox();
            this.checkEarlyBroom = new CheckBox();


            this.buttonWarp = WinFormHelpers.CreateButton("buttonWarp", "Set level", new Point(174, 13), new Size(61, 23), btnFont, control: groupWarp, enabled: false);
            this.buttonWarp.TabIndex = 15;
            this.buttonWarp.UseVisualStyleBackColor = true;
            this.buttonWarp.Click += new System.EventHandler(this.buttonWarp_Click);

            this.comboWarp = new ComboBox();
            this.toolTip = new ToolTip(this.components);
            this.menuStrip = new MenuStrip();
            this.hotkeysToolStripMenuItem = new ToolStripMenuItem();
            this.applicationFolderToolStripMenuItem = new ToolStripMenuItem();
            this.helpAboutToolStripMenuItem = new ToolStripMenuItem();
            this.barBossHP = new ProgressBar();



            this.label3 = WinFormHelpers.CreateLabel("label3", "Boss HP", new Point(218, 295), new Size(54, 15), font, control: groupCoordinates);
            this.label3.Anchor = AnchorStyles.Bottom;
            this.label3.BackColor = SystemColors.ControlText;
            this.label3.ForeColor = SystemColors.Control;
            this.label3.TabIndex = 47;

            this.labelBossHp = WinFormHelpers.CreateLabel("labelBossHp", "280", new Point(421, 295), new Size(28, 15), font, control: groupCoordinates);
            this.labelBossHp.Anchor = AnchorStyles.Bottom;
            this.labelBossHp.BackColor = Color.Black;
            this.labelBossHp.ForeColor = SystemColors.Control;
            this.labelBossHp.TabIndex = 48;





            this.statusStrip.SuspendLayout();
            this.groupCoordinates.SuspendLayout();
            this.groupSaves.SuspendLayout();
            this.groupGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tankBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tankBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tankBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tankBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.weaponBoxEirin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.weaponBoxSakuya)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.weaponBoxReisen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.weaponBoxDoll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.weaponBoxRemilia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.weaponBoxYuyuko)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.weaponBoxCirno)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.weaponBoxYoumu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.weaponBoxBroom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.weaponBoxReimu)).BeginInit();
            this.groupWarp.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupCoordinates
            // 
            this.groupCoordinates.Anchor = topRightAnchor;
            
            
            this.groupCoordinates.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupCoordinates.Location = new System.Drawing.Point(199, 27);
            this.groupCoordinates.Name = "groupCoordinates";
            this.groupCoordinates.Size = new System.Drawing.Size(241, 93);
            this.groupCoordinates.TabIndex = 17;
            this.groupCoordinates.TabStop = false;
            this.groupCoordinates.Text = "Coordinates/Values";
            // 
            // groupSaves
            // 
            this.groupSaves.Anchor = topRightAnchor;
            
            this.groupSaves.Controls.Add(this.comboSaves);
            
            this.groupSaves.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupSaves.Location = new System.Drawing.Point(199, 126);
            this.groupSaves.Name = "groupSaves";
            this.groupSaves.Size = new System.Drawing.Size(241, 76);
            this.groupSaves.TabIndex = 35;
            this.groupSaves.TabStop = false;
            this.groupSaves.Text = "Save states";
            // 
            // comboSaves
            // 
            this.comboSaves.DisplayMember = "(none)";
            this.comboSaves.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboSaves.Enabled = false;
            this.comboSaves.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboSaves.FormattingEnabled = true;
            this.comboSaves.Location = new System.Drawing.Point(6, 46);
            this.comboSaves.Name = "comboSaves";
            this.comboSaves.Size = new System.Drawing.Size(229, 21);
            this.comboSaves.TabIndex = 19;
            this.comboSaves.SelectedIndexChanged += new System.EventHandler(this.comboSaves_SelectionChangeCommitted);
            // 
            // groupGeneral
            // 
            this.groupGeneral.Controls.Add(this.tankBox4);
            
            this.groupGeneral.Controls.Add(this.tankBox3);
            this.groupGeneral.Controls.Add(this.checkFreezeAll);
            this.groupGeneral.Controls.Add(this.tankBox2);
            this.groupGeneral.Controls.Add(this.checkIframes);
            this.groupGeneral.Controls.Add(this.tankBox1);
            this.groupGeneral.Controls.Add(this.weaponCheckDoll);
            this.groupGeneral.Controls.Add(this.weaponCheckRemilia);
            
            this.groupGeneral.Controls.Add(this.weaponCheckReisen);
            this.groupGeneral.Controls.Add(this.weaponCheckSakuya);
            
            this.groupGeneral.Controls.Add(this.weaponCheckEirin);
            this.groupGeneral.Controls.Add(this.weaponCheckYuyuko);
            this.groupGeneral.Controls.Add(this.checkHealth);
            this.groupGeneral.Controls.Add(this.weaponCheckCirno);
            
            this.groupGeneral.Controls.Add(this.weaponCheckYoumu);
            this.groupGeneral.Controls.Add(this.weaponCheckReimu);
            this.groupGeneral.Controls.Add(this.checkLives);
            this.groupGeneral.Controls.Add(this.weaponCheckBroom);
            this.groupGeneral.Controls.Add(this.weaponBoxEirin);
            this.groupGeneral.Controls.Add(this.weaponBoxSakuya);
            this.groupGeneral.Controls.Add(this.weaponBoxReisen);
            this.groupGeneral.Controls.Add(this.weaponBoxDoll);
            this.groupGeneral.Controls.Add(this.weaponBoxRemilia);
            this.groupGeneral.Controls.Add(this.weaponBoxYuyuko);
            this.groupGeneral.Controls.Add(this.weaponBoxCirno);
            this.groupGeneral.Controls.Add(this.weaponBoxYoumu);
            this.groupGeneral.Controls.Add(this.weaponBoxBroom);
            this.groupGeneral.Controls.Add(this.weaponBoxReimu);
            this.groupGeneral.Location = new System.Drawing.Point(12, 27);
            this.groupGeneral.Name = "groupGeneral";
            this.groupGeneral.Size = new System.Drawing.Size(177, 260);
            this.groupGeneral.TabIndex = 41;
            this.groupGeneral.TabStop = false;
            this.groupGeneral.Text = "General";
            // 
            // tankBox4
            // 
            this.tankBox4.Enabled = false;
            this.tankBox4.Image = global::MegaMariPrac.Properties.Resources.tank_off;
            this.tankBox4.InitialImage = null;
            this.tankBox4.Location = new System.Drawing.Point(144, 222);
            this.tankBox4.Name = "tankBox4";
            this.tankBox4.Size = new System.Drawing.Size(27, 31);
            this.tankBox4.TabIndex = 52;
            this.tankBox4.TabStop = false;
            this.tankBox4.MouseDown += new MouseEventHandler(this.tankBox_Click);
            // 
            // tankBox3
            // 
            this.tankBox3.Enabled = false;
            this.tankBox3.Image = global::MegaMariPrac.Properties.Resources.tank_off;
            this.tankBox3.InitialImage = null;
            this.tankBox3.Location = new System.Drawing.Point(98, 222);
            this.tankBox3.Name = "tankBox3";
            this.tankBox3.Size = new System.Drawing.Size(27, 31);
            this.tankBox3.TabIndex = 51;
            this.tankBox3.TabStop = false;
            this.tankBox3.MouseDown += new MouseEventHandler(this.tankBox_Click);
            // 
            // checkFreezeAll
            // 
            this.checkFreezeAll.AutoSize = true;
            this.checkFreezeAll.Enabled = false;
            this.checkFreezeAll.Location = new System.Drawing.Point(6, 19);
            this.checkFreezeAll.Name = "checkFreezeAll";
            this.checkFreezeAll.Size = new System.Drawing.Size(71, 17);
            this.checkFreezeAll.TabIndex = 24;
            this.checkFreezeAll.TabStop = false;
            this.checkFreezeAll.Text = "Freeze all";
            this.checkFreezeAll.UseVisualStyleBackColor = true;
            this.checkFreezeAll.CheckedChanged += new System.EventHandler(this.checkFreezeAll_CheckedChanged);
            // 
            // tankBox2
            // 
            this.tankBox2.Enabled = false;
            this.tankBox2.Image = global::MegaMariPrac.Properties.Resources.tank_off;
            this.tankBox2.InitialImage = null;
            this.tankBox2.Location = new System.Drawing.Point(52, 222);
            this.tankBox2.Name = "tankBox2";
            this.tankBox2.Size = new System.Drawing.Size(27, 31);
            this.tankBox2.TabIndex = 50;
            this.tankBox2.TabStop = false;
            this.tankBox2.MouseDown += new MouseEventHandler(this.tankBox_Click);
            // 
            // checkIframes
            // 
            this.checkIframes.AutoSize = true;
            this.checkIframes.Enabled = false;
            this.checkIframes.Location = new System.Drawing.Point(83, 59);
            this.checkIframes.Name = "checkIframes";
            this.checkIframes.Size = new System.Drawing.Size(93, 17);
            this.checkIframes.TabIndex = 14;
            this.checkIframes.Text = "Infinite iframes";
            this.checkIframes.UseVisualStyleBackColor = true;
            // 
            // tankBox1
            // 
            this.tankBox1.Enabled = false;
            this.tankBox1.Image = global::MegaMariPrac.Properties.Resources.tank_off;
            this.tankBox1.InitialImage = null;
            this.tankBox1.Location = new System.Drawing.Point(6, 222);
            this.tankBox1.Name = "tankBox1";
            this.tankBox1.Size = new System.Drawing.Size(27, 31);
            this.tankBox1.TabIndex = 49;
            this.tankBox1.TabStop = false;
            this.tankBox1.MouseDown += new MouseEventHandler(this.tankBox_Click);
            // 
            // weaponCheckDoll
            // 
            this.weaponCheckDoll.AutoSize = true;
            this.weaponCheckDoll.Enabled = false;
            this.weaponCheckDoll.Location = new System.Drawing.Point(57, 58);
            this.weaponCheckDoll.Name = "weaponCheckDoll";
            this.weaponCheckDoll.Size = new System.Drawing.Size(15, 14);
            this.weaponCheckDoll.TabIndex = 22;
            this.weaponCheckDoll.TabStop = false;
            this.weaponCheckDoll.UseVisualStyleBackColor = true;
            // 
            // weaponCheckRemilia
            // 
            this.weaponCheckRemilia.AutoSize = true;
            this.weaponCheckRemilia.Enabled = false;
            this.weaponCheckRemilia.Location = new System.Drawing.Point(57, 94);
            this.weaponCheckRemilia.Name = "weaponCheckRemilia";
            this.weaponCheckRemilia.Size = new System.Drawing.Size(15, 14);
            this.weaponCheckRemilia.TabIndex = 21;
            this.weaponCheckRemilia.UseVisualStyleBackColor = true;
            // 
            // weaponCheckReisen
            // 
            this.weaponCheckReisen.AutoSize = true;
            this.weaponCheckReisen.Enabled = false;
            this.weaponCheckReisen.Location = new System.Drawing.Point(57, 130);
            this.weaponCheckReisen.Name = "weaponCheckReisen";
            this.weaponCheckReisen.Size = new System.Drawing.Size(15, 14);
            this.weaponCheckReisen.TabIndex = 20;
            this.weaponCheckReisen.TabStop = false;
            this.weaponCheckReisen.UseVisualStyleBackColor = true;
            // 
            // weaponCheckSakuya
            // 
            this.weaponCheckSakuya.AutoSize = true;
            this.weaponCheckSakuya.Enabled = false;
            this.weaponCheckSakuya.Location = new System.Drawing.Point(57, 166);
            this.weaponCheckSakuya.Name = "weaponCheckSakuya";
            this.weaponCheckSakuya.Size = new System.Drawing.Size(15, 14);
            this.weaponCheckSakuya.TabIndex = 19;
            this.weaponCheckSakuya.TabStop = false;
            this.weaponCheckSakuya.UseVisualStyleBackColor = true;
            // 
            // weaponCheckEirin
            // 
            this.weaponCheckEirin.AutoSize = true;
            this.weaponCheckEirin.Enabled = false;
            this.weaponCheckEirin.Location = new System.Drawing.Point(57, 202);
            this.weaponCheckEirin.Name = "weaponCheckEirin";
            this.weaponCheckEirin.Size = new System.Drawing.Size(15, 14);
            this.weaponCheckEirin.TabIndex = 18;
            this.weaponCheckEirin.TabStop = false;
            this.weaponCheckEirin.UseVisualStyleBackColor = true;
            // 
            // weaponCheckYuyuko
            // 
            this.weaponCheckYuyuko.AutoSize = true;
            this.weaponCheckYuyuko.Enabled = false;
            this.weaponCheckYuyuko.Location = new System.Drawing.Point(21, 202);
            this.weaponCheckYuyuko.Name = "weaponCheckYuyuko";
            this.weaponCheckYuyuko.Size = new System.Drawing.Size(15, 14);
            this.weaponCheckYuyuko.TabIndex = 15;
            this.weaponCheckYuyuko.TabStop = false;
            this.weaponCheckYuyuko.UseVisualStyleBackColor = true;
            // 
            // checkHealth
            // 
            this.checkHealth.AutoSize = true;
            this.checkHealth.Enabled = false;
            this.checkHealth.Location = new System.Drawing.Point(83, 19);
            this.checkHealth.Name = "checkHealth";
            this.checkHealth.Size = new System.Drawing.Size(89, 17);
            this.checkHealth.TabIndex = 5;
            this.checkHealth.Text = "Infinite health";
            this.checkHealth.UseVisualStyleBackColor = true;
            // 
            // weaponCheckCirno
            // 
            this.weaponCheckCirno.AutoSize = true;
            this.weaponCheckCirno.Enabled = false;
            this.weaponCheckCirno.Location = new System.Drawing.Point(21, 166);
            this.weaponCheckCirno.Name = "weaponCheckCirno";
            this.weaponCheckCirno.Size = new System.Drawing.Size(15, 14);
            this.weaponCheckCirno.TabIndex = 14;
            this.weaponCheckCirno.TabStop = false;
            this.weaponCheckCirno.UseVisualStyleBackColor = true;
            // 
            // weaponCheckYoumu
            // 
            this.weaponCheckYoumu.AutoSize = true;
            this.weaponCheckYoumu.Enabled = false;
            this.weaponCheckYoumu.Location = new System.Drawing.Point(21, 130);
            this.weaponCheckYoumu.Name = "weaponCheckYoumu";
            this.weaponCheckYoumu.Size = new System.Drawing.Size(15, 14);
            this.weaponCheckYoumu.TabIndex = 13;
            this.weaponCheckYoumu.TabStop = false;
            this.weaponCheckYoumu.UseVisualStyleBackColor = true;
            // 
            // weaponCheckReimu
            // 
            this.weaponCheckReimu.AutoSize = true;
            this.weaponCheckReimu.Enabled = false;
            this.weaponCheckReimu.Location = new System.Drawing.Point(21, 94);
            this.weaponCheckReimu.Name = "weaponCheckReimu";
            this.weaponCheckReimu.Size = new System.Drawing.Size(15, 14);
            this.weaponCheckReimu.TabIndex = 12;
            this.weaponCheckReimu.TabStop = false;
            this.weaponCheckReimu.UseVisualStyleBackColor = true;
            // 
            // checkLives
            // 
            this.checkLives.AutoSize = true;
            this.checkLives.Enabled = false;
            this.checkLives.Location = new System.Drawing.Point(83, 39);
            this.checkLives.Name = "checkLives";
            this.checkLives.Size = new System.Drawing.Size(81, 17);
            this.checkLives.TabIndex = 9;
            this.checkLives.Text = "Infinite lives";
            this.checkLives.UseVisualStyleBackColor = true;
            // 
            // weaponCheckBroom
            // 
            this.weaponCheckBroom.AutoSize = true;
            this.weaponCheckBroom.Enabled = false;
            this.weaponCheckBroom.ForeColor = SystemColors.ControlText;
            this.weaponCheckBroom.Location = new System.Drawing.Point(21, 58);
            this.weaponCheckBroom.Name = "weaponCheckBroom";
            this.weaponCheckBroom.Size = new System.Drawing.Size(15, 14);
            this.weaponCheckBroom.TabIndex = 1;
            this.weaponCheckBroom.TabStop = false;
            this.weaponCheckBroom.UseVisualStyleBackColor = false;
            // 
            // weaponBoxEirin
            // 
            this.weaponBoxEirin.Enabled = false;
            this.weaponBoxEirin.Image = global::MegaMariPrac.Properties.Resources.eirin_off;
            this.weaponBoxEirin.Location = new System.Drawing.Point(42, 186);
            this.weaponBoxEirin.Name = "weaponBoxEirin";
            this.weaponBoxEirin.Size = new System.Drawing.Size(30, 30);
            this.weaponBoxEirin.TabIndex = 10;
            this.weaponBoxEirin.TabStop = false;
            this.weaponBoxEirin.MouseDown += new MouseEventHandler(this.weaponBox_Click);
            // 
            // weaponBoxSakuya
            // 
            this.weaponBoxSakuya.Enabled = false;
            this.weaponBoxSakuya.Image = global::MegaMariPrac.Properties.Resources.sakuya_off;
            this.weaponBoxSakuya.Location = new System.Drawing.Point(42, 150);
            this.weaponBoxSakuya.Name = "weaponBoxSakuya";
            this.weaponBoxSakuya.Size = new System.Drawing.Size(30, 30);
            this.weaponBoxSakuya.TabIndex = 9;
            this.weaponBoxSakuya.TabStop = false;
            this.weaponBoxSakuya.MouseDown += new MouseEventHandler(this.weaponBox_Click);
            // 
            // weaponBoxReisen
            // 
            this.weaponBoxReisen.Enabled = false;
            this.weaponBoxReisen.Image = global::MegaMariPrac.Properties.Resources.reisen_off;
            this.weaponBoxReisen.Location = new System.Drawing.Point(42, 114);
            this.weaponBoxReisen.Name = "weaponBoxReisen";
            this.weaponBoxReisen.Size = new System.Drawing.Size(30, 30);
            this.weaponBoxReisen.TabIndex = 8;
            this.weaponBoxReisen.TabStop = false;
            this.weaponBoxReisen.MouseDown += new MouseEventHandler(this.weaponBox_Click);
            // 
            // weaponBoxDoll
            // 
            this.weaponBoxDoll.Enabled = false;
            this.weaponBoxDoll.Image = global::MegaMariPrac.Properties.Resources.doll_off;
            this.weaponBoxDoll.InitialImage = null;
            this.weaponBoxDoll.Location = new System.Drawing.Point(42, 42);
            this.weaponBoxDoll.Name = "weaponBoxDoll";
            this.weaponBoxDoll.Size = new System.Drawing.Size(30, 30);
            this.weaponBoxDoll.TabIndex = 7;
            this.weaponBoxDoll.TabStop = false;
            this.weaponBoxDoll.MouseDown += new MouseEventHandler(this.weaponBox_Click);
            // 
            // weaponBoxRemilia
            // 
            this.weaponBoxRemilia.Enabled = false;
            this.weaponBoxRemilia.Image = global::MegaMariPrac.Properties.Resources.remi_off;
            this.weaponBoxRemilia.Location = new System.Drawing.Point(42, 78);
            this.weaponBoxRemilia.Name = "weaponBoxRemilia";
            this.weaponBoxRemilia.Size = new System.Drawing.Size(30, 30);
            this.weaponBoxRemilia.TabIndex = 6;
            this.weaponBoxRemilia.TabStop = false;
            this.weaponBoxRemilia.MouseDown += new MouseEventHandler(this.weaponBox_Click);
            // 
            // weaponBoxYuyuko
            // 
            this.weaponBoxYuyuko.Enabled = false;
            this.weaponBoxYuyuko.Image = global::MegaMariPrac.Properties.Resources.yuyuko_off;
            this.weaponBoxYuyuko.Location = new System.Drawing.Point(6, 186);
            this.weaponBoxYuyuko.Name = "weaponBoxYuyuko";
            this.weaponBoxYuyuko.Size = new System.Drawing.Size(30, 30);
            this.weaponBoxYuyuko.TabIndex = 4;
            this.weaponBoxYuyuko.TabStop = false;
            this.weaponBoxYuyuko.MouseDown += new MouseEventHandler(this.weaponBox_Click);
            // 
            // weaponBoxCirno
            // 
            this.weaponBoxCirno.Enabled = false;
            this.weaponBoxCirno.Image = global::MegaMariPrac.Properties.Resources.cirno_off;
            this.weaponBoxCirno.Location = new System.Drawing.Point(6, 150);
            this.weaponBoxCirno.Name = "weaponBoxCirno";
            this.weaponBoxCirno.Size = new System.Drawing.Size(30, 30);
            this.weaponBoxCirno.TabIndex = 3;
            this.weaponBoxCirno.TabStop = false;
            this.weaponBoxCirno.MouseDown += new MouseEventHandler(this.weaponBox_Click);
            // 
            // weaponBoxYoumu
            // 
            this.weaponBoxYoumu.Enabled = false;
            this.weaponBoxYoumu.Image = global::MegaMariPrac.Properties.Resources.youmu_off;
            this.weaponBoxYoumu.Location = new System.Drawing.Point(6, 114);
            this.weaponBoxYoumu.Name = "weaponBoxYoumu";
            this.weaponBoxYoumu.Size = new System.Drawing.Size(30, 30);
            this.weaponBoxYoumu.TabIndex = 2;
            this.weaponBoxYoumu.TabStop = false;
            this.weaponBoxYoumu.MouseDown += new MouseEventHandler(this.weaponBox_Click);
            // 
            // weaponBoxBroom
            // 
            this.weaponBoxBroom.Enabled = false;
            this.weaponBoxBroom.Image = global::MegaMariPrac.Properties.Resources.broom_off;
            this.weaponBoxBroom.InitialImage = null;
            this.weaponBoxBroom.Location = new System.Drawing.Point(6, 42);
            this.weaponBoxBroom.Name = "weaponBoxBroom";
            this.weaponBoxBroom.Size = new System.Drawing.Size(30, 30);
            this.weaponBoxBroom.TabIndex = 1;
            this.weaponBoxBroom.TabStop = false;
            this.weaponBoxBroom.MouseDown += new MouseEventHandler(this.weaponBox_Click);
            // 
            // weaponBoxReimu
            // 
            this.weaponBoxReimu.Enabled = false;
            this.weaponBoxReimu.Image = global::MegaMariPrac.Properties.Resources.reimu_off;
            this.weaponBoxReimu.Location = new System.Drawing.Point(6, 78);
            this.weaponBoxReimu.Name = "weaponBoxReimu";
            this.weaponBoxReimu.Size = new System.Drawing.Size(30, 30);
            this.weaponBoxReimu.TabIndex = 0;
            this.weaponBoxReimu.TabStop = false;
            this.weaponBoxReimu.MouseDown += new MouseEventHandler(this.weaponBox_Click);
            // 
            // groupWarp
            // 
            this.groupWarp.Anchor = topRightAnchor;
            this.groupWarp.Controls.Add(this.checkEarlyBroom);
            
            this.groupWarp.Controls.Add(this.comboWarp);
            this.groupWarp.Location = new System.Drawing.Point(199, 208);
            this.groupWarp.Name = "groupWarp";
            this.groupWarp.Size = new System.Drawing.Size(241, 44);
            this.groupWarp.TabIndex = 43;
            this.groupWarp.TabStop = false;
            this.groupWarp.Text = "Level warp";
            // 
            // checkEarlyBroom
            // 
            this.checkEarlyBroom.AutoSize = true;
            this.checkEarlyBroom.Enabled = false;
            this.checkEarlyBroom.Location = new System.Drawing.Point(6, 18);
            this.checkEarlyBroom.Name = "checkEarlyBroom";
            this.checkEarlyBroom.Size = new System.Drawing.Size(81, 17);
            this.checkEarlyBroom.TabIndex = 16;
            this.checkEarlyBroom.Text = "Early broom";
            this.checkEarlyBroom.UseVisualStyleBackColor = true;
            this.checkEarlyBroom.CheckedChanged += new System.EventHandler(this.checkEarlyBroom_CheckedChanged);
            // 
            // comboWarp
            // 
            this.comboWarp.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboWarp.Enabled = false;
            this.comboWarp.FormattingEnabled = true;
            this.comboWarp.Items.AddRange(new object[] {
            "Cirno",
            "Eirin",
            "Yuyuko",
            "Reisen",
            "Reimu",
            "Remilia",
            "Sakuya",
            "Youmu",
            "Patchouli 1",
            "Patchouli 2",
            "Patchouli 3",
            "Patchouli 4",
            "Patchouli 5",
            "Patchouli 6"});
            this.comboWarp.Location = new System.Drawing.Point(90, 14);
            this.comboWarp.Name = "comboWarp";
            this.comboWarp.Size = new System.Drawing.Size(78, 21);
            this.comboWarp.TabIndex = 14;
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new ToolStripItem[] {
            this.hotkeysToolStripMenuItem,
            this.applicationFolderToolStripMenuItem,
            this.helpAboutToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(451, 24);
            this.menuStrip.TabIndex = 45;
            this.menuStrip.Text = "menuStrip";
            // 
            // hotkeysToolStripMenuItem
            // 
            this.hotkeysToolStripMenuItem.Name = "hotkeysToolStripMenuItem";
            this.hotkeysToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.hotkeysToolStripMenuItem.Text = "Hotkeys";
            this.hotkeysToolStripMenuItem.Click += new System.EventHandler(this.hotkeysToolStripMenuItem_Click);
            // 
            // applicationFolderToolStripMenuItem
            // 
            this.applicationFolderToolStripMenuItem.Name = "applicationFolderToolStripMenuItem";
            this.applicationFolderToolStripMenuItem.Size = new System.Drawing.Size(114, 20);
            this.applicationFolderToolStripMenuItem.Text = "Application folder";
            this.applicationFolderToolStripMenuItem.Click += new System.EventHandler(this.applicationFolderToolStripMenuItem_Click);
            // 
            // helpAboutToolStripMenuItem
            // 
            this.helpAboutToolStripMenuItem.Name = "helpAboutToolStripMenuItem";
            this.helpAboutToolStripMenuItem.Size = new System.Drawing.Size(82, 20);
            this.helpAboutToolStripMenuItem.Text = "Help/About";
            this.helpAboutToolStripMenuItem.Click += new System.EventHandler(this.helpAboutToolStripMenuItem_Click);
            // 
            // barBossHP
            // 
            this.barBossHP.Anchor = AnchorStyles.Bottom;
            this.barBossHP.ForeColor = SystemColors.HotTrack;
            this.barBossHP.Location = new System.Drawing.Point(274, 296);
            this.barBossHP.Maximum = 280;
            this.barBossHP.Name = "barBossHP";
            this.barBossHP.Size = new System.Drawing.Size(144, 16);
            this.barBossHP.Style = ProgressBarStyle.Continuous;
            this.barBossHP.TabIndex = 46;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 315);
            this.Controls.Add(this.labelBossHp);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.barBossHP);
            this.Controls.Add(this.groupWarp);
            this.Controls.Add(this.groupGeneral);
            this.Controls.Add(this.labelLastScreenTime);
            this.Controls.Add(this.labelScreenTime);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.groupSaves);
            this.Controls.Add(this.groupCoordinates);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.Text = "MegaMariPrac v0.91";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.groupCoordinates.ResumeLayout(false);
            this.groupCoordinates.PerformLayout();
            this.groupSaves.ResumeLayout(false);
            this.groupGeneral.ResumeLayout(false);
            this.groupGeneral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tankBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tankBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tankBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tankBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.weaponBoxEirin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.weaponBoxSakuya)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.weaponBoxReisen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.weaponBoxDoll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.weaponBoxRemilia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.weaponBoxYuyuko)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.weaponBoxCirno)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.weaponBoxYoumu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.weaponBoxBroom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.weaponBoxReimu)).EndInit();
            this.groupWarp.ResumeLayout(false);
            this.groupWarp.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        #region Properties

        AnchorStyles topRightAnchor = ((AnchorStyles.Top | AnchorStyles.Right));
        Font btnFont = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));        
        private ToolTip toolTip;
        private MenuStrip menuStrip;
        private ToolStripMenuItem hotkeysToolStripMenuItem,
            applicationFolderToolStripMenuItem,
            helpAboutToolStripMenuItem;
        private ProgressBar barBossHP;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel labelStatus;
        private GroupBox groupCoordinates,
            groupSaves,
            groupGeneral,
            groupWarp;
        private Label labelStoredY,
            labelStoredX,
            label2,
            label1,
            labelY,
            labelX,
            labelScreenTime,
            label6,
            labelLastScreenTime,
            label3,
            labelBossHp;
        private Button buttonLoad,
            buttonStore,
            buttonDelete,
            buttonSave,
            buttonWin,
            buttonGameOver,
            buttonDie,
            buttonWarp,
            buttonCheckpoint;
        private CheckBox checkFreezeAll,
            weaponCheckDoll,
            weaponCheckRemilia,
            weaponCheckReisen,
            weaponCheckSakuya,
            weaponCheckEirin,
            weaponCheckYuyuko,
            weaponCheckCirno,
            weaponCheckYoumu,
            weaponCheckReimu,
            weaponCheckBroom,
            checkHealth,
            checkLives,
            checkEarlyBroom,
            checkIframes;
        private ComboBox comboSaves,
            comboWarp;
        private PictureBox weaponBoxEirin,
            weaponBoxSakuya,
            weaponBoxReisen,
            weaponBoxDoll,
            weaponBoxRemilia,
            weaponBoxYuyuko,
            weaponBoxCirno,
            weaponBoxYoumu,
            weaponBoxBroom,
            weaponBoxReimu,
            tankBox1,
            tankBox2,
            tankBox3,
            tankBox4;

        #endregion
    }
}

