using System;
using System.Collections.Generic;
using System.Text;

namespace EffortlessEnglish.Domain
{
    public class Class
    {
        public int ClassId { get; set; }
        public string Name { get; set; }
        public List<Lesson> Lessons { get; set; }
    }
}