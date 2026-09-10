using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

using MegaMariPrac.Utils;

namespace MegaMariPrac
{
    partial class MainForm : Form
    {
        #region Gen designer code

        /// <summary>Required designer variable.</summary>
        private IContainer components = null;

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

        #region Main window & menu

        /// <summary>Set parameters & events for the main window</summary>
        void SetMainWindow()
        {
            this.Name = "MainForm";
            this.Text = "MegaMariPrac v0.91";
            this.ClientSize = new Size(451, 315);
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.MainMenuStrip = this.menuStrip;
            this.Icon = ((Icon)(resources.GetObject("$this.Icon")));
            this.Load += new System.EventHandler(this.MainForm_Load);
        }

        /// <summary>Generate the window menu</summary>
        void GenerateMenu()
        {
            this.menuStrip = WinFormHelpers.CreateMenuStrip("menuStrip", "menuStrip", this);
            this.menuStrip.TabIndex = 45;

            this.hotkeysToolStripMenuItem = WinFormHelpers.CreateToolStripMenuItem("hotkeysToolStripMenuItem", "Hotkeys", menuStrip: this.menuStrip);
            this.hotkeysToolStripMenuItem.Click += new System.EventHandler(this.hotkeysToolStripMenuItem_Click);

            this.applicationFolderToolStripMenuItem = WinFormHelpers.CreateToolStripMenuItem("applicationFolderToolStripMenuItem", "Application folder", menuStrip: this.menuStrip);
            this.applicationFolderToolStripMenuItem.Click += new System.EventHandler(this.applicationFolderToolStripMenuItem_Click);

            this.helpAboutToolStripMenuItem = WinFormHelpers.CreateToolStripMenuItem("helpAboutToolStripMenuItem", "Help/About", menuStrip: this.menuStrip);
            this.helpAboutToolStripMenuItem.Click += new System.EventHandler(this.helpAboutToolStripMenuItem_Click);
        }

        #endregion

        #region Init component

