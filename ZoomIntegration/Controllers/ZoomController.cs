using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ZoomIntegration.DTO;
using ZoomIntegration.Model;
using ZoomIntegration.Service;

namespace ZoomIntegration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZoomController : ControllerBase
    {
        private readonly IZoomService _zoomService;

        public ZoomController(IZoomService zoomService)
        {
            _zoomService = zoomService;
            
        }

        [HttpGet]
        [Route("GetAccessToken")]
        public IActionResult GetAccessToken()
        {  
            return Ok(_zoomService.GetToken());
        }

        [HttpPost("CreateMeeting")]
        public ActionResult<CreateMeeting> CreateMeeting([FromBody] CreateMeeting meeting)
        {
            var output = _zoomService.CreateMeeting(meeting);
            if(output.IsSuccessful)
            {
                var fainal = JsonConvert.DeserializeObject<MeetingDTO>(output.Content);
                return Ok(fainal);
            }
                return BadRequest(output); 
        }

        
    }
}
