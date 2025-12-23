using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFoodPlanner
{
    internal class Food
    {
        string _name, _description;
        double _price;

        public string name
        {
            get { return _name; }
            set { if (value.Trim() != "") _name = value; }
        }

        public double price
        {
            get { return _price; }
            set { _price = value; }
        }

        public string description
        {
            get { return _description; } 
            set { if (_description.Trim() != "") _description = value; }
        }

        public Food(string _name, double _price,  string _description)
        {
            this._name = _name;
            this._price = _price;
            this._description = _description;
        }

        public override string ToString() 
        {
            return _name + ". Стоимость: " + _price.ToString();
        }
    }
}
