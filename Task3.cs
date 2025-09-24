using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba3._1
{
    internal class Task3
    {
        Printer[] users;
        string path;
        public Task3()
        {

        }
        public Task3(Printer[] users, string path)
        {
            this.users = users;
            this.path = path;
        }
        public void Print_users()
        {
            foreach (Printer printer in users)
            {
                Console.WriteLine(printer.ToString());
            }

        }
        private void Save_To_File(Queue<Printer> pr) {
            if (!Directory.Exists(path)) { 
            Directory.CreateDirectory(path);
            }
            string total_path = Path.Combine(path, "result.txt");
            using (StreamWriter sw = new StreamWriter(total_path)) {
                while (pr.Count > 0) 
                {
                    Printer curr = pr.Dequeue();
                    sw.WriteLine(curr.ToString());
                }
               
            }
        }
        public void Get_queue_of_printers() 
        {
            Queue<Printer> queue = new Queue<Printer>();
        PriorityQueue<Printer, (int,int)> prior = new PriorityQueue<Printer, (int, int)>();
           
            for (int k = 0;k<users.Length ; ++k) {
                prior.Enqueue(users[k],(users[k].value, k));
            }
            while (prior.Count > 0) { 
            Printer curr = prior.Dequeue();
            queue.Enqueue(curr);
            Console.WriteLine(curr.ToString());
            }
            Save_To_File(queue);
        }
//        Завдання 3. Розробити додаток, що імітує чергу друку принтера.
//        Розгляньте можливість існування приорітету у клієнтів, що посилають запит на
//        друк.Необхідно зберігати статистику друку (користувач, час) у окремій
//        колекції. Передбачити виведення статистики друку на екран і/або у файл.Завдання 3. Розробити додаток, що імітує чергу друку принтера.
//Розгляньте можливість існування приорітету у клієнтів, що посилають запит на
//друк.Необхідно зберігати статистику друку (користувач, час) у окремій
//колекції. Передбачити виведення статистики друку на екран і/або у файл.
    }
}