        /// <summary>Required method for Designer support - do not modify the contents of this method with the code editor.</summary>
        private void InitializeComponent()
        {
            // Main window, menu & groups
            SetMainWindow();
            GenerateMenu();
            GenerateCoordinatesGroup();
            GenerateSavesGroup();
            GenerateGeneralGroup();
            GenerateWarpGroup();

            // Tooltip
            this.toolTip = WinFormHelpers.CreateToolTip(20000, 200, 100, container: new Container());

            // Status
            this.labelStatus = WinFormHelpers.CreateToolStripStatusLabel("labelStatus", "labelStatus", new Size(64, 17));
            this.labelStatus.BackColor = this.labelStatus.ForeColor = SystemColors.Control;

            // Boss HP
            this.barBossHP = WinFormHelpers.CreateProgressBar("barBossHP", new Point(274, 296), new Size(144, 16), 0, 280, this);
            this.barBossHP.TabIndex = 46;
            this.barBossHP.Anchor = AnchorStyles.Bottom;
            this.barBossHP.ForeColor = SystemColors.HotTrack;

            Font font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.label3 = WinFormHelpers.CreateLabel("label3", "Boss HP", new Point(218, 295), new Size(54, 15), font, control: this);
            this.label3.TabIndex = 47;
            this.label3.Anchor = AnchorStyles.Bottom;
            this.label3.BackColor = SystemColors.ControlText;
            this.label3.ForeColor = SystemColors.Control;

            this.labelBossHp = WinFormHelpers.CreateLabel("labelBossHp", "280", new Point(421, 295), new Size(28, 15), font, control: this);
            this.labelBossHp.TabIndex = 48;
            this.labelBossHp.Anchor = AnchorStyles.Bottom;
            this.labelBossHp.BackColor = Color.Black;
            this.labelBossHp.ForeColor = SystemColors.Control;

            // Status bar (generate last to prevent it from hiding other elements)
            this.statusStrip = WinFormHelpers.CreateToolStatusStrip("statusStrip", "statusStrip1", new Point(0, 293), new Size(451, 22), control: this);
            this.statusStrip.BackColor = SystemColors.ControlText;
            this.statusStrip.Items.AddRange(new ToolStripItem[] {this.labelStatus});
            this.statusStrip.TabIndex = 2;

            // Timer section
            this.labelScreenTime = WinFormHelpers.CreateLabel("labelScreenTime", "00:00.000", new Point(298, 262), new Size(62, 15), font, control: this);
            this.labelScreenTime.Anchor = topRightAnchor;
            this.labelScreenTime.TabIndex = 39;

            this.label6 = WinFormHelpers.CreateLabel("label6", "Screen timer:", new Point(216, 262), new Size(80, 15), font, control: this);
            this.label6.Anchor = topRightAnchor;
            this.label6.TabIndex = 38;

            this.labelLastScreenTime = WinFormHelpers.CreateLabel("labelLastScreenTime", "00:00.000", new Point(366, 262), new Size(62, 15), font, control: this);
            this.labelLastScreenTime.Anchor = topRightAnchor;
            this.labelLastScreenTime.TabIndex = 40;

            // Layout & init
            this.statusStrip.SuspendLayout();
            this.groupCoordinates.SuspendLayout();
            this.groupSaves.SuspendLayout();
            this.groupGeneral.SuspendLayout();

            ((ISupportInitialize)(this.tankBox4)).BeginInit();
            ((ISupportInitialize)(this.tankBox3)).BeginInit();
            ((ISupportInitialize)(this.tankBox2)).BeginInit();
            ((ISupportInitialize)(this.tankBox1)).BeginInit();
            ((ISupportInitialize)(this.weaponBoxEirin)).BeginInit();
            ((ISupportInitialize)(this.weaponBoxSakuya)).BeginInit();
            ((ISupportInitialize)(this.weaponBoxReisen)).BeginInit();
            ((ISupportInitialize)(this.weaponBoxDoll)).BeginInit();
            ((ISupportInitialize)(this.weaponBoxRemilia)).BeginInit();
            ((ISupportInitialize)(this.weaponBoxYuyuko)).BeginInit();
            ((ISupportInitialize)(this.weaponBoxCirno)).BeginInit();
            ((ISupportInitialize)(this.weaponBoxYoumu)).BeginInit();
            ((ISupportInitialize)(this.weaponBoxBroom)).BeginInit();
            ((ISupportInitialize)(this.weaponBoxReimu)).BeginInit();

            this.groupWarp.SuspendLayout();
            this.menuStrip.SuspendLayout();

            this.SuspendLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.groupCoordinates.ResumeLayout(false);
            this.groupCoordinates.PerformLayout();
            this.groupSaves.ResumeLayout(false);
            this.groupGeneral.ResumeLayout(false);
            this.groupGeneral.PerformLayout();

            ((ISupportInitialize)(this.tankBox4)).EndInit();
            ((ISupportInitialize)(this.tankBox3)).EndInit();
            ((ISupportInitialize)(this.tankBox2)).EndInit();
            ((ISupportInitialize)(this.tankBox1)).EndInit();
            ((ISupportInitialize)(this.weaponBoxEirin)).EndInit();
            ((ISupportInitialize)(this.weaponBoxSakuya)).EndInit();
            ((ISupportInitialize)(this.weaponBoxReisen)).EndInit();
            ((ISupportInitialize)(this.weaponBoxDoll)).EndInit();
            ((ISupportInitialize)(this.weaponBoxRemilia)).EndInit();
            ((ISupportInitialize)(this.weaponBoxYuyuko)).EndInit();
            ((ISupportInitialize)(this.weaponBoxCirno)).EndInit();
            ((ISupportInitialize)(this.weaponBoxYoumu)).EndInit();
            ((ISupportInitialize)(this.weaponBoxBroom)).EndInit();
            ((ISupportInitialize)(this.weaponBoxReimu)).EndInit();

            this.groupWarp.ResumeLayout(false);
            this.groupWarp.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        #region Groups

        void GenerateCoordinatesGroup()
        {
            this.groupCoordinates = WinFormHelpers.CreateGroupBox("groupCoordinates", "Coordinates/Values", new Point(199, 27), new Size(241, 93), grpFont, this);
            this.groupCoordinates.Anchor = topRightAnchor;
            this.groupCoordinates.TabIndex = 17;
            this.groupCoordinates.TabStop = false;

            Font font = new Font("Microsoft Sans Serif", 7.25F);
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

            this.label2 = WinFormHelpers.CreateLabel("label2", "Stored:", new Point(7, 44), new Size(41, 13), grpFont, control: groupCoordinates);
            this.label2.TabIndex = 10;

            this.label1 = WinFormHelpers.CreateLabel("label1", "Coord:", new Point(7, 24), new Size(38, 13), grpFont, control: groupCoordinates);
            this.label1.TabIndex = 7;

            this.labelY = WinFormHelpers.CreateLabel("labelY", "Y: 0", new Point(142, 25), new Size(30, 13), grpFont, control: groupCoordinates);
            this.labelY.ForeColor = Color.Red;
            this.labelY.TabIndex = 6;

            this.labelX = WinFormHelpers.CreateLabel("labelX", "X: 0", new Point(50, 25), new Size(30, 13), grpFont, control: groupCoordinates);
            this.labelX.ForeColor = Color.Blue;
            this.labelX.TabIndex = 5;
        }

        void GenerateSavesGroup()
        {
            this.groupSaves = WinFormHelpers.CreateGroupBox("groupSaves", "Save states", new Point(199, 126), new Size(241, 76), grpFont, this);
            this.groupSaves.Anchor = topRightAnchor;
            this.groupSaves.TabIndex = 35;
            this.groupSaves.TabStop = false;

            this.buttonDelete = WinFormHelpers.CreateButton("buttonDelete", "Delete", new Point(123, 21), new Size(112, 19), btnFont, control: groupSaves, enabled: false);
            this.buttonDelete.BackColor = SystemColors.Control;
            this.buttonDelete.TabIndex = 21;
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);

            this.comboSaves = WinFormHelpers.CreateDropDownList("comboSaves", new Point(6, 46), new Size(229, 21), grpFont, groupSaves, enabled: false);
            this.comboSaves.TabIndex = 19;
            this.comboSaves.FormattingEnabled = true;
            this.comboSaves.SelectedIndexChanged += new System.EventHandler(this.comboSaves_SelectionChangeCommitted);

            this.buttonSave = WinFormHelpers.CreateButton("buttonSave", "Save", new Point(6, 21), new Size(112, 19), btnFont, control: groupSaves, enabled: false);
            this.buttonSave.BackColor = SystemColors.Control;
            this.buttonSave.TabIndex = 20;
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
        }

