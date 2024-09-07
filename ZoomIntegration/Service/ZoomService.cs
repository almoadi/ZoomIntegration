using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using ZoomIntegration.DTO;
using ZoomIntegration.Helpers;
using ZoomIntegration.Model;

namespace ZoomIntegration.Service
{
    public class ZoomService : IZoomService
    {

        public string GetToken()
        {
            // Credentials
            var clientId = ConfigKey.GetKey("Api-keys:ClientID");
            var clientSecret = ConfigKey.GetKey("Api-keys:ClientSecret");
            var authString = $"{clientId}:{clientSecret}";
            var authStringBase64 = Convert.ToBase64String(Encoding.ASCII.GetBytes(authString));

            var zoomUrl = $"https://zoom.us/oauth/token?grant_type=account_credentials&account_id={ConfigKey.GetKey("Api-keys:account_id")}";
            var client = new RestClient(zoomUrl);
            var request = new RestRequest(zoomUrl, Method.Post);
            request.AddHeader("Authorization", $"Basic {authStringBase64}");

            var response = client.Execute(request);

            if (response.IsSuccessful)
            {
                var json = JObject.Parse(response.Content);
                var token = json["access_token"].ToString();

                return token;
            }

            var error = response.Content;

            return error;
        }

        public ZoomResponse CreateMeeting(CreateMeeting meeting)
        {
            var token = GetToken();
            var obj = $@"
    {{
        ""topic"": ""{meeting.topic}"",
        ""type"": 2, 
        ""start_time"": ""{meeting.start_time:yyyy-MM-ddTHH:mm:ssZ}"",
        ""timezone"": ""Africa/Cairo"",
        ""duration"": ""{meeting.duration}"",
        ""password"": """",
        ""agenda"": ""CLASS LESSON"",
        ""settings"": {{
            ""host_video"": false,
            ""participant_video"": false,
            ""cn_meeting"": false,
            ""in_meeting"": false,
            ""jbh_time"": 0,
            ""waiting_room"": false,
            ""join_before_host"": true,
            ""mute_upon_entry"": false,
            ""watermark"": false,
            ""use_pmi"": true,
            ""approval_type"": 2,
            ""registration_type"": 1,
            ""audio"": ""both"",
            ""auto_recording"": ""none"",
            ""registrants_email_notification"": true
        }}
    }}";

            var url = "https://api.zoom.us/v2/users/me/meetings";

            var client = new RestClient(url);
            var request = new RestRequest(url, Method.Post);

            request.AddHeader("Authorization", $"Bearer {token}");
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", obj, ParameterType.RequestBody);

            var response = client.Execute(request);
            return new ZoomResponse
            {
                IsSuccessful = response.IsSuccessful,
                Content = response.Content,
                ErrorMessage = response.IsSuccessful ? null : response.StatusDescription 
            };


        }
    }
}
