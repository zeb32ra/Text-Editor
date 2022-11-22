using Text_Editor;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using System.Xml.Serialization;

namespace Files
{
    internal class Work_With_Files
    {
        /*string text = "17\nNastya\nVirgo\nProgrammer";*/
        People Nastya = new People("17", "Nastya", "Virgo", "Programmer");
        public string[] content;
        public List<People> result = new List<People>();


        public List<People> create_or_open_txt(string path)
        {
            if (File.Exists(path))
            {
                
                string inside = File.ReadAllText(path);
                content = Regex.Split(inside, "\n");
                
                for (int i = 0; i < content.Length; i++)
                {
                    People person = new People(content[i], content[i + 1], content[i + 2], content[i + 3]);
                    result.Add(person);
                    i +=3;
                }        
                
            }
            else
            {
                result.Add(Nastya);
                string text = Nastya.age + "\n" + Nastya.name + "\n" + Nastya.zodiak + "\n" + Nastya.profession;
                File.WriteAllText(path, Nastya.age + "\n" + Nastya.name + "\n" + Nastya.zodiak + "\n" + Nastya.profession);
                content = Regex.Split(text, "\n");
            }
            return result;
        }
        public void save_to_txt(string path, List<string> content)
        {

            File.WriteAllText(path, string.Join("\n", content));

        }
        public List<People> create_or_open_json(string path)
        {
            if (File.Exists(path))
            {
                People person;
                string inside = File.ReadAllText(path);
                person = JsonConvert.DeserializeObject<People>(inside);
                result.Add(person);
            }
            else
            {
                result.Add(Nastya);
                string to_file = JsonConvert.SerializeObject(Nastya);
                File.WriteAllText(path, to_file);
            }
            return result;
        }
        public void save_to_json(string path, List<string> string_content, List<People> people_content)
        {
            for (int i = 0; i < people_content.Count; i++)
            {
                for (int j = 0; j < string_content.Count; j++)
                {
                    people_content[i].age = string_content[j];
                    people_content[i].name = string_content[j + 1];
                    people_content[i].zodiak = string_content[j + 2];
                    people_content[i].profession = string_content[j + 3];
                    j += 3;
                    i++;

                }
            }
            
            foreach (People p in people_content)
            {
                string json = JsonConvert.SerializeObject(p);
                File.WriteAllText(path, json);
            }

        }
        public List<People> create_or_open_xml(string path)
        {
            XmlSerializer xml = new XmlSerializer(typeof(People));
            if (File.Exists(path))
            {
                People person;
                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                {
                    person = (People)xml.Deserialize(fs);
                    result.Add(person);
                }
            }
            else
            {
                result.Add(Nastya);
                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                {
                    xml.Serialize(fs, Nastya);
                }
            }
            return result;
        }
        public void save_to_xml(string path, List<string> string_content, List<People> people_content)
        {
            for (int i = 0; i < people_content.Count; i++)
            {
                for (int j = 0; j < string_content.Count; j++)
                {
                    people_content[i].age = string_content[j];
                    people_content[i].name = string_content[j + 1];
                    people_content[i].zodiak = string_content[j + 2];
                    people_content[i].profession = string_content[j + 3];
                    j += 3;
                    i++;

                }
            }

            XmlSerializer xml = new XmlSerializer(typeof(People));
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                foreach (People p in people_content)
                {
                    xml.Serialize(fs, p);
                }
                
            }
        }
    }
}
