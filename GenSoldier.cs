using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabaOOP10
{
    internal class GenSoldier
    {
        private static Random rand = new Random();

        private static string[] names = {
        "Іван Петро Сидор", "Юрій Андрій Богдан", "Олег Микола Степан",
        "Тарас Василь Орест", "Роман Євген Назар"
    };

        private static string[] addresses = {
        "Київ", "Львів", "Одеса", "Харків", "Дніпро"
    };

        private static string[] places = {
        "Військова частина А001", "Полк зв'язку", "Батальйон охорони",
        "Артилерійська бригада", "Медичний корпус"
    };

        public static MilitaryCard[] GenSoldiers(int count)
        {
            MilitaryCard[] cards = new MilitaryCard[count];

            for (int i = 0; i < count; i++)
            {
                string name = names[rand.Next(names.Length)];
                DateTime birth = new DateTime(rand.Next(1980, 2005), rand.Next(1, 13), rand.Next(1, 28));
                string address = addresses[rand.Next(addresses.Length)];
                DateTime demobilDate = DateTime.Today.AddDays(rand.Next(-2000, 1000));
                string servicePlace = places[rand.Next(places.Length)];
                MilitaryCard.suitability suit = (MilitaryCard.suitability)rand.Next(Enum.GetNames(typeof(MilitaryCard.suitability)).Length);

                cards[i] = new MilitaryCard(name, birth, address, demobilDate, servicePlace, suit);
            }

            return cards;
        }
    }
}
