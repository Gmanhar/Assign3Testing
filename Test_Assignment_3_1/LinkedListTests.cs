using Assignment_3_skeleton;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
/*using static System.Runtime.InteropServices.JavaScript.JSType;*/

namespace Test_Assignment_3_1
{
    [TestFixture]
    public class LinkedListTests
    {
        private LinkedListADT linkedList;

        [SetUp]
        public void Setup()
        {
            this.linkedList = new SLL(); // Initialize a new linked list before each test
        }

        [TearDown]
        public void TearDown()
        {
            this.linkedList.Clear(); // Clear the list after each test
        }

        // Test the linked list is empty.
        [Test]
        public void TestIsEmpty()
        {
            Assert.IsTrue(linkedList.IsEmpty(), "The linked list should be empty.");
            Assert.That(linkedList.Size(), Is.EqualTo(0), "The size of the linked list should be 0.");
        }

        // Test appending elements to the linked list.
        [Test]
        public void TestAppendNode()
        {
            linkedList.Append("a");
            linkedList.Append("b");
            linkedList.Append("c");
            linkedList.Append("d");

            /**
            * Linked list should now be:
            * 
            * a -> b -> c -> d
            */

            // Test the linked list is not empty.
            Assert.IsFalse(linkedList.IsEmpty(), "The linked list should not be empty.");
            Assert.That(linkedList.Size(), Is.EqualTo(4), "The size of the linked list should be 4.");

            // Test the values of the nodes.
            Assert.That(linkedList.Retrieve(0), Is.EqualTo("a"), "The first node value should be 'a'.");
            Assert.That(linkedList.Retrieve(1), Is.EqualTo("b"), "The second node value should be 'b'.");
            Assert.That(linkedList.Retrieve(2), Is.EqualTo("c"), "The third node value should be 'c'.");
            Assert.That(linkedList.Retrieve(3), Is.EqualTo("d"), "The fourth node value should be 'd'.");
        }

        // Test prepending elements to the linked list.
        [Test]
        public void TestPrependNodes()
        {
            linkedList.Prepend("a");
            linkedList.Prepend("b");
            linkedList.Prepend("c");
            linkedList.Prepend("d");

            /**
            * Linked list should now be:
            * 
            * d -> c -> b -> a
            */

            // Test the linked list is not empty.
            Assert.IsFalse(linkedList.IsEmpty(), "The linked list should not be empty.");

            // Test the size is 4.
            Assert.That(linkedList.Size(), Is.EqualTo(4), "The size of the linked list should be 4.");

            // Test the values of the nodes.
            Assert.That(linkedList.Retrieve(0), Is.EqualTo("d"), "The first node value should be 'd'.");
            Assert.That(linkedList.Retrieve(1), Is.EqualTo("c"), "The second node value should be 'c'.");
            Assert.That(linkedList.Retrieve(2), Is.EqualTo("b"), "The third node value should be 'b'.");
            Assert.That(linkedList.Retrieve(3), Is.EqualTo("a"), "The fourth node value should be 'a'.");
        }

        //Tests inserting node at valid index.
        [Test]
        public void TestInsertNode()
        {
            linkedList.Append("a");
            linkedList.Append("b");
            linkedList.Append("c");
            linkedList.Append("d");

            linkedList.Insert("e", 2);

            /**
             * Linked list should now be:
             * 
             * a -> b -> e -> c -> d
             */

            // Test the linked list is not empty.
            Assert.IsFalse(linkedList.IsEmpty(), "The linked list should not be empty.");

            // Test the size is 5.
            Assert.That(linkedList.Size(), Is.EqualTo(5), "The size of the linked list should be 5.");

            // Test the values of the nodes.
            Assert.That(linkedList.Retrieve(0), Is.EqualTo("a"), "The first node value should be 'a'.");
            Assert.That(linkedList.Retrieve(1), Is.EqualTo("b"), "The second node value should be 'b'.");
            Assert.That(linkedList.Retrieve(2), Is.EqualTo("e"), "The third node value should be 'e'.");
            Assert.That(linkedList.Retrieve(3), Is.EqualTo("c"), "The fourth node value should be 'c'.");
            Assert.That(linkedList.Retrieve(4), Is.EqualTo("d"), "The fifth node value should be 'd'.");
        }

