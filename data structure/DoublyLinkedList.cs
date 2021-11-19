using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
                            //Двухсвязный список
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
        public LinkedListNode<T> Previous { get; set; } 
    }
    public class LinkedList<T> : System.Collections.Generic.IEnumerable<T>
    {
        public LinkedListNode<T> _head;
        public LinkedListNode<T> _tail;

        public int Count { get; set; }

        //AddFirst добавляет элемент в начало списка

        public void AddFirst(T value)
        {
            LinkedListNode<T> node = new LinkedListNode<T>(value);
            
            LinkedListNode<T> temp = _head;
            
            _head = node;
            _head.Next = temp;

            if (Count == 0)
            {
                _tail = _head;
            }
            else
            {
                temp.Previous = _head;
            }
            Count++;
        }
        // AddLast добавляет элемент в конец списка 
        public void AddLast(T value)
        {
            LinkedListNode<T> node = new LinkedListNode<T>(value);

            if (Count == 0)
            {
                _head = node;
            }
            else
            {
                _tail.Next = node;
                node.Previous = _tail;
            }
            _tail = node;
            Count++;
        }

        //AddAfter добавляет элемент после другого элемента(index)
        public void AddAfter(T value, int index)
        {
            LinkedListNode<T> node = new LinkedListNode<T>(value);
            LinkedListNode<T> current = _head;

            int i = 0;
            while(current != null && i != index)
            {
                i++;
                current = current.Next;
            }

            if(current == null)
            {
                Console.WriteLine("Error");
                return;
            }
            
            LinkedListNode<T> temp = current.Next;

            current.Next = node;
            temp.Previous = node;

            node.Next = temp;
            node.Previous = current;

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
                        else
                        {
                            current.Next.Previous = previous;
                        }
                        Count--;
                    }
                    else 
                    {
                        RemoveFirst();
                    }
                    return true;
                }
                previous = current;
                current = current.Next;
            }
            return false;   
        }

        //RemoveFirst удаляет первый элемент списка
        public void RemoveFirst()
        {
            if (Count != 0)
            {
                _head = _head.Next;
                Count--;
                if (Count == 0)
                {
                    _tail = null;
                }
                else
                {
                    _head.Previous = null;
                }
            }
        }
        
        //RemoveLast удаляет последний элемент списка
        public void RemoveLast()
        {
            if (Count != 0)
            {
                if (Count == 1)
                {
                    _head = null;
                    _tail = null;
                }
                else
                {
                    _tail.Previous.Next = null;
                    _tail = _tail.Previous;
                }
                Count--;
            }
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
            
            list.AddFirst(1);
            list.AddFirst(4);
            list.AddLast(8);
            list.AddLast(24);

            Display(list);

            //удаление элемента
            Console.WriteLine("Delete element: ");

            list.Remove(4);

            Display(list);
            //копирование списка в массив
            Console.WriteLine("Copy to array: ");
            Console.WriteLine("Add new element(5) in list: ");
            list.AddAfter(5, 0);
            Display(list);

            int[] table = new int[6];
            list.CopyTo(table, 1); // копирование списка с индекса 1
            foreach (var item in table)
            {
                Console.WriteLine(item);
            }

            //удаление первого и последнего элемента 
            Console.WriteLine("Delete last element: ");
            Display(list);  // до изменения

            list.RemoveFirst();
            list.RemoveLast();

            Display(list);

        }
    }
}
