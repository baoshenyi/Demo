using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Threading;

namespace SecureAPI.Service
{
    /// <summary>
    /// Demo cache code to show 
    /// 1. thread safe 
    /// 2. dependecy injection
    /// 3. exception handling
    /// It could not used for a real project 
    /// since cache value should be comparied to DB value after certain time
    /// </summary>
    public class CacheService : ICacheService {
        private ILogger _logger;
        internal ObjectCache cacheItemList;
        internal ReaderWriterLockSlim lockObject = new ReaderWriterLockSlim(LockRecursionPolicy.SupportsRecursion);
        internal CacheItemPolicy Policy;

        public CacheService(ILogger logger) {
            cacheItemList = MemoryCache.Default;
            Policy = new CacheItemPolicy
            {
                AbsoluteExpiration = System.DateTimeOffset.UtcNow.AddHours(1)
            };
            _logger = logger;
        }

        public T Get<T>(string key)
        {
            lockObject.EnterReadLock();
            try
            {
                var item = cacheItemList[key];
                if (item == null)
                    return default;
                if (item is T t)
                    return t;
                return default;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return default;
            }
            finally
            {
                lockObject.ExitReadLock();
            }
        }

        public T Set<T>(string key, T value) {
            lockObject.EnterWriteLock();
            try {
                var itemToRemove = cacheItemList.SingleOrDefault(w => w.Key.ToLower().Equals(key.ToLower()));
                if (itemToRemove.Value != null)
                    cacheItemList.Remove(key);
                cacheItemList.Set(key, value, Policy);
            }
            catch (Exception ex) {
                _logger.LogError(ex.Message);
                return default;
            }
            finally {
                lockObject.ExitWriteLock();
            }
            return value;
        }

        public void DeleteFromCache(string key)
        {
            lockObject.EnterWriteLock();
            try
            {
                cacheItemList.Remove(key);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw ex;
            }
            finally
            {
                lockObject.ExitWriteLock();
            }
        }

        public void ClearCache()
        {
            lockObject.EnterWriteLock();
            try
            {
                cacheItemList.ToList().ForEach(i => cacheItemList.Remove(i.Key));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw ex;
            }
            finally
            {
                lockObject.ExitWriteLock();
            }
        }
    }
}