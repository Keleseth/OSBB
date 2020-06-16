using System.Collections;
using System.Collections.Generic;
using BLL.Factory.Model.Interfaces;

namespace BLL.Iterator
{
    public class CandyBag : IteratorAggregate
    {
        List<ICandy> _collection = new List<ICandy>();

        bool _direction = false;

        public void ReverseDirection()
        {
            _direction = !_direction;
        }

        public List<ICandy> GetItems()
        {
            return _collection;
        }

        public void AddItem(ICandy item)
        {
            this._collection.Add(item);
        }

        public override IEnumerator GetEnumerator()
        {
            return new CandyIterator(this, _direction);
        }
    }
}
