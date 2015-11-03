using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Enyim.Caching;

namespace CurrencyStore.Business
{
    public class ConnectionCounter
    {
        MemcachedClient _client = new MemcachedClient();
        public static ConnectionCounter Current = new ConnectionCounter();
        public void Increase(string key, int i)
        {
            var val = _client.Get<int>(key);

            if (val == 0)
            {
            }

            val += i;

            _client.AddOrReplace(key, val);
        }
        public void Decrease(string key)
        {
            var val = _client.Get<int>(key);

            val -= 1;

            if (val <= 0)
            {
                val = 0;
            }

            _client.AddOrReplace(key, val);
        }
        public void Reset(string key)
        {
            _client.AddOrReplace(key, 0);
        }
        public int this[string key]
        {
            get
            {
                return _client.Get<int>(key);
            }

            internal set
            {
                _client.AddOrReplace(key, value);
            }
        }
    }
}
