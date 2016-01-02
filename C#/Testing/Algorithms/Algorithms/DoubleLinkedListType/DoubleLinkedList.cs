using System;

namespace Algorithms.DoubleLinkedListType
{
    public class DoubleLinkedList<T>
    {
        private DoubleLinkedListItem<T> head;
        private DoubleLinkedListItem<T> tail;

        public void Add(T data)
        {
            DoubleLinkedListItem<T> newItem = new DoubleLinkedListItem<T>(data);

            if (head != null)
            {   
                newItem.previous = tail;
                tail.next = newItem;
            }
            else
            {
                head = newItem;
            }
            tail = newItem;
        }

        public void RemoveFirst(T toDelete)
        {
            if (head == null) return;

            if (head.data.Equals(toDelete))
            {
                head = head.next;
                head.previous = null;
                return;
            }

            DoubleLinkedListItem<T> current = head;
            while (current.next != null)
            {
                if (current.next.data.Equals(toDelete))
                {
                    current.next = current.next.next;
                    current.next.previous = current;
                    return;
                }
                current = current.next;
            }
        }

        public void RemoveAll(T toDelete)
        {
            if (head == null) { return; }

            DoubleLinkedListItem<T> current = head;
            while (current.next != null)
            {
                if (current.next.data.Equals(toDelete))
                {
                    current.next = current.next.next;
                    if(current.next != null)
                    {
                        current.next.previous = current;
                    }
                    else
                    {
                        tail = current;
                        break;
                    }
                }
                current = current.next;
            }

            if (head.data.Equals(toDelete))
            {
                head = head.next;
                head.previous = null;
            }
        }

        public void Print()
        {
            if(head != null)
            {
                DoubleLinkedListItem<T> current = head;
                while (current.next != null)
                {
                    Console.Write($"{current.data} ");
                    current = current.next;
                }
                Console.WriteLine($"{current.data}");
            }
        }

        public void PrintReverse()
        {
            if (tail != null)
            {
                DoubleLinkedListItem<T> current = tail;
                while (current.previous != null)
                {
                    Console.Write($"{current.data} ");
                    current = current.previous;
                }
                Console.WriteLine($"{current.data}");
            }
        }
    }
}
