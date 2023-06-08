using Versta.Web.Models;

namespace Versta.Web.Services.Interfaces
{
    public interface IBaseService
    {
        Task<ResponseDto> SendAsync(ApiRequest apiRequest);
    }
}
