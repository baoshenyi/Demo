using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace SecureAPI.Service.Tests
{
    [TestClass()]
    /// Demo unit test to show basic process
    /// Initilize the mock objects
    /// Test data, action and assert
    /// Functional test: combines sequencial function steps in one test
    public class CacheServiceTests
    {
        private Mock<ILogger> _mockLogger;
        private CacheService _cacheService;
        [TestInitialize]
        public void SetUp()
        {
            _mockLogger = new Mock<ILogger>();
            _cacheService = new CacheService(_mockLogger.Object);
        }


        [TestMethod()]
        public void Get_T_Test()
        {
            var key = "key";

            T result = _cacheService.Get<T>(key);


            Assert.IsNull(result);
        }

        [TestMethod()]
        public void Set_T_Test()
        {
            var key = "key";
            T value = new T()
            {
                Name = "Shenyi",
                Age = 25
            };

            T result = _cacheService.Set<T>(key, value);

            Assert.IsNotNull(result);
            Assert.AreEqual<T>(result,value);//this is stronger than result.Name==value.Name
        }

        [TestMethod()]
        public void Set_Get_T_Test()//this is a simple functional test
        {
            var key = "key";
            T value = new T()
            {
                Name = "Shenyi",
                Age = 25
            };

            _ = _cacheService.Set<T>(key, value);
            T getResult = _cacheService.Get<T>(key);
            Assert.IsNotNull(getResult);
            Assert.AreEqual<T>(getResult, value);
        }

        [TestMethod()]
        public void Set_Delete_Get_T_Test()
        {
            var key = "key";
            T value = new T()
            {
                Name = "Shenyi",
                Age = 25
            };

            _ = _cacheService.Set<T>(key, value);
            _cacheService.DeleteFromCache(key);
            T getResult = _cacheService.Get<T>(key);
            Assert.IsNull(getResult);
        }

        [TestMethod()]
        public void Set_Clear_Cache_Get_T_Test()
        {
            var key = "key";
            T value = new T()
            {
                Name = "Shenyi",
                Age = 25
            };

            _ = _cacheService.Set<T>(key, value);
            _cacheService.ClearCache();
            T getResult = _cacheService.Get<T>(key);
            Assert.IsNull(getResult);
        }


        private class T
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }
    }
}