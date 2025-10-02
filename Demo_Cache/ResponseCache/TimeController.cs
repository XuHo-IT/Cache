using Microsoft.AspNetCore.Mvc;

namespace Demo_Cache.ResponseCache
{
    [ApiController]
    [Route("api/[controller]")]
    public class TimeController : ControllerBase
    {
        [HttpGet]
        [ResponseCache(Duration = 30)]
        public IActionResult GetTime()
        {
            return Ok($"Server time: {DateTime.Now}");
        }
    }
}
//Khi gọi GET /api/time, lần đầu server trả về thời gian.
//Trong 30s tiếp theo, client nhận response từ cache → server không cần xử lý lại.