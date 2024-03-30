namespace backend.Models
{
    public class TicketModel
    {
        public string ticket_id { get; set; }
        public string ticket_title { get; set; }
        public string ticket_description { get; set; }
        public string ticket_contact { get; set; }
        public string ticket_status { get; set; }
        public string ticket_time_create { get; set; }
        public string ticket_time_update { get; set; }
    }
}
