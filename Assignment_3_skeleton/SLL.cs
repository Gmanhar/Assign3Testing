using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Assignment_3_skeleton
{
    public class SLL : LinkedListADT
    {
        private Node head;
        private int size;
        // Initializes an empty singly linked list
        public SLL()
        {
            head = null;
            size = 0;
        }

        // Checks if the linked list is empty.
        // <returns>True if the list is empty, otherwise False.</returns>
        public bool IsEmpty()
        {
            return size == 0;
        }

        // Clear
        public void Clear()
        {
            head = null;
            size = 0;
        }

        // Appends an object to the end of the list.
        public void Append(object data)
        {
            var newNode = new Node(data);
            if (head == null)
            {
                head = newNode;
            }
            else
            {
                var current = head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newNode;
            }
            size++;
        }

        // Prepends
        public void Prepend(object data)
        {
            var newNode = new Node(data) { Next = head };
            head = newNode;
            size++;
        }

        //Inserts an object at a specific index
        public void Insert(object data, int index)
        {
            if (index < 0 || index > size)
            {
                throw new IndexOutOfRangeException("Index out of range.");
            }

            if (index == 0)
            {
                Prepend(data);
                return;
            }

            var newNode = new Node(data);
            var current = head;
            for (int i = 0; i < index - 1; i++)
            {
                current = current.Next;
            }
            newNode.Next = current.Next;
            current.Next = newNode;
            size++;
        }

        // Replaces the data 
        public void Replace(object data, int index)
        {
            if (index < 0 || index >= size)
            {
                throw new IndexOutOfRangeException("Index out of range.");
            }

            var current = head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }
            current.Data = data;
        }

        // Removes an element

        public void Delete(int index)
        {
            if (index < 0 || index >= size)
            {
                throw new IndexOutOfRangeException("Index out of range.");
            }

            if (index == 0)
            {
                head = head.Next;
            }
            else
            {
                var current = head;
                for (int i = 0; i < index - 1; i++)
                {
                    current = current.Next;
                }
                current.Next = current.Next.Next;
            }
            size--;
        }

        // Retrieves the data
        public object Retrieve(int index)
        {
            if (index < 0 || index >= size)
            {
                throw new IndexOutOfRangeException("Index out of range.");
            }

            var current = head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }
            return current.Data;
        }

        // Finds the first index of an element containing the specified data.
        // <returns>The index of the first occurrence of the specified data, or -1 if not found.</returns>
        public int IndexOf(object data)
        {
            var current = head;
            for (int i = 0; i < size; i++)
            {
                if (current.Data.Equals(data))
                {
                    return i;
                }
                current = current.Next;
            }
            return -1;
        }

        // Determines if the list contains an element with the specified data.
        // <returns>True if an element with the specified data exists, otherwise False.</returns>
        public bool Contains(object data)
        {
            return IndexOf(data) != -1;
        }

        // Gets the number of elements in the list.
        // <returns>The number of elements in the list.</returns>
        public int Size()
        {
            return size;
        }

        // Internal Node class for the singly linked list.
        private class Node
        {
            public object Data { get; set; }
            public Node Next { get; set; }

            public Node(object data)
            {
                Data = data;
                Next = null;
            }
        }
    }
}