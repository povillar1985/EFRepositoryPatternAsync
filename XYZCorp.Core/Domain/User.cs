﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XYZCorp.Core.Domain
{
    public class User: BaseEntity
    {
        public string Name { get; set; }
        public int Points { get; set; }
    }
}
