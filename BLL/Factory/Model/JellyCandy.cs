using BLL.Factory.Model.Interfaces;

namespace BLL.Factory.Model
{
    public class JellyCandy : ICandy
    {
        private string _name;

        public JellyCandy(string name)
        {
            _name = name;
        }

        public string Taste()
        {
            return $"Jelly candy \"{_name}\" soft as clouds";
        }
    }
}