using ZoomIntegration.DTO;
using ZoomIntegration.Model;

namespace ZoomIntegration.Service
{
    public interface IZoomService
    {

        public string GetToken();

        public ZoomResponse CreateMeeting(CreateMeeting createMeeting);
    }
}
