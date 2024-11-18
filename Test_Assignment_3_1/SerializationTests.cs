using Assignment_3_skeleton;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Test_Assignment_3_1
{
    [TestFixture]
    public class SerializationTests
    {
        private List<User> users;
        private readonly string testFileName = "test_users.bin";

        [SetUp]
        public void Setup()
        {
            users = new List<User>
            {
                new User(1, "Joe Blow", "jblow@gmail.com", "password"),
                new User(2, "Joe Schmoe", "joe.schmoe@outlook.com", "abcdef"),
                new User(3, "Colonel Sanders", "chickenlover1890@gmail.com", "kfc5555"),
                new User(4, "Ronald McDonald", "burgers4life63@outlook.com", "mcdonalds999")
            };
        }

        [TearDown]
        public void TearDown()
        {
            if (File.Exists(testFileName))
            {
                File.Delete(testFileName);
            }
        }

        // Test the serialization of the users list to a binary file.
        [Test]
        public void TestSerialization()
        {
            SerializationHelper.SerializeUsers(users, testFileName);

            // Assert the file is created
            Assert.IsTrue(File.Exists(testFileName), "Serialized file was not created.");
        }

        //Test the deserialization of the users list from a binary file.
        [Test]
        public void TestDeserialization()
        {
            SerializationHelper.SerializeUsers(users, testFileName);
            List<User> deserializedUsers = SerializationHelper.DeserializeUsers(testFileName);

            // Assert the deserialized data matches the original
            Assert.That(deserializedUsers.Count, Is.EqualTo(users.Count), "Deserialized user count does not match the original count.");
            for (int i = 0; i < users.Count; i++)
            {
                Assert.That(deserializedUsers[i].Id, Is.EqualTo(users[i].Id), $"User ID mismatch at index {i}");
                Assert.That(deserializedUsers[i].Name, Is.EqualTo(users[i].Name), $"User Name mismatch at index {i}");
                Assert.That(deserializedUsers[i].Email, Is.EqualTo(users[i].Email), $"User Email mismatch at index {i}");
                Assert.That(deserializedUsers[i].Password, Is.EqualTo(users[i].Password), $"User Password mismatch at index {i}");
            }
        }
    }
}