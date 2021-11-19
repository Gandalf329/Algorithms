using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
            //Динамический массив
namespace Algorithms
{
    public class DynamicArray<T>
    {
        public T[] data;
        public int count;

        public DynamicArray() : this(4)
        {

        }
        public DynamicArray(int size)
        {
            data = new T[size];
            count = 0;  
        }
        //resize увеличивает длину массива
        public void resize()
        {
            int capacity =  data.Length == 0 ? 4 : data.Length * 2; // попробовать +1
            T[] newArray = new T[capacity];

            data.CopyTo(newArray, 0);
            data = newArray;
        }
        //IsFull проверяет полон ли массив
        public bool IsFull()
        {
            return count == data.Length;
        }
        //Add добавляет элемент в конец списка
        public void Add (T item)
        {
            if (this.IsFull())
            {
                this.resize();
            }
            data[count++] = item;
        }
        //Insert вставляет элемент на нужный индекс
        public void Insert (T item, int index)
        {
            if( index > count)
            {
                return;
            }
            if (this.IsFull())
            {
                this.resize();
            }
            Array.Copy(data, index, data, index + 1, count - index);
            data[index] = item;
            count++;
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            DynamicArray<int> array = new DynamicArray<int>(5);
            array.Add(1);
            array.Add(3);
            array.Add(11);
            array.Add(8);
            array.Insert(24, 5);
            array.Insert(23, 4);
            
        }
    }
}
