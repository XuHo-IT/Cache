using Microsoft.Extensions.Caching.Memory;

namespace Demo_Cache.InMemoryCache
{
    public class InMemoryCacheDemo
    {
        private readonly IMemoryCache _cache;

        public InMemoryCacheDemo(IMemoryCache cache)
        {
            _cache = cache;
        }

        public string GetData(string key)
        {
            if (!_cache.TryGetValue(key, out string value))
            {
                // Giả sử tốn 2s để load dữ liệu từ DB
                value = $"Data from DB at {DateTime.Now}";
                _cache.Set(key, value, TimeSpan.FromSeconds(10)); // cache 10s
            }

            return value;
        }
    }
}
//Lần đầu gọi GetData("user:1") → cache chưa có → lấy DB → lưu cache.
//Lần 2 gọi trong vòng 10s → lấy từ cache → nhanh hơn nhiều.
