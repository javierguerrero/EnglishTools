using System;
using System.Collections.Generic;
using System.Text;
using static Catalog.Common.Enums;

namespace Catalog.Service.Queries.DTOs
{
    public class LessonDto
    {
        public int LessonId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}


