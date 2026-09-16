using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace MegaMariPrac.Hotkeys
{
    public partial class HotkeyDialog : Form
    {
        readonly KeyboardKeys _keybKeys = new KeyboardKeys();

        public HotkeyDialog()
        {
            InitializeComponent();
            CenterToScreen();
            MinimizeBox = MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedSingle;

            foreach (string key in _keybKeys.dictModifierKeys.Keys)
            {
                comboModifier1.Items.Add(key);
                comboModifier2.Items.Add(key);
                comboModifier3.Items.Add(key);
                comboModifier4.Items.Add(key);
                comboModifier5.Items.Add(key);
                comboModifier6.Items.Add(key);
            }

            foreach (string key in _keybKeys.dictKeys.Keys)
            {
                comboHotkey1.Items.Add(key);
                comboHotkey2.Items.Add(key);
                comboHotkey3.Items.Add(key);
                comboHotkey4.Items.Add(key);
                comboHotkey5.Items.Add(key);
                comboHotkey6.Items.Add(key);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            // Saving hotkeys
            using (StreamWriter sw = File.CreateText(HotkeysConfigFile.path))
            {
                /**
                 * Add the version inside the .cfg file
                 * Then loop through ComboBoxes related to this window & store their values too
                 */
                sw.WriteLine(HotkeysConfigFile.version);
                foreach (Control c in Controls.Cast<Control>().OrderBy(c => c.TabIndex))
                    if (c is ComboBox)
                        sw.WriteLine(c.Text);
            }
            Close();
        }

        private void HotkeyDialog_Load(object sender, EventArgs e)
        {
            MainForm.CreateConfigDirectory();
            if (HotkeysConfigFile.Exists())
            {
                // Loop over values stored inside the .cfg file
                using (StreamReader sr = File.OpenText(HotkeysConfigFile.path))
                {
                    // Skip the first line containing the version
                    sr.ReadLine();

                    // Load ComboBoxes with values in TabIndex order & set their values based on the file's content
                    foreach (Control c in Controls.Cast<Control>().OrderBy(c => c.TabIndex))
                        if (c is ComboBox)
                            c.Text = sr.ReadLine();
                }
            }
        }

        private void comboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string[] selectedHotkeys = {
                comboModifier1.SelectedItem.ToString() + comboHotkey1.SelectedItem.ToString(),
                comboModifier2.SelectedItem.ToString() + comboHotkey2.SelectedItem.ToString(),
                comboModifier3.SelectedItem.ToString() + comboHotkey3.SelectedItem.ToString(),
                comboModifier4.SelectedItem.ToString() + comboHotkey4.SelectedItem.ToString(),
                comboModifier5.SelectedItem.ToString() + comboHotkey5.SelectedItem.ToString(),
                comboModifier6.SelectedItem.ToString() + comboHotkey6.SelectedItem.ToString()
            };

            byte i = 0;
            HashSet<string> hs = new HashSet<string>();
            foreach (string s in selectedHotkeys)
                if (hs.Add(s))
                    i++;

            // Update text & enable/disable save button based on every hotkey combo being unique or not
            buttonSave.Enabled = i >= selectedHotkeys.Length;
            buttonSave.Text = i < selectedHotkeys.Length ? "Hotkey conflict!" : "Save";
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
