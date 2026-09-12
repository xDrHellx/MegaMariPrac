using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

using MegaMariPrac.About;
using MegaMariPrac.Hotkeys;
using MegaMariPrac.SaveStates;
using MegaMariPrac.Dictionnaries;

namespace MegaMariPrac
{
    public partial class MainForm : Form
    {
        #region global variables
        static string appdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            hotkeyVersion = "v1.0";
        string configpath = appdata + @"\MegaMariPrac\",
            hotkeyfilename = "hotkey.cfg",
            savestatesfilename = "savestates.cfg";

        readonly MemoryFlags _memFlags = new MemoryFlags();
        SaveState ss = new SaveState();
        static int numberHotkeys = 6;
        KeyboardKeys keybKeys = new KeyboardKeys();
        List<int> lstHotkeys = new List<int>();

        short curCharacter = 0, bossHP = 0;
        int screenType = 0, stageID = 255, state = 255,
            flagBroom = 255, flagDoll = 255, flagReimu = 255, flagCirno = 255, flagSakuya = 255,
            flagRemilia = 255, flagYoumu = 255, flagYuyuko = 255, flagReisen = 255, flagEirin = 255,
            flagTank1 = 0, flagTank2 = 0, flagTank3 = 0, flagTank4 = 0;
        float XF = 0, YF = 0;
        uint screenTimer = 0;
        #endregion

        #region memory stuff
        static ProcessMemory pm = new ProcessMemory();

        //first offsets - these are added to "megamari.exe" when reading/writing
        int FIRST_OFFSET = 0xDB0D4; //general first offset
        int FIRST_OFFSET_BOSS_HP = 0xCF708; //for some reason, boss hp requires a different first offset

        //static addresses
        int STATE = 0xDD6C0;
        int STAGE_ID = 0xDD6C4;
        int SCREEN_TYPE = 0xE3614;
        int DELAY = 0xDD6D4, SCREEN_TIMER = 0xDD6D8;

        //second offsets added to the result of "megamari.exe" + first offset, resulting in a pointer to certain a certain value
        int X_OFFSET = 0x70, Y_OFFSET = 0x74;
        int CAMERA_X_1_OFFSET = 0xF480, CAMERA_Y_1_OFFSET = 0xF484, CAMERA_X_2_OFFSET = 0xF488, CAMERA_Y_2_OFFSET = 0xF48C;
        int CAMERA_VIEW_X_OFFSET = 0xF3B8, CAMERA_VIEW_Y_OFFSET = 0xF3BC;
        int CHECKPOINT_OFFSET = 0xF478;
        int MENU_TANK_SLOT_1_OFFSET = 0xDD, MENU_TANK_SLOT_2_OFFSET = 0xDE, MENU_TANK_SLOT_3_OFFSET = 0xDF, MENU_TANK_SLOT_4_OFFSET = 0xE0;
        int MENU_PANE_OFFSET = 0xDC, MENU_TANKS_OFFSET = 0xDD, MENU_CURSOR_OFFSET = 0x12C;
        int LIVES_OFFSET = 0xD4, IFRAMES_OFFSET = 0x128, SPEED_OFFSET = 0xB8,
            MARISA_HP_OFFSET = 0xCC, ALICE_HP_OFFSET = 0xD0;
        int REIMU_FLAG_OFFSET = 0xE1, REMILIA_FLAG_OFFSET = 0xE2, YOUMU_FLAG_OFFSET = 0xE3, REISEN_FLAG_OFFSET = 0xE4,
            CIRNO_FLAG_OFFSET = 0xE5, SAKUYA_FLAG_OFFSET = 0xE6, YUYUKO_FLAG_OFFSET = 0xE7, EIRIN_FLAG_OFFSET = 0xE8;
        int BROOM_FLAG_OFFSET = 0xE9, DOLL_FLAG_OFFSET = 0xEA;
        int REIMU_AMMO_OFFSET = 0xEC, REMILIA_AMMO_OFFSET = 0xF0, YOUMU_AMMO_OFFSET = 0xF4, REISEN_AMMO_OFFSET = 0xF8,
            CIRNO_AMMO_OFFSET = 0xFC, SAKUYA_AMMO_OFFSET = 0x100, YUYUKO_AMMO_OFFSET = 0x104, EIRIN_AMMO_OFFSET = 0x108,
            BROOM_AMMO_OFFSET = 0x10C, DOLL_AMMO_OFFSET = 0x110;
        int CHARACTER_OFFSET = 0xC9,
            CHARACTER_SPRITE_OFFSET = 0x68,
            CHARACTER_WEAPON_OFFSET = 0x131;

        #endregion

        #region form
        public MainForm()
        {
            InitializeComponent();
            MinimizeBox = MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            LoadHotkeys();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (!Directory.Exists(appdata + @"\MegaMariPrac"))
                Directory.CreateDirectory(appdata + @"\MegaMariPrac");

            // Add tooltip to elements
            toolTip.SetToolTip(checkFreezeAll, "Checks all weapon checkboxes below and forces ammo for all of them at maximum.");
            toolTip.SetToolTip(checkHealth, "Forces health for both Marisa and Alice at maximum.");
            toolTip.SetToolTip(checkLives, "Freezes lives at 2.");
            toolTip.SetToolTip(checkIframes, "Gives infinite invincibility frames.");
            toolTip.SetToolTip(buttonDie, "Die.");
            toolTip.SetToolTip(buttonGameOver, "Instantly go to the game over screen.");
            toolTip.SetToolTip(buttonWin, "Initiates the winning fanfare and brings the user to the stage select screen.\nIf used outside Patchouli stages, the currently used character will receive the stage's boss weapon.");
            toolTip.SetToolTip(buttonCheckpoint, "Cycles through each checkpoint of the stage in the following order: Starting point -> Checkpoint -> Boss.");
            toolTip.SetToolTip(buttonStore, "Stores the following values into memory: Coordinates, HP, Lives, Tanks and Weapon flags/ammo.");
            toolTip.SetToolTip(buttonLoad, "Loads previously stored values from memory.");
            toolTip.SetToolTip(buttonSave, "Stores values into the savestates.cfg file, memory and the dropdown list below.");
            toolTip.SetToolTip(buttonDelete, "Deletes a save state from the savestates.cfg file and the dropwdown list below.");
            toolTip.SetToolTip(comboSaves, "Selecting an entry from this dropdown list will load all values attached to it.");
            toolTip.SetToolTip(checkEarlyBroom, "Checking this will load the early broom route into the drowndown list on the right.");
            toolTip.SetToolTip(buttonWarp, "Loads the selected stage from the dropdown list. Requires the user to select 'Continue' afterwards.\nAlso gives characters their appropriate weapons based on the speedrun route.");

            if (!File.Exists(configpath + savestatesfilename)) //checks if savestatesfilename.cfg doesn't exists
            {
                using (StreamWriter sw = File.CreateText(configpath + savestatesfilename)) //creates the save state file template
                {
                    sw.WriteLine("[Reimu-0]\n"); sw.WriteLine("[Cirno-1]\n");
                    sw.WriteLine("[Sakuya-2]\n"); sw.WriteLine("[Remilia-3]\n");
                    sw.WriteLine("[Youmu-4]\n"); sw.WriteLine("[Yuyuko-5]\n");
                    sw.WriteLine("[Reisen-6]\n"); sw.WriteLine("[Eirin-7]\n");
                    sw.WriteLine("[Patchouli 1-8]\n"); sw.WriteLine("[Patchouli 2-9]\n");
                    sw.WriteLine("[Patchouli 3-12]\n"); sw.WriteLine("[Patchouli 4-13]\n");
                    sw.WriteLine("[Patchouli 5-10]\n"); sw.WriteLine("[Patchouli 6-11]\n");
                }
            }
            else //if savestates.cfg exists, run a quick cleanup to remove empty lines that might be in the wrong spots
            {
                List<string> lst_lines = new List<string>();
                using (StreamReader sr = File.OpenText(configpath + savestatesfilename))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        if (line.Length > 0)
                        {
                            if (line.Contains("["))
                            {
                                lst_lines.Add(""); //add an empty line before each stage ID
                                lst_lines.Add(line);
                            }
                            else
                            {
                                lst_lines.Add(line); //a save state line
                            }
                        }
                    }
                }
                lst_lines.RemoveAt(0); //removes the very first line which is empty
                File.WriteAllLines(configpath + savestatesfilename, lst_lines.ToArray()); //write the new lines to the file
            }

