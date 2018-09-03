using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Dz4
{
    class Purchases : ICollection<Purchase>
    {
        Purchase[] PurchasesArray { get; set; }
        int _count { get; set; }
        public int Count => _count;
        public bool IsReadOnly => false;

        public Purchases()
        {
            PurchasesArray = new Purchase[5];
            _count = 0;
        }

        public IEnumerable<string> GetPurchasersByCategory(string category) => PurchasesArray.Where(p => p.Category == category).Select(p => p.Purchaser);
        public IEnumerable<string> GetCategoresByPurchaser(string purchaser) => PurchasesArray.Where(p => p.Purchaser == purchaser).Select(p => p.Category);

        public void Add(string purchaser, string category) => (this as ICollection<Purchase>).Add(new Purchase(purchaser, category));
        void ICollection<Purchase>.Add(Purchase item)
        {
            TryResize();
            PurchasesArray[_count] = item;
            _count++;
        }
        public void Clear() => _count = 0;
        bool ICollection<Purchase>.Contains(Purchase item) => PurchasesArray.Contains(item);
        public bool Contains(string purchaser, string category) => (this as ICollection<Purchase>).Contains(new Purchase(purchaser, category));
        public void CopyTo(Purchase[] array, int arrayIndex) => PurchasesArray.CopyTo(array, arrayIndex);
        bool ICollection<Purchase>.Remove(Purchase item)
        {
            if (Array.IndexOf(PurchasesArray, item) is var pos && pos != -1)
            {
                for (int i = pos + 1; i < _count; i++)
                    PurchasesArray[i - 1] = PurchasesArray[i];

                _count--;
                return true;
            }
            return false;
        }
        public bool Remove(string purchaser, string category) => (this as ICollection<Purchase>).Remove(new Purchase(purchaser, category));
        public IEnumerator<Purchase> GetEnumerator()
        {
            foreach (Purchase v in this as IEnumerable)
                yield return v;
        }
        IEnumerator IEnumerable.GetEnumerator() => PurchasesArray.GetEnumerator();
        void TryResize()
        {
            if (_count == PurchasesArray.Length)
            {
                var tmp = new Purchase[PurchasesArray.Length * 2];
                PurchasesArray.CopyTo(tmp, 0);
                PurchasesArray = tmp;
            }
        }
    }
}
