using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFoodPlanner
{
    internal class Ingredient
    {
        string _name;
        long _count;

        public string name
        {
            get { return _name; }
            set { if (value.Trim() != "")  _name = value; }
        }

        public long count
        {
            get { return _count; }
            set { if (value >= 0) _count = value; }
        }

        public Ingredient(string _name,  long _count)
        {
            this._name = _name;
            this._count = _count;
        }

        public override string ToString()
        {
            return _name + ". Количество: " + _count;
        }
    }
}
