using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using MegaMariPrac.Dictionnaries;

namespace MegaMariPrac.SaveStates
{
    /// <summary>Class for handling the savestates file</summary>
    public class SaveStateFile
    {
        #region Properties | construct

        public static readonly string name = "savestates.cfg",
            path = MainForm._configpath + name;

        #endregion

        #region Methods

        public SaveStateFile() { }

        /// <summary>Check if the file exist</summary>
        /// <returns><c>bool</c></returns>
        public static bool Exists()
        {
            return File.Exists(path);
        }

        /// <summary>Get all lines from file</summary>
        /// <returns><c>List<string></c>List of lines</returns>
        public static List<string> GetLines()
        {
            return File.ReadAllLines(path).ToList();
        }

        /// <summary>Create the file with the default template</summary>
        public static void CreateFile()
        {
            // If the file already exist, stop
            if (Exists())
            {
                return;
            }

            using (StreamWriter sw = File.CreateText(path))
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

        /// <summary>Cleanup the file to remove empty lines that might be in the wrong spots</summary>
        public static void Clean()
        {
            // If the file doesn't exist, stop
            if (!Exists())
            {
                return;
            }

            // Get all lines in file
            List<string> lines = new List<string>();
            foreach (string line in GetLines())
            {
                if (line.Length == 0)
                {
                    continue;
                }

                /**
                 * For each Stage ID except the 1st one at the top of the file, add an empty line before
                 * If the line doesn't contain "[", then it's a savestate line
                 */
                if (line.Contains("[") && lines.Count > 0)
                {
                    lines.Add("");
                }

                lines.Add(line);
            }

            // Write cleaned lines in file
            File.WriteAllLines(path, lines);
        }

        /// <summary>Add a new savestate in the file</summary>
        /// <param name="stageId">Stage ID</param>
        /// <param name="ssName">SaveState name</param>
        /// <param name="ssContent">SaveState content / string</param>
        public static void AddSaveState(int stageId, string ssName, string ssContent)
        {
            // If file doesn't exist yet, create it
            if (!Exists())
            {
                CreateFile();
            }

            // Prepare the section we're looking for (stage ID within file)
            string section = $"{Constants.Stages.stageNames[stageId]}-{stageId}";

            /**
             * Special case for the last stage :
             * it's always at the end of the file so we just add a new line
             * 
             * Due to this we already the file's content here
             */
            List<string> lines = GetLines();
            if (stageId == Constants.Stages.PATCHY_6)
            {
                lines.Add($"{ssName} | {ssContent}");
                File.WriteAllLines(path, lines);
                return;
            }

            /**
             * Otherwise if it's another stage, we need to find where the section is in the file
             * Start by parsing the file to find the stage's section
             */
            int lineNb = 0;
            bool found = false;
            using (StreamReader sr = File.OpenText(path))
            {
                while (!sr.EndOfStream)
                {
                    /**
                     * If section has already been found, look for the next section
                     * We'll add the new savestate before the empty line above it
                     * 
                     * Exception for the last section because it'll be at the end of the file
                     */
                    string line = sr.ReadLine();
                    if (line.Length > 0 && line.Contains("[") && found)
                    {
                        break;
                    }

                    // If section is found, indicate it
                    if (line.Contains(section))
                    {
                        found = true;
                    }

                    lineNb++;
                }
            }

            // Add the new savestate & put the updated content in the file
            lines.Insert(lineNb - 1, $"{ssName} | {ssContent}");
            File.WriteAllLines(path, lines);
        }

        /// <summary>Delete a savestate from the file</summary>
        /// <param name="savestate">Savestate to remove</param>
        public static void DeleteSaveState(string savestate)
        {
            if (!Exists())
            {
                return;
            }

            /**
             * Get lines from file as a list
             * If savestate string is found, remove it & update the file
             */
            List<string> lines = GetLines();
            if (lines.Remove(savestate))
            {
                File.WriteAllLines(path, lines);
            }
        }

        #endregion
    }
}
