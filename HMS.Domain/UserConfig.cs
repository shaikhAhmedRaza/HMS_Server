﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HMS.Domain
{
   public class UserConfig:BaseEntity
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
    }
}