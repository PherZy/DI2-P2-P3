﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class CreatePasswordDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Notes { get; set; }
        public int ApplicationId { get; set; }
    }
}
