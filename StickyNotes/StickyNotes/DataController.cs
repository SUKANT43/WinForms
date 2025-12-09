using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace StickyNotes
{
    class DataController
    {
        static string desktop=Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        static string path = Path.Combine(desktop, "stickyNotes.txt");


        public static bool WriteData(string header,string content)
        {
            try
            {
                List <ContentStructure>list= LoadData();
                string id = (list.Count + 1).ToString();
                string dateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                list.Add(new ContentStructure(id, header, content, dateTime));
                bool save = SaveAll(list);
                if (!save)
                {
                    return false;
                }
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }

        public static List<ContentStructure> LoadData()
        {
            List<ContentStructure> list = new List<ContentStructure>();
            if (!File.Exists(path))
            {
                return list;
            }
            foreach (var line in File.ReadAllLines(path))
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }

                string[] parts = line.Split('|');
                if (parts.Length == 4)
                {
                    list.Add(new ContentStructure(parts[0], parts[1], parts[2], parts[3]));
                }
            }
           
            return list;
        }

        public static bool SaveAll(List<ContentStructure> list)
        {
            try
            {
                var lines = list.Select(w => $"{w.Id}|{w.Header}|{w.Content}|{w.CreatedDateTime}");
                File.WriteAllLines(path, lines);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static bool EditData(string id,string header,string content)
        {
            try
            {
                List<ContentStructure> list = LoadData();
                for(int i = 0; i < list.Count; i++)
                {
                    if (list[i].Id == id)
                    {
                        list[i].Header = header;
                        list[i].Content = content;
                        list[i].CreatedDateTime= DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        break;
                    }
                }
                bool save = SaveAll(list);
                if (!save)
                {
                    return false;
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }


    }
}
