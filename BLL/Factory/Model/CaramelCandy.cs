using BLL.Factory.Model.Interfaces;

namespace BLL.Factory.Model
{
    public class CaramelCandy : ICandy
    {
        private string _name;

        public CaramelCandy(string name)
        {
            _name = name;
        }

        public string Taste()
        {
            return $"Caramel candy \"{_name}\" is a little hard, be careful to break your teeth";
        }
    }
}