using BLL.Factory.Model;
using BLL.Factory.Model.Interfaces;

namespace BLL.Factory
{
    public class CandyFactory
    {
        public CandyFactory()
        {

        }

        public ICandy CreateInstance(int price, string name)
        {
            if (price > 0 && price < 5)
            {
                return new CaramelCandy(name);
            }
            else if (price < 10)
            {
                return new ChocolateCandy(name);
            }
            else 
            {
                return new JellyCandy(name);
            }
        }
    }
}