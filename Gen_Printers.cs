using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba3._1
{
    internal class Gen_Printers
    {
        static Random random = new Random();
        static private string[] names = {
    "Andriy",
    "Olena",
    "Maksym",
    "Iryna",
    "Vladyslav",
    "Kateryna",
    "Oleh",
    "Tetiana",
    "Dmytro",
    "Sofiia",
    "Petro",
    "Nadiia",
    "Yurii",
    "Mariia",
    "Serhii",
    "Halyna",
    "Bohdan",
    "Anastasiia",
    "Volodymyr",
    "Kristina"
};
        static private string[] texts = {
          "Сонце зійшло над містом. Люди поспішали на роботу.",
    "Дощ барабанив по даху. У кімнаті було тепло і затишно.",
    "Кіт солодко спав на підвіконні. Йому снилися цікаві сни.",
    "Діти гралися у дворі. Сміх лунав на всю вулицю.",
    "Вітер хитав гілки дерев. Листя падало на землю.",
    "Ранок почався з кави. Вона додала сил на весь день.",
    "У лісі було тихо. Лише пташки співали свої пісні.",
    "На річці плавали качки. Вода мерехтіла на сонці.",
    "Собака чекав господаря біля дому. Він радісно махав хвостом.",
    "Вечірнє небо вкривалося зорями. Місяць світив яскраво.",
    "Поїзд мчав крізь поля. Вікна вагона відбивали сонце.",
    "У бібліотеці панувала тиша. Хтось перегортав сторінки книги.",
    "На кухні пахло свіжим хлібом. Господиня радо усміхалася.",
    "Хмари закривали небо. Наближалася гроза.",
    "У парку грала музика. Закохані пари прогулювались алеями.",
    "Сніг вкрив землю білим килимом. Діти будували сніговика.",
    "Літак здіймався в небо. Пасажири дивилися у вікна.",
    "На полі достигала пшениця. Фермери готувалися до жнив.",
    "Годинник пробив полудень. У місті стало гамірно.",
    "Море шуміло хвилями. Чайки літали над водою."
        };
        static private DateTime Get_Random_Date() {
            int year = random.Next(1950, 2025);
            int month = random.Next(1, 13);
            int daysInMonth = DateTime.DaysInMonth(year, month);
            int day = random.Next(1, daysInMonth + 1);
            DateTime date_Of_using = new DateTime(year, month, day);
            return date_Of_using;
        }
        static public Printer[] Get_Printers(int count) { 
        Printer[] printer = new Printer[count];
            for (int k = 0; k < count; ++k) {
                string name = names[random.Next(0, names.Length)];
                string text = texts[random.Next(0, texts.Length)];
                int value = random.Next(1,4);
                DateTime date_Of_using = Get_Random_Date();
                printer[k] = new Printer(name, text, date_Of_using, value);
            }
            Array.Sort(printer);
        return printer;
        }
    }
}
