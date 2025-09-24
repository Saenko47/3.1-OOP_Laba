using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Laba3._1
{
    internal class Language_Dictionary
    {
        private string path;
        public Language_Dictionary() { }
        public Language_Dictionary(string path)
        {
            this.path = path;
        }
        private Dictionary<string, StringBuilder> Get_Words_From_File(string path)
        {
            Dictionary<string, StringBuilder> result = new Dictionary<string, StringBuilder>();
            using (StreamReader sr = new StreamReader(path))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] words = line.Split("-", StringSplitOptions.RemoveEmptyEntries);
                    if (words.Length != 2) { continue; }
                    StringBuilder stringBuilder = new StringBuilder();
                    stringBuilder.Append(words[1]);
                    result.Add(words[0], stringBuilder);
                }
            }
            return result;
        }
        private Dictionary<string, StringBuilder>[] Get_Whole_Dic()
        {
            string[] files = Directory.GetFiles(path);
            Dictionary<string, StringBuilder>[] dic = new Dictionary<string, StringBuilder>[files.Length];
            for (int k = 0; k < files.Length; ++k)
            {

                dic[k] = Get_Words_From_File(files[k]);

            }

            return dic;
        }
        private void Get_Whole_Dictionary_To_File(Dictionary<string, StringBuilder>[] dic)
        {
            string[] files = Directory.GetFiles(path);
            for (int k = 0; k < dic.Length; ++k)
            {
                using (StreamWriter sw = new StreamWriter(files[k]))
                {
                    foreach (var word in dic[k])
                    {
                        sw.WriteLine($"{word.Key}-{word.Value}");
                    }
                }
            }
        }
        private void Get_Single_Dictionary_To_File(Dictionary<string, StringBuilder> dic, string path) 
        {
            using (StreamWriter sw = new StreamWriter(path)) 
            {
                foreach (var word in dic)
                {
                    sw.WriteLine($"{word.Key}-{word.Value}");
                }
            }
        }
        private void Find_In_All_Files(string target)
        {
            Dictionary<string, StringBuilder>[] dic = Get_Whole_Dic();
            bool found = false;
            for (int k = 0; k < dic.Length; ++k) 
            {
                if (dic[k].ContainsKey(target)) 
                {
                    Console.WriteLine(dic[k][target].ToString());
                    found = true;
                }
            }
            if (!found) 
            {
                Console.WriteLine("Theres no such word!!!");
                return;
            }
        }
        


        public void Make_New_Dictionary(string lan1, string lan2, string translate1, string translate2)
        {
            if (File.Exists(path + "/" + lan1 + "-" + lan2 + ".txt") && File.Exists(path + "/" + lan2 + "-" + lan1 + ".txt"))
            {
                Console.WriteLine("There is already exist!!!");
                return;
            }
            using (StreamWriter sw = new StreamWriter(path + "/" + lan1 + "-" + lan2 + ".txt"))
            {
                sw.WriteLine($"{translate1}-{translate2}");
            }
            using (StreamWriter sw = new StreamWriter(path + "/" + lan2 + "-" + lan1 + ".txt"))
            {
                sw.WriteLine($"{translate2}-{translate1}");
            }
        }
        public void Add_Translate()
        {
            string new_word1, new_word2;
            string[] files = Directory.GetFiles(path);

            if (files.Length == 0)
            {
                Console.WriteLine("Theres no dictionarys!!");
                return;
            }
            Console.WriteLine("Choose the language: 0 - exit");
            Show_Dictionary(files);
            int input = int.Parse(Console.ReadLine());
            if (input == 0) { Console.WriteLine("u exit"); return; }
            Console.WriteLine("Enter new word 1:");
            new_word1 = Console.ReadLine();
            Console.WriteLine("Enter new word 2:");
            new_word2 = Console.ReadLine();
            string choosenfile = Path.GetFileNameWithoutExtension(files[input - 1]);
            string[] lan = choosenfile.Split("-", StringSplitOptions.RemoveEmptyEntries);
            string[] word_1 = File.ReadAllLines(path + "/" + lan[0] + "-" + lan[1] + ".txt");
            if (word_1.Contains(new_word1 + "-" + new_word2) || word_1.Contains(new_word2 + "-" + new_word1))
            {
                Console.WriteLine("This word alread in dictionary!!!");
                return;
            }
            using (StreamWriter sw = new StreamWriter(path + "/" + lan[0] + "-" + lan[1] + ".txt", true))
            {
                sw.WriteLine($"{new_word1}-{new_word2}");
            }
            using (StreamWriter sw = new StreamWriter(path + "/" + lan[1] + "-" + lan[0] + ".txt", true))
            {
                sw.WriteLine($"{new_word2}-{new_word1}");
            }

        }
        
        private void Show_Dictionary(string[] files) 
        {

            
            for (int k = 0; k < files.Length; ++k)
            {
                string fileName = Path.GetFileNameWithoutExtension(files[k]);
                Console.WriteLine($"{k + 1}. {fileName}");
            }
        }
        private void Show_Word_In_File(Dictionary<string, StringBuilder> dic) 
        {
            int count = 1;
            foreach (string word in dic.Keys) {
                Console.WriteLine($"{count++}.{word}");
            }
        
        }
        private void Add_For_Change(Dictionary<string, StringBuilder> dic, string newWord1, string newWord2)
        {
            StringBuilder newWord = new StringBuilder();
            newWord.Append(newWord2);
            dic.Add(newWord1, newWord);

        }
        private void Remove_For_Change(string chosen_key, Dictionary<string, StringBuilder> dic)
        {


            if (!dic.ContainsKey(chosen_key))
            {
                Console.WriteLine($"Theres no such word in Dic");
                return;
            }
            else
            {
                foreach (var kvp in dic)
                {
                    if (kvp.Value.ToString().Contains(chosen_key))
                    {
                        chosen_key = kvp.Key;
                        break;
                    }
                }
            }


            dic.Remove(chosen_key);

        }
        private string Get_Exacly_Target(string str, string target) 
        {
            string[] words = str.Split(",", StringSplitOptions.RemoveEmptyEntries);
            foreach (var word in words) 
            {
                if (word == target) 
                { 
                return word;
                }
            }
            return " ";
        }
        private void Change_Word_In_Dictionarys(string target, string newWord1, string newWord2, string notFullPath) 
        {
            string[] raw_lan = Path.GetFileNameWithoutExtension(notFullPath).Split("-",StringSplitOptions.RemoveEmptyEntries);
            string lan1 = $"{path}/{raw_lan[0]}-{raw_lan[1]}.txt";
            string lan2 = $"{path}/{raw_lan[1]}-{raw_lan[0]}.txt";
            var dic1 = Get_Words_From_File(lan1);
            var targetValue = dic1[target].ToString();
            Remove_For_Change(target, dic1);
            Add_For_Change(dic1, newWord1, newWord2);
            Get_Single_Dictionary_To_File(dic1,lan1);
            target = Get_Exacly_Target(targetValue, target);
            var dic2 = Get_Words_From_File(lan2);
            Remove_For_Change(targetValue, dic2);
            Add_For_Change(dic2, newWord2, newWord1);
            Get_Single_Dictionary_To_File(dic2, lan2);

        }
        public void Add_New_Translation_To_Word()
        {
            
            string[] files = Directory.GetFiles(path);
            Console.WriteLine("Choose dictionary:");
            Show_Dictionary(files);
            int input = int.Parse(Console.ReadLine());
            string choosenFile = files[input - 1];
            Dictionary<string, StringBuilder> dic = Get_Words_From_File(choosenFile);
            Console.WriteLine("Choose word to add the new word:");
            Show_Word_In_File(dic);
            string chosen_key = Console.ReadLine();
            if (!dic.ContainsKey(chosen_key)) 
            {
                Console.WriteLine("There is no such word!!!");
                return;
            }
            Console.WriteLine("Enter word to append:");
            string word = Console.ReadLine();
            dic[chosen_key].Append($",{word}");
            Get_Single_Dictionary_To_File(dic, choosenFile);


        }
        public void Find_All_Translation() 
        {
            Console.WriteLine("Choose target");
            string target = Console.ReadLine();
            Find_In_All_Files(target);
        }
        private Dictionary<string, StringBuilder> For_Delete(Dictionary<string, StringBuilder> dic, string target) 
        {
            string? key_to_remove = null;
            foreach (var word in dic) 
            {
                if (word.Value.ToString().Contains(target)) 
                { 
                key_to_remove = word.Key;
                    break;
                }
            }
            if (key_to_remove != null) 
            {
                dic.Remove(key_to_remove);
            }
        return dic;
        }
        public void Remove_Word() 
        {
            Console.WriteLine("Choose target");
            string target = Console.ReadLine();
            Dictionary<string, StringBuilder>[] dic = Get_Whole_Dic();
            for (int k = 0; k < dic.Length; ++k) 
            {
                if (dic[k].ContainsKey(target))
                {
                    dic[k].Remove(target);
                }
                else 
                { 
                var temp = dic[k];
                    dic[k] = For_Delete(temp, target);
                }


            }
            Get_Whole_Dictionary_To_File(dic);
        }
        public void Remove_One_Translation() 
        {
            string[] files = Directory.GetFiles(path);
            Console.WriteLine("Choose dictionary:");
            Show_Dictionary(files);
            int input = int.Parse(Console.ReadLine());
            string choosenFile = files[input - 1];
            Dictionary<string, StringBuilder> dic = Get_Words_From_File(choosenFile);
            Console.WriteLine("Choose word to remove translation");
            Show_Word_In_File(dic);
            string chosen_key = Console.ReadLine();
            string[] sbWords = dic[chosen_key].ToString().Split(",", StringSplitOptions.RemoveEmptyEntries);
            if (sbWords.Length == 1)
            {
                Console.WriteLine("you cant delete last translation");
                return;
            }
            if (!dic.ContainsKey(chosen_key))
            {
                Console.WriteLine("There is no such word!!!");
                return;
            }
            Console.WriteLine("What translation of this word u wanna delete:");
            Console.WriteLine(dic[chosen_key].ToString());
           
            Console.WriteLine("What translation of this word u wanna delete:");
            
            string wordToRemove = Console.ReadLine();
            if (!sbWords.Contains(wordToRemove)) 
            { 
            Console.WriteLine($"{wordToRemove} not found.");
             return;
            }
            string[] newWords = new string[sbWords.Length-1];
            int count = 0;
            for (int k = 0; k < sbWords.Length; ++k) 
            {
                if (sbWords[k] != wordToRemove) 
                {
                    newWords[count++] = sbWords[k];
                }
            }
            StringBuilder sb = new StringBuilder();
            sb.Append(string.Join(",", newWords));
            dic[chosen_key] = sb;
            Get_Single_Dictionary_To_File(dic, choosenFile);
        }
        public void Change_Translation() 
        {
            string[] files = Directory.GetFiles(path);
            Console.WriteLine("Choose dictionary:");
            Show_Dictionary(files);
            int input = int.Parse(Console.ReadLine());
            string choosenFile = files[input - 1];
            Dictionary<string, StringBuilder> dic = Get_Words_From_File(choosenFile);
            Console.WriteLine("What translation you wanna change:");
            Show_Word_In_File(dic);
            string chosen_key = Console.ReadLine();
            if (!dic.ContainsKey(chosen_key))
            {
                Console.WriteLine("There is no such word!!!");
                return;
            }
            Console.WriteLine("Enter new word 1");
            string newWord1 = Console.ReadLine();
            Console.WriteLine("Enter new word 2");
            string newWord2 = Console.ReadLine();
            Change_Word_In_Dictionarys(chosen_key, newWord1, newWord2, choosenFile);


        }
        private void For_Case1() 
        {
            string lan1, lan2, word1, word2;
            Console.WriteLine("Enter first language: 0 - return");
            lan1 = Console.ReadLine();
            if (lan1 == "0") { return; }
            Console.WriteLine("Enter second language: 0 - return");
            lan2 = Console.ReadLine();
            if (lan2 == "0") { return; }
            Console.WriteLine("Enter first word for first language: 0 - return");
            word1 = Console.ReadLine();
            if (word1 == "0") { return; }
            Console.WriteLine("Enter second word for second language: 0 - return");
            word2 = Console.ReadLine();
            if (word2 == "0") { return; }
            Make_New_Dictionary(lan1, lan2, word1, word2);
            Console.WriteLine("Dictionary was create!!!");
           
        }
       
        public void Visual_Interface()
        {
            while (true)
            {
                string lan1, lan2, word1, word2;
                Console.WriteLine("What do u want to do? 0 - exit \n " +
                    "1 - Make new Dictionary\n" +
                    "2 - Add new word to dictionary\n" +
                    "3 - Remove words from dictionary\n" +
                    "4 - Change translate\n" +
                    "5. - Find another translate\n" +
                    "6. - Append new Translation for aldready existing word\n" +
                    "7. - Remove translation for aldready existing word\n"+
                    "0. - exit") ;
                    
                int input = int.Parse(Console.ReadLine());
                switch (input)
                {
                    case 0:
                        Console.WriteLine("u exit"); return;
                        break;

                    case 1:
                        For_Case1();
                        break;
                    case 2:

                        Add_Translate();
                        break;
                    case 3:
                        
                        Remove_Word();
                        break;
                    case 4:
                        Change_Translation();
                        break;
                    case 5:
                        Find_All_Translation();
                        break;
                    case 6:
                        Add_New_Translation_To_Word();
                        break;
                    case 7:
                        Remove_One_Translation();
                        break;
                    default:
                        Console.WriteLine("Enter corect int!!!");
                        break;
                }
//                Завдання 4. (Додаткове).Створити додаток «Словники».
//Основне завдання проекту: зберігати словники на різних мовах і
//знаходити переклад потрібного слова або тексту.
//Інтерфейс програми надаває такі можливості:
//− створити словник. При створенні потрібно вказати тип словника.
//наприклад, англо - український або українсько-англійський;
//− додавати слово і його переклад у вже наявний словник.Оскільки у
//слова може бути кілька перекладів, необхідно підтримувати можливість
//створення декількох варіантів перекладу;
//− замінювати слово або його переклад у словнику;
//− видаляти слово або переклад. Якщо видаляється слово, усі його
//переклади видаляють разом з ним.Не можна видалити переклад слова, якщо це
//останній варіант перекладу;
//− шукати переклад слова;
//− словники повинні зберігатися в файлах;
//− слово і варіанти його перекладів можна експортувати у окремий файл
//результату;
//− якщо вибір пункту меню відкриває підміню, то тоді в ньому потрібно
//передбачити можливість повернення до попереднього меню.
                }
            }
    }
}
