using System.IO;
using System.Linq;

namespace MegaMariPrac.Hotkeys
{
    /// <summary>Class for handling the hotkeys config file</summary>
    public class HotkeysConfigFile
    {
        #region Properties

        public static readonly string name = "hotkey.cfg",
            path = MainForm._configpath + name,
            version = "1.0";

        #endregion

        #region Methods

        /// <summary>Check if the file exist</summary>
        /// <returns><c>bool</c></returns>
        public static bool Exists()
        {
            return File.Exists(path);
        }

        /// <summary>Check if the current file is using the latest version</summary>
        /// <returns><c>bool</c></returns>
        public static bool IsLatestVersion()
        {
            return Exists() && File.ReadLines(path).First().Contains(version);
        }

        /// <summary>Create the file with the default hotkey</summary>
        /// <param name="overwrite">True if we force the creation of the file, at the cost of overwriting existing file (False by default)</param>
        public static void CreateFile(bool overwrite = false)
        {
            // If the file already exist, stop
            if (overwrite == false && Exists())
            {
                return;
            }

            TextWriter writer = new StreamWriter(path);
            writer.WriteLine($"{version}\nLAlt\n1\nLAlt\n2\nLAlt\n3\nLAlt\n4\nLAlt\n5\nLAlt\n6");
            writer.Close();
        }

        #endregion
    }
}