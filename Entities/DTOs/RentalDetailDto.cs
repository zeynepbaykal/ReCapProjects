﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class RentalDetailDto
    {
        public string UserName { get; set; }
        public string CarName { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
