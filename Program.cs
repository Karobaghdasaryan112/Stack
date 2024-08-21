using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyStack<int> ints = new MyStack<int>();

            ints.Push(1);
            ints.Push(2);
            ints.Push(3);
            ints.Push(4);
            ints.Push(5);   


            ints.Pop();

            Console.WriteLine(ints.Peek());

            foreach (int i in ints)
            {
                Console.WriteLine(i);
            }

            Console.ReadLine();
        }
    }
    public class MyStack<T> : IEnumerable<T>
    {
        private int _size;
        private int _capacity;
        private T[] _values;
        public int Count => _size;
        public MyStack()
        {
            _values = new T[4];
            _capacity = 4;
            _size = -1;
        }

        public MyStack(ICollection<T> values)
        {
            if (values == null) throw new ArgumentNullException();
            foreach (var item in values)
            {
                this.Push(item);
            }
        }

        public int GetCapacity()
        {
            _capacity = (_capacity == 0) ? 4 : _capacity;
            while (_size+1 >= _capacity)
            {
                _capacity *= 2;
            }
            Array.Resize(ref _values, _capacity);
            return _capacity;
        }

        public int GetSize()
        {
            return _size;
        }

        public MyStack(int capacity)
        {
            _capacity = capacity;
            _size = -1;
            _values = new T[_capacity];
        }

        public void Push(T value)
        {
            if (_values == null) throw new ArgumentNullException();
            GetCapacity();
            _size++;
            _values[_size] = value;

        }

        public void Pop()
        {

            _values[_size] = default;
            _size--;
        }

        public T Peek()
        {
            return (T)_values[_size];
        }

        public bool Contains(T value)
        {
            return _values.Contains(value);
        }

        public void Clear()
        {
            _capacity = 0;
            _size = 0;
            _values = new T[0];
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return _values.GetEnumerator();
        }
        public IEnumerator<T> GetEnumerator()
        {
            return new MyEnumerator<T>(_values,_size);
        }
    }
    public class MyEnumerator<T> : IEnumerator<T>
    {
        private T[] values;
        private int _size;
        private int index;
        private T current;
        public MyEnumerator(T[] values,int size)
        {
            this.values = values;
            this._size = size;
            index = _size;
        }
        public void Dispose()
        {

        }
        public void Reset()
        {
            _size = -1;
            values = default;
        }
        public bool MoveNext()
        {
            if (index >= 0)
            {   
                current = values[index--];
                return true;
            }
            return false;
        }
        public T Current => current;
        object IEnumerator.Current => Current;
    }
}
