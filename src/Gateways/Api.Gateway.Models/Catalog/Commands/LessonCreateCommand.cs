﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Gateway.Models.Catalog.Commands
{
    public class LessonCreateCommand
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
