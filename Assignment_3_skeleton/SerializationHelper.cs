using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Assignment_3_skeleton
{
    //Serializing and deserializing user data to and from binary files.
    public static class SerializationHelper
    {
        //Serializes a list of users to a binary file
        public static void SerializeUsers(List<User> users, string fileName)
        {
            if (users == null)
            {
                throw new ArgumentNullException(nameof(users), "User list cannot be null.");
            }

            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream stream = File.Create(fileName))
            {
                formatter.Serialize(stream, users);
            }
        }
        // Deserializes
        public static List<User> DeserializeUsers(string fileName)
        {
            if (!File.Exists(fileName))
            {
                throw new FileNotFoundException($"The file {fileName} does not exist.");
            }

            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream stream = File.OpenRead(fileName))
            {
                return (List<User>)formatter.Deserialize(stream);
            }
        }
    }
}
