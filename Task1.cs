using LabaOOP10;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static LabaOOP10.MilitaryCard;

namespace Laba3._1
{
    internal class Task1
    {
        private List<MilitaryCard> militaryCards;
        public Task1() {
            militaryCards = new List<MilitaryCard>();
        }
        public Task1(MilitaryCard[] militaryCards) {
            this.militaryCards = militaryCards.ToList();
        }
       
        public void Add_Soldier(MilitaryCard mc)
        {
            militaryCards.Add(mc);
        }
        public void Delete_soldier_by_name(string name) {
            for (int k = 0; k < militaryCards.Count; ++k) {
                if (militaryCards[k].name == name) {
                    militaryCards.RemoveAt(k);
                }
            }
           
        }
        private void For_Change_soldier_profile(MilitaryCard mc) {
            Console.WriteLine("Are u want change name? 1 - yes 2 - no ");
            int decision = int.Parse(Console.ReadLine());
            if (decision == 1) {
                string newName = Console.ReadLine();
                mc.name = newName;
            }
            Console.WriteLine("Are u want change date of birh? 1 -yes 2 -no");
            decision = int.Parse(Console.ReadLine());
            if (decision == 1)
            {
                DateTime newbd = DateTime.Parse(Console.ReadLine());
                mc.yearOfBirth = newbd;
            }
            Console.WriteLine("are u want change adress? 1 - yes 2 - no");
            decision = int.Parse(Console.ReadLine());
                if(decision == 1){ 
            string newAdress = Console.ReadLine();
                mc.adress = newAdress;
            }
            Console.WriteLine("Are u want change date of demobilization? 1 -yes 2 -no");
            decision = int.Parse(Console.ReadLine());
            if (decision == 1)
            {
                DateTime newdod = DateTime.Parse(Console.ReadLine());
                mc.dateOfDemobilization = newdod;
            }
            Console.WriteLine("Are u want chage palce of service 1 - yes? 2 - no");
            decision = int.Parse(Console.ReadLine());
            if (decision == 1)
            {
                string newpoc = Console.ReadLine();
                mc.placeOfService = newpoc;
            }
            Console.WriteLine("wanna change suitability? 1 - yes 2 - no?");
            decision = int.Parse(Console.ReadLine());
            if (decision == 1)
            {
                string newsui = Console.ReadLine();
                suitability value = (suitability)Enum.Parse(typeof(suitability), newsui);
                mc.suitabilitys = value;
            }
        }
        public void Change_solier_profile(string name) {
            for (int k = 0; k < militaryCards.Count; ++k) {
                if (militaryCards[k].name == name) {
                    For_Change_soldier_profile(militaryCards[k]);
                    return;
                }

            }
            Console.WriteLine("There is no such soldier!!");
           

        }
        public void Print_Soldier() {
            foreach (var i in militaryCards) {
                Console.WriteLine(i);
                Console.WriteLine("--------------------");
            }
        }
        public void Save_To_Json(string path) {
          
            string? directory = Path.GetDirectoryName(path);
            if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory)) { 
            Directory.CreateDirectory(directory);
            }
           
            string json = JsonSerializer.Serialize(militaryCards, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(path, json);
        }
        public void Load_From_Json(string path) {
            if (!File.Exists(path))
            {
                throw new Exception("Theres no such file!");
            }
            else {
                string json = File.ReadAllText(path);
                MilitaryCard[] som = JsonSerializer.Deserialize<MilitaryCard[]>(json);
                militaryCards = som.ToList();
            }
        }
        public void SaveToFileXml(string path, MilitaryCard[] soldeirs)
        {
            string? directory = Path.GetDirectoryName(path);
            if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            if (!File.Exists(path))
            {
                File.Create(path).Close();
            }
            ;
            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(MilitaryCard[]));
            using (StreamWriter writer = new StreamWriter(path))
            {
                serializer.Serialize(writer, soldeirs);
            }
        }
        public void LoadFromFileXml(string path)
        {
            if (!File.Exists(path)) throw new Exception("File not found");
            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(MilitaryCard[]));
            using (StreamReader reader = new StreamReader(path))
            {
                militaryCards = (MilitaryCard[])serializer.Deserialize(reader);
            }
        }
        public void GetDemobilized()
        {
            Console.WriteLine("Input date (e.g., 2024-12-31):");
            DateTime date = DateTime.Parse(Console.ReadLine());
            foreach (var notSoldier in militaryCards)
            {
                if (date > notSoldier.DateOfDemobilization)
                {
                    Console.WriteLine($"{notSoldier.Name} has demobilize {notSoldier.DateOfDemobilization}");
                }
            }
        }

    }
    }
//Створити список(ArrayList або List<T>) екземплярів класу
//відповідно до варіанта Завдання 1 з лабораторної роботи No 1. Створити
//функціонал, що дозволить створювати й додавати нові екземпляри класу до
//списку, видаляти або коригувати уже наявні екземпляри списку. Виконати
//запит до списку відповідно до завдання. Результат запиту вивести на екран і у
//файл.