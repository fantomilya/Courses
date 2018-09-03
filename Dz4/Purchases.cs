using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Dz4
{
    class Purchases : ICollection<Purchase>
    {
        Purchase[] purchases;
        int _count;
        public int Count => _count;
        public bool IsReadOnly => false;

        public Purchases()
        {
            purchases = new Purchase[5];
            _count = 0;
        }
        public IEnumerable<string> GetPurchasersByCategory(string category) => purchases.Where(p => p.Category == category).Select(p => p.Purchaser);
        public IEnumerable<string> GetCategoresByPurchaser(string purchaser) => purchases.Where(p => p.Purchaser == purchaser).Select(p => p.Category);

        public void Add(string purchaser, string category) => (this as ICollection<Purchase>).Add(new Purchase(purchaser, category));
        void ICollection<Purchase>.Add(Purchase item)
        {
            if (_count == purchases.Length)
            {
                var tmp = new Purchase[purchases.Length * 2];
                purchases.CopyTo(tmp, 0);
                purchases = tmp;
            }
            purchases[_count] = item;
            _count++;
        }
        public void Clear() => _count = 0;
        bool ICollection<Purchase>.Contains(Purchase item) => purchases.Contains(item);
        public bool Contains(string purchaser, string category) => (this as ICollection<Purchase>).Contains(new Purchase(purchaser, category));
        public void CopyTo(Purchase[] array, int arrayIndex) => purchases.CopyTo(array, arrayIndex);
        bool ICollection<Purchase>.Remove(Purchase item)
        {
            if (Array.IndexOf(purchases, item) is var pos && pos != -1)
            {
                for (int i = pos + 1; i < _count; i++)
                    purchases[i - 1] = purchases[i];

                _count--;
                return true;
            }
            return false;
        }
        public bool Remove(string purchaser, string category) => (this as ICollection<Purchase>).Remove(new Purchase(purchaser, category));
        public IEnumerator<Purchase> GetEnumerator()
        {
            for (int i = 0; i < _count; i++)
                yield return purchases[i];
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    }
}
