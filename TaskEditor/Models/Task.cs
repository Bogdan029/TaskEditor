﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskEditor.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}