namespace WPF_FlightAppEF
{
    public class TicketDto
    {
        public int Id { get; set; }
        public int ScheduleId { get; set; }
        public int FlightTypeId { get; set; }
        public string ScheduleName { get; set; }
        public string FlightTypeName { get; set; }
    }
}
