﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Core.DTOs
{
    public class ContactUpdateDto : BaseUpdateDto
    {
        public int OwnerId { get; set; }
    }
}
