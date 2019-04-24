using System;
using System.Collections.Generic;
using System.Linq;

namespace Randomizer
{
    /// <summary>
    /// A class to pick random items from a list.
    /// </summary>
    /// <see>
    /// For usage see: https://github.com/kaleidawave/randomizer
    /// </see>
    public class Randomizer<T> where T : IWeighted
    {
        private IList<T> _entries;
        private Random _random;
        private int _totalWeight;

        public Randomizer(List<T> entries)
        {
            this._entries = entries;
            this._random = new Random();
            this._totalWeight = entries.Sum(x => x.Weight);
        }

        /// <summary>
        /// Returns a random item from the collection
        /// </summary>
        /// <remarks>Items with a greater weight will appear more frequent</remarks>
        public T Pick()
        {
            int picked = this._random.Next(0, this._totalWeight) + 1;
            foreach (T item in this._entries)
            {
                picked -= item.Weight;
                if (picked <= 0) return item;
            }
            throw new Exception("Outside of range"); // This should not throw
        }
    }

    /// <summary>
    /// Object has a weight for when picked by a tombolo
    /// </summary>
    public interface IWeighted
    {
        int Weight { get; set; }
    }
}
