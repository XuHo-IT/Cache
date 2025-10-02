using Microsoft.Extensions.Caching.Distributed;

namespace Demo_Cache.DistributedCache
{
    public class DistributedCacheDemo
    {
        private readonly IDistributedCache _cache;

        public DistributedCacheDemo(IDistributedCache cache)
        {
            _cache = cache;
        }

        public async Task<string> GetDataAsync(string key)
        {
            var value = await _cache.GetStringAsync(key);
            if (value == null)
            {
                value = $"Data from DB at {DateTime.Now}";
                await _cache.SetStringAsync(key, value,
                    new DistributedCacheEntryOptions
                    {
                        AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(20)
                    });
            }

            return value;
        }
    }
}
//Lần đầu → lấy DB → lưu Redis.
//Các lần sau từ bất kỳ server nào cũng đọc từ Redis (cache dùng chung).