using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Dz4
{
    class Purchases : ICollection<Purchase>
    {
        Purchase[] _purchasesArray;
        public int Count { get; private set; }
        public bool IsReadOnly => false;

        public Purchases()
        {
            _purchasesArray = new Purchase[5];
            Count = 0;
        }

        public IEnumerable<string> GetPurchasersByCategory(string category) => _purchasesArray.Where(p => p.Category == category).Select(p => p.Purchaser);
        public IEnumerable<string> GetCategoresByPurchaser(string purchaser) => _purchasesArray.Where(p => p.Purchaser == purchaser).Select(p => p.Category);

        public void Add(string purchaser, string category) => (this as ICollection<Purchase>).Add(new Purchase(purchaser, category));
        void ICollection<Purchase>.Add(Purchase item)
        {
            TryResize();
            _purchasesArray[Count] = item;
            Count++;
        }
        public void Clear() => Count = 0;
        bool ICollection<Purchase>.Contains(Purchase item) => _purchasesArray.Contains(item);
        public bool Contains(string purchaser, string category) => (this as ICollection<Purchase>).Contains(new Purchase(purchaser, category));
        public void CopyTo(Purchase[] array, int arrayIndex) => _purchasesArray.CopyTo(array, arrayIndex);
        bool ICollection<Purchase>.Remove(Purchase item)
        {
            if (Array.IndexOf(_purchasesArray, item) is var pos && pos != -1)
            {
                for (int i = pos + 1; i < Count; i++)
                    _purchasesArray[i - 1] = _purchasesArray[i];

                Count--;
                return true;
            }
            return false;
        }
        public bool Remove(string purchaser, string category) => (this as ICollection<Purchase>).Remove(new Purchase(purchaser, category));
        public IEnumerator<Purchase> GetEnumerator() => _purchasesArray.Take(Count).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        void TryResize()
        {
            if (Count == _purchasesArray.Length)
                Array.Resize(ref _purchasesArray, _purchasesArray.Length * 2);
        }
    }
}
