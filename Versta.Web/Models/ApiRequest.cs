using System.Security.AccessControl;

namespace Versta.Web.Models
{
    public class ApiRequest
    {
        public SD.ApiType ApiType { get; set; }
        public string Url { get; set; } = string.Empty;
        public object? Data { get; set; }
    }
}
