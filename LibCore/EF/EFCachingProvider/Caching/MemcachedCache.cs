using System;
using System.Collections.Generic;
using Enyim.Caching;
using Enyim.Caching.Memcached;

namespace SysPro.Core.EF.EFCachingProvider.Caching
{

    public class MemCachedCache : ICache
    {
        private static MemcachedClient _instant;

        /// <summary>
        /// Gets the instant.
        /// </summary>
        /// <value>
        /// The instant.
        /// </value>
        public static MemcachedClient Instant
        {
            get { return _instant ?? (_instant = new MemcachedClient()); }
        }

        public bool GetItem(string key, out object value)
        {
            value = Instant.Get(key);
            return value != null;
        }

        public void PutItem(string key, object value, IEnumerable<string> dependentEntitySets, TimeSpan slidingExpiration,
                            DateTime absoluteExpiration)
        {
            Instant.Store(StoreMode.Add, key, value);
        }

        public void InvalidateSets(IEnumerable<string> entitySets)
        {
            throw new NotImplementedException();
        }

        public void InvalidateItem(string key)
        {
            throw new NotImplementedException();
        }
    }
}