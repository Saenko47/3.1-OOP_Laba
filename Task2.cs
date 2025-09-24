using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Laba3._1
{
    internal class Task2
    {
        private Dictionary<string, int> dic = new Dictionary<string, int>();
        private string path_To_Files;
        private string[] files;
        public Task2() { 
        }
        public Task2(string path_To_Files) { 
        this.path_To_Files = path_To_Files;
            this.files = Get_Files_From_Path();
        }
        private string[] Get_Files_From_Path() {
            if (!Directory.Exists(path_To_Files)) {
                throw new Exception("Therse no such directory");
            }
            string[] raw_files = Directory.GetFiles(path_To_Files);
            if (raw_files.Contains(path_To_Files+@"\firstFile.txt"))
            {
                string[] files = new string[raw_files.Length - 1];
                int count = 0;
                for (int k = 0; k < files.Length; ++k)
                {
                    if (raw_files[k] != path_To_Files + @"\firstFile.txt")
                    {
                        files[count++] = raw_files[k];
                    }
                }
                return files;
            }
            return raw_files;
        }
        public void Print_Files() {
            int count = 0;
            foreach (var i in files){
                Console.WriteLine($"{count++}. {i}");
            }
        }
        private void Get_Analysi_For_File(string file_text)
        {
            string[] words = file_text.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            for (int k = 0; k < words.Length; k++)
            {
                if (!dic.ContainsKey(words[k]))
                {
                    dic.Add(words[k], 1);
                }
                else
                {
                    dic[words[k]]++;
                }
            }


        }
        private void Save_Analysis()
        {
            string ultimate_path = path_To_Files + "/firstFile.txt";

            using (StreamWriter sw = new StreamWriter(ultimate_path)) {
                foreach (var i in dic) {
                    sw.WriteLine($"word: {i.Key} amount in files:{i.Value}");
                }
            }
            
        
        }
        public void Get_One_Analysis() {
            Console.WriteLine("What file u want analize?");
            Print_Files();
            Console.WriteLine("Input index of file that u wanna analize: 999 - exit");
            int input = int.Parse(Console.ReadLine());
            if (input == 999) {
                Console.WriteLine("u exit");
                return;
            }
            if (input >= files.Length || input < 0) {
                Console.WriteLine("Enter correct file index");
                return;
            }
            string text = File.ReadAllText(files[input]);
           
            Get_Analysi_For_File(text);
            Console.WriteLine("Are u wanna get result in file or in terminal? file - 1 terminal - 2");
            int decision = int.Parse(Console.ReadLine());
            switch (decision) {
                case 1:
                    Save_Analysis();
                    break;
                case 2:
                    Print_Dictionary();
                    break;
            }
            dic = new Dictionary<string, int>();

        }
        public void Get_Whole_Texts_Analysis() { 
        List<string> strings = new List<string>();
            for (int k = 0; k < files.Length; ++k)
            {
                strings.Add(File.ReadAllText(files[k]));
            }
            for (int k = 0; k < strings.Count; ++k) { 
            Get_Analysi_For_File(strings[k]);
            }
            Save_Analysis();
        }
        public void Print_Dictionary() {
        foreach(var i in dic) {
                Console.WriteLine($"word: {i.Key} amount in files:{i.Value}");
            }
        }
    }

}
//Завдання 2. Існує певний набір текстових файлів з вихідним текстом для
//аналізу. Інформація про ці файли зберігається у файлі з назвою firstFile.
//Необхідно для обраного файлу вивести на екран та, за необхідності, у
//файл статистику про кількість використань кожного слова, що зустрічається в
//обраному тексті. Виконувати аналіз текстів доти, поки у цьому буде потреба у
//користувача.
