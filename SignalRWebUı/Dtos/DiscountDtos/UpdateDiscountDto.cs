﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRWebUı.Dtos.DiscountDtos
{
    public class UpdateDiscountDto
    {
        public int DiscountID { get; set; }
        public string Title { get; set; }
        public bool Status { get; set; }
        public string Amount { get; set; }
        public string Description { get; set; }

        public string ImageUrl { get; set; }
    }
}
