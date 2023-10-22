using System.Collections.Generic;

namespace APWeather.Services
{
    public class DataResponse
    {
        public bool IsSuccess { get; set; }
        public object Data { get; set; }
        public List<string> Errors { get; set; }
    }
}