﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakery.ClassLibrary.Services;

public interface IDbLocation
{
    public string DbName { get; }
    public string BaseDataDirecory { get; }
}
