using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_3_skeleton
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Create a new singly linked list
            SLL list = new SLL();

            //Add the provided users to the list
            Console.WriteLine("Adding provided users to the linked list...");
            list.Append(new User(1, "Joe Blow", "jblow@gmail.com", "password"));
            list.Append(new User(2, "Joe Schmoe", "joe.schmoe@outlook.com", "abcdef"));
            list.Append(new User(3, "Colonel Sanders", "chickenlover1890@gmail.com", "kfc5555"));
            list.Append(new User(4, "Ronald McDonald", "burgers4life63@outlook.com", "mcdonalds999"));

            //Display the list size and contents
            Console.WriteLine($"\nList contains {list.Size()} items.");
            DisplayListContents(list);

            //Insert a new user at index 2
            Console.WriteLine("\nInserting a new user at index 2...");
            list.Insert(new User(5, "Gurman Harika", "Gman@gmail.com", "camper3333"), 2);
            Console.WriteLine("Updated list after insertion:");
            DisplayListContents(list);

            //Replace a user at index 3
            Console.WriteLine("\nReplacing the user at index 3...");
            list.Replace(new User(6, "Jalen Hurts", "Hurts@eagles.com", "philly01"), 3);
            Console.WriteLine("Updated list after replacement:");
            DisplayListContents(list);

            //Delete the user at index 4
            Console.WriteLine("\nDeleting the user at index 4...");
            list.Delete(4);
            Console.WriteLine("Updated list after deletion:");
            DisplayListContents(list);

            //Serialize the list to a binary file
            Console.WriteLine("\nSerializing the list to binary file 'users.bin'...");
            List<User> users = ConvertLinkedListToList(list);
            SerializationHelper.SerializeUsers(users, "users.bin");
            Console.WriteLine("Binary serialization complete.");

            //Deserialize the list from the binary file
            Console.WriteLine("\nDeserializing from binary file 'users.bin'...");
            List<User> deserializedUsers = SerializationHelper.DeserializeUsers("users.bin");
            Console.WriteLine("Deserialized users:");
            foreach (User user in deserializedUsers)
            {
                Console.WriteLine($"User: {user.Name} ({user.Email})");
            }

            // Confirm program completion
            Console.WriteLine("\nProgram execution complete.");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey(); // Prevents the console from closing immediately
        }
        //display contents of the linked list.
        static void DisplayListContents(SLL list)
        {
            for (int i = 0; i < list.Size(); i++)
            {
                User user = (User)list.Retrieve(i);
                Console.WriteLine($"User at index {i}: {user.Name} ({user.Email})");
            }
        }
        //convert linked list to a standard list of users.
        static List<User> ConvertLinkedListToList(SLL list)
        {
            List<User> users = new List<User>();
            for (int i = 0; i < list.Size(); i++)
            {
                users.Add((User)list.Retrieve(i));
            }
            return users;
        }
    }
}
