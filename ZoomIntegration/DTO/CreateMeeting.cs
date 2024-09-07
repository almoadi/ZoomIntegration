namespace ZoomIntegration.DTO
{
    public class CreateMeeting
    {
        public DateTime start_date { get; set; }
        public DateTime start_time { get; set; }
        public int duration { get; set; }
        public string topic { get; set; }
    }
}
