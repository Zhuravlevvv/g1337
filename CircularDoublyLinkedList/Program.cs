using System;

namespace CircularDoublyLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            CircularDoublyLinkedList<string> circularList = new CircularDoublyLinkedList<string>();
            circularList.Add("Tom");
            circularList.Add("Bob");
            circularList.Add("Alice");
            circularList.Add("Sam");

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
