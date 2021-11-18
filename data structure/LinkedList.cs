using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;

namespace Algorithms
{
    public class LinkedListNode<T>
    {
        public LinkedListNode(T value)
        {
            Value = value;
        }
        public T Value { get; set; }

        public LinkedListNode<T> Next { get; set; }
    }
    public class LinkedList<T> : System.Collections.Generic.IEnumerable<T>
    {
        public LinkedListNode<T> _head;
        public LinkedListNode<T> _tail;

        public int Count { get; set; }

        //Add добавляет элемент в конец списка

        public void Add(T value)
        {
            LinkedListNode<T> node = new LinkedListNode<T>(value);

            if (_head == null)
            {
                _head = node;
                _tail = node;
            }
            else
            {
                _tail.Next = node;
                _tail = node;
            }
            Count++;

        }

        //Remove удаляет элемент из списка
        public bool Remove(T item)
        {
            LinkedListNode<T> previous = null;
            LinkedListNode<T> current = _head;

            while (current != null)
            {
                if (current.Value.Equals(item))
                {
                    if (previous != null)
                    {
                        previous.Next = current.Next;
                        if (current.Next == null)
                        {
                            _tail = previous;
                        }
                    }
                    else 
                    {
                        _head = _head.Next; 

                        if (_head == null)
                        {
                            _tail = null;
                        }
                    }
                    Count--;
                    return true;
                }
                previous = current;
                current = current.Next;
            }
            return false;   
        }

        //Clear очищает список
        public void Clear()
        {
            _head = null;
            _tail = null;
            Count = 0;
        }

        //CopyTo копирует содержимое в массив
        public void CopyTo(T[] array, int index)
        {
            LinkedListNode<T> current = _head;

            while (current != null)
            {
                array[index++] = current.Value;
                current = current.Next;
            }
        }

        //Нумератор IEnumertor<T> для коллекции
        public System.Collections.Generic.IEnumerator<T> GetEnumerator()
        {
            LinkedListNode<T> current = _head;
            
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }
        
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)this).GetEnumerator();
        }
    }
    internal class Program
    {
        public static void Display(LinkedList<int> nums)
        {
            Console.WriteLine("Linked list: ");
            foreach(int num in nums)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine("\n");
        }
        static void Main(string[] args)
        {
            LinkedList<int> list = new LinkedList<int>();

            // добавление элементов
            Console.WriteLine("Add elements: ");
            list.Add(1);
            list.Add(4);
            list.Add(8);
            list.Add(24);
            list.Add(33);

            Display(list);

            // удаление элемента
            Console.WriteLine("Remove element: ");
            list.Remove(4);
            
            Display(list);

            // копирование списка в массив
            Console.WriteLine("Copy to array: ");
            list.Add(11);
            int[] table = new int[7];
            list.CopyTo(table, 2); // копирование списка с индекса 2
            foreach(var item in table)
            {
                Console.WriteLine(item);
            }

            //Удаление списка
            Console.Write("Удаление списка. ");
            list.Clear();

            Console.WriteLine("\n");
            
            list.Add(123);
            Display(list);
        }
    }
}
