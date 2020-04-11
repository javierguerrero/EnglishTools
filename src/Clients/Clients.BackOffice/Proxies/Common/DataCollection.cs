﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clients.BackOffice.Proxies.Common
{
    public class DataCollection<T>
    {
        public bool HasItems { get; set; }
        public IEnumerable<T> Items { get; set; }
        public int Total { get; set; }
        public int Page { get; set; }
        public int Pages { get; set; }
    }
}