        // Test replacing existing nodes data.
        [Test]
        public void TestReplaceNode()
        {
            linkedList.Append("a");
            linkedList.Append("b");
            linkedList.Append("c");
            linkedList.Append("d");

            linkedList.Replace("e", 2);

            /**
             * Linked list should now be:
             * 
             * a -> b -> e -> d
             */

            // Test the linked list is not empty.
            Assert.IsFalse(linkedList.IsEmpty(), "The linked list should not be empty.");

            // Test the size is 4.
            Assert.That(linkedList.Size(), Is.EqualTo(4), "The size of the linked list should be 4.");

            // Test the values of the nodes.
            Assert.That(linkedList.Retrieve(0), Is.EqualTo("a"), "The first node value should be 'a'.");
            Assert.That(linkedList.Retrieve(1), Is.EqualTo("b"), "The second node value should be 'b'.");
            Assert.That(linkedList.Retrieve(2), Is.EqualTo("e"), "The third node value should be 'e' after replacement.");
            Assert.That(linkedList.Retrieve(3), Is.EqualTo("d"), "The fourth node value should be 'd'.");
        }


        //Tests deleting node from linked list
        [Test]
        public void TestDeleteNode()
        {
            linkedList.Append("a");
            linkedList.Append("b");
            linkedList.Append("c");
            linkedList.Append("d");

            linkedList.Delete(2);

            /**
          * Linked list should now be:
          * 
          * a -> b -> d
          */

            // Test the linked list is not empty.
            Assert.IsFalse(linkedList.IsEmpty(), "The linked list should not be empty.");

            // Test the size is 3.
            Assert.That(linkedList.Size(), Is.EqualTo(3), "The size of the linked list should be 3 after deletion.");

            // Test the values of the remaining nodes.
            Assert.That(linkedList.Retrieve(0), Is.EqualTo("a"), "The first node value should be 'a'.");
            Assert.That(linkedList.Retrieve(1), Is.EqualTo("b"), "The second node value should be 'b'.");
            Assert.That(linkedList.Retrieve(2), Is.EqualTo("d"), "The third node value should be 'd'.");
        }

        //Tests finding and retrieving node in linked list.
        [Test]
        public void TestFindNode()
        {
            linkedList.Append("a");
            linkedList.Append("b");
            linkedList.Append("c");
            linkedList.Append("d");

            /**
        * Linked list should now be:
        * 
        * a -> b -> c -> d
        */

            // Test if the linked list contains the specified value.
            Assert.IsTrue(linkedList.Contains("b"), "The linked list should contain 'b'.");

            // Test the index of the specified value.
            Assert.That(linkedList.IndexOf("b"), Is.EqualTo(1), "The index of 'b' should be 1.");

            // Test the value at the specified index.
            Assert.That(linkedList.Retrieve(1), Is.EqualTo("b"), "The value at index 1 should be 'b'.");
        }
        [Test]
        public void TestClear()
        {
            linkedList.Append("a");
            linkedList.Append("b");
            linkedList.Append("c");

            linkedList.Clear();

            // Test if the linked list is empty after clearing.
            Assert.IsTrue(linkedList.IsEmpty(), "The linked list should be empty after clearing.");

            // Test the size of the linked list.
            Assert.That(linkedList.Size(), Is.EqualTo(0), "The size of the linked list should be 0 after clearing.");
        }

        [Test]
        public void TestInsertOutOfBounds()
        {
            linkedList.Append("a");

            // Test that inserting at an invalid index throws an exception.
            Assert.Throws<IndexOutOfRangeException>(
                () => linkedList.Insert("b", 5),
                "Inserting at an invalid index should throw an IndexOutOfRangeException."
            );
        }

        [Test]
        public void TestReplaceAtInvalidIndex()
        {
            linkedList.Append("a");

            // Test that replacing at an invalid index throws an exception.
            Assert.Throws<IndexOutOfRangeException>(
                () => linkedList.Replace("b", 5),
                "Replacing at an invalid index should throw an IndexOutOfRangeException."
            );
        }

        [Test]
        public void TestRetrieveOutOfBounds()
        {
            linkedList.Append("a");

            // Test that retrieving from an invalid index throws an exception.
            Assert.Throws<IndexOutOfRangeException>(
                () => linkedList.Retrieve(5),
                "Retrieving from an invalid index should throw an IndexOutOfRangeException."
            );
        }
    }
}