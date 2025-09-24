using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba3._1
{
    internal class Printer:IComparable<Printer>
    {
        public string name_Of_User { get; private set; }
        public string message { get; private set; }
        public int value { get; private set; }
        public DateTime time_Of_using { get; private set; }
        public Printer(){}
        public Printer(string name_Of_User, string message, int value)  
        { 
        this.name_Of_User = name_Of_User;
        this.message = message;
        this.value = value;
        this.time_Of_using = DateTime.Now;
        }
        public Printer(string name_Of_User, string message, DateTime time_Of_using, int value) {
            this.name_Of_User = name_Of_User;
            this.message = message;
            this.value = value;
            this.time_Of_using = time_Of_using;
        }

        public override string ToString() {
            return $"Name of user: {name_Of_User} his value is - {value} \n Time of using: {time_Of_using} \n Massage:{message}";
        }
        public int CompareTo(Printer other)
        {
            return time_Of_using.CompareTo(other.time_Of_using);
        }


    }
}