        void GenerateGeneralGroup()
        {
            this.groupGeneral = WinFormHelpers.CreateGroupBox("groupGeneral", "General", new Point(12, 27), new Size(177, 260), grpFont, this);
            this.groupGeneral.TabIndex = 41;
            this.groupGeneral.TabStop = false;

            // Set params & click events for each tank PictureBox
            SetTankBox(this.tankBox1, "tankBox1", new Point(6, 222), 49);
            SetTankBox(this.tankBox2, "tankBox2", new Point(52, 222), 50);
            SetTankBox(this.tankBox3, "tankBox3", new Point(98, 222), 51);
            SetTankBox(this.tankBox4, "tankBox4", new Point(144, 222), 52);
            
            this.buttonCheckpoint = WinFormHelpers.CreateButton("buttonCheckPoint", "Checkpoint", new Point(86, 192), new Size(78, 24), btnFont, control: groupGeneral, enabled: false);
            this.buttonCheckpoint.TabIndex = 15;
            this.buttonCheckpoint.UseVisualStyleBackColor = true;
            this.buttonCheckpoint.Click += new System.EventHandler(this.buttonCheckpoint_Click);

            this.checkFreezeAll = WinFormHelpers.CreateCheckBox("checkFreezeAll", "Freeze all", new Point(6, 19), new Size(71, 17), control: groupGeneral, enabled: false);
            this.checkFreezeAll.TabIndex = 24;
            this.checkFreezeAll.TabStop = false;
            this.checkFreezeAll.UseVisualStyleBackColor = true;
            this.checkFreezeAll.CheckedChanged += new System.EventHandler(this.checkFreezeAll_CheckedChanged);

            this.checkLives = WinFormHelpers.CreateCheckBox("checkLives", "Infinite lives", new Point(83, 39), new Size(81, 17), control: groupGeneral, enabled: false);
            this.checkLives.TabIndex = 9;
            this.checkLives.UseVisualStyleBackColor = true;

            this.checkHealth = WinFormHelpers.CreateCheckBox("checkHealth", "Infinite health", new Point(83, 19), new Size(89, 17), control: groupGeneral, enabled: false);
            this.checkHealth.TabIndex = 5;
            this.checkHealth.UseVisualStyleBackColor = true;

            this.checkIframes = WinFormHelpers.CreateCheckBox("checkIframes", "Infinite iframes", new Point(83, 59), new Size(93, 17), control: groupGeneral, enabled: false);
            this.checkIframes.TabIndex = 14;
            this.checkIframes.UseVisualStyleBackColor = true;

            this.buttonWin = WinFormHelpers.CreateButton("buttonWin", "Win", new Point(86, 156), new Size(78, 24), btnFont, control: groupGeneral, enabled: false);
            this.buttonWin.TabIndex = 13;
            this.buttonWin.UseVisualStyleBackColor = true;
            this.buttonWin.Click += new System.EventHandler(this.buttonWin_Click);

            // Set params for each weapon CheckBox
            SetWeaponCheckBox(this.weaponCheckDoll, "weaponCheckDoll",new Point(57, 58), 22);
            SetWeaponCheckBox(this.weaponCheckRemilia, "weaponCheckRemilia",new Point(57, 94), 21);
            SetWeaponCheckBox(this.weaponCheckReisen, "weaponCheckReisen",new Point(57, 130), 20);
            SetWeaponCheckBox(this.weaponCheckSakuya, "weaponCheckSakuya",new Point(57, 166), 19);
            SetWeaponCheckBox(this.weaponCheckEirin, "weaponCheckEirin",new Point(57, 202), 18);
            SetWeaponCheckBox(this.weaponCheckYuyuko, "weaponCheckYuyuko",new Point(21, 202), 15);
            SetWeaponCheckBox(this.weaponCheckCirno, "weaponCheckCirno",new Point(21, 166), 14);
            SetWeaponCheckBox(this.weaponCheckYoumu, "weaponCheckYoumu",new Point(21, 130), 13);
            SetWeaponCheckBox(this.weaponCheckReimu, "weaponCheckReimu",new Point(21, 94), 12);
            SetWeaponCheckBox(this.weaponCheckBroom, "weaponCheckBroom",new Point(21, 58), 1);

            this.buttonGameOver = WinFormHelpers.CreateButton("buttonGameOver", "Game over", new Point(86, 120), new Size(78, 24), btnFont, control: groupGeneral, enabled: false);
            this.buttonGameOver.TabIndex = 8;
            this.buttonGameOver.UseVisualStyleBackColor = true;
            this.buttonGameOver.Click += new System.EventHandler(this.buttonGameOver_Click);

            this.buttonDie = WinFormHelpers.CreateButton("buttonDie", "Die", new Point(86, 84), new Size(78, 24), btnFont, control: groupGeneral, enabled: false);
            this.buttonDie.TabIndex = 6;
            this.buttonDie.UseVisualStyleBackColor = true;
            this.buttonDie.Click += new System.EventHandler(this.buttonDie_Click);

            // Set params & click events for each weapon PictureBox
            SetWeaponBox(this.weaponBoxEirin, "eirin", new Point(42, 186), 10);
            SetWeaponBox(this.weaponBoxSakuya, "sakuya", new Point(42, 150), 9);
            SetWeaponBox(this.weaponBoxReisen, "reisen", new Point(42, 114), 8);
            SetWeaponBox(this.weaponBoxDoll, "doll", new Point(42, 42), 7);
            SetWeaponBox(this.weaponBoxRemilia, "remilia", new Point(42, 78), 6);
            SetWeaponBox(this.weaponBoxYuyuko, "yuyuko", new Point(6, 186), 4);
            SetWeaponBox(this.weaponBoxCirno, "cirno", new Point(6, 150), 3);
            SetWeaponBox(this.weaponBoxYoumu, "youmu", new Point(6, 114), 2);
            SetWeaponBox(this.weaponBoxBroom, "broom", new Point(6, 42), 1);
            SetWeaponBox(this.weaponBoxReimu, "reimu", new Point(6, 78), 0);
        }

