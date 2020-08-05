using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecureAPI.Service
{
    public interface ICacheService
    {
        T Get<T>(string key);
        T Set<T>(string key, T value);
        void DeleteFromCache(string key);
        void ClearCache();

    }
}
