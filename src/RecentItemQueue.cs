using System.Collections.Generic;

namespace PulsarFuse
{
    public class RecentItemQueue<T> where T : class
    {
        private readonly int _size;
        private int _head;
        private int _tail;
        private readonly T[] _items;

        public RecentItemQueue(int size)
        {
            _head = -1;
            _tail = -1;
            _size = size;
            _items = new T[size];
        }

        public IReadOnlyList<T> GetItems()
        {
            // the latest item (last in) will be in the first place of output list
            List<T> items = new List<T>();

            if (_head == -1)
            {
                return items;
            }

            int index = _head;

            for (int i = 0; i < _size; i++)
            {
                if (index == -1)
                {
                    index = _size - 1;
                }

                if (_items[index] != null)
                {
                    items.Add(_items[index]);
                }

                index--;
            }

            return items;
        }

        public void SetItem(T item)
        {
            // initial case
            if (_head == -1)
            {
                _head = 0;
                _tail = 1;
                _items[_head] = item;
                return;
            }

            if (Contains(item, out int target))
            {
                // when item is in content
                T targetItem = _items[target];

                while (target != _head)
                {
                    if (target + 1 == _size)
                    {
                        _items[target] = _items[0];
                        target = 0;
                        continue;
                    }

                    _items[target] = _items[target + 1];
                    target++;
                }

                _items[_head] = targetItem;

                return;
            }

            // when item is not in content
            _items[_tail] = item;
            _tail++;

            if (_tail == _size)
            {
                _tail = 0;
            }

            _head++;

            if (_head == _size)
            {
                _head = 0;
            }
        }

        private bool Contains(T item, out int location)
        {
            int index = _head;
            location = -1;

            while (index != _tail)
            {
                if (_items[index] != null && item.Equals(_items[index]))
                {
                    location = index;
                    return true;
                }

                index--;

                if (index == -1)
                {
                    index = _size - 1;
                }
            }

            return false;
        }
    }
}
