using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adventofcode.Lib
{
    public class AutoAddingDictionary<TKey, TValue> : Dictionary<TKey, TValue> where TValue : new()
    {
        public new TValue this[TKey key]
        {
            get
            {
                if (!ContainsKey(key))
                    Add(key, new TValue());
                return base[key];
            }
            set
            {
                if (!ContainsKey(key))
                    Add(key, value);
                base[key] = value;
            }
        }
    }
}
