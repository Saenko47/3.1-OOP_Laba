using Laba3._1;
using LabaOOP10;

namespace Laba3._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Language_Dictionary task = new Language_Dictionary("dictionary");
           
            Console.WriteLine("---------------------");
            task.Visual_Interface();
           
            
            
           
          


        }
    }
}
//-----------------------------------------------------------
//MilitaryCard[] mc = GenSoldier.GenSoldiers(10);
//foreach (var i in mc)
//{
//    Console.WriteLine(i);
//    Console.WriteLine("--------------------");
//}
//Console.WriteLine("new registr:");
//Task1 task1 = new Task1(mc);
//MilitaryCard newmc = new MilitaryCard(
//"Іваненко Іван Іванович",
//new DateTime(1990, 5, 20),
//"м. Київ, вул. Шевченка 10",
//new DateTime(2025, 9, 1),
//"Військова частина №1234",
//MilitaryCard.suitability.suitable
//);
//task1.Add_Soldier(newmc);
//task1.Print_Soldier();
//task1.Change_solier_profile("Іваненко Іван Іванович");
//task1.Print_Soldier();


//MilitaryCard[] card = GenSoldier.GenSoldiers(15);
//Task1 task1 = new Task1(card);
//task1.Save_To_Json("soldier/soldier.txt");

//Task1 task1 = new Task1();
//task1.Load_From_Json("soldier/soldier.txt");
//task1.Print_Soldier();

//MilitaryCard[] card = GenSoldier.GenSoldiers(15);
//Task1 task1 = new Task1(card);
//task1.Save_To_Json("soldier/soldier.txt");
//-----------------------------------------------------------
//Task2 task = new Task2("fortest");
//task.Print_Files();
//task.Get_Texts_Analysis();
//task.Print_Dictionary();


//Task2 task = new Task2("fortest");
//while (true)
//{
//    task.Get_One_Analysis();
//}
//-----------------------------------------------------------
//Printer[] printer = Gen_Printers.Get_Printers(50);
//Task3 task3 = new Task3(printer, "test");
//task3.Print_users();
//Console.WriteLine("-----------------------------------");
//Console.WriteLine("");
//Console.WriteLine("-----------------------------------");
//task3.Get_queue_of_printers();
//-----------------------------------------------------------
//Task4 task = new Task4("dictionary");
//task.Change_Translate("ukr", "en", "Блять", "Одоробло", "Finga");

//task.Test_Shit("ukr", "en");