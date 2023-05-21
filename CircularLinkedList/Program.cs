using System;

namespace CircularLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            CircularLinkedList<string> circularList = new CircularLinkedList<string>();

            circularList.Add("Tom");
            circularList.Add("Bob");
            circularList.Add("Alice");
            circularList.Add("Jack");
            foreach (var item in circularList)
            {
                Console.WriteLine(item);
            }

            circularList.Remove("Bob");
            Console.WriteLine("\n После удаления: \n");
            foreach (var item in circularList)
            {
                Console.WriteLine(item);
            }
        }
    }
}
