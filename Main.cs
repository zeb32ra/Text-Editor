using Text_Editor;
using Files;

namespace Programm
{
    internal class Main
    {
        People Nastya = new People("17", "Nastya", "Virgo", "Programmer");
        bool we_are_in_main = true;
        bool we_opened_the_file = false;
        bool we_are_changing_data = false;
        bool we_are_saving_data = false;
        string Path;
        Work_With_Files file = new Work_With_Files();
        ConsoleKeyInfo key;
        string[] content;
        
        public void Programm()
        {
            
                if (we_are_in_main)
                {
                    Console.WriteLine("Введите путь до файла (вместе с названием), который вы хотите открыть\n" +
                        "------------------------------------------------------------------------");
                    Path = Console.ReadLine();

                    we_are_in_main = false;
                    we_opened_the_file = true;
                }
                if (we_opened_the_file)
                {
                    if (Path.EndsWith(".txt"))
                    {
                        Console.Clear();
                       
                        content = file.create_or_open_txt(Path);
                        Console.Clear();
                        strelki(content.Length); 
                    }

                    
                }
            
        }
        private void strelki(int max_position)
        {
            int position = 2;

            max_position += 1;
            write_content();
            while (true)
            {
                key = Console.ReadKey();
                if (key.Key == ConsoleKey.UpArrow)
                {
                    if (position - 1 == 1)
                    {
                        position = 2;
                    }
                    else
                    {
                        position--;
                    }
                }
                if (key.Key == ConsoleKey.DownArrow)
                {
                    if (position + 1 > max_position)
                    {
                        position = 2;
                    }
                    else
                    {
                        position++;
                    }
                }
                Console.Clear();
                write_content();
                Console.SetCursorPosition(0, position);
                Console.WriteLine("->");
                Console.SetCursorPosition(0, position);
                if (key.Key == ConsoleKey.Escape)
                {
                    break;
                }
                if (key.Key == ConsoleKey.Enter)
                {
                    we_opened_the_file = false;
                    we_are_changing_data = true;
                    reformat_the_content(position);
                    we_are_changing_data = false;
                    we_opened_the_file = true;
                }
                if (key.Key == ConsoleKey.F1)
                {
                    
                    Console.Clear();
                    Console.WriteLine("Введите путь до файла (вместе с названием), куда вы хотите" +
                        "сохранить текст\n---------------------------------------------------------");
                    string new_path = Console.ReadLine();
                    if (new_path.EndsWith(".txt"))
                    {
                        file.save_to_txt(new_path, content);
                        we_are_in_main = true;
                        Console.Clear();
                        Array.Clear(content);
                        Programm();
                    }
                }
            }
        }
        private void write_content()
        {
            Console.WriteLine("Сохранить файл в одном из трех форматов (txt, json, xml) - F1." +
                        "Закрыть программу - Escape\n---------------------------------------------------------");
            int i = 2;
            foreach (string s in content)
            {
                Console.SetCursorPosition(2, i);
                Console.WriteLine(s);
                i++;    
            }
        }

        private void reformat_the_content(int position)
        {
            Console.Clear();
            Console.WriteLine("Вы решили переделать позицию " + (position - 1) + ". Введите новое значение");
            Console.WriteLine("---------------------------------------------------------------");
            content[position - 2] = Console.ReadLine();
            Console.Clear();
            strelki(content.Length);

        }
    }


}
