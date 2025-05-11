using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRWebUı.Dtos.ContactDtos
{

   public class ResultContactDto
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
