using System;

namespace Algorithms.LinkedListType
{
    public class LinkedList<T>
    {
        private LinkedListItem<T> head;

        public void Add(T data)
        {
            LinkedListItem<T> newItem = new LinkedListItem<T>(data);

            if (head != null)
            {
                LinkedListItem<T> current = head;
                while (current.next != null)
                {
                    current = current.next;
                }
                current.next = newItem;
            }
            else
            {
                head = newItem;
            }
        }

        public void RemoveFirst(T toDelete)
        {
            if (head == null) return;

            if (head.data.Equals(toDelete))
            {
                head = head.next;
                return;
            }

            LinkedListItem<T> current = head;
            while (current.next != null)
            {
                if (current.next.data.Equals(toDelete))
                {
                    current.next = current.next.next;
                    return;
                }
                current = current.next;
            }
        }

        public void RemoveAll(T toDelete)
        {
            if (head == null) { return; }

            LinkedListItem<T> current = head;
            while (current.next != null)
            {
                if (current.next.data.Equals(toDelete))
                {
                    current.next = current.next.next;
                }
                if (current.next != null)
                {
                    current = current.next;
                }
            }

            if (head.data.Equals(toDelete))
            {
                head = head.next;
            }
        }

        public void Print()
        {
            if(head != null)
            {
                LinkedListItem<T> current = head;
                while (current.next != null)
                {
                    Console.Write($"{current.data} ");
                    current = current.next;
                }
                Console.WriteLine($"{current.data}");
            }
        }
    }
}
