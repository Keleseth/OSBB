using System;
using BLL.Adapter.Models;
using BLL.Factory.Model.Interfaces;

namespace BLL.Adapter
{
    public class CandyToTorteAdapter : ITorte
    {
        private readonly ICandy _candy;

        public CandyToTorteAdapter(ICandy candy)
        {
            _candy = candy;
        }

        public string TakePieceOfTorte()
        {
            Console.WriteLine("Sorry, but this cake is hiding sweets inside.");
            return _candy.Taste();
        }
    }
}