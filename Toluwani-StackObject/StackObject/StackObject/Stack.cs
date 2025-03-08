using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackObject
{
    class Stack : IStack
    {
        private object[] _items = new object[2];
        private int _count = 0;

        public void Push(object obj)
        {
            if (obj == null)
                throw new InvalidOperationException("Cannot add null to the stack.");

            //Resizes array if full
            if (_count == _items.Length)
                Resize();

            _items[_count] = obj;
            _count++;
        }

        public object Pop()
        {
            if (_count == 0)
                throw new InvalidOperationException("Stack is empty.");

            var lastItem = _items[--_count];
            _items[_count] = null;
            return lastItem;
        }

        public void Clear()
        {
            for (int i = 0; i < _count; i++)
                _items[i] = null;

            _count = 0;
        }

        private void Resize()
        {
            Array.Resize(ref _items, _items.Length * 2);
        }

        public void DisplayArray()
        {
            foreach (var item in _items)
            {
                if (item == null)
                    continue;

                Console.Write($"{item} ");
            }
        }
    }
}

