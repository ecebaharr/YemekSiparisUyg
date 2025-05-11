namespace SignalR.EntityLayer.Entities
{
    public class Contact
    {
        public int ContactID { get; set; }
        public string Location { get; set; }

        public string Phone { get; set; }        
        public string Mail { get; set; }

        public string FooterDescripton { get; set; }
        public string FooterTitle { get; set; }
        public string OpenDays { get; set; }
        public string OpenDaysDescripton { get; set; }
        public string OpenHours { get; set; }

    }
}
