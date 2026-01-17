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
        long _count, _ID;

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

        public long ID
        {
            get { return _ID; }
        }

        public Ingredient(string _name,  long _count)
        {
            this._name = _name;
            this._count = _count;
        }

        public Ingredient(long _ID, string _name, long _count)
        {
            this._name = _name;
            this._count = _count;
            this._ID = _ID;
        }

        public override string ToString()
        {
            return _name + ". Количество: " + _count;
        }
    }
}
