using BLL.Factory.Model.Interfaces;

namespace BLL.Factory.Model
{
    public class ChocolateCandy : ICandy
    {
        private string _name;

        public ChocolateCandy(string name)
        {
            _name = name;
        }

        public string Taste()
        {
            return $"Candy \"{_name}\" is chocolate ! No panic!";
        }
    }
}