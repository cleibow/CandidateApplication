﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDatabaseLayer.Models
{
    public abstract class IEntity
    {
        DateTime Created { get; set; }
        DateTime? Modified { get; set; }
    }
}
