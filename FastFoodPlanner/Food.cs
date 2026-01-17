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
        long _price, _ID;

        static long max_ID;

        public string name
        {
            get { return _name; }
            set { if (value.Trim() != "") _name = value; }
        }

        public long price
        {
            get { return _price; }
            set { _price = value; }
        }

        public string description
        {
            get { return _description; } 
            set { if (_description.Trim() != "") _description = value; }
        }

        public long ID
        {
            get { return _ID; }
        }

        public Food(long _ID, string _name, long _price,  string _description)
        {
            this._ID = _ID;
            this._name = _name;
            this._price = _price;
            this._description = _description;
            max_ID = _ID;
        }

        public Food(string _name, long _price, string _description)
        {
            this._name = _name;
            this._price = _price;
            this._description = _description;
            _ID = ++max_ID;
        }

        public override string ToString() 
        {
            return _ID.ToString() + "  " + _name + ". Стоимость: " + _price.ToString();
        }
    }
}
