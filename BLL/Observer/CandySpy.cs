using System;
using BLL.Observer.Interfaces;

namespace BLL.Observer
{

    public class CandySpy : IObserver
    {
        private IObservable _candyVan;

        public CandySpy(IObservable candyVan)
        {
            _candyVan = candyVan;
            _candyVan.RegisterObserver(this);
        }

        public void Update(object ob)
        {
            var candies = (int)ob;

            Console.WriteLine($"Van sell some candies, watch out there's only {candies} left");
        }
    }
}