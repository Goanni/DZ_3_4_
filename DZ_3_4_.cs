using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DZ_3_4
{
    public class DoublyNode<T>
    {
        public DoublyNode(T data)
        {
            Data = data;
        }
        public T Data { get; set; }
        public DoublyNode<T> Previous { get; set; }
        public DoublyNode<T> Next { get; set; }
    }

    public class Deque<T>
    {
        private DoublyNode<T> head;
        private DoublyNode<T> tail;
        private int count;

        public Deque()
        {
            count = 0;
        }

        public bool IsEmpty()
        {
            return count == 0;
        }

        public int Size()
        {
            return count;
        }

        public int Find_Element(T value)
        {
            if (count == 0)
                throw new InvalidOperationException("Очередь пуста!");
            DoublyNode<T> temp = head;
            for (int i = 0; i < count; i++)
            {
                if (temp.Data.Equals(value))
                    Console.WriteLine("Поиск нужного элемента имеет индекс {0} в списке", i);
                temp = temp.Next;
            }
            return -1;
        }

        public void AddFirst(T data)
        {
            DoublyNode<T> node = new DoublyNode<T>(data);
            DoublyNode<T> temp = head;
            node.Next = temp;
            head = node;
            if (count == 0)
                tail = head;
            else
                temp.Previous = node;
            count++;
        }

        public void AddLast(T data)
        {
            DoublyNode<T> node = new DoublyNode<T>(data);

            if (head == null)
                head = node;
            else
            {
                tail.Next = node;
                node.Previous = tail;
            }
            tail = node;
            count++;
        }

        public T RemoveFirst()
        {
            if (count == 0)
                throw new InvalidOperationException("Очередь пуста!");
            T output = head.Data;
            if (count == 1)
            {
                head = tail = null;
            }
            else
            {
                head = head.Next;
                head.Previous = null;
            }
            count--;
            return output;
        }
        public T RemoveLast()
        {
            if (count == 0)
                throw new InvalidOperationException("Очередь пуста!");
            T output = tail.Data;
            if (count == 1)
            {
                head = tail = null;
            }
            else
            {
                tail = tail.Previous;
                tail.Next = null;
            }
            count--;
            return output;
        }

        public void Write_queue()
        {
            DoublyNode<T> temp = head;
            for (int i = 0; i < count; i++)
            {
                Console.Write(temp.Data + " ");
                temp = temp.Next;
            }
            Console.WriteLine();
        }

        public void Remove_Element(T data)
        {
            if (count == 0)
                throw new InvalidOperationException("Очередь пуста!");
            DoublyNode<T> temp = head;
            for (int i = 0; i < count; i++)
            {
                if (temp.Data.Equals(data))
                    if (i == 0)
                    {
                        if (count == 1)
                        {
                            head = tail = null;
                        }
                        else
                        {
                            head = head.Next;
                            head.Previous = null;
                        }
                        count--;
                        i = -1;
                    }
                    else if (i == count - 1)
                    {
                        if (count == 1)
                        {
                            head = tail = null;
                        }
                        else
                        {
                            tail = tail.Previous;
                            tail.Next = null;
                        }
                        count--;

                    }
                    else
                    {
                        temp.Previous.Next = temp.Next;
                        temp.Next.Previous = temp.Previous;
                        count--;
                        i--;

                    }
                temp = temp.Next;
            }

        }
    }


    internal class DZ_3_4
    {
        static void Main()
        {
            Deque<int> deque = new Deque<int>();
            deque.AddFirst(1);
            deque.AddFirst(2);
            deque.AddFirst(3);
            deque.AddLast(4);
            deque.AddLast(3);
            deque.AddLast(5);
            deque.AddFirst(3);
            deque.AddLast(3);
            deque.Write_queue();

            //deque.RemoveFirst();
            //deque.RemoveLast();
            //deque.Write_queue();

            deque.Find_Element(3);

            deque.Remove_Element(3);
            deque.Write_queue();
        }

    }
}