        void GenerateWarpGroup()
        {
            this.groupWarp = WinFormHelpers.CreateGroupBox("groupWarp", "Level warp", new Point(199, 208), new Size(241, 44), grpFont, this);
            this.groupWarp.Anchor = topRightAnchor;
            this.groupWarp.TabIndex = 43;
            this.groupWarp.TabStop = false;

            this.checkEarlyBroom = WinFormHelpers.CreateCheckBox("checkEarlyBroom", "Early broom", new Point(6, 18), new Size(81, 17), control: groupWarp, enabled: false);
            this.checkEarlyBroom.TabIndex = 16;
            this.checkEarlyBroom.UseVisualStyleBackColor = true;
            this.checkEarlyBroom.CheckedChanged += new System.EventHandler(this.checkEarlyBroom_CheckedChanged);

            this.buttonWarp = WinFormHelpers.CreateButton("buttonWarp", "Set level", new Point(174, 13), new Size(61, 23), btnFont, control: groupWarp, enabled: false);
            this.buttonWarp.TabIndex = 15;
            this.buttonWarp.UseVisualStyleBackColor = true;
            this.buttonWarp.Click += new System.EventHandler(this.buttonWarp_Click);

            this.comboWarp = WinFormHelpers.CreateDropDownList("comboWarp", new Point(90, 14), new Size(78, 21), grpFont, groupWarp, enabled: false);
            this.comboWarp.TabIndex = 14;
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
                "Patchouli 6"
            });
        }

        #endregion

        #region Setter methods

        /// <summary>
        ///     Set a TankBox's (PictureBox) parameters.<br/>
        ///     Also add the Click event to it.
        /// </summary>
        /// <param name="instance">Instance to populate</param>
        /// <param name="character">Character the WeaponBox is for</param>
        /// <param name="position">Position</param>
        /// <param name="tabIndex">TabIndex</param>
        void SetTankBox(PictureBox instance, string name, Point position, int tabIndex)
        {
            // Get the tank OFF img
            Bitmap img = WinFormHelpers.GetResourceImage("tank_off");
            if (instance == null || img == null || name.Length < 1)
            {
                return;
            }

            instance = WinFormHelpers.CreatePictureBox(name, img, position, new Size(27, 31), groupGeneral, enabled: false);
            instance.InitialImage = null;
            instance.TabIndex = tabIndex;
            instance.TabStop = false;
            instance.MouseDown += new MouseEventHandler(this.tankBox_Click);
        }

        /// <summary>Set a CheckBox's parameters</summary>
        /// <param name="instance">Instance to populate</param>
        /// <param name="character">Character the WeaponBox is for</param>
        /// <param name="position">Position</param>
        /// <param name="tabIndex">TabIndex</param>
        void SetWeaponCheckBox(CheckBox instance, string name, Point position, int tabIndex)
        {
            if (instance == null || name.Length < 1)
            {
                return;
            }

            instance = WinFormHelpers.CreateCheckBox(name, "", position, new Size(15, 14), control: groupGeneral, enabled: false);
            instance.TabIndex = 22;
            instance.TabStop = false;
            instance.UseVisualStyleBackColor = name == "weaponCheckBroom" ? false : true;
        }

        /// <summary>
        ///     Set a WeaponBox's (PictureBox) parameters.<br/>
        ///     Also add the Click event to it.
        /// </summary>
        /// <param name="instance">Instance to populate</param>
        /// <param name="character">Character the WeaponBox is for</param>
        /// <param name="position">Position</param>
        /// <param name="tabIndex">TabIndex</param>
        void SetWeaponBox(PictureBox instance, string character, Point position, int tabIndex)
        {
            // Get the character's OFF image
            character = character.ToLower();
            Bitmap img = WinFormHelpers.GetResourceImage($"{character}_off");
            if (instance == null || img == null || character.Length < 1)
            {
                return;
            }

            string characterWithUppercase = char.ToUpper(character[0]) + character.Substring(1).ToLower();
            instance = WinFormHelpers.CreatePictureBox($"weaponBox{characterWithUppercase}", img, position, new Size(30, 30), groupGeneral, enabled: false);
            instance.TabIndex = tabIndex;
            instance.TabStop = false;
            instance.MouseDown += new MouseEventHandler(this.weaponBox_Click);
        }

        #endregion

        #region Properties

        
        ComponentResourceManager resources = new ComponentResourceManager(typeof(MainForm));
        AnchorStyles topRightAnchor = ((AnchorStyles.Top | AnchorStyles.Right));
        Font btnFont = new Font("Microsoft Sans Serif", 6.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))),
            grpFont = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
        private ToolTip toolTip;
        private MenuStrip menuStrip = new MenuStrip();
        private ToolStripMenuItem hotkeysToolStripMenuItem = new ToolStripMenuItem(),
            applicationFolderToolStripMenuItem = new ToolStripMenuItem(),
            helpAboutToolStripMenuItem = new ToolStripMenuItem();
        private ProgressBar barBossHP = new ProgressBar();
        private StatusStrip statusStrip = new StatusStrip();
        private ToolStripStatusLabel labelStatus = new ToolStripStatusLabel();
        private GroupBox groupCoordinates = new GroupBox(),
            groupSaves = new GroupBox(),
            groupGeneral = new GroupBox(),
            groupWarp = new GroupBox();
        private Label labelStoredY = new Label(),
            labelStoredX = new Label(),
            label2 = new Label(),
            label1 = new Label(),
            labelY = new Label(),
            labelX = new Label(),
            labelScreenTime = new Label(),
            label6 = new Label(),
            labelLastScreenTime = new Label(),
            label3 = new Label(),
            labelBossHp = new Label();
        private Button buttonLoad = new Button(),
            buttonStore = new Button(),
            buttonDelete = new Button(),
            buttonSave = new Button(),
            buttonWin = new Button(),
            buttonGameOver = new Button(),
            buttonDie = new Button(),
            buttonWarp = new Button(),
            buttonCheckpoint = new Button();
        private CheckBox checkFreezeAll = new CheckBox(),
            weaponCheckDoll = new CheckBox(),
            weaponCheckRemilia = new CheckBox(),
            weaponCheckReisen = new CheckBox(),
            weaponCheckSakuya = new CheckBox(),
            weaponCheckEirin = new CheckBox(),
            weaponCheckYuyuko = new CheckBox(),
            weaponCheckCirno = new CheckBox(),
            weaponCheckYoumu = new CheckBox(),
            weaponCheckReimu = new CheckBox(),
            weaponCheckBroom = new CheckBox(),
            checkHealth = new CheckBox(),
            checkLives = new CheckBox(),
            checkEarlyBroom = new CheckBox(),
            checkIframes = new CheckBox();
        private ComboBox comboSaves = new ComboBox(),
            comboWarp = new ComboBox();
        private PictureBox weaponBoxEirin = new PictureBox(),
            weaponBoxSakuya = new PictureBox(),
            weaponBoxReisen = new PictureBox(),
            weaponBoxDoll = new PictureBox(),
            weaponBoxRemilia = new PictureBox(),
            weaponBoxYuyuko = new PictureBox(),
            weaponBoxCirno = new PictureBox(),
            weaponBoxYoumu = new PictureBox(),
            weaponBoxBroom = new PictureBox(),
            weaponBoxReimu = new PictureBox(),
            tankBox1 = new PictureBox(),
            tankBox2 = new PictureBox(),
            tankBox3 = new PictureBox(),
            tankBox4 = new PictureBox();

        #endregion
    }
}
