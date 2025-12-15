using System;
using System.IO;
using System.Collections.Generic;

namespace StickyNotesFull
{
    static class DataController
    {
        static string desktop =
            Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        static string stickyNotesFolder =
            Path.Combine(desktop, "stickyNotesData");

        public static bool AddData(DataEventArgs e)
        {
            try
            {
                Directory.CreateDirectory(stickyNotesFolder);

                string fileName =
                    DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".txt";

                string filePath = Path.Combine(stickyNotesFolder, fileName);

                string content =
                    $"{e.Header}|$|" +
                    $"{e.Content}|$|" +
                    $"{e.SelectedColor}|$|" +
                    $"{DateTime.Now:yyyy-MM-dd HH:mm}";

                File.WriteAllText(filePath, content);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool UpdateData(string fileName, DataEventArgs e)
        {
            try
            {
                string filePath = Path.Combine(stickyNotesFolder, fileName);

                string content =
                    $"{e.Header}|$|" +
                    $"{e.Content}|$|" +
                    $"{e.SelectedColor}|$|" +
                    $"{DateTime.Now:yyyy-MM-dd HH:mm}";

                File.WriteAllText(filePath, content);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static List<DataEventArgs> GetData()
        {
            List<DataEventArgs> list = new List<DataEventArgs>();

            if (!Directory.Exists(stickyNotesFolder))
                return list;

            foreach (string file in Directory.GetFiles(stickyNotesFolder, "*.txt"))
            {
                string text = File.ReadAllText(file);

                string[] parts = text.Split(
                    new string[] { "|$|" },
                    StringSplitOptions.None
                );

                if (parts.Length < 4) continue;

                list.Add(new DataEventArgs(
                    Path.GetFileNameWithoutExtension(file),
                    parts[0],
                    parts[1],
                    parts[3],
                    parts[2],
                    Path.GetFileName(file)
                ));
            }

            return list;
        }

        public static bool DeleteData(string fileName)
        {
            try
            {
                string path = Path.Combine(stickyNotesFolder, fileName);
                if (File.Exists(path))
                    File.Delete(path);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