            //enables controls when playing and disables them when title screen/stage select
            new Thread(ManageControls) { IsBackground = true }.Start();
            //this thread will read values from the game
            new Thread(ReadValues) { IsBackground = true }.Start();
        }
        #endregion

        #region threads
        private void ManageControls()
        {
            bool inStage = false;
            while (true)
            {
                try
                {
                    Invoke((MethodInvoker)delegate //using this because thread
                    {
                        if (screenType == Constants.Screens.STAGE) //if marisa is in a stage
                        {
                            if (curCharacter == Constants.MARISA)
                            {
                                labelStatus.ForeColor = Color.Gold;
                                labelStatus.Text = "Marisa is in " + Constants.Stages.stageNames[stageID] + "'s stage";
                            }
                            else
                            {
                                labelStatus.ForeColor = Color.FromArgb(130, 115, 255);
                                labelStatus.Text = "Alice is in " + Constants.Stages.stageNames[stageID] + "'s stage";
                            }
                            if (!inStage)
                            {
                                foreach (Control group in Controls)
                                {
                                    if (group is GroupBox)
                                    {
                                        switch (group.Name)
                                        {
                                            case "groupCoordinates":
                                                foreach (Control c in group.Controls)
                                                {
                                                    if (c is Button || c is TextBox) c.Enabled = true;
                                                    if (c is TextBox) c.Text = string.Empty;
                                                }
                                                break;
                                            default:
                                                foreach (Control c in group.Controls) c.Enabled = true; break;
                                        }
                                    }
                                }

                                UpdateComboSaveStates(true);
                                StoreValues();

                                new Thread(Coordinates) { IsBackground = true }.Start();
                                new Thread(Timers) { IsBackground = true }.Start();
                                new Thread(Freeze) { IsBackground = true }.Start();
                                new Thread(Track) { IsBackground = true }.Start();
                                new Thread(EnableWeaponTankIcons) { IsBackground = true }.Start();
                                new Thread(Hotkeys) { IsBackground = true }.Start();
                                inStage = true;
                            }
                        }
                        else
                        {
                            if (screenType == Constants.Screens.STAGE_SELECT)
                            {
                                labelStatus.Text = "Stage select...";
                                labelStatus.ForeColor = Color.Cyan;
                            }
                            else if (screenType == Constants.Screens.STAGE_LOADING)
                            {
                                pm.WriteStatic(SCREEN_TYPE, BitConverter.GetBytes(Constants.Screens.STAGE)); //forces te stage to show up right away
                            }
                            else
                            {
                                labelStatus.Text = "Marisa is on the title screen...";
                                labelStatus.ForeColor = Color.LightGreen;
                            }
                            if (inStage)
                            {
                                weaponBoxBroom.Image = Properties.Resources.broom_off; weaponBoxDoll.Image = Properties.Resources.doll_off;
                                weaponBoxReimu.Image = Properties.Resources.reimu_off; weaponBoxRemilia.Image = Properties.Resources.remilia_off;
                                weaponBoxYoumu.Image = Properties.Resources.youmu_off; weaponBoxReisen.Image = Properties.Resources.reisen_off;
                                weaponBoxCirno.Image = Properties.Resources.cirno_off; weaponBoxSakuya.Image = Properties.Resources.sakuya_off;
                                weaponBoxYuyuko.Image = Properties.Resources.yuyuko_off; weaponBoxEirin.Image = Properties.Resources.eirin_off;
                                tankBox1.Image = Properties.Resources.tank_off; tankBox2.Image = Properties.Resources.tank_off;
                                tankBox3.Image = Properties.Resources.tank_off; tankBox4.Image = Properties.Resources.tank_off;

                                foreach (Control group in Controls)
                                {
                                    if (group is GroupBox)
                                    {
                                        switch (group.Name)
                                        {
                                            case "groupCoordinates":
                                                foreach (Control c in group.Controls)
                                                {
                                                    if (c is Button || c is TextBox) c.Enabled = false;
                                                    if (c is TextBox) c.Text = string.Empty;
                                                }
                                                break;
                                            default:
                                                foreach (Control c in group.Controls) c.Enabled = false; break;
                                        }
                                    }
                                }

                                comboSaves.Items.Clear();
                                labelX.Text = "X:"; labelY.Text = "Y:"; labelStoredX.Text = "X:"; labelStoredY.Text = "Y:";
                                labelScreenTime.Text = "00:00:00"; labelLastScreenTime.Text = "00:00:00";
                                inStage = false;
                            }
                        }
                    });
                }
                catch (Exception ex)
                {
                    if (ex is ObjectDisposedException || ex is InvalidOperationException)
                        Console.WriteLine(ex.Message);
                }
                Thread.Sleep(100);
            }
        }

        private void Hotkeys()
        {
            byte[] modifier1 = new byte[1], modifier2 = new byte[1], modifier3 = new byte[1],
                   modifier4 = new byte[1], modifier5 = new byte[1], modifier6 = new byte[1],
                   key1 = new byte[1], key2 = new byte[1], key3 = new byte[1],
                   key4 = new byte[1], key5 = new byte[1], key6 = new byte[1];

            while (true)
            {
                if (lstHotkeys[0] != 0) modifier1 = pm.ReadStatic(lstHotkeys[0], modifier1); else modifier1[0] = 128;
                if (lstHotkeys[2] != 0) modifier2 = pm.ReadStatic(lstHotkeys[2], modifier2); else modifier2[0] = 128;
                if (lstHotkeys[4] != 0) modifier3 = pm.ReadStatic(lstHotkeys[4], modifier3); else modifier3[0] = 128;
                if (lstHotkeys[6] != 0) modifier4 = pm.ReadStatic(lstHotkeys[6], modifier4); else modifier4[0] = 128;
                if (lstHotkeys[8] != 0) modifier5 = pm.ReadStatic(lstHotkeys[8], modifier5); else modifier5[0] = 128;
                if (lstHotkeys[10] != 0) modifier6 = pm.ReadStatic(lstHotkeys[10], modifier6); else modifier6[0] = 128;

                key1 = pm.ReadStatic(lstHotkeys[1], key1); key2 = pm.ReadStatic(lstHotkeys[3], key2);
                key3 = pm.ReadStatic(lstHotkeys[5], key3); key4 = pm.ReadStatic(lstHotkeys[7], key4);
                key5 = pm.ReadStatic(lstHotkeys[9], key5); key6 = pm.ReadStatic(lstHotkeys[11], key6);

                bool isHotkey1Pressed = modifier1[0] == 128 && key1[0] == 128;
                bool isHotkey2Pressed = modifier2[0] == 128 && key2[0] == 128;
                bool isHotkey3Pressed = modifier3[0] == 128 && key3[0] == 128;
                bool isHotkey4Pressed = modifier4[0] == 128 && key4[0] == 128;
                bool isHotkey5Pressed = modifier5[0] == 128 && key5[0] == 128;
                bool isHotkey6Pressed = modifier6[0] == 128 && key6[0] == 128;

                if (isHotkey1Pressed) { StoreValues(); comboSaves.SelectedIndex = -1; }
                if (isHotkey2Pressed) { LoadStoredValues(); }
                if (isHotkey3Pressed) { LoadNextSaveState(); }
                if (isHotkey4Pressed) { buttonDie_Click(null, null); }
                if (isHotkey5Pressed) { buttonCheckpoint_Click(null, null); }
                if (isHotkey6Pressed) { LoadNextStage(); }

                Thread.Sleep(75);

                if (screenType == Constants.Screens.TITLE_SCREEN || screenType == Constants.Screens.STAGE_SELECT || screenType == Constants.Screens.STAGE_LOADING)
                {
                    print("Exiting thread " + System.Reflection.MethodBase.GetCurrentMethod().Name);
                    break;
                }
            }
        }

        private void ReadValues()
        {
            while (true)
            {
                byte[] buffer = pm.Read(FIRST_OFFSET, X_OFFSET); XF = BitConverter.ToSingle(buffer, 0); //convert to float
                buffer = pm.Read(FIRST_OFFSET, Y_OFFSET); YF = BitConverter.ToSingle(buffer, 0); //convert to float

                buffer = pm.ReadStatic(STATE, buffer); state = buffer[0];
                buffer = pm.ReadStatic(SCREEN_TYPE, buffer); screenType = buffer[0];
                buffer = pm.ReadStatic(STAGE_ID, buffer); stageID = buffer[0];
                buffer = pm.ReadStatic(SCREEN_TIMER, buffer); screenTimer = BitConverter.ToUInt32(buffer, 0);

                buffer = pm.Read(FIRST_OFFSET, CHARACTER_OFFSET); curCharacter = BitConverter.ToInt16(buffer, 0);
                buffer = pm.Read(FIRST_OFFSET, BROOM_FLAG_OFFSET); flagBroom = buffer[0];
                buffer = pm.Read(FIRST_OFFSET, DOLL_FLAG_OFFSET); flagDoll = buffer[0];
                buffer = pm.Read(FIRST_OFFSET, REIMU_FLAG_OFFSET); flagReimu = buffer[0];
                buffer = pm.Read(FIRST_OFFSET, CIRNO_FLAG_OFFSET); flagCirno = buffer[0];
                buffer = pm.Read(FIRST_OFFSET, SAKUYA_FLAG_OFFSET); flagSakuya = buffer[0];
                buffer = pm.Read(FIRST_OFFSET, REMILIA_FLAG_OFFSET); flagRemilia = buffer[0];
                buffer = pm.Read(FIRST_OFFSET, YOUMU_FLAG_OFFSET); flagYoumu = buffer[0];
                buffer = pm.Read(FIRST_OFFSET, YUYUKO_FLAG_OFFSET); flagYuyuko = buffer[0];
                buffer = pm.Read(FIRST_OFFSET, REISEN_FLAG_OFFSET); flagReisen = buffer[0];
                buffer = pm.Read(FIRST_OFFSET, EIRIN_FLAG_OFFSET); flagEirin = buffer[0];

                buffer = pm.Read(FIRST_OFFSET, MENU_TANK_SLOT_1_OFFSET); flagTank1 = buffer[0];
                buffer = pm.Read(FIRST_OFFSET, MENU_TANK_SLOT_2_OFFSET); flagTank2 = buffer[0];
                buffer = pm.Read(FIRST_OFFSET, MENU_TANK_SLOT_3_OFFSET); flagTank3 = buffer[0];
                buffer = pm.Read(FIRST_OFFSET, MENU_TANK_SLOT_4_OFFSET); flagTank4 = buffer[0];

                buffer = pm.Read(FIRST_OFFSET_BOSS_HP, 0x0); bossHP = BitConverter.ToInt16(buffer, 0);

                int sleep;
                if (screenType == Constants.Screens.TITLE_SCREEN || screenType == Constants.Screens.STAGE_SELECT || screenType == Constants.Screens.STAGE_LOADING) sleep = 100;
                else sleep = 1;
                Thread.Sleep(sleep);
            }
        }

        private void Coordinates()
        {
            while (true)
            {
                try
                {
                    Invoke((MethodInvoker)delegate //using this because thread
                    {
                        labelX.Text = "X: " + XF.ToString("0.000");
                        labelY.Text = "Y: " + YF.ToString("0.000");
                    });
                }
                catch (Exception ex)
                {
                    if (ex is ObjectDisposedException || ex is InvalidOperationException)
                        print(ex.Message);
                }
                if (screenType == Constants.Screens.TITLE_SCREEN || screenType == Constants.Screens.STAGE_SELECT || screenType == Constants.Screens.STAGE_LOADING)
                {
                    print("Exiting thread " + System.Reflection.MethodBase.GetCurrentMethod().Name);
                    break;
                }
                Thread.Sleep(25);
            }
        }

        private void Timers()
        {
            TimeSpan t = new TimeSpan();
            uint tempTimer = 0;
            while (true)
            {
                t = TimeSpan.FromSeconds((double)screenTimer / 60);
                string stringScreenTimer = t.Minutes.ToString("D2") + ":" + t.Seconds.ToString("D2") + "." + t.Milliseconds.ToString("D3");
                try
                {
                    Invoke((MethodInvoker)delegate //using this because thread
                    {
                        if (tempTimer > screenTimer)
                        {
                            t = TimeSpan.FromSeconds((double)tempTimer / 60);
                            string stringLastScreenTime = t.Minutes.ToString("D2") + ":" + t.Seconds.ToString("D2") + "." + t.Milliseconds.ToString("D3");
                            labelLastScreenTime.Text = stringLastScreenTime;
                        }
                        labelScreenTime.Text = stringScreenTimer;
                    });
                }
                catch (Exception ex)
                {
                    if (ex is ObjectDisposedException || ex is InvalidOperationException)
                        print(ex.Message);
                }
                tempTimer = screenTimer;
                if (screenType == Constants.Screens.TITLE_SCREEN || screenType == Constants.Screens.STAGE_SELECT || screenType == Constants.Screens.STAGE_LOADING)
                {
                    print("Exiting thread " + System.Reflection.MethodBase.GetCurrentMethod().Name);
                    break;
                }
                Thread.Sleep(25);
            }
        }

        private void Freeze()
        {
            while (true)
            {
                if (weaponCheckBroom.Checked) pm.Write(FIRST_OFFSET, BROOM_AMMO_OFFSET, BitConverter.GetBytes(Constants.FULL_AMMO));
                if (weaponCheckDoll.Checked) pm.Write(FIRST_OFFSET, DOLL_AMMO_OFFSET, BitConverter.GetBytes(Constants.FULL_AMMO));
                if (weaponCheckReimu.Checked) pm.Write(FIRST_OFFSET, REIMU_AMMO_OFFSET, BitConverter.GetBytes(Constants.FULL_AMMO));
                if (weaponCheckRemilia.Checked) pm.Write(FIRST_OFFSET, REMILIA_AMMO_OFFSET, BitConverter.GetBytes(Constants.FULL_AMMO));
                if (weaponCheckYoumu.Checked) pm.Write(FIRST_OFFSET, YOUMU_AMMO_OFFSET, BitConverter.GetBytes(Constants.FULL_AMMO));
                if (weaponCheckReisen.Checked) pm.Write(FIRST_OFFSET, REISEN_AMMO_OFFSET, BitConverter.GetBytes(Constants.FULL_AMMO));
                if (weaponCheckCirno.Checked) pm.Write(FIRST_OFFSET, CIRNO_AMMO_OFFSET, BitConverter.GetBytes(Constants.FULL_AMMO));
                if (weaponCheckSakuya.Checked) pm.Write(FIRST_OFFSET, SAKUYA_AMMO_OFFSET, BitConverter.GetBytes(Constants.FULL_AMMO));
                if (weaponCheckYuyuko.Checked) pm.Write(FIRST_OFFSET, YUYUKO_AMMO_OFFSET, BitConverter.GetBytes(Constants.FULL_AMMO));
                if (weaponCheckEirin.Checked) pm.Write(FIRST_OFFSET, EIRIN_AMMO_OFFSET, BitConverter.GetBytes(Constants.FULL_AMMO));

                if (checkHealth.Checked)
                {
                    pm.Write(FIRST_OFFSET, MARISA_HP_OFFSET, BitConverter.GetBytes(Constants.FULL_HP));
                    pm.Write(FIRST_OFFSET, ALICE_HP_OFFSET, BitConverter.GetBytes(Constants.FULL_HP));
                }

                if (checkLives.Checked)
                    pm.Write(FIRST_OFFSET, LIVES_OFFSET, BitConverter.GetBytes(2));

                if (checkIframes.Checked)
                    pm.Write(FIRST_OFFSET, IFRAMES_OFFSET, BitConverter.GetBytes(200));

                if (screenType == Constants.Screens.TITLE_SCREEN || screenType == Constants.Screens.STAGE_SELECT || screenType == Constants.Screens.STAGE_LOADING)
                {
                    print("Exiting thread " + System.Reflection.MethodBase.GetCurrentMethod().Name);
                    break;
                }
                Thread.Sleep(100);
            }
        }

        private void Track()
        {
            while (true)
            {
                if (screenType == Constants.Screens.STAGE && state == Constants.GameStates.DEAD) //track death
                {
                    //fast respawn
                    pm.WriteStatic(STATE, BitConverter.GetBytes(Constants.GameStates.DEAD));
                    pm.WriteStatic(DELAY, BitConverter.GetBytes(240));
                    Thread.Sleep(100);
                    pm.WriteStatic(STATE, BitConverter.GetBytes(Constants.GameStates.READY));
                    pm.WriteStatic(DELAY, BitConverter.GetBytes(120));
                    LoadStoredValues();
                }

                try //track boss hp
                {
                    Invoke((MethodInvoker)delegate //using this because thread
                    {
                        if (bossHP >= 0 && bossHP <= 280)
                        {
                            barBossHP.Value = bossHP;
                            labelBossHp.Text = bossHP.ToString();
                        }
                    });
                }
                catch (Exception ex)
                {
                    if (ex is ObjectDisposedException || ex is InvalidOperationException)
                        print(ex.Message);
                }

                if (screenType == Constants.Screens.TITLE_SCREEN || screenType == Constants.Screens.STAGE_SELECT || screenType == Constants.Screens.STAGE_LOADING)
                {
                    print("Exiting thread " + System.Reflection.MethodBase.GetCurrentMethod().Name);
                    break;
                }
                Thread.Sleep(100);
            }
        }

        private void EnableWeaponTankIcons()
        {
            while (true)
            {
                _memFlags.SetWeaponFlags(flagBroom, flagDoll, flagReimu, flagRemilia, flagYoumu, flagReisen, flagCirno, flagSakuya, flagYuyuko, flagEirin);

                EnableIcon(flagBroom, "broom", weaponBoxBroom, false);
                EnableIcon(flagDoll, "doll", weaponBoxDoll, false);
                EnableIcon(flagReimu, "reimu", weaponBoxReimu);
                EnableIcon(flagRemilia, "remilia", weaponBoxRemilia);
                EnableIcon(flagYoumu, "youmu", weaponBoxYoumu);
                EnableIcon(flagReisen, "reisen", weaponBoxReisen);
                EnableIcon(flagCirno, "cirno", weaponBoxCirno);
                EnableIcon(flagSakuya, "sakuya", weaponBoxSakuya);
                EnableIcon(flagYuyuko, "yuyuko", weaponBoxYuyuko);
                EnableIcon(flagEirin, "eirin", weaponBoxEirin);

                EnableIcon(flagTank1, box: tankBox1, isTank: true); EnableIcon(flagTank2, box: tankBox2, isTank: true);
                EnableIcon(flagTank3, box: tankBox3, isTank: true); EnableIcon(flagTank4, box: tankBox4, isTank: true);

                if (screenType == Constants.Screens.TITLE_SCREEN || screenType == Constants.Screens.STAGE_SELECT || screenType == Constants.Screens.STAGE_LOADING)
                {
                    print("Exiting thread " + System.Reflection.MethodBase.GetCurrentMethod().Name);
                    break;
                }
                Thread.Sleep(250);
            }
        }

        private void EnableIcon(int flag = 0, string character = "", PictureBox box = null, bool regularWeapon = true, bool isTank = false)
        {
            try
            {
                if (!isTank)
                {
                    object iconResource = null;
                    if (regularWeapon)
                    {
                        switch (flag)
                        {
                            case Constants.BossWeaponOn.NOBODY:
                                iconResource = (Image)Properties.Resources.ResourceManager.GetObject(character + "_off");
                                break;
                            case Constants.BossWeaponOn.MARISA:
                                iconResource = (Image)Properties.Resources.ResourceManager.GetObject(character + "_on_marisa");
                                break;
                            case Constants.BossWeaponOn.ALICE:
                                iconResource = (Image)Properties.Resources.ResourceManager.GetObject(character + "_on_alice");
                                break;
                        }
                    }
                    else
                    {
                        switch (flag)
                        {
                            case Constants.SpecialWeapon.OFF:
                                iconResource = (Image)Properties.Resources.ResourceManager.GetObject(character + "_off");
                                break;
                            case Constants.SpecialWeapon.ON:
                                iconResource = (Image)Properties.Resources.ResourceManager.GetObject(character + "_on");
                                break;
                        }
                    }

                    // If the resource img was retrieved, set it
                    if (iconResource is Image icon)
                    {
                        // Get rid of the old icon to prevent memory leaks
                        box.Image?.Dispose();

                        // Assign a copy of the icon to prevent sharing the same object in memory (which will be "locked" and cause an error over time)
                        box.Image = new Bitmap(icon);
                    }
                }
                else
                {
                    switch (flag)
                    {
                        case Constants.Etanks.NO_TANK: box.Image = Properties.Resources.tank_off; break;
                        case Constants.Etanks.ETANK: box.Image = Properties.Resources.etank; break;
                        case Constants.Etanks.STAR_TANK: box.Image = Properties.Resources.startank; break;
                        case Constants.Etanks.DOUBLE_ETANK: box.Image = Properties.Resources.doubletank; break;
                    }
                }
            }
            catch (InvalidOperationException ex) { print(ex.Message); }
        }
        #endregion

        #region buttons
        private void buttonStore_Click(object sender, EventArgs e)
        {
            // If in a stage
            if (screenType == Constants.Screens.STAGE && state == Constants.GameStates.PLAYING)
                StoreValues();
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            // If in a stage
            if (screenType == Constants.Screens.STAGE && state == Constants.GameStates.PLAYING)
                LoadStoredValues();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (File.Exists(configpath + savestatesfilename)) //checks if savestates.cfg exists
            {
                //find the line number of the line to delete
                int lineNumber = 0;
                using (StreamReader sr = File.OpenText(configpath + savestatesfilename))
                {
                    while (!sr.EndOfStream)
                    {
                        //leave the loop once the line to remove is found
                        string line = sr.ReadLine();
                        if (line == comboSaves.Text)
                            break;
                        lineNumber++;
                    }
                }
                //read all save state lines into memory
                List<string> lines = File.ReadAllLines(configpath + savestatesfilename).ToList();
                lines.RemoveAt(lineNumber);
                File.WriteAllLines(configpath + savestatesfilename, lines); //write the new lines to the file
                UpdateComboSaveStates(true);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            using (SaveStateName ssname = new SaveStateName())
            {
                if (ssname.ShowDialog() == DialogResult.OK)
                {
                    bool sectionFound = false;
                    int lineNumber = 0;

                    if (File.Exists(configpath + savestatesfilename)) //checks if savestates.cfg exists
                    {
                        //find the line number to which the new line needs to be inserted
                        using (StreamReader sr = File.OpenText(configpath + savestatesfilename))
                        {
                            while (!sr.EndOfStream)
                            {
                                string line = sr.ReadLine();

                                if (line.Length > 0)
                                    if (line.Contains("[") && sectionFound)
                                        break;
                                if (line.Contains(Constants.Stages.stageNames[stageID] + "-" + stageID))
                                    sectionFound = true;

                                lineNumber++;
                            }
                        }
                        //read all save state lines into memory
                        List<string> lines = File.ReadAllLines(configpath + savestatesfilename).ToList();
                        //insert the desired line at the number found - 1
                        StoreValues();
                        lines.Insert(lineNumber - 1, ssname.name + " | " + ss.ToString());
                        File.WriteAllLines(configpath + savestatesfilename, lines); //write the new lines to the file
                        UpdateComboSaveStates(false);
                    }
                }
            }
        }

        private void buttonGameOver_Click(object sender, EventArgs e)
        {
            //fast respawn
            checkLives.Checked = false;
            pm.Write(FIRST_OFFSET, LIVES_OFFSET, BitConverter.GetBytes(0));
            pm.WriteStatic(STATE, BitConverter.GetBytes(Constants.GameStates.DEAD));
            pm.WriteStatic(DELAY, BitConverter.GetBytes(240));
            for (int i = 0; i < 5000; i++)
                pm.WriteStatic(SCREEN_TYPE, BitConverter.GetBytes(Constants.Screens.CONTINUE));
        }

        private void buttonWin_Click(object sender, EventArgs e)
        {
            pm.WriteStatic(STATE, BitConverter.GetBytes(Constants.GameStates.WIN_FANFARE));
            Thread.Sleep(250);
            pm.WriteStatic(DELAY, BitConverter.GetBytes(220));
            Thread.Sleep(250);
            pm.WriteStatic(DELAY, BitConverter.GetBytes(150));
            for (int i = 0; i < 5000; i++)
                pm.WriteStatic(SCREEN_TYPE, BitConverter.GetBytes(Constants.Screens.WEAPON_GET));
        }

        private void buttonDie_Click(object sender, EventArgs e)
        {
            //fast respawn
            pm.Write(FIRST_OFFSET, LIVES_OFFSET, BitConverter.GetBytes(3));
            pm.WriteStatic(STATE, BitConverter.GetBytes(Constants.GameStates.DEAD));
            pm.WriteStatic(DELAY, BitConverter.GetBytes(240));
            Thread.Sleep(100);
            pm.WriteStatic(STATE, BitConverter.GetBytes(Constants.GameStates.READY));
            pm.WriteStatic(DELAY, BitConverter.GetBytes(120));
        }

        private void buttonCheckpoint_Click(object sender, EventArgs e)
        {
            //fast respawn
            int checkpoint = pm.Read(FIRST_OFFSET, CHECKPOINT_OFFSET)[0];
            if (stageID != Constants.Stages.PATCHY_6)
            {
                switch (checkpoint)
                {
                    case Constants.Checkpoints.START: pm.Write(FIRST_OFFSET, CHECKPOINT_OFFSET, new byte[1] { Constants.Checkpoints.CHECKPOINT }); break;
                    case Constants.Checkpoints.CHECKPOINT: pm.Write(FIRST_OFFSET, CHECKPOINT_OFFSET, new byte[1] { Constants.Checkpoints.BOSS }); break;
                    case Constants.Checkpoints.BOSS: pm.Write(FIRST_OFFSET, CHECKPOINT_OFFSET, new byte[1] { Constants.Checkpoints.START }); break;
                }
            }
            else //patchy 6 stage only has 2 checkpoints
            {
                switch (checkpoint)
                {
                    case Constants.Checkpoints.START: pm.Write(FIRST_OFFSET, CHECKPOINT_OFFSET, new byte[1] { Constants.Checkpoints.CHECKPOINT }); break;
                    case Constants.Checkpoints.CHECKPOINT: pm.Write(FIRST_OFFSET, CHECKPOINT_OFFSET, new byte[1] { Constants.Checkpoints.START }); break;
                }
            }
            pm.Write(FIRST_OFFSET, LIVES_OFFSET, BitConverter.GetBytes(3));
            pm.WriteStatic(STATE, BitConverter.GetBytes(Constants.GameStates.DEAD));
            pm.WriteStatic(DELAY, BitConverter.GetBytes(240));
            Thread.Sleep(100);
            pm.WriteStatic(STATE, BitConverter.GetBytes(Constants.GameStates.READY));
            pm.WriteStatic(DELAY, BitConverter.GetBytes(120));
        }

        private void weaponBox_Click(object sender, EventArgs e)
        {
            PictureBox s = (PictureBox)sender;
            switch (s.Name)
            {
                case "weaponBoxBroom": SetWeapon(BROOM_FLAG_OFFSET, flagBroom, false); break;
                case "weaponBoxDoll": SetWeapon(DOLL_FLAG_OFFSET, flagDoll, false); break;
                case "weaponBoxReimu": SetWeapon(REIMU_FLAG_OFFSET, flagReimu, true); break;
                case "weaponBoxRemilia": SetWeapon(REMILIA_FLAG_OFFSET, flagRemilia, true); break;
                case "weaponBoxYoumu": SetWeapon(YOUMU_FLAG_OFFSET, flagYoumu, true); break;
                case "weaponBoxReisen": SetWeapon(REISEN_FLAG_OFFSET, flagReisen, true); break;
                case "weaponBoxCirno": SetWeapon(CIRNO_FLAG_OFFSET, flagCirno, true); break;
                case "weaponBoxSakuya": SetWeapon(SAKUYA_FLAG_OFFSET, flagSakuya, true); break;
                case "weaponBoxYuyuko": SetWeapon(YUYUKO_FLAG_OFFSET, flagYuyuko, true); break;
                case "weaponBoxEirin": SetWeapon(EIRIN_FLAG_OFFSET, flagEirin, true); break;
            }
        }

        private void tankBox_Click(object sender, EventArgs e)
        {
            PictureBox s = (PictureBox)sender;
            switch (s.Name)
            {
                case "tankBox1": SetTank(MENU_TANK_SLOT_1_OFFSET, tankBox1); break;
                case "tankBox2": SetTank(MENU_TANK_SLOT_2_OFFSET, tankBox2); break;
                case "tankBox3": SetTank(MENU_TANK_SLOT_3_OFFSET, tankBox3); break;
                case "tankBox4": SetTank(MENU_TANK_SLOT_4_OFFSET, tankBox4); break;
            }
        }
        #endregion

        #region menustrip
        private void applicationFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", configpath);
        }

        private void helpAboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox about = new AboutBox();
            about.ShowDialog();
        }

        private void hotkeysToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HotkeyDialog hd = new HotkeyDialog();
            hd.ShowDialog();
            LoadHotkeys();
        }
        #endregion

        #region states

        /// <summary>Update the savestates shown in dropdown by updating savestates.cfg</summary>
        /// <param name="first">Indicate if first line in savestates.cfg for that stage</param>
        private void UpdateComboSaveStates(bool first)
        {
            if (Constants.Stages.stageNames.ContainsKey(stageID))
            {
                bool sectionFound = false;
                if (File.Exists(configpath + savestatesfilename)) //checks if savestates.cfg exists
                {
                    comboSaves.Items.Clear();
                    using (StreamReader sr = File.OpenText(configpath + savestatesfilename))
                    {
                        while (!sr.EndOfStream)
                        {
                            //skip empty lines
                            string line = sr.ReadLine();
                            if (line.Length > 0)
                            {
                                //if another section is reached after the desired one is parsed
                                if (line.Contains("[") && sectionFound)
                                    break;

                                //if flag is true then analyze the line to check its screenID
                                if (sectionFound)
                                    comboSaves.Items.Add(line);

                                //if reached the desired section -> set flag to true
                                if (line.Contains(Constants.Stages.stageNames[stageID] + "-" + stageID))
                                    sectionFound = true;
                            }
                        }

                        // If not first, remove the empty entry
                        if (first == true)
                        {
                            comboSaves.SelectedIndex = comboSaves.Items.Count - 1;
                        }
                        else
                        {
                            /**
                             * Reset the Text property of the dropdown
                             * Then deselect the chosen value
                             * 
                             * Resetting the property prevents a crash on Win10+
                             */
                            comboSaves.ResetText();
                            comboSaves.SelectedIndex = -1;
                        }
                    }
                }
            }
        }

        private void comboSaves_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string[] split = comboSaves.Text.Split('|');
            ss = new SaveState(split[1]);

            labelStoredX.Text = "X: " + ss.xF.ToString("0.000"); // X
            labelStoredY.Text = "Y: " + ss.yF.ToString("0.000"); // Y

            //weapon flags
            _memFlags.SetWeaponFlags(
                ss.broomFlag, ss.dollFlag, ss.reimuFlag, ss.remiliaFlag, ss.youmuFlag,
                ss.reisenFlag, ss.cirnoFlag, ss.sakuyaFlag, ss.yuyukoFlag, ss.eirinFlag
            );

            LoadStoredValues();
        }
        #endregion

        #region hotkeys
        private void WriteDefaultHotkeyConfig()
        {
            TextWriter writer = new StreamWriter(configpath + hotkeyfilename);
            writer.WriteLine(hotkeyVersion + "\nLAlt\n1\nLAlt\n2\nLAlt\n3\nLAlt\n4\nLAlt\n5\nLAlt\n6");
            writer.Close();
        }

        private void LoadHotkeys()
        {
            if (!Directory.Exists(configpath)) Directory.CreateDirectory(configpath);
            if (!File.Exists(configpath + hotkeyfilename))
                WriteDefaultHotkeyConfig();
            if (File.Exists(configpath + hotkeyfilename)) //checks if hotkey.cfg exists
            {
                if (File.ReadLines(configpath + hotkeyfilename).First().Contains(hotkeyVersion))
                {
                    using (StreamReader sr = File.OpenText(configpath + hotkeyfilename))
                    {
                        int modifier = 0;
                        lstHotkeys.Clear();
                        sr.ReadLine(); //skip the first line containing the version number
                        for (int i = 2; i <= numberHotkeys * 2 + 1; i++)
                        {
                            if (i % 2 == 0) //if the line number is even then it's a modifier
                            {
                                modifier = keybKeys.dictModifierKeys[sr.ReadLine()]; //this variable will hold the address of the modifier
                                lstHotkeys.Add(modifier);
                            }
                            else //if the line number is odd then it's a hotkey
                            {
                                lstHotkeys.Add(keybKeys.dictKeys[sr.ReadLine()]);
                            }
                        }
                    }
                    //foreach (int key in lstHotkeys) print(key.ToString("x"));
                }
                else
                {
                    MessageBox.Show("Some changes have been made to hotkeys. They have been set back to defaults.\n",
                                    "Hotkeys changed",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    WriteDefaultHotkeyConfig();
                }
            }
        }
        #endregion

        #region actions
        private void StoreValues()
        {
            if (screenType == Constants.Screens.STAGE && state == Constants.GameStates.PLAYING)
            {
                byte[] xPos = pm.Read(FIRST_OFFSET, X_OFFSET); //read x speed value
                byte[] yPos = pm.Read(FIRST_OFFSET, Y_OFFSET); //read y speed value

                ss = new SaveState(
                    x: BitConverter.ToInt32(pm.Read(FIRST_OFFSET, X_OFFSET), 0), y: BitConverter.ToInt32(pm.Read(FIRST_OFFSET, Y_OFFSET), 0),
                    xF: BitConverter.ToSingle(pm.Read(FIRST_OFFSET, X_OFFSET), 0), yF: BitConverter.ToSingle(pm.Read(FIRST_OFFSET, Y_OFFSET), 0),
                    camera1X: BitConverter.ToInt32(pm.Read(FIRST_OFFSET, CAMERA_X_1_OFFSET), 0),
                    camera1Y: BitConverter.ToInt32(pm.Read(FIRST_OFFSET, CAMERA_Y_1_OFFSET), 0),
                    camera2X: BitConverter.ToInt32(pm.Read(FIRST_OFFSET, CAMERA_X_2_OFFSET), 0),
                    camera2Y: BitConverter.ToInt32(pm.Read(FIRST_OFFSET, CAMERA_Y_2_OFFSET), 0),
                    cameraViewX: pm.Read(FIRST_OFFSET, CAMERA_VIEW_X_OFFSET)[0], cameraViewY: pm.Read(FIRST_OFFSET, CAMERA_VIEW_Y_OFFSET)[0],
                    marisaHP: pm.Read(FIRST_OFFSET, MARISA_HP_OFFSET)[0], aliceHP: pm.Read(FIRST_OFFSET, ALICE_HP_OFFSET)[0],
                    character: BitConverter.ToInt16(pm.Read(FIRST_OFFSET, CHARACTER_OFFSET), 0),
                    characterWeapon: pm.Read(FIRST_OFFSET, CHARACTER_WEAPON_OFFSET)[0],
                    characterSprite: BitConverter.ToInt16(pm.Read(FIRST_OFFSET, CHARACTER_SPRITE_OFFSET), 0),
                    broomAmmo: pm.Read(FIRST_OFFSET, BROOM_AMMO_OFFSET)[0], broomFlag: pm.Read(FIRST_OFFSET, BROOM_FLAG_OFFSET)[0],
                    cirnoAmmo: pm.Read(FIRST_OFFSET, CIRNO_AMMO_OFFSET)[0], cirnoFlag: pm.Read(FIRST_OFFSET, CIRNO_FLAG_OFFSET)[0],
                    dollAmmo: pm.Read(FIRST_OFFSET, DOLL_AMMO_OFFSET)[0], dollFlag: pm.Read(FIRST_OFFSET, DOLL_FLAG_OFFSET)[0],
                    eirinAmmo: pm.Read(FIRST_OFFSET, EIRIN_AMMO_OFFSET)[0], eirinFlag: pm.Read(FIRST_OFFSET, EIRIN_FLAG_OFFSET)[0],
                    reimuAmmo: pm.Read(FIRST_OFFSET, REIMU_AMMO_OFFSET)[0], reimuFlag: pm.Read(FIRST_OFFSET, REIMU_FLAG_OFFSET)[0],
                    reisenAmmo: pm.Read(FIRST_OFFSET, REISEN_AMMO_OFFSET)[0], reisenFlag: pm.Read(FIRST_OFFSET, REISEN_FLAG_OFFSET)[0],
                    remiliaAmmo: pm.Read(FIRST_OFFSET, REMILIA_AMMO_OFFSET)[0], remiliaFlag: pm.Read(FIRST_OFFSET, REMILIA_FLAG_OFFSET)[0],
                    sakuyaAmmo: pm.Read(FIRST_OFFSET, SAKUYA_AMMO_OFFSET)[0], sakuyaFlag: pm.Read(FIRST_OFFSET, SAKUYA_FLAG_OFFSET)[0],
                    youmuAmmo: pm.Read(FIRST_OFFSET, YOUMU_AMMO_OFFSET)[0], youmuFlag: pm.Read(FIRST_OFFSET, YOUMU_FLAG_OFFSET)[0],
                    yuyukoAmmo: pm.Read(FIRST_OFFSET, YUYUKO_AMMO_OFFSET)[0], yuyukoFlag: pm.Read(FIRST_OFFSET, YUYUKO_FLAG_OFFSET)[0],
                    menuCursor: BitConverter.ToInt32(pm.Read(FIRST_OFFSET, MENU_CURSOR_OFFSET), 0),
                    tanks: BitConverter.ToInt32(pm.Read(FIRST_OFFSET, MENU_TANKS_OFFSET), 0),
                    lives: pm.Read(FIRST_OFFSET, LIVES_OFFSET)[0]);

                try
                {
                    Invoke((MethodInvoker)delegate //using this because thread
                    {
                        labelStoredX.Text = "X: " + ss.xF.ToString("0.000");
                        labelStoredY.Text = "Y: " + ss.yF.ToString("0.000");
                    });
                }
                catch (Exception ex)
                {
                    if (ex is ObjectDisposedException || ex is InvalidOperationException)
                        print(ex.Message);
                }
            }
        }

        /// <summary>
        ///     Load stored values from within the game<br/>
        ///     <i>Note: this will force a game over</i>
        /// </summary>
        private void LoadStoredValues()
        {
            // If in a stage & the character has moved from the starting point
            if (screenType == Constants.Screens.STAGE && state == Constants.GameStates.PLAYING && ss.x != 1 && ss.y != 1)
            {
                pm.Write(FIRST_OFFSET, X_OFFSET, BitConverter.GetBytes(ss.x));
                pm.Write(FIRST_OFFSET, Y_OFFSET, BitConverter.GetBytes(ss.y));

                pm.Write(FIRST_OFFSET, CAMERA_VIEW_X_OFFSET, BitConverter.GetBytes(ss.cameraViewX));
                pm.Write(FIRST_OFFSET, CAMERA_VIEW_Y_OFFSET, BitConverter.GetBytes(ss.cameraViewY));
                pm.Write(FIRST_OFFSET, CAMERA_X_1_OFFSET, BitConverter.GetBytes(ss.camera1X));
                pm.Write(FIRST_OFFSET, CAMERA_Y_1_OFFSET, BitConverter.GetBytes(ss.camera1Y));
                pm.Write(FIRST_OFFSET, CAMERA_X_2_OFFSET, BitConverter.GetBytes(ss.camera2X));
                pm.Write(FIRST_OFFSET, CAMERA_Y_2_OFFSET, BitConverter.GetBytes(ss.camera2Y));

                pm.Write(FIRST_OFFSET, MARISA_HP_OFFSET, new byte[1] { (byte)ss.marisaHP });
                pm.Write(FIRST_OFFSET, ALICE_HP_OFFSET, new byte[1] { (byte)ss.aliceHP });

                pm.Write(FIRST_OFFSET, CHARACTER_OFFSET, BitConverter.GetBytes(ss.character));
                pm.Write(FIRST_OFFSET, CHARACTER_WEAPON_OFFSET, new byte[1] { (byte)ss.characterWeapon });
                pm.Write(FIRST_OFFSET, CHARACTER_SPRITE_OFFSET, BitConverter.GetBytes(ss.characterSprite));

                pm.Write(FIRST_OFFSET, BROOM_FLAG_OFFSET, new byte[1] { (byte)_memFlags.weapons["Broom"] });
                pm.Write(FIRST_OFFSET, DOLL_FLAG_OFFSET, new byte[1] { (byte)_memFlags.weapons["Doll"] });
                pm.Write(FIRST_OFFSET, REIMU_FLAG_OFFSET, new byte[1] { (byte)_memFlags.weapons["Reimu"] });
                pm.Write(FIRST_OFFSET, REMILIA_FLAG_OFFSET, new byte[1] { (byte)_memFlags.weapons["Remilia"] });
                pm.Write(FIRST_OFFSET, YOUMU_FLAG_OFFSET, new byte[1] { (byte)_memFlags.weapons["Youmu"] });
                pm.Write(FIRST_OFFSET, REISEN_FLAG_OFFSET, new byte[1] { (byte)_memFlags.weapons["Reisen"] });
                pm.Write(FIRST_OFFSET, CIRNO_FLAG_OFFSET, new byte[1] { (byte)_memFlags.weapons["Cirno"] });
                pm.Write(FIRST_OFFSET, SAKUYA_FLAG_OFFSET, new byte[1] { (byte)_memFlags.weapons["Sakuya"] });
                pm.Write(FIRST_OFFSET, YUYUKO_FLAG_OFFSET, new byte[1] { (byte)_memFlags.weapons["Yuyuko"] });
                pm.Write(FIRST_OFFSET, EIRIN_FLAG_OFFSET, new byte[1] { (byte)_memFlags.weapons["Eirin"] });

                pm.Write(FIRST_OFFSET, BROOM_AMMO_OFFSET, BitConverter.GetBytes(ss.broomAmmo));
                pm.Write(FIRST_OFFSET, DOLL_AMMO_OFFSET, BitConverter.GetBytes(ss.dollAmmo));
                pm.Write(FIRST_OFFSET, REIMU_AMMO_OFFSET, BitConverter.GetBytes(ss.reimuAmmo));
                pm.Write(FIRST_OFFSET, REMILIA_AMMO_OFFSET, BitConverter.GetBytes(ss.remiliaAmmo));
                pm.Write(FIRST_OFFSET, YOUMU_AMMO_OFFSET, BitConverter.GetBytes(ss.youmuAmmo));
                pm.Write(FIRST_OFFSET, REISEN_AMMO_OFFSET, BitConverter.GetBytes(ss.reisenAmmo));
                pm.Write(FIRST_OFFSET, CIRNO_AMMO_OFFSET, BitConverter.GetBytes(ss.cirnoAmmo));
                pm.Write(FIRST_OFFSET, SAKUYA_AMMO_OFFSET, BitConverter.GetBytes(ss.sakuyaAmmo));
                pm.Write(FIRST_OFFSET, YUYUKO_AMMO_OFFSET, BitConverter.GetBytes(ss.yuyukoAmmo));
                pm.Write(FIRST_OFFSET, EIRIN_AMMO_OFFSET, BitConverter.GetBytes(ss.eirinAmmo));

                pm.Write(FIRST_OFFSET, MENU_CURSOR_OFFSET, BitConverter.GetBytes(ss.menuCursor));
                pm.Write(FIRST_OFFSET, MENU_TANKS_OFFSET, BitConverter.GetBytes(ss.tanks));
                pm.Write(FIRST_OFFSET, LIVES_OFFSET, new byte[1] { (byte)ss.lives });
            }
        }

        private void LoadNextSaveState()
        {
            try
            {
                Invoke((MethodInvoker)delegate //using this because thread
                {
                    if (comboSaves.Items.Count > 0)
                    {
                        if (comboSaves.SelectedIndex < comboSaves.Items.Count - 1)
                            comboSaves.SelectedIndex += 1;
                        else if (comboSaves.SelectedIndex == comboSaves.Items.Count - 1 || comboSaves.SelectedIndex == -1)
                            comboSaves.SelectedIndex = 0;
                        comboSaves_SelectionChangeCommitted(null, null);
                    }
                });
            }
            catch (Exception ex)
            {
                if (ex is ObjectDisposedException || ex is InvalidOperationException)
                    print(ex.Message);
            }
        }

        private void LoadNextStage()
        {
            try
            {
                Invoke((MethodInvoker)delegate //using this because thread
                {
                    if (comboWarp.SelectedIndex < comboWarp.Items.Count - 1) //if selected entry isn't the last one
                        comboWarp.SelectedIndex += 1; //select the next one
                    else if (comboWarp.SelectedIndex == comboWarp.Items.Count - 1 || comboWarp.SelectedIndex == -1) //if selected entry is the last one or is empty
                        comboWarp.SelectedIndex = 0; //go to the first one
                    buttonWarp_Click(null, null);
                });
            }
            catch (Exception ex)
            {
                if (ex is ObjectDisposedException || ex is InvalidOperationException)
                    print(ex.Message);
            }
        }
        #endregion

        #region warp
        private void checkEarlyBroom_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEarlyBroom.Checked)
            {
                comboWarp.Items.Clear();
                comboWarp.Items.Add("Cirno"); comboWarp.Items.Add("Eirin"); comboWarp.Items.Add("Yuyuko"); comboWarp.Items.Add("Reimu");
                comboWarp.Items.Add("Youmu"); comboWarp.Items.Add("Remilia"); comboWarp.Items.Add("Sakuya"); comboWarp.Items.Add("Reisen");
            }
            else
            {
                comboWarp.Items.Clear();
                comboWarp.Items.Add("Cirno"); comboWarp.Items.Add("Eirin"); comboWarp.Items.Add("Yuyuko"); comboWarp.Items.Add("Reisen");
                comboWarp.Items.Add("Reimu"); comboWarp.Items.Add("Remilia"); comboWarp.Items.Add("Sakuya"); comboWarp.Items.Add("Youmu");
            }
            comboWarp.Items.Add("Patchouli 1"); comboWarp.Items.Add("Patchouli 2"); comboWarp.Items.Add("Patchouli 3");
            comboWarp.Items.Add("Patchouli 4"); comboWarp.Items.Add("Patchouli 5"); comboWarp.Items.Add("Patchouli 6");
        }

        private void buttonWarp_Click(object sender, EventArgs e)
        {
            bool checkLivesWasChecked = false;
            if (checkLives.Checked) { checkLivesWasChecked = true; checkLives.Checked = false; }

            //fast respawn
            pm.Write(FIRST_OFFSET, LIVES_OFFSET, BitConverter.GetBytes(0));
            pm.WriteStatic(STATE, BitConverter.GetBytes(Constants.GameStates.DEAD));
            pm.WriteStatic(DELAY, BitConverter.GetBytes(240));

            for (int i = 0; i < 5000; i++)
                pm.WriteStatic(SCREEN_TYPE, BitConverter.GetBytes(Constants.Screens.CONTINUE));

            switch (comboWarp.Text)
            {
                case "Cirno":
                    pm.WriteStatic(STAGE_ID, BitConverter.GetBytes(Constants.Stages.CIRNO));
                    SetWeapons();
                    break;
                case "Eirin":
                    pm.WriteStatic(STAGE_ID, BitConverter.GetBytes(Constants.Stages.EIRIN));
                    SetWeapons(cirno: Constants.BossWeaponOn.ALICE);
                    break;
                case "Yuyuko":
                    pm.WriteStatic(STAGE_ID, BitConverter.GetBytes(Constants.Stages.YUYUKO));
                    if (checkEarlyBroom.Checked)
                        SetWeapons(broom: Constants.SpecialWeapon.ON, doll: Constants.SpecialWeapon.ON,
                                   cirno: Constants.BossWeaponOn.ALICE, eirin: Constants.BossWeaponOn.ALICE);
                    else
                        SetWeapons(cirno: Constants.BossWeaponOn.ALICE, eirin: Constants.BossWeaponOn.ALICE);
                    break;
                case "Reimu":
                    pm.WriteStatic(STAGE_ID, BitConverter.GetBytes(Constants.Stages.REIMU));
                    if (checkEarlyBroom.Checked)
                        SetWeapons(broom: Constants.SpecialWeapon.ON, doll: Constants.SpecialWeapon.ON,
                                   cirno: Constants.BossWeaponOn.ALICE, eirin: Constants.BossWeaponOn.ALICE, yuyuko: Constants.BossWeaponOn.MARISA);
                    else
                        SetWeapons(broom: Constants.SpecialWeapon.ON,
                                   cirno: Constants.BossWeaponOn.ALICE, eirin: Constants.BossWeaponOn.ALICE, yuyuko: Constants.BossWeaponOn.MARISA, reisen: Constants.BossWeaponOn.MARISA);
                    break;
                case "Youmu":
                    pm.WriteStatic(STAGE_ID, BitConverter.GetBytes(Constants.Stages.YOUMU));
                    if (checkEarlyBroom.Checked)
                        SetWeapons(broom: Constants.SpecialWeapon.ON, doll: Constants.SpecialWeapon.ON,
                                   cirno: Constants.BossWeaponOn.ALICE, eirin: Constants.BossWeaponOn.ALICE, yuyuko: Constants.BossWeaponOn.MARISA, reimu: Constants.BossWeaponOn.MARISA);
                    else
                        SetWeapons(broom: Constants.SpecialWeapon.ON,
                                   cirno: Constants.BossWeaponOn.ALICE, eirin: Constants.BossWeaponOn.ALICE, yuyuko: Constants.BossWeaponOn.MARISA, reimu: Constants.BossWeaponOn.MARISA,
                                   remilia: Constants.BossWeaponOn.MARISA, sakuya: Constants.BossWeaponOn.MARISA, reisen: Constants.BossWeaponOn.MARISA);
                    break;
                case "Remilia":
                    pm.WriteStatic(STAGE_ID, BitConverter.GetBytes(Constants.Stages.REMILIA));
                    if (checkEarlyBroom.Checked)
                        SetWeapons(broom: Constants.SpecialWeapon.ON, doll: Constants.SpecialWeapon.ON,
                                   cirno: Constants.BossWeaponOn.ALICE, eirin: Constants.BossWeaponOn.ALICE, yuyuko: Constants.BossWeaponOn.MARISA, reimu: Constants.BossWeaponOn.MARISA,
                                   youmu: Constants.BossWeaponOn.ALICE);
                    else
                        SetWeapons(broom: Constants.SpecialWeapon.ON,
                                   cirno: Constants.BossWeaponOn.ALICE, eirin: Constants.BossWeaponOn.ALICE, yuyuko: Constants.BossWeaponOn.MARISA, reimu: Constants.BossWeaponOn.MARISA,
                                   reisen: Constants.BossWeaponOn.MARISA);
                    break;
                case "Sakuya":
                    pm.WriteStatic(STAGE_ID, BitConverter.GetBytes(Constants.Stages.SAKUYA));
                    if (checkEarlyBroom.Checked)
                        SetWeapons(broom: Constants.SpecialWeapon.ON, doll: Constants.SpecialWeapon.ON,
                                   cirno: Constants.BossWeaponOn.ALICE, eirin: Constants.BossWeaponOn.ALICE, yuyuko: Constants.BossWeaponOn.MARISA, reimu: Constants.BossWeaponOn.MARISA,
                                   youmu: Constants.BossWeaponOn.ALICE, remilia: Constants.BossWeaponOn.MARISA);
                    else
                        SetWeapons(broom: Constants.SpecialWeapon.ON,
                                   cirno: Constants.BossWeaponOn.ALICE, eirin: Constants.BossWeaponOn.ALICE, yuyuko: Constants.BossWeaponOn.MARISA, reimu: Constants.BossWeaponOn.MARISA,
                                   reisen: Constants.BossWeaponOn.MARISA, remilia: Constants.BossWeaponOn.MARISA);
                    break;
                case "Reisen":
                    pm.WriteStatic(STAGE_ID, BitConverter.GetBytes(Constants.Stages.REISEN));
                    if (checkEarlyBroom.Checked)
                        SetWeapons(broom: Constants.SpecialWeapon.ON, doll: Constants.SpecialWeapon.ON,
                                   cirno: Constants.BossWeaponOn.ALICE, eirin: Constants.BossWeaponOn.ALICE, yuyuko: Constants.BossWeaponOn.MARISA, reimu: Constants.BossWeaponOn.MARISA,
                                   youmu: Constants.BossWeaponOn.ALICE, remilia: Constants.BossWeaponOn.MARISA, sakuya: Constants.BossWeaponOn.MARISA);
                    else
                        SetWeapons(cirno: Constants.BossWeaponOn.ALICE, eirin: Constants.BossWeaponOn.ALICE, yuyuko: Constants.BossWeaponOn.MARISA);
                    break;
                case "Patchouli 1":
                    pm.WriteStatic(STAGE_ID, BitConverter.GetBytes(Constants.Stages.PATCHY_1));
                    SetWeapons(broom: Constants.SpecialWeapon.ON, doll: Constants.SpecialWeapon.ON,
                               cirno: Constants.BossWeaponOn.ALICE, eirin: Constants.BossWeaponOn.ALICE, yuyuko: Constants.BossWeaponOn.MARISA, reimu: Constants.BossWeaponOn.MARISA,
                               youmu: Constants.BossWeaponOn.ALICE, remilia: Constants.BossWeaponOn.MARISA, sakuya: Constants.BossWeaponOn.MARISA, reisen: Constants.BossWeaponOn.MARISA);
                    break;
                case "Patchouli 2":
                    pm.WriteStatic(STAGE_ID, BitConverter.GetBytes(Constants.Stages.PATCHY_2));
                    SetWeapons(broom: Constants.SpecialWeapon.ON, doll: Constants.SpecialWeapon.ON,
                               cirno: Constants.BossWeaponOn.ALICE, eirin: Constants.BossWeaponOn.ALICE, yuyuko: Constants.BossWeaponOn.MARISA, reimu: Constants.BossWeaponOn.MARISA,
                               youmu: Constants.BossWeaponOn.ALICE, remilia: Constants.BossWeaponOn.MARISA, sakuya: Constants.BossWeaponOn.MARISA, reisen: Constants.BossWeaponOn.MARISA);
                    break;
                case "Patchouli 3":
                    pm.WriteStatic(STAGE_ID, BitConverter.GetBytes(Constants.Stages.PATCHY_3));
                    SetWeapons(broom: Constants.SpecialWeapon.ON, doll: Constants.SpecialWeapon.ON,
                               cirno: Constants.BossWeaponOn.ALICE, eirin: Constants.BossWeaponOn.ALICE, yuyuko: Constants.BossWeaponOn.MARISA, reimu: Constants.BossWeaponOn.MARISA,
                               youmu: Constants.BossWeaponOn.ALICE, remilia: Constants.BossWeaponOn.MARISA, sakuya: Constants.BossWeaponOn.MARISA, reisen: Constants.BossWeaponOn.MARISA);
                    break;
                case "Patchouli 4":
                    pm.WriteStatic(STAGE_ID, BitConverter.GetBytes(Constants.Stages.PATCHY_4));
                    SetWeapons(broom: Constants.SpecialWeapon.ON, doll: Constants.SpecialWeapon.ON,
                               cirno: Constants.BossWeaponOn.ALICE, eirin: Constants.BossWeaponOn.ALICE, yuyuko: Constants.BossWeaponOn.MARISA, reimu: Constants.BossWeaponOn.MARISA,
                               youmu: Constants.BossWeaponOn.ALICE, remilia: Constants.BossWeaponOn.MARISA, sakuya: Constants.BossWeaponOn.MARISA, reisen: Constants.BossWeaponOn.MARISA);
                    break;
                case "Patchouli 5":
                    pm.WriteStatic(STAGE_ID, BitConverter.GetBytes(Constants.Stages.PATCHY_5));
                    SetWeapons(broom: Constants.SpecialWeapon.ON, doll: Constants.SpecialWeapon.ON,
                               cirno: Constants.BossWeaponOn.ALICE, eirin: Constants.BossWeaponOn.ALICE, yuyuko: Constants.BossWeaponOn.MARISA, reimu: Constants.BossWeaponOn.MARISA,
                               youmu: Constants.BossWeaponOn.ALICE, remilia: Constants.BossWeaponOn.MARISA, sakuya: Constants.BossWeaponOn.MARISA, reisen: Constants.BossWeaponOn.MARISA);
                    break;
                case "Patchouli 6":
                    pm.WriteStatic(STAGE_ID, BitConverter.GetBytes(Constants.Stages.PATCHY_6));
                    SetWeapons(broom: Constants.SpecialWeapon.ON, doll: Constants.SpecialWeapon.ON,
                               cirno: Constants.BossWeaponOn.ALICE, eirin: Constants.BossWeaponOn.ALICE, yuyuko: Constants.BossWeaponOn.MARISA, reimu: Constants.BossWeaponOn.MARISA,
                               youmu: Constants.BossWeaponOn.ALICE, remilia: Constants.BossWeaponOn.MARISA, sakuya: Constants.BossWeaponOn.MARISA, reisen: Constants.BossWeaponOn.MARISA);
                    break;
            }

            if (checkLivesWasChecked) { Thread.Sleep(500); checkLives.Checked = true; }
        }

        private void SetWeapons(int broom = Constants.SpecialWeapon.OFF, int doll = Constants.SpecialWeapon.OFF,
            int reimu = Constants.BossWeaponOn.NOBODY, int remilia = Constants.BossWeaponOn.NOBODY, int youmu = Constants.BossWeaponOn.NOBODY, int reisen = Constants.BossWeaponOn.NOBODY,
            int cirno = Constants.BossWeaponOn.NOBODY, int sakuya = Constants.BossWeaponOn.NOBODY, int yuyuko = Constants.BossWeaponOn.NOBODY, int eirin = Constants.BossWeaponOn.NOBODY)
        {
            pm.Write(FIRST_OFFSET, BROOM_FLAG_OFFSET, new byte[1] { (byte)broom });
            pm.Write(FIRST_OFFSET, DOLL_FLAG_OFFSET, new byte[1] { (byte)doll });
            pm.Write(FIRST_OFFSET, REIMU_FLAG_OFFSET, new byte[1] { (byte)reimu });
            pm.Write(FIRST_OFFSET, REMILIA_FLAG_OFFSET, new byte[1] { (byte)remilia });
            pm.Write(FIRST_OFFSET, YOUMU_FLAG_OFFSET, new byte[1] { (byte)youmu });
            pm.Write(FIRST_OFFSET, REISEN_FLAG_OFFSET, new byte[1] { (byte)reisen });
            pm.Write(FIRST_OFFSET, CIRNO_FLAG_OFFSET, new byte[1] { (byte)cirno });
            pm.Write(FIRST_OFFSET, SAKUYA_FLAG_OFFSET, new byte[1] { (byte)sakuya });
            pm.Write(FIRST_OFFSET, YUYUKO_FLAG_OFFSET, new byte[1] { (byte)yuyuko });
            pm.Write(FIRST_OFFSET, EIRIN_FLAG_OFFSET, new byte[1] { (byte)eirin });
        }
        #endregion

        #region freezer
        private void checkFreezeAll_CheckedChanged(object sender, EventArgs e)
        {
            if (checkFreezeAll.Checked)
            {
                weaponCheckBroom.Checked = weaponCheckDoll.Checked =
                weaponCheckReimu.Checked = weaponCheckRemilia.Checked =
                weaponCheckYoumu.Checked = weaponCheckReisen.Checked =
                weaponCheckCirno.Checked = weaponCheckSakuya.Checked =
                weaponCheckYuyuko.Checked = weaponCheckEirin.Checked = true;
            }
            else
            {
                weaponCheckBroom.Checked = weaponCheckDoll.Checked =
                weaponCheckReimu.Checked = weaponCheckRemilia.Checked =
                weaponCheckYoumu.Checked = weaponCheckReisen.Checked =
                weaponCheckCirno.Checked = weaponCheckSakuya.Checked =
                weaponCheckYuyuko.Checked = weaponCheckEirin.Checked = false;
            }
        }

        private void SetWeapon(int offset, int flag, bool regularWeapon)
        {
            if (regularWeapon)
            {
                switch (flag)
                {
                    case Constants.BossWeaponOn.NOBODY: pm.Write(FIRST_OFFSET, offset, new byte[1] { Constants.BossWeaponOn.MARISA }); break;
                    case Constants.BossWeaponOn.MARISA: pm.Write(FIRST_OFFSET, offset, new byte[1] { Constants.BossWeaponOn.ALICE }); break;
                    case Constants.BossWeaponOn.ALICE: pm.Write(FIRST_OFFSET, offset, new byte[1] { Constants.BossWeaponOn.NOBODY }); break;
                }
            }
            else
            {
                switch (flag)
                {
                    case Constants.SpecialWeapon.OFF: pm.Write(FIRST_OFFSET, offset, new byte[1] { Constants.SpecialWeapon.ON }); break;
                    case Constants.SpecialWeapon.ON: pm.Write(FIRST_OFFSET, offset, new byte[1] { Constants.SpecialWeapon.OFF }); break;
                }
            }
        }

        private void SetTank(int offset, PictureBox tankBox)
        {
            int curTank = pm.Read(FIRST_OFFSET, offset)[0];

            switch (curTank)
            {
                case Constants.Etanks.ETANK: tankBox.Image = Properties.Resources.etank; pm.Write(FIRST_OFFSET, offset, new byte[1] { Constants.Etanks.ETANK }); break;
                case Constants.Etanks.STAR_TANK: tankBox.Image = Properties.Resources.startank; pm.Write(FIRST_OFFSET, offset, new byte[1] { Constants.Etanks.STAR_TANK }); break;
                case Constants.Etanks.DOUBLE_ETANK: tankBox.Image = Properties.Resources.doubletank; pm.Write(FIRST_OFFSET, offset, new byte[1] { Constants.Etanks.DOUBLE_ETANK }); break;
                case Constants.Etanks.NO_TANK: tankBox.Image = Properties.Resources.tank_off; pm.Write(FIRST_OFFSET, offset, new byte[1] { Constants.Etanks.NO_TANK }); break;
            }
        }
        #endregion

        #region Helpers
        private void print(string msg)
        {
            Console.WriteLine(msg);
        }
        #endregion
    }
}
