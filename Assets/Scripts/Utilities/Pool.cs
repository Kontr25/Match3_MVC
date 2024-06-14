using System;
using System.Collections.Generic;

namespace Utilities
{
    public class Pool<T> where T : class
    {
        /// <summary>
        /// Пул
        /// </summary>
        private List<T> _pool = new List<T>();

        public void AddToPool(T item)
        {
            if (!_pool.Contains(item))
                _pool.Add(item);
        }

        public T GetFreeItem(Func<T, bool> isActive)
        {
            foreach (var item in _pool)
            {
                if (!isActive(item))
                {
                    return item;
                }
            }

            return null;
        }

        public T GetItemByProperties(Func<T, bool> propertiesMatch)
        {
            foreach (var item in _pool)
            {
                if (propertiesMatch(item))
                    return item;
            }

            return null;
        }
    }
}