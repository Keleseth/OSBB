using System.Collections.Generic;
using BLL.Observer.Interfaces;

namespace BLL.Observer
{
    public class СandyVan : IObservable
    {
        List<IObserver> observers;
        private int _candies;

        public СandyVan()
        {
            observers = new List<IObserver>();
            _candies = 10;
        }

        public void SellSomeCandies(int newPopulation)
        {
            _candies--;
            NotifyObservers();
        }

        public void RegisterObserver(IObserver o)
        {
            observers.Add(o);
        }

        public void RemoveObserver(IObserver o)
        {
            observers.Remove(o);
        }

        public void NotifyObservers()
        {
            foreach (var o in observers)
            {
                o.Update(_candies);
            }
        }
    }
}