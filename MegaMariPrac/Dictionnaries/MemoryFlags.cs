using System.Collections.Generic;

namespace MegaMariPrac.Dictionnaries
{
    /// <summary>Class for handling memory values / flags, this can be used for setting values directly</summary>
    public class MemoryFlags
    {
        public Dictionary<string, int> weapons = new Dictionary<string, int>{
            {"Broom", Constants.BossWeaponOn.NOBODY},
            {"Doll", Constants.BossWeaponOn.NOBODY},
            {"Reimu", Constants.BossWeaponOn.NOBODY},
            {"Remilia", Constants.BossWeaponOn.NOBODY},
            {"Youmu", Constants.BossWeaponOn.NOBODY},
            {"Reisen", Constants.BossWeaponOn.NOBODY},
            {"Cirno", Constants.BossWeaponOn.NOBODY},
            {"Sakuya", Constants.BossWeaponOn.NOBODY},
            {"Yuyuko", Constants.BossWeaponOn.NOBODY},
            {"Eirin", Constants.BossWeaponOn.NOBODY}
        };

        /// <summary>Set all flags for the weapons dictionnary</summary>
        /// <param name="values">Values to set, in the same order as the weapons dictionnary</param>
        public void SetWeaponFlags(params int[] values)
        {
            string[] keys = { "Broom", "Doll", "Reimu", "Remilia", "Youmu", "Reisen", "Cirno", "Sakuya", "Yuyuko", "Eirin" };
            for (int i = 0; i < keys.Length; i++)
            {
                weapons[keys[i]] = values[i];
            }
        }
    }
}
