using System.Collections;
using System.Collections.Generic;
using BLL.Adapter.Models;
using BLL.Iterator;

namespace BLL.Adapter.VillageCollection
{
    public class TorteShowcase : IteratorAggregate
    {
        List<ITorte> _collection = new List<ITorte>();

        bool _direction = false;

        public void ReverseDirection()
        {
            _direction = !_direction;
        }

        public List<ITorte> getItems()
        {
            return _collection;
        }

        public void AddItem(ITorte item)
        {
            this._collection.Add(item);
        }

        public override IEnumerator GetEnumerator()
        {
            return new TorteIterator(this, _direction);
        }
    }
}
