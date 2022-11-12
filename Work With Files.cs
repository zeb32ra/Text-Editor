using Text_Editor;
using System.Text.RegularExpressions;

namespace Files
{
    internal class Work_With_Files
    {
        string text = "Age\nName\nZodiak\nProfession";
        /*List<People> people = new List<People>();*/
        string[] content;

        public string[] create_or_open_txt(string path)
        {
            if (File.Exists(path))
            {
                
                string inside = File.ReadAllText(path);
                content = Regex.Split(inside, "\n");
                int i = 2;
                foreach (string line in content)
                {
                    Console.SetCursorPosition(2, i);
                    Console.WriteLine(line);
                    i++;
                }
             
                
            }
            else
            {
                File.WriteAllText(path, text);
                content = Regex.Split(text, "\n");
            }
            return content;
        }
        public void save_to_txt(string path, string[] content)
        {

            File.WriteAllText(path, string.Join("\n", content));

        }
        public void create_or_open_json(string path)
        {

        }
        public void save_to_json(string path)
        {

        }
        public void create_or_open_xml(string path)
        {

        }
        public void save_to_xml(string path)
        {

        }
    }
}
